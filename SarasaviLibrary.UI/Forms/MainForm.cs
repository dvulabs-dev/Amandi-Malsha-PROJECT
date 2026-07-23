using System;
using System.Windows.Forms;

namespace SarasaviLibrary.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void ShowForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        private void mnuRegisterUser_Click(object sender, EventArgs e) => ShowForm(new UserRegistrationForm());
        private void mnuRegisterBook_Click(object sender, EventArgs e) => ShowForm(new BookRegistrationForm());
        private void mnuLoanBook_Click(object sender, EventArgs e) => ShowForm(new LoanForm());
        private void mnuReturnBook_Click(object sender, EventArgs e) => ShowForm(new ReturnForm());
        private void mnuReserveBook_Click(object sender, EventArgs e) => ShowForm(new ReservationForm());
        private void mnuInquiry_Click(object sender, EventArgs e) => ShowForm(new InquiryForm());
        private void mnuExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
