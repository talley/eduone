using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using EduOne.Data.Fr;
using EduOne.Exts;
using EduOne.Helpers;
using Config = System.Configuration.ConfigurationManager;
using Newtonsoft;
using Newtonsoft.Json;
using DevExpress.Office.Utils;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static Humanizer.On;


namespace EduOne.Fr.Helpers
{
    /// <summary>
    ///   Application Users data access class
    /// </summary>
    public static class ApplicationUsersHelper
    {
        /// <summary>
        /// Determines whether [is application in production or not.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is application in product]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsAppInProd()
        {
            bool isAppInProd = bool.Parse(Config.AppSettings["IS_PROD"]);
            return isAppInProd;
        }
        /// <summary>
        /// Gets the application users asynchronously.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ApplicationUsers>> GetApplicationUsersAsync()
        {
            List <ApplicationUsers> users = new List <ApplicationUsers>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "ApplicationUsers";
            using (var client = new HttpClient())
            {
                try
                {
                   ///var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                    //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        users=JsonConvert.DeserializeObject<List<ApplicationUsers>>(responseData);
                    }
                    else
                    {
                        "".DisplayDialog($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    "".DisplayDialog($"An error occurred: {ex.Message}");
                }
            }
            return users;
        }

        /// <summary>
        /// Gets the role Id by role name asynchronously.
        /// </summary>
        /// <param name="role">role</param>
        /// <returns></returns>
        public static async Task<Guid> GetRoleIdAsync(string role)
        {
            Guid roleId =Guid.Empty;

            List<ApplicationUsers> users = new List<ApplicationUsers>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + $"/Commons/Roles/{role}";
            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        roleId=Guid.Parse(responseData);
                    }
                    else
                    {
                        "".DisplayDialog($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    "".DisplayDialog($"An error occurred: {ex.Message}");
                }
            }
            return roleId;
        }

        /// <summary>
        /// Gets the roles asynchronously.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public static async Task<List<ApplicationRoles>> GetRolesAsync()
        {
            var roles=new List<ApplicationRoles>();

            List<ApplicationUsers> users = new List<ApplicationUsers>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + $"ApplicationRoles";
            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                       roles=JsonConvert.DeserializeObject<List<ApplicationRoles>>(responseData);
                    }
                    else
                    {
                        "".DisplayDialog($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    "".DisplayDialog($"An error occurred: {ex.Message}");
                }
            }
            return roles;
        }
    }
}
