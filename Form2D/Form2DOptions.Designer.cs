namespace mview
{
    partial class Form2DOptions
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.checkShowAllWell = new System.Windows.Forms.CheckBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.checkShowGridLines = new System.Windows.Forms.CheckBox();
            this.labelMin = new System.Windows.Forms.Label();
            this.boxMaximum = new System.Windows.Forms.TextBox();
            this.boxMinimum = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.numericScaleFactor = new System.Windows.Forms.NumericUpDown();
            this.boxBubbleMode = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.checkShowBubbles = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericScaleFactor)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.checkShowAllWell);
            this.tabPage4.Controls.Add(this.labelMax);
            this.tabPage4.Controls.Add(this.checkShowGridLines);
            this.tabPage4.Controls.Add(this.labelMin);
            this.tabPage4.Controls.Add(this.boxMaximum);
            this.tabPage4.Controls.Add(this.boxMinimum);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.numericScaleFactor);
            this.tabPage4.Controls.Add(this.boxBubbleMode);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.checkShowBubbles);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(351, 395);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Bubble map";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Set color";
            // 
            // checkShowAllWell
            // 
            this.checkShowAllWell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkShowAllWell.AutoSize = true;
            this.checkShowAllWell.Checked = true;
            this.checkShowAllWell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowAllWell.Location = new System.Drawing.Point(21, 280);
            this.checkShowAllWell.Name = "checkShowAllWell";
            this.checkShowAllWell.Size = new System.Drawing.Size(113, 17);
            this.checkShowAllWell.TabIndex = 62;
            this.checkShowAllWell.Text = "Show all well track";
            this.checkShowAllWell.UseVisualStyleBackColor = true;
            this.checkShowAllWell.CheckedChanged += new System.EventHandler(this.checkShowAllWell_CheckedChanged);
            // 
            // labelMax
            // 
            this.labelMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(87, 219);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(51, 13);
            this.labelMax.TabIndex = 61;
            this.labelMax.Text = "Maximum";
            // 
            // checkShowGridLines
            // 
            this.checkShowGridLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkShowGridLines.AutoSize = true;
            this.checkShowGridLines.Location = new System.Drawing.Point(21, 141);
            this.checkShowGridLines.Name = "checkShowGridLines";
            this.checkShowGridLines.Size = new System.Drawing.Size(97, 17);
            this.checkShowGridLines.TabIndex = 60;
            this.checkShowGridLines.Text = "Show grid lines";
            this.checkShowGridLines.UseVisualStyleBackColor = true;
            this.checkShowGridLines.CheckedChanged += new System.EventHandler(this.checkShowGridLines_CheckedChanged);
            // 
            // labelMin
            // 
            this.labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(87, 189);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(47, 13);
            this.labelMin.TabIndex = 59;
            this.labelMin.Text = "Minimum";
            // 
            // boxMaximum
            // 
            this.boxMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMaximum.Location = new System.Drawing.Point(175, 216);
            this.boxMaximum.Name = "boxMaximum";
            this.boxMaximum.Size = new System.Drawing.Size(64, 21);
            this.boxMaximum.TabIndex = 57;
            this.boxMaximum.Text = "1.0";
            this.boxMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.boxMaximum.Validating += new System.ComponentModel.CancelEventHandler(this.boxMaximum_Validating);
            // 
            // boxMinimum
            // 
            this.boxMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMinimum.Location = new System.Drawing.Point(175, 189);
            this.boxMinimum.Name = "boxMinimum";
            this.boxMinimum.Size = new System.Drawing.Size(64, 21);
            this.boxMinimum.TabIndex = 56;
            this.boxMinimum.Text = "0.0";
            this.boxMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.boxMinimum.Validating += new System.ComponentModel.CancelEventHandler(this.boxMinimum_Validating);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 101);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 55;
            this.label22.Text = "Scale factor";
            // 
            // numericScaleFactor
            // 
            this.numericScaleFactor.Location = new System.Drawing.Point(175, 99);
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
            this.numericScaleFactor.TabIndex = 54;
            this.numericScaleFactor.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericScaleFactor.ValueChanged += new System.EventHandler(this.numericScaleFactor_ValueChanged);
            // 
            // boxBubbleMode
            // 
            this.boxBubbleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxBubbleMode.FormattingEnabled = true;
            this.boxBubbleMode.IntegralHeight = false;
            this.boxBubbleMode.Items.AddRange(new object[] {
            "Simulation",
            "History"});
            this.boxBubbleMode.Location = new System.Drawing.Point(133, 62);
            this.boxBubbleMode.Name = "boxBubbleMode";
            this.boxBubbleMode.Size = new System.Drawing.Size(106, 21);
            this.boxBubbleMode.TabIndex = 53;
            this.boxBubbleMode.SelectedIndexChanged += new System.EventHandler(this.boxBubbleMode_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 13);
            this.label21.TabIndex = 52;
            this.label21.Text = "Bubble map mode";
            // 
            // checkShowBubbles
            // 
            this.checkShowBubbles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkShowBubbles.AutoSize = true;
            this.checkShowBubbles.Checked = true;
            this.checkShowBubbles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowBubbles.Location = new System.Drawing.Point(21, 26);
            this.checkShowBubbles.Name = "checkShowBubbles";
            this.checkShowBubbles.Size = new System.Drawing.Size(92, 17);
            this.checkShowBubbles.TabIndex = 51;
            this.checkShowBubbles.Text = "Show bubbles";
            this.checkShowBubbles.UseVisualStyleBackColor = true;
            this.checkShowBubbles.CheckedChanged += new System.EventHandler(this.checkShowBubbles_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(359, 421);
            this.tabControl1.TabIndex = 30;
            // 
            // Form2DOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 446);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2DOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2D Options";
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericScaleFactor)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.CheckBox checkShowGridLines;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.TextBox boxMaximum;
        private System.Windows.Forms.TextBox boxMinimum;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numericScaleFactor;
        private System.Windows.Forms.ComboBox boxBubbleMode;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkShowBubbles;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox checkShowAllWell;
        private System.Windows.Forms.Label label1;
    }
}