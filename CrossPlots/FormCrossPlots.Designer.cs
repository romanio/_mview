﻿namespace mview
{
    partial class FormCrossPlots
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.listKeywords = new System.Windows.Forms.ListBox();
            this.boxRestart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listGroups = new System.Windows.Forms.ListBox();
            this.labelMin = new System.Windows.Forms.Label();
            this.bbLoadGroups = new System.Windows.Forms.Button();
            this.bbCriteria = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.boxSecondCond = new System.Windows.Forms.TextBox();
            this.boxFirstCond = new System.Windows.Forms.TextBox();
            this.boxTypeCondition = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.plotView1.Size = new System.Drawing.Size(581, 545);
            this.plotView1.TabIndex = 1;
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
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 583);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.plotView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(593, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.plotView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Histo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // plotView2
            // 
            this.plotView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotView2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView2.Location = new System.Drawing.Point(6, 6);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(762, 545);
            this.plotView2.TabIndex = 2;
            this.plotView2.Text = "plotHisto";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNWSE;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gridData);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(774, 557);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Table";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.gridData.Location = new System.Drawing.Point(3, 3);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersVisible = false;
            this.gridData.RowTemplate.Height = 18;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridData.Size = new System.Drawing.Size(768, 551);
            this.gridData.TabIndex = 2;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Wellname";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Simulated";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "History";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Difference";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "%";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keywords";
            // 
            // listKeywords
            // 
            this.listKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listKeywords.FormattingEnabled = true;
            this.listKeywords.Items.AddRange(new object[] {
            "LPR",
            "OPR",
            "WPR",
            "GPR",
            "WIR",
            "BHP",
            "LPT",
            "OPT",
            "WPT",
            "GPT",
            "WIT"});
            this.listKeywords.Location = new System.Drawing.Point(628, 85);
            this.listKeywords.Name = "listKeywords";
            this.listKeywords.Size = new System.Drawing.Size(120, 121);
            this.listKeywords.TabIndex = 4;
            this.listKeywords.SelectedIndexChanged += new System.EventHandler(this.listKeywords_SelectedIndexChanged);
            // 
            // boxRestart
            // 
            this.boxRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxRestart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestart.FormattingEnabled = true;
            this.boxRestart.Location = new System.Drawing.Point(628, 34);
            this.boxRestart.Name = "boxRestart";
            this.boxRestart.Size = new System.Drawing.Size(120, 21);
            this.boxRestart.TabIndex = 27;
            this.boxRestart.SelectedIndexChanged += new System.EventHandler(this.boxRestart_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Date";
            // 
            // listGroups
            // 
            this.listGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGroups.FormattingEnabled = true;
            this.listGroups.IntegralHeight = false;
            this.listGroups.Location = new System.Drawing.Point(628, 276);
            this.listGroups.Name = "listGroups";
            this.listGroups.ScrollAlwaysVisible = true;
            this.listGroups.Size = new System.Drawing.Size(120, 242);
            this.listGroups.Sorted = true;
            this.listGroups.TabIndex = 63;
            this.listGroups.SelectedIndexChanged += new System.EventHandler(this.listGroups_SelectedIndexChanged);
            // 
            // labelMin
            // 
            this.labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(625, 260);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(55, 13);
            this.labelMin.TabIndex = 62;
            this.labelMin.Text = "Group List";
            // 
            // bbLoadGroups
            // 
            this.bbLoadGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bbLoadGroups.Location = new System.Drawing.Point(628, 524);
            this.bbLoadGroups.Name = "bbLoadGroups";
            this.bbLoadGroups.Size = new System.Drawing.Size(120, 27);
            this.bbLoadGroups.TabIndex = 64;
            this.bbLoadGroups.Text = "Load Groups";
            this.bbLoadGroups.UseVisualStyleBackColor = true;
            this.bbLoadGroups.Click += new System.EventHandler(this.bbLoadGroups_Click);
            // 
            // bbCriteria
            // 
            this.bbCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbCriteria.Location = new System.Drawing.Point(628, 218);
            this.bbCriteria.Name = "bbCriteria";
            this.bbCriteria.Size = new System.Drawing.Size(120, 27);
            this.bbCriteria.TabIndex = 65;
            this.bbCriteria.Text = "Criteria";
            this.bbCriteria.UseVisualStyleBackColor = true;
            this.bbCriteria.Click += new System.EventHandler(this.bbCriteria_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.boxSecondCond);
            this.panel1.Controls.Add(this.boxFirstCond);
            this.panel1.Controls.Add(this.boxTypeCondition);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(515, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 194);
            this.panel1.TabIndex = 66;
            this.panel1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type";
            // 
            // boxSecondCond
            // 
            this.boxSecondCond.Location = new System.Drawing.Point(128, 102);
            this.boxSecondCond.Name = "boxSecondCond";
            this.boxSecondCond.Size = new System.Drawing.Size(94, 21);
            this.boxSecondCond.TabIndex = 5;
            this.boxSecondCond.Text = "20";
            this.boxSecondCond.Validating += new System.ComponentModel.CancelEventHandler(this.boxSecondCond_Validating);
            // 
            // boxFirstCond
            // 
            this.boxFirstCond.Location = new System.Drawing.Point(128, 69);
            this.boxFirstCond.Name = "boxFirstCond";
            this.boxFirstCond.Size = new System.Drawing.Size(94, 21);
            this.boxFirstCond.TabIndex = 4;
            this.boxFirstCond.Text = "10";
            this.boxFirstCond.Validating += new System.ComponentModel.CancelEventHandler(this.boxFirstCond_Validating);
            // 
            // boxTypeCondition
            // 
            this.boxTypeCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxTypeCondition.FormattingEnabled = true;
            this.boxTypeCondition.Items.AddRange(new object[] {
            "Relative",
            "Absolute"});
            this.boxTypeCondition.Location = new System.Drawing.Point(128, 32);
            this.boxTypeCondition.Name = "boxTypeCondition";
            this.boxTypeCondition.Size = new System.Drawing.Size(94, 21);
            this.boxTypeCondition.TabIndex = 3;
            this.boxTypeCondition.SelectedIndexChanged += new System.EventHandler(this.boxTypeCondition_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Second condition";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "First condition";
            // 
            // FormCrossPlots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 607);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bbCriteria);
            this.Controls.Add(this.bbLoadGroups);
            this.Controls.Add(this.listGroups);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.boxRestart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listKeywords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FormCrossPlots";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HM Cross Plots";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listKeywords;
        private System.Windows.Forms.ComboBox boxRestart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private OxyPlot.WindowsForms.PlotView plotView2;
        private System.Windows.Forms.ListBox listGroups;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Button bbLoadGroups;
        private System.Windows.Forms.Button bbCriteria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox boxTypeCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxSecondCond;
        private System.Windows.Forms.TextBox boxFirstCond;
        private System.Windows.Forms.Label label3;
    }
}