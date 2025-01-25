using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
