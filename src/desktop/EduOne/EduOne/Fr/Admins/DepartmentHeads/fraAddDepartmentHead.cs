using System;
using System.Net.Http;
using System.Text;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;

namespace EduOne.Fr.Admins.DepartmentHeads
{
    public partial class fraAddDepartmentHead : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        CommonHelpers helper=new CommonHelpers();
        public fraAddDepartmentHead(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void fraAddDepartmentHead_Load(object sender, EventArgs e)
        {

        }

        private async void btnadd_Click(object sender, EventArgs e)
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

                var data = new
                {
                    Id=0,
                    Nom = lname,
                    Prénom = fname,
                    TelePhone=phone,
                    DateNaissance = DateTime.Parse(dtdate.EditValue.ToString()),
                    Fax = fax,
                    Email = email,
                    Notes = notes,
                    Statut=status,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "DepartmentHeads";
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
                            Invoke(new Action(() => {
                                "".DisplayDialog("Le département a été créé.");
                                btnadd.Enabled = false;
                            }));

                        }
                        else
                        {
                            Invoke(new Action(() => {
                                XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                            }));

                        }
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() => {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));

                    }
                }
            }
        }
    }
}