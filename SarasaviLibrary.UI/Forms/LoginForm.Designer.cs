namespace SarasaviLibrary.UI.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblSubtitle    = new System.Windows.Forms.Label();
            this.pnlBody        = new System.Windows.Forms.Panel();
            this.lblUsername    = new System.Windows.Forms.Label();
            this.txtUsername    = new System.Windows.Forms.TextBox();
            this.lblPassword    = new System.Windows.Forms.Label();
            this.txtPassword    = new System.Windows.Forms.TextBox();
            this.btnLogin       = new System.Windows.Forms.Button();
            this.lblHint        = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // ── Header Panel ────────────────────────────────────────────
            this.pnlHeader.BackColor  = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock       = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height     = 90;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.None;
            this.lblTitle.Text      = "Sarasavi Library";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(20, 15);
            this.lblTitle.Size      = new System.Drawing.Size(360, 35);

            this.lblSubtitle.AutoSize  = false;
            this.lblSubtitle.Text      = "Management System — Librarian Login";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(22, 52);
            this.lblSubtitle.Size      = new System.Drawing.Size(360, 20);

            // ── Body Panel ──────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding   = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlBody.Controls.Add(this.lblHint);
            this.pnlBody.Controls.Add(this.btnLogin);
            this.pnlBody.Controls.Add(this.txtPassword);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Controls.Add(this.txtUsername);
            this.pnlBody.Controls.Add(this.lblUsername);

            // Username
            this.lblUsername.AutoSize  = false;
            this.lblUsername.Text      = "Username";
            this.lblUsername.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblUsername.Location  = new System.Drawing.Point(30, 30);
            this.lblUsername.Size      = new System.Drawing.Size(340, 18);

            this.txtUsername.Location  = new System.Drawing.Point(30, 52);
            this.txtUsername.Name      = "txtUsername";
            this.txtUsername.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Size      = new System.Drawing.Size(340, 26);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.TabIndex  = 1;

            // Password
            this.lblPassword.AutoSize  = false;
            this.lblPassword.Text      = "Password";
            this.lblPassword.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblPassword.Location  = new System.Drawing.Point(30, 95);
            this.lblPassword.Size      = new System.Drawing.Size(340, 18);

            this.txtPassword.Location     = new System.Drawing.Point(30, 117);
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size         = new System.Drawing.Size(340, 26);
            this.txtPassword.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.TabIndex     = 2;

            // Hint
            this.lblHint.AutoSize  = false;
            this.lblHint.Text      = "Default credentials:  admin / admin";
            this.lblHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(120, 130, 150);
            this.lblHint.Location  = new System.Drawing.Point(30, 152);
            this.lblHint.Size      = new System.Drawing.Size(340, 18);

            // Login Button
            this.btnLogin.Location         = new System.Drawing.Point(30, 182);
            this.btnLogin.Name             = "btnLogin";
            this.btnLogin.Size             = new System.Drawing.Size(340, 38);
            this.btnLogin.TabIndex         = 3;
            this.btnLogin.Text             = "Login";
            this.btnLogin.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.BackColor        = System.Drawing.Color.FromArgb(30, 58, 138);
            this.btnLogin.ForeColor        = System.Drawing.Color.White;
            this.btnLogin.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click           += new System.EventHandler(this.btnLogin_Click);

            // ── Form ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(400, 370);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Sarasavi Library — Login";
            this.BackColor           = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel   pnlHeader;
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblSubtitle;
        private System.Windows.Forms.Panel   pnlBody;
        private System.Windows.Forms.Label   lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button  btnLogin;
        private System.Windows.Forms.Label   lblHint;
    }
}

