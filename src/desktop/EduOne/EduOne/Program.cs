using System;
using System.Windows.Forms;
using EduOne.En;
using EduOne.Fr.Admins;
using Telerik.WinControls.Themes;
using Telerik.WinControls;
using Config = System.Configuration.ConfigurationManager;
using EduOne.Fr.Tools;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;
using EduOne.Fr.Admins.Reports;
using EduOne.Fr.Admins.Audits;
using EduOne.Fr;
namespace EduOne
{
    internal static class Program
    {
        static CommonHelpers helper = new CommonHelpers();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Office2007SilverTheme theme = new Office2007SilverTheme();
            ThemeResolutionService.ApplicationThemeName = "Crystal";
            var appLang = Config.AppSettings["APP_LANG"] as string;
            if (appLang == "fr")
            {

                //fraWelcome2
                Application.Run(new frLogin());// fraManageStaffs("test@test.com"));
            }
            else
            {

                Application.Run(new enLogin());//fraEditUser("talleyouro@gmail.com",Guid.NewGuid()
            }
        }
    }
}
