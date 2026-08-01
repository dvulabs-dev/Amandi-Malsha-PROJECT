using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;

namespace SarasaviLibrary.UI.Forms
{
    public partial class LoanListForm : Form
    {
        private readonly LoanService _loanService;
        private System.Collections.Generic.List<ActiveLoanDto> _allLoans;

        public LoanListForm()
        {
            InitializeComponent();
            _loanService = new LoanService();
            _allLoans = new System.Collections.Generic.List<ActiveLoanDto>();
        }

        private void LoanListForm_Load(object sender, EventArgs e)
        {
            UIThemeHelper.ApplyDashboardTheme(this);
            pnlHeader.BackColor = Color.FromArgb(41, 54, 129); // Dark blue banner
            pnlSearch.BackColor = Color.White;
            
            // Text colors for the dark blue banner
            lblTitle.ForeColor = Color.White;
            lblSubtitle.ForeColor = Color.FromArgb(200, 215, 255); // Light blueish white

            // Style buttons to be smoothly rounded pills
            btnAddLoan.BackColor = Color.FromArgb(66, 116, 217); // Bright blue button on dark banner
            btnAddLoan.ForeColor = Color.White;
            btnAddLoan.Paint += RoundedButton_Paint;
            btnReset.Paint += RoundedButton_Paint;

            SetupGrid();
            LoadData();
        }

        private void RoundedButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Button btn || btn.Parent == null || e.Graphics == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(btn.Parent.BackColor);

            var rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
            int radius = 8; // Smooth round corner instead of perfect curve

            using (var path = GetRoundedRect(rect, radius))
            using (var brush = new SolidBrush(btn.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Draw border if it's the reset button
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

        private void SetupGrid()
        {
            dgvLoans.AutoGenerateColumns = false;
            dgvLoans.Columns.Clear();
            
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AccessionNumber", HeaderText = "Accession #", Name = "AccessionNumber", Width = 120 });
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookTitle", HeaderText = "Book Title", Name = "BookTitle", Width = 200 });
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BorrowerName", HeaderText = "Borrower", Name = "BorrowerName", Width = 150 });
            
            var dueDateCol = new DataGridViewTextBoxColumn { DataPropertyName = "DueDate", HeaderText = "Due Date", Name = "DueDate", Width = 120 };
            dueDateCol.DefaultCellStyle.Format = "dd MMM yyyy";
            dgvLoans.Columns.Add(dueDateCol);
            
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "Status", Width = 100 });

            var returnCol = new DataGridViewButtonColumn { HeaderText = "ACTIONS", Name = "Return", Text = "Return", UseColumnTextForButtonValue = true, Width = 90 };
            dgvLoans.Columns.Add(returnCol);

            dgvLoans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 54, 129);
            dgvLoans.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLoans.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvLoans.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 54, 129);
            dgvLoans.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvLoans.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvLoans.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvLoans.BackgroundColor = Color.FromArgb(245, 247, 250); // Blend with form background
        }

        private void LoadData()
        {
            try
            {
                _allLoans = _loanService.GetAllActiveLoans();
                FilterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            var query = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(query))
            {
                dgvLoans.DataSource = _allLoans.ToList();
            }
            else
            {
                dgvLoans.DataSource = _allLoans.Where(l => 
                    l.BookTitle.ToLower().Contains(query) || 
                    l.AccessionNumber.ToLower().Contains(query) ||
                    l.BorrowerName.ToLower().Contains(query)).ToList();
            }
        }

        private void btnAddLoan_Click(object sender, EventArgs e)
        {
            var loanForm = new LoanForm();
            loanForm.ShowDialog(this);
            LoadData(); // Refresh list after issuing a loan
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            FilterData();
        }

        private void dgvLoans_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var columnName = dgvLoans.Columns[e.ColumnIndex].Name;
                if (columnName == "Return")
                {
                    var loanDto = (ActiveLoanDto)dgvLoans.Rows[e.RowIndex].DataBoundItem;
                    
                    var returnForm = new ReturnForm(loanDto.AccessionNumber);
                    returnForm.ShowDialog(this);
                    LoadData();
                }
            }
        }

        private void dgvLoans_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Graphics == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool isFirstVisibleCol = e.ColumnIndex == dgvLoans.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index;
            bool isLastVisibleCol = e.ColumnIndex == dgvLoans.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index;
            bool isHeader = e.RowIndex == -1;
            bool isLastRow = e.RowIndex == dgvLoans.Rows.Count - 1;

            if (dgvLoans.Rows.Count == 0 && isHeader)
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

            var colName = dgvLoans.Columns[e.ColumnIndex].Name;
            var loanDto = (ActiveLoanDto)dgvLoans.Rows[e.RowIndex].DataBoundItem;

            if (colName == "Return")
            {
                int btnPaddingY = 14;
                int btnPaddingX = 10;
                var btnRect = new Rectangle(e.CellBounds.X + btnPaddingX, e.CellBounds.Y + btnPaddingY, e.CellBounds.Width - (btnPaddingX * 2), e.CellBounds.Height - (btnPaddingY * 2));
                
                Color btnColor = Color.FromArgb(16, 185, 129); // Emerald green for Return
                Color textColor = Color.White;

                using (var path = GetRoundedRect(btnRect, 8)) // smooth rounded corners
                using (var btnBrush = new SolidBrush(btnColor))
                {
                    e.Graphics.FillPath(btnBrush, path);
                }

                string btnText = "Return";
                using (var font = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (var textBrush = new SolidBrush(textColor))
                {
                    var size = e.Graphics.MeasureString(btnText, font);
                    var textPt = new Point(btnRect.X + (btnRect.Width - (int)size.Width) / 2, btnRect.Y + (btnRect.Height - (int)size.Height) / 2);
                    e.Graphics.DrawString(btnText, font, textBrush, textPt);
                }
            }
            else if (colName == "Status")
            {
                if (e.Value != null)
                {
                    string text = e.Value.ToString() ?? "";
                    using (var font = new Font("Segoe UI", 9F, FontStyle.Regular))
                    {
                        var size = e.Graphics.MeasureString(text, font);
                        var pillRect = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y + (e.CellBounds.Height - 24) / 2, (int)size.Width + 20, 24);
                        
                        bool isOverdue = loanDto.IsOverdue;
                        Color pillBgColor = isOverdue ? Color.FromArgb(254, 226, 226) : Color.FromArgb(226, 232, 240);
                        Color pillTextColor = isOverdue ? Color.FromArgb(220, 38, 38) : Color.FromArgb(30, 41, 59);

                        using (var path = GetRoundedRect(pillRect, 12))
                        using (var brush = new SolidBrush(pillBgColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                        
                        var textRect = new Rectangle(pillRect.X, pillRect.Y + 1, pillRect.Width, pillRect.Height);
                        using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center })
                        using (var brush = new SolidBrush(pillTextColor))
                        {
                            e.Graphics.DrawString(text, font, brush, textRect, sf);
                        }
                    }
                }
            }
            else if (colName == "DueDate")
            {
                if (e.Value != null)
                {
                    var textRect = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y, e.CellBounds.Width - 30, e.CellBounds.Height);
                    using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
                    {
                        bool isOverdue = loanDto.IsOverdue;
                        Color textColor = isOverdue ? Color.FromArgb(220, 38, 38) : Color.FromArgb(100, 116, 139);
                        Font drawFont = new Font("Segoe UI", 9.5F, isOverdue ? FontStyle.Bold : FontStyle.Regular);
                        
                        string displayText = e.Value.ToString() ?? "";
                        if (e.Value is DateTime dt)
                            displayText = dt.ToString("dd MMM yyyy");
                            
                        e.Graphics.DrawString(displayText, drawFont, new SolidBrush(textColor), textRect, sf);
                        drawFont.Dispose();
                    }
                }
            }
            else
            {
                // Standard text drawing
                if (e.Value != null)
                {
                    var textRect = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y, e.CellBounds.Width - 30, e.CellBounds.Height);
                    using (var font = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                    using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
                    {
                        var textColor = (colName == "BookTitle" || colName == "AccessionNumber") ? Color.FromArgb(41, 54, 129) : Color.FromArgb(100, 116, 139);
                        Font drawFont = (colName == "BookTitle" || colName == "AccessionNumber") ? new Font(font, FontStyle.Bold) : font;
                        e.Graphics.DrawString(e.Value.ToString(), drawFont, new SolidBrush(textColor), textRect, sf);
                        if (colName == "BookTitle" || colName == "AccessionNumber") drawFont.Dispose();
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
