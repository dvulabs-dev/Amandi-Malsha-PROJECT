using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.UI.Forms
{
    public partial class MainForm : Form
    {
        private Label _lblStatTitles;
        private Label _lblStatCopies;
        private Label _lblStatBorrowers;
        private Label _lblStatLoans;
        private Label _lblStatOverdue;
        private Label _lblStatReserved;
        private Button _activeNavButton;

        public MainForm()
        {
            InitializeComponent();

            LayoutSidebar();
            BuildDashboardContent();

            BuildStatCards();
            SetActiveNav(btnNavDashboard);
            LoadDashboardStats();

            var clock = new System.Windows.Forms.Timer { Interval = 1000 };
            clock.Tick += (_, _) => RefreshClock();
            clock.Start();
            RefreshClock();
        }

        private void LayoutSidebar()
        {
            Color darkBlue = Color.FromArgb(30, 58, 138); // Deep premium blue
            pnlSidebar.BackColor = darkBlue;
            pnlLogo.BackColor = darkBlue;
            pnlNavContainer.BackColor = darkBlue;
            pnlNavBottom.BackColor = darkBlue;
            btnNavExit.BackColor = darkBlue;

            var navButtons = new[] { btnNavDashboard, btnNavRegisterUser, btnNavRegisterBook,
                              btnNavLoan, btnNavReturn, btnNavReserve, btnNavInquiry };
            
            pnlNavContainer.Controls.Clear();
            
            int y = 20;
            foreach (var btn in navButtons)
            {
                btn.Size = new Size(pnlSidebar.Width, 60);
                btn.Location = new Point(0, y);
                btn.BackColor = darkBlue;
                btn.ForeColor = Color.Transparent; // Hide default text
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = darkBlue;
                btn.FlatAppearance.MouseDownBackColor = darkBlue;
                btn.Paint += NavButton_Paint;
                
                pnlNavContainer.Controls.Add(btn);
                y += 60;
            }
        }

        private void BuildDashboardContent()
        {
            pnlWelcomeBanner.Visible = false;
            
            flpStats.Dock = DockStyle.Top;
            flpStats.Height = 130;
            flpStats.Padding = new Padding(20, 10, 20, 0);

            var pnlCharts = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            pnlContent.Controls.Add(pnlCharts);
            pnlCharts.BringToFront();

            var tlp = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            pnlCharts.Controls.Add(tlp);

            var pnlLineChart = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 10, 0), BackColor = Color.White };
            tlp.Controls.Add(pnlLineChart, 0, 0);

            var pnlPieChart = new Panel { Dock = DockStyle.Fill, Margin = new Padding(10, 0, 0, 0), BackColor = Color.White };
            tlp.Controls.Add(pnlPieChart, 1, 0);

            PaintEventHandler drawCard = (s, e) => {
                var p = (Panel)s;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
                var path = new GraphicsPath();
                int radius = 10;
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                e.Graphics.FillPath(Brushes.White, path);
                e.Graphics.DrawPath(new Pen(Color.FromArgb(226, 232, 240)), path);
            };
            pnlLineChart.Paint += drawCard;
            pnlPieChart.Paint += drawCard;

            pnlLineChart.Paint += (s, e) => {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawString("02. Report Graph", new Font("Segoe UI", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(30, 41, 59)), new Point(20, 20));
                
                int padLeft = 50, padRight = 20, padTop = 80, padBottom = 40;
                var rect = new Rectangle(padLeft, padTop, pnlLineChart.Width - padLeft - padRight, pnlLineChart.Height - padTop - padBottom);
                
                using (var pen = new Pen(Color.FromArgb(240, 240, 240))) {
                    for (int i = 0; i <= 4; i++) {
                        int currentY = rect.Bottom - (rect.Height * i / 4);
                        g.DrawLine(pen, rect.Left, currentY, rect.Right, currentY);
                        g.DrawString((i * 100).ToString(), new Font("Segoe UI", 8), Brushes.Gray, new Point(15, currentY - 6));
                    }
                }

                var wavePath = new GraphicsPath();
                var fillPath = new GraphicsPath();
                Point[] pts = new Point[] {
                    new Point(rect.Left, rect.Bottom - 40),
                    new Point(rect.Left + rect.Width * 1 / 6, rect.Bottom - 100),
                    new Point(rect.Left + rect.Width * 2 / 6, rect.Bottom - 70),
                    new Point(rect.Left + rect.Width * 3 / 6, rect.Bottom - 160),
                    new Point(rect.Left + rect.Width * 4 / 6, rect.Bottom - 90),
                    new Point(rect.Left + rect.Width * 5 / 6, rect.Bottom - 200),
                    new Point(rect.Right, rect.Bottom - 130)
                };
                
                wavePath.AddCurve(pts, 0.4f);
                fillPath.AddCurve(pts, 0.4f);
                fillPath.AddLine(pts[6].X, pts[6].Y, rect.Right, rect.Bottom);
                fillPath.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
                fillPath.CloseFigure();

                using (var fillBrush = new SolidBrush(Color.FromArgb(50, 59, 130, 246))) { g.FillPath(fillBrush, fillPath); }
                using (var wavePen = new Pen(Color.FromArgb(59, 130, 246), 3)) { g.DrawPath(wavePen, wavePath); }
                
                string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
                for (int i = 0; i < 7; i++) {
                    int x = rect.Left + (rect.Width * i / 6);
                    g.DrawString(days[i], new Font("Segoe UI", 8), Brushes.Gray, new Point(x - 10, rect.Bottom + 10));
                    g.FillEllipse(new SolidBrush(Color.FromArgb(250, 204, 21)), x - 4, pts[i].Y - 4, 8, 8);
                }
            };

            pnlPieChart.Paint += (s, e) => {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawString("03. Comparison Report", new Font("Segoe UI", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(30, 41, 59)), new Point(20, 20));
                
                int size = Math.Min(pnlPieChart.Width, pnlPieChart.Height) - 100;
                if(size < 50) size = 50;
                int x = (pnlPieChart.Width - size) / 2;
                int y = (pnlPieChart.Height - size) / 2 + 20;
                var rect = new Rectangle(x, y, size, size);
                
                using (var pen1 = new Pen(Color.FromArgb(30, 58, 138), 24))
                using (var pen2 = new Pen(Color.FromArgb(250, 204, 21), 24))
                using (var pen3 = new Pen(Color.FromArgb(226, 232, 240), 24))
                {
                    g.DrawArc(pen1, rect, -90, 150);
                    g.DrawArc(pen2, rect, 60, 120);
                    g.DrawArc(pen3, rect, 180, 90);
                }
                
                using (var font = new Font("Segoe UI", 20, FontStyle.Bold)) {
                    var text = "75%";
                    var textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, new SolidBrush(Color.FromArgb(30, 41, 59)), new Point(x + size / 2 - (int)(textSize.Width/2), y + size / 2 - (int)(textSize.Height/2)));
                }
            };
        }

        private void NavButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(pnlSidebar.BackColor);

            int margin = 20;

            if (btn == _activeNavButton)
            {
                int r = 16;
                
                var path = new GraphicsPath();
                path.AddArc(margin, 10, r * 2, r * 2, 180, 90);
                path.AddLine(margin + r, 10, btn.Width, 10);
                path.AddLine(btn.Width, 10, btn.Width, btn.Height - 10);
                path.AddLine(btn.Width, btn.Height - 10, margin + r, btn.Height - 10);
                path.AddArc(margin, btn.Height - 10 - r * 2, r * 2, r * 2, 90, 90);
                path.CloseFigure();
                
                using (var brush = new SolidBrush(Color.FromArgb(241, 245, 249)))
                {
                    e.Graphics.FillPath(brush, path);
                }

                var topFillet = new GraphicsPath();
                topFillet.AddLine(btn.Width, 10, btn.Width - r, 10);
                topFillet.AddArc(btn.Width - r * 2, 10 - r * 2, r * 2, r * 2, 90, -90);
                topFillet.AddLine(btn.Width, 10 - r, btn.Width, 10);
                topFillet.CloseFigure();
                using (var brush = new SolidBrush(Color.FromArgb(241, 245, 249))) { e.Graphics.FillPath(brush, topFillet); }

                var botFillet = new GraphicsPath();
                botFillet.AddLine(btn.Width, btn.Height - 10, btn.Width - r, btn.Height - 10);
                botFillet.AddArc(btn.Width - r * 2, btn.Height - 10, r * 2, r * 2, 270, 90);
                botFillet.AddLine(btn.Width, btn.Height - 10 + r, btn.Width, btn.Height - 10);
                botFillet.CloseFigure();
                using (var brush = new SolidBrush(Color.FromArgb(241, 245, 249))) { e.Graphics.FillPath(brush, botFillet); }

                int pillHeight = 22;
                int pillY = (btn.Height - pillHeight) / 2;
                var pillPath = new GraphicsPath();
                pillPath.AddArc(margin + 6, pillY, 6, 6, 180, 180);
                pillPath.AddArc(margin + 6, pillY + pillHeight - 6, 6, 6, 0, 180);
                pillPath.CloseFigure();
                using (var brush = new SolidBrush(Color.FromArgb(250, 204, 21))) { e.Graphics.FillPath(brush, pillPath); }

                using (var font = new Font("Segoe UI", 10.5F, FontStyle.Bold))
                {
                    TextRenderer.DrawText(e.Graphics, btn.Text, font, new Point(margin + 35, (btn.Height - font.Height) / 2), Color.FromArgb(30, 41, 59));
                }
            }
            else
            {
                using (var font = new Font("Segoe UI", 10.5F, FontStyle.Regular))
                {
                    TextRenderer.DrawText(e.Graphics, btn.Text, font, new Point(margin + 35, (btn.Height - font.Height) / 2), Color.FromArgb(191, 219, 254));
                }
            }
        }

        private void RefreshClock()
        {
            lblDateTime.Text = "📅  " + DateTime.Now.ToString("ddd, dd MMM yyyy") +
                               "     🕐  " + DateTime.Now.ToString("HH:mm:ss") +
                               "     👤  admin";
        }

        // ─────────────────────────────────────────────────────────────────
        // DASHBOARD STAT CARDS
        // ─────────────────────────────────────────────────────────────────
        private void BuildStatCards()
        {
            flpStats.Controls.Clear();
            var cardDefs = new[]
            {
                new { Icon = "📚", Title = "Total Book Titles",      Accent = Color.FromArgb(99,  102, 241) },
                new { Icon = "📋", Title = "Book Copies",            Accent = Color.FromArgb(59,  130, 246) },
                new { Icon = "👤", Title = "Registered Borrowers",   Accent = Color.FromArgb(16,  185, 129) },
                new { Icon = "📖", Title = "Active Loans",           Accent = Color.FromArgb(245, 158,  11) },
                new { Icon = "⏰", Title = "Overdue Loans",          Accent = Color.FromArgb(239,  68,  68) },
                new { Icon = "🔖", Title = "Pending Reserves",       Accent = Color.FromArgb(139,  92, 246) },
            };

            var numLabels = new Label[cardDefs.Length];

            for (int i = 0; i < cardDefs.Length; i++)
            {
                var d = cardDefs[i];

                var card = new Panel
                {
                    Size      = new Size(200, 100),
                    BackColor = Color.White,
                    Margin    = new Padding(0, 10, 20, 10),
                    Cursor    = Cursors.Default
                };

                Color bgLight = Color.FromArgb(
                    (int)(d.Accent.R * 0.15 + 255 * 0.85),
                    (int)(d.Accent.G * 0.15 + 255 * 0.85),
                    (int)(d.Accent.B * 0.15 + 255 * 0.85));

                card.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    
                    // Left border
                    using (var b = new SolidBrush(d.Accent)) {
                        e.Graphics.FillRectangle(b, 0, 0, 4, card.Height);
                    }
                    // Outer border
                    using (var p = new Pen(Color.FromArgb(226, 232, 240))) {
                        e.Graphics.DrawRectangle(p, 0, 0, card.Width - 1, card.Height - 1);
                    }
                    // Icon background
                    e.Graphics.FillEllipse(new SolidBrush(bgLight), 16, 25, 50, 50);
                    
                    using (var font = new Font("Segoe UI Emoji", 20F))
                    {
                        TextRenderer.DrawText(e.Graphics, d.Icon, font, new Point(21, 32), d.Accent);
                    }
                };

                var numLbl = new Label
                {
                    Text      = "—",
                    Font      = new Font("Segoe UI", 20F, FontStyle.Bold),
                    AutoSize  = false,
                    Location  = new Point(80, 25),
                    Size      = new Size(110, 35),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    TextAlign = ContentAlignment.BottomLeft
                };
                card.Controls.Add(numLbl);
                numLabels[i] = numLbl;

                card.Controls.Add(new Label
                {
                    Text      = d.Title,
                    Font      = new Font("Segoe UI", 9F, FontStyle.Regular),
                    AutoSize  = false,
                    Location  = new Point(80, 60),
                    Size      = new Size(110, 20),
                    ForeColor = Color.FromArgb(100, 116, 139),
                    TextAlign = ContentAlignment.TopLeft
                });

                flpStats.Controls.Add(card);
            }

            _lblStatTitles    = numLabels[0];
            _lblStatCopies    = numLabels[1];
            _lblStatBorrowers = numLabels[2];
            _lblStatLoans     = numLabels[3];
            _lblStatOverdue   = numLabels[4];
            _lblStatReserved  = numLabels[5];
        }

        /// <summary>Queries the database and updates all stat card numbers, then reloads the tables.</summary>
        private void LoadDashboardStats()
        {
            try
            {
                using var ctx = new AppDbContext();
                _lblStatTitles.Text    = ctx.Titles.Count().ToString();
                _lblStatCopies.Text    = ctx.BookCopies.Count().ToString();
                _lblStatBorrowers.Text = ctx.Borrowers.Count().ToString();
                _lblStatLoans.Text     = ctx.Loans.Count(l => l.Status == LoanStatus.Active).ToString();
                _lblStatOverdue.Text   = ctx.Loans
                                            .Count(l => l.Status == LoanStatus.Active && l.DueDate < DateTime.Now)
                                            .ToString();
                _lblStatReserved.Text  = ctx.Reservations
                                            .Count(r => r.Status == ReservationStatus.Pending)
                                            .ToString();
            }
            catch
            {
                // Database not yet created on first run — values stay at "—"
            }

            
        }

        

        // ─────────────────────────────────────────────────────────────────
        // NAVIGATION
        // ─────────────────────────────────────────────────────────────────
        private void SetActiveNav(Button active)
        {
            var all = new[] { btnNavDashboard, btnNavRegisterUser, btnNavRegisterBook,
                              btnNavLoan, btnNavReturn, btnNavReserve, btnNavInquiry };

            foreach (var b in all)
            {
                b.Region = null; 
                b.Padding = new Padding(0, 0, 0, 0);
                b.Invalidate();
            }

            _activeNavButton = active;
            active.Invalidate();
        }

        /// <summary>Opens a module as a dialog, then refreshes stats when it closes.</summary>
        private void OpenModule(Button navBtn, string pageTitle, Form form)
        {
            SetActiveNav(navBtn);
            lblPageTitle.Text = "  " + pageTitle;
            form.ShowDialog(this);
            // Return to dashboard after dialog closes
            lblPageTitle.Text = "  📊   Dashboard";
            SetActiveNav(btnNavDashboard);
            LoadDashboardStats();
        }

        // ─────────────────────────────────────────────────────────────────
        // NAV BUTTON CLICK HANDLERS
        // ─────────────────────────────────────────────────────────────────
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnNavDashboard);
            lblPageTitle.Text = "  📊   Dashboard";
            LoadDashboardStats();
        }

        private void btnNavRegisterUser_Click(object sender, EventArgs e) =>
            OpenModule(btnNavRegisterUser, "👤   Register Borrower", new UserRegistrationForm());

        private void btnNavRegisterBook_Click(object sender, EventArgs e) =>
            OpenModule(btnNavRegisterBook, "📗   Register Book", new BookRegistrationForm());

        private void btnNavLoan_Click(object sender, EventArgs e) =>
            OpenModule(btnNavLoan, "📖   Book Loan", new LoanForm());

        private void btnNavReturn_Click(object sender, EventArgs e) =>
            OpenModule(btnNavReturn, "↩   Book Return", new ReturnForm());

        private void btnNavReserve_Click(object sender, EventArgs e) =>
            OpenModule(btnNavReserve, "🔖   Reserve Book", new ReservationForm());

        private void btnNavInquiry_Click(object sender, EventArgs e) =>
            OpenModule(btnNavInquiry, "🔍   Book Inquiry", new InquiryForm());

        private void btnNavExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
