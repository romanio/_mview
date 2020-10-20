namespace mview
{
    partial class Form3D
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
            this.glControl = new OpenTK.GLControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabSliceControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boxXSlice = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.boxYSlice = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.boxZSlice = new System.Windows.Forms.ComboBox();
            this.boxRestart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.treeProperties = new System.Windows.Forms.TreeView();
            this.bbWellModel = new System.Windows.Forms.Button();
            this.bbSetFocusOn = new System.Windows.Forms.Button();
            this.lbCellValue = new System.Windows.Forms.Label();
            this.bbChartOptions = new System.Windows.Forms.Button();
            this.bbShowFilter = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabSliceControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(177, 44);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(785, 619);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControlOnLoad);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControlOnPaint);
            this.glControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControlOnMouseClick);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControlOnMouseMove);
            this.glControl.Resize += new System.EventHandler(this.glControlOnResize);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 666);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(294, 17);
            this.toolStripStatusLabel1.Text = "Use Right Mouse Button to Rotate and Middle Button to Pan";
            // 
            // tabSliceControl
            // 
            this.tabSliceControl.Controls.Add(this.tabPage1);
            this.tabSliceControl.Controls.Add(this.tabPage2);
            this.tabSliceControl.Controls.Add(this.tabPage3);
            this.tabSliceControl.Location = new System.Drawing.Point(12, 12);
            this.tabSliceControl.Name = "tabSliceControl";
            this.tabSliceControl.SelectedIndex = 0;
            this.tabSliceControl.Size = new System.Drawing.Size(159, 89);
            this.tabSliceControl.TabIndex = 42;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.boxXSlice);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(151, 63);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "X(I)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // boxXSlice
            // 
            this.boxXSlice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.boxXSlice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxXSlice.FormattingEnabled = true;
            this.boxXSlice.Location = new System.Drawing.Point(14, 20);
            this.boxXSlice.Name = "boxXSlice";
            this.boxXSlice.Size = new System.Drawing.Size(127, 21);
            this.boxXSlice.TabIndex = 40;
            this.boxXSlice.SelectedIndexChanged += new System.EventHandler(this.boxXSlice_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.boxYSlice);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(151, 63);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Y(J)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // boxYSlice
            // 
            this.boxYSlice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.boxYSlice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxYSlice.FormattingEnabled = true;
            this.boxYSlice.Location = new System.Drawing.Point(14, 20);
            this.boxYSlice.Name = "boxYSlice";
            this.boxYSlice.Size = new System.Drawing.Size(127, 21);
            this.boxYSlice.TabIndex = 39;
            this.boxYSlice.SelectedIndexChanged += new System.EventHandler(this.boxYSlice_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.boxZSlice);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(151, 63);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Z(K)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // boxZSlice
            // 
            this.boxZSlice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.boxZSlice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxZSlice.FormattingEnabled = true;
            this.boxZSlice.Location = new System.Drawing.Point(14, 20);
            this.boxZSlice.Name = "boxZSlice";
            this.boxZSlice.Size = new System.Drawing.Size(127, 21);
            this.boxZSlice.TabIndex = 38;
            this.boxZSlice.SelectedIndexChanged += new System.EventHandler(this.boxZSlice_SelectedIndexChanged);
            // 
            // boxRestart
            // 
            this.boxRestart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestart.FormattingEnabled = true;
            this.boxRestart.Location = new System.Drawing.Point(16, 131);
            this.boxRestart.Name = "boxRestart";
            this.boxRestart.Size = new System.Drawing.Size(150, 21);
            this.boxRestart.TabIndex = 45;
            this.boxRestart.SelectedIndexChanged += new System.EventHandler(this.BoxRestartOnSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Restart date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Properties";
            // 
            // treeProperties
            // 
            this.treeProperties.FullRowSelect = true;
            this.treeProperties.HideSelection = false;
            this.treeProperties.Location = new System.Drawing.Point(16, 185);
            this.treeProperties.Name = "treeProperties";
            treeNode1.Name = "Узел0";
            treeNode1.Text = "Static ";
            treeNode2.Name = "Узел1";
            treeNode2.Text = "Dynamic";
            this.treeProperties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeProperties.Size = new System.Drawing.Size(150, 372);
            this.treeProperties.TabIndex = 43;
            this.treeProperties.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreePropertiesOnAfterSelect);
            // 
            // bbWellModel
            // 
            this.bbWellModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbWellModel.Location = new System.Drawing.Point(844, 12);
            this.bbWellModel.Name = "bbWellModel";
            this.bbWellModel.Size = new System.Drawing.Size(118, 26);
            this.bbWellModel.TabIndex = 58;
            this.bbWellModel.Text = "Well Model";
            this.bbWellModel.UseVisualStyleBackColor = true;
            // 
            // bbSetFocusOn
            // 
            this.bbSetFocusOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbSetFocusOn.Location = new System.Drawing.Point(472, 12);
            this.bbSetFocusOn.Name = "bbSetFocusOn";
            this.bbSetFocusOn.Size = new System.Drawing.Size(118, 26);
            this.bbSetFocusOn.TabIndex = 57;
            this.bbSetFocusOn.Text = "Set Focus On";
            this.bbSetFocusOn.UseVisualStyleBackColor = true;
            // 
            // lbCellValue
            // 
            this.lbCellValue.AutoSize = true;
            this.lbCellValue.Location = new System.Drawing.Point(181, 19);
            this.lbCellValue.Name = "lbCellValue";
            this.lbCellValue.Size = new System.Drawing.Size(106, 13);
            this.lbCellValue.TabIndex = 56;
            this.lbCellValue.Text = "Cell[-1;-1;-1]=0.000";
            // 
            // bbChartOptions
            // 
            this.bbChartOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbChartOptions.Location = new System.Drawing.Point(596, 12);
            this.bbChartOptions.Name = "bbChartOptions";
            this.bbChartOptions.Size = new System.Drawing.Size(118, 26);
            this.bbChartOptions.TabIndex = 54;
            this.bbChartOptions.Text = "Options";
            this.bbChartOptions.UseVisualStyleBackColor = true;
            // 
            // bbShowFilter
            // 
            this.bbShowFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbShowFilter.Location = new System.Drawing.Point(720, 12);
            this.bbShowFilter.Name = "bbShowFilter";
            this.bbShowFilter.Size = new System.Drawing.Size(118, 26);
            this.bbShowFilter.TabIndex = 55;
            this.bbShowFilter.Text = "Filter [ON]";
            this.bbShowFilter.UseVisualStyleBackColor = true;
            this.bbShowFilter.Click += new System.EventHandler(this.bbShowFilterOnClick);
            // 
            // Form3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 688);
            this.Controls.Add(this.bbWellModel);
            this.Controls.Add(this.bbSetFocusOn);
            this.Controls.Add(this.lbCellValue);
            this.Controls.Add(this.bbChartOptions);
            this.Controls.Add(this.bbShowFilter);
            this.Controls.Add(this.boxRestart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeProperties);
            this.Controls.Add(this.tabSliceControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.glControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form3D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show 3D";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabSliceControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabSliceControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox boxXSlice;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox boxYSlice;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox boxZSlice;
        private System.Windows.Forms.ComboBox boxRestart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeProperties;
        private System.Windows.Forms.Button bbWellModel;
        private System.Windows.Forms.Button bbSetFocusOn;
        private System.Windows.Forms.Label lbCellValue;
        private System.Windows.Forms.Button bbChartOptions;
        private System.Windows.Forms.Button bbShowFilter;
    }
}