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
            double s0 = 101.52;
            double k = 100.0;
            double var0 = 0.00770547621786487;
            double rf = 0.001521;
            double T = 1.0;

            double rho = -0.9;
            double kappa = 1.5;
            double theta = 0.04;
            double sigma = 0.3;
            #endregion
            VanillaCall testCall = new VanillaCall(s0, var0, k, T, rf, rho, kappa, theta, sigma);
            #region trial para
            int taskCnt = 10000;
            int pathLen = 365;
            Random rv = new Random(1234);
            Stopwatch SW = new Stopwatch();
            Stopwatch SW2 = new Stopwatch();
            SW.Start();
            SW.Stop();

            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            #endregion


            #region test6 sequential payoff
            SW.Restart();
            double[] payoffArr = new double[taskCnt];
            for (int i = 0; i < taskCnt; i++)
            {
                Random localRv = new Random(i);
                Zmtrx scenario = new Zmtrx(2, pathLen, rv);
                payoffArr[i] = testCall.payoff(ref scenario);
                //Console.WriteLine($"{payoff}");
                //Thread.Sleep(1);
            }
            SW.Stop();
            double t6 = SW.ElapsedMilliseconds;
            #endregion

            #region test9 parallel payoff
            SW.Restart();
            
            VanillaOption_heston testOption = new VanillaOption_heston(
                s0, var0, k, T, rf, rho, kappa, theta, sigma);
            double[] stArr4 = testOption.drawSt(pathLen, taskCnt);
            SW.Stop();
            double t9 = SW.ElapsedMilliseconds;

            SW.Restart();
            VanillaCall call9 = new VanillaCall(k);
            double[] payoffArr4 = new double[taskCnt];
            for(int i = 0; i < taskCnt; i++)
            {
                payoffArr4[i] = call9.payoff(stArr4[i]);
            }
            SW.Stop();
            double t9_1 = SW.ElapsedMilliseconds;

            #endregion

            #region test8 parallel payoff
            SW.Restart();
            double[] payoffArr3 = new double[taskCnt];
            Parallel.ForEach(Partitioner.Create(0, taskCnt), parallelOpts, range =>
            {
                VanillaCall localCall = new VanillaCall(s0, var0, k, T, rf, rho, kappa, theta, sigma);
                Random localRv = new Random(range.Item1);
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    payoffArr3[i] = testCall.payoff(localRv, pathLen);
                }
                //Thread.Sleep(1);
            });
            SW.Stop();
            double t8 = SW.ElapsedMilliseconds;
            #endregion


            #region test7 parallel payoff
            SW.Restart();
            double[] payoffArr2 = new double[taskCnt];
            Parallel.ForEach(Partitioner.Create(0, taskCnt), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    Zmtrx scenario = new Zmtrx(2, pathLen, rv);
                    payoffArr2[i] = testCall.payoff(ref scenario);
                }
                //Thread.Sleep(1);
            });
            SW.Stop();
            double t7 = SW.ElapsedMilliseconds;
            #endregion

            #region test1
            SW.Start();
            double[][, ] ans1 = new double[taskCnt][,];

            for(int i = 0; i < taskCnt; i++)
            {
                double[,] temp = new double[2, pathLen];
                for (int rowIdx = 0; rowIdx < 2; rowIdx++)
                {        
                    for (int colIdx = 0; colIdx < pathLen; colIdx++)
                    {
                        double a = DStat.N_Inv(rv.NextDouble());
                        temp[rowIdx, colIdx] = a;
                    }
                }
                ans1[i] = temp;
                //Thread.Sleep(1);
            }
            SW.Stop();
            double t = SW.ElapsedMilliseconds;
            #endregion

            #region test2
            SW.Restart();
            double[][,] ans2 = new double[taskCnt][,];
            Parallel.ForEach(Partitioner.Create(0, taskCnt), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    double[,] temp = new double[2, pathLen];
                    for (int rowIdx = 0; rowIdx < 2; rowIdx++)
                    {
                        for (int colIdx = 0; colIdx < pathLen; colIdx++)
                        {
                            double a = DStat.N_Inv(rv.NextDouble());
                            temp[rowIdx, colIdx] = a;
                        }
                    }
                    ans2[i] = temp;
                }
                //Thread.Sleep(1);
            });
            SW.Stop();
            double t2 = SW.ElapsedMilliseconds;
            #endregion

            #region test5
            SW.Restart();
            parallelOpts.MaxDegreeOfParallelism = 1;
            double s = 0.0;
            for (int i = 0; i < taskCnt; i++)
            {
                SW2.Restart();
                for (int rowIdx = 0; rowIdx < 2; rowIdx++)
                {
                    for (int colIdx = 0; colIdx < pathLen; colIdx++)
                    {
                        
                        s = DStat.N_Inv(rv.NextDouble());
                        
                    }
                }
                SW2.Stop();
                double tprime = SW2.ElapsedMilliseconds;
            }
            //Thread.Sleep(1);
            SW.Stop();
            double t5 = SW.ElapsedMilliseconds;
            #endregion

            SW.Restart();
            Zmtrx[] ans3 = new Zmtrx[taskCnt];
            Parallel.ForEach(Partitioner.Create(0, taskCnt), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    ans3[i] = new Zmtrx(2, pathLen, rv);
                    //Thread.Sleep(1);
                }
            });
            SW.Stop();
            double t3 = SW.ElapsedMilliseconds;

            SW.Restart();
            Parallel.ForEach(Partitioner.Create(0, taskCnt), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    for (int rowIdx = 0; rowIdx < 2; rowIdx++)
                    {
                        for (int colIdx = 0; colIdx < pathLen; colIdx++)
                        {
                            double a = DStat.N_Inv(rv.NextDouble());
                        }
                    }
                }
                //Thread.Sleep(1);
            });
            SW.Stop();
            double t4 = SW.ElapsedMilliseconds;
            Console.ReadLine();
        }
    }
}
