namespace mview
{
    partial class SubGraphicFilter
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
            this.comboSliceX = new System.Windows.Forms.ComboBox();
            this.checkboxUseIndexFilter = new System.Windows.Forms.CheckBox();
            this.radioButtonUseX = new System.Windows.Forms.RadioButton();
            this.radioButtonUseY = new System.Windows.Forms.RadioButton();
            this.radioButtonUseZ = new System.Windows.Forms.RadioButton();
            this.comboSliceY = new System.Windows.Forms.ComboBox();
            this.comboSliceZ = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboSliceX
            // 
            this.comboSliceX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSliceX.Enabled = false;
            this.comboSliceX.FormattingEnabled = true;
            this.comboSliceX.Location = new System.Drawing.Point(195, 25);
            this.comboSliceX.Name = "comboSliceX";
            this.comboSliceX.Size = new System.Drawing.Size(116, 21);
            this.comboSliceX.TabIndex = 40;
            this.comboSliceX.SelectedIndexChanged += new System.EventHandler(this.ComboSliceXOnSelectedIndexChanged);
            // 
            // checkboxUseIndexFilter
            // 
            this.checkboxUseIndexFilter.AutoSize = true;
            this.checkboxUseIndexFilter.Location = new System.Drawing.Point(12, 25);
            this.checkboxUseIndexFilter.Name = "checkboxUseIndexFilter";
            this.checkboxUseIndexFilter.Size = new System.Drawing.Size(98, 17);
            this.checkboxUseIndexFilter.TabIndex = 45;
            this.checkboxUseIndexFilter.Text = "Use index filter";
            this.checkboxUseIndexFilter.UseVisualStyleBackColor = true;
            this.checkboxUseIndexFilter.CheckedChanged += new System.EventHandler(this.CheckBoxUseIndexFilterOnCheckedChanged);
            // 
            // radioButtonUseX
            // 
            this.radioButtonUseX.AutoSize = true;
            this.radioButtonUseX.Checked = true;
            this.radioButtonUseX.Enabled = false;
            this.radioButtonUseX.Location = new System.Drawing.Point(135, 26);
            this.radioButtonUseX.Name = "radioButtonUseX";
            this.radioButtonUseX.Size = new System.Drawing.Size(43, 17);
            this.radioButtonUseX.TabIndex = 46;
            this.radioButtonUseX.TabStop = true;
            this.radioButtonUseX.Text = "X(I)";
            this.radioButtonUseX.UseVisualStyleBackColor = true;
            this.radioButtonUseX.CheckedChanged += new System.EventHandler(this.RadioButtonUseXOnCheckedChanged);
            // 
            // radioButtonUseY
            // 
            this.radioButtonUseY.AutoSize = true;
            this.radioButtonUseY.Enabled = false;
            this.radioButtonUseY.Location = new System.Drawing.Point(134, 62);
            this.radioButtonUseY.Name = "radioButtonUseY";
            this.radioButtonUseY.Size = new System.Drawing.Size(44, 17);
            this.radioButtonUseY.TabIndex = 47;
            this.radioButtonUseY.Text = "Y(J)";
            this.radioButtonUseY.UseVisualStyleBackColor = true;
            this.radioButtonUseY.CheckedChanged += new System.EventHandler(this.RadioButtonUseYOnCheckedChanged);
            // 
            // radioButtonUseZ
            // 
            this.radioButtonUseZ.AutoSize = true;
            this.radioButtonUseZ.Enabled = false;
            this.radioButtonUseZ.Location = new System.Drawing.Point(134, 98);
            this.radioButtonUseZ.Name = "radioButtonUseZ";
            this.radioButtonUseZ.Size = new System.Drawing.Size(45, 17);
            this.radioButtonUseZ.TabIndex = 48;
            this.radioButtonUseZ.Text = "Z(K)";
            this.radioButtonUseZ.UseVisualStyleBackColor = true;
            this.radioButtonUseZ.CheckedChanged += new System.EventHandler(this.RadioButtonUseZOnCheckedChanged);
            // 
            // comboSliceY
            // 
            this.comboSliceY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSliceY.Enabled = false;
            this.comboSliceY.FormattingEnabled = true;
            this.comboSliceY.Location = new System.Drawing.Point(195, 61);
            this.comboSliceY.Name = "comboSliceY";
            this.comboSliceY.Size = new System.Drawing.Size(116, 21);
            this.comboSliceY.TabIndex = 49;
            this.comboSliceY.SelectedIndexChanged += new System.EventHandler(this.ComboSliceYOnSelectedIndexChanged);
            // 
            // comboSliceZ
            // 
            this.comboSliceZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSliceZ.Enabled = false;
            this.comboSliceZ.FormattingEnabled = true;
            this.comboSliceZ.Location = new System.Drawing.Point(195, 97);
            this.comboSliceZ.Name = "comboSliceZ";
            this.comboSliceZ.Size = new System.Drawing.Size(116, 21);
            this.comboSliceZ.TabIndex = 50;
            this.comboSliceZ.SelectedIndexChanged += new System.EventHandler(this.ComboSliceZOnSelectedIndexChanged);
            // 
            // SubGraphicFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 390);
            this.Controls.Add(this.comboSliceZ);
            this.Controls.Add(this.comboSliceY);
            this.Controls.Add(this.radioButtonUseZ);
            this.Controls.Add(this.radioButtonUseY);
            this.Controls.Add(this.radioButtonUseX);
            this.Controls.Add(this.checkboxUseIndexFilter);
            this.Controls.Add(this.comboSliceX);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubGraphicFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubGraphicFilterOnFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboSliceX;
        private System.Windows.Forms.CheckBox checkboxUseIndexFilter;
        private System.Windows.Forms.RadioButton radioButtonUseX;
        private System.Windows.Forms.RadioButton radioButtonUseY;
        private System.Windows.Forms.RadioButton radioButtonUseZ;
        private System.Windows.Forms.ComboBox comboSliceY;
        private System.Windows.Forms.ComboBox comboSliceZ;
    }
}