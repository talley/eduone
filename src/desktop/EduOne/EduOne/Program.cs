using System;
using System.Windows.Forms;
using EduOne.En;
using EduOne.Fr.Admins;
using EduOne.Fr.Admins.Enrollments;
using EduOne.Fr.Admins.Finances.SemestersFees;
using EduOne.Fr.Admins.Semesters;
using Config = System.Configuration.ConfigurationManager;
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
            var appLang = Config.AppSettings["APP_LANG"] as string;
            if (appLang == "fr")
            {
                Application.Run(new fraAddSemesterFee(""));// fraManageStaffs("test@test.com"));
            }
            else
            {

                Application.Run(new enLogin());//fraEditUser("talleyouro@gmail.com",Guid.NewGuid()
            }
        }
    }
}
