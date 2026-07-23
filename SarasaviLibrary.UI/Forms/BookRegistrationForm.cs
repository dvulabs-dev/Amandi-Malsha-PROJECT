using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class BookRegistrationForm : Form
    {
        private BookService _bookService;

        public BookRegistrationForm()
        {
            InitializeComponent();
            _bookService = new BookService();
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
                
                var title = _bookService.RegisterTitle(
                    txtISBN.Text,
                    txtName.Text,
                    txtAuthor.Text,
                    txtPublisher.Text,
                    txtClassification.Text
                );

                if (copies > 0)
                {
                    _bookService.AddCopies(title.TitleId, copies, chkReferenceOnly.Checked);
                }

                MessageBox.Show($"Title Registered Successfully!\nPrefix: {title.BookNumberPrefix}\nCopies Added: {copies}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
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
