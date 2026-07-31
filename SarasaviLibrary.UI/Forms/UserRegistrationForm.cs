using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.UI.Forms
{
    public partial class UserRegistrationForm : Form
    {
        private UserService _userService;
        private int? _editingBorrowerId;

        public UserRegistrationForm()
        {
            InitializeComponent();
            _userService = new UserService();
            cmbSex.DataSource = Enum.GetValues(typeof(Sex));
            this.Load += (s, e) => UIThemeHelper.ApplyDashboardTheme(this);
        }

        public UserRegistrationForm(SarasaviLibrary.Models.Entities.Borrower borrower) : this()
        {
            _editingBorrowerId = borrower.Id;
            txtName.Text = borrower.Name;
            txtAddress.Text = borrower.Address;
            cmbSex.SelectedItem = borrower.Sex;
            txtNIC.Text = borrower.NationalId;

            this.Load += (s, e) => {
                this.Text = "Update Borrower";
                // Optionally find the title label and update its text
                foreach (Control c in this.Controls)
                {
                    if (c is Panel pnl)
                    {
                        foreach (Control inner in pnl.Controls)
                        {
                            if (inner is Label lbl && lbl.Text.Contains("Register"))
                                lbl.Text = "Update Borrower";
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
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtNIC.Text))
                {
                    MessageBox.Show("Name and NIC are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_editingBorrowerId.HasValue)
                {
                    _userService.UpdateBorrower(
                        _editingBorrowerId.Value,
                        txtName.Text,
                        txtAddress.Text,
                        (Sex)(cmbSex.SelectedItem ?? Sex.Male),
                        txtNIC.Text
                    );
                    CustomMessageBox.Show($"Borrower Updated Successfully!", "Update Complete");
                    this.Close();
                }
                else
                {
                    var borrower = _userService.RegisterBorrower(
                        txtName.Text,
                        txtAddress.Text,
                        (Sex)(cmbSex.SelectedItem ?? Sex.Male),
                        txtNIC.Text
                    );

                    CustomMessageBox.Show($"Borrower Registered Successfully!\n\nUser Number: {borrower.UserNumber}", "Registration Complete");
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
            txtName.Clear();
            txtAddress.Clear();
            txtNIC.Clear();
            cmbSex.SelectedIndex = 0;
        }
    }
}
