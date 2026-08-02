using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class ReservationListForm : Form
    {
        private readonly ReservationService _reservationService;
        private List<ReservationDetailDto> _allReservations = new List<ReservationDetailDto>();

        public ReservationListForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
        }

        private void ReservationListForm_Load(object? sender, EventArgs e)
        {
            UIThemeHelper.ApplyDashboardTheme(this);
            pnlHeader.BackColor = Color.FromArgb(41, 54, 129); // Dark blue banner
            pnlSearch.BackColor = Color.White;
            
            // Text colors for the dark blue banner
            lblTitle.ForeColor = Color.White;
            lblSubtitle.ForeColor = Color.FromArgb(200, 215, 255); // Light blueish white

            // Style buttons to be smoothly rounded pills
            btnReserveBook.BackColor = Color.FromArgb(66, 116, 217); // Bright blue button on dark banner
            btnReserveBook.ForeColor = Color.White;
            btnReserveBook.Paint += RoundedButton_Paint;
            btnReset.Paint += RoundedButton_Paint;

            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.Columns.Clear();
            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReservationDate", HeaderText = "Date", Name = "ReservationDate", Width = 120 });
            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookTitle", HeaderText = "Book Title", Name = "BookTitle", Width = 250 });
            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BorrowerName", HeaderText = "Borrower Name", Name = "BorrowerName", Width = 200 });
            dgvReservations.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "Status", Width = 160 });

            var activateCol = new DataGridViewButtonColumn { HeaderText = "ACTION", Name = "ActivateLoan", Text = "Activate Loan", UseColumnTextForButtonValue = true, Width = 120 };
            dgvReservations.Columns.Add(activateCol);

            var deleteCol = new DataGridViewButtonColumn { HeaderText = "", Name = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 50 };
            dgvReservations.Columns.Add(deleteCol);

            dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 54, 129);
            dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvReservations.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 54, 129);
            dgvReservations.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvReservations.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvReservations.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvReservations.BackgroundColor = Color.FromArgb(245, 247, 250); // Blend with form background
        }

        private void LoadData()
        {
            try
            {
                _allReservations = _reservationService.GetAllReservationsDetail();
                // Re-assign a new list instance so WinForms DataGridView refreshes properly
                dgvReservations.DataSource = null;
                dgvReservations.DataSource = _allReservations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Reservations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReserveBook_Click(object sender, EventArgs e)
        {
            var form = new ReservationForm();
            form.ShowDialog(this);
            LoadData(); // Refresh after closing
        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnName = dgvReservations.Columns[e.ColumnIndex].Name;
                var res = dgvReservations.Rows[e.RowIndex].DataBoundItem as ReservationDetailDto;
                if (res == null) return;

                if (columnName == "ActivateLoan")
                {
                    if (res.Status != "ReadyForPickup")
                    {
                        MessageBox.Show(
                            "This reservation cannot be activated yet.\n\n" +
                            "The loan can only be activated once the book has been returned and the reservation status is 'Ready for Pickup'.",
                            "Cannot Activate",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    var confirm = MessageBox.Show(
                        $"Activate loan for \"{res.BookTitle}\" to borrower \"{res.BorrowerName}\"?\n\n" +
                        "This will create an active loan record and mark the reservation as Fulfilled.",
                        "Confirm Loan Activation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            _reservationService.ActivateReservationLoan(res.ReservationId);
                            LoadData(); // Refresh reservations table first

                            // Ask librarian if they want to switch to Active Loans to see B's loan
                            var goToLoans = MessageBox.Show(
                                $"✅ Loan activated for {res.BorrowerName}!\n\n" +
                                $"Book \"{res.BookTitle}\" is now checked out to them.\n\n" +
                                "Would you like to open Active Loans to confirm?",
                                "Loan Activated",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);

                            if (goToLoans == DialogResult.Yes)
                            {
                                // Navigate to Active Loans via the MainForm
                                var mainForm = FindMainForm();
                                mainForm?.NavigateToActiveLoans();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Activation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (columnName == "Delete")
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to permanently delete this reservation?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _reservationService.DeleteReservation(res.ReservationId);
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // --- Navigation helper ---

        /// <summary>
        /// Walks up the WinForms parent chain to find the hosting MainForm.
        /// The ReservationListForm is embedded inline inside pnlContent of MainForm,
        /// so its Parent is the panel, and the panel's Parent is the MainForm.
        /// </summary>
        private MainForm? FindMainForm()
        {
            Control? c = this.Parent;
            while (c != null)
            {
                if (c is MainForm mf) return mf;
                c = c.Parent;
            }
            return null;
        }

        // --- Custom Drawing ---

        private void RoundedButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Button btn || btn.Parent == null || e.Graphics == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(btn.Parent.BackColor);

            var rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
            int radius = 8; // Smooth round corner

            using (var path = GetRoundedRect(rect, radius))
            using (var brush = new SolidBrush(btn.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            if (btn.Name == "btnReset")
            {
                using (var path = GetRoundedRect(rect, radius))
                using (var pen = new Pen(Color.FromArgb(203, 213, 225), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, rect, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void dgvReservations_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Graphics == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool isFirstVisibleCol = e.ColumnIndex == dgvReservations.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index;
            bool isLastVisibleCol = e.ColumnIndex == dgvReservations.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index;
            bool isHeader = e.RowIndex == -1;
            bool isLastRow = e.RowIndex == dgvReservations.Rows.Count - 1;

            if (dgvReservations.Rows.Count == 0 && isHeader)
            {
                isLastRow = true;
            }

            bool isTopLeft = isHeader && isFirstVisibleCol;
            bool isTopRight = isHeader && isLastVisibleCol;
            bool isBottomLeft = isLastRow && isFirstVisibleCol;
            bool isBottomRight = isLastRow && isLastVisibleCol;

            using (var formBg = new SolidBrush(Color.FromArgb(245, 247, 250)))
            {
                e.Graphics.FillRectangle(formBg, e.CellBounds);
            }

            Color cellBgColor = isHeader ? Color.FromArgb(41, 54, 129) : Color.White;
            using (var path = GetCellPath(e.CellBounds, 12, isTopLeft, isTopRight, isBottomLeft, isBottomRight))
            using (var brush = new SolidBrush(cellBgColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            if (isHeader)
            {
                if (e.Value != null)
                {
                    var textRect = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y, e.CellBounds.Width - 30, e.CellBounds.Height);
                    using (var font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
                    using (var textBrush = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString(e.Value!.ToString()!.ToUpper(), font, textBrush, textRect, sf);
                    }
                }
                e.Handled = true;
                return;
            }

            if (!isLastRow)
            {
                using (var pen = new Pen(Color.FromArgb(238, 242, 246), 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }

            var colName = dgvReservations.Columns[e.ColumnIndex].Name;

            // Determine row status for conditional rendering
            string rowStatus = "";
            if (e.RowIndex >= 0 && e.RowIndex < dgvReservations.Rows.Count)
            {
                var rowData = dgvReservations.Rows[e.RowIndex].DataBoundItem as ReservationDetailDto;
                if (rowData != null) rowStatus = rowData.Status;
            }

            if (colName == "ActivateLoan")
            {
                bool isReady = rowStatus == "ReadyForPickup";
                int btnPaddingY = 14;
                int btnPaddingX = 10;
                var btnRect = new Rectangle(e.CellBounds.X + btnPaddingX, e.CellBounds.Y + btnPaddingY,
                    e.CellBounds.Width - (btnPaddingX * 2), e.CellBounds.Height - (btnPaddingY * 2));

                // Green if ready, grey if not
                Color btnColor = isReady ? Color.FromArgb(16, 185, 129) : Color.FromArgb(203, 213, 225);
                Color btnTextColor = isReady ? Color.White : Color.FromArgb(148, 163, 184);

                using (var path = GetRoundedRect(btnRect, 8))
                using (var btnBrush = new SolidBrush(btnColor))
                {
                    e.Graphics.FillPath(btnBrush, path);
                }

                string activateText = "Activate Loan";
                using (var font = new Font("Segoe UI", 8.5F, isReady ? FontStyle.Bold : FontStyle.Regular))
                using (var textBrush = new SolidBrush(btnTextColor))
                {
                    var size = e.Graphics.MeasureString(activateText, font);
                    var textPt = new PointF(
                        btnRect.X + (btnRect.Width - size.Width) / 2,
                        btnRect.Y + (btnRect.Height - size.Height) / 2);
                    e.Graphics.DrawString(activateText, font, textBrush, textPt);
                }
            }
            else if (colName == "Delete")
            {
                int btnSize = 36;
                int btnPaddingY = (e.CellBounds.Height - btnSize) / 2;
                int btnPaddingX = (e.CellBounds.Width - btnSize) / 2;
                var btnRect = new Rectangle(e.CellBounds.X + btnPaddingX, e.CellBounds.Y + btnPaddingY, btnSize, btnSize);

                Color btnColor = Color.FromArgb(254, 226, 226); // Light Red
                Color textColor = Color.FromArgb(220, 38, 38); // Red text

                using (var path = GetRoundedRect(btnRect, 8))
                using (var btnBrush = new SolidBrush(btnColor))
                {
                    e.Graphics.FillPath(btnBrush, path);
                }

                string btnText = "\uE74D"; // Dustbin icon
                using (var font = new Font("Segoe MDL2 Assets", 10F, FontStyle.Regular))
                using (var textBrush = new SolidBrush(textColor))
                {
                    var size = e.Graphics.MeasureString(btnText, font);
                    var textPt = new Point(btnRect.X + (btnRect.Width - (int)size.Width) / 2, btnRect.Y + (btnRect.Height - (int)size.Height) / 2 + 1);
                    e.Graphics.DrawString(btnText, font, textBrush, textPt);
                }
            }
            else if (colName == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString() ?? "";
                    // Show a friendly label for ReadyForPickup
                    string displayStatus = status == "ReadyForPickup" ? "Ready for Pickup" : status;

                    using (var font = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                    {
                        var size = e.Graphics.MeasureString(displayStatus, font);
                        var pillRect = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + (e.CellBounds.Height - 26) / 2, (int)size.Width + 20, 26);
                        
                        Color pillBgColor = Color.FromArgb(226, 232, 240);   // default grey
                        Color pillTextColor = Color.FromArgb(30, 41, 59);

                        if (status == "Pending")
                        {
                            pillBgColor = Color.FromArgb(254, 243, 199);     // amber 100
                            pillTextColor = Color.FromArgb(180, 90, 0);      // amber dark
                        }
                        else if (status == "ReadyForPickup")
                        {
                            pillBgColor = Color.FromArgb(209, 250, 229);     // emerald 100
                            pillTextColor = Color.FromArgb(4, 120, 87);      // emerald 700
                        }
                        else if (status == "Fulfilled")
                        {
                            pillBgColor = Color.FromArgb(219, 234, 254);     // blue 100
                            pillTextColor = Color.FromArgb(29, 78, 216);     // blue 700
                        }
                        else if (status == "Cancelled")
                        {
                            pillBgColor = Color.FromArgb(254, 226, 226);     // red 100
                            pillTextColor = Color.FromArgb(185, 28, 28);     // red 700
                        }

                        using (var path = GetRoundedRect(pillRect, 13))
                        using (var brush = new SolidBrush(pillBgColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                        
                        var textRect = new Rectangle(pillRect.X, pillRect.Y + 1, pillRect.Width, pillRect.Height);
                        using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center })
                        using (var brush = new SolidBrush(pillTextColor))
                        {
                            e.Graphics.DrawString(displayStatus, font, brush, textRect, sf);
                        }
                    }
                }
            }
            else
            {
                if (e.Value != null)
                {
                    var textRect = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y, e.CellBounds.Width - 30, e.CellBounds.Height);
                    using (var font = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                    using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
                    {
                        var textColor = Color.FromArgb(100, 116, 139);
                        Font drawFont = font;
                        
                        if (colName == "BookTitle")
                        {
                            textColor = Color.FromArgb(41, 54, 129);
                            drawFont = new Font(font, FontStyle.Bold);
                        }

                        e.Graphics.DrawString(e.Value.ToString(), drawFont, new SolidBrush(textColor), textRect, sf);
                        if (drawFont != font) drawFont.Dispose();
                    }
                }
            }

            e.Handled = true;
        }

        private GraphicsPath GetCellPath(Rectangle rect, int radius, bool isTopLeft, bool isTopRight, bool isBottomLeft, bool isBottomRight)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            var r = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

            if (isTopLeft) path.AddArc(r.X, r.Y, d, d, 180, 90);
            else path.AddLine(r.X, r.Y, r.X, r.Y);
            
            if (isTopRight) path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            else path.AddLine(r.Right, r.Y, r.Right, r.Y);
            
            if (isBottomRight) path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            else path.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
            
            if (isBottomLeft) path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            else path.AddLine(r.X, r.Bottom, r.X, r.Bottom);
            
            path.CloseFigure();
            return path;
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
