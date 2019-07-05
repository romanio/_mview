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
            this.bbUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelMin = new System.Windows.Forms.Label();
            this.listGroups = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // bbUpdate
            // 
            this.bbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbUpdate.Location = new System.Drawing.Point(424, 18);
            this.bbUpdate.Name = "bbUpdate";
            this.bbUpdate.Size = new System.Drawing.Size(127, 29);
            this.bbUpdate.TabIndex = 31;
            this.bbUpdate.Text = "Load Groups";
            this.bbUpdate.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(424, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 29);
            this.button1.TabIndex = 32;
            this.button1.Text = "Save Groups";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(424, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 29);
            this.button2.TabIndex = 33;
            this.button2.Text = "Remove All Groups";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelMin
            // 
            this.labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(12, 18);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(55, 13);
            this.labelMin.TabIndex = 60;
            this.labelMin.Text = "Group List";
            // 
            // listGroups
            // 
            this.listGroups.FormattingEnabled = true;
            this.listGroups.HorizontalScrollbar = true;
            this.listGroups.IntegralHeight = false;
            this.listGroups.Location = new System.Drawing.Point(15, 43);
            this.listGroups.Name = "listGroups";
            this.listGroups.Size = new System.Drawing.Size(111, 311);
            this.listGroups.TabIndex = 61;
            // 
            // FormVirtualGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 456);
            this.Controls.Add(this.listGroups);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bbUpdate);
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
        private System.Windows.Forms.Button bbUpdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.ListBox listGroups;
    }
}