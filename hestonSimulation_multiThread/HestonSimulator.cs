using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Linq;
using DFinNR;
 
namespace hestonSimulation_multiThread
{
    class HestonSimulator
    {
        #region attributes
        private double s0;
        private double var0;
        private double k;
        private double T;
        private double rf;
        private double rho;
        private double kappa;
        private double theta;
        private double sigma;
        #endregion
        #region constructors
        public HestonSimulator() { }
        public HestonSimulator
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        )
        {
            this.s0 = s0; this.var0 = var0; this.k = k; this.T = T; this.rf = rf;
            this.rho = rho; this.kappa = kappa; this.theta = theta; this.sigma = sigma;
        }
        public HestonSimulator(HestonOption theOption)
        {

            s0 = theOption.getS0();
            var0 = theOption.getVar0();
            k = theOption.getK();
            T = theOption.getT();
            rf = theOption.getRf();
            rho = theOption.getRho();
            kappa = theOption.getKappa();
            theta = theOption.getTheta();
            sigma = theOption.getSigma();
        }
        #endregion;
        #region simulation

        public double[] drawSt(int pathCnt, int pathLen)
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
                //Random rv2 = new Random();
                //Random rv = new Random(range.Item1 + rv2.Next());
                Random rv = new Random(range.Item1);
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
        public double[][] drawSandVPath(int pathLen)
        {
            double[][] ans = new double[2][];
            ans[0] = new double[pathLen + 1];
            ans[1] = new double[pathLen + 1];

            double deltat = T / pathLen;
            double sqrtdt = Math.Sqrt(deltat);
            double Vt = var0;
            double St = s0;
            Random rv = new Random();
            // need to change seed machanism in the future

            double z1;
            double z2;
            double sqrt1_rho2 = Math.Sqrt(1 - rho * rho);

            ans[0][0] = s0; // 0th. row for stock price
            ans[1][0] = var0; // 1th. row for vaolatility

            for (int t = 0; t < pathLen; t++)
            {
                z1 = DStat.N_Inv(rv.NextDouble());
                z2 = DStat.N_Inv(rv.NextDouble());
                z2 = rho * z1 + sqrt1_rho2 * z1;

                St = St * Math.Exp((rf - 0.5 * Vt) * deltat + Math.Sqrt(Vt) * sqrtdt * z1);
                ans[0][t+1] = St;
                Vt = Math.Max(Vt + kappa * (theta - Vt) * deltat + sigma * Math.Sqrt(Vt) * sqrtdt * z2, 0);
                ans[1][t + 1] = Vt;
            }
            return ans;
        }
        #endregion
    }
}
