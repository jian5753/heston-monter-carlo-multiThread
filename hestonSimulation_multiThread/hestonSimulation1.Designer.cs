namespace hestonSimulation_multiThread
{
    partial class HestonSimulationForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Simulation = new System.Windows.Forms.TabControl();
            this.priceTest2 = new System.Windows.Forms.TabPage();
            this.pricingResult = new System.Windows.Forms.GroupBox();
            this.textBox_putPrice = new System.Windows.Forms.TextBox();
            this.textBox_callPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.simulationPara = new System.Windows.Forms.GroupBox();
            this.textBox_seed = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_pathCnt = new System.Windows.Forms.TextBox();
            this.button_price = new System.Windows.Forms.Button();
            this.msgGroupBox = new System.Windows.Forms.GroupBox();
            this.clear = new System.Windows.Forms.Button();
            this.msgBox = new System.Windows.Forms.RichTextBox();
            this.hestonPara = new System.Windows.Forms.GroupBox();
            this.textBox_sigma = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_theta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_kappa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_rho = new System.Windows.Forms.TextBox();
            this.optionPara = new System.Windows.Forms.GroupBox();
            this.textBox_rf = new System.Windows.Forms.TextBox();
            this.textBox_T = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_var0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_k = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_s0 = new System.Windows.Forms.TextBox();
            this.pathPlot = new System.Windows.Forms.TabPage();
            this.chart_vPath = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_sPath = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_drawPath = new System.Windows.Forms.Button();
            this.asianOption = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Geo_ave = new System.Windows.Forms.RadioButton();
            this.Ari_ave = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.floating_strike = new System.Windows.Forms.RadioButton();
            this.fixed_strike = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aisanOption_price = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_asianFixCallPrice = new System.Windows.Forms.TextBox();
            this.textBox_asianFixPutPrice = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.testPage = new System.Windows.Forms.TabPage();
            this.buttonForTest = new System.Windows.Forms.Button();
            this.americanOption = new System.Windows.Forms.TabPage();
            this.tt = new System.Windows.Forms.Button();
            this.testt = new System.Windows.Forms.TextBox();
            this.Simulation.SuspendLayout();
            this.priceTest2.SuspendLayout();
            this.pricingResult.SuspendLayout();
            this.simulationPara.SuspendLayout();
            this.msgGroupBox.SuspendLayout();
            this.hestonPara.SuspendLayout();
            this.optionPara.SuspendLayout();
            this.pathPlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_vPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_sPath)).BeginInit();
            this.asianOption.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.testPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // Simulation
            // 
            this.Simulation.Controls.Add(this.priceTest2);
            this.Simulation.Controls.Add(this.pathPlot);
            this.Simulation.Controls.Add(this.asianOption);
            this.Simulation.Controls.Add(this.americanOption);
            this.Simulation.Controls.Add(this.testPage);
            this.Simulation.Cursor = System.Windows.Forms.Cursors.Default;
            this.Simulation.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Simulation.Location = new System.Drawing.Point(0, 0);
            this.Simulation.Margin = new System.Windows.Forms.Padding(2);
            this.Simulation.Name = "Simulation";
            this.Simulation.SelectedIndex = 0;
            this.Simulation.Size = new System.Drawing.Size(853, 499);
            this.Simulation.TabIndex = 6;
            // 
            // priceTest2
            // 
            this.priceTest2.BackColor = System.Drawing.Color.AliceBlue;
            this.priceTest2.Controls.Add(this.pricingResult);
            this.priceTest2.Controls.Add(this.simulationPara);
            this.priceTest2.Controls.Add(this.msgGroupBox);
            this.priceTest2.Controls.Add(this.hestonPara);
            this.priceTest2.Controls.Add(this.optionPara);
            this.priceTest2.Location = new System.Drawing.Point(4, 30);
            this.priceTest2.Margin = new System.Windows.Forms.Padding(2);
            this.priceTest2.Name = "priceTest2";
            this.priceTest2.Size = new System.Drawing.Size(845, 465);
            this.priceTest2.TabIndex = 2;
            this.priceTest2.Text = "pricing";
            this.priceTest2.Click += new System.EventHandler(this.priceTest2_Click);
            // 
            // pricingResult
            // 
            this.pricingResult.Controls.Add(this.textBox_putPrice);
            this.pricingResult.Controls.Add(this.textBox_callPrice);
            this.pricingResult.Controls.Add(this.label12);
            this.pricingResult.Controls.Add(this.label13);
            this.pricingResult.Location = new System.Drawing.Point(572, 196);
            this.pricingResult.Margin = new System.Windows.Forms.Padding(2);
            this.pricingResult.Name = "pricingResult";
            this.pricingResult.Padding = new System.Windows.Forms.Padding(2);
            this.pricingResult.Size = new System.Drawing.Size(241, 114);
            this.pricingResult.TabIndex = 13;
            this.pricingResult.TabStop = false;
            this.pricingResult.Text = "pricing result";
            // 
            // textBox_putPrice
            // 
            this.textBox_putPrice.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_putPrice.Location = new System.Drawing.Point(92, 74);
            this.textBox_putPrice.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_putPrice.Name = "textBox_putPrice";
            this.textBox_putPrice.Size = new System.Drawing.Size(141, 31);
            this.textBox_putPrice.TabIndex = 10;
            this.textBox_putPrice.Text = "0";
            // 
            // textBox_callPrice
            // 
            this.textBox_callPrice.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_callPrice.Location = new System.Drawing.Point(92, 34);
            this.textBox_callPrice.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_callPrice.Name = "textBox_callPrice";
            this.textBox_callPrice.Size = new System.Drawing.Size(141, 31);
            this.textBox_callPrice.TabIndex = 9;
            this.textBox_callPrice.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 34);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "call";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 74);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 20);
            this.label13.TabIndex = 9;
            this.label13.Text = "put";
            // 
            // simulationPara
            // 
            this.simulationPara.Controls.Add(this.textBox_seed);
            this.simulationPara.Controls.Add(this.label15);
            this.simulationPara.Controls.Add(this.label14);
            this.simulationPara.Controls.Add(this.textBox_pathCnt);
            this.simulationPara.Controls.Add(this.button_price);
            this.simulationPara.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.simulationPara.Location = new System.Drawing.Point(572, 21);
            this.simulationPara.Margin = new System.Windows.Forms.Padding(2);
            this.simulationPara.Name = "simulationPara";
            this.simulationPara.Padding = new System.Windows.Forms.Padding(2);
            this.simulationPara.Size = new System.Drawing.Size(241, 170);
            this.simulationPara.TabIndex = 12;
            this.simulationPara.TabStop = false;
            this.simulationPara.Text = "simulation parameter";
            // 
            // textBox_seed
            // 
            this.textBox_seed.Location = new System.Drawing.Point(92, 82);
            this.textBox_seed.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_seed.Name = "textBox_seed";
            this.textBox_seed.Size = new System.Drawing.Size(141, 31);
            this.textBox_seed.TabIndex = 11;
            this.textBox_seed.Text = "1234";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 84);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 20);
            this.label15.TabIndex = 10;
            this.label15.Text = "seed";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 41);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 20);
            this.label14.TabIndex = 9;
            this.label14.Text = "# of path";
            // 
            // textBox_pathCnt
            // 
            this.textBox_pathCnt.Location = new System.Drawing.Point(92, 39);
            this.textBox_pathCnt.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_pathCnt.Name = "textBox_pathCnt";
            this.textBox_pathCnt.Size = new System.Drawing.Size(141, 31);
            this.textBox_pathCnt.TabIndex = 9;
            this.textBox_pathCnt.Text = "10000";
            // 
            // button_price
            // 
            this.button_price.Location = new System.Drawing.Point(7, 123);
            this.button_price.Margin = new System.Windows.Forms.Padding(2);
            this.button_price.Name = "button_price";
            this.button_price.Size = new System.Drawing.Size(224, 33);
            this.button_price.TabIndex = 1;
            this.button_price.Text = "price";
            this.button_price.UseVisualStyleBackColor = true;
            this.button_price.Click += new System.EventHandler(this.button2_Click);
            // 
            // msgGroupBox
            // 
            this.msgGroupBox.Controls.Add(this.clear);
            this.msgGroupBox.Controls.Add(this.msgBox);
            this.msgGroupBox.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.msgGroupBox.Location = new System.Drawing.Point(27, 313);
            this.msgGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.msgGroupBox.Name = "msgGroupBox";
            this.msgGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.msgGroupBox.Size = new System.Drawing.Size(777, 128);
            this.msgGroupBox.TabIndex = 11;
            this.msgGroupBox.TabStop = false;
            this.msgGroupBox.Text = "message";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(690, 19);
            this.clear.Margin = new System.Windows.Forms.Padding(2);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(82, 32);
            this.clear.TabIndex = 1;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(18, 33);
            this.msgBox.Margin = new System.Windows.Forms.Padding(2);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(742, 88);
            this.msgBox.TabIndex = 0;
            this.msgBox.Text = "";
            // 
            // hestonPara
            // 
            this.hestonPara.Controls.Add(this.textBox_sigma);
            this.hestonPara.Controls.Add(this.label7);
            this.hestonPara.Controls.Add(this.label8);
            this.hestonPara.Controls.Add(this.textBox_theta);
            this.hestonPara.Controls.Add(this.label9);
            this.hestonPara.Controls.Add(this.label10);
            this.hestonPara.Controls.Add(this.textBox_kappa);
            this.hestonPara.Controls.Add(this.label11);
            this.hestonPara.Controls.Add(this.textBox_rho);
            this.hestonPara.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.hestonPara.Location = new System.Drawing.Point(299, 21);
            this.hestonPara.Margin = new System.Windows.Forms.Padding(2);
            this.hestonPara.Name = "hestonPara";
            this.hestonPara.Padding = new System.Windows.Forms.Padding(2);
            this.hestonPara.Size = new System.Drawing.Size(252, 289);
            this.hestonPara.TabIndex = 10;
            this.hestonPara.TabStop = false;
            this.hestonPara.Text = "heston parameters";
            // 
            // textBox_sigma
            // 
            this.textBox_sigma.Location = new System.Drawing.Point(103, 173);
            this.textBox_sigma.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_sigma.Name = "textBox_sigma";
            this.textBox_sigma.Size = new System.Drawing.Size(141, 31);
            this.textBox_sigma.TabIndex = 8;
            this.textBox_sigma.Text = "0.33220849746904";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 239);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 175);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "sigma";
            // 
            // textBox_theta
            // 
            this.textBox_theta.Location = new System.Drawing.Point(103, 128);
            this.textBox_theta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_theta.Name = "textBox_theta";
            this.textBox_theta.Size = new System.Drawing.Size(141, 31);
            this.textBox_theta.TabIndex = 5;
            this.textBox_theta.Text = "0.0164951784035976";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 129);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "theta";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "kappa";
            // 
            // textBox_kappa
            // 
            this.textBox_kappa.Location = new System.Drawing.Point(103, 82);
            this.textBox_kappa.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_kappa.Name = "textBox_kappa";
            this.textBox_kappa.Size = new System.Drawing.Size(141, 31);
            this.textBox_kappa.TabIndex = 2;
            this.textBox_kappa.Text = "2.20366282736578";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 39);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "rho";
            // 
            // textBox_rho
            // 
            this.textBox_rho.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_rho.Location = new System.Drawing.Point(103, 38);
            this.textBox_rho.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_rho.Name = "textBox_rho";
            this.textBox_rho.Size = new System.Drawing.Size(141, 31);
            this.textBox_rho.TabIndex = 0;
            this.textBox_rho.Text = "-0.277814270110106";
            // 
            // optionPara
            // 
            this.optionPara.Controls.Add(this.textBox_rf);
            this.optionPara.Controls.Add(this.textBox_T);
            this.optionPara.Controls.Add(this.label6);
            this.optionPara.Controls.Add(this.label5);
            this.optionPara.Controls.Add(this.textBox_var0);
            this.optionPara.Controls.Add(this.label4);
            this.optionPara.Controls.Add(this.label3);
            this.optionPara.Controls.Add(this.textBox_k);
            this.optionPara.Controls.Add(this.label2);
            this.optionPara.Controls.Add(this.textBox_s0);
            this.optionPara.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.optionPara.Location = new System.Drawing.Point(27, 21);
            this.optionPara.Margin = new System.Windows.Forms.Padding(2);
            this.optionPara.Name = "optionPara";
            this.optionPara.Padding = new System.Windows.Forms.Padding(2);
            this.optionPara.Size = new System.Drawing.Size(252, 289);
            this.optionPara.TabIndex = 0;
            this.optionPara.TabStop = false;
            this.optionPara.Text = "option parameters";
            // 
            // textBox_rf
            // 
            this.textBox_rf.Location = new System.Drawing.Point(103, 218);
            this.textBox_rf.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_rf.Name = "textBox_rf";
            this.textBox_rf.Size = new System.Drawing.Size(141, 31);
            this.textBox_rf.TabIndex = 9;
            this.textBox_rf.Text = "0.001521";
            // 
            // textBox_T
            // 
            this.textBox_T.Location = new System.Drawing.Point(103, 173);
            this.textBox_T.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_T.Name = "textBox_T";
            this.textBox_T.Size = new System.Drawing.Size(141, 31);
            this.textBox_T.TabIndex = 8;
            this.textBox_T.Text = "1.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 219);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "rf";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "T";
            // 
            // textBox_var0
            // 
            this.textBox_var0.Location = new System.Drawing.Point(103, 128);
            this.textBox_var0.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_var0.Name = "textBox_var0";
            this.textBox_var0.Size = new System.Drawing.Size(141, 31);
            this.textBox_var0.TabIndex = 5;
            this.textBox_var0.Text = "0.00770547621786487";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "var0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "K";
            // 
            // textBox_k
            // 
            this.textBox_k.Location = new System.Drawing.Point(103, 82);
            this.textBox_k.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_k.Name = "textBox_k";
            this.textBox_k.Size = new System.Drawing.Size(141, 31);
            this.textBox_k.TabIndex = 2;
            this.textBox_k.Text = "100.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "S0";
            // 
            // textBox_s0
            // 
            this.textBox_s0.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_s0.Location = new System.Drawing.Point(103, 38);
            this.textBox_s0.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_s0.Name = "textBox_s0";
            this.textBox_s0.Size = new System.Drawing.Size(141, 31);
            this.textBox_s0.TabIndex = 0;
            this.textBox_s0.Text = "103.44";
            // 
            // pathPlot
            // 
            this.pathPlot.BackColor = System.Drawing.Color.AliceBlue;
            this.pathPlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pathPlot.Controls.Add(this.chart_vPath);
            this.pathPlot.Controls.Add(this.chart_sPath);
            this.pathPlot.Controls.Add(this.button_drawPath);
            this.pathPlot.Location = new System.Drawing.Point(4, 30);
            this.pathPlot.Margin = new System.Windows.Forms.Padding(2);
            this.pathPlot.Name = "pathPlot";
            this.pathPlot.Padding = new System.Windows.Forms.Padding(2);
            this.pathPlot.Size = new System.Drawing.Size(845, 465);
            this.pathPlot.TabIndex = 0;
            this.pathPlot.Text = "paths";
            // 
            // chart_vPath
            // 
            this.chart_vPath.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.LabelStyle.Format = "F4";
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart_vPath.ChartAreas.Add(chartArea1);
            this.chart_vPath.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart_vPath.Location = new System.Drawing.Point(22, 236);
            this.chart_vPath.Margin = new System.Windows.Forms.Padding(2);
            this.chart_vPath.Name = "chart_vPath";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "series_sPath";
            this.chart_vPath.Series.Add(series1);
            this.chart_vPath.Size = new System.Drawing.Size(807, 212);
            this.chart_vPath.TabIndex = 2;
            this.chart_vPath.Text = "chart1";
            // 
            // chart_sPath
            // 
            this.chart_sPath.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.LabelStyle.Format = "F4";
            chartArea2.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.Maximum = 100D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart_sPath.ChartAreas.Add(chartArea2);
            this.chart_sPath.Location = new System.Drawing.Point(2, 36);
            this.chart_sPath.Margin = new System.Windows.Forms.Padding(2);
            this.chart_sPath.Name = "chart_sPath";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "series_sPath";
            this.chart_sPath.Series.Add(series2);
            this.chart_sPath.Size = new System.Drawing.Size(826, 196);
            this.chart_sPath.TabIndex = 1;
            this.chart_sPath.Text = "chart1";
            // 
            // button_drawPath
            // 
            this.button_drawPath.Location = new System.Drawing.Point(2, 4);
            this.button_drawPath.Margin = new System.Windows.Forms.Padding(2);
            this.button_drawPath.Name = "button_drawPath";
            this.button_drawPath.Size = new System.Drawing.Size(64, 29);
            this.button_drawPath.TabIndex = 0;
            this.button_drawPath.Text = "draw path";
            this.button_drawPath.UseVisualStyleBackColor = true;
            this.button_drawPath.Click += new System.EventHandler(this.button_drawPath_Click);
            // 
            // asianOption
            // 
            this.asianOption.BackColor = System.Drawing.Color.AliceBlue;
            this.asianOption.Controls.Add(this.groupBox3);
            this.asianOption.Controls.Add(this.groupBox1);
            this.asianOption.Controls.Add(this.groupBox2);
            this.asianOption.Controls.Add(this.groupBox4);
            this.asianOption.Location = new System.Drawing.Point(4, 30);
            this.asianOption.Margin = new System.Windows.Forms.Padding(2);
            this.asianOption.Name = "asianOption";
            this.asianOption.Size = new System.Drawing.Size(845, 465);
            this.asianOption.TabIndex = 4;
            this.asianOption.Text = "asian option";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Geo_ave);
            this.groupBox3.Controls.Add(this.Ari_ave);
            this.groupBox3.Location = new System.Drawing.Point(270, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 108);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "type of average";
            // 
            // Geo_ave
            // 
            this.Geo_ave.AutoSize = true;
            this.Geo_ave.Location = new System.Drawing.Point(20, 60);
            this.Geo_ave.Name = "Geo_ave";
            this.Geo_ave.Size = new System.Drawing.Size(108, 24);
            this.Geo_ave.TabIndex = 12;
            this.Geo_ave.Text = "Geometric";
            this.Geo_ave.UseVisualStyleBackColor = true;
            // 
            // Ari_ave
            // 
            this.Ari_ave.AutoSize = true;
            this.Ari_ave.Checked = true;
            this.Ari_ave.Location = new System.Drawing.Point(20, 30);
            this.Ari_ave.Name = "Ari_ave";
            this.Ari_ave.Size = new System.Drawing.Size(110, 24);
            this.Ari_ave.TabIndex = 11;
            this.Ari_ave.TabStop = true;
            this.Ari_ave.Text = "Arithmetic";
            this.Ari_ave.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.floating_strike);
            this.groupBox1.Controls.Add(this.fixed_strike);
            this.groupBox1.Location = new System.Drawing.Point(270, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 108);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "type of strike";
            // 
            // floating_strike
            // 
            this.floating_strike.AutoSize = true;
            this.floating_strike.Location = new System.Drawing.Point(20, 60);
            this.floating_strike.Name = "floating_strike";
            this.floating_strike.Size = new System.Drawing.Size(90, 24);
            this.floating_strike.TabIndex = 12;
            this.floating_strike.Text = "Floating";
            this.floating_strike.UseVisualStyleBackColor = true;
            // 
            // fixed_strike
            // 
            this.fixed_strike.AutoSize = true;
            this.fixed_strike.Checked = true;
            this.fixed_strike.Location = new System.Drawing.Point(20, 30);
            this.fixed_strike.Name = "fixed_strike";
            this.fixed_strike.Size = new System.Drawing.Size(71, 24);
            this.fixed_strike.TabIndex = 11;
            this.fixed_strike.TabStop = true;
            this.fixed_strike.Text = "Fixed";
            this.fixed_strike.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.aisanOption_price);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBox_asianFixCallPrice);
            this.groupBox2.Controls.Add(this.textBox_asianFixPutPrice);
            this.groupBox2.Location = new System.Drawing.Point(517, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(286, 258);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "pricing result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Call";
            // 
            // aisanOption_price
            // 
            this.aisanOption_price.Location = new System.Drawing.Point(142, 190);
            this.aisanOption_price.Margin = new System.Windows.Forms.Padding(2);
            this.aisanOption_price.Name = "aisanOption_price";
            this.aisanOption_price.Size = new System.Drawing.Size(114, 40);
            this.aisanOption_price.TabIndex = 2;
            this.aisanOption_price.Text = "price";
            this.aisanOption_price.UseVisualStyleBackColor = true;
            this.aisanOption_price.Click += new System.EventHandler(this.aisanOption_price_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 113);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 20);
            this.label16.TabIndex = 16;
            this.label16.Text = "Put";
            // 
            // textBox_asianFixCallPrice
            // 
            this.textBox_asianFixCallPrice.Location = new System.Drawing.Point(94, 59);
            this.textBox_asianFixCallPrice.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_asianFixCallPrice.Name = "textBox_asianFixCallPrice";
            this.textBox_asianFixCallPrice.Size = new System.Drawing.Size(168, 31);
            this.textBox_asianFixCallPrice.TabIndex = 0;
            // 
            // textBox_asianFixPutPrice
            // 
            this.textBox_asianFixPutPrice.Location = new System.Drawing.Point(94, 110);
            this.textBox_asianFixPutPrice.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_asianFixPutPrice.Name = "textBox_asianFixPutPrice";
            this.textBox_asianFixPutPrice.Size = new System.Drawing.Size(168, 31);
            this.textBox_asianFixPutPrice.TabIndex = 15;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(23, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 394);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameters";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(110, 70);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(96, 29);
            this.label34.TabIndex = 17;
            this.label34.Text = "100.0";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(110, 110);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(96, 23);
            this.label33.TabIndex = 16;
            this.label33.Text = "0.00770547621786487";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(110, 150);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(96, 20);
            this.label32.TabIndex = 15;
            this.label32.Text = "1.0";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(110, 350);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 20);
            this.label31.TabIndex = 14;
            this.label31.Text = "0.33220849746904";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(110, 310);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(96, 20);
            this.label30.TabIndex = 13;
            this.label30.Text = "0.0164951784035976";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(110, 270);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 20);
            this.label29.TabIndex = 12;
            this.label29.Text = "2.20366282736578";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(110, 230);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(96, 20);
            this.label28.TabIndex = 11;
            this.label28.Text = "-0.277814270110106";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(110, 190);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 20);
            this.label27.TabIndex = 10;
            this.label27.Text = "0.001521";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(110, 30);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(96, 20);
            this.label26.TabIndex = 9;
            this.label26.Text = "103.44";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 230);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 20);
            this.label25.TabIndex = 8;
            this.label25.Text = "rho";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 270);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 20);
            this.label24.TabIndex = 7;
            this.label24.Text = "kappa";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 310);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 20);
            this.label23.TabIndex = 6;
            this.label23.Text = "theta";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 350);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 20);
            this.label22.TabIndex = 5;
            this.label22.Text = "sigma";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 190);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 20);
            this.label21.TabIndex = 4;
            this.label21.Text = "rf";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 150);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 20);
            this.label20.TabIndex = 3;
            this.label20.Text = "T";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 20);
            this.label19.TabIndex = 2;
            this.label19.Text = "Var0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 20);
            this.label18.TabIndex = 1;
            this.label18.Text = "K";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "S0";
            // 
            // testPage
            // 
            this.testPage.Controls.Add(this.testt);
            this.testPage.Controls.Add(this.tt);
            this.testPage.Controls.Add(this.buttonForTest);
            this.testPage.Location = new System.Drawing.Point(4, 30);
            this.testPage.Margin = new System.Windows.Forms.Padding(2);
            this.testPage.Name = "testPage";
            this.testPage.Size = new System.Drawing.Size(845, 465);
            this.testPage.TabIndex = 3;
            this.testPage.Text = "testPage";
            this.testPage.UseVisualStyleBackColor = true;
            // 
            // buttonForTest
            // 
            this.buttonForTest.Location = new System.Drawing.Point(30, 25);
            this.buttonForTest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonForTest.Name = "buttonForTest";
            this.buttonForTest.Size = new System.Drawing.Size(222, 48);
            this.buttonForTest.TabIndex = 0;
            this.buttonForTest.Text = "mother fucker";
            this.buttonForTest.UseVisualStyleBackColor = true;
            this.buttonForTest.Click += new System.EventHandler(this.buttonForTest_Click);
            // 
            // americanOption
            // 
            this.americanOption.BackColor = System.Drawing.Color.AliceBlue;
            this.americanOption.Location = new System.Drawing.Point(4, 30);
            this.americanOption.Name = "americanOption";
            this.americanOption.Size = new System.Drawing.Size(845, 465);
            this.americanOption.TabIndex = 5;
            this.americanOption.Text = "American Option";
            // 
            // tt
            // 
            this.tt.Location = new System.Drawing.Point(284, 25);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(139, 48);
            this.tt.TabIndex = 1;
            this.tt.Text = "fuck you";
            this.tt.UseVisualStyleBackColor = true;
            this.tt.Click += new System.EventHandler(this.tt_Click);
            // 
            // testt
            // 
            this.testt.Location = new System.Drawing.Point(474, 25);
            this.testt.Name = "testt";
            this.testt.Size = new System.Drawing.Size(149, 31);
            this.testt.TabIndex = 2;
            // 
            // HestonSimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 493);
            this.Controls.Add(this.Simulation);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HestonSimulationForm";
            this.Text = "heston model montecarlo simulation";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.HestonSimulationForm_Load);
            this.Simulation.ResumeLayout(false);
            this.priceTest2.ResumeLayout(false);
            this.pricingResult.ResumeLayout(false);
            this.pricingResult.PerformLayout();
            this.simulationPara.ResumeLayout(false);
            this.simulationPara.PerformLayout();
            this.msgGroupBox.ResumeLayout(false);
            this.hestonPara.ResumeLayout(false);
            this.hestonPara.PerformLayout();
            this.optionPara.ResumeLayout(false);
            this.optionPara.PerformLayout();
            this.pathPlot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_vPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_sPath)).EndInit();
            this.asianOption.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.testPage.ResumeLayout(false);
            this.testPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl Simulation;
        private System.Windows.Forms.TabPage pathPlot;
        private System.Windows.Forms.TabPage priceTest2;
        private System.Windows.Forms.GroupBox optionPara;
        private System.Windows.Forms.TextBox textBox_s0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_k;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_var0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_rf;
        private System.Windows.Forms.TextBox textBox_T;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_price;
        private System.Windows.Forms.GroupBox hestonPara;
        private System.Windows.Forms.TextBox textBox_sigma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_theta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_kappa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_rho;
        private System.Windows.Forms.GroupBox msgGroupBox;
        private System.Windows.Forms.RichTextBox msgBox;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.GroupBox simulationPara;
        private System.Windows.Forms.TextBox textBox_callPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_putPrice;
        private System.Windows.Forms.GroupBox pricingResult;
        private System.Windows.Forms.TextBox textBox_seed;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_pathCnt;
        private System.Windows.Forms.Button button_drawPath;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_sPath;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_vPath;
        private System.Windows.Forms.TabPage testPage;
        private System.Windows.Forms.Button buttonForTest;
        private System.Windows.Forms.TabPage asianOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_asianFixCallPrice;
        private System.Windows.Forms.Button aisanOption_price;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton floating_strike;
        private System.Windows.Forms.RadioButton fixed_strike;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_asianFixPutPrice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton Geo_ave;
        private System.Windows.Forms.RadioButton Ari_ave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TabPage americanOption;
        private System.Windows.Forms.Button tt;
        private System.Windows.Forms.TextBox testt;
    }
}

