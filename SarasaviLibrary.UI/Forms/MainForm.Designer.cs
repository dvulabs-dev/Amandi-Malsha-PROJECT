namespace SarasaviLibrary.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Declare all controls ────────────────────────────────────
            this.pnlSidebar          = new System.Windows.Forms.Panel();
            this.pnlLogo             = new System.Windows.Forms.Panel();
            this.lblLibraryName      = new System.Windows.Forms.Label();
            this.lblLibrarySub       = new System.Windows.Forms.Label();
            this.pnlNavContainer     = new System.Windows.Forms.Panel();
            this.pnlNavBottom        = new System.Windows.Forms.Panel();
            this.lblNavSectionReg    = new System.Windows.Forms.Label();
            this.lblNavSectionTrans  = new System.Windows.Forms.Label();
            this.btnNavDashboard     = new System.Windows.Forms.Button();
            this.btnNavRegisterUser  = new System.Windows.Forms.Button();
            this.btnNavRegisterBook  = new System.Windows.Forms.Button();
            this.btnNavLoan          = new System.Windows.Forms.Button();
            this.btnNavReturn        = new System.Windows.Forms.Button();
            this.btnNavReserve       = new System.Windows.Forms.Button();
            this.btnNavInquiry       = new System.Windows.Forms.Button();
            this.btnNavExit          = new System.Windows.Forms.Button();
            this.pnlMain             = new System.Windows.Forms.Panel();
            this.pnlTopBar           = new System.Windows.Forms.Panel();
            this.lblPageTitle        = new System.Windows.Forms.Label();
            this.lblDateTime         = new System.Windows.Forms.Label();
            this.pnlContent          = new System.Windows.Forms.Panel();
            this.pnlWelcomeBanner    = new System.Windows.Forms.Panel();
            this.lblWelcome          = new System.Windows.Forms.Label();
            this.lblWelcomeSubtitle  = new System.Windows.Forms.Label();
            this.flpStats            = new System.Windows.Forms.FlowLayoutPanel();
            // ── New table controls ───────────────────────────────────────
            this.tlpTables           = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBorrowersSection = new System.Windows.Forms.Panel();
            this.lblBorrowersHeader  = new System.Windows.Forms.Label();
            this.dgvBorrowers        = new System.Windows.Forms.DataGridView();
            this.pnlBooksSection     = new System.Windows.Forms.Panel();
            this.lblBooksHeader      = new System.Windows.Forms.Label();
            this.dgvBooks            = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════
            // SIDEBAR
            // ══════════════════════════════════════════════════════════════
            this.pnlSidebar.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width     = 232;
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlSidebar.Controls.Add(this.pnlNavContainer);
            this.pnlSidebar.Controls.Add(this.pnlNavBottom);
            this.pnlSidebar.Controls.Add(this.pnlLogo);

            // Logo
            this.pnlLogo.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Height    = 88;
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(15, 38, 92);
            this.pnlLogo.Controls.Add(this.lblLibraryName);
            this.pnlLogo.Controls.Add(this.lblLibrarySub);

            this.lblLibraryName.AutoSize  = false;
            this.lblLibraryName.Text      = "📚  SARASAVI";
            this.lblLibraryName.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLibraryName.ForeColor = System.Drawing.Color.White;
            this.lblLibraryName.Location  = new System.Drawing.Point(14, 16);
            this.lblLibraryName.Size      = new System.Drawing.Size(204, 30);

            this.lblLibrarySub.AutoSize  = false;
            this.lblLibrarySub.Text      = "Library Management System";
            this.lblLibrarySub.Font      = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLibrarySub.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLibrarySub.Location  = new System.Drawing.Point(14, 50);
            this.lblLibrarySub.Size      = new System.Drawing.Size(204, 18);

            // Exit bottom panel
            this.pnlNavBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavBottom.Height    = 54;
            this.pnlNavBottom.BackColor = System.Drawing.Color.FromArgb(15, 38, 92);
            this.pnlNavBottom.Controls.Add(this.btnNavExit);

            this.btnNavExit.Dock                              = System.Windows.Forms.DockStyle.Fill;
            this.btnNavExit.Text                              = "   🚪   Exit System";
            this.btnNavExit.TextAlign                         = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavExit.Font                              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavExit.ForeColor                         = System.Drawing.Color.FromArgb(252, 165, 165);
            this.btnNavExit.BackColor                         = System.Drawing.Color.FromArgb(15, 38, 92);
            this.btnNavExit.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavExit.FlatAppearance.BorderSize         = 0;
            this.btnNavExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(127, 29, 29);
            this.btnNavExit.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnNavExit.Click += new System.EventHandler(this.btnNavExit_Click);

            // Nav container
            this.pnlNavContainer.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavContainer.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlNavContainer.Controls.Add(this.btnNavInquiry);
            this.pnlNavContainer.Controls.Add(this.btnNavReserve);
            this.pnlNavContainer.Controls.Add(this.btnNavReturn);
            this.pnlNavContainer.Controls.Add(this.btnNavLoan);
            this.pnlNavContainer.Controls.Add(this.lblNavSectionTrans);
            this.pnlNavContainer.Controls.Add(this.btnNavRegisterBook);
            this.pnlNavContainer.Controls.Add(this.btnNavRegisterUser);
            this.pnlNavContainer.Controls.Add(this.lblNavSectionReg);
            this.pnlNavContainer.Controls.Add(this.btnNavDashboard);

            void StyleNav(System.Windows.Forms.Button btn, string text, int y, System.EventHandler handler)
            {
                btn.Text      = text;
                btn.Location  = new System.Drawing.Point(0, y);
                btn.Size      = new System.Drawing.Size(232, 44);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
                btn.ForeColor = System.Drawing.Color.FromArgb(165, 180, 252);
                btn.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize            = 0;
                btn.FlatAppearance.MouseOverBackColor    = System.Drawing.Color.FromArgb(49, 78, 168);
                btn.Cursor    = System.Windows.Forms.Cursors.Hand;
                btn.Click    += handler;
            }
            void StyleSection(System.Windows.Forms.Label lbl, string text, int y)
            {
                lbl.AutoSize  = false;
                lbl.Text      = text;
                lbl.Font      = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.FromArgb(99, 130, 190);
                lbl.Location  = new System.Drawing.Point(16, y);
                lbl.Size      = new System.Drawing.Size(200, 20);
            }

            StyleNav(this.btnNavDashboard,    "   🏠   Dashboard",          8,   this.btnNavDashboard_Click);
            StyleSection(this.lblNavSectionReg, "REGISTRATION",              60);
            StyleNav(this.btnNavRegisterUser, "   👤   Register Borrower",   82,  this.btnNavRegisterUser_Click);
            StyleNav(this.btnNavRegisterBook, "   📗   Register Book",        126, this.btnNavRegisterBook_Click);
            StyleSection(this.lblNavSectionTrans, "TRANSACTIONS",             178);
            StyleNav(this.btnNavLoan,         "   📖   Loan Book",            198, this.btnNavLoan_Click);
            StyleNav(this.btnNavReturn,       "   ↩   Return Book",           242, this.btnNavReturn_Click);
            StyleNav(this.btnNavReserve,      "   🔖   Reserve Book",         286, this.btnNavReserve_Click);
            StyleNav(this.btnNavInquiry,      "   🔍   Book Inquiry",         330, this.btnNavInquiry_Click);

            // ══════════════════════════════════════════════════════════════
            // MAIN AREA
            // ══════════════════════════════════════════════════════════════
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlTopBar);

            // Top bar
            this.pnlTopBar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height    = 52;
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblDateTime);
            this.pnlTopBar.Controls.Add(this.lblPageTitle);

            this.lblPageTitle.Dock      = System.Windows.Forms.DockStyle.Left;
            this.lblPageTitle.Width     = 320;
            this.lblPageTitle.Text      = "  📊   Dashboard";
            this.lblPageTitle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPageTitle.Padding   = new System.Windows.Forms.Padding(10, 0, 0, 0);

            this.lblDateTime.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblDateTime.Text      = "";
            this.lblDateTime.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDateTime.Padding   = new System.Windows.Forms.Padding(0, 0, 20, 0);

            // ── Content area ─────────────────────────────────────────────
            // Add in reverse visual order: Fill → Top (welcome is topmost so added last)
            this.pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlContent.Controls.Add(this.tlpTables);       // Fill — remaining space
            this.pnlContent.Controls.Add(this.flpStats);         // Top — below welcome
            this.pnlContent.Controls.Add(this.pnlWelcomeBanner); // Top — very top

            // Welcome banner
            this.pnlWelcomeBanner.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlWelcomeBanner.Height    = 100;
            this.pnlWelcomeBanner.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlWelcomeBanner.Padding   = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.pnlWelcomeBanner.Controls.Add(this.lblWelcomeSubtitle);
            this.pnlWelcomeBanner.Controls.Add(this.lblWelcome);

            this.lblWelcome.AutoSize  = false;
            this.lblWelcome.Text      = "Welcome to Sarasavi Library  👋";
            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location  = new System.Drawing.Point(30, 18);
            this.lblWelcome.Size      = new System.Drawing.Size(900, 36);

            this.lblWelcomeSubtitle.AutoSize  = false;
            this.lblWelcomeSubtitle.Text      = "";
            this.lblWelcomeSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblWelcomeSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblWelcomeSubtitle.Location  = new System.Drawing.Point(30, 60);
            this.lblWelcomeSubtitle.Size      = new System.Drawing.Size(900, 24);

            // Stats row (fixed height — Top docked)
            this.flpStats.Dock          = System.Windows.Forms.DockStyle.Top;
            this.flpStats.Height        = 160;
            this.flpStats.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpStats.WrapContents  = false;
            this.flpStats.AutoScroll    = false;
            this.flpStats.Padding       = new System.Windows.Forms.Padding(16, 14, 16, 0);
            this.flpStats.BackColor     = System.Drawing.Color.FromArgb(241, 245, 249);

            // ──────────────────────────────────────────────────────────────
            // TABLE AREA — splits into Borrowers (left) | Books (right)
            // ──────────────────────────────────────────────────────────────
            this.tlpTables.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.tlpTables.ColumnCount = 2;
            this.tlpTables.RowCount    = 1;
            this.tlpTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTables.Padding     = new System.Windows.Forms.Padding(14, 10, 14, 12);
            this.tlpTables.BackColor   = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tlpTables.Controls.Add(this.pnlBorrowersSection, 0, 0);
            this.tlpTables.Controls.Add(this.pnlBooksSection, 1, 0);

            // ── Borrowers section ────────────────────────────────────────
            this.pnlBorrowersSection.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorrowersSection.Margin  = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlBorrowersSection.Controls.Add(this.dgvBorrowers);
            this.pnlBorrowersSection.Controls.Add(this.lblBorrowersHeader);

            this.lblBorrowersHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblBorrowersHeader.Height    = 38;
            this.lblBorrowersHeader.Text      = "  👤   Registered Borrowers";
            this.lblBorrowersHeader.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorrowersHeader.ForeColor = System.Drawing.Color.White;
            this.lblBorrowersHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblBorrowersHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBorrowersHeader.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);

            this.dgvBorrowers.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvBorrowers.Name                  = "dgvBorrowers";
            this.dgvBorrowers.ReadOnly              = true;
            this.dgvBorrowers.AllowUserToAddRows    = false;
            this.dgvBorrowers.AllowUserToDeleteRows = false;
            this.dgvBorrowers.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowers.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowers.RowHeadersVisible     = false;
            this.dgvBorrowers.Font                  = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dgvBorrowers.BackgroundColor       = System.Drawing.Color.White;
            this.dgvBorrowers.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvBorrowers.GridColor             = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvBorrowers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 80, 160);
            this.dgvBorrowers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBorrowers.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvBorrowers.ColumnHeadersHeightSizeMode             = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowers.EnableHeadersVisualStyles               = false;
            this.dgvBorrowers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);

            // ── Books section ────────────────────────────────────────────
            this.pnlBooksSection.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlBooksSection.Margin  = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlBooksSection.Controls.Add(this.dgvBooks);
            this.pnlBooksSection.Controls.Add(this.lblBooksHeader);

            this.lblBooksHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblBooksHeader.Height    = 38;
            this.lblBooksHeader.Text      = "  📗   Registered Book Titles";
            this.lblBooksHeader.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBooksHeader.ForeColor = System.Drawing.Color.White;
            this.lblBooksHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblBooksHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBooksHeader.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);

            this.dgvBooks.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Name                  = "dgvBooks";
            this.dgvBooks.ReadOnly              = true;
            this.dgvBooks.AllowUserToAddRows    = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.RowHeadersVisible     = false;
            this.dgvBooks.Font                  = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dgvBooks.BackgroundColor       = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.GridColor             = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 80, 160);
            this.dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBooks.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvBooks.ColumnHeadersHeightSizeMode             = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.EnableHeadersVisualStyles               = false;
            this.dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 255, 245);

            // ══════════════════════════════════════════════════════════════
            // FORM
            // ══════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1200, 720);
            this.MinimumSize         = new System.Drawing.Size(960, 640);
            this.WindowState         = System.Windows.Forms.FormWindowState.Maximized;
            this.Text                = "Sarasavi Library Management System";
            this.BackColor           = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Private field declarations ────────────────────────────────────
        private System.Windows.Forms.Panel           pnlSidebar;
        private System.Windows.Forms.Panel           pnlLogo;
        private System.Windows.Forms.Label           lblLibraryName;
        private System.Windows.Forms.Label           lblLibrarySub;
        private System.Windows.Forms.Panel           pnlNavContainer;
        private System.Windows.Forms.Panel           pnlNavBottom;
        private System.Windows.Forms.Label           lblNavSectionReg;
        private System.Windows.Forms.Label           lblNavSectionTrans;
        private System.Windows.Forms.Button          btnNavDashboard;
        private System.Windows.Forms.Button          btnNavRegisterUser;
        private System.Windows.Forms.Button          btnNavRegisterBook;
        private System.Windows.Forms.Button          btnNavLoan;
        private System.Windows.Forms.Button          btnNavReturn;
        private System.Windows.Forms.Button          btnNavReserve;
        private System.Windows.Forms.Button          btnNavInquiry;
        private System.Windows.Forms.Button          btnNavExit;
        private System.Windows.Forms.Panel           pnlMain;
        private System.Windows.Forms.Panel           pnlTopBar;
        private System.Windows.Forms.Label           lblPageTitle;
        private System.Windows.Forms.Label           lblDateTime;
        private System.Windows.Forms.Panel           pnlContent;
        private System.Windows.Forms.Panel           pnlWelcomeBanner;
        private System.Windows.Forms.Label           lblWelcome;
        private System.Windows.Forms.Label           lblWelcomeSubtitle;
        private System.Windows.Forms.FlowLayoutPanel flpStats;
        private System.Windows.Forms.TableLayoutPanel tlpTables;
        private System.Windows.Forms.Panel           pnlBorrowersSection;
        private System.Windows.Forms.Label           lblBorrowersHeader;
        private System.Windows.Forms.DataGridView    dgvBorrowers;
        private System.Windows.Forms.Panel           pnlBooksSection;
        private System.Windows.Forms.Label           lblBooksHeader;
        private System.Windows.Forms.DataGridView    dgvBooks;
    }
}
