namespace SarasaviLibrary.UI.Forms
{
    partial class LoanForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader          = new System.Windows.Forms.Panel();
            this.lblTitle           = new System.Windows.Forms.Label();
            this.lblSubtitle        = new System.Windows.Forms.Label();
            this.pnlBody            = new System.Windows.Forms.Panel();
            this.lblUserNumber      = new System.Windows.Forms.Label();
            this.lblUserNumberHint  = new System.Windows.Forms.Label();
            this.txtUserNumber      = new System.Windows.Forms.TextBox();
            this.lblAccessionNumber = new System.Windows.Forms.Label();
            this.lblAccessionHint   = new System.Windows.Forms.Label();
            this.txtAccessionNumber = new System.Windows.Forms.TextBox();
            this.pnlInfo            = new System.Windows.Forms.Panel();
            this.lblInfoText        = new System.Windows.Forms.Label();
            this.btnPlaceLoan       = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();

            // ── Header ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 80;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Text      = "📖  Book Loan";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(18, 12);
            this.lblTitle.Size      = new System.Drawing.Size(400, 30);
            this.lblTitle.AutoSize  = false;

            this.lblSubtitle.Text      = "Issue a book copy to a registered borrower";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(20, 46);
            this.lblSubtitle.Size      = new System.Drawing.Size(400, 18);
            this.lblSubtitle.AutoSize  = false;

            // ── Info Box ────────────────────────────────────────────────
            this.pnlInfo.BackColor  = System.Drawing.Color.FromArgb(219, 234, 254);
            this.pnlInfo.Location   = new System.Drawing.Point(25, 20);
            this.pnlInfo.Size       = new System.Drawing.Size(390, 56);
            this.pnlInfo.Controls.Add(this.lblInfoText);

            this.lblInfoText.Text      = "ℹ  Max 5 active loans per borrower. Loans with overdue books\r\n    cannot borrow further. Loan period: 14 days.";
            this.lblInfoText.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblInfoText.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblInfoText.Location  = new System.Drawing.Point(8, 8);
            this.lblInfoText.Size      = new System.Drawing.Size(374, 40);
            this.lblInfoText.AutoSize  = false;

            // ── Body ────────────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Controls.Add(this.btnPlaceLoan);
            this.pnlBody.Controls.Add(this.txtAccessionNumber);
            this.pnlBody.Controls.Add(this.lblAccessionHint);
            this.pnlBody.Controls.Add(this.lblAccessionNumber);
            this.pnlBody.Controls.Add(this.txtUserNumber);
            this.pnlBody.Controls.Add(this.lblUserNumberHint);
            this.pnlBody.Controls.Add(this.lblUserNumber);
            this.pnlBody.Controls.Add(this.pnlInfo);

            // User Number
            this.lblUserNumber.AutoSize  = false;
            this.lblUserNumber.Text      = "User Number  *";
            this.lblUserNumber.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserNumber.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblUserNumber.Location  = new System.Drawing.Point(25, 92);
            this.lblUserNumber.Size      = new System.Drawing.Size(390, 18);

            this.lblUserNumberHint.AutoSize  = false;
            this.lblUserNumberHint.Text      = "The number displayed after borrower registration (e.g. 1001)";
            this.lblUserNumberHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblUserNumberHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUserNumberHint.Location  = new System.Drawing.Point(25, 112);
            this.lblUserNumberHint.Size      = new System.Drawing.Size(390, 16);

            this.txtUserNumber.Name        = "txtUserNumber";
            this.txtUserNumber.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserNumber.Location    = new System.Drawing.Point(25, 130);
            this.txtUserNumber.Size        = new System.Drawing.Size(390, 26);
            this.txtUserNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserNumber.TabIndex    = 1;

            // Accession Number
            this.lblAccessionNumber.AutoSize  = false;
            this.lblAccessionNumber.Text      = "Book Accession Number  *";
            this.lblAccessionNumber.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccessionNumber.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblAccessionNumber.Location  = new System.Drawing.Point(25, 172);
            this.lblAccessionNumber.Size      = new System.Drawing.Size(390, 18);

            this.lblAccessionHint.AutoSize  = false;
            this.lblAccessionHint.Text      = "The unique copy code printed on the book (e.g. F0001-01). Found via Book Inquiry.";
            this.lblAccessionHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblAccessionHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblAccessionHint.Location  = new System.Drawing.Point(25, 192);
            this.lblAccessionHint.Size      = new System.Drawing.Size(390, 16);

            this.txtAccessionNumber.Name        = "txtAccessionNumber";
            this.txtAccessionNumber.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAccessionNumber.Location    = new System.Drawing.Point(25, 210);
            this.txtAccessionNumber.Size        = new System.Drawing.Size(390, 26);
            this.txtAccessionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccessionNumber.TabIndex    = 2;

            // Button
            this.btnPlaceLoan.Name             = "btnPlaceLoan";
            this.btnPlaceLoan.Text             = "Place Loan";
            this.btnPlaceLoan.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPlaceLoan.BackColor        = System.Drawing.Color.FromArgb(30, 58, 138);
            this.btnPlaceLoan.ForeColor        = System.Drawing.Color.White;
            this.btnPlaceLoan.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceLoan.FlatAppearance.BorderSize = 0;
            this.btnPlaceLoan.Location         = new System.Drawing.Point(25, 256);
            this.btnPlaceLoan.Size             = new System.Drawing.Size(390, 38);
            this.btnPlaceLoan.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnPlaceLoan.Click           += new System.EventHandler(this.btnPlaceLoan_Click);

            // ── Form ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(440, 390);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Book Loan";
            this.BackColor           = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblSubtitle;
        private System.Windows.Forms.Panel   pnlBody;
        private System.Windows.Forms.Panel   pnlInfo;
        private System.Windows.Forms.Label   lblInfoText;
        private System.Windows.Forms.Label   lblUserNumber;
        private System.Windows.Forms.Label   lblUserNumberHint;
        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Label   lblAccessionNumber;
        private System.Windows.Forms.Label   lblAccessionHint;
        private System.Windows.Forms.TextBox txtAccessionNumber;
        private System.Windows.Forms.Button  btnPlaceLoan;
    }
}
