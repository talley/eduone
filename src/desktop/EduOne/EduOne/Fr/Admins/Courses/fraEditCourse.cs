using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;
using Newtonsoft.Json;
using Config = System.Configuration.ConfigurationManager;

namespace EduOne.Fr.Admins.Courses
{
    public partial class fraEditCourse : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        int _id;
        CommonHelpers helper = new CommonHelpers();

        public fraEditCourse(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditCourse_Load(object sender, EventArgs e)
        {
            lblid.Text = $"Modifier Cours:{_id}";
            await LoadDepartmentsAsync();

            var courses = await helper.GetCoursesAsync();

            if (courses != null)
            {
                var course = courses.SingleOrDefault(x => x.Cours_Id == _id);

                txtcoursename.Text = course.Nom_Cours;
                txtdesc.Text = course.Description;
                ckstatus.Checked = course.Statut;
                drpdepts.Text = await helper.GetDepartmentNameAsync(course.ID_Department);
            }



        }

        private async Task LoadDepartmentsAsync()
        {
            var departments = await GetDepartmentAsync();

            if (departments != null)
            {
                var needed = departments.Select(x => new { x.Id, x.Nom_Département }).ToList();
                drpdepts.Properties.DataSource = needed;
                drpdepts.Properties.DisplayMember = "Nom_Département";
                drpdepts.Properties.ValueMember = "Id";
                drpdepts.Properties.BestFit();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnedit_Click(object sender, EventArgs e)
        {
            var course = txtcoursename.Text.Trim();
            var department = drpdepts.Text.Trim();
            var desc = txtdesc.Text.Trim();

            if (course.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Cours");
            }
            else if (department.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Département");
            }
            else if (desc.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Description");
            }
            else
            {
                var dptId = int.Parse(drpdepts.EditValue.ToString());

                var data = new
                {
                    cours_id = _id,
                    Nom_Cours = course,
                    Description = desc,
                    ID_Department = dptId,
                    Statut = ckstatus.Checked,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(_email),
                    ModifierAu = DateTime.Now,
                    ModifierPar=ApplicationHelpers.GetSystemUser(_email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + $"Courses/{_id}";

                using (var client = new HttpClient())
                {
                    try
                    {
                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);
                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        var content1 = new StringContent(jsonData, Encoding.Default, "application/json");

                        var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {

                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog($"Ce cours ({course} ) a été mis a jour");
                                btnedit.Enabled = false;


                            }));
                        }
                        else
                        {

                            Invoke(new Action(() =>
                            {
                                XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                            }));
                        }
                    }
                    catch (ArgumentNullException ex)
                    {
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));
                    }
                    catch (HttpRequestException ex)
                    {

                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));

                    }
                }
            }

        }
        private async Task<List<Models.Departments>> GetDepartmentAsync()
        {
            var dpts = new List<Models.Departments>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Departments";

            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        dpts = JsonConvert.DeserializeObject<List<Models.Departments>>(responseData);
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

        private bool IsAppInProd()
        {
            bool isAppInProd = bool.Parse(Config.AppSettings["IS_PROD"]);
            return isAppInProd;
        }

    }
}