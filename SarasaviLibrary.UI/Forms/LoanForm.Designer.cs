namespace SarasaviLibrary.UI.Forms
{
    partial class LoanForm
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
            this.lblUserNumber = new System.Windows.Forms.Label();
            this.txtUserNumber = new System.Windows.Forms.TextBox();
            this.lblAccessionNumber = new System.Windows.Forms.Label();
            this.txtAccessionNumber = new System.Windows.Forms.TextBox();
            this.btnPlaceLoan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.lblUserNumber.AutoSize = true;
            this.lblUserNumber.Location = new System.Drawing.Point(30, 30);
            this.lblUserNumber.Name = "lblUserNumber";
            this.lblUserNumber.Size = new System.Drawing.Size(81, 15);
            this.lblUserNumber.TabIndex = 0;
            this.lblUserNumber.Text = "User Number:";
            
            this.txtUserNumber.Location = new System.Drawing.Point(150, 27);
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Size = new System.Drawing.Size(150, 23);
            this.txtUserNumber.TabIndex = 1;
            
            this.lblAccessionNumber.AutoSize = true;
            this.lblAccessionNumber.Location = new System.Drawing.Point(30, 70);
            this.lblAccessionNumber.Name = "lblAccessionNumber";
            this.lblAccessionNumber.Size = new System.Drawing.Size(109, 15);
            this.lblAccessionNumber.TabIndex = 2;
            this.lblAccessionNumber.Text = "Accession Number:";
            
            this.txtAccessionNumber.Location = new System.Drawing.Point(150, 67);
            this.txtAccessionNumber.Name = "txtAccessionNumber";
            this.txtAccessionNumber.Size = new System.Drawing.Size(150, 23);
            this.txtAccessionNumber.TabIndex = 3;
            
            this.btnPlaceLoan.Location = new System.Drawing.Point(150, 110);
            this.btnPlaceLoan.Name = "btnPlaceLoan";
            this.btnPlaceLoan.Size = new System.Drawing.Size(100, 30);
            this.btnPlaceLoan.TabIndex = 4;
            this.btnPlaceLoan.Text = "Place Loan";
            this.btnPlaceLoan.UseVisualStyleBackColor = true;
            this.btnPlaceLoan.Click += new System.EventHandler(this.btnPlaceLoan_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 180);
            this.Controls.Add(this.btnPlaceLoan);
            this.Controls.Add(this.txtAccessionNumber);
            this.Controls.Add(this.lblAccessionNumber);
            this.Controls.Add(this.txtUserNumber);
            this.Controls.Add(this.lblUserNumber);
            this.Name = "LoanForm";
            this.Text = "Place Loan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUserNumber;
        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Label lblAccessionNumber;
        private System.Windows.Forms.TextBox txtAccessionNumber;
        private System.Windows.Forms.Button btnPlaceLoan;
    }
}
