using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace mKYS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          //  DevExpress.XtraEditors.WindowsFormsSettings.DefaultSettingsCompatibilityMode = DevExpress.XtraEditors.SettingsCompatibilityMode.v19_1;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();

            // Application.Run(new Analiz.ValidasyonEkle());
             Application.Run(new Giris());
           // Application.Run(new mKYS.Duyuru.Okuduklarim());
        }
    }
}
