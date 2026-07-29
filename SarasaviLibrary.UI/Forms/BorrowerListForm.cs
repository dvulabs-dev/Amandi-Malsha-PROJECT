using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class BorrowerListForm : Form
    {
        private readonly UserService _userService;

        public BorrowerListForm()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var borrowers = _userService.GetAllBorrowers();
                dgvBorrowers.DataSource = borrowers;
                
                if (dgvBorrowers.Columns["ActiveLoans"] != null) dgvBorrowers.Columns["ActiveLoans"].Visible = false;
                if (dgvBorrowers.Columns["Reservations"] != null) dgvBorrowers.Columns["Reservations"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Borrowers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
