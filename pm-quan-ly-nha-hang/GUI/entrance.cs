using System;
using GUI.MonAn;
using GUI.NhanVien;
using System.Windows.Forms;

namespace GUI
{
    internal static class entrance
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}