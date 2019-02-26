namespace mview
{
    partial class ChartOptions
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
            this.button1 = new System.Windows.Forms.Button();
            this.boxKeywords = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxAxisYMode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // boxKeywords
            // 
            this.boxKeywords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxKeywords.FormattingEnabled = true;
            this.boxKeywords.IntegralHeight = false;
            this.boxKeywords.Location = new System.Drawing.Point(70, 56);
            this.boxKeywords.Name = "boxKeywords";
            this.boxKeywords.Size = new System.Drawing.Size(103, 21);
            this.boxKeywords.TabIndex = 11;
            this.boxKeywords.SelectedIndexChanged += new System.EventHandler(this.boxKeywords_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Axis X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Axis Y";
            // 
            // boxAxisYMode
            // 
            this.boxAxisYMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxAxisYMode.FormattingEnabled = true;
            this.boxAxisYMode.IntegralHeight = false;
            this.boxAxisYMode.Items.AddRange(new object[] {
            "Normal",
            "Average",
            "Sum"});
            this.boxAxisYMode.Location = new System.Drawing.Point(70, 98);
            this.boxAxisYMode.Name = "boxAxisYMode";
            this.boxAxisYMode.Size = new System.Drawing.Size(103, 21);
            this.boxAxisYMode.TabIndex = 15;
            this.boxAxisYMode.SelectedIndexChanged += new System.EventHandler(this.boxAxisYMode_SelectedIndexChanged);
            // 
            // ChartOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 176);
            this.Controls.Add(this.boxAxisYMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxKeywords);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChartOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Options";
            this.Deactivate += new System.EventHandler(this.ChartOptions_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox boxKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxAxisYMode;
    }
}