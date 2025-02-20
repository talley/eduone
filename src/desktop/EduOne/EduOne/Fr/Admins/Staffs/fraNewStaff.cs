using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Fr.Models;
using EduOne.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Humanizer.On;

namespace EduOne.Fr.Admins.Staffs
{
    public partial class fraNewStaff : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        CommonHelpers helpers=new CommonHelpers();
        public fraNewStaff(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraNewStaff_Load(object sender, EventArgs e)
        {
            var roles = await helpers.GettStaffRolesAsync();

            var needed_roles = roles.Select(x => new {x.Id,x.Role}).ToList();

            var genders = helpers.GetGenders();
            var needed_genders=new List<MyRoles>();
            foreach (var g in genders)
            {
                needed_genders.Add(new MyRoles { Role = g });
            }

            drproles.Properties.DataSource = needed_roles;
            drproles.Properties.DisplayMember = "Role";
            drproles.Properties.ValueMember = "Role";
            drproles.Properties.BestFit();

            drpgenders.Properties.DataSource = needed_genders;
            drpgenders.Properties.DisplayMember = "Role";
            drpgenders.Properties.ValueMember = "Role";
            drpgenders.Properties.BestFit();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var lname=txtlname.Text;
            var fname=txtfname.Text;
            var sname=txtsurname.Text;
            var lieuxnaiss=txtlieunaiss.Text;
            var datenaiss=dtdatenaissance.Text;
            var gender=drpgenders.Text;
            var email=txtemail.Text;
            var phone=txtphone.Text;
            var fax=txtfax.Text;
            var hidedate=dthiredate.Text;
            var role=drproles.Text;
            var notes=txtnotes.Text;

            if (lname.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Nom");
            }
            else if (fname.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Prénom");
            }
            else if (lieuxnaiss.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Lieux De Naissance");
            }
            else if (datenaiss.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Date De Naissance");
            }
            else if (gender.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Genre");
            }
            else if (email.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Email");
            }
            else if (!email.IsEmailValid())
            {
                ".".DisplayErrorFrDialog(" Email Valide");
            }
            else if (phone.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Téléphone");
            }
            else if (hidedate.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Date d'embauche");
            }
            else if (role.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Role");
            }
            else if (notes.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Notes");
            }
            else
            {

                var data = new
                {
                    Id=0,
                    Nom = lname,
                    Prénom = fname,
                    Surnom = sname,
                    LieuNaissance =lieuxnaiss,
                    DateNaissance=DateTime.Parse(dtdatenaissance.EditValue.ToString()),
                    Genre=gender,
                    Email=email,
                    TelePhone=phone,
                    Fax=fax,
                    Date_Embauche= DateTime.Parse(dthiredate.EditValue.ToString()),
                    Role=role,
                    Notes=notes,
                    Status=ckstatus.Checked,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(_email)

                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helpers.IsAppInProd()) + "Staffs";

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
                            var staff = JsonConvert.DeserializeObject<Models.Staffs>(responseData);
                            Invoke(new Action(async () =>
                            {
                                await AddStaffNoteAsync(staff.Id, txtnotes.Text);
                                "".DisplayDialog($"Le personnel a été créé");
                                btnadd.Enabled = false;
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");

                    }
                }

            }
        }

        private async Task<Models.StaffNotes> AddStaffNoteAsync(int id, string note)
        {
            var result = new StaffNotes();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helpers.IsAppInProd()) + "StaffNotes";
            using (var client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                    Id=0,
                    EId=id,
                    Notes=txtnotes.Text,
                    AjouterAu=DateTime.Now,
                    AjouterPar=ApplicationHelpers.GetSystemUser(_email)
                    };

                    var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var staff = JsonConvert.DeserializeObject<Models.Staffs>(responseData);
                        Invoke(new Action(async () =>
                        {
                            await AddStaffNoteAsync(staff.Id, txtnotes.Text);
                            "".DisplayDialog($"Le personnel a été créé");
                            btnadd.Enabled = false;
                        }));
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }

            return result;
        }
    }

    public struct MyRoles
    {
        public string Role { get; set; }
    }
}