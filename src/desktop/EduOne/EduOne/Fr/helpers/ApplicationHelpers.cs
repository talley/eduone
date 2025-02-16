using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Config = System.Configuration.ConfigurationManager;


namespace EduOne.Fr.helpers
{
    public class ApplicationHelpers
    {
        private static string version = "1.0.0";
        public static string AppName = $"EduOne Version:{version}";

        public static object GetSystemUser(string email)
        {
            return string.Concat(email, "_", Environment.MachineName);
        }

        public static string GetAppDomain()
        {
            var domain = Config.AppSettings["APP_DOMAIN"] as string;
            var result = "";

            if (domain != null)
            {
                if (domain == "SCHOOLS")
                {
                    result = "Eleve";
                }
                else
                {
                    result = "Etudiant";
                }
            }
            return result;
        }
    }
}
