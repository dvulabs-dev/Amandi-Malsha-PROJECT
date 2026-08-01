import codecs

path = r'D:\DVULabs\Amandi-Malsha-PROJECT\SarasaviLibrary.UI\Forms\MainForm.cs'

code = '''using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.UI.Forms
{
    public class CustomNavButton : Button
    {
        public bool IsActive { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Draw base background (Sidebar color)
            using (var bgBrush = new SolidBrush(Color.FromArgb(76, 91, 212)))
            {
                e.Graphics.FillRectangle(bgBrush, ClientRectangle);
            }

            if (IsActive)
            {
                // Smooth pill shape blending into the right main area
                using var brush = new SolidBrush(Color.FromArgb(241, 245, 249)); // Main background color
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                int r = 40;
                path.AddArc(16, 0, r, r, 180, 90);
                path.AddLine(16 + r/2, 0, Width, 0);
                path.AddLine(Width, 0, Width, Height);
                path.AddLine(Width, Height, 16 + r/2, Height);
                path.AddArc(16, Height - r, r, r, 90, 90);
                path.CloseFigure();
                e.Graphics.FillPath(brush, path);
            }
            else if (ClientRectangle.Contains(PointToClient(MousePosition)))
            {
                // Hover effect
                using var brush = new SolidBrush(Color.FromArgb(92, 107, 226));
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
            
            // Draw Text
            Color textColor = IsActive ? Color.FromArgb(76, 91, 212) : Color.FromArgb(255, 255, 255);
            if (!IsActive && Name == "btnNavExit") textColor = Color.FromArgb(252, 165, 165); // Exit button specific color
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
            
            // Text offset
            var rect = new Rectangle(IsActive ? 30 : 16, 0, Width, Height);
            TextRenderer.DrawText(e.Graphics, Text.Trim(), Font, rect, textColor, flags);
        }

        protected override void OnMouseEnter(EventArgs e) { base.OnMouseEnter(e); Invalidate(); }
        protected override void OnMouseLeave(EventArgs e) { base.OnMouseLeave(e); Invalidate(); }
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Smooth Sidebar Rounded Corners
            pnlSidebar.BackColor = Color.FromArgb(241, 245, 249); // Same as main body
            pnlLogo.BackColor = Color.Transparent;
            pnlNavBottom.BackColor = Color.Transparent;
            pnlNavContainer.BackColor = Color.Transparent;

            pnlSidebar.Paint += (s, e) => {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(Color.FromArgb(76, 91, 212));
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                int r = 40;
                path.AddLine(0, 0, pnlSidebar.Width - r, 0);
                path.AddArc(pnlSidebar.Width - r, 0, r, r, 270, 90);
                path.AddLine(pnlSidebar.Width, r, pnlSidebar.Width, pnlSidebar.Height - r);
                path.AddArc(pnlSidebar.Width - r, pnlSidebar.Height - r, r, r, 0, 90);
                path.AddLine(pnlSidebar.Width - r, pnlSidebar.Height, 0, pnlSidebar.Height);
                path.CloseFigure();
                e.Graphics.FillPath(brush, path);
            };

            // Force repaint on resize to avoid artifacts
            pnlSidebar.Resize += (s, e) => pnlSidebar.Invalidate();

            // Set welcome subtitle with today's date
            lblWelcomeSubtitle.Text =
                $"Manage books, borrowers, loans and reservations  •  {DateTime.Now:dddd, dd MMMM yyyy}";

            BuildStatCards();
            SetActiveNav(btnNavDashboard);
            LoadDashboardStats();

            // Live clock timer
            var clock = new System.Windows.Forms.Timer { Interval = 1000 };
            clock.Tick += (_, _) => RefreshClock();
            clock.Start();
            RefreshClock();
        }

        private void RefreshClock()
        {
            lblDateTime.Text = "??  " + DateTime.Now.ToString("ddd, dd MMM yyyy") +
                               "     ??  " + DateTime.Now.ToString("HH:mm:ss") +
                               "     ??  admin";
        }

        private void BuildStatCards()
        {
            // Cards built dynamically in LoadDashboardStats
        }

        private void LoadDashboardStats()
        {
            try
            {
                using var ctx = new AppDbContext();
                int totalBooks = ctx.Titles.Count();
                int availableCopies = ctx.BookCopies.Count(c => c.Status == CopyStatus.Available);
                int activeLoans = ctx.Loans.Count(l => l.Status == LoanStatus.Active);
                int registeredUsers = ctx.Borrowers.Count();
                int pendingRes = ctx.Reservations.Count(r => r.Status == ReservationStatus.Pending);

                flpStats.Controls.Clear();
                
                AddNumberCard("Available Books", availableCopies, "??", Color.FromArgb(16, 185, 129));
                AddNumberCard("Active Loans", activeLoans, "??", Color.FromArgb(245, 158, 11));
                AddNumberCard("Pending Reserves", pendingRes, "??", Color.FromArgb(239, 68, 68));
                AddNumberCard("Total Borrowers", registeredUsers, "??", Color.FromArgb(99, 102, 241));
            }
            catch
            {
                // DB not initialized
            }
        }

        private void AddNumberCard(string title, int number, string icon, Color accent)
        {
            var card = new Panel
            {
                Size = new Size(240, 120),
                BackColor = Color.White,
                Margin = new Padding(15, 15, 15, 15),
            };

            // Round card corners and draw icon circle
            card.Paint += (s, e) => {
                var p = (Panel)s;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                
                // Draw rounded border/background
                var rect = new Rectangle(1, 1, p.Width - 3, p.Height - 3);
                int r = 16;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();
                
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
                
                // Draw circle for icon
                using (var brush = new SolidBrush(Color.FromArgb(30, accent.R, accent.G, accent.B)))
                {
                    e.Graphics.FillEllipse(brush, 20, 30, 60, 60);
                }
                
                // Draw icon
                TextRenderer.DrawText(e.Graphics, icon, new Font("Segoe UI Emoji", 24F), new Rectangle(20, 30, 60, 60), accent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            // Title
            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(100, 35),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            
            // Number text
            var lblNum = new Label
            {
                Text = number.ToString(),
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(96, 55),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblNum);
            flpStats.Controls.Add(card);
        }

        private void SetActiveNav(CustomNavButton active)
        {
            var all = new[] { btnNavDashboard, btnNavRegisterUser, btnNavRegisterBook,
                              btnNavLoan, btnNavReturn, btnNavReserve, btnNavInquiry, btnNavExit };

            foreach (var b in all)
            {
                if (b != null)
                {
                    b.IsActive = false;
                    b.Invalidate();
                }
            }

            if (active != null)
            {
                active.IsActive = true;
                active.Invalidate();
            }
        }

        private void OpenModule(CustomNavButton navBtn, string pageTitle, Form form)
        {
            SetActiveNav(navBtn);
            lblPageTitle.Text = "  " + pageTitle;
            form.ShowDialog(this);
            lblPageTitle.Text = "  ??   Dashboard";
            SetActiveNav(btnNavDashboard);
            LoadDashboardStats();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnNavDashboard);
            lblPageTitle.Text = "  ??   Dashboard";
            LoadDashboardStats();
        }

        private void btnNavRegisterUser_Click(object sender, EventArgs e) =>
            OpenModule(btnNavRegisterUser, "??   Register Borrower", new UserRegistrationForm());

        private void btnNavRegisterBook_Click(object sender, EventArgs e) =>
            OpenModule(btnNavRegisterBook, "??   Register Book", new BookRegistrationForm());

        private void btnNavLoan_Click(object sender, EventArgs e) =>
            OpenModule(btnNavLoan, "??   Book Loan", new LoanForm());

        private void btnNavReturn_Click(object sender, EventArgs e) =>
            OpenModule(btnNavReturn, "?   Book Return", new ReturnForm());

        private void btnNavReserve_Click(object sender, EventArgs e) =>
            OpenModule(btnNavReserve, "??   Reserve Book", new ReservationForm());

        private void btnNavInquiry_Click(object sender, EventArgs e) =>
            OpenModule(btnNavInquiry, "??   Book Inquiry", new InquiryForm());

        private void btnNavExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
'''

with codecs.open(path, 'w', 'utf-8-sig') as f:
    f.write(code)
