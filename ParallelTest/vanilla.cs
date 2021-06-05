using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }

    class VanillaOption_heston : VanillaOption
    {
        private double rho;
        private double kappa;
        private double theta;
        private double sigma;
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

    class VanillaCall : VanillaOption
    {
        private double rho;
        private double kappa;
        private double theta;
        private double sigma;
        private Mtrx downTri;
        public VanillaCall
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf)
        {
            this.rho = rho;
            this.kappa = kappa;
            this.theta = theta;
            this.sigma = sigma;

            double[,] corrData = { { 1, rho }, { rho, 1 } };
            Mtrx testCorr = new Mtrx(2, 2, ref corrData);
            downTri = testCorr.choleskyDecomp().T();
        }



        public VanillaCall(double k) : base()
        {
            this.k = k;
        }

        public override double payoff(double st)
        {
            return Math.Max(st - k, 0);
        }


        public double payoff(ref Zmtrx scenario)
        {
            int length = scenario.getColCnt();
            double deltat = T / length;
            double sqrtdt = Math.Sqrt(deltat);
            double[] vPath = new double[length + 1];
            double[] sPath = new double[length + 1];


            vPath[0] = var0;
            sPath[0] = s0;

            for (int t = 0; t < length; t++)
            {
                sPath[t + 1] = sPath[t] * Math.Exp((rf - 0.5 * vPath[t]) * deltat + Math.Sqrt(vPath[t]) * sqrtdt * scenario[0, t]);
                vPath[t + 1] = Math.Max(vPath[t] + kappa * (theta - vPath[t]) * deltat + sigma * Math.Sqrt(vPath[t]) * sqrtdt * scenario[1, t], 0);
            }

            double sT = sPath[length];
            //Console.Write($"{sT:F4}, ");
            return payoff(sT);
        }

        public double payoff(Random rv, int length)
        {
            double deltat = T / length;
            double sqrtdt = Math.Sqrt(deltat);
            double[] vPath = new double[length + 1];
            double[] sPath = new double[length + 1];


            vPath[0] = var0;
            sPath[0] = s0;

            for (int t = 0; t < length; t++)
            {
                Zmtrx Zt_indep = new Zmtrx(2, 1, rv);
                Mtrx Zt_corrlated = downTri.dot(Zt_indep);

                sPath[t + 1] = sPath[t] * Math.Exp((rf - 0.5 * vPath[t]) * deltat + Math.Sqrt(vPath[t]) * sqrtdt * Zt_corrlated[0, 0]);
                vPath[t + 1] = Math.Max(vPath[t] + kappa * (theta - vPath[t]) * deltat + sigma * Math.Sqrt(vPath[t]) * sqrtdt * Zt_corrlated[1, 0], 0);
            }

            double sT = sPath[length];
            //Console.Write($"{sT:F4}, ");
            return payoff(sT);
        }
    }

    class VanillaPut : VanillaOption
    {
        public VanillaPut(
            double s0, double v0, double k, double T, double rf
            ) : base(s0, v0, k, T, rf) { }

        public VanillaPut() : base() { }

        public override double payoff(double st)
        {
            return Math.Max(k - st, 0);
        }
    }
}
