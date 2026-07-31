using System;
using System.Drawing;
using System.Windows.Forms;

namespace SarasaviLibrary.UI.Forms
{
    public static class UIThemeHelper
    {
        // Light theme colors based on BookRegistration layout
        private static readonly Color FormBgColor = Color.FromArgb(245, 247, 250); // Light Grey
        private static readonly Color ForeTextColor = Color.FromArgb(30, 41, 59); // Dark Slate Blue for Labels
        private static readonly Color InputBgColor = Color.White;
        private static readonly Color PrimaryBtnColor = Color.FromArgb(30, 58, 138); // Deep Blue for Header and Buttons
        private static readonly Color PrimaryBtnTextColor = Color.White;
        
        public static void ApplyDashboardTheme(Form form)
        {
            form.BackColor = FormBgColor;
            form.ForeColor = ForeTextColor;
            StyleControls(form.Controls, isHeader: false);
        }

        private static void StyleControls(Control.ControlCollection controls, bool isHeader)
        {
            foreach (Control c in controls)
            {
                bool isHeaderPanel = (c is Panel pnl && pnl.Dock == DockStyle.Top) || 
                                     c.Name.IndexOf("Header", StringComparison.OrdinalIgnoreCase) >= 0;
                bool childIsHeader = isHeader || isHeaderPanel;
                
                if (c is Panel pnl2 && childIsHeader)
                {
                    pnl2.BackColor = PrimaryBtnColor;
                }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = childIsHeader ? Color.White : ForeTextColor;
                    lbl.BackColor = Color.Transparent;
                }
                else if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = PrimaryBtnColor;
                    btn.ForeColor = PrimaryBtnTextColor;
                    btn.Cursor = Cursors.Hand;
                    btn.Font = new Font(btn.Font, FontStyle.Bold);
                }
                else if (c is TextBox txt)
                {
                    txt.BackColor = InputBgColor;
                    txt.ForeColor = ForeTextColor;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cmb)
                {
                    cmb.BackColor = InputBgColor;
                    cmb.ForeColor = ForeTextColor;
                    cmb.FlatStyle = FlatStyle.Flat;
                }
                else if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = FormBgColor;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.DefaultCellStyle.BackColor = InputBgColor;
                    dgv.DefaultCellStyle.ForeColor = ForeTextColor;
                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 232, 240);
                    dgv.DefaultCellStyle.SelectionForeColor = ForeTextColor;
                    
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBtnColor;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryBtnColor;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.RowHeadersVisible = false;
                    dgv.GridColor = Color.FromArgb(203, 213, 225);
                }
                else if (c is NumericUpDown nud)
                {
                    nud.BackColor = InputBgColor;
                    nud.ForeColor = ForeTextColor;
                    nud.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is CheckBox chk)
                {
                    chk.ForeColor = chk.ForeColor == Color.FromArgb(185, 28, 28) ? chk.ForeColor : ForeTextColor;
                }

                if (c.HasChildren)
                {
                    StyleControls(c.Controls, childIsHeader);
                }
            }
        }
    }
}
