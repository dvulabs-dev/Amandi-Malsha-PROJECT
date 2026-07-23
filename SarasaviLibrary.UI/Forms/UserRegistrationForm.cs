using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.UI.Forms
{
    public partial class UserRegistrationForm : Form
    {
        private UserService _userService;

        public UserRegistrationForm()
        {
            InitializeComponent();
            _userService = new UserService();
            cmbSex.DataSource = Enum.GetValues(typeof(Sex));
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtNIC.Text))
                {
                    MessageBox.Show("Name and NIC are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var borrower = _userService.RegisterBorrower(
                    txtName.Text,
                    txtAddress.Text,
                    (Sex)cmbSex.SelectedItem,
                    txtNIC.Text
                );

                MessageBox.Show($"Borrower Registered Successfully!\nUser Number: {borrower.UserNumber}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtNIC.Clear();
            cmbSex.SelectedIndex = 0;
        }
    }
}
