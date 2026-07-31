using System;
using System.Drawing;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class LoanForm : Form
    {
        private readonly LoanService _loanService;

        // Stored after a successful Check so Accept can use them directly
        private int    _checkedUserNumber;
        private string _checkedAccessionNumber = string.Empty;

        public LoanForm()
        {
            InitializeComponent();
            _loanService = new LoanService();
        }

        // ── Step 1: Check Status ─────────────────────────────────────────
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Reset UI to a clean slate
            HideActionButtons();
            pnlStatus.Visible = false;
            pnlResult.Visible = false;

            if (!int.TryParse(txtUserNumber.Text.Trim(), out int userNumber))
            {
                ShowResult(false, "Please enter a valid numeric User Number.");
                return;
            }

            string accession = txtAccessionNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(accession))
            {
                ShowResult(false, "Please enter the Book Accession Number.");
                return;
            }

            try
            {
                var result = _loanService.CheckLoan(userNumber, accession);

                // ── Populate borrower rows ───────────────────────────────
                if (result.BorrowerFound)
                {
                    lblBorrowerName.Text = result.BorrowerName;
                    lblBorrowerName.ForeColor = Color.FromArgb(30, 41, 59);

                    lblLoansRow.Text      = $"Active Loans:    {result.ActiveLoanCount} / 5";
                    lblLoansRow.ForeColor = result.ActiveLoanCount >= 5
                        ? Color.FromArgb(185, 28, 28)
                        : Color.FromArgb(22, 163, 74);

                    lblOverdueRow.Text      = $"Overdue Books:   {(result.HasOverdue ? "⚠ YES – must return first" : "✔ None")}";
                    lblOverdueRow.ForeColor = result.HasOverdue
                        ? Color.FromArgb(185, 28, 28)
                        : Color.FromArgb(22, 163, 74);
                }
                else
                {
                    lblBorrowerName.Text      = "Not found";
                    lblBorrowerName.ForeColor = Color.FromArgb(185, 28, 28);
                    lblLoansRow.Text          = string.Empty;
                    lblOverdueRow.Text        = string.Empty;
                }

                // ── Populate book rows ───────────────────────────────────
                if (result.CopyFound)
                {
                    lblBookTitle.Text      = result.BookTitle;
                    lblBookTitle.ForeColor = Color.FromArgb(30, 41, 59);

                    bool borrowable = result.CopyStatus == SarasaviLibrary.Models.Enums.CopyStatus.Available;
                    lblBookStatus.Text      = $"Copy Status:   {result.CopyStatus}  " +
                                              (borrowable ? "✔ Borrowable" : "✖ Cannot borrow");
                    lblBookStatus.ForeColor = borrowable
                        ? Color.FromArgb(22, 163, 74)
                        : Color.FromArgb(185, 28, 28);
                }
                else
                {
                    lblBookTitle.Text      = "Copy not found";
                    lblBookTitle.ForeColor = Color.FromArgb(185, 28, 28);
                    lblBookStatus.Text     = string.Empty;
                }

                pnlStatus.Visible = true;

                // ── Show result banner & buttons ─────────────────────────
                if (result.CanLoan)
                {
                    ShowResult(true, "✔  All checks passed. The Librarian may now Accept or Cancel the loan.");
                    _checkedUserNumber      = userNumber;
                    _checkedAccessionNumber = accession;
                    ShowActionButtons(acceptEnabled: true);
                }
                else
                {
                    ShowResult(false, "✖  " + result.BlockReason);
                    ShowActionButtons(acceptEnabled: false);   // Only Cancel is available
                }
            }
            catch (Exception ex)
            {
                ShowResult(false, "Error: " + ex.Message);
            }
        }

        // ── Step 2a: Accept ──────────────────────────────────────────────
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                var loan = _loanService.PlaceLoan(_checkedUserNumber, _checkedAccessionNumber);

                CustomMessageBox.Show(
                    $"Loan confirmed!\n\n" +
                    $"Borrower : {lblBorrowerName.Text}\n" +
                    $"Book     : {lblBookTitle.Text}\n" +
                    $"Loan Date: {loan.LoanDate.ToShortDateString()}\n" +
                    $"Due Date : {loan.DueDate.ToShortDateString()}",
                    "Loan Processed Successfully");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not place loan:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Step 2b: Cancel ──────────────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "❌  Loan request cancelled by the Librarian. No changes were saved.",
                "Loan Cancelled",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            ResetForm();
        }

        // ── Helpers ──────────────────────────────────────────────────────
        private void ShowResult(bool success, string message)
        {
            lblResultText.Text      = message;
            lblResultText.ForeColor = success
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(185, 28, 28);
            pnlResult.BackColor     = success
                ? Color.FromArgb(220, 252, 231)
                : Color.FromArgb(254, 226, 226);
            pnlResult.Visible       = true;
        }

        private void ShowActionButtons(bool acceptEnabled)
        {
            btnAccept.Visible = true;
            btnAccept.Enabled = acceptEnabled;
            btnCancel.Visible = true;
            btnCancel.Enabled = true;
        }

        private void HideActionButtons()
        {
            btnAccept.Visible = false;
            btnAccept.Enabled = false;
            btnCancel.Visible = false;
            btnCancel.Enabled = false;
        }

        private void ResetForm()
        {
            txtUserNumber.Clear();
            txtAccessionNumber.Clear();
            pnlStatus.Visible = false;
            pnlResult.Visible = false;
            HideActionButtons();
            _checkedUserNumber      = 0;
            _checkedAccessionNumber = string.Empty;
        }
    }
}
