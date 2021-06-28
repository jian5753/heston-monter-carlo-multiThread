using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace hestonSimulation_multiThread
{
    class BSMoption
    {
        #region attributes
        protected double s0; protected double var0; protected double k;
        protected double T; protected double rf;
        #endregion
        #region constructors
        public BSMoption()
        {
            s0 = 0.0; var0 = 0.0; k = 0.0; T = 0.0; rf = 0.0;
        }
        public BSMoption(double s0, double var0, double k, double T, double rf)
        {
            this.s0 = s0; this.var0 = var0; this.k = k; this.T = T; this.rf = rf;
        }
        #endregion
        #region query
        public double getS0() { return s0; }
        public double getVar0() { return var0; }
        public double getK() { return k; }
        public double getRf() { return rf; }
        public double getT() { return T; }
        #endregion
        #region payoff
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
        #endregion
        #region pricing
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
        public double AmrcPrice(Mtrx sPanel)
        {
            int pathLen = sPanel.getColCnt();
            double deltaT = T / pathLen;
            double dsctFactor = Math.Exp(-rf * deltaT);
            QuadraticRegression regression = new QuadraticRegression();

            double[] y = payoffs(sPanel.getCol(pathLen - 1));
            
            for (int i = 1; i < pathLen - 1; i++)
            {
                int nextIdx = pathLen - i;
                int currentIdx = nextIdx - 1;

                double[] y_pv = Utils.Mul(y, dsctFactor);
                double[] x = sPanel.getCol(currentIdx);
                double[] exerciseValue = payoffs(x);
                bool[] subset = Utils.greater(exerciseValue, 0);
                
                regression.fit(y_pv, x, subset);

                double[] holdingValue = regression.predict(x);
                bool[] holding = Utils.greaterEqual(holdingValue, exerciseValue);
                for(int pathIdx = 0; pathIdx < sPanel.getRowCnt(); pathIdx++)
                {
                    if (holding[pathIdx]){ y[pathIdx] = y_pv[pathIdx]; }
                    else { y[pathIdx] = exerciseValue[pathIdx]; }
                }
            }
            return Utils.Mean(y);
        }
        #endregion
    }
    class HestonOption : BSMoption
    {
        #region attributes
        protected double rho;
        protected double kappa;
        protected double theta;
        protected double sigma;
        #endregion
        #region constructors
        public HestonOption() { }
        public HestonOption
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
        #endregion
        #region query
        public double getRho() { return rho; }
        public double getKappa() { return kappa; }
        public double getTheta() { return theta; }
        public double getSigma() { return sigma; }
        #endregion
    }
    class VanillaCall_heston : HestonOption
    {
        public VanillaCall_heston
        (
            double s0, double var0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
        ) : base(s0, var0, k, T, rf, rho, kappa, theta, sigma) { }

        public VanillaCall_heston() : base() { }

        public VanillaCall_heston(double k) : base() { this.k = k; }

        public override double payoff(double st) { return Math.Max(st - k, 0); }
    }
    class VanillaPut_heston : HestonOption
    {
        public VanillaPut_heston(
            double s0, double v0, double k, double T, double rf,
            double rho, double kappa, double theta, double sigma
            ) : base(s0, v0, k, T, rf, rho, kappa, theta, sigma) { }

        public VanillaPut_heston() : base() { }

        public VanillaPut_heston(double k) : base() { this.k = k; }

        public override double payoff(double st)
        {
            return Math.Max(k - st, 0);
        }
    }
}
