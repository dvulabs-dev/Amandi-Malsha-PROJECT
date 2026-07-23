using System;
using System.Linq;
using System.Windows.Forms;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;

namespace SarasaviLibrary.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Simple validation for prototype. In production, use hashed passwords!
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                this.Hide();
                var mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                using var context = new AppDbContext();
                var librarian = context.Librarians.FirstOrDefault(l => l.Username == txtUsername.Text && l.PasswordHash == txtPassword.Text);
                
                if (librarian != null)
                {
                    this.Hide();
                    var mainForm = new MainForm();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Try admin/admin.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
