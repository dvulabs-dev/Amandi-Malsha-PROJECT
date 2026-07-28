using System.Drawing;
using System.Windows.Forms;

namespace SarasaviLibrary.UI.Utilities
{
    public static class ThemeUtility
    {
        // Colors
        public static Color PrimaryColor = Color.FromArgb(41, 128, 185); // Nice vibrant blue
        public static Color BackgroundColor = Color.FromArgb(245, 247, 250); // Soft gray
        public static Color ForegroundColor = Color.FromArgb(44, 62, 80); // Dark text
        
        public static void ApplyModernTheme(Form form)
        {
            form.BackColor = BackgroundColor;
            form.ForeColor = ForegroundColor;
            form.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            
            foreach (Control control in form.Controls)
            {
                StyleControl(control);
            }
        }

        private static void StyleControl(Control control)
        {
            if (control is DataGridView grid)
            {
                grid.BackgroundColor = BackgroundColor;
                grid.BorderStyle = BorderStyle.None;
                grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                grid.DefaultCellStyle.SelectionBackColor = PrimaryColor;
                grid.DefaultCellStyle.SelectionForeColor = Color.White;
                grid.DefaultCellStyle.BackColor = Color.White;
                grid.DefaultCellStyle.ForeColor = ForegroundColor;
                grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
                
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 252);
                
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                grid.ColumnHeadersHeight = 40;
                
                grid.RowTemplate.Height = 35;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else if (control is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = PrimaryColor;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }
            
            // Recursively style children
            foreach (Control child in control.Controls)
            {
                StyleControl(child);
            }
        }
    }
}
