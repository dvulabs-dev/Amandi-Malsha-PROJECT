namespace SarasaviLibrary.UI.Forms
{
    partial class InquiryForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlToggle = new System.Windows.Forms.Panel();
            this.btnToggleBook = new System.Windows.Forms.Button();
            this.btnToggleBorrower = new System.Windows.Forms.Button();
            this.pnlBookCard = new System.Windows.Forms.Panel();
            this.dgvBookResults = new System.Windows.Forms.DataGridView();
            this.btnBookSearch = new System.Windows.Forms.Button();
            this.pnlBookSearchContainer = new System.Windows.Forms.Panel();
            this.txtBookSearch = new System.Windows.Forms.TextBox();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.pnlBorrowerCard = new System.Windows.Forms.Panel();
            this.dgvBorrowerLoans = new System.Windows.Forms.DataGridView();
            this.pnlProfileStats = new System.Windows.Forms.Panel();
            this.lblStatOverdue = new System.Windows.Forms.Label();
            this.lblStatActive = new System.Windows.Forms.Label();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblProfileRegDate = new System.Windows.Forms.Label();
            this.lblProfileSex = new System.Windows.Forms.Label();
            this.lblProfileAddress = new System.Windows.Forms.Label();
            this.lblProfileNid = new System.Windows.Forms.Label();
            this.lblProfileUserNo = new System.Windows.Forms.Label();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.btnBorrowerSearch = new System.Windows.Forms.Button();
            this.pnlBorrowerSearchContainer = new System.Windows.Forms.Panel();
            this.txtBorrowerSearch = new System.Windows.Forms.TextBox();
            this.lblBorrowerTitle = new System.Windows.Forms.Label();
            
            this.pnlContent.SuspendLayout();
            this.pnlToggle.SuspendLayout();
            this.pnlBookCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookResults)).BeginInit();
            this.pnlBookSearchContainer.SuspendLayout();
            this.pnlBorrowerCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowerLoans)).BeginInit();
            this.pnlProfileStats.SuspendLayout();
            this.pnlBorrowerSearchContainer.SuspendLayout();
            this.SuspendLayout();

            //
            // pnlContent
            //
            this.pnlContent.Controls.Add(this.pnlBorrowerCard);
            this.pnlContent.Controls.Add(this.pnlBookCard);
            this.pnlContent.Controls.Add(this.pnlToggle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);

            // 
            // pnlToggle
            // 
            this.pnlToggle.Controls.Add(this.btnToggleBook);
            this.pnlToggle.Controls.Add(this.btnToggleBorrower);
            this.pnlToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToggle.Location = new System.Drawing.Point(0, 0);
            this.pnlToggle.Name = "pnlToggle";
            this.pnlToggle.Size = new System.Drawing.Size(1000, 60);
            this.pnlToggle.TabIndex = 0;

            // 
            // btnToggleBook
            // 
            this.btnToggleBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(54)))), ((int)(((byte)(129)))));
            this.btnToggleBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleBook.FlatAppearance.BorderSize = 0;
            this.btnToggleBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnToggleBook.ForeColor = System.Drawing.Color.White;
            this.btnToggleBook.Location = new System.Drawing.Point(20, 0);
            this.btnToggleBook.Name = "btnToggleBook";
            this.btnToggleBook.Size = new System.Drawing.Size(200, 50);
            this.btnToggleBook.TabIndex = 0;
            this.btnToggleBook.Text = "📚 Book Inquiry";
            this.btnToggleBook.UseVisualStyleBackColor = false;
            this.btnToggleBook.Click += new System.EventHandler(this.btnToggleBook_Click);
            this.btnToggleBook.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundedButton_Paint);

            // 
            // btnToggleBorrower
            // 
            this.btnToggleBorrower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.btnToggleBorrower.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleBorrower.FlatAppearance.BorderSize = 0;
            this.btnToggleBorrower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleBorrower.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnToggleBorrower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnToggleBorrower.Location = new System.Drawing.Point(230, 0);
            this.btnToggleBorrower.Name = "btnToggleBorrower";
            this.btnToggleBorrower.Size = new System.Drawing.Size(200, 50);
            this.btnToggleBorrower.TabIndex = 1;
            this.btnToggleBorrower.Text = "👥 Borrower Inquiry";
            this.btnToggleBorrower.UseVisualStyleBackColor = false;
            this.btnToggleBorrower.Click += new System.EventHandler(this.btnToggleBorrower_Click);
            this.btnToggleBorrower.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundedButton_Paint);

            // 
            // pnlBookCard
            // 
            this.pnlBookCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlBookCard.Controls.Add(this.dgvBookResults);
            this.pnlBookCard.Controls.Add(this.btnBookSearch);
            this.pnlBookCard.Controls.Add(this.pnlBookSearchContainer);
            this.pnlBookCard.Controls.Add(this.lblBookTitle);
            this.pnlBookCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBookCard.Location = new System.Drawing.Point(20, 80);
            this.pnlBookCard.Name = "pnlBookCard";
            this.pnlBookCard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBookCard.Size = new System.Drawing.Size(1060, 700);
            this.pnlBookCard.TabIndex = 1;

            // 
            // pnlBorrowerCard
            // 
            this.pnlBorrowerCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlBorrowerCard.Controls.Add(this.dgvBorrowerLoans);
            this.pnlBorrowerCard.Controls.Add(this.pnlProfileStats);
            this.pnlBorrowerCard.Controls.Add(this.btnBorrowerSearch);
            this.pnlBorrowerCard.Controls.Add(this.pnlBorrowerSearchContainer);
            this.pnlBorrowerCard.Controls.Add(this.lblBorrowerTitle);
            this.pnlBorrowerCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorrowerCard.Location = new System.Drawing.Point(20, 80);
            this.pnlBorrowerCard.Name = "pnlBorrowerCard";
            this.pnlBorrowerCard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBorrowerCard.Size = new System.Drawing.Size(1060, 700);
            this.pnlBorrowerCard.TabIndex = 2;
            this.pnlBorrowerCard.Visible = false;
            
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBookTitle.Location = new System.Drawing.Point(15, 20);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(155, 32);
            this.lblBookTitle.TabIndex = 0;
            this.lblBookTitle.Text = "Book Lookup";
            
            // 
            // txtBookSearch
            // 
            this.txtBookSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtBookSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBookSearch.Location = new System.Drawing.Point(20, 12);
            this.txtBookSearch.Name = "txtBookSearch";
            this.txtBookSearch.PlaceholderText = "Search by Title or Author";
            this.txtBookSearch.Size = new System.Drawing.Size(840, 20);
            this.txtBookSearch.TabIndex = 0;
            
            // 
            // pnlBookSearchContainer
            // 
            this.pnlBookSearchContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBookSearchContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlBookSearchContainer.Controls.Add(this.txtBookSearch);
            this.pnlBookSearchContainer.Location = new System.Drawing.Point(20, 75);
            this.pnlBookSearchContainer.Name = "pnlBookSearchContainer";
            this.pnlBookSearchContainer.Size = new System.Drawing.Size(880, 45);
            this.pnlBookSearchContainer.TabIndex = 1;
            this.pnlBookSearchContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundedTextBoxContainer_Paint);
            
            // 
            // btnBookSearch
            // 
            this.btnBookSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBookSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnBookSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookSearch.FlatAppearance.BorderSize = 0;
            this.btnBookSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBookSearch.ForeColor = System.Drawing.Color.White;
            this.btnBookSearch.Location = new System.Drawing.Point(920, 75);
            this.btnBookSearch.Name = "btnBookSearch";
            this.btnBookSearch.Size = new System.Drawing.Size(120, 45);
            this.btnBookSearch.TabIndex = 2;
            this.btnBookSearch.Text = "Look Up";
            this.btnBookSearch.UseVisualStyleBackColor = false;
            this.btnBookSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnBookSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundedButton_Paint);
            
            // 
            // dgvBookResults
            // 
            this.dgvBookResults.AllowUserToAddRows = false;
            this.dgvBookResults.AllowUserToDeleteRows = false;
            this.dgvBookResults.AllowUserToResizeRows = false;
            this.dgvBookResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBookResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBookResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBookResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBookResults.ColumnHeadersHeight = 40;
            this.dgvBookResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBookResults.EnableHeadersVisualStyles = false;
            this.dgvBookResults.Location = new System.Drawing.Point(20, 140);
            this.dgvBookResults.MultiSelect = false;
            this.dgvBookResults.Name = "dgvBookResults";
            this.dgvBookResults.ReadOnly = true;
            this.dgvBookResults.RowHeadersVisible = false;
            this.dgvBookResults.RowTemplate.Height = 50;
            this.dgvBookResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookResults.Size = new System.Drawing.Size(1020, 540);
            this.dgvBookResults.TabIndex = 4;
            this.dgvBookResults.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvBorrowerLoans_CellPainting);
            
            // 
            // dgvBorrowerLoans
            // 
            this.dgvBorrowerLoans.AllowUserToAddRows = false;
            this.dgvBorrowerLoans.AllowUserToDeleteRows = false;
            this.dgvBorrowerLoans.AllowUserToResizeRows = false;
            this.dgvBorrowerLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBorrowerLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowerLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvBorrowerLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBorrowerLoans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBorrowerLoans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBorrowerLoans.ColumnHeadersHeight = 40;
            this.dgvBorrowerLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBorrowerLoans.EnableHeadersVisualStyles = false;
            this.dgvBorrowerLoans.Location = new System.Drawing.Point(20, 300);
            this.dgvBorrowerLoans.MultiSelect = false;
            this.dgvBorrowerLoans.Name = "dgvBorrowerLoans";
            this.dgvBorrowerLoans.ReadOnly = true;
            this.dgvBorrowerLoans.RowHeadersVisible = false;
            this.dgvBorrowerLoans.RowTemplate.Height = 50;
            this.dgvBorrowerLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowerLoans.Size = new System.Drawing.Size(1020, 380);
            this.dgvBorrowerLoans.TabIndex = 4;
            this.dgvBorrowerLoans.Visible = false;
            this.dgvBorrowerLoans.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvBorrowerLoans_CellPainting);
            
            // 
            // pnlProfileStats
            // 
            this.pnlProfileStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProfileStats.Controls.Add(this.lblStatOverdue);
            this.pnlProfileStats.Controls.Add(this.lblStatActive);
            this.pnlProfileStats.Controls.Add(this.lblStatTotal);
            this.pnlProfileStats.Controls.Add(this.lblProfileRegDate);
            this.pnlProfileStats.Controls.Add(this.lblProfileSex);
            this.pnlProfileStats.Controls.Add(this.lblProfileAddress);
            this.pnlProfileStats.Controls.Add(this.lblProfileNid);
            this.pnlProfileStats.Controls.Add(this.lblProfileUserNo);
            this.pnlProfileStats.Controls.Add(this.lblProfileName);
            this.pnlProfileStats.Location = new System.Drawing.Point(20, 140);
            this.pnlProfileStats.Name = "pnlProfileStats";
            this.pnlProfileStats.Size = new System.Drawing.Size(1020, 150);
            this.pnlProfileStats.TabIndex = 3;
            this.pnlProfileStats.Visible = false;
            
            // 
            // lblStatOverdue
            // 
            this.lblStatOverdue.AutoSize = true;
            this.lblStatOverdue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatOverdue.Location = new System.Drawing.Point(280, 120);
            this.lblStatOverdue.Name = "lblStatOverdue";
            this.lblStatOverdue.Size = new System.Drawing.Size(84, 19);
            this.lblStatOverdue.TabIndex = 8;
            this.lblStatOverdue.Text = "Overdue";
            
            // 
            // lblStatActive
            // 
            this.lblStatActive.AutoSize = true;
            this.lblStatActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatActive.Location = new System.Drawing.Point(140, 120);
            this.lblStatActive.Name = "lblStatActive";
            this.lblStatActive.Size = new System.Drawing.Size(46, 19);
            this.lblStatActive.TabIndex = 7;
            this.lblStatActive.Text = "Active";
            
            // 
            // lblStatTotal
            // 
            this.lblStatTotal.AutoSize = true;
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatTotal.Location = new System.Drawing.Point(5, 120);
            this.lblStatTotal.Name = "lblStatTotal";
            this.lblStatTotal.Size = new System.Drawing.Size(38, 19);
            this.lblStatTotal.TabIndex = 6;
            this.lblStatTotal.Text = "Total";
            
            // 
            // lblProfileRegDate
            // 
            this.lblProfileRegDate.AutoSize = true;
            this.lblProfileRegDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProfileRegDate.ForeColor = System.Drawing.Color.Gray;
            this.lblProfileRegDate.Location = new System.Drawing.Point(280, 85);
            this.lblProfileRegDate.Name = "lblProfileRegDate";
            this.lblProfileRegDate.Size = new System.Drawing.Size(73, 17);
            this.lblProfileRegDate.TabIndex = 5;
            this.lblProfileRegDate.Text = "Registered:";
            
            // 
            // lblProfileSex
            // 
            this.lblProfileSex.AutoSize = true;
            this.lblProfileSex.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProfileSex.ForeColor = System.Drawing.Color.Gray;
            this.lblProfileSex.Location = new System.Drawing.Point(5, 85);
            this.lblProfileSex.Name = "lblProfileSex";
            this.lblProfileSex.Size = new System.Drawing.Size(31, 17);
            this.lblProfileSex.TabIndex = 4;
            this.lblProfileSex.Text = "Sex:";
            
            // 
            // lblProfileAddress
            // 
            this.lblProfileAddress.AutoSize = true;
            this.lblProfileAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProfileAddress.ForeColor = System.Drawing.Color.Gray;
            this.lblProfileAddress.Location = new System.Drawing.Point(5, 60);
            this.lblProfileAddress.Name = "lblProfileAddress";
            this.lblProfileAddress.Size = new System.Drawing.Size(59, 17);
            this.lblProfileAddress.TabIndex = 3;
            this.lblProfileAddress.Text = "Address:";
            
            // 
            // lblProfileNid
            // 
            this.lblProfileNid.AutoSize = true;
            this.lblProfileNid.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProfileNid.ForeColor = System.Drawing.Color.Gray;
            this.lblProfileNid.Location = new System.Drawing.Point(280, 35);
            this.lblProfileNid.Name = "lblProfileNid";
            this.lblProfileNid.Size = new System.Drawing.Size(78, 17);
            this.lblProfileNid.TabIndex = 2;
            this.lblProfileNid.Text = "National ID:";
            
            // 
            // lblProfileUserNo
            // 
            this.lblProfileUserNo.AutoSize = true;
            this.lblProfileUserNo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProfileUserNo.ForeColor = System.Drawing.Color.Gray;
            this.lblProfileUserNo.Location = new System.Drawing.Point(5, 35);
            this.lblProfileUserNo.Name = "lblProfileUserNo";
            this.lblProfileUserNo.Size = new System.Drawing.Size(56, 17);
            this.lblProfileUserNo.TabIndex = 1;
            this.lblProfileUserNo.Text = "User No:";
            
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProfileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblProfileName.Location = new System.Drawing.Point(0, 0);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(182, 30);
            this.lblProfileName.TabIndex = 0;
            this.lblProfileName.Text = "Borrower Name";
            
            // 
            // btnBorrowerSearch
            // 
            this.btnBorrowerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrowerSearch.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnBorrowerSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrowerSearch.FlatAppearance.BorderSize = 0;
            this.btnBorrowerSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowerSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBorrowerSearch.ForeColor = System.Drawing.Color.White;
            this.btnBorrowerSearch.Location = new System.Drawing.Point(920, 75);
            this.btnBorrowerSearch.Name = "btnBorrowerSearch";
            this.btnBorrowerSearch.Size = new System.Drawing.Size(120, 45);
            this.btnBorrowerSearch.TabIndex = 2;
            this.btnBorrowerSearch.Text = "Look Up";
            this.btnBorrowerSearch.UseVisualStyleBackColor = false;
            this.btnBorrowerSearch.Click += new System.EventHandler(this.btnBorrowerSearch_Click);
            this.btnBorrowerSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundedButton_Paint);
            
            // 
            // pnlBorrowerSearchContainer
            // 
            this.pnlBorrowerSearchContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBorrowerSearchContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlBorrowerSearchContainer.Controls.Add(this.txtBorrowerSearch);
            this.pnlBorrowerSearchContainer.Location = new System.Drawing.Point(20, 75);
            this.pnlBorrowerSearchContainer.Name = "pnlBorrowerSearchContainer";
            this.pnlBorrowerSearchContainer.Size = new System.Drawing.Size(880, 45);
            this.pnlBorrowerSearchContainer.TabIndex = 1;
            this.pnlBorrowerSearchContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.RoundedTextBoxContainer_Paint);
            
            // 
            // txtBorrowerSearch
            // 
            this.txtBorrowerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBorrowerSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtBorrowerSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBorrowerSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBorrowerSearch.Location = new System.Drawing.Point(20, 12);
            this.txtBorrowerSearch.Name = "txtBorrowerSearch";
            this.txtBorrowerSearch.PlaceholderText = "Search by User No or NIC";
            this.txtBorrowerSearch.Size = new System.Drawing.Size(840, 20);
            this.txtBorrowerSearch.TabIndex = 0;
            
            // 
            // lblBorrowerTitle
            // 
            this.lblBorrowerTitle.AutoSize = true;
            this.lblBorrowerTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBorrowerTitle.Location = new System.Drawing.Point(15, 20);
            this.lblBorrowerTitle.Name = "lblBorrowerTitle";
            this.lblBorrowerTitle.Size = new System.Drawing.Size(213, 32);
            this.lblBorrowerTitle.TabIndex = 0;
            this.lblBorrowerTitle.Text = "Borrower Lookup";
            
            // 
            // InquiryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.Controls.Add(this.pnlContent);
            this.Name = "InquiryForm";
            this.Text = "Inquiry Dashboard";
            
            this.pnlContent.ResumeLayout(false);
            this.pnlToggle.ResumeLayout(false);
            this.pnlBookCard.ResumeLayout(false);
            this.pnlBookCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookResults)).EndInit();
            this.pnlBookSearchContainer.ResumeLayout(false);
            this.pnlBookSearchContainer.PerformLayout();
            this.pnlBorrowerCard.ResumeLayout(false);
            this.pnlBorrowerCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowerLoans)).EndInit();
            this.pnlProfileStats.ResumeLayout(false);
            this.pnlProfileStats.PerformLayout();
            this.pnlBorrowerSearchContainer.ResumeLayout(false);
            this.pnlBorrowerSearchContainer.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlToggle;
        private System.Windows.Forms.Button btnToggleBook;
        private System.Windows.Forms.Button btnToggleBorrower;
        private System.Windows.Forms.Panel pnlBookCard;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Panel pnlBookSearchContainer;
        private System.Windows.Forms.TextBox txtBookSearch;
        private System.Windows.Forms.Button btnBookSearch;
        private System.Windows.Forms.DataGridView dgvBookResults;
        private System.Windows.Forms.Panel pnlBorrowerCard;
        private System.Windows.Forms.Label lblBorrowerTitle;
        private System.Windows.Forms.Panel pnlBorrowerSearchContainer;
        private System.Windows.Forms.TextBox txtBorrowerSearch;
        private System.Windows.Forms.Button btnBorrowerSearch;
        private System.Windows.Forms.Panel pnlProfileStats;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Label lblProfileUserNo;
        private System.Windows.Forms.Label lblProfileNid;
        private System.Windows.Forms.Label lblProfileAddress;
        private System.Windows.Forms.Label lblProfileSex;
        private System.Windows.Forms.Label lblProfileRegDate;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatActive;
        private System.Windows.Forms.Label lblStatOverdue;
        private System.Windows.Forms.DataGridView dgvBorrowerLoans;
    }
}
