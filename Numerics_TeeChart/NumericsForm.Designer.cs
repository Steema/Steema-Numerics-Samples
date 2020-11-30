
namespace Numerics_TeeChart
{
    partial class NumericsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.panelO = new System.Windows.Forms.Panel();
			this.bOptions = new System.Windows.Forms.Button();
			this.panelOptions = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.tbDataSetDescription = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbRealTime = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cbAxisIncrement = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.bChartEditor = new System.Windows.Forms.Button();
			this.cbAxisFormat = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbDataSets = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bViewData = new System.Windows.Forms.Button();
			this.bClearChart = new System.Windows.Forms.Button();
			this.bResetData = new System.Windows.Forms.Button();
			this.bData = new System.Windows.Forms.Button();
			this.lDataName = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericDaysToAdd = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.cbMovingAverage = new System.Windows.Forms.CheckBox();
			this.bEditAlgorithm = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.bStop = new System.Windows.Forms.Button();
			this.bPrediction = new System.Windows.Forms.Button();
			this.bAnomalies = new System.Windows.Forms.Button();
			this.panelBaseChart = new System.Windows.Forms.Panel();
			this.panelWarnings = new System.Windows.Forms.Panel();
			this.tbWarnings = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panelChart = new System.Windows.Forms.Panel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panelO.SuspendLayout();
			this.panelOptions.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericDaysToAdd)).BeginInit();
			this.panel3.SuspendLayout();
			this.panelBaseChart.SuspendLayout();
			this.panelWarnings.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelO
			// 
			this.panelO.Controls.Add(this.bOptions);
			this.panelO.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelO.Location = new System.Drawing.Point(0, 635);
			this.panelO.Name = "panelO";
			this.panelO.Size = new System.Drawing.Size(1385, 40);
			this.panelO.TabIndex = 0;
			// 
			// bOptions
			// 
			this.bOptions.Location = new System.Drawing.Point(640, 6);
			this.bOptions.Name = "bOptions";
			this.bOptions.Size = new System.Drawing.Size(158, 30);
			this.bOptions.TabIndex = 0;
			this.bOptions.Text = "OPTIONS";
			this.bOptions.UseVisualStyleBackColor = true;
			this.bOptions.Click += new System.EventHandler(this.BOptions_Click);
			// 
			// panelOptions
			// 
			this.panelOptions.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panelOptions.Controls.Add(this.label3);
			this.panelOptions.Controls.Add(this.tbDataSetDescription);
			this.panelOptions.Controls.Add(this.groupBox4);
			this.panelOptions.Controls.Add(this.cbRealTime);
			this.panelOptions.Controls.Add(this.groupBox3);
			this.panelOptions.Controls.Add(this.label2);
			this.panelOptions.Controls.Add(this.cbDataSets);
			this.panelOptions.Controls.Add(this.groupBox2);
			this.panelOptions.Controls.Add(this.groupBox1);
			this.panelOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelOptions.Location = new System.Drawing.Point(0, 341);
			this.panelOptions.Name = "panelOptions";
			this.panelOptions.Size = new System.Drawing.Size(1385, 294);
			this.panelOptions.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(871, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 15);
			this.label3.TabIndex = 29;
			this.label3.Text = "Description";
			// 
			// tbDataSetDescription
			// 
			this.tbDataSetDescription.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbDataSetDescription.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.tbDataSetDescription.Location = new System.Drawing.Point(871, 51);
			this.tbDataSetDescription.Multiline = true;
			this.tbDataSetDescription.Name = "tbDataSetDescription";
			this.tbDataSetDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDataSetDescription.Size = new System.Drawing.Size(482, 232);
			this.tbDataSetDescription.TabIndex = 28;
			// 
			// groupBox4
			// 
			this.groupBox4.Location = new System.Drawing.Point(270, 90);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(257, 193);
			this.groupBox4.TabIndex = 27;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Options for Anomalies";
			// 
			// cbRealTime
			// 
			this.cbRealTime.AutoSize = true;
			this.cbRealTime.Location = new System.Drawing.Point(638, 54);
			this.cbRealTime.Name = "cbRealTime";
			this.cbRealTime.Size = new System.Drawing.Size(74, 19);
			this.cbRealTime.TabIndex = 25;
			this.cbRealTime.Text = "RealTime";
			this.cbRealTime.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cbAxisIncrement);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.bChartEditor);
			this.groupBox3.Controls.Add(this.cbAxisFormat);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Location = new System.Drawing.Point(699, 90);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(155, 193);
			this.groupBox3.TabIndex = 23;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Visualization Options";
			// 
			// cbAxisIncrement
			// 
			this.cbAxisIncrement.FormattingEnabled = true;
			this.cbAxisIncrement.Items.AddRange(new object[] {
            "one year",
            "one month",
            "one day",
            "one minute",
            "one second"});
			this.cbAxisIncrement.Location = new System.Drawing.Point(14, 100);
			this.cbAxisIncrement.Name = "cbAxisIncrement";
			this.cbAxisIncrement.Size = new System.Drawing.Size(129, 23);
			this.cbAxisIncrement.TabIndex = 4;
			this.cbAxisIncrement.SelectedIndexChanged += new System.EventHandler(this.CbAxisIncrement_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(86, 15);
			this.label5.TabIndex = 3;
			this.label5.Text = "Axis Increment";
			// 
			// bChartEditor
			// 
			this.bChartEditor.Location = new System.Drawing.Point(14, 154);
			this.bChartEditor.Name = "bChartEditor";
			this.bChartEditor.Size = new System.Drawing.Size(129, 24);
			this.bChartEditor.TabIndex = 2;
			this.bChartEditor.Text = "Chart Editor";
			this.bChartEditor.UseVisualStyleBackColor = true;
			this.bChartEditor.Click += new System.EventHandler(this.BChartEditor_Click);
			// 
			// cbAxisFormat
			// 
			this.cbAxisFormat.FormattingEnabled = true;
			this.cbAxisFormat.Items.AddRange(new object[] {
            "yyyy",
            "MMM",
            "MM",
            "d",
            "dd/MM/yyyy",
            "yyyy/MM/dd",
            "HH:mm",
            "hh:mm:ss",
            "mm:ss"});
			this.cbAxisFormat.Location = new System.Drawing.Point(14, 41);
			this.cbAxisFormat.Name = "cbAxisFormat";
			this.cbAxisFormat.Size = new System.Drawing.Size(129, 23);
			this.cbAxisFormat.TabIndex = 1;
			this.cbAxisFormat.SelectedIndexChanged += new System.EventHandler(this.CbAxisFormat_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 15);
			this.label4.TabIndex = 0;
			this.label4.Text = "Axis bottom Format";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 15);
			this.label2.TabIndex = 22;
			this.label2.Text = "Sample DataSet to use";
			// 
			// cbDataSets
			// 
			this.cbDataSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDataSets.FormattingEnabled = true;
			this.cbDataSets.Items.AddRange(new object[] {
            "Continuous Factory Process",
            "Sample Data",
            "Production Plant Data for Condition Monitoring"});
			this.cbDataSets.Location = new System.Drawing.Point(27, 51);
			this.cbDataSets.Name = "cbDataSets";
			this.cbDataSets.Size = new System.Drawing.Size(552, 23);
			this.cbDataSets.TabIndex = 21;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bViewData);
			this.groupBox2.Controls.Add(this.bClearChart);
			this.groupBox2.Controls.Add(this.bResetData);
			this.groupBox2.Controls.Add(this.bData);
			this.groupBox2.Controls.Add(this.lDataName);
			this.groupBox2.Location = new System.Drawing.Point(543, 90);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(150, 193);
			this.groupBox2.TabIndex = 20;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Data Options";
			// 
			// bViewData
			// 
			this.bViewData.Location = new System.Drawing.Point(6, 80);
			this.bViewData.Name = "bViewData";
			this.bViewData.Size = new System.Drawing.Size(134, 24);
			this.bViewData.TabIndex = 8;
			this.bViewData.Text = "View Data";
			this.bViewData.UseVisualStyleBackColor = true;
			this.bViewData.Click += new System.EventHandler(this.BViewData_Click);
			// 
			// bClearChart
			// 
			this.bClearChart.Location = new System.Drawing.Point(6, 154);
			this.bClearChart.Name = "bClearChart";
			this.bClearChart.Size = new System.Drawing.Size(134, 24);
			this.bClearChart.TabIndex = 7;
			this.bClearChart.Text = "Clear Chart";
			this.bClearChart.UseVisualStyleBackColor = true;
			this.bClearChart.Click += new System.EventHandler(this.BClearChart_Click);
			// 
			// bResetData
			// 
			this.bResetData.Location = new System.Drawing.Point(6, 50);
			this.bResetData.Name = "bResetData";
			this.bResetData.Size = new System.Drawing.Size(134, 23);
			this.bResetData.TabIndex = 2;
			this.bResetData.Text = "Reset Data";
			this.bResetData.UseVisualStyleBackColor = true;
			this.bResetData.Click += new System.EventHandler(this.BResetData_Click);
			// 
			// bData
			// 
			this.bData.Location = new System.Drawing.Point(6, 20);
			this.bData.Name = "bData";
			this.bData.Size = new System.Drawing.Size(134, 23);
			this.bData.TabIndex = 5;
			this.bData.Text = "Choose Data ...";
			this.bData.UseVisualStyleBackColor = true;
			this.bData.Click += new System.EventHandler(this.BData_Click);
			// 
			// lDataName
			// 
			this.lDataName.AutoSize = true;
			this.lDataName.Location = new System.Drawing.Point(6, 52);
			this.lDataName.Name = "lDataName";
			this.lDataName.Size = new System.Drawing.Size(0, 15);
			this.lDataName.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericDaysToAdd);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cbMovingAverage);
			this.groupBox1.Controls.Add(this.bEditAlgorithm);
			this.groupBox1.Location = new System.Drawing.Point(27, 90);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(228, 193);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options for PREDICTION";
			// 
			// numericDaysToAdd
			// 
			this.numericDaysToAdd.Location = new System.Drawing.Point(163, 154);
			this.numericDaysToAdd.Name = "numericDaysToAdd";
			this.numericDaysToAdd.Size = new System.Drawing.Size(52, 23);
			this.numericDaysToAdd.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(81, 156);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 15);
			this.label6.TabIndex = 8;
			this.label6.Text = "Days to add :";
			// 
			// cbMovingAverage
			// 
			this.cbMovingAverage.AutoSize = true;
			this.cbMovingAverage.Location = new System.Drawing.Point(19, 124);
			this.cbMovingAverage.Name = "cbMovingAverage";
			this.cbMovingAverage.Size = new System.Drawing.Size(113, 19);
			this.cbMovingAverage.TabIndex = 7;
			this.cbMovingAverage.Text = "Moving Average";
			this.cbMovingAverage.UseVisualStyleBackColor = true;
			this.cbMovingAverage.CheckedChanged += new System.EventHandler(this.CbMovingAverage_CheckedChanged);
			// 
			// bEditAlgorithm
			// 
			this.bEditAlgorithm.Location = new System.Drawing.Point(13, 40);
			this.bEditAlgorithm.Name = "bEditAlgorithm";
			this.bEditAlgorithm.Size = new System.Drawing.Size(202, 23);
			this.bEditAlgorithm.TabIndex = 5;
			this.bEditAlgorithm.Text = "Edit Algorithm ...";
			this.bEditAlgorithm.UseVisualStyleBackColor = true;
			this.bEditAlgorithm.Click += new System.EventHandler(this.BEditAlgorithm_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.bStop);
			this.panel3.Controls.Add(this.bPrediction);
			this.panel3.Controls.Add(this.bAnomalies);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1385, 60);
			this.panel3.TabIndex = 2;
			// 
			// bStop
			// 
			this.bStop.Enabled = false;
			this.bStop.Location = new System.Drawing.Point(1291, 10);
			this.bStop.Name = "bStop";
			this.bStop.Size = new System.Drawing.Size(76, 40);
			this.bStop.TabIndex = 3;
			this.bStop.Text = "STOP";
			this.bStop.UseVisualStyleBackColor = true;
			this.bStop.Click += new System.EventHandler(this.BStop_Click);
			// 
			// bPrediction
			// 
			this.bPrediction.Location = new System.Drawing.Point(651, 10);
			this.bPrediction.Name = "bPrediction";
			this.bPrediction.Size = new System.Drawing.Size(633, 40);
			this.bPrediction.TabIndex = 2;
			this.bPrediction.Text = "SHOW PREDICTION SAMPLE";
			this.bPrediction.UseVisualStyleBackColor = true;
			this.bPrediction.Click += new System.EventHandler(this.BPrediction_Click);
			// 
			// bAnomalies
			// 
			this.bAnomalies.Location = new System.Drawing.Point(12, 10);
			this.bAnomalies.Name = "bAnomalies";
			this.bAnomalies.Size = new System.Drawing.Size(633, 40);
			this.bAnomalies.TabIndex = 1;
			this.bAnomalies.Text = "SHOW ANOMALIES SAMPLE";
			this.bAnomalies.UseVisualStyleBackColor = true;
			this.bAnomalies.Click += new System.EventHandler(this.BAnomalies_Click);
			// 
			// panelBaseChart
			// 
			this.panelBaseChart.Controls.Add(this.panelWarnings);
			this.panelBaseChart.Controls.Add(this.panelChart);
			this.panelBaseChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBaseChart.Location = new System.Drawing.Point(0, 60);
			this.panelBaseChart.Name = "panelBaseChart";
			this.panelBaseChart.Size = new System.Drawing.Size(1385, 281);
			this.panelBaseChart.TabIndex = 3;
			// 
			// panelWarnings
			// 
			this.panelWarnings.AutoSize = true;
			this.panelWarnings.Controls.Add(this.tbWarnings);
			this.panelWarnings.Controls.Add(this.label7);
			this.panelWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelWarnings.Location = new System.Drawing.Point(1047, 0);
			this.panelWarnings.Name = "panelWarnings";
			this.panelWarnings.Size = new System.Drawing.Size(338, 281);
			this.panelWarnings.TabIndex = 1;
			// 
			// tbWarnings
			// 
			this.tbWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbWarnings.Location = new System.Drawing.Point(0, 26);
			this.tbWarnings.Margin = new System.Windows.Forms.Padding(5);
			this.tbWarnings.Multiline = true;
			this.tbWarnings.Name = "tbWarnings";
			this.tbWarnings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbWarnings.Size = new System.Drawing.Size(338, 255);
			this.tbWarnings.TabIndex = 16;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(0, 0);
			this.label7.Margin = new System.Windows.Forms.Padding(3);
			this.label7.Name = "label7";
			this.label7.Padding = new System.Windows.Forms.Padding(3);
			this.label7.Size = new System.Drawing.Size(338, 26);
			this.label7.TabIndex = 17;
			this.label7.Text = "Warnings / Notifications";
			// 
			// panelChart
			// 
			this.panelChart.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelChart.Location = new System.Drawing.Point(0, 0);
			this.panelChart.Name = "panelChart";
			this.panelChart.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panelChart.Size = new System.Drawing.Size(1047, 281);
			this.panelChart.TabIndex = 0;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// NumericsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1385, 675);
			this.Controls.Add(this.panelBaseChart);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panelOptions);
			this.Controls.Add(this.panelO);
			this.Name = "NumericsForm";
			this.Text = "NumericsForm";
			this.panelO.ResumeLayout(false);
			this.panelOptions.ResumeLayout(false);
			this.panelOptions.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericDaysToAdd)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panelBaseChart.ResumeLayout(false);
			this.panelBaseChart.PerformLayout();
			this.panelWarnings.ResumeLayout(false);
			this.panelWarnings.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelO;
        private System.Windows.Forms.Button bOptions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bPrediction;
        private System.Windows.Forms.Button bAnomalies;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbRealTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbAxisIncrement;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bChartEditor;
        private System.Windows.Forms.ComboBox cbAxisFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDataSets;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bViewData;
        private System.Windows.Forms.Button bClearChart;
        private System.Windows.Forms.Button bResetData;
        private System.Windows.Forms.Button bData;
        private System.Windows.Forms.Label lDataName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericDaysToAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbMovingAverage;
        private System.Windows.Forms.Button bEditAlgorithm;
        private System.Windows.Forms.Panel panelBaseChart;
        private System.Windows.Forms.Panel panelWarnings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbWarnings;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.TextBox tbDataSetDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bStop;
    }
}
