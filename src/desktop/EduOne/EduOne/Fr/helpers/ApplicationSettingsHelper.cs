using DevExpress.XtraEditors;
using EduOne.Fr.Models;
using EduOne.Helpers;
using Newtonsoft.Json;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Config=System.Configuration.ConfigurationManager;
namespace EduOne.Fr.Helpers
{
    public static class ApplicationSettingsHelper
    {
        internal static async Task<List<ApplicationSettings>> GetApplicationSettingsAsync()
        {
            var result = new List<ApplicationSettings>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "ApplicationSettings";

            using (var client = new HttpClient())
            {
                try
                {
                   //  var secret = await GetAppApiAsync();
                   //  client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<Models.ApplicationSettings>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        public static async Task<string> GetApplicationSettingAsync(string key)
        {
            var settings = await GetApplicationSettingsAsync();
            var setting = settings.SingleOrDefault(x => x.AppKey == key);
            return setting?.AppValue;
        }

        public static bool IsAppInProd()
        {
            var value = Config.AppSettings["IS_PROD"];

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("IS_PROD setting is missing or empty in App.config");
            }

            if (!bool.TryParse(value, out bool isAppInProd))
            {
                throw new Exception($"Invalid boolean value for IS_PROD: {value}");
            }

            return isAppInProd;
        }

        private static async Task<string> GetAppApiAsync()
        {
            string result = "";
           var settings = await GetApplicationSettingsAsync();
            var setting = settings.SingleOrDefault(x => x.AppKey == "APPLICATION.SECURITY.APIKEY");
            result = setting.AppValue;
            return result;
        }
    }
}
