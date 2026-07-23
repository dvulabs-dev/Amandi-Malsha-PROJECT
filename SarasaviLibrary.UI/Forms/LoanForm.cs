using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class LoanForm : Form
    {
        private LoanService _loanService;

        public LoanForm()
        {
            InitializeComponent();
            _loanService = new LoanService();
        }

        private void btnPlaceLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUserNumber.Text, out int userNumber))
                {
                    MessageBox.Show("Please enter a valid User Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAccessionNumber.Text))
                {
                    MessageBox.Show("Please enter an Accession Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var loan = _loanService.PlaceLoan(userNumber, txtAccessionNumber.Text);

                MessageBox.Show($"Loan placed successfully!\nDue Date: {loan.DueDate.ToShortDateString()}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtUserNumber.Clear();
            txtAccessionNumber.Clear();
        }
    }
}
