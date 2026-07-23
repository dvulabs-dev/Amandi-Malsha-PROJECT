using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class ReturnForm : Form
    {
        private LoanService _loanService;

        public ReturnForm()
        {
            InitializeComponent();
            _loanService = new LoanService();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAccessionNumber.Text))
                {
                    MessageBox.Show("Please enter an Accession Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string message = _loanService.ReturnLoan(txtAccessionNumber.Text);

                MessageBox.Show(message, "Return Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccessionNumber.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
