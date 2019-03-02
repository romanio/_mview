namespace mview
{
    partial class FormModels
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
            this.buttonModels = new System.Windows.Forms.Button();
            this.gridGeneral = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.boxActiveProject = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.boxNewName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonModels
            // 
            this.buttonModels.Location = new System.Drawing.Point(0, 0);
            this.buttonModels.Name = "buttonModels";
            this.buttonModels.Size = new System.Drawing.Size(103, 23);
            this.buttonModels.TabIndex = 12;
            this.buttonModels.Text = "Close";
            this.buttonModels.UseVisualStyleBackColor = true;
            this.buttonModels.Click += new System.EventHandler(this.buttonModels_Click);
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
            this.gridGeneral.Location = new System.Drawing.Point(0, 39);
            this.gridGeneral.MultiSelect = false;
            this.gridGeneral.Name = "gridGeneral";
            this.gridGeneral.ReadOnly = true;
            this.gridGeneral.RowHeadersVisible = false;
            this.gridGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridGeneral.Size = new System.Drawing.Size(396, 197);
            this.gridGeneral.TabIndex = 16;
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
            this.Column2.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Active project";
            // 
            // boxActiveProject
            // 
            this.boxActiveProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxActiveProject.FormattingEnabled = true;
            this.boxActiveProject.Location = new System.Drawing.Point(204, 2);
            this.boxActiveProject.Name = "boxActiveProject";
            this.boxActiveProject.Size = new System.Drawing.Size(83, 21);
            this.boxActiveProject.TabIndex = 18;
            this.boxActiveProject.SelectedIndexChanged += new System.EventHandler(this.boxActiveProject_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(293, 0);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(103, 23);
            this.buttonRename.TabIndex = 21;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.button1_Click);
            // 
            // boxNewName
            // 
            this.boxNewName.Location = new System.Drawing.Point(204, 2);
            this.boxNewName.Name = "boxNewName";
            this.boxNewName.Size = new System.Drawing.Size(83, 21);
            this.boxNewName.TabIndex = 22;
            this.boxNewName.Visible = false;
            // 
            // FormModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 288);
            this.Controls.Add(this.boxNewName);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.boxActiveProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridGeneral);
            this.Controls.Add(this.buttonModels);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormModels";
            this.Deactivate += new System.EventHandler(this.FormModels_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.gridGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonModels;
        private System.Windows.Forms.DataGridView gridGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxActiveProject;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.TextBox boxNewName;
    }
}