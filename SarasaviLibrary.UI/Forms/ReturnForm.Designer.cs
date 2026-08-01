namespace SarasaviLibrary.UI.Forms
{
    partial class ReturnForm
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
            this.lblAccessionNumber = new System.Windows.Forms.Label();
            this.lblAccessionHint   = new System.Windows.Forms.Label();
            this.txtAccessionNumber = new System.Windows.Forms.TextBox();
            this.lblNote            = new System.Windows.Forms.Label();
            this.btnReturn          = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // ── Header ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 80;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Text      = "↩  Book Return";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(18, 12);
            this.lblTitle.Size      = new System.Drawing.Size(380, 30);
            this.lblTitle.AutoSize  = false;

            this.lblSubtitle.Text      = "Record a borrower returning a book copy";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(20, 46);
            this.lblSubtitle.Size      = new System.Drawing.Size(380, 18);
            this.lblSubtitle.AutoSize  = false;

            // ── Body ────────────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Controls.Add(this.btnReturn);
            this.pnlBody.Controls.Add(this.lblNote);
            this.pnlBody.Controls.Add(this.txtAccessionNumber);
            this.pnlBody.Controls.Add(this.lblAccessionHint);
            this.pnlBody.Controls.Add(this.lblAccessionNumber);

            this.lblAccessionNumber.AutoSize  = false;
            this.lblAccessionNumber.Text      = "Book Accession Number  *";
            this.lblAccessionNumber.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccessionNumber.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblAccessionNumber.Location  = new System.Drawing.Point(25, 30);
            this.lblAccessionNumber.Size      = new System.Drawing.Size(380, 18);

            this.lblAccessionHint.AutoSize  = false;
            this.lblAccessionHint.Text      = "Scan or type the accession number on the book (e.g. F0001-01)";
            this.lblAccessionHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblAccessionHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblAccessionHint.Location  = new System.Drawing.Point(25, 50);
            this.lblAccessionHint.Size      = new System.Drawing.Size(380, 16);

            this.txtAccessionNumber.Name        = "txtAccessionNumber";
            this.txtAccessionNumber.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAccessionNumber.Location    = new System.Drawing.Point(25, 68);
            this.txtAccessionNumber.Size        = new System.Drawing.Size(380, 26);
            this.txtAccessionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccessionNumber.TabIndex    = 1;

            this.lblNote.AutoSize  = false;
            this.lblNote.Text      = "If the title has pending reservations, the system will\r\n   automatically notify the next borrower in the queue.";
            this.lblNote.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(30, 80, 160);
            this.lblNote.Location  = new System.Drawing.Point(25, 104);
            this.lblNote.Size      = new System.Drawing.Size(380, 38);

            this.btnReturn.Name             = "btnReturn";
            this.btnReturn.Text             = "Return Book";
            this.btnReturn.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReturn.BackColor        = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnReturn.ForeColor        = System.Drawing.Color.White;
            this.btnReturn.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.Location         = new System.Drawing.Point(25, 152);
            this.btnReturn.Size             = new System.Drawing.Size(380, 38);
            this.btnReturn.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.Click           += new System.EventHandler(this.btnReturn_Click);

            // ── Form ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(430, 285);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Book Return";
            this.BackColor           = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblSubtitle;
        private System.Windows.Forms.Panel   pnlBody;
        private System.Windows.Forms.Label   lblAccessionNumber;
        private System.Windows.Forms.Label   lblAccessionHint;
        private System.Windows.Forms.TextBox txtAccessionNumber;
        private System.Windows.Forms.Label   lblNote;
        private System.Windows.Forms.Button  btnReturn;
    }
}

