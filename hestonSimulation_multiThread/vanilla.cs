using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using DFinNR;

namespace hestonSimulation_multiThread
{
    class VanillaOption
    {
        protected double s0; protected double var0; protected double k;
        protected double T; protected double rf;

        public VanillaOption()
        {
            s0 = 0.0; var0 = 0.0; k = 0.0; T = 0.0; rf = 0.0;
        }

        public VanillaOption(double s0, double var0, double k, double T, double rf)
        {
            this.s0 = s0; this.var0 = var0; this.k = k; this.T = T; this.rf = rf;
        }

        public double getS0() { return s0; }
        public double getVar0() { return var0; }
        public double getRf() { return rf; }
        public double getT() { return T; }

        public virtual double payoff(double St)
        {
            throw new notImplementError("not implementation Err");
        }
        
        public double[] payoffs(double[] stArr)
        {
            int length = stArr.Length;
            double[] payoffArr = new double[length];
            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, stArr.Length), parallelOpts, range =>
            {
                for(int i = range.Item1; i < range.Item2; i++)
                {
                    payoffArr[i] = this.payoff(stArr[i]);
                }
            });
            return payoffArr;
        }

        public double priceSampleMean(double[] stArr)
        {
            double[] payoffArr = payoffs(stArr);
            double mean = Utils.Mean(payoffArr);
            return mean / Math.Exp(-rf * T);
        }

        public double priceSampleVar(double[] stArr)
        {
            double ans = 0;
            double sampleMean = priceSampleMean(stArr);
            #region parallized version (commentted out)
            /*
            Parallel.ForEach<double, double>(
                payoffArr, () => 0.0, (j, loop, subtotal) =>
                {
                    subtotal += payoff(j) * payoff(j);
                    return subtotal;
                },
            (x) => { ans += x; });
            */
            #endregion 

            foreach (double x in stArr)
            {
                ans += Math.Pow(payoff(x) * Math.Exp(-rf * T) - sampleMean, 2);
            }
            ans /= stArr.Length;
            return ans;
        }
    }

    class VanillaOption_heston : VanillaOption
    {
        protected double rho;
        protected double kappa;
        protected double theta;
        protected double sigma;

        public VanillaOption_heston() { }
        public VanillaOption_heston
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf)
        {
            this.rho = rho;
            this.kappa = kappa;
            this.theta = theta;
            this.sigma = sigma;
        }

        public double[] drawSt(int pathLen, int pathCnt)
        {
            double[] stArr = new double[pathCnt];

            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, pathCnt), parallelOpts, range =>
            {
                double deltat = T / pathLen;
                double sqrtdt = Math.Sqrt(deltat);
                double Vt = var0;
                double St = s0;
                Random rv2 = new Random();
                Random rv = new Random(range.Item1 + rv2.Next());
                // need to change seed machanism in the fucture
                double z1;
                double z2;
                double sqrt1_rho2 = Math.Sqrt(1 - rho * rho);
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    for (int t = 0; t < pathLen; t++)
                    {
                        z1 = DStat.N_Inv(rv.NextDouble());
                        z2 = DStat.N_Inv(rv.NextDouble());
                        z2 = rho * z1 + sqrt1_rho2 * z1;

                        St = St * Math.Exp((rf - 0.5 * Vt) * deltat + Math.Sqrt(Vt) * sqrtdt * z1);
                        Vt = Math.Max(Vt + kappa * (theta - Vt) * deltat + sigma * Math.Sqrt(Vt) * sqrtdt * z2, 0);
                    }
                    stArr[i] = St;
                    // reset st, vt when a path is done
                    St = s0;
                    Vt = var0;
                }
            });

            return stArr;
        }

        public Mtrx drawSPath(int pathCnt, int pathLen)
        {
            double[,] stArr = new double[pathCnt, pathLen + 1];

            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, pathCnt), parallelOpts, range =>
            {
                double deltat = T / pathLen;
                double sqrtdt = Math.Sqrt(deltat);
                double Vt = var0;
                double St = s0;
                Random rv2 = new Random();
                Random rv = new Random(range.Item1 + rv2.Next());
                // need to change seed machanism in the future

                double z1;
                double z2;
                double sqrt1_rho2 = Math.Sqrt(1 - rho * rho);
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    stArr[i, 0] = s0;
                    for (int t = 0; t < pathLen; t++)
                    {
                        z1 = DStat.N_Inv(rv.NextDouble());
                        z2 = DStat.N_Inv(rv.NextDouble());
                        z2 = rho * z1 + sqrt1_rho2 * z1;

                        St = St * Math.Exp((rf - 0.5 * Vt) * deltat + Math.Sqrt(Vt) * sqrtdt * z1);
                        stArr[i, t + 1] = St;
                        Vt = Math.Max(Vt + kappa * (theta - Vt) * deltat + sigma * Math.Sqrt(Vt) * sqrtdt * z2, 0);
                    }
                    // reset st, vt when a path is done
                    St = s0;
                    Vt = var0;
                }
            });
            return new Mtrx(ref stArr);
        }
    }
    class VanillaCall : VanillaOption_heston
    {
        public VanillaCall
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public VanillaCall() : base() { }

        public VanillaCall(double k) : base() { this.k = k; }

        public override double payoff(double st) { return Math.Max(st - k, 0); }
    }
    class VanillaPut : VanillaOption_heston
    {
        public VanillaPut(
            double s0, double v0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
            ) : base(s0, v0, k, T, rf, rho, kappa, theta, sigma) { }

        public VanillaPut() : base() { }

        public VanillaPut(double k) : base() { this.k = k; }

        public override double payoff(double st)
        {
            return Math.Max(k - st, 0);
        }
    }
}
