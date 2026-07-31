namespace SarasaviLibrary.UI.Forms
{
    partial class LoanListForm
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
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnAddLoan = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.btnAddLoan);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.Location = new System.Drawing.Point(23, 45);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(161, 15);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "Manage ongoing book loans";
            // 
            // btnAddLoan
            // 
            this.btnAddLoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLoan.FlatAppearance.BorderSize = 0;
            this.btnAddLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddLoan.Location = new System.Drawing.Point(720, 20);
            this.btnAddLoan.Name = "btnAddLoan";
            this.btnAddLoan.Size = new System.Drawing.Size(160, 40);
            this.btnAddLoan.TabIndex = 2;
            this.btnAddLoan.Text = "+ Loan Book";
            this.btnAddLoan.UseVisualStyleBackColor = false;
            this.btnAddLoan.Click += new System.EventHandler(this.btnAddLoan_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Active Loans";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnReset);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 80);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(900, 60);
            this.pnlSearch.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(240, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 30);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(26, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search loans...";
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvLoans
            // 
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.AllowUserToResizeRows = false;
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(231)))), ((int)(((byte)(230)))));
            this.dgvLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLoans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLoans.ColumnHeadersHeight = 40;
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoans.EnableHeadersVisualStyles = false;
            this.dgvLoans.Location = new System.Drawing.Point(20, 140);
            this.dgvLoans.MultiSelect = false;
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.RowHeadersVisible = false;
            this.dgvLoans.RowTemplate.Height = 60;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(860, 310);
            this.dgvLoans.TabIndex = 1;
            this.dgvLoans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoans_CellContentClick);
            this.dgvLoans.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLoans_CellPainting);
            // 
            // LoanListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(231)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Name = "LoanListForm";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Active Loans";
            this.Load += new System.EventHandler(this.LoanListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnAddLoan;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReset;
    }
}
