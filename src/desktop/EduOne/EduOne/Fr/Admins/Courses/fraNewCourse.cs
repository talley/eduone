using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;
using Config = System.Configuration.ConfigurationManager;

namespace EduOne.Fr.Admins.Courses
{
    public partial class fraNewCourse : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        public fraNewCourse(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraNewCourse_Load(object sender, EventArgs e)
        {
            var helper = new CommonHelpers();
            var departments = await helper.GetDepartmentsAsync();
            if(departments != null)
            {
                var needed = departments.Select(x => new {x.Id,x.Nom_Département }).ToList();
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

        private async void btnadd_Click(object sender, EventArgs e)
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
                var dptId=int.Parse(drpdepts.EditValue.ToString());

                var data = new
                {
                    Nom_Cours=course,
                    Description=desc,
                    ID_Department= dptId,
                    Statut=ckstatus.Checked,
                    AjouterAu=DateTime.Now,
                    AjouterPar=ApplicationHelpers.GetSystemUser(_email)

                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Courses";

                using (var client = new HttpClient())
                {
                    try
                    {
                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            "".DisplayDialog($"Ce cours ({course} ) a été créé");
                            btnadd.Enabled = false;
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
            }
        }

        private bool IsAppInProd()
        {
            bool isAppInProd = bool.Parse(Config.AppSettings["IS_PROD"]);
            return isAppInProd;
        }
    }
}