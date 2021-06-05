using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;
using DFinNR;

namespace ParallelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region default parameters;
            double s0 = 103.44;
            double k = 100.0;
            double var0 = 0.00770547621786487;
            double rf = 0.001521;
            double T = 1.0;

            double rho = -0.277814270110106;
            double kappa = 2.20366282736578;
            double theta = 0.0164951784035976;
            double sigma = 0.33220849746904;
            #endregion
            #region trial para
            int pathCnt = 40000;
            int pathLen = 365;
            Stopwatch SW = new Stopwatch();
            SW.Start();
            SW.Stop();
            #endregion

            #region test9 parallel payoff
            SW.Restart();
            
            VanillaCall call9 = new VanillaCall(
                s0, var0, k, T, rf, rho, kappa, theta, sigma);
            double[] stArr4 = call9.drawSt(pathLen, pathCnt);
            SW.Stop();
            double t9 = SW.ElapsedMilliseconds;

            SW.Restart();
            double[] payoffArr4 = new double[pathCnt];
            for(int i = 0; i < pathCnt; i++)
            {
                payoffArr4[i] = call9.payoff(stArr4[i]);
            }
            SW.Stop();
            double sampleMean = call9.priceSampleMean(stArr4);
            double sampleVar = call9.priceSampleVar(stArr4);
            

            #endregion
            Console.ReadLine();
        }
    }
}
