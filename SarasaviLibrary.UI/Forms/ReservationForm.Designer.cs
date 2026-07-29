namespace SarasaviLibrary.UI.Forms
{
    partial class ReservationForm
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
            this.lblUserNumber = new System.Windows.Forms.Label();
            this.txtUserNumber = new System.Windows.Forms.TextBox();
            this.lblTitleSearch = new System.Windows.Forms.Label();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSelectTitle = new System.Windows.Forms.Label();
            this.cmbTitles = new System.Windows.Forms.ComboBox();
            this.btnReserve = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblUserNumber
            this.lblUserNumber.AutoSize = true;
            this.lblUserNumber.Location = new System.Drawing.Point(30, 30);
            this.lblUserNumber.Name = "lblUserNumber";
            this.lblUserNumber.TabIndex = 0;
            this.lblUserNumber.Text = "User Number:";

            // txtUserNumber
            this.txtUserNumber.Location = new System.Drawing.Point(150, 27);
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Size = new System.Drawing.Size(150, 23);
            this.txtUserNumber.TabIndex = 1;

            // lblTitleSearch
            this.lblTitleSearch.AutoSize = true;
            this.lblTitleSearch.Location = new System.Drawing.Point(30, 70);
            this.lblTitleSearch.Name = "lblTitleSearch";
            this.lblTitleSearch.TabIndex = 2;
            this.lblTitleSearch.Text = "Search Title / Author:";

            // txtTitleSearch
            this.txtTitleSearch.Location = new System.Drawing.Point(150, 67);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(200, 23);
            this.txtTitleSearch.TabIndex = 3;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(360, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // lblSelectTitle
            this.lblSelectTitle.AutoSize = true;
            this.lblSelectTitle.Location = new System.Drawing.Point(30, 110);
            this.lblSelectTitle.Name = "lblSelectTitle";
            this.lblSelectTitle.TabIndex = 5;
            this.lblSelectTitle.Text = "Select Title:";

            // cmbTitles
            this.cmbTitles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTitles.Location = new System.Drawing.Point(150, 107);
            this.cmbTitles.Name = "cmbTitles";
            this.cmbTitles.Size = new System.Drawing.Size(280, 23);
            this.cmbTitles.TabIndex = 6;

            // btnReserve
            this.btnReserve.Location = new System.Drawing.Point(150, 150);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(110, 30);
            this.btnReserve.TabIndex = 7;
            this.btnReserve.Text = "Reserve Title";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 210);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.cmbTitles);
            this.Controls.Add(this.lblSelectTitle);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTitleSearch);
            this.Controls.Add(this.lblTitleSearch);
            this.Controls.Add(this.txtUserNumber);
            this.Controls.Add(this.lblUserNumber);
            this.Name = "ReservationForm";
            this.Text = "Reserve Title";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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
