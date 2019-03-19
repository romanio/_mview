namespace mview
{
    partial class Form2D
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Static ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Dynamic");
            this.label2 = new System.Windows.Forms.Label();
            this.boxRestart = new System.Windows.Forms.ComboBox();
            this.glControl = new OpenTK.GLControl();
            this.boxMaximum = new System.Windows.Forms.TextBox();
            this.treeProperties = new System.Windows.Forms.TreeView();
            this.boxMinimum = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.boxZslice = new System.Windows.Forms.ComboBox();
            this.chkShowGridLines = new System.Windows.Forms.CheckBox();
            this.tabSliceControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boxXslice = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.boxYslice = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.boxScaleZ = new System.Windows.Forms.TextBox();
            this.labelPickValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackStretch = new System.Windows.Forms.TrackBar();
            this.bbColorReset = new System.Windows.Forms.Button();
            this.tabSliceControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackStretch)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(637, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Restart date";
            // 
            // boxRestart
            // 
            this.boxRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxRestart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestart.FormattingEnabled = true;
            this.boxRestart.Location = new System.Drawing.Point(640, 130);
            this.boxRestart.Name = "boxRestart";
            this.boxRestart.Size = new System.Drawing.Size(119, 21);
            this.boxRestart.TabIndex = 25;
            // 
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.glControl.Location = new System.Drawing.Point(148, 28);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(476, 467);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = true;
            // 
            // boxMaximum
            // 
            this.boxMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMaximum.Location = new System.Drawing.Point(695, 223);
            this.boxMaximum.Name = "boxMaximum";
            this.boxMaximum.Size = new System.Drawing.Size(64, 21);
            this.boxMaximum.TabIndex = 37;
            this.boxMaximum.Text = "100.000";
            // 
            // treeProperties
            // 
            this.treeProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeProperties.FullRowSelect = true;
            this.treeProperties.HideSelection = false;
            this.treeProperties.Location = new System.Drawing.Point(12, 28);
            this.treeProperties.Name = "treeProperties";
            treeNode1.Name = "Узел0";
            treeNode1.Text = "Static ";
            treeNode2.Name = "Узел1";
            treeNode2.Text = "Dynamic";
            this.treeProperties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeProperties.Size = new System.Drawing.Size(130, 198);
            this.treeProperties.TabIndex = 0;
            // 
            // boxMinimum
            // 
            this.boxMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxMinimum.Location = new System.Drawing.Point(695, 196);
            this.boxMinimum.Name = "boxMinimum";
            this.boxMinimum.Size = new System.Drawing.Size(64, 21);
            this.boxMinimum.TabIndex = 36;
            this.boxMinimum.Text = "0.000";
            // 
            // labelMax
            // 
            this.labelMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(637, 226);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(51, 13);
            this.labelMax.TabIndex = 35;
            this.labelMax.Text = "Maximum";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Properties";
            // 
            // labelMin
            // 
            this.labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(637, 199);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(47, 13);
            this.labelMin.TabIndex = 34;
            this.labelMin.Text = "Minimum";
            // 
            // boxZslice
            // 
            this.boxZslice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.boxZslice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxZslice.FormattingEnabled = true;
            this.boxZslice.Location = new System.Drawing.Point(6, 20);
            this.boxZslice.Name = "boxZslice";
            this.boxZslice.Size = new System.Drawing.Size(121, 21);
            this.boxZslice.TabIndex = 38;
            // 
            // chkShowGridLines
            // 
            this.chkShowGridLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowGridLines.AutoSize = true;
            this.chkShowGridLines.Checked = true;
            this.chkShowGridLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowGridLines.Location = new System.Drawing.Point(640, 370);
            this.chkShowGridLines.Name = "chkShowGridLines";
            this.chkShowGridLines.Size = new System.Drawing.Size(97, 17);
            this.chkShowGridLines.TabIndex = 40;
            this.chkShowGridLines.Text = "Show grid lines";
            this.chkShowGridLines.UseVisualStyleBackColor = true;
            // 
            // tabSliceControl
            // 
            this.tabSliceControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSliceControl.Controls.Add(this.tabPage1);
            this.tabSliceControl.Controls.Add(this.tabPage2);
            this.tabSliceControl.Controls.Add(this.tabPage3);
            this.tabSliceControl.Location = new System.Drawing.Point(630, 12);
            this.tabSliceControl.Name = "tabSliceControl";
            this.tabSliceControl.SelectedIndex = 0;
            this.tabSliceControl.Size = new System.Drawing.Size(142, 89);
            this.tabSliceControl.TabIndex = 41;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.boxXslice);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(134, 63);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "X(I)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // boxXslice
            // 
            this.boxXslice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.boxXslice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxXslice.FormattingEnabled = true;
            this.boxXslice.Location = new System.Drawing.Point(6, 20);
            this.boxXslice.Name = "boxXslice";
            this.boxXslice.Size = new System.Drawing.Size(121, 21);
            this.boxXslice.TabIndex = 40;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.boxYslice);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(134, 63);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Y(J)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // boxYslice
            // 
            this.boxYslice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.boxYslice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxYslice.FormattingEnabled = true;
            this.boxYslice.Location = new System.Drawing.Point(6, 20);
            this.boxYslice.Name = "boxYslice";
            this.boxYslice.Size = new System.Drawing.Size(121, 21);
            this.boxYslice.TabIndex = 39;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.boxZslice);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(134, 63);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Z(K)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(637, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Scale Z";
            // 
            // boxScaleZ
            // 
            this.boxScaleZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxScaleZ.Location = new System.Drawing.Point(695, 169);
            this.boxScaleZ.Name = "boxScaleZ";
            this.boxScaleZ.Size = new System.Drawing.Size(64, 21);
            this.boxScaleZ.TabIndex = 43;
            this.boxScaleZ.Text = "12";
            // 
            // labelPickValue
            // 
            this.labelPickValue.AutoSize = true;
            this.labelPickValue.Location = new System.Drawing.Point(145, 12);
            this.labelPickValue.Name = "labelPickValue";
            this.labelPickValue.Size = new System.Drawing.Size(103, 13);
            this.labelPickValue.TabIndex = 44;
            this.labelPickValue.Text = "Cell [0,0,0] = 0.000";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(642, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Stretch";
            // 
            // trackStretch
            // 
            this.trackStretch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackStretch.Location = new System.Drawing.Point(634, 319);
            this.trackStretch.Maximum = 100;
            this.trackStretch.Name = "trackStretch";
            this.trackStretch.Size = new System.Drawing.Size(138, 45);
            this.trackStretch.TabIndex = 46;
            this.trackStretch.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // bbColorReset
            // 
            this.bbColorReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bbColorReset.Location = new System.Drawing.Point(640, 260);
            this.bbColorReset.Name = "bbColorReset";
            this.bbColorReset.Size = new System.Drawing.Size(121, 23);
            this.bbColorReset.TabIndex = 48;
            this.bbColorReset.Text = "Reset";
            this.bbColorReset.UseVisualStyleBackColor = true;
            // 
            // Form2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 499);
            this.Controls.Add(this.bbColorReset);
            this.Controls.Add(this.trackStretch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelPickValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxScaleZ);
            this.Controls.Add(this.tabSliceControl);
            this.Controls.Add(this.chkShowGridLines);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.boxMaximum);
            this.Controls.Add(this.boxRestart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeProperties);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.boxMinimum);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form2D";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2D View";
            this.tabSliceControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackStretch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxRestart;
        private System.Windows.Forms.TextBox boxMaximum;
        private System.Windows.Forms.TreeView treeProperties;
        private System.Windows.Forms.TextBox boxMinimum;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMin;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.ComboBox boxZslice;
        private System.Windows.Forms.CheckBox chkShowGridLines;
        private System.Windows.Forms.TabControl tabSliceControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox boxXslice;
        private System.Windows.Forms.ComboBox boxYslice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox boxScaleZ;
        private System.Windows.Forms.Label labelPickValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackStretch;
        private System.Windows.Forms.Button bbColorReset;

        #endregion
    }
}