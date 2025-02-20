using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using Newtonsoft.Json;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace EduOne.Fr.Admins.Staffs
{
    public partial class fraEditStaff : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        readonly int _id;

        CommonHelpers helpers = new CommonHelpers();
        public fraEditStaff(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditStaff_Load(object sender, EventArgs e)
        {
            Text = "Modification de l`enseignant(te)";

            var roles = await helpers.GettStaffRolesAsync();

            var needed_roles = roles.Select(x => new { x.Id, x.Role }).ToList();

            var genders = helpers.GetGenders();
            var needed_genders = new List<MyRoles>();
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

            var staffs = await helpers.GetStaffsAsync();
            if (staffs.Any())
            {

                var edit = staffs.SingleOrDefault(x => x.Id == _id);

                txtlname.Text = edit.Nom;
                txtfname.Text = edit.Prénom;
                txtsurname.Text = edit.Surnom;
                txtlieunaiss.Text = edit.LieuNaissance;
                dtdatenaissance.Text = edit.DateNaissance.ToString();
                drpgenders.Text = edit.Genre;
                txtemail.Text = edit.Email;
                txtphone.Text = edit.TelePhone;
                txtfax.Text = edit.Fax;
                dthiredate.Text = edit.Date_Embauche.ToString();
                drproles.Text = edit.Role;

                if (edit.Status)
                {
                    ckstatus.Checked = true;
                }
                else
                {
                    ckstatus.Checked = false;
                }
                txtnotes.Text = edit.Notes;
            }

            var note = txtnotes.Text.Trim();
            if (note.Length == 0)
            {
                xtraTabControl1.TabPages[1].PageEnabled = false;
            }
            else
            {
                xtraTabControl1.TabPages[1].PageEnabled = true;
            }
        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helpers.IsAppInProd()) + $"Staffs/{_id}";
            using (var client = new HttpClient())
            {
                try
                {
                    var lname = txtlname.Text;
                    var fname = txtfname.Text;
                    var sname = txtsurname.Text;
                    var lieuxnaiss = txtlieunaiss.Text;
                    var datenaiss = dtdatenaissance.Text;
                    var gender = drpgenders.Text;
                    var email = txtemail.Text;
                    var phone = txtphone.Text;
                    var fax = txtfax.Text;
                    var hidedate = dthiredate.Text;
                    var role = drproles.Text;
                    var notes = txtnotes.Text;

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
                        var staffs = await helpers.GetStaffsAsync();
                        var staff1 = staffs.SingleOrDefault(x => x.Id == _id);

                        var data = new
                        {
                            Id = _id,
                            Nom = lname,
                            Prénom = fname,
                            Surnom = sname,
                            LieuNaissance = lieuxnaiss,
                            DateNaissance = DateTime.Parse(dtdatenaissance.EditValue.ToString()),
                            Genre = gender,
                            Email = email,
                            TelePhone = phone,
                            Fax = fax,
                            Date_Embauche = DateTime.Parse(dthiredate.EditValue.ToString()),
                            Role = role,
                            Notes = notes,
                            Status = ckstatus.Checked,
                            AjouterAu = staff1.AjouterAu,
                            AjouterPar = staff1.AjouterPar,
                            ModifierAu = DateTime.Now,
                            ModifierPar = ApplicationHelpers.GetSystemUser(_email)

                        };

                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var staff = JsonConvert.DeserializeObject<Models.Staffs>(responseData);
                            Invoke(new Action(async () =>
                            {
                                "".DisplayDialog($"Le personnel a été mis a  jour.Veuillez ajouter quelques notes si nécessaire dans l'onglet suivant.");
                                btnadd.Enabled = false;
                            }));
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
        }

        private async void btnaddnewnote_Click(object sender, EventArgs e)
        {
            var note = txtnewnote.Text;
            if (note.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Note");
            }
            else
            {
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helpers.IsAppInProd()) + "StaffNotes";

                using (var client = new HttpClient())
                {
                    try
                    {
                        var data = new
                        {
                            Id=0,
                            EId=_id,
                            Notes=note,
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
                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog($"La note du personnel a été créé");
                                btnaddnewnote.Enabled = false;
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
    }
}