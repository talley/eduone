using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;
using Config = System.Configuration.ConfigurationManager;
namespace EduOne.Fr.Admins.Departments
{
    public partial class fraAddDepartment : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        CommonHelpers helper=new CommonHelpers();
        public fraAddDepartment(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraAddDepartment_Load(object sender, EventArgs e)
        {
            var dptheads=await helper.GetDepartmentHeadsAsync();

            var needed = dptheads.Select(x => new
            {
                x.Id,
                Nom=x.Nom+" "+x.Prénom
            }).ToList();

            drpdepts.Properties.DataSource = needed;
            drpdepts.Properties.DisplayMember = "Nom";
            drpdepts.Properties.ValueMember = "Id";
            drpdepts.Properties.BestFit();

        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var dept = txtdept.Text.Trim();
            var deptchief =drpdepts.Text.Trim();
            var desc = txtdesc.Text.Trim();

            if (dept.Length == 0)
            {
                dept.DisplayErrorFrDialog(" Nom du département");
            }
            else if (desc.Length == 0)
            {
                "".DisplayErrorFrDialog(" Description");
            }
            else
            {
                int deptId = 0;
                if (deptchief.Length > 0)
                {
                    deptId=int.Parse(drpdepts.EditValue.ToString());
                }
                var data = new
                {
                    Id = 0,
                    Département = dept,
                    ID_Chef_Département = deptId,
                    Description = desc,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(_email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(new CommonHelpers().IsAppInProd()) + "Departments";
                using (var client = new HttpClient())
                {
                    try
                    {
                        JsonSerializerOptions options =new JsonSerializerOptions()
                        {
                            ReferenceHandler = ReferenceHandler.IgnoreCycles,
                            WriteIndented = true
                        };
                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data,options);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("Le département a été créé");
                                btnadd.Enabled = false;
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
                    catch (Exception ex)
                    {
                        //XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        throw ex;
                    }
                }
            }
        }


    }
}