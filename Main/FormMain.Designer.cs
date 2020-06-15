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
            this.hMAssistentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossPlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dViewToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dViewToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virtualGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.bbWellFilter = new System.Windows.Forms.Button();
            this.panelNameFilter = new System.Windows.Forms.Panel();
            this.listGroups = new System.Windows.Forms.ListBox();
            this.labelMin = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.panelNameFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openModelToolStripMenuItem,
            this.hMAssistentToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionalToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(808, 24);
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
            // hMAssistentToolStripMenuItem
            // 
            this.hMAssistentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crossPlotsToolStripMenuItem});
            this.hMAssistentToolStripMenuItem.Name = "hMAssistentToolStripMenuItem";
            this.hMAssistentToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.hMAssistentToolStripMenuItem.Text = "HM Assistent";
            // 
            // crossPlotsToolStripMenuItem
            // 
            this.crossPlotsToolStripMenuItem.Name = "crossPlotsToolStripMenuItem";
            this.crossPlotsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.crossPlotsToolStripMenuItem.Text = "Show Cross-Plots";
            this.crossPlotsToolStripMenuItem.Click += new System.EventHandler(this.crossPlotsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dViewToolStripMenuItem2,
            this.dViewToolStripMenuItem3});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // dViewToolStripMenuItem2
            // 
            this.dViewToolStripMenuItem2.Name = "dViewToolStripMenuItem2";
            this.dViewToolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.dViewToolStripMenuItem2.Text = "Show 2D View";
            this.dViewToolStripMenuItem2.Click += new System.EventHandler(this.dViewToolStripMenuItem2_Click);
            // 
            // dViewToolStripMenuItem3
            // 
            this.dViewToolStripMenuItem3.Enabled = false;
            this.dViewToolStripMenuItem3.Name = "dViewToolStripMenuItem3";
            this.dViewToolStripMenuItem3.Size = new System.Drawing.Size(141, 22);
            this.dViewToolStripMenuItem3.Text = "3D View";
            // 
            // optionalToolStripMenuItem
            // 
            this.optionalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.virtualGroupsToolStripMenuItem});
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
            // virtualGroupsToolStripMenuItem
            // 
            this.virtualGroupsToolStripMenuItem.Name = "virtualGroupsToolStripMenuItem";
            this.virtualGroupsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.virtualGroupsToolStripMenuItem.Text = "Virtual Groups";
            this.virtualGroupsToolStripMenuItem.Click += new System.EventHandler(this.virtualGroupsToolStripMenuItem_Click);
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
            this.listNames.Size = new System.Drawing.Size(108, 380);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(126, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(670, 552);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 42);
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
            this.boxSetChartCount.Location = new System.Drawing.Point(301, 38);
            this.boxSetChartCount.Name = "boxSetChartCount";
            this.boxSetChartCount.Size = new System.Drawing.Size(61, 21);
            this.boxSetChartCount.TabIndex = 7;
            this.boxSetChartCount.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkSorted
            // 
            this.checkSorted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSorted.AutoSize = true;
            this.checkSorted.Location = new System.Drawing.Point(12, 463);
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
            this.label2.Location = new System.Drawing.Point(9, 492);
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
            "Completions",
            "Aquifer",
            "Region",
            "Other"});
            this.boxNamesType.Location = new System.Drawing.Point(12, 508);
            this.boxNamesType.Name = "boxNamesType";
            this.boxNamesType.Size = new System.Drawing.Size(108, 21);
            this.boxNamesType.TabIndex = 10;
            this.boxNamesType.SelectedIndexChanged += new System.EventHandler(this.boxNamesType_SelectedIndexChanged);
            // 
            // buttonModels
            // 
            this.buttonModels.Location = new System.Drawing.Point(12, 35);
            this.buttonModels.Name = "buttonModels";
            this.buttonModels.Size = new System.Drawing.Size(108, 24);
            this.buttonModels.TabIndex = 11;
            this.buttonModels.Text = "///";
            this.buttonModels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonModels.UseVisualStyleBackColor = true;
            this.buttonModels.Click += new System.EventHandler(this.buttonModelsOnClick);
            // 
            // buttonChartOptions
            // 
            this.buttonChartOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChartOptions.Location = new System.Drawing.Point(400, 36);
            this.buttonChartOptions.Name = "buttonChartOptions";
            this.buttonChartOptions.Size = new System.Drawing.Size(110, 24);
            this.buttonChartOptions.TabIndex = 12;
            this.buttonChartOptions.Text = "Chart Options";
            this.buttonChartOptions.UseVisualStyleBackColor = true;
            this.buttonChartOptions.Click += new System.EventHandler(this.buttonChartOptionsOnClick);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Location = new System.Drawing.Point(706, 35);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(90, 24);
            this.buttonUpdate.TabIndex = 13;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdateOnClick);
            // 
            // bbWellFilter
            // 
            this.bbWellFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bbWellFilter.Location = new System.Drawing.Point(12, 596);
            this.bbWellFilter.Name = "bbWellFilter";
            this.bbWellFilter.Size = new System.Drawing.Size(108, 24);
            this.bbWellFilter.TabIndex = 14;
            this.bbWellFilter.Text = "Filtered";
            this.bbWellFilter.UseVisualStyleBackColor = true;
            this.bbWellFilter.Click += new System.EventHandler(this.bbWellFilter_Click);
            // 
            // panelNameFilter
            // 
            this.panelNameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelNameFilter.Controls.Add(this.listGroups);
            this.panelNameFilter.Controls.Add(this.labelMin);
            this.panelNameFilter.Location = new System.Drawing.Point(13, 433);
            this.panelNameFilter.Name = "panelNameFilter";
            this.panelNameFilter.Size = new System.Drawing.Size(139, 157);
            this.panelNameFilter.TabIndex = 25;
            this.panelNameFilter.Visible = false;
            // 
            // listGroups
            // 
            this.listGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listGroups.FormattingEnabled = true;
            this.listGroups.IntegralHeight = false;
            this.listGroups.Location = new System.Drawing.Point(6, 30);
            this.listGroups.Name = "listGroups";
            this.listGroups.ScrollAlwaysVisible = true;
            this.listGroups.Size = new System.Drawing.Size(120, 113);
            this.listGroups.Sorted = true;
            this.listGroups.TabIndex = 63;
            this.listGroups.SelectedIndexChanged += new System.EventHandler(this.listGroups_SelectedIndexChanged);
            // 
            // labelMin
            // 
            this.labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(3, 14);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(55, 13);
            this.labelMin.TabIndex = 62;
            this.labelMin.Text = "Group List";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(808, 653);
            this.Controls.Add(this.panelNameFilter);
            this.Controls.Add(this.bbWellFilter);
            this.Controls.Add(this.buttonUpdate);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainOnFormClosed);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panelNameFilter.ResumeLayout(false);
            this.panelNameFilter.PerformLayout();
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
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ToolStripMenuItem virtualGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hMAssistentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crossPlotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dViewToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dViewToolStripMenuItem3;
        private System.Windows.Forms.Button bbWellFilter;
        private System.Windows.Forms.Panel panelNameFilter;
        private System.Windows.Forms.ListBox listGroups;
        private System.Windows.Forms.Label labelMin;
    }
}

