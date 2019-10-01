namespace mview
{
    partial class UСOptions
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.trackStratch = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MaxColorDefault = new System.Windows.Forms.Button();
            this.MinColorDefault = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericScaleFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Set color";
            // 
            // checkShowAllWell
            // 
            this.checkShowAllWell.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkShowAllWell.AutoSize = true;
            this.checkShowAllWell.Checked = true;
            this.checkShowAllWell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowAllWell.Location = new System.Drawing.Point(23, 69);
            this.checkShowAllWell.Name = "checkShowAllWell";
            this.checkShowAllWell.Size = new System.Drawing.Size(113, 17);
            this.checkShowAllWell.TabIndex = 62;
            this.checkShowAllWell.Text = "Show all well track";
            this.checkShowAllWell.UseVisualStyleBackColor = true;
            this.checkShowAllWell.CheckedChanged += new System.EventHandler(this.checkShowAllWell_CheckedChanged);
            // 
            // labelMax
            // 
            this.labelMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(27, 99);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(51, 13);
            this.labelMax.TabIndex = 61;
            this.labelMax.Text = "Maximum";
            // 
            // checkShowGridLines
            // 
            this.checkShowGridLines.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkShowGridLines.AutoSize = true;
            this.checkShowGridLines.Location = new System.Drawing.Point(23, 28);
            this.checkShowGridLines.Name = "checkShowGridLines";
            this.checkShowGridLines.Size = new System.Drawing.Size(97, 17);
            this.checkShowGridLines.TabIndex = 60;
            this.checkShowGridLines.Text = "Show grid lines";
            this.checkShowGridLines.UseVisualStyleBackColor = true;
            this.checkShowGridLines.CheckedChanged += new System.EventHandler(this.checkShowGridLines_CheckedChanged);
            // 
            // labelMin
            // 
            this.labelMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(28, 67);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(47, 13);
            this.labelMin.TabIndex = 59;
            this.labelMin.Text = "Minimum";
            // 
            // boxMaximum
            // 
            this.boxMaximum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxMaximum.Location = new System.Drawing.Point(115, 96);
            this.boxMaximum.Name = "boxMaximum";
            this.boxMaximum.Size = new System.Drawing.Size(64, 21);
            this.boxMaximum.TabIndex = 57;
            this.boxMaximum.Text = "1.0";
            this.boxMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.boxMaximum.Validating += new System.ComponentModel.CancelEventHandler(this.boxMaximum_Validating);
            // 
            // boxMinimum
            // 
            this.boxMinimum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxMinimum.Location = new System.Drawing.Point(115, 64);
            this.boxMinimum.Name = "boxMinimum";
            this.boxMinimum.Size = new System.Drawing.Size(64, 21);
            this.boxMinimum.TabIndex = 56;
            this.boxMinimum.Text = "0.0";
            this.boxMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.boxMinimum.Validating += new System.ComponentModel.CancelEventHandler(this.boxMinimum_Validating);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 112);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 55;
            this.label22.Text = "Scale factor";
            // 
            // numericScaleFactor
            // 
            this.numericScaleFactor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericScaleFactor.Location = new System.Drawing.Point(122, 112);
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
            this.boxBubbleMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxBubbleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxBubbleMode.FormattingEnabled = true;
            this.boxBubbleMode.IntegralHeight = false;
            this.boxBubbleMode.Items.AddRange(new object[] {
            "Simulation",
            "History"});
            this.boxBubbleMode.Location = new System.Drawing.Point(109, 58);
            this.boxBubbleMode.Name = "boxBubbleMode";
            this.boxBubbleMode.Size = new System.Drawing.Size(106, 21);
            this.boxBubbleMode.TabIndex = 53;
            this.boxBubbleMode.SelectedIndexChanged += new System.EventHandler(this.boxBubbleMode_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 13);
            this.label21.TabIndex = 52;
            this.label21.Text = "Bubble map mode";
            // 
            // checkShowBubbles
            // 
            this.checkShowBubbles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkShowBubbles.AutoSize = true;
            this.checkShowBubbles.Checked = true;
            this.checkShowBubbles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowBubbles.Location = new System.Drawing.Point(10, 23);
            this.checkShowBubbles.Name = "checkShowBubbles";
            this.checkShowBubbles.Size = new System.Drawing.Size(92, 17);
            this.checkShowBubbles.TabIndex = 51;
            this.checkShowBubbles.Text = "Show bubbles";
            this.checkShowBubbles.UseVisualStyleBackColor = true;
            this.checkShowBubbles.CheckedChanged += new System.EventHandler(this.checkShowBubbles_CheckedChanged);
            // 
            // trackStratch
            // 
            this.trackStratch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackStratch.BackColor = System.Drawing.SystemColors.Window;
            this.trackStratch.Location = new System.Drawing.Point(23, 166);
            this.trackStratch.Maximum = 100;
            this.trackStratch.Name = "trackStratch";
            this.trackStratch.Size = new System.Drawing.Size(178, 45);
            this.trackStratch.TabIndex = 64;
            this.trackStratch.TickFrequency = 4;
            this.trackStratch.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackStratch.Scroll += new System.EventHandler(this.trackStratch_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(229, 290);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 65;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.trackStratch);
            this.tabPage1.Controls.Add(this.checkShowAllWell);
            this.tabPage1.Controls.Add(this.checkShowGridLines);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(221, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grid";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Stretch factor";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkShowBubbles);
            this.tabPage2.Controls.Add(this.boxBubbleMode);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.numericScaleFactor);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(221, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bubbles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.MaxColorDefault);
            this.tabPage3.Controls.Add(this.MinColorDefault);
            this.tabPage3.Controls.Add(this.boxMaximum);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.boxMinimum);
            this.tabPage3.Controls.Add(this.labelMax);
            this.tabPage3.Controls.Add(this.labelMin);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(221, 264);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Colors";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MaxColorDefault
            // 
            this.MaxColorDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaxColorDefault.Location = new System.Drawing.Point(185, 99);
            this.MaxColorDefault.Name = "MaxColorDefault";
            this.MaxColorDefault.Size = new System.Drawing.Size(24, 21);
            this.MaxColorDefault.TabIndex = 65;
            this.MaxColorDefault.Text = "D";
            this.MaxColorDefault.UseVisualStyleBackColor = true;
            this.MaxColorDefault.Click += new System.EventHandler(this.MaxColorDefault_Click);
            // 
            // MinColorDefault
            // 
            this.MinColorDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinColorDefault.Location = new System.Drawing.Point(185, 64);
            this.MinColorDefault.Name = "MinColorDefault";
            this.MinColorDefault.Size = new System.Drawing.Size(24, 21);
            this.MinColorDefault.TabIndex = 64;
            this.MinColorDefault.Text = "D";
            this.MinColorDefault.UseVisualStyleBackColor = true;
            this.MinColorDefault.Click += new System.EventHandler(this.MinColorDefault_Click);
            // 
            // UСOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UСOptions";
            this.Size = new System.Drawing.Size(259, 320);
            this.VisibleChanged += new System.EventHandler(this.UСOptions_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericScaleFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.CheckBox checkShowAllWell;
        public System.Windows.Forms.CheckBox checkShowGridLines;
        public System.Windows.Forms.TextBox boxMaximum;
        public System.Windows.Forms.TextBox boxMinimum;
        public System.Windows.Forms.NumericUpDown numericScaleFactor;
        public System.Windows.Forms.ComboBox boxBubbleMode;
        public System.Windows.Forms.CheckBox checkShowBubbles;
        private System.Windows.Forms.TrackBar trackStratch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button MaxColorDefault;
        private System.Windows.Forms.Button MinColorDefault;
    }
}
