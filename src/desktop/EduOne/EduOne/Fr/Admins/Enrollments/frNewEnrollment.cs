using System;
using System.Data;
using System.Text;
using System.Linq;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using EduOne.Helpers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using EduOne.Fr.helpers;

namespace EduOne.Fr.Admins.Enrollments
{
	public partial class frNewEnrollment: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public frNewEnrollment(string email)
		{
            InitializeComponent();
            _email = email;
		}

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void frNewEnrollment_Load(object sender, EventArgs e)
        {
            var courses = await helper.GetCoursesAsync();
            var students = await helper.GetStudentsAsync();

            var needed_students = students.Select(x => new
            {
                x.Id,x.Nom,x.Prénom,x.TelePhone,
                x.Ville,x.État,x.DateNaissance,x.Date_Inscription,x.Email
            }).ToList();

            drpstudentid.Properties.DataSource = needed_students;
            drpstudentid.Properties.DisplayMember = "Nom";
            drpstudentid.Properties.ValueMember = "Id";

            drpcourseid.Properties.DataSource = courses;
            drpcourseid.Properties.DisplayMember = "Nom_Cours";
            drpcourseid.Properties.ValueMember = "Cours_Id";

        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var courseid = drpcourseid.Text;
            var studentid = drpstudentid.Text;
            var grade = txtgrade.Text;
            var notes = txtnotes.Text;

            if (courseid.Length == 0)
            {
                "".DisplayErrorFrDialog(" Cour");
            }
            else if (studentid.Length == 0)
            {
                "".DisplayErrorFrDialog(ApplicationHelpers.GetAppDomain());
            }
            else if (grade.Length == 0)
            {
                "".DisplayErrorFrDialog(" Grade");
            }
            else if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog(" Notes");
            }
            else
            {
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "Enrollments";
                using (var client = new HttpClient())
                {
                    try
                    {
                        JsonSerializerOptions options = new JsonSerializerOptions()
                        {
                            ReferenceHandler = ReferenceHandler.IgnoreCycles,
                            WriteIndented = true
                        };

                        var data = new
                        {
                            InscriptionID = 0,
                            EleveId = int.Parse(drpstudentid.EditValue.ToString()),
                            CoursId = int.Parse(drpcourseid.EditValue.ToString()),
                            Date_Inscription = DateTime.Parse(dtdateinsc.EditValue.ToString()),
                            Grade = double.Parse(grade),
                            Statut = ckstatus.Checked,
                            Notes = notes,
                            AjouterAu = DateTime.Now,
                            AjouterPar=ApplicationHelpers.GetSystemUser(_email)
                        };

                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data, options);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("La Nouvelle inscription a été créé");
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