namespace SarasaviLibrary.UI.Forms
{
    partial class BookRegistrationForm
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
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.lblClassification = new System.Windows.Forms.Label();
            this.txtClassification = new System.Windows.Forms.TextBox();
            this.lblCopies = new System.Windows.Forms.Label();
            this.numCopies = new System.Windows.Forms.NumericUpDown();
            this.chkReferenceOnly = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
            this.SuspendLayout();
            
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(30, 30);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(35, 15);
            this.lblISBN.TabIndex = 0;
            this.lblISBN.Text = "ISBN:";
            
            this.txtISBN.Location = new System.Drawing.Point(130, 27);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(200, 23);
            this.txtISBN.TabIndex = 1;
            
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 15);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            
            this.txtName.Location = new System.Drawing.Point(130, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 3;
            
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(30, 110);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(47, 15);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Author:";
            
            this.txtAuthor.Location = new System.Drawing.Point(130, 107);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(200, 23);
            this.txtAuthor.TabIndex = 5;
            
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(30, 150);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(59, 15);
            this.lblPublisher.TabIndex = 6;
            this.lblPublisher.Text = "Publisher:";
            
            this.txtPublisher.Location = new System.Drawing.Point(130, 147);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(200, 23);
            this.txtPublisher.TabIndex = 7;
            
            this.lblClassification.AutoSize = true;
            this.lblClassification.Location = new System.Drawing.Point(30, 190);
            this.lblClassification.Name = "lblClassification";
            this.lblClassification.Size = new System.Drawing.Size(80, 15);
            this.lblClassification.TabIndex = 8;
            this.lblClassification.Text = "Classification:";
            
            this.txtClassification.Location = new System.Drawing.Point(130, 187);
            this.txtClassification.Name = "txtClassification";
            this.txtClassification.Size = new System.Drawing.Size(200, 23);
            this.txtClassification.TabIndex = 9;
            
            this.lblCopies.AutoSize = true;
            this.lblCopies.Location = new System.Drawing.Point(30, 230);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Size = new System.Drawing.Size(46, 15);
            this.lblCopies.TabIndex = 10;
            this.lblCopies.Text = "Copies:";
            
            this.numCopies.Location = new System.Drawing.Point(130, 227);
            this.numCopies.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numCopies.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numCopies.Name = "numCopies";
            this.numCopies.Size = new System.Drawing.Size(60, 23);
            this.numCopies.TabIndex = 11;
            this.numCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });
            
            this.chkReferenceOnly.AutoSize = true;
            this.chkReferenceOnly.Location = new System.Drawing.Point(210, 229);
            this.chkReferenceOnly.Name = "chkReferenceOnly";
            this.chkReferenceOnly.Size = new System.Drawing.Size(106, 19);
            this.chkReferenceOnly.TabIndex = 12;
            this.chkReferenceOnly.Text = "Reference Only";
            this.chkReferenceOnly.UseVisualStyleBackColor = true;
            
            this.btnRegister.Location = new System.Drawing.Point(130, 270);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 30);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 341);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.chkReferenceOnly);
            this.Controls.Add(this.numCopies);
            this.Controls.Add(this.lblCopies);
            this.Controls.Add(this.txtClassification);
            this.Controls.Add(this.lblClassification);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblISBN);
            this.Name = "BookRegistrationForm";
            this.Text = "Book Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label lblClassification;
        private System.Windows.Forms.TextBox txtClassification;
        private System.Windows.Forms.Label lblCopies;
        private System.Windows.Forms.NumericUpDown numCopies;
        private System.Windows.Forms.CheckBox chkReferenceOnly;
        private System.Windows.Forms.Button btnRegister;
    }
}
