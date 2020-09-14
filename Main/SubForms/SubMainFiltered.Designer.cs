namespace mview
{
    partial class SubMainFiltered
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
            this.listGroups = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listGroups
            // 
            this.listGroups.FormattingEnabled = true;
            this.listGroups.Location = new System.Drawing.Point(12, 12);
            this.listGroups.Name = "listGroups";
            this.listGroups.Size = new System.Drawing.Size(142, 290);
            this.listGroups.Sorted = true;
            this.listGroups.TabIndex = 77;
            this.listGroups.SelectedIndexChanged += new System.EventHandler(this.listWells_SelectedIndexChanged);
            // 
            // SubMainFiltered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 309);
            this.Controls.Add(this.listGroups);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubMainFiltered";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Groups";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubFormOptions_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ListBox listGroups;
    }
}