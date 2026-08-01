import re

path = r'D:\DVULabs\Amandi-Malsha-PROJECT\SarasaviLibrary.UI\Forms\MainForm.Designer.cs'
with open(path, 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Remove declarations 42-48
content = re.sub(r'\s*// ── New table controls ───────────────────────────────────────[\s\S]*?this\.dgvBooks\s*=\s*new System\.Windows\.Forms\.DataGridView\(\);', '', content)
# Remove BeginInit
content = re.sub(r'\s*\(\(System\.ComponentModel\.ISupportInitialize\)\(this\.dgvBorrowers\)\)\.BeginInit\(\);\s*\(\(System\.ComponentModel\.ISupportInitialize\)\(this\.dgvBooks\)\)\.BeginInit\(\);', '', content)
# Remove Add(this.tlpTables)
content = re.sub(r'\s*this\.pnlContent\.Controls\.Add\(this\.tlpTables\);\s*// Fill — remaining space', '', content)
# Remove TABLE AREA
content = re.sub(r'\s*// ──────────────────────────────────────────────────────────────\s*// TABLE AREA[\s\S]*?this\.dgvBooks\.AlternatingRowsDefaultCellStyle\.BackColor = System\.Drawing\.Color\.FromArgb\(240, 255, 245\);', '', content)
# Remove EndInit
content = re.sub(r'\s*\(\(System\.ComponentModel\.ISupportInitialize\)\(this\.dgvBorrowers\)\)\.EndInit\(\);\s*\(\(System\.ComponentModel\.ISupportInitialize\)\(this\.dgvBooks\)\)\.EndInit\(\);', '', content)
# Remove fields
content = re.sub(r'\s*private System\.Windows\.Forms\.TableLayoutPanel tlpTables;[\s\S]*?private System\.Windows\.Forms\.DataGridView\s*dgvBooks;', '', content)

# Colors
content = content.replace('Color.FromArgb(30, 58, 138)', 'Color.FromArgb(76, 91, 212)')
content = content.replace('Color.FromArgb(15, 38, 92)', 'Color.FromArgb(76, 91, 212)')
content = content.replace('Color.FromArgb(49, 78, 168)', 'Color.FromArgb(92, 107, 226)')

content = content.replace('this.flpStats.Height        = 160;', 'this.flpStats.Height        = 500;\n            this.flpStats.Dock          = System.Windows.Forms.DockStyle.Fill;')
content = content.replace('this.flpStats.Dock          = System.Windows.Forms.DockStyle.Top;', '')

with open(path, 'w', encoding='utf-8-sig') as f:
    f.write(content)
