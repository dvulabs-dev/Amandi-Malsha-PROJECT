namespace SarasaviLibrary.UI.Forms
{
    partial class BookRegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader        = new System.Windows.Forms.Panel();
            this.lblTitle         = new System.Windows.Forms.Label();
            this.lblSubtitle      = new System.Windows.Forms.Label();
            this.pnlBody          = new System.Windows.Forms.Panel();
            this.lblISBN          = new System.Windows.Forms.Label();
            this.txtISBN          = new System.Windows.Forms.TextBox();
            this.lblName          = new System.Windows.Forms.Label();
            this.txtName          = new System.Windows.Forms.TextBox();
            this.lblAuthor        = new System.Windows.Forms.Label();
            this.txtAuthor        = new System.Windows.Forms.TextBox();
            this.lblPublisher     = new System.Windows.Forms.Label();
            this.txtPublisher     = new System.Windows.Forms.TextBox();
            this.lblClassification     = new System.Windows.Forms.Label();
            this.lblClassificationHint = new System.Windows.Forms.Label();
            this.txtClassification     = new System.Windows.Forms.TextBox();
            this.lblCopies        = new System.Windows.Forms.Label();
            this.numCopies        = new System.Windows.Forms.NumericUpDown();
            this.chkReferenceOnly = new System.Windows.Forms.CheckBox();
            this.pnlDivider       = new System.Windows.Forms.Panel();
            this.btnRegister      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // ── Header ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 80;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Text      = "Book Registration";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(18, 12);
            this.lblTitle.Size      = new System.Drawing.Size(420, 30);
            this.lblTitle.AutoSize  = false;

            this.lblSubtitle.Text      = "Add a new book title and copies to the library catalogue";
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(20, 46);
            this.lblSubtitle.Size      = new System.Drawing.Size(420, 18);
            this.lblSubtitle.AutoSize  = false;

            // ── Body ────────────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Controls.Add(this.btnRegister);
            this.pnlBody.Controls.Add(this.pnlDivider);
            this.pnlBody.Controls.Add(this.chkReferenceOnly);
            this.pnlBody.Controls.Add(this.numCopies);
            this.pnlBody.Controls.Add(this.lblCopies);
            this.pnlBody.Controls.Add(this.txtClassification);
            this.pnlBody.Controls.Add(this.lblClassificationHint);
            this.pnlBody.Controls.Add(this.lblClassification);
            this.pnlBody.Controls.Add(this.txtPublisher);
            this.pnlBody.Controls.Add(this.lblPublisher);
            this.pnlBody.Controls.Add(this.txtAuthor);
            this.pnlBody.Controls.Add(this.lblAuthor);
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.lblName);
            this.pnlBody.Controls.Add(this.txtISBN);
            this.pnlBody.Controls.Add(this.lblISBN);

            int lx = 25, fw = 400, lh = 18, th = 26;
            int y = 18;

            void AddField(System.Windows.Forms.Label lbl, string text, System.Windows.Forms.Control input)
            {
                lbl.AutoSize  = false;
                lbl.Text      = text;
                lbl.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
                lbl.Location  = new System.Drawing.Point(lx, y);
                lbl.Size      = new System.Drawing.Size(fw, lh);
                y += lh + 2;
                input.Font     = new System.Drawing.Font("Segoe UI", 10F);
                input.Location = new System.Drawing.Point(lx, y);
                input.Size     = new System.Drawing.Size(fw, th);
                if (input is System.Windows.Forms.TextBox tb) tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                y += th + 14;
            }

            this.txtISBN.Name = "txtISBN";
            AddField(this.lblISBN, "ISBN  *", this.txtISBN);

            this.txtName.Name = "txtName";
            AddField(this.lblName, "Title / Book Name  *", this.txtName);

            this.txtAuthor.Name = "txtAuthor";
            AddField(this.lblAuthor, "Author(s)", this.txtAuthor);

            this.txtPublisher.Name = "txtPublisher";
            AddField(this.lblPublisher, "Publisher", this.txtPublisher);

            this.lblClassification.AutoSize  = false;
            this.lblClassification.Text      = "Classification Code  *";
            this.lblClassification.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClassification.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblClassification.Location  = new System.Drawing.Point(lx, y);
            this.lblClassification.Size      = new System.Drawing.Size(fw, lh);
            y += lh + 2;

            this.lblClassificationHint.AutoSize  = false;
            this.lblClassificationHint.Text      = "Single letter used to generate book number (e.g. 'F' → F0001)";
            this.lblClassificationHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblClassificationHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblClassificationHint.Location  = new System.Drawing.Point(lx, y);
            this.lblClassificationHint.Size      = new System.Drawing.Size(fw, 16);
            y += 18;

            this.txtClassification.Name        = "txtClassification";
            this.txtClassification.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassification.Location    = new System.Drawing.Point(lx, y);
            this.txtClassification.Size        = new System.Drawing.Size(fw, th);
            this.txtClassification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            y += th + 16;

            // Divider
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(220, 225, 235);
            this.pnlDivider.Location  = new System.Drawing.Point(lx, y);
            this.pnlDivider.Size      = new System.Drawing.Size(fw, 1);
            y += 10;

            // Copies + Reference Only row
            this.lblCopies.AutoSize  = false;
            this.lblCopies.Text      = "Number of Copies";
            this.lblCopies.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCopies.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblCopies.Location  = new System.Drawing.Point(lx, y + 4);
            this.lblCopies.Size      = new System.Drawing.Size(150, 18);

            this.numCopies.Location = new System.Drawing.Point(180, y);
            this.numCopies.Minimum  = new decimal(new int[] { 0, 0, 0, 0 });
            this.numCopies.Maximum  = new decimal(new int[] { 100, 0, 0, 0 });
            this.numCopies.Value    = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCopies.Name     = "numCopies";
            this.numCopies.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.numCopies.Size     = new System.Drawing.Size(70, 26);

            this.chkReferenceOnly.Text      = "Reference Only";
            this.chkReferenceOnly.Name      = "chkReferenceOnly";
            this.chkReferenceOnly.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkReferenceOnly.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
            this.chkReferenceOnly.Location  = new System.Drawing.Point(265, y + 2);
            this.chkReferenceOnly.Size      = new System.Drawing.Size(160, 22);
            this.chkReferenceOnly.AutoSize  = false;
            y += 42;

            // Register Button
            this.btnRegister.Name             = "btnRegister";
            this.btnRegister.Text             = "Register Title & Copies";
            this.btnRegister.Font             = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.BackColor        = System.Drawing.Color.FromArgb(30, 58, 138);
            this.btnRegister.ForeColor        = System.Drawing.Color.White;
            this.btnRegister.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Location         = new System.Drawing.Point(lx, y);
            this.btnRegister.Size             = new System.Drawing.Size(fw, 38);
            this.btnRegister.Cursor           = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Click           += new System.EventHandler(this.btnRegister_Click);

            int formHeight = 80 + y + 38 + 20;

            // ── Form ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(450, formHeight);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Book Registration";
            this.BackColor           = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel        pnlHeader;
        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Label        lblSubtitle;
        private System.Windows.Forms.Panel        pnlBody;
        private System.Windows.Forms.Label        lblISBN;
        private System.Windows.Forms.TextBox      txtISBN;
        private System.Windows.Forms.Label        lblName;
        private System.Windows.Forms.TextBox      txtName;
        private System.Windows.Forms.Label        lblAuthor;
        private System.Windows.Forms.TextBox      txtAuthor;
        private System.Windows.Forms.Label        lblPublisher;
        private System.Windows.Forms.TextBox      txtPublisher;
        private System.Windows.Forms.Label        lblClassification;
        private System.Windows.Forms.Label        lblClassificationHint;
        private System.Windows.Forms.TextBox      txtClassification;
        private System.Windows.Forms.Label        lblCopies;
        private System.Windows.Forms.NumericUpDown numCopies;
        private System.Windows.Forms.CheckBox     chkReferenceOnly;
        private System.Windows.Forms.Panel        pnlDivider;
        private System.Windows.Forms.Button       btnRegister;
    }
}

