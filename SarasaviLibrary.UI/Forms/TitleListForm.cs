using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class TitleListForm : Form
    {
        private readonly BookService _bookService;

        public TitleListForm()
        {
            InitializeComponent();
            _bookService = new BookService();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var titles = _bookService.GetAllTitles();
                dgvTitles.DataSource = titles;
                
                if (dgvTitles.Columns["Copies"] != null) dgvTitles.Columns["Copies"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Titles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
