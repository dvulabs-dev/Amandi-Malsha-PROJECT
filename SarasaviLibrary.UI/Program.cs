using System;
using System.Windows.Forms;
using SarasaviLibrary.UI.Forms;

namespace SarasaviLibrary.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
