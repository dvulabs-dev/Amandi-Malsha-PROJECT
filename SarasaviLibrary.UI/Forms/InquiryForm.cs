using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class InquiryForm : Form
    {
        private readonly InquiryService _inquiryService;

        public InquiryForm()
        {
            InitializeComponent();
            _inquiryService = new InquiryService();
        }

        // ── Book Search ──────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    MessageBox.Show("Please enter a search query.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var results = _inquiryService.SearchCopies(txtSearch.Text);

                dgvResults.DataSource = results.Select(c => new
                {
                    BookNumber     = c.AccessionNumber,
                    Title          = c.Title.Name,
                    Author         = c.Title.AuthorNames,
                    Publisher      = c.Title.Publisher,
                    Classification = c.Title.Classification,
                    BookType       = c.Title.BookType.ToString(),
                    Availability   = c.Status.ToString()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Borrower Lookup ──────────────────────────────────────────────
        private void btnBorrowerSearch_Click(object sender, EventArgs e)
        {
            string query = txtBorrowerSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a User Number or National ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var result = _inquiryService.SearchBorrower(query);

                if (!result.Found)
                {
                    pnlProfile.Visible = false;
                    dgvLoans.Visible   = false;
                    MessageBox.Show(
                        $"No borrower found for \"{query}\".\nCheck the User Number or National ID and try again.",
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ── Populate profile card ────────────────────────────────
                lblProfileName.Text    = $"👤  {result.Name}";
                lblProfileUserNo.Text  = $"User Number:   {result.UserNumber}";
                lblProfileNid.Text     = $"National ID:   {result.NationalId}";
                lblProfileAddress.Text = $"Address:       {result.Address}";
                lblProfileSex.Text     = $"Sex:           {result.Sex}";
                lblProfileRegDate.Text = $"Registered:    {result.RegisteredDate.ToShortDateString()}";

                // Stats
                lblStatTotal.Text   = $"Total Loans: {result.TotalLoans}";
                lblStatActive.Text  = $"Active: {result.ActiveLoans}";
                lblStatOverdue.Text = result.OverdueLoans > 0
                    ? $"⚠ Overdue: {result.OverdueLoans}"
                    : "✔ No Overdue";
                lblStatOverdue.ForeColor = result.OverdueLoans > 0
                    ? Color.FromArgb(185, 28, 28)
                    : Color.FromArgb(22, 163, 74);

                pnlProfile.Visible = true;

                // ── Populate loans grid ──────────────────────────────────
                dgvLoans.DataSource = result.Loans.Select(l => new
                {
                    AccessionNo  = l.AccessionNumber,
                    BookTitle    = l.BookTitle,
                    LoanDate     = l.LoanDate.ToShortDateString(),
                    DueDate      = l.DueDate.ToShortDateString(),
                    ReturnDate   = l.ReturnDate.HasValue ? l.ReturnDate.Value.ToShortDateString() : "—",
                    Status       = l.IsOverdue ? "⚠ OVERDUE" : l.Status
                }).ToList();

                // Colour overdue rows red
                dgvLoans.CellFormatting -= DgvLoans_CellFormatting; // prevent duplicate subscribe
                dgvLoans.CellFormatting += DgvLoans_CellFormatting;

                dgvLoans.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLoans_CellFormatting(object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvLoans.Rows[e.RowIndex].Cells["Status"].Value?.ToString() == "⚠ OVERDUE")
            {
                if (e.RowIndex >= 0)
                {
                    dgvLoans.Rows[e.RowIndex].DefaultCellStyle.ForeColor    = Color.FromArgb(185, 28, 28);
                    dgvLoans.Rows[e.RowIndex].DefaultCellStyle.BackColor    = Color.FromArgb(254, 226, 226);
                    dgvLoans.Rows[e.RowIndex].DefaultCellStyle.Font         =
                        new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }
    }
}
