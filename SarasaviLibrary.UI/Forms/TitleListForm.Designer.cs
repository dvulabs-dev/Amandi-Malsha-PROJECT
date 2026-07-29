namespace SarasaviLibrary.UI.Forms
{
    partial class TitleListForm
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
            this.dgvTitles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).BeginInit();
            this.SuspendLayout();
            
            // 
            // dgvTitles
            // 
            this.dgvTitles.AllowUserToAddRows = false;
            this.dgvTitles.AllowUserToDeleteRows = false;
            this.dgvTitles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTitles.Location = new System.Drawing.Point(0, 0);
            this.dgvTitles.Name = "dgvTitles";
            this.dgvTitles.ReadOnly = true;
            this.dgvTitles.RowTemplate.Height = 25;
            this.dgvTitles.Size = new System.Drawing.Size(800, 450);
            this.dgvTitles.TabIndex = 0;
            
            // 
            // TitleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTitles);
            this.Name = "TitleListForm";
            this.Text = "Registered Books (Titles)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvTitles;
    }
}
