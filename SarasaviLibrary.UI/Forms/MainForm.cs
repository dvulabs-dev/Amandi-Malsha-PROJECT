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
        private Label _lblStatTitles = null!;
        private Label _lblStatCopies = null!;
        private Label _lblStatBorrowers = null!;
        private Label _lblStatLoans = null!;
        private Label _lblStatOverdue = null!;
        private Label _lblStatReserved = null!;
        private Button _activeNavButton = null!;

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
            pnlSidebar.Width = 300; // Increased width for better proportions

            Color darkBlue = Color.FromArgb(30, 58, 138); // Deep premium blue
            btnNavExit.BackColor = Color.Transparent;

            // Smooth rounded corners for the sidebar via Paint (anti-aliased)
            pnlSidebar.BackColor = Color.Transparent;
            pnlLogo.BackColor = Color.Transparent;
            pnlNavContainer.BackColor = Color.Transparent;
            pnlNavBottom.BackColor = Color.Transparent;
            
            int leftStripWidth = 60;
            Color leftStripColor = Color.FromArgb(99, 102, 241);
            Color rightStripColor = Color.FromArgb(67, 56, 202);
            
            pnlSidebar.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Fill left strip
                using (var brush = new SolidBrush(leftStripColor))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, leftStripWidth, pnlSidebar.Height);
                }
                
                // Fill right strip
                using (var brush = new SolidBrush(rightStripColor))
                {
                    e.Graphics.FillRectangle(brush, leftStripWidth, 0, pnlSidebar.Width - leftStripWidth, pnlSidebar.Height);
                }
            };

            var navButtons = new[] { btnNavDashboard, btnNavRegisterUser, btnNavRegisterBook,
                              btnNavLoan, btnNavReturn, btnNavReserve, btnNavInquiry };
            
            pnlNavContainer.Controls.Clear();
            
            int y = 20;
            foreach (var btn in navButtons)
            {
                btn.Size = new Size(pnlSidebar.Width, 60);
                btn.Location = new Point(0, y);
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.Transparent; 
                btn.Text = string.Empty; // Hide native text perfectly
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = darkBlue;
                btn.FlatAppearance.MouseDownBackColor = darkBlue;
                btn.Paint += NavButton_Paint;
                
                pnlNavContainer.Controls.Add(btn);
                y += 60;
            }

            // Create a professional Custom Calendar Widget in the sidebar
            var pnlCalendar = new Panel { Height = 230, Dock = DockStyle.Bottom, BackColor = Color.Transparent };
            pnlCalendar.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(20, 10, pnlCalendar.Width - 40, pnlCalendar.Height - 20);
                var p = GetRoundedRect(rect, 15);
                
                // Glassmorphism background
                using (var brush = new LinearGradientBrush(rect, Color.FromArgb(40, 255, 255, 255), Color.FromArgb(10, 255, 255, 255), 45F))
                {
                    e.Graphics.FillPath(brush, p);
                }
                using (var pen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                {
                    e.Graphics.DrawPath(pen, p);
                }
                
                // Header
                using (var font = new Font("Segoe UI", 11, FontStyle.Bold))
                {
                    e.Graphics.DrawString(DateTime.Now.ToString("MMMM yyyy"), font, Brushes.White, new Point(rect.X + 65, rect.Y + 15));
                }
                
                // Calendar Grid
                using (var font = new Font("Segoe UI", 8, FontStyle.Regular))
                {
                    string[] dows = { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
                    int stepX = (rect.Width - 80) / 7;
                    for (int i = 0; i < 7; i++) {
                        e.Graphics.DrawString(dows[i], font, new SolidBrush(Color.FromArgb(180, 255, 255, 255)), new Point(rect.X + 65 + stepX * i, rect.Y + 45));
                    }
                    
                    using (var dayFont = new Font("Segoe UI", 9, FontStyle.Bold))
                    {
                        var firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        int startDayIndex = (int)firstDay.DayOfWeek;
                        int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                        
                        int day = 1;
                        for (int row = 0; row < 6; row++) {
                            for (int col = 0; col < 7; col++) {
                                if (row == 0 && col < startDayIndex) continue;
                                if (day > daysInMonth) break;
                                
                                int x = rect.X + 65 + stepX * col;
                                int y = rect.Y + 70 + (row * 24);
                                
                                if (day == DateTime.Now.Day) {
                                    e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(250, 204, 21)), x - 5, y - 3, 22, 22);
                                    e.Graphics.DrawString(day.ToString(), dayFont, new SolidBrush(Color.FromArgb(30, 58, 138)), new Point(x, y));
                                } else {
                                    e.Graphics.DrawString(day.ToString(), dayFont, Brushes.White, new Point(x, y));
                                }
                                day++;
                            }
                        }
                    }
                }
            };
            
            btnNavExit.Text = "";
            btnNavExit.Paint += (s, e) => {
                var btn = s as Button;
                if (btn == null) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int leftStripWidth = 60;
                
                string icon = "🚪";
                string text = "Log Out";
                
                using (var font = new Font("Segoe UI Emoji", 14F))
                {
                    var sz = e.Graphics.MeasureString(icon, font);
                    float ix = (leftStripWidth - sz.Width) / 2;
                    float iy = (btn.Height - sz.Height) / 2;
                    TextRenderer.DrawText(e.Graphics, icon, font, new Point((int)ix, (int)iy), Color.FromArgb(252, 165, 165));
                }

                using (var font = new Font("Segoe UI", 10.5F, FontStyle.Regular))
                {
                    TextRenderer.DrawText(e.Graphics, text, font, new Point(leftStripWidth + 25, (btn.Height - font.Height) / 2), Color.FromArgb(252, 165, 165));
                }
            };
            
            pnlSidebar.Controls.Add(pnlCalendar);
            pnlCalendar.BringToFront(); // Stack it above the exit button
            pnlNavBottom.BringToFront(); // Ensure exit button is at the very bottom
        }

        private void BuildDashboardContent()
        {
            this.Size = new Size(1400, 900);
            this.MinimumSize = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            pnlWelcomeBanner.Visible = false;

            var pnlTopHeader = new Panel { Dock = DockStyle.Top, Height = 205, BackColor = Color.Transparent };
            pnlContent.Controls.Add(pnlTopHeader);
            
            flpStats.Dock = DockStyle.Top;
            flpStats.Height = 440;
            flpStats.Padding = new Padding(20, 10, 20, 0);

            var pnlCharts = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };
            pnlContent.Controls.Add(pnlCharts);

            flpStats.SendToBack();
            pnlTopHeader.SendToBack();
            pnlCharts.BringToFront();

            pnlTopHeader.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Draw Banner (spanning almost full width and height)
                var rect = new Rectangle(15, 15, pnlTopHeader.Width - 30, 175);
                var path = GetRoundedRect(rect, 15);

                // Gradient Background
                using (var brush = new LinearGradientBrush(rect, Color.FromArgb(147, 197, 253), Color.FromArgb(59, 130, 246), 45F)) {
                    e.Graphics.FillPath(brush, path);
                }

                // Background decorations
                using (var decorBrush = new SolidBrush(Color.FromArgb(20, 255, 255, 255))) {
                    e.Graphics.FillRectangle(decorBrush, rect.X + 450, rect.Y + 10, 80, 80);
                    e.Graphics.FillRectangle(decorBrush, rect.X + 580, rect.Y + 20, 60, 50);
                    e.Graphics.FillRectangle(decorBrush, rect.X + 460, rect.Y + 15, 20, 40);
                    e.Graphics.FillRectangle(decorBrush, rect.X + 490, rect.Y + 30, 15, 20);
                }

                // Draw Notification Bell inside banner (top right)
                int bellX = rect.Right - 55;
                using (var fontBell = new Font("Segoe UI Emoji", 16F)) {
                    TextRenderer.DrawText(e.Graphics, "🔔", fontBell, new Point(bellX, rect.Y + 20), Color.Black);
                }
                e.Graphics.FillEllipse(Brushes.Red, bellX + 22, rect.Y + 22, 10, 10);

                // Welcome Header Texts (now inside the banner!)
                using (var fontSmall = new Font("Segoe UI", 10F, FontStyle.Bold)) {
                    e.Graphics.DrawString("Hi, Admin!", fontSmall, new SolidBrush(Color.FromArgb(220, 230, 255)), new Point(rect.X + 30, rect.Y + 20));
                }
                using (var fontLarge = new Font("Segoe UI", 22F, FontStyle.Bold)) {
                    e.Graphics.DrawString("Welcome to Sarasavi Library!", fontLarge, Brushes.White, new Point(rect.X + 26, rect.Y + 45));
                }

                // Library Quote
                using (var fontQuoteTitle = new Font("Segoe UI", 9F, FontStyle.Regular)) {
                    e.Graphics.DrawString("Library Quote", fontQuoteTitle, new SolidBrush(Color.FromArgb(200, 220, 255)), new Point(rect.X + 30, rect.Y + 115));
                }
                
                using (var fontQuote = new Font("Segoe UI", 14F, FontStyle.Bold)) {
                    var quote = "\"A library is not a luxury but one of the necessities of life.\"";
                    e.Graphics.DrawString(quote, fontQuote, Brushes.White, new Point(rect.X + 26, rect.Y + 135));
                }

                // Draw a simple book illustration on the right
                int illustrationX = rect.Right - 220;
                int illustrationY = rect.Y + 10;
                
                // Decorative circles behind the book
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(40, 255, 255, 255)), illustrationX - 20, illustrationY, 140, 140);
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(20, 255, 255, 255)), illustrationX - 70, illustrationY + 40, 60, 60);
                
                // Draw Book icon with Segoe MDL2 Assets
                using (var fontIcon = new Font("Segoe MDL2 Assets", 80F)) {
                    e.Graphics.DrawString("\uE82D", fontIcon, new SolidBrush(Color.FromArgb(220, 255, 255, 255)), new Point(illustrationX - 15, illustrationY + 10));
                }
            };

            var tlp = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            pnlCharts.Controls.Add(tlp);

            var pnlLineChart = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 10, 0), BackColor = Color.White };
            tlp.Controls.Add(pnlLineChart, 0, 0);

            var pnlPieChart = new Panel { Dock = DockStyle.Fill, Margin = new Padding(10, 0, 0, 0), BackColor = Color.White };
            tlp.Controls.Add(pnlPieChart, 1, 0);

            PaintEventHandler drawCard = (s, e) => {
                var p = s as Panel;
                if (p == null) return;
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
                g.DrawString("User Registration Timeline", new Font("Segoe UI", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(30, 41, 59)), new Point(20, 20));
                
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
                    g.FillEllipse(new SolidBrush(Color.FromArgb(30, 58, 138)), x - 4, pts[i].Y - 4, 8, 8); // Changed to dark blue
                }
            };

            pnlPieChart.Paint += (s, e) => {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawString("Book Borrowable Percentage", new Font("Segoe UI", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(30, 41, 59)), new Point(20, 20));
                
                int size = Math.Min(pnlPieChart.Width, pnlPieChart.Height) - 100;
                if(size < 50) size = 50;
                int x = (pnlPieChart.Width - size) / 2;
                int y = (pnlPieChart.Height - size) / 2 + 20;
                var rect = new Rectangle(x, y, size, size);
                
                using (var pen1 = new Pen(Color.FromArgb(30, 58, 138), 24))
                using (var pen2 = new Pen(Color.FromArgb(59, 130, 246), 24)) // Changed from yellow to primary blue
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

        private void NavButton_Paint(object? sender, PaintEventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int leftStripWidth = 60;
            string icon = "";
            string text = "";
            
            if (btn.Tag != null)
            {
                string tagStr = btn.Tag.ToString() ?? "";
                var parts = tagStr.Split('|');
                if (parts.Length == 2)
                {
                    icon = parts[0];
                    text = parts[1];
                }
                else
                {
                    text = tagStr;
                }
            }

            if (btn == _activeNavButton)
            {
                // Active tab: cutout effect on the right strip
                int r = 20; // Corner radius
                
                var path = new GraphicsPath();
                // We want the white background to start at leftStripWidth and go to btn.Width
                // with rounded top-left and bottom-left corners.
                var rect = new Rectangle(leftStripWidth, 5, btn.Width - leftStripWidth, btn.Height - 10);
                
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddLine(rect.X + r, rect.Y, rect.Right, rect.Y);
                path.AddLine(rect.Right, rect.Bottom, rect.X + r, rect.Bottom);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();
                
                using (var brush = new SolidBrush(Color.FromArgb(241, 245, 249))) // Match main form background
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Draw Icon on the left strip
                using (var font = new Font("Segoe UI Emoji", 14F))
                {
                    var sz = e.Graphics.MeasureString(icon, font);
                    float ix = (leftStripWidth - sz.Width) / 2;
                    float iy = (btn.Height - sz.Height) / 2;
                    TextRenderer.DrawText(e.Graphics, icon, font, new Point((int)ix, (int)iy), Color.White);
                }

                // Draw Text on the right strip
                using (var font = new Font("Segoe UI", 11F, FontStyle.Bold))
                {
                    TextRenderer.DrawText(e.Graphics, text, font, new Point(leftStripWidth + 25, (btn.Height - font.Height) / 2), Color.FromArgb(30, 41, 59));
                }
            }
            else
            {
                // Inactive tab
                
                // Draw Icon on the left strip
                using (var font = new Font("Segoe UI Emoji", 14F))
                {
                    var sz = e.Graphics.MeasureString(icon, font);
                    float ix = (leftStripWidth - sz.Width) / 2;
                    float iy = (btn.Height - sz.Height) / 2;
                    TextRenderer.DrawText(e.Graphics, icon, font, new Point((int)ix, (int)iy), Color.FromArgb(200, 200, 255)); // Slightly dimmed
                }

                // Draw Text on the right strip
                using (var font = new Font("Segoe UI", 10.5F, FontStyle.Regular))
                {
                    TextRenderer.DrawText(e.Graphics, text, font, new Point(leftStripWidth + 25, (btn.Height - font.Height) / 2), Color.White);
                }
            }
        }

        private void RefreshClock()
        {
            lblDateTime.Text = "📅  " + DateTime.Now.ToString("ddd, dd MMM yyyy") +
                               "     🕐  " + DateTime.Now.ToString("HH:mm:ss") +
                               "     admin";
        }

        // ─────────────────────────────────────────────────────────────────
        // DASHBOARD STAT CARDS
        // ─────────────────────────────────────────────────────────────────
        private void BuildStatCards()
        {
            flpStats.Controls.Clear();
            var cardDefs = new[]
            {
                new { Icon = "", Title = "Total Book Titles",      Accent = Color.FromArgb(37,  99, 235) },
                new { Icon = "", Title = "Registered Borrowers",   Accent = Color.FromArgb(16,  185, 129) },
                new { Icon = "📖", Title = "Active Loans",           Accent = Color.FromArgb(245, 158,  11) },
                new { Icon = "⏰", Title = "Overdue Loans",          Accent = Color.FromArgb(239,  68,  68) }
            };

            var numLabels = new Label[cardDefs.Length];

            for (int i = 0; i < cardDefs.Length; i++)
            {
                var d = cardDefs[i];
                bool isFirst = (i == 0);

                var card = new Panel
                {
                    Size      = new Size(340, 200), // Massive card for perfect clarity
                    BackColor = Color.Transparent, 
                    Margin    = new Padding(10, 10, 20, 20),
                    Cursor    = Cursors.Default
                };

                Color bgColor = isFirst ? Color.FromArgb(37, 99, 235) : Color.FromArgb(248, 250, 252);
                Color textColor = isFirst ? Color.White : Color.FromArgb(30, 41, 59);
                Color subTextColor = isFirst ? Color.FromArgb(180, 210, 255) : Color.FromArgb(100, 116, 139);

                var numLbl = new Label
                {
                    Text      = "—",
                    Visible   = false // Hidden so it doesn't clip the custom drawn text underneath
                };
                // When LoadDashboardStats updates the hidden label's text, trigger a repaint of this specific card
                numLbl.TextChanged += (sender, args) => card.Invalidate();
                card.Controls.Add(numLbl);
                numLabels[i] = numLbl;

                card.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    int r = 20;
                    int tabW = 140;
                    int drop = 40;

                    var p = new GraphicsPath();
                    p.AddArc(0, 0, r * 2, r * 2, 180, 90);
                    p.AddLine(r, 0, tabW - r, 0);
                    p.AddArc(tabW - r * 2, 0, r * 2, r * 2, 270, 90); 
                    p.AddLine(tabW, r, tabW, drop - r); 
                    p.AddArc(tabW, drop - r * 2, r * 2, r * 2, 180, -90);
                    p.AddLine(tabW + r, drop, card.Width - r, drop);
                    p.AddArc(card.Width - r * 2, drop, r * 2, r * 2, 270, 90);
                    p.AddArc(card.Width - r * 2, card.Height - r * 2, r * 2, r * 2, 0, 90);
                    p.AddArc(0, card.Height - r * 2, r * 2, r * 2, 90, 90);
                    p.CloseFigure();

                    // Subtle shadow
                    e.Graphics.TranslateTransform(1, 1);
                    using (var shadowBrush = new SolidBrush(Color.FromArgb(15, 0, 0, 0))) {
                        e.Graphics.FillPath(shadowBrush, p);
                    }
                    e.Graphics.TranslateTransform(-1, -1);

                    using (var brush = new SolidBrush(bgColor)) {
                        e.Graphics.FillPath(brush, p);
                    }
                    
                    if (!isFirst) {
                        using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1)) {
                            e.Graphics.DrawPath(pen, p);
                        }
                    }

                    // Tab Icon
                    using (var font = new Font("Segoe UI Emoji", 12F)) {
                        TextRenderer.DrawText(e.Graphics, d.Icon, font, new Point(16, 8), textColor);
                    }

                    // "ASSOCIATED WITH"
                    using (var font = new Font("Segoe UI", 8F, FontStyle.Bold)) {
                        e.Graphics.DrawString("ASSOCIATED WITH", font, new SolidBrush(subTextColor), new Point(24, drop + 20));
                    }

                    // Avatars
                    int avatarY = drop + 42;
                    int avatarSize = 40;
                    string[] emojis = { "", "", "🏫" };
                    Color[] avatarColors = { Color.FromArgb(254, 226, 226), Color.FromArgb(219, 234, 254), Color.FromArgb(220, 252, 231) };
                    for (int j = 2; j >= 0; j--) { 
                        int ax = 24 + (j * 24);
                        e.Graphics.FillEllipse(new SolidBrush(bgColor), ax - 2, avatarY - 2, avatarSize + 4, avatarSize + 4);
                        e.Graphics.FillEllipse(new SolidBrush(avatarColors[j]), ax, avatarY, avatarSize, avatarSize);
                        using (var font = new Font("Segoe UI Emoji", 16F)) {
                            TextRenderer.DrawText(e.Graphics, emojis[j], font, new Point(ax + 3, avatarY + 4), Color.Black);
                        }
                    }

                    // CATEGORY
                    using (var font = new Font("Segoe UI", 8.5F, FontStyle.Bold)) {
                        e.Graphics.DrawString("CATEGORY", font, new SolidBrush(subTextColor), new Point(24, card.Height - 75));
                    }
                    
                    // Title
                    using (var font = new Font("Segoe UI", 13F, FontStyle.Bold)) {
                        e.Graphics.DrawString(d.Title, font, isFirst ? Brushes.White : new SolidBrush(Color.FromArgb(37, 99, 235)), new Point(20, card.Height - 55));
                    }
                    
                    // TOTAL label
                    using (var font = new Font("Segoe UI", 10F, FontStyle.Bold)) {
                        var sz = e.Graphics.MeasureString("TOTAL", font);
                        e.Graphics.DrawString("TOTAL", font, new SolidBrush(subTextColor), new Point(card.Width - 30 - (int)sz.Width, card.Height - 95));
                    }

                    // Number (pulled dynamically from the hidden label - FIXED loop closure bug!)
                    using (var font = new Font("Segoe UI", 40F, FontStyle.Bold)) {
                        string valStr = numLbl.Text;
                        var sz = e.Graphics.MeasureString(valStr, font);
                        e.Graphics.DrawString(valStr, font, new SolidBrush(textColor), new Point(card.Width - 30 - (int)sz.Width, card.Height - 75));
                    }
                };

                flpStats.Controls.Add(card);
            }

            _lblStatTitles    = numLabels[0];
            _lblStatBorrowers = numLabels[1];
            _lblStatLoans     = numLabels[2];
            _lblStatOverdue   = numLabels[3];
            
            // Dummy labels so LoadDashboardStats doesn't crash when updating the removed cards
            _lblStatCopies    = new Label();
            _lblStatReserved  = new Label();
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

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void OpenModule(Button navBtn, string pageTitle, Form form)
        {
            SetActiveNav(navBtn);
            lblPageTitle.Text = "  " + pageTitle;
            form.ShowDialog(this);
            // Return to dashboard after dialog closes
            btnNavDashboard_Click(btnNavDashboard, EventArgs.Empty);
        }

        private void OpenModuleInline(Button navBtn, string pageTitle, Form form)
        {
            SetActiveNav(navBtn);
            lblPageTitle.Text = "  " + pageTitle;

            // Hide dashboard controls in pnlContent
            foreach (Control c in pnlContent.Controls)
            {
                c.Visible = false;
            }

            // Remove any previously hosted forms
            var existingForms = pnlContent.Controls.OfType<Form>().ToList();
            foreach (var f in existingForms)
            {
                pnlContent.Controls.Remove(f);
                f.Dispose();
            }

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();
        }

        // ─────────────────────────────────────────────────────────────────
        // NAV BUTTON CLICK HANDLERS
        // ─────────────────────────────────────────────────────────────────
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnNavDashboard);
            lblPageTitle.Text = "  📊   Dashboard";

            // Remove any hosted forms
            var existingForms = pnlContent.Controls.OfType<Form>().ToList();
            foreach (var f in existingForms)
            {
                pnlContent.Controls.Remove(f);
                f.Dispose();
            }

            // Show dashboard controls
            foreach (Control c in pnlContent.Controls)
            {
                c.Visible = true;
            }
            pnlWelcomeBanner.Visible = false; // Keep welcome banner hidden

            LoadDashboardStats();
        }

        private void btnNavRegisterUser_Click(object sender, EventArgs e) =>
            OpenModuleInline(btnNavRegisterUser, "👥   Borrowers List", new BorrowerListForm());

        private void btnNavRegisterBook_Click(object sender, EventArgs e) =>
            OpenModuleInline(btnNavRegisterBook, " Registered Books", new BookListForm());

        private void btnNavLoan_Click(object sender, EventArgs e) =>
            OpenModuleInline(btnNavLoan, "📖   Active Loans", new LoanListForm());

        private void btnNavReturn_Click(object sender, EventArgs e) =>
            OpenModuleInline(btnNavReturn, "↩   Return History", new ReturnListForm());

        private void btnNavReserve_Click(object sender, EventArgs e) =>
            OpenModuleInline(btnNavReserve, "🔖   Reservations", new ReservationListForm());

        private void btnNavInquiry_Click(object sender, EventArgs e) =>
            OpenModuleInline(btnNavInquiry, " Inquiry Dashboard", new InquiryForm());

        private void btnNavExit_Click(object sender, EventArgs e) => Application.Exit();

        /// <summary>
        /// Called by embedded child forms (e.g. ReservationListForm) to switch the
        /// main content panel to the Active Loans screen with fresh data.
        /// </summary>
        public void NavigateToActiveLoans()
        {
            btnNavLoan_Click(btnNavLoan, EventArgs.Empty);
        }
    }
}

