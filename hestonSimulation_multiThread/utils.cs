﻿using System;
using DFinNR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;


namespace hestonSimulation_multiThread
{
    class Utils
    {
        public static double[] Power(double[] v, double x)
        {
            double[] ans = new double[v.Length];
            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, v.Length), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    ans[i] = Math.Pow(v[i], x);
                }
            });
            return ans;
        }

        public static double[] Add(double[] v1, double[] v2)
        {
            if (v1.Length != v2.Length)
            {
                throw new dimNotMatchException("v1.Length != v2.Length");
            }

            double[] ans = new double[v1.Length];
            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, v1.Length), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    ans[i] = v1[i] + v2[i];
                }
            });
            return ans;
        }

        public static double[] Sub(double[] v1, double c)
        {
            double[] ans = new double[v1.Length];
            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, v1.Length), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    ans[i] = v1[i] - c;
                }
            });
            return ans;
        }

        public static double[] Mul(double[] v1, double[] v2)
        {
            if (v1.Length != v2.Length)
            {
                throw new dimNotMatchException("v1.Length != v2.Length");
            }

            double[] ans = new double[v1.Length];
            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, v1.Length), parallelOpts, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    ans[i] = v1[i] * v2[i];
                }
            });
            return ans;
        }

        public static double Mean(double[] v)
        {
            double ans = 0;
            ParallelOptions parallelOpts = new ParallelOptions();
            parallelOpts.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(Partitioner.Create(0, v.Length), parallelOpts, range =>
            {
                double temp = 0;
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    temp += v[i];
                }
                ans += temp;
            });
            return ans / v.Length;
        }

        public static double Var(double[] v)
        {
            double vBar = Mean(v);
            return Mean(Power(Sub(v, vBar), 2));
        }

        public static double Cov(double[] v1, double[] v2)
        {
            double v1Bar = Mean(v1);
            double v2Bar = Mean(v2);
            return Mean(Mul(Sub(v1, v1Bar), Sub(v2, v2Bar)));
        }
    }
    class Mtrx
    {
        protected int rowCnt;
        protected int colCnt;
        public double[,] data;

        public Mtrx(int rowCnt, int colCnt)
        {
            this.rowCnt = rowCnt;
            this.colCnt = colCnt;
            data = new double[rowCnt, colCnt];
        }
        public Mtrx(int rowCnt, int colCnt, ref double[,] data)
        {
            this.rowCnt = rowCnt;
            this.colCnt = colCnt;
            this.data = data;
        }

        public Mtrx(ref double[,] data)
        {
            this.rowCnt = data.GetLength(0);
            this.colCnt = data.GetLength(1);
            this.data = data;
        }

        #region query
        public int getColCnt()
        {
            return colCnt;
        }
        public int getRowCnt()
        {
            return rowCnt;
        }

        public double[] getRow(int rowIdx)
        {
            double[] ans = new double[colCnt];
            for (int colIdx = 0; colIdx < colCnt; colIdx++)
            {
                ans[colIdx] = data[rowIdx, colIdx];
            }
            return ans;
        }

        public double[] getCol(int colIdx)
        {
            double[] ans = new double[rowCnt];
            for (int rowIdx = 0; rowIdx < rowCnt; rowIdx++)
            {
                ans[rowIdx] = data[rowIdx, colIdx];
            }
            return ans;
        }
        #endregion

        #region operation overload
        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { this.data[i, j] = value; }
        }
        #endregion

        #region algebra operation
        public Mtrx dot(Mtrx rightMtrx)
        {
            Mtrx ans = new Mtrx(this.rowCnt, rightMtrx.getColCnt());
            for (int rowIdx = 0; rowIdx < rowCnt; rowIdx++)
            {
                for (int colIdx = 0; colIdx < rightMtrx.getColCnt(); colIdx++)
                {
                    double[] vec1 = this.getRow(rowIdx);
                    double[] vec2 = rightMtrx.getCol(colIdx);
                    ans[rowIdx, colIdx] = 0;
                    for (int k = 0; k < colCnt; k++)
                    {
                        ans[rowIdx, colIdx] += vec1[k] * vec2[k];
                    }
                }
            }
            return ans;
        }

        public Mtrx T()
        {
            Mtrx ans = new Mtrx(colCnt, rowCnt);
            for (int rowIdx = 0; rowIdx < rowCnt; rowIdx++)
            {
                for (int colIdx = 0; colIdx < colCnt; colIdx++)
                {
                    ans.data[colIdx, rowIdx] = this.data[rowIdx, colIdx];
                }
            }
            return ans;
        }

        public Mtrx choleskyDecomp()
        {
            Mtrx theAns = new Mtrx(rowCnt, this.colCnt);

            //the [1, 1] data
            theAns.data[0, 0] = Math.Sqrt(data[0, 0]);
            //the first row
            for (int colIdx = 1; colIdx < this.colCnt; colIdx++)
            {
                theAns[0, colIdx] = data[0, colIdx] / theAns[0, 0];
            }

            for (int rowIdx = 1; rowIdx < rowCnt; rowIdx++)
            {
                for (int colIdx = rowIdx; colIdx < this.colCnt; colIdx++)
                {
                    //Console.WriteLine($"{rowIdx}, {colIdx}");
                    theAns[rowIdx, colIdx] = this[rowIdx, colIdx];
                    if (rowIdx == colIdx)
                    {

                        for (int k = 0; k < colIdx; k++)
                        {
                            //Console.WriteLine(theAns[k, colIdx]);
                            theAns[rowIdx, colIdx] -= theAns[k, colIdx] * theAns[k, colIdx];
                        }
                        theAns[rowIdx, colIdx] = Math.Sqrt(theAns[rowIdx, colIdx]);
                    }
                    else
                    {
                        for (int k = 0; k < colIdx; k++)
                        {
                            theAns[rowIdx, colIdx] -= theAns[k, rowIdx] * theAns[k, colIdx];
                        }
                        theAns[rowIdx, colIdx] /= theAns[rowIdx, colIdx];
                    }
                }
            }

            return theAns;
        }
        #endregion

        #region statistics
        public Mtrx mean_throughRow()
        {
            Mtrx ans = new Mtrx(rowCnt, 1);
            for (int rowIdx = 0; rowIdx < rowCnt; rowIdx++)
            {
                double rowMean = 0;
                for (int colIdx = 0; colIdx < colCnt; colIdx++)
                {
                    rowMean += data[rowIdx, colIdx];
                }
                ans[rowIdx, 0] = rowMean / colCnt;
            }
            return ans;
        }

        public Mtrx sampleCov_rowAsRV()
        {
            Mtrx ans = new Mtrx(rowCnt, rowCnt);
            Mtrx means = mean_throughRow();
            for (int rowIdx = 0; rowIdx < rowCnt; rowIdx++)
            {
                for (int colIdx = 0; colIdx < rowCnt; colIdx++)
                {
                    double xy = 0;
                    for (int k = 0; k < colCnt; k++)
                    {
                        xy += data[rowIdx, k] * data[colIdx, k];
                    }
                    xy /= colCnt;
                    ans[rowIdx, colIdx] = xy - means[rowIdx, 0] * means[colIdx, 0];
                }
            }
            return ans;
        }
        #endregion
    }
    class Zmtrx : Mtrx
    {
        private Random rv;

        #region constructor;
        public Zmtrx(int rowCnt, int colCnt, Random rv) : base(rowCnt, colCnt)
        {
            this.rv = rv;
            #region draw z
            
            for (int colIdx = 0; colIdx < colCnt; colIdx++)
            {
                for (int rowIdx = 0; rowIdx < rowCnt; rowIdx++)
                {
                    data[rowIdx, colIdx] = DStat.N_Inv(rv.NextDouble());
                }
            };
            
            /*
            Parallel.For(0, rowCnt, rowIdx =>
            {
                for(int colIdx = 0; colIdx < colCnt; colIdx++)
                {
                    data[rowIdx, colIdx] = DStat.N_Inv(rv.NextDouble());
                }
            });
            */
            #endregion
        }

        public Zmtrx(int rowCnt, int colCnt) : base(rowCnt, colCnt)
        {
            this.rv = new Random();
            #region draw z
            for (int colIdx = 0; colIdx < colCnt; colIdx++)
            {
                for (int rowIdx = 0; rowIdx < rowCnt; rowCnt++)
                {
                    data[rowIdx, colIdx] = DStat.N_Inv(rv.NextDouble());
                }
            }
            #endregion
        }

        public Zmtrx(Mtrx source) : base(source.getRowCnt(), source.getColCnt())
        {
            data = source.data;
        }
        #endregion

        #region algebra operation

        #endregion
        #region operation overload

        #endregion
    }

    class SVpath
    {
        private int length;
        private double[] vPath;
        private double[] sPath;
        private double deltat;
        public SVpath(ref Mtrx source,
            double s0, double v0,
            double kappa, double theta, double sigma,
            double rf,
            double T)
        {
            this.length = source.getColCnt();
            this.deltat = T / length;
            double sqrtdt = Math.Sqrt(deltat);
            vPath = new double[this.length + 1];
            sPath = new double[this.length + 1];
            

            vPath[0] = v0;
            sPath[0] = s0;

            for (int t = 0; t < this.length; t++)
            {
                sPath[t + 1] = sPath[t] * Math.Exp((rf - 0.5 * vPath[t]) * deltat + Math.Sqrt(vPath[t]) * sqrtdt * source[0, t]);
                vPath[t + 1] = Math.Max(vPath[t] + kappa * (theta - vPath[t]) * deltat + sigma * Math.Sqrt(vPath[t]) * sqrtdt * source[1, t], 0);
            }
        }

        public double getSt()
        {
            return sPath[length];
        }

        public double[] getSpath()
        {
            return sPath;
        }

        public double[] getVPath()
        {
            return vPath;
        }

        public double[][] getSandVPath()
        {
            double[][] ans = new double[2][];
            ans[0] = sPath;
            ans[1] = vPath;
            return ans;
        }
    }
}
