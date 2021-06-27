using DFinNR;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace hestonSimulation_multiThread
{
    public partial class HestonSimulationForm : Form
    {
        #region attributes
        private double s0;
        private double k;
        private double var0;
        private double rf;
        private double T;

        private double rho;
        private double kappa;
        private double theta;
        private double sigma;

        private int seed;
        private int pathCnt;
        #endregion

        static Matrix corrToCov(Matrix corrMtrx, double[] variance)
        {

            Matrix covMtrx = new Matrix(corrMtrx);
            for (int rowIdx = 0; rowIdx < corrMtrx.rows(); rowIdx++)
            {
                for (int colIdx = 0; colIdx < corrMtrx.columns(); colIdx++)
                {
                    covMtrx[rowIdx, colIdx] *= Math.Sqrt(variance[rowIdx]);
                    covMtrx[rowIdx, colIdx] *= Math.Sqrt(variance[colIdx]);
                }
            }
            return covMtrx;
        }

        public HestonSimulationForm()
        {
            InitializeComponent();
            #region default parameters;
            s0 = 103.44;
            k = 100.0;
            var0 = 0.00770547621786487;
            rf = 0.001521;
            T = 1.0;

            rho = -0.277814270110106;
            kappa = 2.20366282736578;
            theta = 0.0164951784035976;
            sigma = 0.33220849746904;

            seed = 1234;
            pathCnt = 10000;
            #endregion

            #region chart

            #region spath chart
            chart_sPath.Series[0].Points.AddXY(0, 60);
            chart_sPath.Series[0].Points.AddXY(365, 60);
            chart_sPath.ChartAreas[0].AxisX.Maximum = 365.0;
            #endregion

            #region vpath chart
            chart_vPath.Series[0].Points.AddXY(0, theta);
            chart_vPath.Series[0].Points.AddXY(365, theta);
            chart_vPath.ChartAreas[0].AxisY.Maximum = 0.08;
            chart_vPath.ChartAreas[0].AxisX.Maximum = 365.0;
            #endregion

            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region parse input
            try { s0 = double.Parse(textBox_s0.Text); } catch { };
            try { k = double.Parse(textBox_k.Text); } catch { };
            try { var0 = double.Parse(textBox_var0.Text); } catch { };
            try { T = double.Parse(textBox_T.Text); } catch { };
            try { rf = double.Parse(textBox_rf.Text); } catch { };

            try { rho = double.Parse(textBox_rho.Text); } catch { };
            try { kappa = double.Parse(textBox_kappa.Text); } catch { };
            try { theta = double.Parse(textBox_theta.Text); } catch { };
            try { sigma = double.Parse(textBox_sigma.Text); } catch { };

            try { pathCnt = int.Parse(textBox_pathCnt.Text); } catch { };
            try { seed = int.Parse(textBox_seed.Text); } catch { seed = 0; };

            int pathLen = (int)(365 * T);
            #endregion

            VanillaCall theCall = new VanillaCall(s0, var0, k, T, rf, rho, kappa, theta, sigma);
            VanillaPut thePut = new VanillaPut(s0, var0, k, T, rf, rho, kappa, theta, sigma);

            Stopwatch SW = new Stopwatch();
            SW.Start();
            Random rv;
            if (seed == 0) { rv = new Random(); }
            else { rv = new Random(seed); };

            double[] stArr = theCall.drawSt(pathLen, pathCnt);


            double callSampleMean = theCall.priceSampleMean(stArr);
            double putSampleMean = thePut.priceSampleMean(stArr);
            textBox_callPrice.Text = callSampleMean.ToString("F4");
            textBox_putPrice.Text = putSampleMean.ToString("F4");

            SW.Stop();
            double timeConsumption = SW.ElapsedMilliseconds;
            msgBox.Text += $"done. time consumption {timeConsumption} ms. ";
            msgBox.Text += $"call price: {textBox_callPrice.Text} , put price: {textBox_putPrice.Text}. \n";

            #region some theoritical verification
            /*
            double[] callPayoffs = new double[pathCnt];
            double[] putPayoffs = new double[pathCnt];
            double[] verify = new double[pathCnt];
            for(int i = 0; i < pathCnt; i++)
            {
                callPayoffs[i] = theCall.payoff(stArr[i]);
                putPayoffs[i] = thePut.payoff(stArr[i]);
                verify[i] = callPayoffs[i] - putPayoffs[i] + k;
            }*/

            // put call parity
            double parityLeft = putSampleMean + s0;
            double parityRight = callSampleMean + k *  Math.Exp(-rf * T);
            #endregion
            msgBox.Text += "";

        }

        private void clear_Click(object sender, EventArgs e)
        {
            msgBox.Text = "";
        }

        private void button_drawPath_Click(object sender, EventArgs e)
        {
            #region rv
            Random rv = new Random();
            //if (seed == 0) { rv = new Random(); }
            //else { rv = new Random(seed); };
            #endregion
            chart_sPath.Series[0].Points.Clear();
            chart_vPath.Series[0].Points.Clear();
            int pathLen = (int)(365 * T);

            #region draw path 
            VanillaOption forPath = new VanillaOption(s0, var0, k, T, rf);
            MonteCarloSimulation_hestonModel pathSim
                = new MonteCarloSimulation_hestonModel(forPath, rho, kappa, theta, sigma, pathLen);
            double[][] sAndvPath = pathSim.drawSandVPath(rv);
            #endregion

            for (int i = 0; i < pathLen; i++)
            {
                chart_sPath.Series[0].Points.AddY(sAndvPath[0][i]);
                chart_vPath.Series[0].Points.AddY(sAndvPath[1][i]);
            }
            chart_sPath.ChartAreas[0].AxisY.Maximum = sAndvPath[0].Max() * 1.1;
            chart_sPath.ChartAreas[0].AxisY.Minimum = sAndvPath[0].Min() * 0.9;
            chart_vPath.ChartAreas[0].AxisY.Maximum = sAndvPath[1].Max() * 1.1;
            chart_vPath.ChartAreas[0].AxisY.Minimum = sAndvPath[1].Min() * 0.9;

            chart_sPath.ChartAreas[0].AxisX.Maximum = pathLen;
            chart_vPath.ChartAreas[0].AxisX.Maximum = pathLen;


        }

        private void buttonForTest_Click(object sender, EventArgs e)
        {
            Stopwatch SW = new Stopwatch();
            SW.Start();
            VanillaOption_AmrcCall testInstance = new VanillaOption_AmrcCall(s0, var0, k, T, rf, rho, kappa, theta, sigma);
            Mtrx tempMtrx = testInstance.drawSPath(10, 365);
            SW.Stop();
            double t1 = SW.ElapsedMilliseconds;
            SW.Restart();
            double ans = testInstance.meanPrice(ref tempMtrx);
            SW.Stop();
            double t2 = SW.ElapsedMilliseconds;

        }

        private void aisanOption_price_Click(object sender, EventArgs e)
        {
            #region parse input
            try { s0 = double.Parse(textBox_s0.Text); label26.Text = s0.ToString(); } catch { };
            try { k = double.Parse(textBox_k.Text); label34.Text = k.ToString(); } catch { };
            try { var0 = double.Parse(textBox_var0.Text); label33.Text = var0.ToString(); } catch { };
            try { T = double.Parse(textBox_T.Text); label32.Text = T.ToString(); } catch { };
            try { rf = double.Parse(textBox_rf.Text); label27.Text = rf.ToString(); } catch { };

            try { rho = double.Parse(textBox_rho.Text); label28.Text = rho.ToString(); } catch { };
            try { kappa = double.Parse(textBox_kappa.Text); label29.Text = kappa.ToString(); } catch { };
            try { theta = double.Parse(textBox_theta.Text); label30.Text = theta.ToString(); } catch { };
            try { sigma = double.Parse(textBox_sigma.Text); label31.Text = sigma.ToString(); } catch { };

            try { pathCnt = int.Parse(textBox_pathCnt.Text); } catch { };
            try { seed = int.Parse(textBox_seed.Text); } catch { seed = 0; };

            int pathLen = (int)(365 * T);
            #endregion

            VanillaOption_heston simulator = new VanillaOption_heston
                    (s0, var0, k, T, rf, rho, kappa, theta, sigma);
            Mtrx sPanel = simulator.drawSPath(pathCnt, 365);
            if (fixed_strike.Checked)
            {
                if (Ari_ave.Checked)
                {
                    AsianOptionFixCall asianCall = new AsianOptionFixCall
                    (s0, var0, k, T, rf, rho, kappa, theta, sigma);
                    AsianOptionFixPut asianPut = new AsianOptionFixPut
                        (s0, var0, k, T, rf, rho, kappa, theta, sigma);
                    double asianFixCallPrice = asianCall.priceSampleMean(sPanel);
                    double asianFixPutPrice = asianPut.priceSampleMean(sPanel);
                    textBox_asianFixCallPrice.Text = asianFixCallPrice.ToString("F4");
                    textBox_asianFixPutPrice.Text = asianFixPutPrice.ToString("F4");
                }
                else if (Geo_ave.Checked)
                {
                    AsianOptionFixCall_Geo asianCall = new AsianOptionFixCall_Geo
                    (s0, var0, k, T, rf, rho, kappa, theta, sigma);
                    AsianOptionFixPut_Geo asianPut = new AsianOptionFixPut_Geo
                        (s0, var0, k, T, rf, rho, kappa, theta, sigma);
                    double asianFixCallPrice = asianCall.priceSampleMean(sPanel);
                    double asianFixPutPrice = asianPut.priceSampleMean(sPanel);
                    textBox_asianFixCallPrice.Text = asianFixCallPrice.ToString("F4");
                    textBox_asianFixPutPrice.Text = asianFixPutPrice.ToString("F4");
                }
                
            }   
            else if (floating_strike.Checked)
            {
                if (Ari_ave.Checked)
                {
                    AsianOptionFloatCall asianCall_f = new AsianOptionFloatCall
                    (s0, var0, k, T, rf, rho, kappa, theta, sigma);
                    AsianOptionFloatPut asianPut_f = new AsianOptionFloatPut
                        (s0, var0, k, T, rf, rho, kappa, theta, sigma);
                    double asianFloatCallPrice = asianCall_f.priceSampleMean(sPanel);
                    double asianFloatPutPrice = asianPut_f.priceSampleMean(sPanel);
                    textBox_asianFixCallPrice.Text = asianFloatCallPrice.ToString("F4");
                    textBox_asianFixPutPrice.Text = asianFloatPutPrice.ToString("F4");
                }
                else if (Geo_ave.Checked)
                {
                    AsianOptionFloatCall_Geo asianCall_f = new AsianOptionFloatCall_Geo
                    (s0, var0, k, T, rf, rho, kappa, theta, sigma);
                    AsianOptionFloatPut_Geo asianPut_f = new AsianOptionFloatPut_Geo
                        (s0, var0, k, T, rf, rho, kappa, theta, sigma);
                    double asianFloatCallPrice = asianCall_f.priceSampleMean(sPanel);
                    double asianFloatPutPrice = asianPut_f.priceSampleMean(sPanel);
                    textBox_asianFixCallPrice.Text = asianFloatCallPrice.ToString("F4");
                    textBox_asianFixPutPrice.Text = asianFloatPutPrice.ToString("F4");
                }
            }
        }

        private void HestonSimulationForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void priceTest2_Click(object sender, EventArgs e)
        {

        }
    }
}
