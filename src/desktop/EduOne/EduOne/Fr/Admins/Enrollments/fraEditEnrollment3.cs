using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.Helpers;
using EduOne.Helpers;
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
using EduOne.Fr.helpers;
using EduOne.Fr.Models;

namespace EduOne.Fr.Admins.Enrollments
{
    public partial class fraEditEnrollment3 : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        readonly int _id;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraEditEnrollment3(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditEnrollment3_Load(object sender, EventArgs e)
        {
            var courses = await helper.GetCoursesAsync();
            var students = await helper.GetStudentsAsync();
            var semesters = await helper.GetSemestersAsync();

            var needed_students = students.Select(x => new
            {
                x.Id,
                x.Nom,
                x.Prénom,
                x.TelePhone,
                x.Ville,
                x.État,
                x.DateNaissance,
                x.Date_Inscription,
                x.Email
            }).ToList();

            var needed_semesters = semesters.Select(x => new { x.ID, x.Semestre, x.Statut }).ToList();

            //drpsemesters.Properties.DataSource = needed_semesters;
            //drpsemesters.Properties.DisplayMember = "Semestre";
            //drpsemesters.Properties.ValueMember = "ID";

            //txtstudentid.Properties.DataSource = needed_students;
            //txtstudentid.Properties.DisplayMember = "Nom";
            //txtstudentid.Properties.ValueMember = "Id";

            //drpcourseid.Properties.DataSource = courses;
            //drpcourseid.Properties.DisplayMember = "Nom_Cours";
            //drpcourseid.Properties.ValueMember = "Cours_Id";

            var enrollements = await helper.GetEnrollmentsAsync();
            var edit = enrollements.SingleOrDefault(x => x.InscriptionID == _id);

            var courseName = await GetCourseName(edit.CoursId).ConfigureAwait(false);
            var studentName = await GetStudentAsync2(edit.EleveId).ConfigureAwait(false);
            var semester = await GetSemesterAsync(edit.SemestreID).ConfigureAwait(false);

            Invoke(new Action(() =>
            {
                txtgrade.Text = edit.Grade.ToString();
                txtnotes.Text = edit.Notes;
                dtdateinsc.Text = edit.Date_Inscription.ToString();
                txtsemesters.Text=edit.SemestreID.ToString();
                txtstudentid.Text =studentName.studentName;// edit.EleveId.ToString();
                txtcourseid.Text=courseName;// edit.CoursId.ToString();
                txtsemesters.Text = semester.Semestre;

                if (edit.Statut)
                {
                    ckstatus.Checked = true;
                }

            }));
        }

        private async Task<Models.Semesters> GetSemesterAsync(int? semestreID)
        {
            var semesters = await helper.GetSemestersAsync();
            var semester = semesters.SingleOrDefault(x => x.ID == semestreID);
            return semester;
        }

        private async Task<(int studentId, string studentName)> GetStudentAsync2(int eleveId)
        {
            (int, string) result;
            var students = await helper.GetStudentsAsync();
            var student = students.SingleOrDefault(x => x.Id == eleveId);
            result = (student.Id, student.Nom + " " + student.Prénom);
            return result;
        }

        private async Task<string> GetCourseName(int coursId)
        {
            string result;
            var courses = await helper.GetCoursesAsync();
            var course = courses.SingleOrDefault(x => x.Cours_Id == coursId);
            result = course.Nom_Cours;
            return result;
        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var enrollements = await helper.GetEnrollmentsAsync();
            var edit = enrollements.SingleOrDefault(x => x.InscriptionID == _id);

            var courseid = txtcourseid.Text;
            var studentid = txtstudentid.Text;
            var grade = txtgrade.Text;
            var notes = txtnotes.Text;
            var semester = txtsemesters.Text;

            if (semester.Length == 0)
            {
                "".DisplayErrorFrDialog(" Semestre");
            }
            else if (courseid.Length == 0)
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
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"Enrollments/{_id}";
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
                            InscriptionID =edit.InscriptionID,
                            EleveId = edit.EleveId,
                            CoursId = edit.CoursId,
                            Date_Inscription = DateTime.Parse(dtdateinsc.EditValue.ToString()),
                            Grade = double.Parse(grade),
                            Statut = ckstatus.Checked,
                            Notes = notes,
                            SemestreID =edit.SemestreID,
                            AjouterAu = DateTime.Now,
                            AjouterPar = ApplicationHelpers.GetSystemUser(_email)
                        };


                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data, options);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("L'inscription a été mis a jour.Veuillez ajouter une note si nécessaire");
                                btnadd.Enabled = false;
                                btnnotes.Enabled = true;
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
                        //Invoke(new Action(() =>
                        //{
                        //    XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                        //}));
                        throw ex;
                    }
                }
            }
        }

        private async void btnnotes_Click(object sender, EventArgs e)
        {
            var notes = txtnotes2.Text;
            if (notes.Length == 0)
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
                            EId = 0,
                            Id = _id,
                            Notes = notes,
                            AjouterAu = DateTime.Now,
                            AjouterPar = ApplicationHelpers.GetSystemUser(_email)
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
                                btnnotes.Enabled=false;
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