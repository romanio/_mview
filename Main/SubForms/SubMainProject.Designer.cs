namespace mview
{
    partial class SubMainProject
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
            this.button2 = new System.Windows.Forms.Button();
            this.boxNewName = new System.Windows.Forms.TextBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.boxActiveProject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridGeneral = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listboxProjectNames = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.gridGeneral)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(297, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 24);
            this.button2.TabIndex = 24;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // boxNewName
            // 
            this.boxNewName.Location = new System.Drawing.Point(121, 24);
            this.boxNewName.Name = "boxNewName";
            this.boxNewName.Size = new System.Drawing.Size(163, 21);
            this.boxNewName.TabIndex = 23;
            this.boxNewName.Visible = false;
            this.boxNewName.TextChanged += new System.EventHandler(this.boxNewName_TextChanged);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(297, 24);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(118, 24);
            this.buttonRename.TabIndex = 22;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRenameOnClick);
            // 
            // boxActiveProject
            // 
            this.boxActiveProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxActiveProject.FormattingEnabled = true;
            this.boxActiveProject.Location = new System.Drawing.Point(121, 24);
            this.boxActiveProject.Name = "boxActiveProject";
            this.boxActiveProject.Size = new System.Drawing.Size(163, 21);
            this.boxActiveProject.TabIndex = 19;
            this.boxActiveProject.SelectedIndexChanged += new System.EventHandler(this.boxActiveProjectOnSelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Active Model Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // gridGeneral
            // 
            this.gridGeneral.AllowUserToAddRows = false;
            this.gridGeneral.AllowUserToDeleteRows = false;
            this.gridGeneral.AllowUserToResizeRows = false;
            this.gridGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.gridGeneral.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridGeneral.Location = new System.Drawing.Point(6, 6);
            this.gridGeneral.MultiSelect = false;
            this.gridGeneral.Name = "gridGeneral";
            this.gridGeneral.ReadOnly = true;
            this.gridGeneral.RowHeadersVisible = false;
            this.gridGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridGeneral.Size = new System.Drawing.Size(414, 213);
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
            // listboxProjectNames
            // 
            this.listboxProjectNames.CheckOnClick = true;
            this.listboxProjectNames.FormattingEnabled = true;
            this.listboxProjectNames.IntegralHeight = false;
            this.listboxProjectNames.Items.AddRange(new object[] {
            "OLD MODEL",
            "NEW MODEL (ACTIVE)",
            "TEST MODEL",
            "BRV"});
            this.listboxProjectNames.Location = new System.Drawing.Point(123, 67);
            this.listboxProjectNames.Name = "listboxProjectNames";
            this.listboxProjectNames.Size = new System.Drawing.Size(292, 112);
            this.listboxProjectNames.TabIndex = 25;
            this.listboxProjectNames.SelectedIndexChanged += new System.EventHandler(this.listboxProjectNamesOnSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Loaded models";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 263);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonRename);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.listboxProjectNames);
            this.tabPage1.Controls.Add(this.boxNewName);
            this.tabPage1.Controls.Add(this.boxActiveProject);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Models";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridGeneral);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(426, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SubMainProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 285);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubMainProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Models ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubMainProjectOnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridGeneral)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.ComboBox boxActiveProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox boxNewName;
        private System.Windows.Forms.CheckedListBox listboxProjectNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}