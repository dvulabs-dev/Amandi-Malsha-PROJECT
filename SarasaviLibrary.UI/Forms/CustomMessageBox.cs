using System;
using System.Drawing;
using System.Windows.Forms;

namespace SarasaviLibrary.UI.Forms
{
    public static class CustomMessageBox
    {
        public static void Show(string message, string title)
        {
            using (var form = new Form())
            {
                form.Text = title;
                form.Size = new Size(400, 240);
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.BackColor = Color.FromArgb(245, 247, 250);

                // Header
                var pnlHeader = new Panel
                {
                    BackColor = Color.FromArgb(30, 58, 138),
                    Dock = DockStyle.Top,
                    Height = 60
                };
                
                var lblTitle = new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(20, 18),
                    AutoSize = true
                };
                pnlHeader.Controls.Add(lblTitle);

                // Body
                var lblMessage = new Label
                {
                    Text = message,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    Location = new Point(20, 80),
                    AutoSize = true,
                    MaximumSize = new Size(360, 0)
                };

                // Add early to force layout/size calculation
                form.Controls.Add(lblMessage);
                
                // Dynamically size the form based on the label content
                int requiredHeight = lblMessage.Bottom + 80;
                form.ClientSize = new Size(400, Math.Max(180, requiredHeight));

                // Button
                var btnOk = new Button
                {
                    Text = "OK",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    BackColor = Color.FromArgb(30, 58, 138),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Size = new Size(100, 32),
                    Location = new Point(280, form.ClientSize.Height - 52)
                };
                btnOk.FlatAppearance.BorderSize = 0;
                btnOk.Click += (s, e) => form.Close();

                form.Controls.Add(btnOk);
                form.Controls.Add(pnlHeader);

                // Focus OK button by default
                form.AcceptButton = btnOk;

                form.ShowDialog();
            }
        }
    }
}
