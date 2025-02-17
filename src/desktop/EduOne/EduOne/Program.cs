using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EduOne.En;
using EduOne.Fr;
using EduOne.Fr.Admins;
using EduOne.Fr.Admins.Courses;
using EduOne.Fr.Admins.DepartmentHeads;
using EduOne.Fr.Admins.Departments;
using EduOne.Fr.Admins.Staffs;
using EduOne.Fr.Admins.Students;
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
                Application.Run(new fraManageStaffs("test@test.com"));
            }
            else
            {

                Application.Run(new enLogin());//fraEditUser("talleyouro@gmail.com",Guid.NewGuid()
            }
        }
    }
}
