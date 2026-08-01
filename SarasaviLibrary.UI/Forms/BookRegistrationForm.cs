using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.UI.Forms
{
    public partial class BookRegistrationForm : Form
    {
        private BookService _bookService;
        private int? _editingTitleId;

        public BookRegistrationForm()
        {
            InitializeComponent();
            _bookService = new BookService();
            this.Load += (s, e) => UIThemeHelper.ApplyDashboardTheme(this);
        }

        public BookRegistrationForm(SarasaviLibrary.Models.Entities.Title title) : this()
        {
            _editingTitleId = title.TitleId;
            txtISBN.Text = title.ISBN;
            txtName.Text = title.Name;
            txtAuthor.Text = title.AuthorNames;
            txtPublisher.Text = title.Publisher;
            txtClassification.Text = title.Classification;
            chkReferenceOnly.Checked = title.BookType == BookType.ReferenceOnly;
            
            // Disable copies count since we're just editing title info
            numCopies.Enabled = false;

            this.Load += (s, e) => {
                this.Text = "Update Book Title";
                foreach (Control c in this.Controls)
                {
                    if (c is Panel pnl)
                    {
                        foreach (Control inner in pnl.Controls)
                        {
                            if (inner is Label lbl && lbl.Text.Contains("Register"))
                                lbl.Text = "Update Book";
                            else if (inner is Button btn && btn.Text.Contains("Register"))
                                btn.Text = "Update";
                        }
                    }
                    if (c is Button mainBtn && mainBtn.Text.Contains("Register"))
                        mainBtn.Text = "Update";
                }
            };
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtISBN.Text) || string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("ISBN and Name are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int copies = (int)numCopies.Value;
                BookType bookType = chkReferenceOnly.Checked ? BookType.ReferenceOnly : BookType.Borrowable;
                
                if (_editingTitleId.HasValue)
                {
                    _bookService.UpdateTitle(
                        _editingTitleId.Value,
                        txtISBN.Text,
                        txtName.Text,
                        txtAuthor.Text,
                        txtPublisher.Text,
                        txtClassification.Text,
                        bookType
                    );
                    CustomMessageBox.Show($"Book Updated Successfully!", "Update Complete");
                    this.Close();
                }
                else
                {
                    var title = _bookService.RegisterTitle(
                        txtISBN.Text,
                        txtName.Text,
                        txtAuthor.Text,
                        txtPublisher.Text,
                        txtClassification.Text,
                        bookType
                    );

                    if (copies > 0)
                    {
                        _bookService.AddCopies(title.TitleId, copies, bookType);
                    }

                    CustomMessageBox.Show($"Title Registered Successfully!\n\nPrefix: {title.BookNumberPrefix}\nCopies Added: {copies}", "Registration Complete");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtISBN.Clear();
            txtName.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtClassification.Clear();
            numCopies.Value = 1;
            chkReferenceOnly.Checked = false;
        }
    }
}
