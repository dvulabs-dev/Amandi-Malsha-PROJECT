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
            this.pnlHeader  = new System.Windows.Forms.Panel();
            this.lblTitle   = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlBody    = new System.Windows.Forms.Panel();
            this.pnlSearch  = new System.Windows.Forms.Panel();
            this.lblSearch  = new System.Windows.Forms.Label();
            this.txtSearch  = new System.Windows.Forms.TextBox();
            this.btnSearch  = new System.Windows.Forms.Button();
            this.lblHint    = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();

            // ── Header ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 80;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Text      = "🔍  Book Inquiry";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(18, 12);
            this.lblTitle.Size      = new System.Drawing.Size(700, 30);
            this.lblTitle.AutoSize  = false;

            this.lblSubtitle.Text      = "Search by book number, title name, or author name";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(20, 46);
            this.lblSubtitle.Size      = new System.Drawing.Size(700, 18);
            this.lblSubtitle.AutoSize  = false;

            // ── Search Panel ─────────────────────────────────────────────
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(235, 240, 250);
            this.pnlSearch.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Height    = 68;
            this.pnlSearch.Padding   = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.pnlSearch.Controls.Add(this.lblHint);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);

            this.lblSearch.AutoSize  = false;
            this.lblSearch.Text      = "Search:";
            this.lblSearch.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblSearch.Location  = new System.Drawing.Point(14, 10);
            this.lblSearch.Size      = new System.Drawing.Size(60, 18);

            this.txtSearch.Name        = "txtSearch";
            this.txtSearch.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location    = new System.Drawing.Point(14, 30);
            this.txtSearch.Size        = new System.Drawing.Size(550, 26);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TabIndex    = 1;

            this.btnSearch.Name             = "btnSearch";
            this.btnSearch.Text             = "Search";
            this.btnSearch.Font             = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.BackColor        = System.Drawing.Color.FromArgb(30, 58, 138);
            this.btnSearch.ForeColor        = System.Drawing.Color.White;
            this.btnSearch.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Location         = new System.Drawing.Point(572, 28);
            this.btnSearch.Size             = new System.Drawing.Size(90, 28);
            this.btnSearch.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.TabIndex         = 2;
            this.btnSearch.Click           += new System.EventHandler(this.btnSearch_Click);

            this.lblHint.AutoSize  = false;
            this.lblHint.Text      = "Tip: Search returns all matching copies with full availability details.";
            this.lblHint.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHint.Location  = new System.Drawing.Point(675, 36);
            this.lblHint.Size      = new System.Drawing.Size(270, 16);

            // ── Results Grid ─────────────────────────────────────────────
            this.dgvResults.Name                  = "dgvResults";
            this.dgvResults.Dock                  = System.Windows.Forms.DockStyle.Fill;
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
            // Header styling
            this.dgvResults.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvResults.EnableHeadersVisualStyles = false;
            // Alternating row colors
            this.dgvResults.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.dgvResults.TabIndex = 3;

            // ── Body Panel ───────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Controls.Add(this.dgvResults);
            this.pnlBody.Controls.Add(this.pnlSearch);

            // ── Form ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(960, 520);
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Book Inquiry";
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel       pnlHeader;
        private System.Windows.Forms.Label       lblTitle;
        private System.Windows.Forms.Label       lblSubtitle;
        private System.Windows.Forms.Panel       pnlBody;
        private System.Windows.Forms.Panel       pnlSearch;
        private System.Windows.Forms.Label       lblSearch;
        private System.Windows.Forms.TextBox     txtSearch;
        private System.Windows.Forms.Button      btnSearch;
        private System.Windows.Forms.Label       lblHint;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}
