using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class InquiryForm : Form
    {
        private readonly InquiryService _inquiryService;

        public InquiryForm()
        {
            InitializeComponent();
            _inquiryService = new InquiryService();
            this.Load += InquiryForm_Load;
            
            pnlBookCard.Paint += pnlHalf_Paint;
            pnlBorrowerCard.Paint += pnlHalf_Paint;
        }

        private void InquiryForm_Load(object? sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 247, 250); // Dashboard grey
            this.Padding = new Padding(25); // Gap from navbar and edges
            
            pnlBookCard.BackColor = Color.Transparent;
            pnlBorrowerCard.BackColor = Color.Transparent;

            lblBookTitle.ForeColor = Color.FromArgb(41, 54, 129);
            lblBorrowerTitle.ForeColor = Color.FromArgb(41, 54, 129);
            
            // Buttons
            btnBookSearch.BackColor = Color.FromArgb(16, 185, 129);
            btnBorrowerSearch.BackColor = Color.FromArgb(16, 185, 129); // Green pill button

            SetupGrids();
        }

        private void SetupGrids()
        {
            // Book Results Grid
            dgvBookResults.AutoGenerateColumns = false;
            dgvBookResults.Columns.Clear();
            dgvBookResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookNumber", HeaderText = "ACC #", Name = "BookNumber", Width = 90 });
            dgvBookResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "TITLE", Name = "Title", Width = 150 });
            dgvBookResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Author", HeaderText = "AUTHOR", Name = "Author", Width = 120 });
            dgvBookResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Availability", HeaderText = "AVAILABILITY", Name = "Availability", Width = 110 });
            dgvBookResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BorrowedByUserId", HeaderText = "BORROWER ID", Name = "BorrowedByUserId", Width = 110 });

            // Borrower Loans Grid
            dgvBorrowerLoans.AutoGenerateColumns = false;
            dgvBorrowerLoans.Columns.Clear();
            dgvBorrowerLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AccessionNo", HeaderText = "ACC #", Name = "AccessionNo", Width = 90 });
            dgvBorrowerLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookTitle", HeaderText = "TITLE", Name = "BookTitle", Width = 150 });
            dgvBorrowerLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DueDate", HeaderText = "DUE", Name = "DueDate", Width = 90 });
            dgvBorrowerLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "STATUS", Name = "Status", Width = 110 });

            ApplyGridTheme(dgvBookResults);
            ApplyGridTheme(dgvBorrowerLoans);
        }

        private void ApplyGridTheme(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 54, 129);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 54, 129);
            dgv.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        }

        // ── Drawing Events ──────────────────────────────────────────────

        private void pnlHalf_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel pnl || e.Graphics == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            e.Graphics.Clear(Color.FromArgb(245, 247, 250));
            
            var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            int radius = 30; // Large rounded corners for the main splits
            
            Color bgColor = Color.FromArgb(235, 240, 245);
            
            using (var path = GetRoundedRect(rect, radius))
            using (var brush = new SolidBrush(bgColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        private void RoundedButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Button btn || e.Graphics == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(btn.Parent?.BackColor ?? Color.White);

            var rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
            int radius = 8; 

            using (var path = GetRoundedRect(rect, radius))
            using (var brush = new SolidBrush(btn.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, rect, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void RoundedTextBoxContainer_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel pnl || e.Graphics == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(pnl.Parent?.BackColor ?? Color.White);

            var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            int radius = pnl.Height / 2;

            using (var path = GetRoundedRect(rect, radius))
            using (var brush = new SolidBrush(pnl.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        private void pnlCard_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel pnl || e.Graphics == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            Color parentColor = pnl == pnlBookCard ? Color.FromArgb(41, 54, 129) : Color.FromArgb(235, 240, 245);
            e.Graphics.Clear(parentColor);

            var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            int radius = 20;

            // Simple drop shadow effect (draw a slightly offset grey rect before the white card)
            var shadowRect = new Rectangle(2, 2, pnl.Width - 1, pnl.Height - 1);
            using (var shadowPath = GetRoundedRect(shadowRect, radius))
            using (var shadowBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            using (var path = GetRoundedRect(rect, radius))
            using (var brush = new SolidBrush(pnl.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        private void dgvBookResults_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            DrawGridCells(dgvBookResults, e);
        }

        private void dgvBorrowerLoans_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            DrawGridCells(dgvBorrowerLoans, e);
        }

        private void DrawGridCells(DataGridView dgv, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Graphics == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool isFirstVisibleCol = e.ColumnIndex == dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index;
            bool isLastVisibleCol = e.ColumnIndex == dgv.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index;
            bool isHeader = e.RowIndex == -1;
            bool isLastRow = e.RowIndex == dgv.Rows.Count - 1;

            if (dgv.Rows.Count == 0 && isHeader)
            {
                isLastRow = true;
            }

            bool isTopLeft = isHeader && isFirstVisibleCol;
            bool isTopRight = isHeader && isLastVisibleCol;
            bool isBottomLeft = isLastRow && isFirstVisibleCol;
            bool isBottomRight = isLastRow && isLastVisibleCol;

            using (var parentBg = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(parentBg, e.CellBounds);
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
                    var textRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y, e.CellBounds.Width - 10, e.CellBounds.Height);
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

            // Draw thin row separator
            if (!isLastRow)
            {
                using (var pen = new Pen(Color.FromArgb(238, 242, 246), 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }

            var colName = dgv.Columns[e.ColumnIndex].Name;
            
            if (e.Value != null)
            {
                var textRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y, e.CellBounds.Width - 10, e.CellBounds.Height);
                using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
                {
                    string text = e.Value.ToString() ?? "";
                    Color textColor = Color.FromArgb(100, 116, 139);
                    Font drawFont = new Font("Segoe UI", 9.5F, FontStyle.Regular);

                    if (text == "⚠️ OVERDUE" || text == "⚠ OVERDUE")
                    {
                        textColor = Color.FromArgb(220, 38, 38);
                        drawFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else if (colName == "Availability" && text == "Available")
                    {
                        textColor = Color.FromArgb(16, 185, 129); // Green
                        drawFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else if (colName == "Availability")
                    {
                        textColor = Color.FromArgb(245, 158, 11); // Orange/Amber
                    }
                    else if (colName == "Title" || colName == "BookTitle" || colName == "BookNumber" || colName == "AccessionNo")
                    {
                        textColor = Color.FromArgb(41, 54, 129);
                        drawFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }

                    e.Graphics.DrawString(text, drawFont, new SolidBrush(textColor), textRect, sf);
                    drawFont.Dispose();
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

        // â”€â”€ Search Logic â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBookSearch.Text)) return;

                var results = _inquiryService.SearchCopiesDetail(txtBookSearch.Text);

                dgvBookResults.DataSource = results.Select(c => new
                {
                    BookNumber       = c.BookNumber,
                    Title            = c.Title,
                    Author           = c.Author,
                    Availability     = c.Availability,
                    BorrowedByUserId = c.BorrowedByUserId
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleBook_Click(object? sender, EventArgs e)
        {
            pnlBookCard.Visible = true;
            pnlBorrowerCard.Visible = false;
            
            btnToggleBook.BackColor = Color.FromArgb(41, 54, 129);
            btnToggleBook.ForeColor = Color.White;
            
            btnToggleBorrower.BackColor = Color.FromArgb(230, 235, 240);
            btnToggleBorrower.ForeColor = Color.FromArgb(100, 116, 139);
        }

        private void btnToggleBorrower_Click(object? sender, EventArgs e)
        {
            pnlBookCard.Visible = false;
            pnlBorrowerCard.Visible = true;
            
            btnToggleBorrower.BackColor = Color.FromArgb(41, 54, 129);
            btnToggleBorrower.ForeColor = Color.White;
            
            btnToggleBook.BackColor = Color.FromArgb(230, 235, 240);
            btnToggleBook.ForeColor = Color.FromArgb(100, 116, 139);
        }

        private void btnBorrowerSearch_Click(object sender, EventArgs e)
        {
            string query = txtBorrowerSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(query)) return;

            try
            {
                var result = _inquiryService.SearchBorrower(query);

                if (!result.Found)
                {
                    pnlProfileStats.Visible = false;
                    dgvBorrowerLoans.Visible = false;
                    MessageBox.Show($"No borrower found for \"{query}\".", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblProfileName.Text    = $"ðŸ‘¤  {result.Name}";
                lblProfileUserNo.Text  = $"User Number:   {result.UserNumber}";
                lblProfileNid.Text     = $"National ID:   {result.NationalId}";
                lblProfileAddress.Text = $"Address:       {result.Address}";
                lblProfileSex.Text     = $"Sex:           {result.Sex}";
                lblProfileRegDate.Text = $"Registered:    {result.RegisteredDate.ToShortDateString()}";

                lblStatTotal.Text   = $"Total Loans: {result.TotalLoans}";
                lblStatActive.Text  = $"Active: {result.ActiveLoans}";
                lblStatOverdue.Text = result.OverdueLoans > 0 ? $"âš  Overdue: {result.OverdueLoans}" : "âœ” No Overdue";
                lblStatOverdue.ForeColor = result.OverdueLoans > 0 ? Color.FromArgb(220, 38, 38) : Color.FromArgb(16, 185, 129);

                pnlProfileStats.Visible = true;

                dgvBorrowerLoans.DataSource = result.Loans.Select(l => new
                {
                    AccessionNo  = l.AccessionNumber,
                    BookTitle    = l.BookTitle,
                    DueDate      = l.DueDate.ToShortDateString(),
                    Status       = l.IsOverdue ? "âš  OVERDUE" : l.Status
                }).ToList();

                dgvBorrowerLoans.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
