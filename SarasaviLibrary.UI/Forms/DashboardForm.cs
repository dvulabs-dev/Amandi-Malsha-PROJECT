using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;
using SarasaviLibrary.UI.Utilities;

namespace SarasaviLibrary.UI.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly UserService _userService;
        private readonly BookService _bookService;

        public DashboardForm()
        {
            InitializeComponent();
            _userService = new UserService();
            _bookService = new BookService();
            LoadData();
            ThemeUtility.ApplyModernTheme(this);
        }

        private void LoadData()
        {
            try
            {
                var borrowers = _userService.GetAllBorrowers();
                dgvBorrowers.DataSource = borrowers;
                if (dgvBorrowers.Columns["ActiveLoans"] != null) dgvBorrowers.Columns["ActiveLoans"].Visible = false;
                if (dgvBorrowers.Columns["Reservations"] != null) dgvBorrowers.Columns["Reservations"].Visible = false;

                var titles = _bookService.GetAllTitles();
                dgvTitles.DataSource = titles;
                if (dgvTitles.Columns["Copies"] != null) dgvTitles.Columns["Copies"].Visible = false;
                
                lblBorrowerCount.Text = borrowers.Count.ToString();
                lblBookCount.Text = titles.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
