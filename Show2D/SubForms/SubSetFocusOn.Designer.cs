namespace mview
{
    partial class SubSetFocusOn
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
            this.listWells = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listWells
            // 
            this.listWells.FormattingEnabled = true;
            this.listWells.Location = new System.Drawing.Point(12, 12);
            this.listWells.Name = "listWells";
            this.listWells.Size = new System.Drawing.Size(142, 290);
            this.listWells.Sorted = true;
            this.listWells.TabIndex = 77;
            this.listWells.SelectedIndexChanged += new System.EventHandler(this.listWells_SelectedIndexChanged);
            // 
            // SubSetFocusOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 309);
            this.Controls.Add(this.listWells);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubSetFocusOn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Focus On";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubFormOptions_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ListBox listWells;
    }
}