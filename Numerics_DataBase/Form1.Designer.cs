namespace Numerics_DataBase
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.bEdit = new System.Windows.Forms.Button();
			this.bDoPredictions = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.bEdit);
			this.splitContainer1.Panel1.Controls.Add(this.bDoPredictions);
			this.splitContainer1.Size = new System.Drawing.Size(1197, 569);
			this.splitContainer1.SplitterDistance = 397;
			this.splitContainer1.TabIndex = 0;
			this.splitContainer1.Text = "splitContainer1";
			// 
			// bEdit
			// 
			this.bEdit.Location = new System.Drawing.Point(24, 23);
			this.bEdit.Name = "bEdit";
			this.bEdit.Size = new System.Drawing.Size(211, 23);
			this.bEdit.TabIndex = 2;
			this.bEdit.Text = "Edit default prediction settings ...";
			this.bEdit.UseVisualStyleBackColor = true;
			this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
			// 
			// bDoPredictions
			// 
			this.bDoPredictions.Location = new System.Drawing.Point(24, 52);
			this.bDoPredictions.Name = "bDoPredictions";
			this.bDoPredictions.Size = new System.Drawing.Size(211, 23);
			this.bDoPredictions.TabIndex = 1;
			this.bDoPredictions.Text = "Do Predictions";
			this.bDoPredictions.UseVisualStyleBackColor = true;
			this.bDoPredictions.Click += new System.EventHandler(this.bDoPredictions_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1197, 569);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "Numerics DataBase";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bDoPredictions;
        private System.Windows.Forms.Button bEdit;
    }
}

