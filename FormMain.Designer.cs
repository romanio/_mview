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
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dViewToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dViewToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.hMAssistentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossPlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.boxNewName = new System.Windows.Forms.TextBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.boxActiveProject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridGeneral = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bbUpdate = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGeneral)).BeginInit();
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
            this.dViewToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.dViewToolStripMenuItem2.Text = "2D View";
            this.dViewToolStripMenuItem2.Click += new System.EventHandler(this.dViewToolStripMenuItem2_Click);
            // 
            // dViewToolStripMenuItem3
            // 
            this.dViewToolStripMenuItem3.Enabled = false;
            this.dViewToolStripMenuItem3.Name = "dViewToolStripMenuItem3";
            this.dViewToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.dViewToolStripMenuItem3.Text = "3D View";
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
            this.crossPlotsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.crossPlotsToolStripMenuItem.Text = "Cross-Plots";
            this.crossPlotsToolStripMenuItem.Click += new System.EventHandler(this.crossPlotsToolStripMenuItem_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.boxNewName);
            this.panel1.Controls.Add(this.buttonRename);
            this.panel1.Controls.Add(this.boxActiveProject);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.gridGeneral);
            this.panel1.Location = new System.Drawing.Point(12, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 341);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(287, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 24);
            this.button2.TabIndex = 24;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // boxNewName
            // 
            this.boxNewName.Location = new System.Drawing.Point(106, 10);
            this.boxNewName.Name = "boxNewName";
            this.boxNewName.Size = new System.Drawing.Size(163, 21);
            this.boxNewName.TabIndex = 23;
            this.boxNewName.Visible = false;
            this.boxNewName.Leave += new System.EventHandler(this.boxNewName_Leave);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(287, 7);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(100, 24);
            this.buttonRename.TabIndex = 22;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // boxActiveProject
            // 
            this.boxActiveProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxActiveProject.FormattingEnabled = true;
            this.boxActiveProject.Location = new System.Drawing.Point(106, 10);
            this.boxActiveProject.Name = "boxActiveProject";
            this.boxActiveProject.Size = new System.Drawing.Size(163, 21);
            this.boxActiveProject.TabIndex = 19;
            this.boxActiveProject.SelectedIndexChanged += new System.EventHandler(this.boxActiveProject_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Active project";
            // 
            // gridGeneral
            // 
            this.gridGeneral.AllowUserToAddRows = false;
            this.gridGeneral.AllowUserToDeleteRows = false;
            this.gridGeneral.AllowUserToResizeRows = false;
            this.gridGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.gridGeneral.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridGeneral.Location = new System.Drawing.Point(6, 53);
            this.gridGeneral.MultiSelect = false;
            this.gridGeneral.Name = "gridGeneral";
            this.gridGeneral.ReadOnly = true;
            this.gridGeneral.RowHeadersVisible = false;
            this.gridGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridGeneral.Size = new System.Drawing.Size(390, 236);
            this.gridGeneral.TabIndex = 17;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Key";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 300;
            // 
            // bbUpdate
            // 
            this.bbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbUpdate.Location = new System.Drawing.Point(707, 36);
            this.bbUpdate.Name = "bbUpdate";
            this.bbUpdate.Size = new System.Drawing.Size(100, 24);
            this.bbUpdate.TabIndex = 13;
            this.bbUpdate.Text = "Update";
            this.bbUpdate.UseVisualStyleBackColor = true;
            this.bbUpdate.Click += new System.EventHandler(this.bbUpdate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(819, 629);
            this.Controls.Add(this.bbUpdate);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGeneral)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxActiveProject;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.TextBox boxNewName;
        private System.Windows.Forms.Button bbUpdate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem virtualGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hMAssistentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crossPlotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dViewToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dViewToolStripMenuItem3;
    }
}

