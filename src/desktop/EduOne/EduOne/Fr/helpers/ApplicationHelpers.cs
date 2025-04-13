using System;
using Config = System.Configuration.ConfigurationManager;


namespace EduOne.Fr.helpers
{
    public static class ApplicationHelpers
    {
        private static string version = "1.0.0";
        public static string AppName = $"EduOne Version:{version}";

        public static string GetSystemUser(string email)
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
