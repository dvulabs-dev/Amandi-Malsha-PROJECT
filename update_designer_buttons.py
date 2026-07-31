import re

path = r'D:\DVULabs\Amandi-Malsha-PROJECT\SarasaviLibrary.UI\Forms\MainForm.Designer.cs'
with open(path, 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Replace System.Windows.Forms.Button with SarasaviLibrary.UI.Forms.CustomNavButton for nav buttons
nav_buttons = ['btnNavDashboard', 'btnNavRegisterUser', 'btnNavRegisterBook', 'btnNavLoan', 'btnNavReturn', 'btnNavReserve', 'btnNavInquiry', 'btnNavExit']

for btn in nav_buttons:
    content = content.replace(f'new System.Windows.Forms.Button()', f'new SarasaviLibrary.UI.Forms.CustomNavButton()')
    content = content.replace(f'private System.Windows.Forms.Button          {btn};', f'private SarasaviLibrary.UI.Forms.CustomNavButton          {btn};')

with open(path, 'w', encoding='utf-8-sig') as f:
    f.write(content)
