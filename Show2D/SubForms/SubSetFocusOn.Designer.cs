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
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listWells
            // 
            this.listWells.FormattingEnabled = true;
            this.listWells.Location = new System.Drawing.Point(15, 28);
            this.listWells.Name = "listWells";
            this.listWells.Size = new System.Drawing.Size(134, 264);
            this.listWells.Sorted = true;
            this.listWells.TabIndex = 77;
            this.listWells.SelectedIndexChanged += new System.EventHandler(this.listWells_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Wells";
            // 
            // SubSetFocusOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 309);
            this.Controls.Add(this.listWells);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubSetFocusOn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Focus On";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubFormOptions_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox listWells;
        private System.Windows.Forms.Label label6;
    }
}