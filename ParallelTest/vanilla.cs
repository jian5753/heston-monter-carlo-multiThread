using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using DFinNR;

namespace ParallelTest
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
            return 0.0;
        }

        public double priceSampleMean(double[] stArr)
        {
            double ans = 0;
            #region parallized version (commentted out)
            /*
            Parallel.ForEach<double, double>(
                payoffArr, () => 0.0, (j, loop, subtotal) =>
            {
                subtotal += payoff(j);
                return subtotal;
            },
            (x) => { ans += x;  });
            ans /= payoffArr.Length;
            ans *= Math.Exp(-rf * T);
            */
            #endregion
            foreach (double x in stArr){
                ans += payoff(x);
            }
            ans /= stArr.Length;
            return ans /= Math.Exp(-rf * T);

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

            foreach(double x in stArr)
            {
                ans += Math.Pow(payoff(x) * Math.Exp(-rf * T) - sampleMean, 2);
            }
            ans /= stArr.Length;
            return ans;
        }
    }

    class VanillaOption_heston : VanillaOption
    {
        private double rho;
        private double kappa;
        private double theta;
        private double sigma;

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
            parallelOpts.MaxDegreeOfParallelism = 2;
            Parallel.ForEach(Partitioner.Create(0, pathCnt), parallelOpts, range =>
            {
                double deltat = T / pathLen;
                double sqrtdt = Math.Sqrt(deltat);
                double Vt = var0;
                double St = s0;
                Random rv = new Random(range.Item1);
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
    }

    class VanillaCall : VanillaOption_heston
    {
        public VanillaCall
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) {}

        public VanillaCall() : base() { }

        public VanillaCall(double k) : base() { this.k = k; }

        public override double payoff(double st) { return Math.Max(st - k, 0);}
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
