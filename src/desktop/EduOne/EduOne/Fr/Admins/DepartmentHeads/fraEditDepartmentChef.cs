using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;

namespace EduOne.Fr.Admins.DepartmentHeads
{
    public partial class fraEditDepartmentChef : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        int _id;
        CommonHelpers helper = new CommonHelpers();
        public fraEditDepartmentChef(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnupdate_Click(object sender, EventArgs e)
        {

            var fname = txtfname.Text.Trim();
            var lname = txtlname.Text;
            var phone = txtphone.Text;
            var status = ckstatus.Checked;
            var email = txtemail.Text.Trim();
            var fax = txtfax.Text.Trim();
            var notes = txtnotes.Text;
            var dob = dtdate.Text;

            if (fname.Length == 0)
            {
                fname.DisplayErrorFrDialog(" Prénom");
            }
            else if (lname.Length == 0)
            {
                lname.DisplayErrorFrDialog(" Nom");
            }
            else if (phone.Length == 0)
            {
                phone.DisplayErrorFrDialog(" Téléphone");
            }
            else if (email.Length == 0)
            {
                "".DisplayErrorFrDialog(" Email");
            }
            else if (!email.IsEmailValid())
            {
                "".DisplayErrorFrDialog(" Email Valide");
            }
            else if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog(" Notes");
            }
            else if (dob.Length == 0)
            {
                "".DisplayErrorFrDialog(" Date De Naissance");
            }
            else
            {
                var deptheads = await helper.GetDepartmentHeadsAsync();
               var depthead = deptheads.SingleOrDefault(x => x.Id == _id);

                var data = new
                {
                    Id = _id,
                    Nom = lname,
                    Prénom = fname,
                    TelePhone = phone,
                    DateNaissance = DateTime.Parse(dtdate.EditValue.ToString()),
                    Fax = fax,
                    Email = email,
                    Notes = notes,
                    Statut = status,
                    AjouterAu = depthead.AjouterAu,
                    AjouterPar = depthead.AjouterPar,
                    ModifierAu = DateTime.Now,
                    ModifierPar = ApplicationHelpers.GetSystemUser(email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"DepartmentHeads/{_id}";
                using (var client = new HttpClient())
                {
                    try
                    {
                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("Le chef de département a été mis a jour.");
                                btnupdate.Enabled = false;
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
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));

                    }
                }
            }
        }

        private async void fraEditDepartmentChef_Load(object sender, EventArgs e)
        {
            var deptheads = await helper.GetDepartmentHeadsAsync();
            if (deptheads != null)
            {
                var depthead=deptheads.SingleOrDefault(x=>x.Id==_id);
                if (depthead != null)
                {
                    txtemail.Text=depthead.Email;
                    txtfax.Text=depthead.Fax;
                    txtfname.Text=depthead.Prénom;
                    txtlname.Text = depthead.Nom;
                    txtnotes.Text = depthead.Notes;
                    txtphone.Text=depthead.TelePhone;
                    dtdate.EditValue=depthead.DateNaissance.ToString();
                }
            }
        }
    }
}