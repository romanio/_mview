namespace mview
{
    partial class SubWellModel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.MaxColorDefault = new System.Windows.Forms.Button();
            this.MinColorDefault = new System.Windows.Forms.Button();
            this.boxMaximum = new System.Windows.Forms.TextBox();
            this.boxMinimum = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.numericZScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackStratch = new System.Windows.Forms.TrackBar();
            this.checkShowAllWell = new System.Windows.Forms.CheckBox();
            this.checkShowGridLines = new System.Windows.Forms.CheckBox();
            this.checkShowBubbles = new System.Windows.Forms.CheckBox();
            this.boxBubbleMode = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.numericScaleFactor = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkNoFillColor = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listWells = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gridCommon = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.boxChartMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericZScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScaleFactor)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommon)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotView
            // 
            this.plotView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.Location = new System.Drawing.Point(129, 38);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(305, 568);
            this.plotView.TabIndex = 72;
            this.plotView.Text = "plotHisto";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNWSE;
            // 
            // MaxColorDefault
            // 
            this.MaxColorDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaxColorDefault.Location = new System.Drawing.Point(154, 79);
            this.MaxColorDefault.Name = "MaxColorDefault";
            this.MaxColorDefault.Size = new System.Drawing.Size(24, 21);
            this.MaxColorDefault.TabIndex = 71;
            this.MaxColorDefault.Text = "D";
            this.MaxColorDefault.UseVisualStyleBackColor = true;
            // 
            // MinColorDefault
            // 
            this.MinColorDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinColorDefault.Location = new System.Drawing.Point(154, 46);
            this.MinColorDefault.Name = "MinColorDefault";
            this.MinColorDefault.Size = new System.Drawing.Size(24, 22);
            this.MinColorDefault.TabIndex = 70;
            this.MinColorDefault.Text = "D";
            this.MinColorDefault.UseVisualStyleBackColor = true;
            // 
            // boxMaximum
            // 
            this.boxMaximum.Location = new System.Drawing.Point(72, 79);
            this.boxMaximum.Name = "boxMaximum";
            this.boxMaximum.Size = new System.Drawing.Size(76, 21);
            this.boxMaximum.TabIndex = 67;
            this.boxMaximum.Text = "1.0";
            this.boxMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // boxMinimum
            // 
            this.boxMinimum.Location = new System.Drawing.Point(72, 47);
            this.boxMinimum.Name = "boxMinimum";
            this.boxMinimum.Size = new System.Drawing.Size(76, 21);
            this.boxMinimum.TabIndex = 66;
            this.boxMinimum.Text = "0.0";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(18, 82);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(51, 13);
            this.labelMax.TabIndex = 69;
            this.labelMax.Text = "Maximum";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(19, 50);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(47, 13);
            this.labelMin.TabIndex = 68;
            this.labelMin.Text = "Minimum";
            // 
            // numericZScale
            // 
            this.numericZScale.Location = new System.Drawing.Point(198, 164);
            this.numericZScale.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericZScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericZScale.Name = "numericZScale";
            this.numericZScale.Size = new System.Drawing.Size(64, 21);
            this.numericZScale.TabIndex = 70;
            this.numericZScale.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Z Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Stretch factor";
            // 
            // trackStratch
            // 
            this.trackStratch.BackColor = System.Drawing.SystemColors.Window;
            this.trackStratch.Location = new System.Drawing.Point(106, 277);
            this.trackStratch.Maximum = 100;
            this.trackStratch.Name = "trackStratch";
            this.trackStratch.Size = new System.Drawing.Size(178, 45);
            this.trackStratch.TabIndex = 66;
            this.trackStratch.TickFrequency = 4;
            this.trackStratch.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // checkShowAllWell
            // 
            this.checkShowAllWell.AutoSize = true;
            this.checkShowAllWell.Checked = true;
            this.checkShowAllWell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowAllWell.Location = new System.Drawing.Point(20, 206);
            this.checkShowAllWell.Name = "checkShowAllWell";
            this.checkShowAllWell.Size = new System.Drawing.Size(113, 17);
            this.checkShowAllWell.TabIndex = 64;
            this.checkShowAllWell.Text = "Show all well track";
            this.checkShowAllWell.UseVisualStyleBackColor = true;
            // 
            // checkShowGridLines
            // 
            this.checkShowGridLines.AutoSize = true;
            this.checkShowGridLines.Checked = true;
            this.checkShowGridLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowGridLines.Location = new System.Drawing.Point(20, 165);
            this.checkShowGridLines.Name = "checkShowGridLines";
            this.checkShowGridLines.Size = new System.Drawing.Size(97, 17);
            this.checkShowGridLines.TabIndex = 63;
            this.checkShowGridLines.Text = "Show grid lines";
            this.checkShowGridLines.UseVisualStyleBackColor = true;
            // 
            // checkShowBubbles
            // 
            this.checkShowBubbles.AutoSize = true;
            this.checkShowBubbles.Checked = true;
            this.checkShowBubbles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowBubbles.Location = new System.Drawing.Point(21, 353);
            this.checkShowBubbles.Name = "checkShowBubbles";
            this.checkShowBubbles.Size = new System.Drawing.Size(92, 17);
            this.checkShowBubbles.TabIndex = 56;
            this.checkShowBubbles.Text = "Show bubbles";
            this.checkShowBubbles.UseVisualStyleBackColor = true;
            // 
            // boxBubbleMode
            // 
            this.boxBubbleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxBubbleMode.FormattingEnabled = true;
            this.boxBubbleMode.IntegralHeight = false;
            this.boxBubbleMode.Items.AddRange(new object[] {
            "Simulation",
            "History"});
            this.boxBubbleMode.Location = new System.Drawing.Point(15, 498);
            this.boxBubbleMode.Name = "boxBubbleMode";
            this.boxBubbleMode.Size = new System.Drawing.Size(106, 21);
            this.boxBubbleMode.TabIndex = 58;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 388);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 13);
            this.label21.TabIndex = 57;
            this.label21.Text = "Bubble map mode";
            // 
            // numericScaleFactor
            // 
            this.numericScaleFactor.Location = new System.Drawing.Point(126, 429);
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
            this.numericScaleFactor.TabIndex = 59;
            this.numericScaleFactor.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 429);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 60;
            this.label22.Text = "Scale factor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Colors";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Grid";
            // 
            // checkNoFillColor
            // 
            this.checkNoFillColor.AutoSize = true;
            this.checkNoFillColor.Checked = true;
            this.checkNoFillColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNoFillColor.Location = new System.Drawing.Point(20, 242);
            this.checkNoFillColor.Name = "checkNoFillColor";
            this.checkNoFillColor.Size = new System.Drawing.Size(82, 17);
            this.checkNoFillColor.TabIndex = 71;
            this.checkNoFillColor.Text = "No Fill Color";
            this.checkNoFillColor.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(20, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Bubbles";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(22, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 529);
            this.tabControl1.TabIndex = 75;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MaxColorDefault);
            this.tabPage1.Controls.Add(this.checkShowBubbles);
            this.tabPage1.Controls.Add(this.boxMinimum);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.labelMax);
            this.tabPage1.Controls.Add(this.boxMaximum);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.trackStratch);
            this.tabPage1.Controls.Add(this.numericScaleFactor);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.labelMin);
            this.tabPage1.Controls.Add(this.MinColorDefault);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.checkShowGridLines);
            this.tabPage1.Controls.Add(this.numericZScale);
            this.tabPage1.Controls.Add(this.checkShowAllWell);
            this.tabPage1.Controls.Add(this.checkNoFillColor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grid Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(377, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistic";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listWells
            // 
            this.listWells.FormattingEnabled = true;
            this.listWells.Location = new System.Drawing.Point(12, 38);
            this.listWells.Name = "listWells";
            this.listWells.Size = new System.Drawing.Size(108, 420);
            this.listWells.Sorted = true;
            this.listWells.TabIndex = 79;
            this.listWells.SelectedIndexChanged += new System.EventHandler(this.listWells_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "Wells";
            // 
            // gridCommon
            // 
            this.gridCommon.AllowUserToAddRows = false;
            this.gridCommon.AllowUserToDeleteRows = false;
            this.gridCommon.AllowUserToResizeRows = false;
            this.gridCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCommon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCommon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCommon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.gridCommon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridCommon.Location = new System.Drawing.Point(6, 7);
            this.gridCommon.MultiSelect = false;
            this.gridCommon.Name = "gridCommon";
            this.gridCommon.ReadOnly = true;
            this.gridCommon.RowHeadersVisible = false;
            this.gridCommon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridCommon.Size = new System.Drawing.Size(305, 500);
            this.gridCommon.TabIndex = 81;
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
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(522, 38);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(325, 539);
            this.tabControl2.TabIndex = 82;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gridCommon);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(317, 513);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Common";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gridData);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(317, 513);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Completions";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column8,
            this.Column9,
            this.Column10});
            this.gridData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridData.Location = new System.Drawing.Point(6, 6);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersVisible = false;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridData.Size = new System.Drawing.Size(380, 921);
            this.gridData.TabIndex = 83;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn1.HeaderText = "I";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 36;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn2.HeaderText = "J";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 37;
            // 
            // Column3
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column3.HeaderText = "K";
            this.Column3.Name = "Column3";
            this.Column3.Width = 38;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Depth";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 61;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "KH";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 45;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 73;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "CF";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 45;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "complex";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 71;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "s38";
            this.Column9.Name = "Column9";
            this.Column9.Width = 49;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Hw";
            this.Column10.Name = "Column10";
            this.Column10.Width = 47;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tabControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(484, 513);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // boxChartMode
            // 
            this.boxChartMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxChartMode.FormattingEnabled = true;
            this.boxChartMode.IntegralHeight = false;
            this.boxChartMode.Items.AddRange(new object[] {
            "Pressure",
            "Pressure Normalized",
            "Liquid Production",
            "Oil Production",
            "Water Production",
            "Water Cut",
            "Connection Factor"});
            this.boxChartMode.Location = new System.Drawing.Point(195, 11);
            this.boxChartMode.Name = "boxChartMode";
            this.boxChartMode.Size = new System.Drawing.Size(139, 21);
            this.boxChartMode.TabIndex = 83;
            this.boxChartMode.SelectedIndexChanged += new System.EventHandler(this.boxChartMode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 84;
            this.label7.Text = "Chart Mode";
            // 
            // SubWellModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 618);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.boxChartMode);
            this.Controls.Add(this.plotView);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.listWells);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.boxBubbleMode);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubWellModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2D Well Model";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubFormOptions_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericZScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScaleFactor)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCommon)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button MaxColorDefault;
        private System.Windows.Forms.Button MinColorDefault;
        public System.Windows.Forms.TextBox boxMaximum;
        public System.Windows.Forms.TextBox boxMinimum;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMin;
        private OxyPlot.WindowsForms.PlotView plotView;
        public System.Windows.Forms.CheckBox checkShowAllWell;
        public System.Windows.Forms.CheckBox checkShowGridLines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackStratch;
        public System.Windows.Forms.CheckBox checkShowBubbles;
        public System.Windows.Forms.ComboBox boxBubbleMode;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.NumericUpDown numericScaleFactor;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericZScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox checkNoFillColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListBox listWells;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gridCommon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        public System.Windows.Forms.ComboBox boxChartMode;
        private System.Windows.Forms.Label label7;
    }
}