using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.Models;
using EduOne.Helpers;
using EduOne.Fr.Models;

using Config = System.Configuration.ConfigurationManager;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using EduOne.Fr.helpers;
namespace EduOne.Fr.Helpers
{
    public class CommonHelpers
    {

        public async Task<List<EduOne.Fr.Models.Courses>> GetCoursesAsync()
        {
            var courses = new List<Models.Courses>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Courses";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        courses = JsonConvert.DeserializeObject<List<Models.Courses>>(responseData);
                    }
                    else
                    {
                        XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (HttpRequestException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return courses;
        }

        public bool IsAppInProd()
        {
            bool isAppInProd = bool.Parse(Config.AppSettings["IS_PROD"]);
            return isAppInProd;
        }

        public async Task<List<Departments>> GetDepartmentAsync()
        {
            var dpts = new List<Departments>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Departments";

            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        dpts = JsonConvert.DeserializeObject<List<Departments>>(responseData);
                    }
                    else
                    {
                        XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (HttpRequestException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            return dpts;
        }
        public async Task<string> GetDepartmentNameAsync(int iD_Department)
        {
            string department = "";
            var dpts = await GetDepartmentAsync();
            var xdepartment = dpts.SingleOrDefault(x => x.Id == iD_Department);
            department = xdepartment.Nom_Département;
            return department;
        }
    }
}
