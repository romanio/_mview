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
            this.label1 = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
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
            this.checkedModelList.Size = new System.Drawing.Size(133, 68);
            this.checkedModelList.TabIndex = 13;
            this.checkedModelList.SelectedIndexChanged += new System.EventHandler(this.checkedModelList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Path";
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(171, 39);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(305, 21);
            this.textPath.TabIndex = 15;
            // 
            // FormModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 144);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedModelList);
            this.Controls.Add(this.buttonModels);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormModels";
            this.Deactivate += new System.EventHandler(this.FormModels_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonModels;
        private System.Windows.Forms.CheckedListBox checkedModelList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPath;
    }
}