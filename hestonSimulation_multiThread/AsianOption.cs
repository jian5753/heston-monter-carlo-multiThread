using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hestonSimulation_multiThread
{
    class AsianOptionFixCall : PathDepOption_heston
    {
        public AsianOptionFixCall
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double[] sPath)
        {
            double mean = Utils.Mean(sPath);
            return Math.Max(mean - k, 0);
        }
    }
}
