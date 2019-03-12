namespace mview
{
    partial class FormMain
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.openModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listNames = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.boxSetChartCount = new System.Windows.Forms.ComboBox();
            this.checkSorted = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boxNamesType = new System.Windows.Forms.ComboBox();
            this.buttonModels = new System.Windows.Forms.Button();
            this.buttonChartOptions = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openModelToolStripMenuItem,
            this.optionalToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(819, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // openModelToolStripMenuItem
            // 
            this.openModelToolStripMenuItem.Name = "openModelToolStripMenuItem";
            this.openModelToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.openModelToolStripMenuItem.Text = "Open model";
            this.openModelToolStripMenuItem.Click += new System.EventHandler(this.openModelToolStripMenuItem_Click);
            // 
            // optionalToolStripMenuItem
            // 
            this.optionalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem});
            this.optionalToolStripMenuItem.Name = "optionalToolStripMenuItem";
            this.optionalToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.optionalToolStripMenuItem.Text = "Optional";
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "Eclipse file|*.SMSPEC";
            // 
            // listNames
            // 
            this.listNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listNames.FormattingEnabled = true;
            this.listNames.IntegralHeight = false;
            this.listNames.Location = new System.Drawing.Point(12, 68);
            this.listNames.Name = "listNames";
            this.listNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listNames.Size = new System.Drawing.Size(100, 396);
            this.listNames.TabIndex = 3;
            this.listNames.SelectedIndexChanged += new System.EventHandler(this.listNames_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(121, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(686, 528);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Set charts count";
            // 
            // boxSetChartCount
            // 
            this.boxSetChartCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxSetChartCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSetChartCount.FormattingEnabled = true;
            this.boxSetChartCount.IntegralHeight = false;
            this.boxSetChartCount.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.boxSetChartCount.Location = new System.Drawing.Point(309, 38);
            this.boxSetChartCount.Name = "boxSetChartCount";
            this.boxSetChartCount.Size = new System.Drawing.Size(61, 21);
            this.boxSetChartCount.TabIndex = 7;
            this.boxSetChartCount.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkSorted
            // 
            this.checkSorted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSorted.AutoSize = true;
            this.checkSorted.Location = new System.Drawing.Point(12, 483);
            this.checkSorted.Name = "checkSorted";
            this.checkSorted.Size = new System.Drawing.Size(92, 17);
            this.checkSorted.TabIndex = 8;
            this.checkSorted.Text = "Sorted names";
            this.checkSorted.UseVisualStyleBackColor = true;
            this.checkSorted.CheckedChanged += new System.EventHandler(this.checkSorted_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Type";
            // 
            // boxNamesType
            // 
            this.boxNamesType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boxNamesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxNamesType.FormattingEnabled = true;
            this.boxNamesType.IntegralHeight = false;
            this.boxNamesType.Items.AddRange(new object[] {
            "Field",
            "Group",
            "Well",
            "Aquifer",
            "Region",
            "Other"});
            this.boxNamesType.Location = new System.Drawing.Point(12, 537);
            this.boxNamesType.Name = "boxNamesType";
            this.boxNamesType.Size = new System.Drawing.Size(100, 21);
            this.boxNamesType.TabIndex = 10;
            this.boxNamesType.SelectedIndexChanged += new System.EventHandler(this.boxNamesType_SelectedIndexChanged);
            // 
            // buttonModels
            // 
            this.buttonModels.Location = new System.Drawing.Point(12, 35);
            this.buttonModels.Name = "buttonModels";
            this.buttonModels.Size = new System.Drawing.Size(100, 24);
            this.buttonModels.TabIndex = 11;
            this.buttonModels.Text = "///";
            this.buttonModels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonModels.UseVisualStyleBackColor = true;
            this.buttonModels.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // buttonChartOptions
            // 
            this.buttonChartOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChartOptions.Location = new System.Drawing.Point(415, 35);
            this.buttonChartOptions.Name = "buttonChartOptions";
            this.buttonChartOptions.Size = new System.Drawing.Size(100, 24);
            this.buttonChartOptions.TabIndex = 12;
            this.buttonChartOptions.Text = "Chart Options";
            this.buttonChartOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChartOptions.UseVisualStyleBackColor = true;
            this.buttonChartOptions.Click += new System.EventHandler(this.buttonChartOptions_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(819, 629);
            this.Controls.Add(this.buttonChartOptions);
            this.Controls.Add(this.buttonModels);
            this.Controls.Add(this.boxNamesType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkSorted);
            this.Controls.Add(this.boxSetChartCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listNames);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menu;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model View";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem openModelToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.ListBox listNames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxSetChartCount;
        private System.Windows.Forms.CheckBox checkSorted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxNamesType;
        private System.Windows.Forms.Button buttonModels;
        private System.Windows.Forms.ToolStripMenuItem optionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.Button buttonChartOptions;
    }
}

