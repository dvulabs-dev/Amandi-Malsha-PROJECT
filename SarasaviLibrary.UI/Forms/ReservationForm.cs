using System;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class ReservationForm : Form
    {
        private ReservationService _reservationService;

        public ReservationForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUserNumber.Text, out int userNumber))
                {
                    MessageBox.Show("Please enter a valid User Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtTitleId.Text, out int titleId))
                {
                    MessageBox.Show("Please enter a valid Title ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var reservation = _reservationService.ReserveTitle(userNumber, titleId);

                MessageBox.Show($"Reservation queued successfully!\nReservation ID: {reservation.ReservationId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserNumber.Clear();
                txtTitleId.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
