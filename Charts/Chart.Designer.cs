namespace mview
{
    partial class Chart
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
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listKeywords = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotView1
            // 
            this.plotView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotView1.Location = new System.Drawing.Point(6, 6);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(315, 367);
            this.plotView1.TabIndex = 0;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNWSE;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 405);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listKeywords);
            this.tabPage1.Controls.Add(this.plotView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(451, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listKeywords
            // 
            this.listKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listKeywords.FormattingEnabled = true;
            this.listKeywords.IntegralHeight = false;
            this.listKeywords.Location = new System.Drawing.Point(327, 6);
            this.listKeywords.Name = "listKeywords";
            this.listKeywords.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listKeywords.Size = new System.Drawing.Size(118, 367);
            this.listKeywords.Sorted = true;
            this.listKeywords.TabIndex = 1;
            this.listKeywords.SelectedIndexChanged += new System.EventHandler(this.listKeywords_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridData);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(451, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Location = new System.Drawing.Point(6, 6);
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            this.gridData.RowTemplate.Height = 18;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridData.Size = new System.Drawing.Size(439, 367);
            this.gridData.TabIndex = 1;
            this.gridData.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridData_CellValueNeeded);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.plotView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(451, 379);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SpecOps";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // plotView2
            // 
            this.plotView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotView2.Location = new System.Drawing.Point(3, 3);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(445, 373);
            this.plotView2.TabIndex = 1;
            this.plotView2.Text = "plotView2";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNWSE;
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Chart";
            this.Size = new System.Drawing.Size(465, 411);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listKeywords;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.TabPage tabPage3;
        private OxyPlot.WindowsForms.PlotView plotView2;
    }
}
