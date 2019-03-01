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
            this.checkedModelList = new System.Windows.Forms.CheckedListBox();
            this.gridGeneral = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // checkedModelList
            // 
            this.checkedModelList.FormattingEnabled = true;
            this.checkedModelList.Items.AddRange(new object[] {
            "hi",
            "my",
            "pay",
            "poo"});
            this.checkedModelList.Location = new System.Drawing.Point(12, 39);
            this.checkedModelList.Name = "checkedModelList";
            this.checkedModelList.Size = new System.Drawing.Size(114, 212);
            this.checkedModelList.TabIndex = 13;
            this.checkedModelList.SelectedIndexChanged += new System.EventHandler(this.checkedModelList_SelectedIndexChanged);
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
            this.gridGeneral.Location = new System.Drawing.Point(132, 39);
            this.gridGeneral.Name = "gridGeneral";
            this.gridGeneral.ReadOnly = true;
            this.gridGeneral.RowHeadersVisible = false;
            this.gridGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGeneral.Size = new System.Drawing.Size(410, 212);
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
            this.Column2.ReadOnly = true;
            this.Column2.Width = 300;
            // 
            // FormModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 281);
            this.Controls.Add(this.gridGeneral);
            this.Controls.Add(this.checkedModelList);
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

        }

        #endregion

        private System.Windows.Forms.Button buttonModels;
        private System.Windows.Forms.CheckedListBox checkedModelList;
        private System.Windows.Forms.DataGridView gridGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}