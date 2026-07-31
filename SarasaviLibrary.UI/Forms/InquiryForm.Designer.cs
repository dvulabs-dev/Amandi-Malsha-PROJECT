namespace SarasaviLibrary.UI.Forms
{
    partial class InquiryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.lblTitle        = new System.Windows.Forms.Label();
            this.lblSubtitle     = new System.Windows.Forms.Label();
            this.pnlBody         = new System.Windows.Forms.Panel();

            // ── Book Search (TOP) ──
            this.pnlSearch       = new System.Windows.Forms.Panel();
            this.lblSearch       = new System.Windows.Forms.Label();
            this.txtSearch       = new System.Windows.Forms.TextBox();
            this.btnSearch       = new System.Windows.Forms.Button();
            this.lblHint         = new System.Windows.Forms.Label();
            this.dgvResults      = new System.Windows.Forms.DataGridView();

            // ── Borrower Search (BOTTOM) ──
            this.pnlBorrowerSection  = new System.Windows.Forms.Panel();
            this.pnlBorrowerHeader   = new System.Windows.Forms.Panel();
            this.lblBorrowerSectionTitle = new System.Windows.Forms.Label();
            this.pnlBorrowerSearch   = new System.Windows.Forms.Panel();
            this.lblBorrowerSearch   = new System.Windows.Forms.Label();
            this.txtBorrowerSearch   = new System.Windows.Forms.TextBox();
            this.btnBorrowerSearch   = new System.Windows.Forms.Button();
            this.lblBorrowerHint     = new System.Windows.Forms.Label();

            // Profile card
            this.pnlProfile          = new System.Windows.Forms.Panel();
            this.lblProfileName      = new System.Windows.Forms.Label();
            this.lblProfileUserNo    = new System.Windows.Forms.Label();
            this.lblProfileNid       = new System.Windows.Forms.Label();
            this.lblProfileAddress   = new System.Windows.Forms.Label();
            this.lblProfileSex       = new System.Windows.Forms.Label();
            this.lblProfileRegDate   = new System.Windows.Forms.Label();
            this.pnlStats            = new System.Windows.Forms.Panel();
            this.lblStatTotal        = new System.Windows.Forms.Label();
            this.lblStatActive       = new System.Windows.Forms.Label();
            this.lblStatOverdue      = new System.Windows.Forms.Label();

            // Loans grid
            this.dgvLoans            = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlBorrowerSection.SuspendLayout();
            this.pnlBorrowerHeader.SuspendLayout();
            this.pnlBorrowerSearch.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════════════
            // HEADER
            // ════════════════════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 72;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Text      = "Book & Borrower Inquiry";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(18, 10);
            this.lblTitle.Size      = new System.Drawing.Size(900, 28);
            this.lblTitle.AutoSize  = false;

            this.lblSubtitle.Text      = "Top: Search books by title / accession number   |   Bottom: Look up borrower by User Number or National ID";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(20, 42);
            this.lblSubtitle.Size      = new System.Drawing.Size(900, 18);
            this.lblSubtitle.AutoSize  = false;

            // ════════════════════════════════════════════════════════════
            // BOOK SEARCH — top section
            // ════════════════════════════════════════════════════════════
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(235, 240, 250);
            this.pnlSearch.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Height    = 64;
            this.pnlSearch.Controls.Add(this.lblHint);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);

            this.lblSearch.AutoSize  = false;
            this.lblSearch.Text      = "Book Search (by title, author, or accession number):";
            this.lblSearch.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblSearch.Location  = new System.Drawing.Point(14, 8);
            this.lblSearch.Size      = new System.Drawing.Size(400, 18);

            this.txtSearch.Name        = "txtSearch";
            this.txtSearch.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location    = new System.Drawing.Point(14, 28);
            this.txtSearch.Size        = new System.Drawing.Size(540, 26);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TabIndex    = 1;

            this.btnSearch.Name             = "btnSearch";
            this.btnSearch.Text             = " Search";
            this.btnSearch.Font             = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.BackColor        = System.Drawing.Color.FromArgb(30, 58, 138);
            this.btnSearch.ForeColor        = System.Drawing.Color.White;
            this.btnSearch.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Location         = new System.Drawing.Point(562, 26);
            this.btnSearch.Size             = new System.Drawing.Size(100, 28);
            this.btnSearch.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.TabIndex         = 2;
            this.btnSearch.Click           += new System.EventHandler(this.btnSearch_Click);

            this.lblHint.AutoSize  = false;
            this.lblHint.Text      = "Returns all matching copies with availability.";
            this.lblHint.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Location  = new System.Drawing.Point(672, 34);
            this.lblHint.Size      = new System.Drawing.Size(270, 16);

            // Book results grid
            this.dgvResults.Name                  = "dgvResults";
            this.dgvResults.Dock                  = System.Windows.Forms.DockStyle.Top;
            this.dgvResults.Height                = 200;
            this.dgvResults.ReadOnly              = true;
            this.dgvResults.AllowUserToAddRows    = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.RowHeadersVisible     = false;
            this.dgvResults.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvResults.BackgroundColor       = System.Drawing.Color.White;
            this.dgvResults.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.GridColor             = System.Drawing.Color.FromArgb(220, 225, 235);
            this.dgvResults.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.dgvResults.TabIndex = 3;

            // ════════════════════════════════════════════════════════════
            // BORROWER SECTION — bottom
            // ════════════════════════════════════════════════════════════

            // Section header bar
            this.pnlBorrowerHeader.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.pnlBorrowerHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlBorrowerHeader.Height    = 34;
            this.pnlBorrowerHeader.Controls.Add(this.lblBorrowerSectionTitle);

            this.lblBorrowerSectionTitle.Text      = "Borrower Lookup — search by User Number or National ID";
            this.lblBorrowerSectionTitle.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBorrowerSectionTitle.ForeColor = System.Drawing.Color.White;
            this.lblBorrowerSectionTitle.Location  = new System.Drawing.Point(12, 8);
            this.lblBorrowerSectionTitle.Size      = new System.Drawing.Size(900, 20);
            this.lblBorrowerSectionTitle.AutoSize  = false;

            // Borrower search bar
            this.pnlBorrowerSearch.BackColor = System.Drawing.Color.FromArgb(240, 253, 250);
            this.pnlBorrowerSearch.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlBorrowerSearch.Height    = 52;
            this.pnlBorrowerSearch.Controls.Add(this.lblBorrowerHint);
            this.pnlBorrowerSearch.Controls.Add(this.btnBorrowerSearch);
            this.pnlBorrowerSearch.Controls.Add(this.txtBorrowerSearch);
            this.pnlBorrowerSearch.Controls.Add(this.lblBorrowerSearch);

            this.lblBorrowerSearch.AutoSize  = false;
            this.lblBorrowerSearch.Text      = "User No / NIC:";
            this.lblBorrowerSearch.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBorrowerSearch.ForeColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.lblBorrowerSearch.Location  = new System.Drawing.Point(14, 16);
            this.lblBorrowerSearch.Size      = new System.Drawing.Size(110, 18);

            this.txtBorrowerSearch.Name        = "txtBorrowerSearch";
            this.txtBorrowerSearch.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBorrowerSearch.Location    = new System.Drawing.Point(130, 12);
            this.txtBorrowerSearch.Size        = new System.Drawing.Size(350, 26);
            this.txtBorrowerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBorrowerSearch.TabIndex    = 4;

            this.btnBorrowerSearch.Name             = "btnBorrowerSearch";
            this.btnBorrowerSearch.Text             = " Look Up";
            this.btnBorrowerSearch.Font             = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBorrowerSearch.BackColor        = System.Drawing.Color.FromArgb(15, 118, 110);
            this.btnBorrowerSearch.ForeColor        = System.Drawing.Color.White;
            this.btnBorrowerSearch.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowerSearch.FlatAppearance.BorderSize = 0;
            this.btnBorrowerSearch.Location         = new System.Drawing.Point(490, 11);
            this.btnBorrowerSearch.Size             = new System.Drawing.Size(110, 28);
            this.btnBorrowerSearch.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnBorrowerSearch.TabIndex         = 5;
            this.btnBorrowerSearch.Click           += new System.EventHandler(this.btnBorrowerSearch_Click);

            this.lblBorrowerHint.AutoSize  = false;
            this.lblBorrowerHint.Text      = "e.g. 1001  or  200156789V";
            this.lblBorrowerHint.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblBorrowerHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBorrowerHint.Location  = new System.Drawing.Point(612, 18);
            this.lblBorrowerHint.Size      = new System.Drawing.Size(250, 16);

            // ── Profile card ─────────────────────────────────────────────
            this.pnlProfile.BackColor   = System.Drawing.Color.White;
            this.pnlProfile.Dock        = System.Windows.Forms.DockStyle.Top;
            this.pnlProfile.Height      = 90;
            this.pnlProfile.Visible     = false;
            this.pnlProfile.Padding     = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.pnlProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Left column — name + NIC + address
            this.lblProfileName.Text      = "";
            this.lblProfileName.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProfileName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblProfileName.Location  = new System.Drawing.Point(14, 8);
            this.lblProfileName.Size      = new System.Drawing.Size(380, 22);
            this.lblProfileName.AutoSize  = false;

            this.lblProfileUserNo.Text      = "";
            this.lblProfileUserNo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProfileUserNo.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblProfileUserNo.Location  = new System.Drawing.Point(14, 32);
            this.lblProfileUserNo.Size      = new System.Drawing.Size(380, 17);
            this.lblProfileUserNo.AutoSize  = false;

            this.lblProfileNid.Text      = "";
            this.lblProfileNid.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProfileNid.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblProfileNid.Location  = new System.Drawing.Point(14, 50);
            this.lblProfileNid.Size      = new System.Drawing.Size(380, 17);
            this.lblProfileNid.AutoSize  = false;

            this.lblProfileAddress.Text      = "";
            this.lblProfileAddress.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProfileAddress.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblProfileAddress.Location  = new System.Drawing.Point(14, 68);
            this.lblProfileAddress.Size      = new System.Drawing.Size(380, 17);
            this.lblProfileAddress.AutoSize  = false;

            // Right column — sex + reg date
            this.lblProfileSex.Text      = "";
            this.lblProfileSex.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProfileSex.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblProfileSex.Location  = new System.Drawing.Point(420, 32);
            this.lblProfileSex.Size      = new System.Drawing.Size(300, 17);
            this.lblProfileSex.AutoSize  = false;

            this.lblProfileRegDate.Text      = "";
            this.lblProfileRegDate.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProfileRegDate.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblProfileRegDate.Location  = new System.Drawing.Point(420, 50);
            this.lblProfileRegDate.Size      = new System.Drawing.Size(300, 17);
            this.lblProfileRegDate.AutoSize  = false;

            // Stats row
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(240, 253, 250);
            this.pnlStats.Location  = new System.Drawing.Point(420, 8);
            this.pnlStats.Size      = new System.Drawing.Size(500, 22);
            this.pnlStats.Controls.Add(this.lblStatTotal);
            this.pnlStats.Controls.Add(this.lblStatActive);
            this.pnlStats.Controls.Add(this.lblStatOverdue);

            this.lblStatTotal.Text      = "";
            this.lblStatTotal.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblStatTotal.Location  = new System.Drawing.Point(0, 3);
            this.lblStatTotal.Size      = new System.Drawing.Size(120, 16);
            this.lblStatTotal.AutoSize  = false;

            this.lblStatActive.Text      = "";
            this.lblStatActive.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatActive.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblStatActive.Location  = new System.Drawing.Point(130, 3);
            this.lblStatActive.Size      = new System.Drawing.Size(140, 16);
            this.lblStatActive.AutoSize  = false;

            this.lblStatOverdue.Text      = "";
            this.lblStatOverdue.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatOverdue.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.lblStatOverdue.Location  = new System.Drawing.Point(280, 3);
            this.lblStatOverdue.Size      = new System.Drawing.Size(180, 16);
            this.lblStatOverdue.AutoSize  = false;

            this.pnlProfile.Controls.Add(this.lblProfileName);
            this.pnlProfile.Controls.Add(this.lblProfileUserNo);
            this.pnlProfile.Controls.Add(this.lblProfileNid);
            this.pnlProfile.Controls.Add(this.lblProfileAddress);
            this.pnlProfile.Controls.Add(this.lblProfileSex);
            this.pnlProfile.Controls.Add(this.lblProfileRegDate);
            this.pnlProfile.Controls.Add(this.pnlStats);

            // ── Loans grid ───────────────────────────────────────────────
            this.dgvLoans.Name                  = "dgvLoans";
            this.dgvLoans.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoans.ReadOnly              = true;
            this.dgvLoans.AllowUserToAddRows    = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoans.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.RowHeadersVisible     = false;
            this.dgvLoans.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvLoans.BackgroundColor       = System.Drawing.Color.White;
            this.dgvLoans.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvLoans.GridColor             = System.Drawing.Color.FromArgb(220, 225, 235);
            this.dgvLoans.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.dgvLoans.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLoans.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvLoans.EnableHeadersVisualStyles = false;
            this.dgvLoans.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 253, 250);
            this.dgvLoans.Visible   = false;
            this.dgvLoans.TabIndex  = 6;

            // ── Borrower section container ────────────────────────────────
            this.pnlBorrowerSection.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorrowerSection.BackColor = System.Drawing.Color.White;
            this.pnlBorrowerSection.Controls.Add(this.dgvLoans);
            this.pnlBorrowerSection.Controls.Add(this.pnlProfile);
            this.pnlBorrowerSection.Controls.Add(this.pnlBorrowerSearch);
            this.pnlBorrowerSection.Controls.Add(this.pnlBorrowerHeader);

            // ── Body (outer container) ────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Controls.Add(this.pnlBorrowerSection);
            this.pnlBody.Controls.Add(this.dgvResults);
            this.pnlBody.Controls.Add(this.pnlSearch);

            // ── Form ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(980, 660);
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Book & Borrower Inquiry";
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlBorrowerHeader.ResumeLayout(false);
            this.pnlBorrowerSearch.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlBorrowerSection.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // Field declarations
        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Label          lblSubtitle;
        private System.Windows.Forms.Panel          pnlBody;

        // Book search
        private System.Windows.Forms.Panel          pnlSearch;
        private System.Windows.Forms.Label          lblSearch;
        private System.Windows.Forms.TextBox        txtSearch;
        private System.Windows.Forms.Button         btnSearch;
        private System.Windows.Forms.Label          lblHint;
        private System.Windows.Forms.DataGridView   dgvResults;

        // Borrower search
        private System.Windows.Forms.Panel          pnlBorrowerSection;
        private System.Windows.Forms.Panel          pnlBorrowerHeader;
        private System.Windows.Forms.Label          lblBorrowerSectionTitle;
        private System.Windows.Forms.Panel          pnlBorrowerSearch;
        private System.Windows.Forms.Label          lblBorrowerSearch;
        private System.Windows.Forms.TextBox        txtBorrowerSearch;
        private System.Windows.Forms.Button         btnBorrowerSearch;
        private System.Windows.Forms.Label          lblBorrowerHint;

        // Profile card
        private System.Windows.Forms.Panel          pnlProfile;
        private System.Windows.Forms.Label          lblProfileName;
        private System.Windows.Forms.Label          lblProfileUserNo;
        private System.Windows.Forms.Label          lblProfileNid;
        private System.Windows.Forms.Label          lblProfileAddress;
        private System.Windows.Forms.Label          lblProfileSex;
        private System.Windows.Forms.Label          lblProfileRegDate;
        private System.Windows.Forms.Panel          pnlStats;
        private System.Windows.Forms.Label          lblStatTotal;
        private System.Windows.Forms.Label          lblStatActive;
        private System.Windows.Forms.Label          lblStatOverdue;

        // Loans grid
        private System.Windows.Forms.DataGridView   dgvLoans;
    }
}

