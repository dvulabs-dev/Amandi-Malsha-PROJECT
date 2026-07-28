namespace SarasaviLibrary.UI.Forms
{
    partial class BorrowerListForm
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
            this.dgvBorrowers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).BeginInit();
            this.SuspendLayout();
            
            // 
            // dgvBorrowers
            // 
            this.dgvBorrowers.AllowUserToAddRows = false;
            this.dgvBorrowers.AllowUserToDeleteRows = false;
            this.dgvBorrowers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBorrowers.Location = new System.Drawing.Point(0, 0);
            this.dgvBorrowers.Name = "dgvBorrowers";
            this.dgvBorrowers.ReadOnly = true;
            this.dgvBorrowers.RowTemplate.Height = 25;
            this.dgvBorrowers.Size = new System.Drawing.Size(800, 450);
            this.dgvBorrowers.TabIndex = 0;
            
            // 
            // BorrowerListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBorrowers);
            this.Name = "BorrowerListForm";
            this.Text = "Registered Borrowers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvBorrowers;
    }
}
