using System;
using System.IO;
using System.Text.RegularExpressions;

string path = @"D:\DVULabs\Amandi-Malsha-PROJECT\SarasaviLibrary.UI\Forms\MainForm.Designer.cs";
string content = File.ReadAllText(path);

// Remove declarations 42-48
content = Regex.Replace(content, @"\s*// -- New table controls ---------------------------------------[\s\S]*?this\.dgvBooks\s*=\s*new System\.Windows\.Forms\.DataGridView\(\);", "");
// Remove BeginInit
content = Regex.Replace(content, @"\s*\(\(System\.ComponentModel\.ISupportInitialize\)\(this\.dgvBorrowers\)\)\.BeginInit\(\);\s*\(\(System\.ComponentModel\.ISupportInitialize\)\(this\.dgvBooks\)\)\.BeginInit\(\);", "");
// Remove Add(this.tlpTables)
content = Regex.Replace(content, @"\s*this\.pnlContent\.Controls\.Add\(this\.tlpTables\);\s*// Fill — remaining space", "");
// Remove TABLE AREA (lines 219-300)
content = Regex.Replace(content, @"\s*// --------------------------------------------------------------\s*// TABLE AREA[\s\S]*?this\.dgvBooks\.AlternatingRowsDefaultCellStyle\.BackColor = System\.Drawing\.Color\.FromArgb\(240, 255, 245\);", "");
// Remove EndInit
content = Regex.Replace(content, @"\s*\(\(System\.ComponentModel\.ISupportInitialize\)\(this\.dgvBorrowers\)\)\.EndInit\(\);\s*\(\(System\.ComponentModel\.ISupportInitialize\)\(this\.dgvBooks\)\)\.EndInit\(\);", "");
// Remove fields
content = Regex.Replace(content, @"\s*private System\.Windows\.Forms\.TableLayoutPanel tlpTables;[\s\S]*?private System\.Windows\.Forms\.DataGridView\s*dgvBooks;", "");

// Colors
content = content.Replace("Color.FromArgb(30, 58, 138)", "Color.FromArgb(76, 91, 212)");
content = content.Replace("Color.FromArgb(15, 38, 92)", "Color.FromArgb(76, 91, 212)");
content = content.Replace("Color.FromArgb(49, 78, 168)", "Color.FromArgb(92, 107, 226)");

// Also flpStats padding / height
content = content.Replace("this.flpStats.Height        = 160;", "this.flpStats.Height        = 500;\r\n            this.flpStats.Dock          = System.Windows.Forms.DockStyle.Fill;");
content = content.Replace("this.flpStats.Dock          = System.Windows.Forms.DockStyle.Top;", "");

File.WriteAllText(path, content);
