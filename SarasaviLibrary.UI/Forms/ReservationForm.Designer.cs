namespace SarasaviLibrary.UI.Forms
{
    partial class ReservationForm
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
            this.lblTitleId = new System.Windows.Forms.Label();
            this.txtTitleId = new System.Windows.Forms.TextBox();
            this.btnReserve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.lblUserNumber.AutoSize = true;
            this.lblUserNumber.Location = new System.Drawing.Point(30, 30);
            this.lblUserNumber.Name = "lblUserNumber";
            this.lblUserNumber.Size = new System.Drawing.Size(81, 15);
            this.lblUserNumber.TabIndex = 0;
            this.lblUserNumber.Text = "User Number:";
            
            this.txtUserNumber.Location = new System.Drawing.Point(120, 27);
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Size = new System.Drawing.Size(150, 23);
            this.txtUserNumber.TabIndex = 1;
            
            this.lblTitleId.AutoSize = true;
            this.lblTitleId.Location = new System.Drawing.Point(30, 70);
            this.lblTitleId.Name = "lblTitleId";
            this.lblTitleId.Size = new System.Drawing.Size(46, 15);
            this.lblTitleId.TabIndex = 2;
            this.lblTitleId.Text = "Title ID:";
            
            this.txtTitleId.Location = new System.Drawing.Point(120, 67);
            this.txtTitleId.Name = "txtTitleId";
            this.txtTitleId.Size = new System.Drawing.Size(150, 23);
            this.txtTitleId.TabIndex = 3;
            
            this.btnReserve.Location = new System.Drawing.Point(120, 110);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(100, 30);
            this.btnReserve.TabIndex = 4;
            this.btnReserve.Text = "Reserve Title";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.txtTitleId);
            this.Controls.Add(this.lblTitleId);
            this.Controls.Add(this.txtUserNumber);
            this.Controls.Add(this.lblUserNumber);
            this.Name = "ReservationForm";
            this.Text = "Reserve Title";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUserNumber;
        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Label lblTitleId;
        private System.Windows.Forms.TextBox txtTitleId;
        private System.Windows.Forms.Button btnReserve;
    }
}
