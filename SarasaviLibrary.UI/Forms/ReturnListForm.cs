using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class ReturnListForm : Form
    {
        private readonly LoanService _loanService;
        private object[] _allReturns = Array.Empty<object>();

        public ReturnListForm()
        {
            InitializeComponent();
            _loanService = new LoanService();
        }

        private void ReturnListForm_Load(object? sender, EventArgs e)
        {
            UIThemeHelper.ApplyDashboardTheme(this);
            pnlHeader.BackColor = Color.FromArgb(41, 54, 129); // Dark blue banner
            pnlSearch.BackColor = Color.White;
            
            // Text colors for the dark blue banner
            lblTitle.ForeColor = Color.White;
            lblSubtitle.ForeColor = Color.FromArgb(200, 215, 255); // Light blueish white

            // Style buttons to be smoothly rounded pills
            btnReturnBook.BackColor = Color.FromArgb(66, 116, 217); // Bright blue button on dark banner
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Paint += RoundedButton_Paint;
            btnReset.Paint += RoundedButton_Paint;

            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvReturns.AutoGenerateColumns = false;
            dgvReturns.Columns.Clear();
            dgvReturns.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReturnDate", HeaderText = "Return Date", Name = "ReturnDate", Width = 120 });
            dgvReturns.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AccessionNumber", HeaderText = "Accession No.", Name = "AccessionNumber", Width = 150 });
            dgvReturns.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookTitle", HeaderText = "Book Title", Name = "BookTitle", Width = 250 });
            dgvReturns.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BorrowerName", HeaderText = "Borrower Name", Name = "BorrowerName", Width = 200 });

            var deleteCol = new DataGridViewButtonColumn { HeaderText = "", Name = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 50 };
            dgvReturns.Columns.Add(deleteCol);

            dgvReturns.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 54, 129);
            dgvReturns.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReturns.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvReturns.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 54, 129);
            dgvReturns.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvReturns.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvReturns.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvReturns.BackgroundColor = Color.FromArgb(245, 247, 250); // Blend with form background
        }

        private void LoadData()
        {
            try
            {
                var returns = _loanService.GetAllReturnedLoans();
                // We cast to object array to make databinding easy without needing to reference DTO type explicitly in form load if not needed
                _allReturns = returns.ToArray();
                dgvReturns.DataSource = _allReturns;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Return History", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            var form = new ReturnForm();
            form.ShowDialog(this);
            LoadData(); // Refresh history
        }

        private void dgvReturns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnName = dgvReturns.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete")
                {
                    dynamic res = dgvReturns.Rows[e.RowIndex].DataBoundItem;
                    int id = res.LoanId;
                    var result = MessageBox.Show($"Are you sure you want to permanently delete this return record from history?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _loanService.DeleteLoan(id);
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

        private void dgvReturns_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Graphics == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool isFirstVisibleCol = e.ColumnIndex == dgvReturns.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index;
            bool isLastVisibleCol = e.ColumnIndex == dgvReturns.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index;
            bool isHeader = e.RowIndex == -1;
            bool isLastRow = e.RowIndex == dgvReturns.Rows.Count - 1;

            if (dgvReturns.Rows.Count == 0 && isHeader)
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

            var colName = dgvReturns.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
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
