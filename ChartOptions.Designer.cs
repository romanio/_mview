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
            this.boxAxisXMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxAxisYMode = new System.Windows.Forms.ComboBox();
            this.listBoxKeywords = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonApplySeries = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkSmooth = new System.Windows.Forms.CheckBox();
            this.numericMarkerSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonMarkerFill = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonMarkerBorderColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonLineColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.boxMarkerStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxLineStyle = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonLineColorDefault = new System.Windows.Forms.Button();
            this.buttonMarkerBorderDefault = new System.Windows.Forms.Button();
            this.buttonMarkerFillDefault = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMarkerSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLineWidth)).BeginInit();
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
            // boxAxisXMode
            // 
            this.boxAxisXMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxAxisXMode.FormattingEnabled = true;
            this.boxAxisXMode.IntegralHeight = false;
            this.boxAxisXMode.Location = new System.Drawing.Point(109, 14);
            this.boxAxisXMode.Name = "boxAxisXMode";
            this.boxAxisXMode.Size = new System.Drawing.Size(103, 21);
            this.boxAxisXMode.TabIndex = 11;
            this.boxAxisXMode.SelectedIndexChanged += new System.EventHandler(this.boxKeywords_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Axis X Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Axis Y Mode";
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
            this.boxAxisYMode.Location = new System.Drawing.Point(109, 57);
            this.boxAxisYMode.Name = "boxAxisYMode";
            this.boxAxisYMode.Size = new System.Drawing.Size(103, 21);
            this.boxAxisYMode.TabIndex = 15;
            this.boxAxisYMode.SelectedIndexChanged += new System.EventHandler(this.boxAxisYMode_SelectedIndexChanged);
            // 
            // listBoxKeywords
            // 
            this.listBoxKeywords.FormattingEnabled = true;
            this.listBoxKeywords.IntegralHeight = false;
            this.listBoxKeywords.Location = new System.Drawing.Point(6, 6);
            this.listBoxKeywords.Name = "listBoxKeywords";
            this.listBoxKeywords.Size = new System.Drawing.Size(80, 337);
            this.listBoxKeywords.TabIndex = 0;
            this.listBoxKeywords.SelectedIndexChanged += new System.EventHandler(this.listBoxKeywords_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(304, 394);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.boxAxisYMode);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.boxAxisXMode);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(286, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Axes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonMarkerFillDefault);
            this.tabPage2.Controls.Add(this.buttonMarkerBorderDefault);
            this.tabPage2.Controls.Add(this.buttonLineColorDefault);
            this.tabPage2.Controls.Add(this.buttonApplySeries);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.checkSmooth);
            this.tabPage2.Controls.Add(this.numericMarkerSize);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.numericLineWidth);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.buttonMarkerFill);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.buttonMarkerBorderColor);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.buttonLineColor);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.boxMarkerStyle);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.boxLineStyle);
            this.tabPage2.Controls.Add(this.listBoxKeywords);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(296, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Series";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonApplySeries
            // 
            this.buttonApplySeries.Location = new System.Drawing.Point(187, 320);
            this.buttonApplySeries.Name = "buttonApplySeries";
            this.buttonApplySeries.Size = new System.Drawing.Size(103, 23);
            this.buttonApplySeries.TabIndex = 28;
            this.buttonApplySeries.Text = "Apply style";
            this.buttonApplySeries.UseVisualStyleBackColor = true;
            this.buttonApplySeries.Click += new System.EventHandler(this.buttonApplySeries_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(100, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Smooth line";
            // 
            // checkSmooth
            // 
            this.checkSmooth.AutoSize = true;
            this.checkSmooth.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkSmooth.Location = new System.Drawing.Point(187, 98);
            this.checkSmooth.Name = "checkSmooth";
            this.checkSmooth.Size = new System.Drawing.Size(81, 17);
            this.checkSmooth.TabIndex = 26;
            this.checkSmooth.Text = "Yes, please";
            this.checkSmooth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkSmooth.UseVisualStyleBackColor = true;
            // 
            // numericMarkerSize
            // 
            this.numericMarkerSize.Location = new System.Drawing.Point(187, 174);
            this.numericMarkerSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMarkerSize.Name = "numericMarkerSize";
            this.numericMarkerSize.Size = new System.Drawing.Size(103, 21);
            this.numericMarkerSize.TabIndex = 25;
            this.numericMarkerSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Marker size";
            // 
            // numericLineWidth
            // 
            this.numericLineWidth.Location = new System.Drawing.Point(187, 67);
            this.numericLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLineWidth.Name = "numericLineWidth";
            this.numericLineWidth.Size = new System.Drawing.Size(103, 21);
            this.numericLineWidth.TabIndex = 23;
            this.numericLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Line width";
            // 
            // buttonMarkerFill
            // 
            this.buttonMarkerFill.Location = new System.Drawing.Point(187, 246);
            this.buttonMarkerFill.Name = "buttonMarkerFill";
            this.buttonMarkerFill.Size = new System.Drawing.Size(81, 23);
            this.buttonMarkerFill.TabIndex = 21;
            this.buttonMarkerFill.Text = "(default)";
            this.buttonMarkerFill.UseVisualStyleBackColor = true;
            this.buttonMarkerFill.Click += new System.EventHandler(this.buttonMarkerFill_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Marker fill";
            // 
            // buttonMarkerBorderColor
            // 
            this.buttonMarkerBorderColor.Location = new System.Drawing.Point(187, 217);
            this.buttonMarkerBorderColor.Name = "buttonMarkerBorderColor";
            this.buttonMarkerBorderColor.Size = new System.Drawing.Size(81, 23);
            this.buttonMarkerBorderColor.TabIndex = 19;
            this.buttonMarkerBorderColor.Text = "(default)";
            this.buttonMarkerBorderColor.UseVisualStyleBackColor = true;
            this.buttonMarkerBorderColor.Click += new System.EventHandler(this.buttonMarkerBorderColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Marker border";
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLineColor.Location = new System.Drawing.Point(187, 36);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(81, 23);
            this.buttonLineColor.TabIndex = 17;
            this.buttonLineColor.Text = "(default)";
            this.buttonLineColor.UseVisualStyleBackColor = true;
            this.buttonLineColor.Click += new System.EventHandler(this.buttonLineColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Line color";
            // 
            // boxMarkerStyle
            // 
            this.boxMarkerStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMarkerStyle.FormattingEnabled = true;
            this.boxMarkerStyle.IntegralHeight = false;
            this.boxMarkerStyle.Location = new System.Drawing.Point(187, 147);
            this.boxMarkerStyle.Name = "boxMarkerStyle";
            this.boxMarkerStyle.Size = new System.Drawing.Size(103, 21);
            this.boxMarkerStyle.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Marker style";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Line style";
            // 
            // boxLineStyle
            // 
            this.boxLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxLineStyle.FormattingEnabled = true;
            this.boxLineStyle.IntegralHeight = false;
            this.boxLineStyle.Location = new System.Drawing.Point(187, 9);
            this.boxLineStyle.Name = "boxLineStyle";
            this.boxLineStyle.Size = new System.Drawing.Size(103, 21);
            this.boxLineStyle.TabIndex = 12;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // buttonLineColorDefault
            // 
            this.buttonLineColorDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLineColorDefault.Location = new System.Drawing.Point(269, 36);
            this.buttonLineColorDefault.Name = "buttonLineColorDefault";
            this.buttonLineColorDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonLineColorDefault.TabIndex = 29;
            this.buttonLineColorDefault.Text = "D";
            this.buttonLineColorDefault.UseVisualStyleBackColor = true;
            this.buttonLineColorDefault.Click += new System.EventHandler(this.buttonLineColorDefault_Click);
            // 
            // buttonMarkerBorderDefault
            // 
            this.buttonMarkerBorderDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMarkerBorderDefault.Location = new System.Drawing.Point(269, 217);
            this.buttonMarkerBorderDefault.Name = "buttonMarkerBorderDefault";
            this.buttonMarkerBorderDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonMarkerBorderDefault.TabIndex = 30;
            this.buttonMarkerBorderDefault.Text = "D";
            this.buttonMarkerBorderDefault.UseVisualStyleBackColor = true;
            this.buttonMarkerBorderDefault.Click += new System.EventHandler(this.buttonMarkerBorderDefault_Click);
            // 
            // buttonMarkerFillDefault
            // 
            this.buttonMarkerFillDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMarkerFillDefault.Location = new System.Drawing.Point(269, 246);
            this.buttonMarkerFillDefault.Name = "buttonMarkerFillDefault";
            this.buttonMarkerFillDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonMarkerFillDefault.TabIndex = 31;
            this.buttonMarkerFillDefault.Text = "D";
            this.buttonMarkerFillDefault.UseVisualStyleBackColor = true;
            this.buttonMarkerFillDefault.Click += new System.EventHandler(this.buttonMarkerFillDefault_Click);
            // 
            // ChartOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 440);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChartOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Options";
            this.Deactivate += new System.EventHandler(this.ChartOptions_Deactivate);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMarkerSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLineWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox boxAxisXMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxAxisYMode;
        private System.Windows.Forms.ListBox listBoxKeywords;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxLineStyle;
        private System.Windows.Forms.ComboBox boxMarkerStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonLineColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonMarkerBorderColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonMarkerFill;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericLineWidth;
        private System.Windows.Forms.NumericUpDown numericMarkerSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkSmooth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonApplySeries;
        private System.Windows.Forms.Button buttonLineColorDefault;
        private System.Windows.Forms.Button buttonMarkerFillDefault;
        private System.Windows.Forms.Button buttonMarkerBorderDefault;
    }
}