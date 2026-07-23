namespace SarasaviLibrary.UI.Forms
{
    partial class ReturnForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAccessionNumber = new System.Windows.Forms.Label();
            this.txtAccessionNumber = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.lblAccessionNumber.AutoSize = true;
            this.lblAccessionNumber.Location = new System.Drawing.Point(30, 30);
            this.lblAccessionNumber.Name = "lblAccessionNumber";
            this.lblAccessionNumber.Size = new System.Drawing.Size(109, 15);
            this.lblAccessionNumber.TabIndex = 0;
            this.lblAccessionNumber.Text = "Accession Number:";
            
            this.txtAccessionNumber.Location = new System.Drawing.Point(150, 27);
            this.txtAccessionNumber.Name = "txtAccessionNumber";
            this.txtAccessionNumber.Size = new System.Drawing.Size(150, 23);
            this.txtAccessionNumber.TabIndex = 1;
            
            this.btnReturn.Location = new System.Drawing.Point(150, 70);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 30);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "Return Book";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 140);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.txtAccessionNumber);
            this.Controls.Add(this.lblAccessionNumber);
            this.Name = "ReturnForm";
            this.Text = "Return Book";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblAccessionNumber;
        private System.Windows.Forms.TextBox txtAccessionNumber;
        private System.Windows.Forms.Button btnReturn;
    }
}
