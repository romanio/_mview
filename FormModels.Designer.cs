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
            // FormModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 338);
            this.Controls.Add(this.buttonModels);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormModels";
            this.Deactivate += new System.EventHandler(this.FormModels_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonModels;
    }
}