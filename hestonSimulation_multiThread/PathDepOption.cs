using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using DFinNR;

namespace hestonSimulation_multiThread
{
    class PathDepOption_heston : HestonOption
    {
        #region constructors
        public PathDepOption_heston
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }
        #endregion
        #region hide path indep payoff function
        public override double payoff(double St)
        {
            throw new NotImplementError("can not pass only St to get payoff for path dependent option");
        }
        public new double[] payoffs(double[] stArr)
        {
            throw new NotImplementError("can not pass only St to get payoff for path dependent option");
        }
        public new double priceSampleMean(double[] stArr)
        {
            throw new NotImplementError("can not pass only St to get payoff for path dependent option");
        }
        #endregion
        #region new payoff function for path dep
        public virtual double payoff(double[] sPath)
        {
            throw new NotImplementError("not implementation Err");
        }
        public double[] payoffs(Mtrx sPanel)
        {
            int length = sPanel.getRowCnt();
            double[] payoffArr = new double[length];
            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, length), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    payoffArr[i] = this.payoff(sPanel.getRow(i));
                }
            });
            return payoffArr;
        }
        public double priceSampleMean(Mtrx sPanel)
        {
            double[] payoffArr = payoffs(sPanel);
            double mean = Utils.Mean(payoffArr);
            return mean / Math.Exp(-rf * T);
        }
        #endregion
    }
}
