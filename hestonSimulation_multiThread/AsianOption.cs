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
    class AsianOptionFixPut : PathDepOption_heston
    {
        public AsianOptionFixPut
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double[] sPath)
        {
            double mean = Utils.Mean(sPath);
            return Math.Max(k - mean, 0);
        }
    }
    class AsianOptionFloatCall : PathDepOption_heston
    {
        public AsianOptionFloatCall
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double[] sPath)
        {
            int n = sPath.Length;
            double mean = Utils.Mean(sPath);
            return Math.Max(sPath[n - 1] - mean, 0);
        }
    }
    class AsianOptionFloatPut : PathDepOption_heston
    {
        public AsianOptionFloatPut
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double[] sPath)
        {
            int n = sPath.Length;
            double mean = Utils.Mean(sPath);
            return Math.Max(mean - sPath[n - 1], 0);
        }
    }
    class AsianOptionFixCall_Geo : PathDepOption_heston
    {
        public AsianOptionFixCall_Geo
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double[] sPath)
        {
            double mean = Utils.GeoMean(sPath);
            return Math.Max(mean - k, 0);
        }
    }
    class AsianOptionFixPut_Geo : PathDepOption_heston
    {
        public AsianOptionFixPut_Geo
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double[] sPath)
        {
            double mean = Utils.GeoMean(sPath);
            return Math.Max(k - mean, 0);
        }
    }
    class AsianOptionFloatCall_Geo : PathDepOption_heston
    {
        public AsianOptionFloatCall_Geo
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double[] sPath)
        {
            int n = sPath.Length;
            double mean = Utils.GeoMean(sPath);
            return Math.Max(sPath[n - 1] - mean, 0);
        }
    }
    class AsianOptionFloatPut_Geo : PathDepOption_heston
    {
        public AsianOptionFloatPut_Geo
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public override double payoff(double[] sPath)
        {
            int n = sPath.Length;
            double mean = Utils.GeoMean(sPath);
            return Math.Max(mean - sPath[n - 1], 0);
        }
    }
}
