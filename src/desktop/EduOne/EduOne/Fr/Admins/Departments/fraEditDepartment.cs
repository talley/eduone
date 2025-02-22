using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;
using Config = System.Configuration.ConfigurationManager;

namespace EduOne.Fr.Admins.Departments
{
    public partial class fraEditDepartment : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        int _id;
        CommonHelpers helper = new CommonHelpers();
        public fraEditDepartment(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditDepartment_Load(object sender, EventArgs e)
        {
            var dptheads = await helper.GetDepartmentHeadsAsync();

            var needed = dptheads.Select(x => new
            {
                x.Id,
                Nom = x.Nom + " " + x.Prénom
            }).ToList();

            drpdepts.Properties.DataSource = needed;
            drpdepts.Properties.DisplayMember = "Nom";
            drpdepts.Properties.ValueMember = "Id";
            drpdepts.Properties.BestFit();

            var depts=await helper.GetDepartmentsAsync();
            var department=depts.SingleOrDefault(x=>x.Id==_id);

            if (department != null)
            {
                var head=dptheads.SingleOrDefault(x=>x.Id==department.ID_Chef_Département.Value);
                var fullname= head?.Nom + " " + head?.Prénom;

                lblhead.Text = fullname;

                txtdept.Text = department.Nom_Département;
                txtdesc.Text = department.Description;
                drpdepts.Text = fullname;
            }
        }



        private async void btnedit_Click(object sender, EventArgs e)
        {

            var dept = txtdept.Text.Trim();
            var deptchief = drpdepts.Text.Trim();
            var desc = txtdesc.Text.Trim();
            int id = _id;

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
                    deptId = int.Parse(drpdepts.EditValue.ToString());
                }
                var depts = await helper.GetDepartmentsAsync();
                var department=depts.SingleOrDefault(x=>x.Id == id);
                var data = new
                {
                    Id = id,
                    Département = dept,
                    ID_Chef_Département = deptId,
                    Description = desc,
                    AjouterAu =department.AjouterAu,
                    AjouterPar =department.AjouterPar,
                    ModifierAu = DateTime.Now,
                    ModifierPar = ApplicationHelpers.GetSystemUser(_email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"Departments/{_id}";
                using (var client = new HttpClient())
                {
                    try
                    {
                        JsonSerializerOptions options = new JsonSerializerOptions()
                        {
                            ReferenceHandler = ReferenceHandler.IgnoreCycles,
                            WriteIndented = true
                        };
                        var jsonData = JsonSerializer.Serialize(data, options);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("Le département a été mis a jour");
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
                    catch (Exception ex)
                    {
                        //XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        throw ex;
                    }
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}