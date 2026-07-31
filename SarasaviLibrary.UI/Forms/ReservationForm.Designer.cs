namespace SarasaviLibrary.UI.Forms
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            
            this.lblUserNumber = new System.Windows.Forms.Label();
            this.txtUserNumber = new System.Windows.Forms.TextBox();
            this.lblTitleSearch = new System.Windows.Forms.Label();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSelectTitle = new System.Windows.Forms.Label();
            this.cmbTitles = new System.Windows.Forms.ComboBox();
            this.btnReserve = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // ── Header ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Text = "🔖  Reserve Title";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 12);
            this.lblTitle.Size = new System.Drawing.Size(420, 30);
            this.lblTitle.AutoSize = false;

            this.lblSubtitle.Text = "Reserve a title for a user if no copies are available";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location = new System.Drawing.Point(20, 46);
            this.lblSubtitle.Size = new System.Drawing.Size(420, 18);
            this.lblSubtitle.AutoSize = false;

            // ── Body ────────────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Controls.Add(this.lblUserNumber);
            this.pnlBody.Controls.Add(this.txtUserNumber);
            this.pnlBody.Controls.Add(this.lblTitleSearch);
            this.pnlBody.Controls.Add(this.txtTitleSearch);
            this.pnlBody.Controls.Add(this.btnSearch);
            this.pnlBody.Controls.Add(this.lblSelectTitle);
            this.pnlBody.Controls.Add(this.cmbTitles);
            this.pnlBody.Controls.Add(this.btnReserve);

            int lx = 25, fw = 400;

            // User Number
            this.lblUserNumber.Text = "User Number  *";
            this.lblUserNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserNumber.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblUserNumber.Location = new System.Drawing.Point(lx, 20);
            this.lblUserNumber.Size = new System.Drawing.Size(fw, 18);
            this.lblUserNumber.AutoSize = false;

            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserNumber.Location = new System.Drawing.Point(lx, 40);
            this.txtUserNumber.Size = new System.Drawing.Size(fw, 26);
            this.txtUserNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Search Title
            this.lblTitleSearch.Text = "Search Title / Author  *";
            this.lblTitleSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleSearch.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblTitleSearch.Location = new System.Drawing.Point(lx, 80);
            this.lblTitleSearch.Size = new System.Drawing.Size(fw, 18);
            this.lblTitleSearch.AutoSize = false;

            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitleSearch.Location = new System.Drawing.Point(lx, 100);
            this.txtTitleSearch.Size = new System.Drawing.Size(280, 26);
            this.txtTitleSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Text = "Search";
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(lx + 290, 99);
            this.btnSearch.Size = new System.Drawing.Size(110, 28);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Select Title
            this.lblSelectTitle.Text = "Select Title";
            this.lblSelectTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectTitle.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblSelectTitle.Location = new System.Drawing.Point(lx, 140);
            this.lblSelectTitle.Size = new System.Drawing.Size(fw, 18);
            this.lblSelectTitle.AutoSize = false;

            this.cmbTitles.Name = "cmbTitles";
            this.cmbTitles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTitles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTitles.Location = new System.Drawing.Point(lx, 160);
            this.cmbTitles.Size = new System.Drawing.Size(fw, 25);
            this.cmbTitles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // Reserve Button
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Text = "Reserve Title";
            this.btnReserve.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReserve.Location = new System.Drawing.Point(lx, 210);
            this.btnReserve.Size = new System.Drawing.Size(fw, 38);
            this.btnReserve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ReservationForm";
            this.Text = "Reserve Title";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlBody;

        private System.Windows.Forms.Label lblUserNumber;
        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Label lblTitleSearch;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSelectTitle;
        private System.Windows.Forms.ComboBox cmbTitles;
        private System.Windows.Forms.Button btnReserve;
    }
}
