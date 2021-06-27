using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace hestonSimulation_multiThread
{
    class VanillaOption_AmrcCall : HestonOption
    {
        public VanillaOption_AmrcCall
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double st)
        {
            return Math.Max(st - k, 0);
        }

        public double meanPrice(ref Mtrx stPanel)
        {
            int length = stPanel.getColCnt();
            double[] y = payoffs(stPanel.getCol(length - 1));
            double[] x1 = stPanel.getCol(length - 2);
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
            double beta1 = (s1Y * s22 - s2Y * s12) / denominator;
            double beta2 = (s2Y * s11 - s1Y * s12) / denominator;
            double beta0 = yBar - beta1 * x1Bar - beta2 * x2Bar;
            return 0.0;
        }

        
    }

}
