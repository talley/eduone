namespace EduOne.Helpers
{
    using DevExpress.XtraEditors;
    using EduOne.Exts;
    using System;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Text.Json;
    using System.Text;
    using System.Threading.Tasks;
    using static Humanizer.On;
    using Config = System.Configuration.ConfigurationManager;

    public static class WebServerHelpers
    {

        public static string GetApiApplicationUrl(bool IsProd)
        {
            if (IsProd)
            {
                return "";
            }
            else
            {
                return "https://localhost:7027/api/";
            }
        }

        public  static string GetApplicationUrl()
        {
            bool IsProd = bool.Parse(Config.AppSettings["IS_PROD"]);// await GetApplicationModeAsync();
            if (IsProd)
            {
                return "";
            }
            else
            {
                return "https://localhost:7027/";
            }
        }
    }
}
