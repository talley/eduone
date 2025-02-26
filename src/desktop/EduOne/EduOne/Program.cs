using System;
using System.Windows.Forms;
using EduOne.En;
using EduOne.Fr.Admins;
using EduOne.Fr.Admins.Enrollments;
using EduOne.Fr.Admins.Finances.SemestersFees;
using EduOne.Fr.Admins.Semesters;
using Telerik.WinControls.Themes;
using Telerik.WinControls;
using Config = System.Configuration.ConfigurationManager;
using EduOne.Fr.Admins.Settings;
namespace EduOne
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Office2007SilverTheme theme = new Office2007SilverTheme();
            ThemeResolutionService.ApplicationThemeName = "CrystalDark";
            var appLang = Config.AppSettings["APP_LANG"] as string;
            if (appLang == "fr")
            {
                Application.Run(new fraWelcome2(""));// fraManageStaffs("test@test.com"));
            }
            else
            {

                Application.Run(new enLogin());//fraEditUser("talleyouro@gmail.com",Guid.NewGuid()
            }
        }
    }
}
