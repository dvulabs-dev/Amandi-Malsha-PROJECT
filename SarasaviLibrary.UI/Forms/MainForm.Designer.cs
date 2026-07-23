namespace SarasaviLibrary.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegisterUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegisterBook = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoanBook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReturnBook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReserveBook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInquiry = new System.Windows.Forms.ToolStripMenuItem();
            
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            
            // menuStrip1
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.registrationToolStripMenuItem,
            this.transactionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            
            // fileToolStripMenuItem
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuExit });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            
            // mnuExit
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(180, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            
            // registrationToolStripMenuItem
            this.registrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRegisterUser,
            this.mnuRegisterBook});
            this.registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
            this.registrationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.registrationToolStripMenuItem.Text = "Registration";
            
            // mnuRegisterUser
            this.mnuRegisterUser.Name = "mnuRegisterUser";
            this.mnuRegisterUser.Size = new System.Drawing.Size(180, 22);
            this.mnuRegisterUser.Text = "Register Borrower";
            this.mnuRegisterUser.Click += new System.EventHandler(this.mnuRegisterUser_Click);
            
            // mnuRegisterBook
            this.mnuRegisterBook.Name = "mnuRegisterBook";
            this.mnuRegisterBook.Size = new System.Drawing.Size(180, 22);
            this.mnuRegisterBook.Text = "Register Title";
            this.mnuRegisterBook.Click += new System.EventHandler(this.mnuRegisterBook_Click);
            
            // transactionsToolStripMenuItem
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoanBook,
            this.mnuReturnBook,
            this.mnuReserveBook,
            this.mnuInquiry});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            
            // mnuLoanBook
            this.mnuLoanBook.Name = "mnuLoanBook";
            this.mnuLoanBook.Size = new System.Drawing.Size(180, 22);
            this.mnuLoanBook.Text = "Loan Book";
            this.mnuLoanBook.Click += new System.EventHandler(this.mnuLoanBook_Click);
            
            // mnuReturnBook
            this.mnuReturnBook.Name = "mnuReturnBook";
            this.mnuReturnBook.Size = new System.Drawing.Size(180, 22);
            this.mnuReturnBook.Text = "Return Book";
            this.mnuReturnBook.Click += new System.EventHandler(this.mnuReturnBook_Click);
            
            // mnuReserveBook
            this.mnuReserveBook.Name = "mnuReserveBook";
            this.mnuReserveBook.Size = new System.Drawing.Size(180, 22);
            this.mnuReserveBook.Text = "Reserve Title";
            this.mnuReserveBook.Click += new System.EventHandler(this.mnuReserveBook_Click);
            
            // mnuInquiry
            this.mnuInquiry.Name = "mnuInquiry";
            this.mnuInquiry.Size = new System.Drawing.Size(180, 22);
            this.mnuInquiry.Text = "Book Inquiry";
            this.mnuInquiry.Click += new System.EventHandler(this.mnuInquiry_Click);
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Sarasavi Library Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem registrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuRegisterUser;
        private System.Windows.Forms.ToolStripMenuItem mnuRegisterBook;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLoanBook;
        private System.Windows.Forms.ToolStripMenuItem mnuReturnBook;
        private System.Windows.Forms.ToolStripMenuItem mnuReserveBook;
        private System.Windows.Forms.ToolStripMenuItem mnuInquiry;
    }
}
