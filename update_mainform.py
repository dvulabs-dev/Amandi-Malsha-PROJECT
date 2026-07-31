import re

path = r'D:\DVULabs\Amandi-Malsha-PROJECT\SarasaviLibrary.UI\Forms\MainForm.cs'
with open(path, 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Replace SetActiveNav
setActiveNavRegex = r'private void SetActiveNav\(Button active\)[\s\S]*?\}'
newSetActiveNav = '''private void SetActiveNav(Button active)
        {
            var all = new[] { btnNavDashboard, btnNavRegisterUser, btnNavRegisterBook,
                              btnNavLoan, btnNavReturn, btnNavReserve, btnNavInquiry };

            foreach (var b in all)
            {
                b.BackColor = Color.FromArgb(76, 91, 212);
                b.ForeColor = Color.FromArgb(165, 180, 252);
                b.FlatAppearance.MouseOverBackColor = Color.FromArgb(92, 107, 226);
                b.Region = new Region(new Rectangle(0, 0, b.Width, b.Height)); // Reset
                b.Padding = new Padding(0, 0, 0, 0); // Reset padding
            }

            // Highlight active (Pill shape)
            active.BackColor = Color.FromArgb(241, 245, 249); // Match main background
            active.ForeColor = Color.FromArgb(76, 91, 212);
            active.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            
            // Push text slightly to the right to account for the curved cut
            active.Padding = new Padding(24, 0, 0, 0);

            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int r = 40; // radius
            path.AddArc(16, 0, r, r, 180, 90);
            path.AddLine(16 + r/2, 0, active.Width, 0);
            path.AddLine(active.Width, 0, active.Width, active.Height);
            path.AddLine(active.Width, active.Height, 16 + r/2, active.Height);
            path.AddArc(16, active.Height - r, r, r, 90, 90);
            path.CloseFigure();
            active.Region = new Region(path);
        }'''

content = re.sub(setActiveNavRegex, newSetActiveNav, content)

# Remove LoadDashboardTables
content = re.sub(r'/// <summary>Loads the Borrowers and Book Titles tables shown on the dashboard\.</summary>[\s\S]*?catch \{ /\* DB not yet initialised \*/ \}\s*\}', '', content)
content = content.replace('LoadDashboardTables();', '')

# Replace BuildStatCards and LoadDashboardStats
buildStatCardsRegex = r'private void BuildStatCards\(\)[\s\S]*?LoadDashboardTables\(\);\s*\}'
newBuildStatCards = '''
        private void BuildStatCards()
        {
            // Cards will be built dynamically in LoadDashboardStats based on DB data.
        }

        private void LoadDashboardStats()
        {
            try
            {
                using var ctx = new AppDbContext();
                int totalBooks = ctx.Titles.Count();
                int availableCopies = ctx.BookCopies.Count(c => c.Status == BookCopyStatus.Available);
                int totalCopies = ctx.BookCopies.Count();
                int activeLoans = ctx.Loans.Count(l => l.Status == LoanStatus.Active);
                int registeredUsers = ctx.Borrowers.Count();
                int pendingRes = ctx.Reservations.Count(r => r.Status == ReservationStatus.Pending);

                flpStats.Controls.Clear();
                
                int copyPct = totalCopies == 0 ? 0 : (int)Math.Round((double)availableCopies / totalCopies * 100);
                int loanPct = activeLoans == 0 ? 0 : Math.Min(100, activeLoans * 5); // Example proxy
                int resPct = pendingRes == 0 ? 0 : Math.Min(100, pendingRes * 10);
                
                AddPercentageCard("Available Books", copyPct, Color.FromArgb(16, 185, 129));
                AddPercentageCard("Active Loans", loanPct, Color.FromArgb(245, 158, 11));
                AddPercentageCard("Pending Reserves", resPct, Color.FromArgb(239, 68, 68));
                AddPercentageCard("Total Borrowers", Math.Min(100, registeredUsers), Color.FromArgb(99, 102, 241));
            }
            catch
            {
                // DB not initialized
            }
        }

        private void AddPercentageCard(string title, int percentage, Color accent)
        {
            var card = new Panel
            {
                Size = new Size(200, 260),
                BackColor = Color.White,
                Margin = new Padding(15, 15, 15, 15),
            };

            // Round card corners
            card.Paint += (s, e) => {
                var p = s as Panel;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 2);
                var rect = new Rectangle(1, 1, p.Width - 3, p.Height - 3);
                
                // Draw rounded border
                int r = 16;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();
                e.Graphics.DrawPath(pen, path);
                
                // Draw circular progress bar
                var center = new Point(p.Width / 2, 120);
                int radius = 50;
                var circleRect = new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2);
                
                using var backPen = new Pen(Color.FromArgb(241, 245, 249), 12);
                e.Graphics.DrawArc(backPen, circleRect, 0, 360);
                
                using var frontPen = new Pen(accent, 12);
                frontPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                frontPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                float sweep = (percentage / 100f) * 360f;
                e.Graphics.DrawArc(frontPen, circleRect, -90, sweep);
            };

            // Title
            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };
            
            // Percentage text
            var lblPct = new Label
            {
                Text = $"{percentage}%",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = accent,
                AutoSize = false,
                Size = new Size(100, 40),
                Location = new Point(50, 100),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            card.Controls.Add(lblPct);
            card.Controls.Add(lblTitle);
            flpStats.Controls.Add(card);
        }
'''

content = re.sub(buildStatCardsRegex, newBuildStatCards, content)

# Add pnlSidebar rounding to constructor
constructorRegex = r'public MainForm\(\)\s*\{\s*InitializeComponent\(\);'
newConstructor = '''public MainForm()
        {
            InitializeComponent();

            pnlSidebar.Resize += (s, e) => {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                int r = 40;
                path.AddLine(0, 0, pnlSidebar.Width - r, 0);
                path.AddArc(pnlSidebar.Width - r, 0, r, r, 270, 90);
                path.AddLine(pnlSidebar.Width, r, pnlSidebar.Width, pnlSidebar.Height - r);
                path.AddArc(pnlSidebar.Width - r, pnlSidebar.Height - r, r, r, 0, 90);
                path.AddLine(pnlSidebar.Width - r, pnlSidebar.Height, 0, pnlSidebar.Height);
                path.CloseFigure();
                pnlSidebar.Region = new Region(path);
            };'''

content = re.sub(constructorRegex, newConstructor, content)

# Remove field declarations for unused stats
content = re.sub(r'// References to stat value labels.*?private Label _lblStatReserved\s*=\s*null!;', '', content, flags=re.DOTALL)

with open(path, 'w', encoding='utf-8-sig') as f:
    f.write(content)
