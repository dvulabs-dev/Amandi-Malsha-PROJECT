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
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════
            // SIDEBAR
            // ══════════════════════════════════════════════════════════════
            this.pnlSidebar.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width     = 232;
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(76, 91, 212);
            this.pnlSidebar.Controls.Add(this.pnlNavContainer);
            this.pnlSidebar.Controls.Add(this.pnlNavBottom);
            this.pnlSidebar.Controls.Add(this.pnlLogo);

            // Logo
            this.pnlLogo.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Height    = 88;
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(76, 91, 212);
            this.pnlLogo.Controls.Add(this.lblLibraryName);
            this.pnlLogo.Controls.Add(this.lblLibrarySub);

            this.lblLibraryName.AutoSize  = false;
            this.lblLibraryName.Text      = "SARASAVI";
            this.lblLibraryName.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLibraryName.ForeColor = System.Drawing.Color.White;
            this.lblLibraryName.Location  = new System.Drawing.Point(75, 16);
            this.lblLibraryName.Size      = new System.Drawing.Size(204, 30);

            this.lblLibrarySub.AutoSize  = false;
            this.lblLibrarySub.Text      = "Library Management System";
            this.lblLibrarySub.Font      = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLibrarySub.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLibrarySub.Location  = new System.Drawing.Point(75, 50);
            this.lblLibrarySub.Size      = new System.Drawing.Size(204, 18);

            // Exit bottom panel
            this.pnlNavBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavBottom.Height    = 54;
            this.pnlNavBottom.BackColor = System.Drawing.Color.FromArgb(76, 91, 212);
            this.pnlNavBottom.Controls.Add(this.btnNavExit);

            this.btnNavExit.Dock                              = System.Windows.Forms.DockStyle.Fill;
            this.btnNavExit.Text                              = "   🚪   Exit System";
            this.btnNavExit.TextAlign                         = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavExit.Font                              = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavExit.ForeColor                         = System.Drawing.Color.FromArgb(252, 165, 165);
            this.btnNavExit.BackColor                         = System.Drawing.Color.FromArgb(76, 91, 212);
            this.btnNavExit.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavExit.FlatAppearance.BorderSize         = 0;
            this.btnNavExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(127, 29, 29);
            this.btnNavExit.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnNavExit.Click += new System.EventHandler(this.btnNavExit_Click);

            // Nav container
            this.pnlNavContainer.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavContainer.BackColor = System.Drawing.Color.FromArgb(76, 91, 212);
            this.pnlNavContainer.Controls.Add(this.btnNavInquiry);
            this.pnlNavContainer.Controls.Add(this.btnNavReserve);
            this.pnlNavContainer.Controls.Add(this.btnNavReturn);
            this.pnlNavContainer.Controls.Add(this.btnNavLoan);
            this.pnlNavContainer.Controls.Add(this.lblNavSectionTrans);
            this.pnlNavContainer.Controls.Add(this.btnNavRegisterBook);
            this.pnlNavContainer.Controls.Add(this.btnNavRegisterUser);
            this.pnlNavContainer.Controls.Add(this.lblNavSectionReg);
            this.pnlNavContainer.Controls.Add(this.btnNavDashboard);

            void StyleNav(System.Windows.Forms.Button btn, string icon, string text, int y, System.EventHandler handler)
            {
                btn.Tag       = icon + "|" + text;
                btn.Text      = text; // Will be hidden in MainForm.cs
                btn.Location  = new System.Drawing.Point(0, y);
                btn.Size      = new System.Drawing.Size(232, 44);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
                btn.ForeColor = System.Drawing.Color.FromArgb(165, 180, 252);
                btn.BackColor = System.Drawing.Color.FromArgb(76, 91, 212);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize            = 0;
                btn.FlatAppearance.MouseOverBackColor    = System.Drawing.Color.FromArgb(92, 107, 226);
                btn.Cursor    = System.Windows.Forms.Cursors.Hand;
                btn.Click    += handler;
            }
            void StyleSection(System.Windows.Forms.Label lbl, string text, int y)
            {
                lbl.AutoSize  = false;
                lbl.Text      = text;
                lbl.Font      = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.FromArgb(99, 130, 190);
                lbl.Location  = new System.Drawing.Point(85, y);
                lbl.Size      = new System.Drawing.Size(200, 20);
            }

            StyleNav(this.btnNavDashboard,    "🏠", "Dashboard",          8,   this.btnNavDashboard_Click);
            StyleSection(this.lblNavSectionReg, "REGISTRATION",              60);
            StyleNav(this.btnNavRegisterUser, "👥", "Register Borrower",   82,  this.btnNavRegisterUser_Click);
            StyleNav(this.btnNavRegisterBook, "📚", "Register Book",        126, this.btnNavRegisterBook_Click);
            StyleSection(this.lblNavSectionTrans, "TRANSACTIONS",             178);
            StyleNav(this.btnNavLoan,         "📖", "Loan Book",            198, this.btnNavLoan_Click);
            StyleNav(this.btnNavReturn,       "↩", "Return Book",           242, this.btnNavReturn_Click);
            StyleNav(this.btnNavReserve,      "🔖", "Reserve Book",         286, this.btnNavReserve_Click);
            StyleNav(this.btnNavInquiry,      "🔍", "Book Inquiry",         330, this.btnNavInquiry_Click);

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
            this.pnlContent.Controls.Add(this.flpStats);         // Top — below welcome
            this.pnlContent.Controls.Add(this.pnlWelcomeBanner); // Top — very top

            // Welcome banner
            this.pnlWelcomeBanner.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlWelcomeBanner.Height    = 100;
            this.pnlWelcomeBanner.BackColor = System.Drawing.Color.FromArgb(76, 91, 212);
            this.pnlWelcomeBanner.Padding   = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.pnlWelcomeBanner.Controls.Add(this.lblWelcomeSubtitle);
            this.pnlWelcomeBanner.Controls.Add(this.lblWelcome);

            this.lblWelcome.AutoSize  = false;
            this.lblWelcome.Text      = "Welcome to Sarasavi Library  ";
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
            
            this.flpStats.Height        = 500;
            this.flpStats.Dock          = System.Windows.Forms.DockStyle.Fill;
            this.flpStats.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpStats.WrapContents  = false;
            this.flpStats.AutoScroll    = false;
            this.flpStats.Padding       = new System.Windows.Forms.Padding(16, 14, 16, 0);
            this.flpStats.BackColor     = System.Drawing.Color.FromArgb(241, 245, 249);

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
    }
}

