using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.UI.Forms
{
    public partial class MainForm : Form
    {
        // References to stat value labels (populated in BuildStatCards)
        private Label _lblStatTitles    = null!;
        private Label _lblStatCopies    = null!;
        private Label _lblStatBorrowers = null!;
        private Label _lblStatLoans     = null!;
        private Label _lblStatOverdue   = null!;
        private Label _lblStatReserved  = null!;

        public MainForm()
        {
            InitializeComponent();

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
            lblDateTime.Text = "📅  " + DateTime.Now.ToString("ddd, dd MMM yyyy") +
                               "     🕐  " + DateTime.Now.ToString("HH:mm:ss") +
                               "     👤  admin";
        }

        // ─────────────────────────────────────────────────────────────────
        // DASHBOARD STAT CARDS
        // ─────────────────────────────────────────────────────────────────
        private void BuildStatCards()
        {
            var cardDefs = new[]
            {
                new { Icon = "📚", Title = "Total Book Titles",      Accent = Color.FromArgb(99,  102, 241) },
                new { Icon = "📋", Title = "Book Copies",            Accent = Color.FromArgb(59,  130, 246) },
                new { Icon = "👤", Title = "Registered Borrowers",   Accent = Color.FromArgb(16,  185, 129) },
                new { Icon = "📖", Title = "Active Loans",           Accent = Color.FromArgb(245, 158,  11) },
                new { Icon = "⏰", Title = "Overdue Loans",          Accent = Color.FromArgb(239,  68,  68) },
                new { Icon = "🔖", Title = "Pending Reservations",   Accent = Color.FromArgb(139,  92, 246) },
            };

            var numLabels = new Label[cardDefs.Length];

            for (int i = 0; i < cardDefs.Length; i++)
            {
                var d = cardDefs[i];

                var card = new Panel
                {
                    Size      = new Size(210, 120),
                    BackColor = Color.White,
                    Margin    = new Padding(10, 12, 10, 0),
                    Cursor    = Cursors.Default
                };

                // Left accent bar
                card.Controls.Add(new Panel
                {
                    Dock      = DockStyle.Left,
                    Width     = 6,
                    BackColor = d.Accent
                });

                // Icon
                card.Controls.Add(new Label
                {
                    Text      = d.Icon,
                    Font      = new Font("Segoe UI Emoji", 18F),
                    AutoSize  = false,
                    Location  = new Point(14, 10),
                    Size      = new Size(36, 36),
                    ForeColor = d.Accent
                });

                // Stat number (will be updated)
                var numLbl = new Label
                {
                    Text      = "—",
                    Font      = new Font("Segoe UI", 22F, FontStyle.Bold),
                    AutoSize  = false,
                    Location  = new Point(14, 48),
                    Size      = new Size(190, 36),
                    ForeColor = Color.FromArgb(30, 41, 59)
                };
                card.Controls.Add(numLbl);
                numLabels[i] = numLbl;

                // Stat title
                card.Controls.Add(new Label
                {
                    Text      = d.Title,
                    Font      = new Font("Segoe UI", 8.5F),
                    AutoSize  = false,
                    Location  = new Point(14, 88),
                    Size      = new Size(190, 20),
                    ForeColor = Color.FromArgb(100, 116, 139)
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

            LoadDashboardTables();
        }

        /// <summary>Loads the Borrowers and Book Titles tables shown on the dashboard.</summary>
        private void LoadDashboardTables()
        {
            try
            {
                using var ctx = new AppDbContext();

                // ── Registered Borrowers ──────────────────────────────────
                var borrowers = ctx.Borrowers
                    .OrderByDescending(b => b.Id)
                    .ToList()   // materialise before in-memory projection
                    .Select(b => new
                    {
                        User_No  = b.UserNumber,
                        Name     = b.Name,
                        NIC      = b.NationalId,
                        Gender   = b.Sex.ToString(),
                        Address  = b.Address ?? "",
                    })
                    .ToList();

                dgvBorrowers.DataSource = borrowers;

                // Friendly column headers
                if (dgvBorrowers.Columns.Count >= 5)
                {
                    dgvBorrowers.Columns[0].HeaderText = "User No.";
                    dgvBorrowers.Columns[0].Width      = 80;
                    dgvBorrowers.Columns[1].HeaderText = "Name";
                    dgvBorrowers.Columns[2].HeaderText = "NIC";
                    dgvBorrowers.Columns[3].HeaderText = "Gender";
                    dgvBorrowers.Columns[3].Width      = 70;
                    dgvBorrowers.Columns[4].HeaderText = "Address";
                }

                // ── Registered Book Titles ────────────────────────────────
                var books = ctx.Titles
                    .Include(t => t.Copies)
                    .OrderByDescending(t => t.TitleId)
                    .ToList()   // materialise before in-memory projection
                    .Select(t => new
                    {
                        Book_No  = t.BookNumberPrefix ?? "",
                        Title    = t.Name,
                        Author   = t.AuthorNames ?? "",
                        Publisher = t.Publisher ?? "",
                        Type     = t.BookType.ToString(),
                        Copies   = t.Copies.Count,
                    })
                    .ToList();

                dgvBooks.DataSource = books;

                if (dgvBooks.Columns.Count >= 6)
                {
                    dgvBooks.Columns[0].HeaderText = "Book No.";
                    dgvBooks.Columns[0].Width      = 80;
                    dgvBooks.Columns[1].HeaderText = "Title";
                    dgvBooks.Columns[2].HeaderText = "Author";
                    dgvBooks.Columns[3].HeaderText = "Publisher";
                    dgvBooks.Columns[4].HeaderText = "Type";
                    dgvBooks.Columns[4].Width      = 90;
                    dgvBooks.Columns[5].HeaderText = "Copies";
                    dgvBooks.Columns[5].Width      = 60;
                }
            }
            catch { /* DB not yet initialised */ }
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
                b.BackColor = Color.FromArgb(30, 58, 138);
                b.ForeColor = Color.FromArgb(165, 180, 252);
                b.FlatAppearance.MouseOverBackColor = Color.FromArgb(49, 78, 168);
            }

            // Highlight active
            active.BackColor = Color.FromArgb(59, 130, 246);
            active.ForeColor = Color.White;
            active.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
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
