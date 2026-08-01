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
            this.Load += (s, e) => UIThemeHelper.ApplyDashboardTheme(this);
        }

        public ReturnForm(string accessionNumber) : this()
        {
            txtAccessionNumber.Text = accessionNumber;
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

                CustomMessageBox.Show(message, "Return Processed Successfully");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
