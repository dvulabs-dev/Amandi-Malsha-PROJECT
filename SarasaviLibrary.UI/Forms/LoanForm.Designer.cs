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
            this.btnCheck           = new System.Windows.Forms.Button();

            this.pnlDivider         = new System.Windows.Forms.Panel();

            this.pnlStatus          = new System.Windows.Forms.Panel();
            this.lblStatusHeader    = new System.Windows.Forms.Label();
            this.lblBorrowerIcon    = new System.Windows.Forms.Label();
            this.lblBorrowerName    = new System.Windows.Forms.Label();
            this.lblLoansRow        = new System.Windows.Forms.Label();
            this.lblOverdueRow      = new System.Windows.Forms.Label();
            this.lblBookIcon        = new System.Windows.Forms.Label();
            this.lblBookTitle       = new System.Windows.Forms.Label();
            this.lblBookStatus      = new System.Windows.Forms.Label();

            this.pnlResult          = new System.Windows.Forms.Panel();
            this.lblResultText      = new System.Windows.Forms.Label();

            this.btnAccept          = new System.Windows.Forms.Button();
            this.btnCancel          = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.SuspendLayout();

            // ── Header ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 72;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Text      = "📖  Book Loan";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(16, 10);
            this.lblTitle.Size      = new System.Drawing.Size(420, 28);
            this.lblTitle.AutoSize  = false;

            this.lblSubtitle.Text      = "Step 1 – Check Status  |  Step 2 – Accept or Cancel";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(18, 42);
            this.lblSubtitle.Size      = new System.Drawing.Size(420, 18);
            this.lblSubtitle.AutoSize  = false;

            // ── Body ─────────────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;

            int lx = 22, fw = 416;

            // User Number
            this.lblUserNumber.AutoSize  = false;
            this.lblUserNumber.Text      = "User Number  *";
            this.lblUserNumber.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserNumber.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblUserNumber.Location  = new System.Drawing.Point(lx, 14);
            this.lblUserNumber.Size      = new System.Drawing.Size(fw, 17);

            this.lblUserNumberHint.AutoSize  = false;
            this.lblUserNumberHint.Text      = "e.g. 1001  (shown at borrower registration)";
            this.lblUserNumberHint.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblUserNumberHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUserNumberHint.Location  = new System.Drawing.Point(lx, 32);
            this.lblUserNumberHint.Size      = new System.Drawing.Size(fw, 15);

            this.txtUserNumber.Name        = "txtUserNumber";
            this.txtUserNumber.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserNumber.Location    = new System.Drawing.Point(lx, 48);
            this.txtUserNumber.Size        = new System.Drawing.Size(fw, 26);
            this.txtUserNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserNumber.TabIndex    = 1;

            // Accession Number
            this.lblAccessionNumber.AutoSize  = false;
            this.lblAccessionNumber.Text      = "Book Accession Number  *";
            this.lblAccessionNumber.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccessionNumber.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblAccessionNumber.Location  = new System.Drawing.Point(lx, 84);
            this.lblAccessionNumber.Size      = new System.Drawing.Size(fw, 17);

            this.lblAccessionHint.AutoSize  = false;
            this.lblAccessionHint.Text      = "e.g. F0001-01  (copy sticker on the physical book)";
            this.lblAccessionHint.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblAccessionHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblAccessionHint.Location  = new System.Drawing.Point(lx, 102);
            this.lblAccessionHint.Size      = new System.Drawing.Size(fw, 15);

            this.txtAccessionNumber.Name        = "txtAccessionNumber";
            this.txtAccessionNumber.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAccessionNumber.Location    = new System.Drawing.Point(lx, 118);
            this.txtAccessionNumber.Size        = new System.Drawing.Size(fw, 26);
            this.txtAccessionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccessionNumber.TabIndex    = 2;

            // Check button
            this.btnCheck.Name             = "btnCheck";
            this.btnCheck.Text             = "🔍  Check Status";
            this.btnCheck.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheck.BackColor        = System.Drawing.Color.FromArgb(30, 58, 138);
            this.btnCheck.ForeColor        = System.Drawing.Color.White;
            this.btnCheck.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.Location         = new System.Drawing.Point(lx, 154);
            this.btnCheck.Size             = new System.Drawing.Size(fw, 34);
            this.btnCheck.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.TabIndex         = 3;
            this.btnCheck.Click           += new System.EventHandler(this.btnCheck_Click);

            // Divider
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(220, 225, 235);
            this.pnlDivider.Location  = new System.Drawing.Point(lx, 196);
            this.pnlDivider.Size      = new System.Drawing.Size(fw, 1);

            // ── Status Panel ─────────────────────────────────────────────
            this.pnlStatus.BackColor   = System.Drawing.Color.White;
            this.pnlStatus.Location    = new System.Drawing.Point(lx, 204);
            this.pnlStatus.Size        = new System.Drawing.Size(fw, 148);
            this.pnlStatus.Visible     = false;
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblStatusHeader.Text      = "STATUS CHECK";
            this.lblStatusHeader.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatusHeader.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStatusHeader.Location  = new System.Drawing.Point(10, 7);
            this.lblStatusHeader.Size      = new System.Drawing.Size(390, 15);
            this.lblStatusHeader.AutoSize  = false;

            this.lblBorrowerIcon.Text     = "👤";
            this.lblBorrowerIcon.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBorrowerIcon.Location = new System.Drawing.Point(8, 25);
            this.lblBorrowerIcon.Size     = new System.Drawing.Size(28, 20);
            this.lblBorrowerIcon.AutoSize = false;

            this.lblBorrowerName.Text      = "—";
            this.lblBorrowerName.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorrowerName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblBorrowerName.Location  = new System.Drawing.Point(38, 27);
            this.lblBorrowerName.Size      = new System.Drawing.Size(370, 18);
            this.lblBorrowerName.AutoSize  = false;

            this.lblLoansRow.Text      = "Active Loans:  —";
            this.lblLoansRow.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoansRow.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblLoansRow.Location  = new System.Drawing.Point(38, 47);
            this.lblLoansRow.Size      = new System.Drawing.Size(370, 16);
            this.lblLoansRow.AutoSize  = false;

            this.lblOverdueRow.Text      = "Overdue Books:  —";
            this.lblOverdueRow.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOverdueRow.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblOverdueRow.Location  = new System.Drawing.Point(38, 65);
            this.lblOverdueRow.Size      = new System.Drawing.Size(370, 16);
            this.lblOverdueRow.AutoSize  = false;

            this.lblBookIcon.Text     = "📗";
            this.lblBookIcon.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBookIcon.Location = new System.Drawing.Point(8, 86);
            this.lblBookIcon.Size     = new System.Drawing.Size(28, 20);
            this.lblBookIcon.AutoSize = false;

            this.lblBookTitle.Text      = "—";
            this.lblBookTitle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblBookTitle.Location  = new System.Drawing.Point(38, 88);
            this.lblBookTitle.Size      = new System.Drawing.Size(370, 18);
            this.lblBookTitle.AutoSize  = false;

            this.lblBookStatus.Text      = "Copy Status:  —";
            this.lblBookStatus.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBookStatus.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblBookStatus.Location  = new System.Drawing.Point(38, 108);
            this.lblBookStatus.Size      = new System.Drawing.Size(370, 16);
            this.lblBookStatus.AutoSize  = false;

            this.pnlStatus.Controls.Add(this.lblStatusHeader);
            this.pnlStatus.Controls.Add(this.lblBorrowerIcon);
            this.pnlStatus.Controls.Add(this.lblBorrowerName);
            this.pnlStatus.Controls.Add(this.lblLoansRow);
            this.pnlStatus.Controls.Add(this.lblOverdueRow);
            this.pnlStatus.Controls.Add(this.lblBookIcon);
            this.pnlStatus.Controls.Add(this.lblBookTitle);
            this.pnlStatus.Controls.Add(this.lblBookStatus);

            // ── Result Banner ─────────────────────────────────────────────
            this.pnlResult.Location  = new System.Drawing.Point(lx, 358);
            this.pnlResult.Size      = new System.Drawing.Size(fw, 34);
            this.pnlResult.Visible   = false;
            this.pnlResult.Controls.Add(this.lblResultText);

            this.lblResultText.Text      = string.Empty;
            this.lblResultText.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblResultText.Location  = new System.Drawing.Point(8, 8);
            this.lblResultText.Size      = new System.Drawing.Size(fw - 16, 18);
            this.lblResultText.AutoSize  = false;

            // ── Accept & Cancel Buttons ───────────────────────────────────
            this.btnAccept.Name             = "btnAccept";
            this.btnAccept.Text             = "✅  Accept Loan";
            this.btnAccept.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAccept.BackColor        = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnAccept.ForeColor        = System.Drawing.Color.White;
            this.btnAccept.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.Location         = new System.Drawing.Point(lx, 400);
            this.btnAccept.Size             = new System.Drawing.Size(200, 38);
            this.btnAccept.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Enabled          = false;
            this.btnAccept.Visible          = false;
            this.btnAccept.TabIndex         = 4;
            this.btnAccept.Click           += new System.EventHandler(this.btnAccept_Click);

            this.btnCancel.Name             = "btnCancel";
            this.btnCancel.Text             = "❌  Cancel";
            this.btnCancel.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.BackColor        = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnCancel.ForeColor        = System.Drawing.Color.White;
            this.btnCancel.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location         = new System.Drawing.Point(238, 400);
            this.btnCancel.Size             = new System.Drawing.Size(200, 38);
            this.btnCancel.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Enabled          = false;
            this.btnCancel.Visible          = false;
            this.btnCancel.TabIndex         = 5;
            this.btnCancel.Click           += new System.EventHandler(this.btnCancel_Click);

            // Add all controls to body
            this.pnlBody.Controls.Add(this.lblUserNumber);
            this.pnlBody.Controls.Add(this.lblUserNumberHint);
            this.pnlBody.Controls.Add(this.txtUserNumber);
            this.pnlBody.Controls.Add(this.lblAccessionNumber);
            this.pnlBody.Controls.Add(this.lblAccessionHint);
            this.pnlBody.Controls.Add(this.txtAccessionNumber);
            this.pnlBody.Controls.Add(this.btnCheck);
            this.pnlBody.Controls.Add(this.pnlDivider);
            this.pnlBody.Controls.Add(this.pnlStatus);
            this.pnlBody.Controls.Add(this.pnlResult);
            this.pnlBody.Controls.Add(this.btnAccept);
            this.pnlBody.Controls.Add(this.btnCancel);

            // ── Form ──────────────────────────────────────────────────────
            // Total height = header(72) + body elements bottom(400+38=438) + padding(16) = 526
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(460, 530);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Book Loan";
            this.BackColor           = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlResult.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblSubtitle;
        private System.Windows.Forms.Panel   pnlBody;
        private System.Windows.Forms.Label   lblUserNumber;
        private System.Windows.Forms.Label   lblUserNumberHint;
        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Label   lblAccessionNumber;
        private System.Windows.Forms.Label   lblAccessionHint;
        private System.Windows.Forms.TextBox txtAccessionNumber;
        private System.Windows.Forms.Button  btnCheck;
        private System.Windows.Forms.Panel   pnlDivider;
        private System.Windows.Forms.Panel   pnlStatus;
        private System.Windows.Forms.Label   lblStatusHeader;
        private System.Windows.Forms.Label   lblBorrowerIcon;
        private System.Windows.Forms.Label   lblBorrowerName;
        private System.Windows.Forms.Label   lblLoansRow;
        private System.Windows.Forms.Label   lblOverdueRow;
        private System.Windows.Forms.Label   lblBookIcon;
        private System.Windows.Forms.Label   lblBookTitle;
        private System.Windows.Forms.Label   lblBookStatus;
        private System.Windows.Forms.Panel   pnlResult;
        private System.Windows.Forms.Label   lblResultText;
        private System.Windows.Forms.Button  btnAccept;
        private System.Windows.Forms.Button  btnCancel;
    }
}
