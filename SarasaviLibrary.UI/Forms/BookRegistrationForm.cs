using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.UI.Forms
{
    public partial class BookRegistrationForm : Form
    {
        private BookService _bookService;

        public BookRegistrationForm()
        {
            InitializeComponent();
            _bookService = new BookService();
            this.Load += (s, e) => UIThemeHelper.ApplyDashboardTheme(this);
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
