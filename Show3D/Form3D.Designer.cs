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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Static ");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Dynamic");
            this.glControl = new OpenTK.GLControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.boxRestart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.treeProperties = new System.Windows.Forms.TreeView();
            this.bbWellModel = new System.Windows.Forms.Button();
            this.bbSetFocusOn = new System.Windows.Forms.Button();
            this.lbCellValue = new System.Windows.Forms.Label();
            this.bbChartOptions = new System.Windows.Forms.Button();
            this.buttonShowFilter = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(159, 44);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(803, 619);
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
            // boxRestart
            // 
            this.boxRestart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestart.FormattingEnabled = true;
            this.boxRestart.Location = new System.Drawing.Point(15, 44);
            this.boxRestart.Name = "boxRestart";
            this.boxRestart.Size = new System.Drawing.Size(127, 21);
            this.boxRestart.TabIndex = 45;
            this.boxRestart.SelectedIndexChanged += new System.EventHandler(this.BoxRestartOnSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Restart date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Properties";
            // 
            // treeProperties
            // 
            this.treeProperties.FullRowSelect = true;
            this.treeProperties.HideSelection = false;
            this.treeProperties.Location = new System.Drawing.Point(12, 95);
            this.treeProperties.Name = "treeProperties";
            treeNode7.Name = "Узел0";
            treeNode7.Text = "Static ";
            treeNode8.Name = "Узел1";
            treeNode8.Text = "Dynamic";
            this.treeProperties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.treeProperties.Size = new System.Drawing.Size(130, 372);
            this.treeProperties.TabIndex = 43;
            this.treeProperties.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreePropertiesOnAfterSelect);
            // 
            // bbWellModel
            // 
            this.bbWellModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbWellModel.Location = new System.Drawing.Point(720, 12);
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
            this.lbCellValue.Location = new System.Drawing.Point(856, 19);
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
            // buttonShowFilter
            // 
            this.buttonShowFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowFilter.Location = new System.Drawing.Point(348, 12);
            this.buttonShowFilter.Name = "buttonShowFilter";
            this.buttonShowFilter.Size = new System.Drawing.Size(118, 25);
            this.buttonShowFilter.TabIndex = 55;
            this.buttonShowFilter.Text = "Filter [ON]";
            this.buttonShowFilter.UseVisualStyleBackColor = true;
            this.buttonShowFilter.Click += new System.EventHandler(this.ButtonShowFilterOnClick);
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
            this.Controls.Add(this.buttonShowFilter);
            this.Controls.Add(this.boxRestart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeProperties);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.glControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form3D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show 3D";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox boxRestart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeProperties;
        private System.Windows.Forms.Button bbWellModel;
        private System.Windows.Forms.Button bbSetFocusOn;
        private System.Windows.Forms.Label lbCellValue;
        private System.Windows.Forms.Button bbChartOptions;
        private System.Windows.Forms.Button buttonShowFilter;
    }
}