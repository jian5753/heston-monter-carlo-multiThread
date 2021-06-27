using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace hestonSimulation_multiThread
{
    class QuadraticRegression
    {
        #region attributes
        private double beta0;
        private double beta1;
        private double beta2;
        #endregion 
        public QuadraticRegression() { beta0 = 0; beta1 = 0; beta2 = 0; }
        public double[] coef()
        {
            double[] ans = new double[3];
            ans[0] = beta0; ans[1] = beta1; ans[2] = beta2;
            return ans;
        }
        public void fit(double[] y, double[] x1)
        {
            if(y.Length != x1.Length)
            {
                throw new dimNotMatchException("length of Y should equals to that of X");
            }
            double[] x2 = Utils.Power(x1, 2);
            double yBar = Utils.Mean(y);
            double x1Bar = Utils.Mean(x1);
            double x2Bar = Utils.Mean(x2);
            double s11 = Utils.Var(x1);
            double s22 = Utils.Var(x2);
            double s12 = Utils.Cov(x1, x2);
            double s1Y = Utils.Cov(x1, y);
            double s2Y = Utils.Cov(x2, y);
            double denominator = s11 * s22 - s12 * s12;
            beta1 = (s1Y * s22 - s2Y * s12) / denominator;
            beta2 = (s2Y * s11 - s1Y * s12) / denominator;
            beta0 = yBar - beta1 * x1Bar - beta2 * x2Bar;

        }
        public double predict(double x)
        {
            return beta0 + beta1 * x + beta2 * x * x;
        }
        public double[] predict(double[] x)
        {
            double[] ans = new double[x.Length];
            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, x.Length), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    ans[i] = predict(x[i]);
                }
            });
            return ans;
        }
        
    }
}
