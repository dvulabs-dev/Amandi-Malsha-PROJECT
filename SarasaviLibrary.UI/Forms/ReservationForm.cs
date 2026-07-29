using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;
using SarasaviLibrary.Models.Entities;

namespace SarasaviLibrary.UI.Forms
{
    public partial class ReservationForm : Form
    {
        private ReservationService _reservationService;
        private InquiryService _inquiryService;

        // Holds the titles found by the last search so we can retrieve TitleId by selection
        private List<Title> _searchResults = new List<Title>();

        public ReservationForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
            _inquiryService = new InquiryService();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtTitleSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a title or author name to search.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _searchResults = _inquiryService.SearchTitles(query);

            cmbTitles.Items.Clear();
            if (_searchResults.Count == 0)
            {
                MessageBox.Show("No titles found matching that search.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var title in _searchResults)
            {
                cmbTitles.Items.Add($"{title.BookNumberPrefix} — {title.Name} by {title.AuthorNames}");
            }
            cmbTitles.SelectedIndex = 0;
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUserNumber.Text, out int userNumber))
                {
                    MessageBox.Show("Please enter a valid User Number.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbTitles.SelectedIndex < 0 || _searchResults.Count == 0)
                {
                    MessageBox.Show("Please search for and select a title first.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedTitle = _searchResults[cmbTitles.SelectedIndex];
                var reservation = _reservationService.ReserveTitle(userNumber, selectedTitle.TitleId);

                MessageBox.Show(
                    $"Reservation queued successfully!\nReservation ID: {reservation.ReservationId}\nTitle: {selectedTitle.Name}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUserNumber.Clear();
                txtTitleSearch.Clear();
                cmbTitles.Items.Clear();
                _searchResults.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
