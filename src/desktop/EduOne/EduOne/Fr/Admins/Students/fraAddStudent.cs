using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;

namespace EduOne.Fr.Admins.Students
{
    public partial class fraAddStudent : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        CommonHelpers helper=new CommonHelpers();

        public fraAddStudent(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void fraAddStudent_Load(object sender, EventArgs e)
        {
            LoadGenders();
            LoadCountries();
        }

        private void LoadCountries()
        {
            var countries=helper.GetAllCountrysNames().OrderBy(x=>x).ToList();
            countries.Add("Togo");
            foreach (var country in countries)
            {
                drpcountries.Items.Add(country);
            }

        }

        private void LoadGenders()
        {
            var genders = new List<string>
            {
                "Mâle","Femelle"
            };

            foreach (var gender in genders)
            {
                drpgenders.Items.Add(gender);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var lname = txtlname.Text;
            var fname = txtfname.Text.Trim();
            var surname=txtsname.Text.Trim();
            var lieux=txtlieuxnaissance.Text.Trim();
            var datenaiss=dtdatenaissance.Text.Trim();
            var gender=drpgenders.Text;
            var email = txtemail.Text.Trim();
            var phone = txtphone.Text;
            var fax = txtfax.Text.Trim();
            var address=txtaddress.Text.Trim();
            var address2 = txtaddresse2.Text.Trim();
            var city=txtville.Text.Trim();
            var etat=txtetat.Text.Trim();
            var country=drpcountries.Text;
            var dateinscrib=dtdateinsc.Text.Trim();
            var status = ckstatus.Checked;
            var notes = txtnotes.Text;


            if (lname.Length == 0)
            {
                lname.DisplayErrorFrDialog("Nom");
            }
            else if (fname.Length == 0)
            {
                fname.DisplayErrorFrDialog(" Prénom");
            }
            else if (lieux.Length == 0)
            {
                lieux.DisplayErrorFrDialog(" Lieux Naissance");//
            }
            else if (datenaiss.Length == 0)
            {
                datenaiss.DisplayErrorFrDialog(" Date Naissance");
            }
            else if (gender.Length == 0)
            {
                gender.DisplayErrorFrDialog(" Genre");
            }
            else if (email.Length == 0)
            {
                email.DisplayErrorFrDialog("Email");
            }
            else if (!email.IsEmailValid())
            {
                "".DisplayErrorFrDialog(" Email Valide");
            }
            else if (phone.Length == 0)
            {
                phone.DisplayErrorFrDialog(" Téléphone");
            }
            else if (address.Length == 0)
            {
                phone.DisplayErrorFrDialog(" Adresse");
            }
            else if (city.Length == 0)
            {
                "".DisplayErrorFrDialog(" Ville");
            }
            else if (etat.Length == 0)
            {
                "".DisplayErrorFrDialog(" État");
            }
            else if (country.Length == 0)
            {
                "".DisplayErrorFrDialog(" Pays");//dateinscrib
            }
            else if (dateinscrib.Length == 0)
            {
                "".DisplayErrorFrDialog(" Date d`inscription");//
            }
            else if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog(" Notes");//
            }
            else
            {

                var data = new
                {
                    Id = 0,
                    Nom = lname,
                    Prénom = fname,
                    Surnom=surname,
                    LieuNaissance=lieux,
                    DateNaissance = DateTime.Parse(dtdatenaissance.EditValue.ToString()),
                    Genre= drpgenders.SelectedItem.ToString(),
                    Email = email,
                    TelePhone = phone,
                    Fax = fax,
                    Addresse=address,
                    Addresse2=address2,
                    Ville=city,
                    État=etat,
                    Pays=drpcountries.SelectedItem.ToString(),
                    Date_Inscription=DateTime.Parse(dtdateinsc.EditValue.ToString()),
                    Notes = notes,
                    Statut = status,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "Students";
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
                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("L`eleve(etudiant) a été mis a ajouté.");
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
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));

                    }
                }
            }
        }
    }
}