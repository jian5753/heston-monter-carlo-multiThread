﻿using System;
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
        public HestonSimulator(VanillaOption_heston theOption)
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
        #endregion
    }
    class MonteCarloSimulation_hestonModel
    {
        private VanillaOption option;
        private double s0;
        private double var0;
        private double T;
        private double rf;

        private double rho;
        private double kappa;
        private double theta;
        private double sigma;

        private int pathLen;

        public MonteCarloSimulation_hestonModel()
        {
            s0 = 0; var0 = 0; T = 0; rf = 0;
            rho = 0; kappa = 0; theta = 0; sigma = 0;
            pathLen = 0;
        }

        public MonteCarloSimulation_hestonModel(
            VanillaOption option,
            double rho, double kappa, double theta, double sigma, int pathLen)
        {
            this.option = option;
            s0 = option.getS0(); var0 = option.getVar0(); T = option.getT(); rf = option.getRf();
            this.rho = rho; this.kappa = kappa; this.theta = theta; this.sigma = sigma;
            this.pathLen = pathLen;
        }

        public double[] drawSPath(Random rv)
        {
            double[,] corrData = { { 1, rho }, { rho, 1 } };
            Mtrx testCorr = new Mtrx(2, 2, ref corrData);

            Zmtrx test = new Zmtrx(2, 365, rv);
            Mtrx upTri = testCorr.choleskyDecomp();
            Mtrx dotted = upTri.T().dot(test);

            SVpath hestonPath = new SVpath(
                ref dotted,
                option.getS0(), option.getVar0(),
                kappa, theta, sigma,
                option.getRf(), option.getT() / pathLen);
            return hestonPath.getSpath();

        }

        public double[] drawVPath(Random rv)
        {
            double[,] corrData = { { 1, rho }, { rho, 1 } };
            Mtrx testCorr = new Mtrx(2, 2, ref corrData);

            Zmtrx test = new Zmtrx(2, 365, rv);
            Mtrx upTri = testCorr.choleskyDecomp();
            Mtrx dotted = upTri.T().dot(test);

            SVpath hestonPath = new SVpath(
                ref dotted,
                option.getS0(), option.getVar0(),
                kappa, theta, sigma,
                option.getRf(), option.getT() / pathLen);
            return hestonPath.getVPath();
        }

        public double[][] drawSandVPath(Random rv)
        {
            double[,] corrData = { { 1, rho }, { rho, 1 } };
            Mtrx testCorr = new Mtrx(2, 2, ref corrData);

            Zmtrx test = new Zmtrx(2, pathLen, rv);
            Mtrx upTri = testCorr.choleskyDecomp();
            Mtrx dotted = upTri.T().dot(test);

            SVpath hestonPath = new SVpath(
                ref dotted,
                option.getS0(), option.getVar0(),
                kappa, theta, sigma,
                option.getRf(), option.getT() / pathLen);
            return hestonPath.getSandVPath();
        }

        public double[] drawSt(int pathCnt, Random rv)
        {
            double[] StArr = new double[pathCnt];

            double[,] corrData = { { 1, rho }, { rho, 1 } };
            Mtrx testCorr = new Mtrx(2, 2, ref corrData);

            for (int i = 0; i < pathCnt; i++)
            {
                Zmtrx test = new Zmtrx(2, 365, rv);
                Mtrx upTri = testCorr.choleskyDecomp();
                Mtrx dotted = upTri.T().dot(test);

                SVpath hestonPath = new SVpath
                (
                    ref dotted,
                    option.getS0(), option.getVar0(),
                    kappa, theta, sigma,
                    option.getRf(), option.getT() / pathLen
                );

                StArr[i] = hestonPath.getSt();
            }
            return StArr;
        }

        public double[] DrawSt(int pathCnt, Random rv)
        {
            double[] StArr = new double[pathCnt];

            double[,] corrData = { { 1, rho }, { rho, 1 } };
            Mtrx testCorr = new Mtrx(2, 2, ref corrData);

            ParallelOptions parallelOpts = new ParallelOptions();
            //parallelOpts.MaxDegreeOfParallelism = maxDegree;
            parallelOpts.MaxDegreeOfParallelism = 2;

            Parallel.ForEach(Partitioner.Create(0, pathCnt), parallelOpts, range =>
            {
                for(int i = range.Item1; i < range.Item2; i++)
                {
                    Zmtrx test = new Zmtrx(2, pathLen, rv);
                    Mtrx upTri = testCorr.choleskyDecomp();
                    Mtrx dotted = upTri.T().dot(test);

                    SVpath hestonPath = new SVpath
                    (
                        ref dotted,
                        option.getS0(), option.getVar0(),
                        kappa, theta, sigma,
                        option.getRf(), option.getT()
                    );
                    StArr[i] = hestonPath.getSt();
                } 
            });
            return StArr;
        }

        public double meanPrice(double[] stArr, int pathCnt)
        {
            double ans = 0;
            for (int i = 0; i < pathCnt; i++)
            {
                ans += option.payoff(stArr[i]);
            }
            ans /= pathCnt;
            return ans * Math.Exp(-rf * T);
        }

        public double meanPrice(Random rv, int pathCnt)
        {
            double[] stArr = drawSt(pathCnt, rv);
            return meanPrice(stArr, pathCnt);
        }

        public double MeanPrice(ConcurrentStack<double> payoffStack, int pathCnt)
        {
            double ans = payoffStack.Sum();
            ans /= pathCnt;
            return ans * Math.Exp(-rf * T);
        }

    }
}
