using System;
using System.Linq;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class InquiryForm : Form
    {
        private InquiryService _inquiryService;

        public InquiryForm()
        {
            InitializeComponent();
            _inquiryService = new InquiryService();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    MessageBox.Show("Please enter a search query.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var results = _inquiryService.SearchCopies(txtSearch.Text);
                
                dgvResults.DataSource = results.Select(c => new {
                    BookNumber    = c.AccessionNumber,
                    Title         = c.Title.Name,
                    Author        = c.Title.AuthorNames,
                    Publisher     = c.Title.Publisher,
                    Classification = c.Title.Classification,
                    BookType      = c.Title.BookType.ToString(),
                    Availability  = c.Status.ToString()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
