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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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

        private async Task<string> GetAppApiAsync()
        {
            string result="";
            var settings = await GetApplicationSettings();
            var setting = settings.SingleOrDefault(x => x.AppKey == "APPLICATION.SECURITY.APIKEY");
            result = setting.AppValue;
            return result;
        }

        public bool IsAppInProd()
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


        public async Task<List<Departments>> GetDepartmentAsync()
        {
            var dpts = new List<Departments>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Departments";

            using (var client = new HttpClient())
            {
                try
                {
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);

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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);

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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                   // var secret = await GetAppApiAsync();
                    //client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                   // var secret = await GetAppApiAsync();
                   // client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
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

        internal async Task<List<UserThemes>> GetUsersThemesAsync()
        {

            var result = new List<UserThemes>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "UserThemes";

            using (var client = new HttpClient())
            {
                try
                {
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<UserThemes>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }


        internal async Task<List<EnrollmentNotes>> GetEnrollmentNotesAsync()
        {

            var result = new List<EnrollmentNotes>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "EnrollmentNotes";

            using (var client = new HttpClient())
            {
                try
                {
                    var secret = await GetAppApiAsync();
                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", secret);
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<EnrollmentNotes>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        internal async Task<string> GetCourseNameAsync(int courseId)
        {
            string result="";

            var courses = await GetCoursesAsync();
            if (courses.Any())
            {
                var course = courses.SingleOrDefault(x => x.Cours_Id == courseId);
                if (course != null)
                {
                    result = course.Nom_Cours;
                }
            }

            return result;
        }
    }
}
