namespace SarasaviLibrary.UI.Forms
{
    partial class DashboardForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBorrowerTitle = new System.Windows.Forms.Label();
            this.lblBorrowerCount = new System.Windows.Forms.Label();
            this.dgvBorrowers = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblBookCount = new System.Windows.Forms.Label();
            this.dgvTitles = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).BeginInit();
            this.SuspendLayout();
            
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            
            // 
            // panel1 (Borrowers)
            // 
            this.panel1.Controls.Add(this.dgvBorrowers);
            this.panel1.Controls.Add(this.lblBorrowerCount);
            this.panel1.Controls.Add(this.lblBorrowerTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 580);
            this.panel1.TabIndex = 0;
            
            // 
            // lblBorrowerTitle
            // 
            this.lblBorrowerTitle.AutoSize = true;
            this.lblBorrowerTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBorrowerTitle.Location = new System.Drawing.Point(10, 15);
            this.lblBorrowerTitle.Name = "lblBorrowerTitle";
            this.lblBorrowerTitle.Size = new System.Drawing.Size(236, 30);
            this.lblBorrowerTitle.TabIndex = 0;
            this.lblBorrowerTitle.Text = "Registered Borrowers";
            
            // 
            // lblBorrowerCount
            // 
            this.lblBorrowerCount.AutoSize = true;
            this.lblBorrowerCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBorrowerCount.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblBorrowerCount.Location = new System.Drawing.Point(400, 15);
            this.lblBorrowerCount.Name = "lblBorrowerCount";
            this.lblBorrowerCount.Size = new System.Drawing.Size(26, 30);
            this.lblBorrowerCount.TabIndex = 1;
            this.lblBorrowerCount.Text = "0";
            
            // 
            // dgvBorrowers
            // 
            this.dgvBorrowers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBorrowers.AllowUserToAddRows = false;
            this.dgvBorrowers.AllowUserToDeleteRows = false;
            this.dgvBorrowers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowers.Location = new System.Drawing.Point(10, 60);
            this.dgvBorrowers.Name = "dgvBorrowers";
            this.dgvBorrowers.ReadOnly = true;
            this.dgvBorrowers.Size = new System.Drawing.Size(460, 510);
            this.dgvBorrowers.TabIndex = 2;
            
            // 
            // panel2 (Books)
            // 
            this.panel2.Controls.Add(this.dgvTitles);
            this.panel2.Controls.Add(this.lblBookCount);
            this.panel2.Controls.Add(this.lblBookTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(510, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 580);
            this.panel2.TabIndex = 1;
            
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBookTitle.Location = new System.Drawing.Point(10, 15);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(193, 30);
            this.lblBookTitle.TabIndex = 0;
            this.lblBookTitle.Text = "Registered Books";
            
            // 
            // lblBookCount
            // 
            this.lblBookCount.AutoSize = true;
            this.lblBookCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBookCount.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblBookCount.Location = new System.Drawing.Point(400, 15);
            this.lblBookCount.Name = "lblBookCount";
            this.lblBookCount.Size = new System.Drawing.Size(26, 30);
            this.lblBookCount.TabIndex = 1;
            this.lblBookCount.Text = "0";
            
            // 
            // dgvTitles
            // 
            this.dgvTitles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTitles.AllowUserToAddRows = false;
            this.dgvTitles.AllowUserToDeleteRows = false;
            this.dgvTitles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitles.Location = new System.Drawing.Point(10, 60);
            this.dgvTitles.Name = "dgvTitles";
            this.dgvTitles.ReadOnly = true;
            this.dgvTitles.Size = new System.Drawing.Size(460, 510);
            this.dgvTitles.TabIndex = 2;
            
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBorrowerTitle;
        private System.Windows.Forms.Label lblBorrowerCount;
        private System.Windows.Forms.DataGridView dgvBorrowers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblBookCount;
        private System.Windows.Forms.DataGridView dgvTitles;
    }
}
