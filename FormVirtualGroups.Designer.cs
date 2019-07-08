namespace mview
{
    partial class FormVirtualGroups
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
            this.bbLoadGroups = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelMin = new System.Windows.Forms.Label();
            this.listGroups = new System.Windows.Forms.ListBox();
            this.listWells = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bbLoadGroups
            // 
            this.bbLoadGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbLoadGroups.Location = new System.Drawing.Point(12, 43);
            this.bbLoadGroups.Name = "bbLoadGroups";
            this.bbLoadGroups.Size = new System.Drawing.Size(127, 27);
            this.bbLoadGroups.TabIndex = 31;
            this.bbLoadGroups.Text = "Load Groups";
            this.bbLoadGroups.UseVisualStyleBackColor = true;
            this.bbLoadGroups.Click += new System.EventHandler(this.bbLoadGroups_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(12, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 27);
            this.button2.TabIndex = 33;
            this.button2.Text = "Remove All Groups";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(162, 22);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(55, 13);
            this.labelMin.TabIndex = 60;
            this.labelMin.Text = "Group List";
            // 
            // listGroups
            // 
            this.listGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listGroups.FormattingEnabled = true;
            this.listGroups.IntegralHeight = false;
            this.listGroups.Location = new System.Drawing.Point(165, 43);
            this.listGroups.Name = "listGroups";
            this.listGroups.ScrollAlwaysVisible = true;
            this.listGroups.Size = new System.Drawing.Size(120, 305);
            this.listGroups.Sorted = true;
            this.listGroups.TabIndex = 61;
            this.listGroups.SelectedIndexChanged += new System.EventHandler(this.listGroups_SelectedIndexChanged);
            // 
            // listWells
            // 
            this.listWells.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listWells.FormattingEnabled = true;
            this.listWells.HorizontalScrollbar = true;
            this.listWells.IntegralHeight = false;
            this.listWells.Location = new System.Drawing.Point(307, 44);
            this.listWells.Name = "listWells";
            this.listWells.Size = new System.Drawing.Size(111, 305);
            this.listWells.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Wells in Group";
            // 
            // FormVirtualGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 373);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listWells);
            this.Controls.Add(this.listGroups);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bbLoadGroups);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVirtualGroups";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Groups";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bbLoadGroups;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.ListBox listGroups;
        private System.Windows.Forms.ListBox listWells;
        private System.Windows.Forms.Label label1;
    }
}