namespace Anomaly_TeeChart
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lMSE = new System.Windows.Forms.Label();
			this.lbestWindowSize = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bResetData = new System.Windows.Forms.Button();
			this.bData = new System.Windows.Forms.Button();
			this.lDataName = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.bClearChart = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lMSE);
			this.splitContainer1.Panel1.Controls.Add(this.lbestWindowSize);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
			this.splitContainer1.Size = new System.Drawing.Size(1119, 591);
			this.splitContainer1.SplitterDistance = 100;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			// 
			// lMSE
			// 
			this.lMSE.AutoSize = true;
			this.lMSE.Location = new System.Drawing.Point(124, 41);
			this.lMSE.Name = "lMSE";
			this.lMSE.Size = new System.Drawing.Size(15, 15);
			this.lMSE.TabIndex = 11;
			this.lMSE.Text = "[]";
			// 
			// lbestWindowSize
			// 
			this.lbestWindowSize.AutoSize = true;
			this.lbestWindowSize.Location = new System.Drawing.Point(124, 14);
			this.lbestWindowSize.Name = "lbestWindowSize";
			this.lbestWindowSize.Size = new System.Drawing.Size(15, 15);
			this.lbestWindowSize.TabIndex = 10;
			this.lbestWindowSize.Text = "[]";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(85, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 15);
			this.label2.TabIndex = 9;
			this.label2.Text = "MSE:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 15);
			this.label1.TabIndex = 8;
			this.label1.Text = "Best windowSize:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bClearChart);
			this.groupBox2.Controls.Add(this.bResetData);
			this.groupBox2.Controls.Add(this.bData);
			this.groupBox2.Controls.Add(this.lDataName);
			this.groupBox2.Location = new System.Drawing.Point(718, 14);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(374, 64);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Data";
			// 
			// bResetData
			// 
			this.bResetData.Location = new System.Drawing.Point(178, 23);
			this.bResetData.Name = "bResetData";
			this.bResetData.Size = new System.Drawing.Size(88, 23);
			this.bResetData.TabIndex = 2;
			this.bResetData.Text = "Reset Data";
			this.bResetData.UseVisualStyleBackColor = true;
			this.bResetData.Click += new System.EventHandler(this.bResetData_Click);
			// 
			// bData
			// 
			this.bData.Location = new System.Drawing.Point(29, 23);
			this.bData.Name = "bData";
			this.bData.Size = new System.Drawing.Size(134, 23);
			this.bData.TabIndex = 5;
			this.bData.Text = "Choose Data ...";
			this.bData.UseVisualStyleBackColor = true;
			this.bData.Click += new System.EventHandler(this.bData_Click);
			// 
			// lDataName
			// 
			this.lDataName.AutoSize = true;
			this.lDataName.Location = new System.Drawing.Point(6, 52);
			this.lDataName.Name = "lDataName";
			this.lDataName.Size = new System.Drawing.Size(0, 15);
			this.lDataName.TabIndex = 6;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "DataFile";
			this.openFileDialog1.Filter = "Text files|*txt";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// bClearChart
			// 
			this.bClearChart.Location = new System.Drawing.Point(272, 23);
			this.bClearChart.Name = "bClearChart";
			this.bClearChart.Size = new System.Drawing.Size(88, 23);
			this.bClearChart.TabIndex = 7;
			this.bClearChart.Text = "Clear Chart";
			this.bClearChart.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1119, 591);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "TeeChart and Steema.Numerics";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Steema.TeeChart.TChart tChart1;
        private System.Windows.Forms.Button bData;
        private System.Windows.Forms.Label lDataName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bResetData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lMSE;
        private System.Windows.Forms.Label lbestWindowSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bClearChart;
    }
}

