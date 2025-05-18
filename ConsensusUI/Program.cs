using ConsensusUI.Forms;
using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using DevExpress.XtraGrid.Localization;
using ConsensusUI.Classes;
namespace ConsensusUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
            GridLocalizer.Active = new MyGridLocalizer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}