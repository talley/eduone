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
using System.Globalization;
using EduOne.Fr.Admins.Finances.SemestersFees;
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

        public  List<string> GetAllCountrysNames()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            return cultures
                    .Select(cult => (new RegionInfo(cult.LCID)).DisplayName)
                    .Distinct()
                    .OrderBy(q => q)
                    .ToList();
        }

        internal async Task<List<Students>> GetStudentsAsync()
        {
            var students = new List<Students>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Students";

            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        students = JsonConvert.DeserializeObject<List<Students>>(responseData);
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
            return students;
        }

        internal async Task<List<StudentIdentifications>> GetStudentsIdentificationsAsync()
        {
            var students = new List<StudentIdentifications>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "StudentIdentifications";

            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        students = JsonConvert.DeserializeObject<List<StudentIdentifications>>(responseData);
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
            return students;
        }

        internal  List<string> GetGenders()
        {
            return new List<string>
            {
                "Mâle","Feminin"
            };
        }

        internal async Task<List<StaffRoles>> GettStaffRolesAsync()
        {
            var roles= new List<StaffRoles>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "StaffRoles";

            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        roles = JsonConvert.DeserializeObject<List<StaffRoles>>(responseData);
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

            return roles;
        }

        internal async Task<List<Models.Staffs>> GetStaffsAsync()
        {
            var result = new List<Models.Staffs>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Staffs";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<Models.Staffs>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<List<StaffNotes>> GetStaffNotesAsync()
        {
            var result = new List<Models.StaffNotes>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "StaffNotes";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<Models.StaffNotes>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<List<Classrooms>> GetClassRoomsAsync()
        {
            var result = new List<Models.Classrooms>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Classrooms";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<Models.Classrooms>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<List<Models.Enrollments>> GetEnrollmentsAsync()
        {
            var result = new List<Models.Enrollments>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Enrollments";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<Models.Enrollments>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<List<Semesters>> GetSemestersAsync()
        {
            var result = new List<Models.Semesters>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Semesters";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<Models.Semesters>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<List<SemesestersFees>> GetSemestersFeesAsync()
        {
            var result = new List<Models.SemesestersFees>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "SemesestersFees";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<Models.SemesestersFees>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<List<ApplicationSettings>> GetApplicationSettings()
        {
            var result = new List<ApplicationSettings>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "ApplicationSettings";

            using (var client = new HttpClient())
            {
                try
                {
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

        internal async Task<IEnumerable<ApplicationUsers>> GetApplicationUsersAsync()
        {
            var result = new List<ApplicationUsers>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "ApplicationUsers";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<Models.ApplicationUsers>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<IEnumerable<ApplicationRoles>> GetApplicationRolesAsync()
        {
            var result = new List<ApplicationRoles>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "ApplicationRoles";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<ApplicationRoles>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<List<SemesterEnrollmentFees>> GetSemesterEnrollmentFeesAsync()
        {

            var result = new List<SemesterEnrollmentFees>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "SemesterEnrollmentFees";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<SemesterEnrollmentFees>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<string> GetSemesterNameAsync(int semestreId)
        {
            var semesters = await GetSemestersAsync();
            var result = semesters.SingleOrDefault(x => x.ID == semestreId);
            return result.Semestre;
        }

        public async Task<string> GetStudentLastFirstName(int id)
        {
            var students = await GetStudentsAsync();
            var st = students.SingleOrDefault(x => x.Id == id);

            return string.Concat(st.Nom, " ", st.Prénom);
        }
    }
}
