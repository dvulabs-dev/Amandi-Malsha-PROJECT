using System;
using System.Drawing;
using System.Windows.Forms;
using SarasaviLibrary.UI.Utilities;

namespace SarasaviLibrary.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Style MenuStrip
            menuStrip1.BackColor = ThemeUtility.ForegroundColor;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            
            // Style MdiClient background
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient client)
                {
                    client.BackColor = ThemeUtility.BackgroundColor;
                    break;
                }
            }
            
            // Show Dashboard
            var dashboard = new DashboardForm();
            dashboard.MdiParent = this;
            dashboard.Dock = DockStyle.Fill;
            dashboard.Show();
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
