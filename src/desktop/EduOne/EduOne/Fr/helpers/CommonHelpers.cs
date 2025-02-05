using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using EduOne.Fr.Models;
using EduOne.Helpers;

using Config = System.Configuration.ConfigurationManager;
using Newtonsoft.Json;
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


        public async Task<List<Departments>> GetDepartmentsAsync()
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

        public async Task<List<DepartmentHeads>> GetDepartmentHeadsAsync()
        {
            var dpts = new List<DepartmentHeads>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "DepartmentHeads";

            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        dpts = JsonConvert.DeserializeObject<List<DepartmentHeads>>(responseData);
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



    }
}
