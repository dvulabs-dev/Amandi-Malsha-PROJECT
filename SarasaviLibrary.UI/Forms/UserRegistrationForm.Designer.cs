namespace SarasaviLibrary.UI.Forms
{
    partial class UserRegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblTitle     = new System.Windows.Forms.Label();
            this.lblSubtitle  = new System.Windows.Forms.Label();
            this.pnlBody      = new System.Windows.Forms.Panel();
            this.lblName      = new System.Windows.Forms.Label();
            this.txtName      = new System.Windows.Forms.TextBox();
            this.lblAddress   = new System.Windows.Forms.Label();
            this.txtAddress   = new System.Windows.Forms.TextBox();
            this.lblSex       = new System.Windows.Forms.Label();
            this.cmbSex       = new System.Windows.Forms.ComboBox();
            this.lblNIC       = new System.Windows.Forms.Label();
            this.lblNICHint   = new System.Windows.Forms.Label();
            this.txtNIC       = new System.Windows.Forms.TextBox();
            this.pnlDivider   = new System.Windows.Forms.Panel();
            this.lblNote      = new System.Windows.Forms.Label();
            this.btnRegister  = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // ── Header ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 80;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Text      = "👤  Borrower Registration";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(18, 12);
            this.lblTitle.Size      = new System.Drawing.Size(400, 30);
            this.lblTitle.AutoSize  = false;

            this.lblSubtitle.Text      = "Fill in the details to register a new library borrower";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(20, 46);
            this.lblSubtitle.Size      = new System.Drawing.Size(400, 18);
            this.lblSubtitle.AutoSize  = false;

            // ── Body ────────────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Controls.Add(this.btnRegister);
            this.pnlBody.Controls.Add(this.lblNote);
            this.pnlBody.Controls.Add(this.pnlDivider);
            this.pnlBody.Controls.Add(this.txtNIC);
            this.pnlBody.Controls.Add(this.lblNICHint);
            this.pnlBody.Controls.Add(this.lblNIC);
            this.pnlBody.Controls.Add(this.cmbSex);
            this.pnlBody.Controls.Add(this.lblSex);
            this.pnlBody.Controls.Add(this.txtAddress);
            this.pnlBody.Controls.Add(this.lblAddress);
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.lblName);

            // Helper method for consistent label styling
            void StyleLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
            {
                lbl.AutoSize  = false;
                lbl.Text      = text;
                lbl.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
                lbl.Location  = new System.Drawing.Point(x, y);
                lbl.Size      = new System.Drawing.Size(380, 18);
            }
            void StyleInput(System.Windows.Forms.Control ctrl, int x, int y, int w = 380)
            {
                ctrl.Font     = new System.Drawing.Font("Segoe UI", 10F);
                ctrl.Location = new System.Drawing.Point(x, y);
                ctrl.Size     = new System.Drawing.Size(w, 26);
                if (ctrl is System.Windows.Forms.TextBox tb)
                    tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }

            StyleLabel(this.lblName, "Full Name  *", 25, 20);
            this.txtName.Name = "txtName";
            StyleInput(this.txtName, 25, 40);

            StyleLabel(this.lblAddress, "Address", 25, 78);
            this.txtAddress.Name = "txtAddress";
            StyleInput(this.txtAddress, 25, 98);

            StyleLabel(this.lblSex, "Gender", 25, 136);
            this.cmbSex.Name         = "cmbSex";
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSex.Location      = new System.Drawing.Point(25, 156);
            this.cmbSex.Size          = new System.Drawing.Size(200, 26);
            this.cmbSex.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;

            StyleLabel(this.lblNIC, "NIC / National ID  *", 25, 196);
            this.txtNIC.Name = "txtNIC";
            StyleInput(this.txtNIC, 25, 216);

            this.lblNICHint.AutoSize  = false;
            this.lblNICHint.Text      = "e.g. 991234567V or 199912345670";
            this.lblNICHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblNICHint.ForeColor = System.Drawing.Color.FromArgb(120, 130, 150);
            this.lblNICHint.Location  = new System.Drawing.Point(25, 244);
            this.lblNICHint.Size      = new System.Drawing.Size(380, 16);

            // Divider
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(220, 225, 235);
            this.pnlDivider.Location  = new System.Drawing.Point(25, 270);
            this.pnlDivider.Size      = new System.Drawing.Size(380, 1);

            // Note
            this.lblNote.AutoSize  = false;
            this.lblNote.Text      = "ℹ  After registration, the User Number will be shown — note it for loans.";
            this.lblNote.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(30, 80, 160);
            this.lblNote.Location  = new System.Drawing.Point(25, 278);
            this.lblNote.Size      = new System.Drawing.Size(380, 32);

            // Register Button
            this.btnRegister.Name             = "btnRegister";
            this.btnRegister.Text             = "Register Borrower";
            this.btnRegister.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.BackColor        = System.Drawing.Color.FromArgb(30, 58, 138);
            this.btnRegister.ForeColor        = System.Drawing.Color.White;
            this.btnRegister.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Location         = new System.Drawing.Point(25, 320);
            this.btnRegister.Size             = new System.Drawing.Size(380, 38);
            this.btnRegister.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Click           += new System.EventHandler(this.btnRegister_Click);

            // ── Form ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(430, 465);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Borrower Registration";
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
        private System.Windows.Forms.Label   lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label   lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label   lblSex;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.Label   lblNIC;
        private System.Windows.Forms.Label   lblNICHint;
        private System.Windows.Forms.TextBox txtNIC;
        private System.Windows.Forms.Panel   pnlDivider;
        private System.Windows.Forms.Label   lblNote;
        private System.Windows.Forms.Button  btnRegister;
    }
}
