using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SarasaviLibrary.BusinessLogic.Services;
using SarasaviLibrary.Models.Entities;

namespace SarasaviLibrary.UI.Forms
{
    public partial class BookListForm : Form
    {
        private readonly BookService _bookService;
        private System.Collections.Generic.List<Title> _allTitles;

        public BookListForm()
        {
            InitializeComponent();
            _bookService = new BookService();
            _allTitles = new System.Collections.Generic.List<Title>();
        }

        private void BookListForm_Load(object sender, EventArgs e)
        {
            UIThemeHelper.ApplyDashboardTheme(this);
            pnlHeader.BackColor = Color.FromArgb(41, 54, 129); // Dark blue banner
            pnlSearch.BackColor = Color.White;
            
            // Text colors for the dark blue banner
            lblTitle.ForeColor = Color.White;
            lblSubtitle.ForeColor = Color.FromArgb(200, 215, 255); // Light blueish white

            // Style buttons to be smoothly rounded pills
            btnAddBook.BackColor = Color.FromArgb(66, 116, 217); // Bright blue button on dark banner
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Paint += RoundedButton_Paint;
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
            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.Columns.Clear();
            
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookNumberPrefix", HeaderText = "Prefix", Name = "BookNumberPrefix", Width = 80 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Title", Name = "Name", Width = 200 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AuthorNames", HeaderText = "Author", Name = "AuthorNames", Width = 150 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Classification", HeaderText = "Classification", Name = "Classification", Width = 150 });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BookType", HeaderText = "Type", Name = "BookType" });

            var updateCol = new DataGridViewButtonColumn { HeaderText = "ACTIONS", Name = "Update", Text = "Edit", UseColumnTextForButtonValue = true, Width = 50 };
            dgvBooks.Columns.Add(updateCol);
            
            var deleteCol = new DataGridViewButtonColumn { HeaderText = "", Name = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 50 };
            dgvBooks.Columns.Add(deleteCol);

            dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 54, 129);
            dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvBooks.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 54, 129);
            dgvBooks.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvBooks.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvBooks.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvBooks.BackgroundColor = Color.FromArgb(245, 247, 250); // Blend with form background
        }

        private void LoadData()
        {
            try
            {
                _allTitles = _bookService.GetAllTitles();
                FilterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Books", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            var query = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(query))
            {
                dgvBooks.DataSource = _allTitles.ToList();
            }
            else
            {
                dgvBooks.DataSource = _allTitles.Where(t => 
                    t.Name.ToLower().Contains(query) || 
                    t.BookNumberPrefix.ToLower().Contains(query) ||
                    t.AuthorNames.ToLower().Contains(query)).ToList();
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var regForm = new BookRegistrationForm();
            regForm.ShowDialog(this);
            LoadData();
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

        private void dgvBooks_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var columnName = dgvBooks.Columns[e.ColumnIndex].Name;
                if (columnName == "Update" || columnName == "Delete")
                {
                    var title = (Title)dgvBooks.Rows[e.RowIndex].DataBoundItem;
                    
                    if (columnName == "Update")
                    {
                        var editForm = new BookRegistrationForm(title);
                        editForm.ShowDialog(this);
                        LoadData();
                    }
                    else if (columnName == "Delete")
                    {
                        var result = MessageBox.Show($"Are you sure you want to permanently delete {title.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                _bookService.DeleteTitle(title.TitleId);
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
        }

        private void dgvBooks_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Graphics == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            bool isFirstVisibleCol = e.ColumnIndex == dgvBooks.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index;
            bool isLastVisibleCol = e.ColumnIndex == dgvBooks.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index;
            bool isHeader = e.RowIndex == -1;
            bool isLastRow = e.RowIndex == dgvBooks.Rows.Count - 1;

            if (dgvBooks.Rows.Count == 0 && isHeader)
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

            // Draw custom button or normal content
            var colName = dgvBooks.Columns[e.ColumnIndex].Name;
            if (colName == "Update" || colName == "Delete")
            {
                int btnSize = 36;
                int btnPaddingY = (e.CellBounds.Height - btnSize) / 2;
                int btnPaddingX = (e.CellBounds.Width - btnSize) / 2;
                var btnRect = new Rectangle(e.CellBounds.X + btnPaddingX, e.CellBounds.Y + btnPaddingY, btnSize, btnSize);
                
                Color btnColor = colName == "Update" ? Color.FromArgb(66, 116, 217) : Color.FromArgb(241, 245, 249); 
                Color textColor = colName == "Update" ? Color.White : Color.FromArgb(100, 116, 139);

                using (var path = GetRoundedRect(btnRect, 8)) // smooth rounded corners
                using (var btnBrush = new SolidBrush(btnColor))
                {
                    e.Graphics.FillPath(btnBrush, path);
                }
                
                if (colName == "Delete")
                {
                    using (var path = GetRoundedRect(btnRect, 8))
                    using (var pen = new Pen(Color.FromArgb(203, 213, 225), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                string btnText = colName == "Update" ? "\uE70F" : "\uE74D";
                using (var font = new Font("Segoe MDL2 Assets", 10F, FontStyle.Regular))
                using (var textBrush = new SolidBrush(textColor))
                {
                    var size = e.Graphics.MeasureString(btnText, font);
                    var textPt = new Point(btnRect.X + (btnRect.Width - (int)size.Width) / 2, btnRect.Y + (btnRect.Height - (int)size.Height) / 2 + 1);
                    e.Graphics.DrawString(btnText, font, textBrush, textPt);
                }
            }
            else if (colName == "BookType")
            {
                if (e.Value != null)
                {
                    string text = e.Value.ToString() ?? "";
                    using (var font = new Font("Segoe UI", 9F, FontStyle.Regular))
                    {
                        var size = e.Graphics.MeasureString(text, font);
                        var pillRect = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y + (e.CellBounds.Height - 24) / 2, (int)size.Width + 20, 24);
                        
                        using (var path = GetRoundedRect(pillRect, 12))
                        using (var brush = new SolidBrush(Color.FromArgb(226, 232, 240)))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                        
                        var textRect = new Rectangle(pillRect.X, pillRect.Y + 1, pillRect.Width, pillRect.Height);
                        using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center })
                        using (var brush = new SolidBrush(Color.FromArgb(30, 41, 59)))
                        {
                            e.Graphics.DrawString(text, font, brush, textRect, sf);
                        }
                    }
                }
            }
            else
            {
                // Standard text drawing with custom font/colors
                if (e.Value != null)
                {
                    var textRect = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y, e.CellBounds.Width - 30, e.CellBounds.Height);
                    using (var font = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                    using (var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
                    {
                        var textColor = (colName == "Name" || colName == "BookNumberPrefix") ? Color.FromArgb(41, 54, 129) : Color.FromArgb(100, 116, 139);
                        Font drawFont = (colName == "Name" || colName == "BookNumberPrefix") ? new Font(font, FontStyle.Bold) : font;
                        e.Graphics.DrawString(e.Value.ToString(), drawFont, new SolidBrush(textColor), textRect, sf);
                        if (colName == "Name" || colName == "BookNumberPrefix") drawFont.Dispose();
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
