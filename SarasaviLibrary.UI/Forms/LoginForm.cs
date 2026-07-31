using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
            
            this.Load += LoginForm_Load;
            this.btnLogin.Paint += BtnLogin_Paint;
            
            this.txtUsername.Enter += (s, e) => this.pnlUsernameLine.BackColor = Color.FromArgb(66, 133, 244);
            this.txtUsername.Leave += (s, e) => this.pnlUsernameLine.BackColor = Color.LightGray;
            
            this.txtPassword.Enter += (s, e) => this.pnlPasswordLine.BackColor = Color.FromArgb(66, 133, 244);
            this.txtPassword.Leave += (s, e) => this.pnlPasswordLine.BackColor = Color.LightGray;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "login_illustration.png");
            if (File.Exists(imagePath))
            {
                picIllustration.Image = Image.FromFile(imagePath);
            }
        }

        private void BtnLogin_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                int radius = 20; 
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                
                btn.Region = new Region(path);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
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
