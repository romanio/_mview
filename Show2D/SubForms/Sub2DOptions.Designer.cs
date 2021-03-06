﻿namespace mview
{
    partial class Sub2DOptions
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
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.MaxColorDefault = new System.Windows.Forms.Button();
            this.MinColorDefault = new System.Windows.Forms.Button();
            this.boxMaximum = new System.Windows.Forms.TextBox();
            this.boxMinimum = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.numericZScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackStratch = new System.Windows.Forms.TrackBar();
            this.checkShowAllWell = new System.Windows.Forms.CheckBox();
            this.checkShowGridLines = new System.Windows.Forms.CheckBox();
            this.checkShowBubbles = new System.Windows.Forms.CheckBox();
            this.boxBubbleMode = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.numericScaleFactor = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkNoFillColor = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.numericZScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScaleFactor)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotView
            // 
            this.plotView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.Location = new System.Drawing.Point(6, 6);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(492, 363);
            this.plotView.TabIndex = 72;
            this.plotView.Text = "plotHisto";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNWSE;
            // 
            // MaxColorDefault
            // 
            this.MaxColorDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaxColorDefault.Location = new System.Drawing.Point(154, 79);
            this.MaxColorDefault.Name = "MaxColorDefault";
            this.MaxColorDefault.Size = new System.Drawing.Size(24, 21);
            this.MaxColorDefault.TabIndex = 71;
            this.MaxColorDefault.Text = "D";
            this.MaxColorDefault.UseVisualStyleBackColor = true;
            this.MaxColorDefault.Click += new System.EventHandler(this.MaxColorDefault_Click);
            // 
            // MinColorDefault
            // 
            this.MinColorDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinColorDefault.Location = new System.Drawing.Point(154, 46);
            this.MinColorDefault.Name = "MinColorDefault";
            this.MinColorDefault.Size = new System.Drawing.Size(24, 22);
            this.MinColorDefault.TabIndex = 70;
            this.MinColorDefault.Text = "D";
            this.MinColorDefault.UseVisualStyleBackColor = true;
            this.MinColorDefault.Click += new System.EventHandler(this.MinColorDefault_Click);
            // 
            // boxMaximum
            // 
            this.boxMaximum.Location = new System.Drawing.Point(72, 79);
            this.boxMaximum.Name = "boxMaximum";
            this.boxMaximum.Size = new System.Drawing.Size(76, 21);
            this.boxMaximum.TabIndex = 67;
            this.boxMaximum.Text = "1.0";
            this.boxMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.boxMaximum.Validating += new System.ComponentModel.CancelEventHandler(this.boxMaximum_Validating);
            // 
            // boxMinimum
            // 
            this.boxMinimum.Location = new System.Drawing.Point(72, 47);
            this.boxMinimum.Name = "boxMinimum";
            this.boxMinimum.Size = new System.Drawing.Size(76, 21);
            this.boxMinimum.TabIndex = 66;
            this.boxMinimum.Text = "0.0";
            this.boxMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.boxMinimum.Validating += new System.ComponentModel.CancelEventHandler(this.boxMinimum_Validating);
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(18, 82);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(51, 13);
            this.labelMax.TabIndex = 69;
            this.labelMax.Text = "Maximum";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(19, 50);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(47, 13);
            this.labelMin.TabIndex = 68;
            this.labelMin.Text = "Minimum";
            // 
            // numericZScale
            // 
            this.numericZScale.Location = new System.Drawing.Point(198, 164);
            this.numericZScale.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericZScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericZScale.Name = "numericZScale";
            this.numericZScale.Size = new System.Drawing.Size(64, 21);
            this.numericZScale.TabIndex = 70;
            this.numericZScale.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericZScale.ValueChanged += new System.EventHandler(this.numericZScale_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Z Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Stretch factor";
            // 
            // trackStratch
            // 
            this.trackStratch.BackColor = System.Drawing.SystemColors.Window;
            this.trackStratch.Location = new System.Drawing.Point(106, 277);
            this.trackStratch.Maximum = 100;
            this.trackStratch.Name = "trackStratch";
            this.trackStratch.Size = new System.Drawing.Size(178, 45);
            this.trackStratch.TabIndex = 66;
            this.trackStratch.TickFrequency = 4;
            this.trackStratch.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackStratch.Scroll += new System.EventHandler(this.trackStratch_Scroll);
            // 
            // checkShowAllWell
            // 
            this.checkShowAllWell.AutoSize = true;
            this.checkShowAllWell.Checked = true;
            this.checkShowAllWell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowAllWell.Location = new System.Drawing.Point(20, 206);
            this.checkShowAllWell.Name = "checkShowAllWell";
            this.checkShowAllWell.Size = new System.Drawing.Size(113, 17);
            this.checkShowAllWell.TabIndex = 64;
            this.checkShowAllWell.Text = "Show all well track";
            this.checkShowAllWell.UseVisualStyleBackColor = true;
            this.checkShowAllWell.CheckedChanged += new System.EventHandler(this.checkShowAllWell_CheckedChanged);
            // 
            // checkShowGridLines
            // 
            this.checkShowGridLines.AutoSize = true;
            this.checkShowGridLines.Checked = true;
            this.checkShowGridLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowGridLines.Location = new System.Drawing.Point(20, 165);
            this.checkShowGridLines.Name = "checkShowGridLines";
            this.checkShowGridLines.Size = new System.Drawing.Size(97, 17);
            this.checkShowGridLines.TabIndex = 63;
            this.checkShowGridLines.Text = "Show grid lines";
            this.checkShowGridLines.UseVisualStyleBackColor = true;
            this.checkShowGridLines.CheckedChanged += new System.EventHandler(this.checkShowGridLines_CheckedChanged);
            // 
            // checkShowBubbles
            // 
            this.checkShowBubbles.AutoSize = true;
            this.checkShowBubbles.Checked = true;
            this.checkShowBubbles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowBubbles.Location = new System.Drawing.Point(21, 353);
            this.checkShowBubbles.Name = "checkShowBubbles";
            this.checkShowBubbles.Size = new System.Drawing.Size(92, 17);
            this.checkShowBubbles.TabIndex = 56;
            this.checkShowBubbles.Text = "Show bubbles";
            this.checkShowBubbles.UseVisualStyleBackColor = true;
            this.checkShowBubbles.CheckedChanged += new System.EventHandler(this.checkShowBubbles_CheckedChanged);
            // 
            // boxBubbleMode
            // 
            this.boxBubbleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxBubbleMode.FormattingEnabled = true;
            this.boxBubbleMode.IntegralHeight = false;
            this.boxBubbleMode.Items.AddRange(new object[] {
            "Simulation",
            "History"});
            this.boxBubbleMode.Location = new System.Drawing.Point(126, 385);
            this.boxBubbleMode.Name = "boxBubbleMode";
            this.boxBubbleMode.Size = new System.Drawing.Size(106, 21);
            this.boxBubbleMode.TabIndex = 58;
            this.boxBubbleMode.SelectedIndexChanged += new System.EventHandler(this.boxBubbleMode_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 388);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 13);
            this.label21.TabIndex = 57;
            this.label21.Text = "Bubble map mode";
            // 
            // numericScaleFactor
            // 
            this.numericScaleFactor.Location = new System.Drawing.Point(126, 429);
            this.numericScaleFactor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericScaleFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericScaleFactor.Name = "numericScaleFactor";
            this.numericScaleFactor.Size = new System.Drawing.Size(64, 21);
            this.numericScaleFactor.TabIndex = 59;
            this.numericScaleFactor.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericScaleFactor.ValueChanged += new System.EventHandler(this.numericScaleFactor_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 429);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 60;
            this.label22.Text = "Scale factor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Colors";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Grid";
            // 
            // checkNoFillColor
            // 
            this.checkNoFillColor.AutoSize = true;
            this.checkNoFillColor.Checked = true;
            this.checkNoFillColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNoFillColor.Location = new System.Drawing.Point(20, 242);
            this.checkNoFillColor.Name = "checkNoFillColor";
            this.checkNoFillColor.Size = new System.Drawing.Size(82, 17);
            this.checkNoFillColor.TabIndex = 71;
            this.checkNoFillColor.Text = "No Fill Color";
            this.checkNoFillColor.UseVisualStyleBackColor = true;
            this.checkNoFillColor.CheckedChanged += new System.EventHandler(this.checkNoFillColor_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(20, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Bubbles";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 509);
            this.tabControl1.TabIndex = 75;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MaxColorDefault);
            this.tabPage1.Controls.Add(this.checkShowBubbles);
            this.tabPage1.Controls.Add(this.boxMinimum);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.labelMax);
            this.tabPage1.Controls.Add(this.boxBubbleMode);
            this.tabPage1.Controls.Add(this.boxMaximum);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.trackStratch);
            this.tabPage1.Controls.Add(this.numericScaleFactor);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.labelMin);
            this.tabPage1.Controls.Add(this.MinColorDefault);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.checkShowGridLines);
            this.tabPage1.Controls.Add(this.numericZScale);
            this.tabPage1.Controls.Add(this.checkShowAllWell);
            this.tabPage1.Controls.Add(this.checkNoFillColor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grid Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.plotView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistic";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Sub2DOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 535);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sub2DOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2D View Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubFormOptions_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericZScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScaleFactor)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button MaxColorDefault;
        private System.Windows.Forms.Button MinColorDefault;
        public System.Windows.Forms.TextBox boxMaximum;
        public System.Windows.Forms.TextBox boxMinimum;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private OxyPlot.WindowsForms.PlotView plotView;
        public System.Windows.Forms.CheckBox checkShowAllWell;
        public System.Windows.Forms.CheckBox checkShowGridLines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackStratch;
        public System.Windows.Forms.CheckBox checkShowBubbles;
        public System.Windows.Forms.ComboBox boxBubbleMode;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.NumericUpDown numericScaleFactor;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericZScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox checkNoFillColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}