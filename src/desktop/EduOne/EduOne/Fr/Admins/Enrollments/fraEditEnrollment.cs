using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EduOne.Fr.Admins.Enrollments
{
    public partial class fraEditEnrollment : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        readonly int _id;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraEditEnrollment(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditEnrollment_Load(object sender, EventArgs e)
        {
            var courses = await helper.GetCoursesAsync();
            var students = await helper.GetStudentsAsync();

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

            drpstudentid.Properties.DataSource = needed_students;
            drpstudentid.Properties.DisplayMember = "Nom";
            drpstudentid.Properties.ValueMember = "Id";

            drpcourseid.Properties.DataSource = courses;
            drpcourseid.Properties.DisplayMember = "Nom_Cours";
            drpcourseid.Properties.ValueMember = "Cours_Id";

            var enrollements = await helper.GetEnrollmentsAsync();
            var edit = enrollements.SingleOrDefault(x => x.InscriptionID == _id);

            Invoke(new Action(() =>
            {
                txtgrade.Text = edit.Grade.ToString();
                txtnotes.Text = edit.Notes;
                dtdateinsc.Text = edit.Date_Inscription.ToString();


            }));


            var courseName = await GetCourseName2(edit.CoursId).ConfigureAwait(false);
            var studentName = await GetStudentAsync2(edit.EleveId).ConfigureAwait(false);

            Invoke(new Action(() =>
            {
                drpcourseid.Text = courseName.courseName;
                drpstudentid.Text= studentName.studentName;

                if (edit.Statut)
                {
                    ckstatus.Checked = true;
                }
            }));

        }

        private async Task<string> GetStudentAsync(int eleveId)
        {
            string result;
            var students = await helper.GetStudentsAsync();
            var student = students.SingleOrDefault(x => x.Id == eleveId);
            result = student.Nom + " " + student.Prénom;
            return result;
        }

        private async Task<(int studentId,string studentName)> GetStudentAsync2(int eleveId)
        {
            (int, string) result;
            var students = await helper.GetStudentsAsync();
            var student = students.SingleOrDefault(x => x.Id == eleveId);
            result = (student.Id,student.Nom + " " + student.Prénom);
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
        private async Task<(int courseId,string courseName)> GetCourseName2(int coursId)
        {
            (int,string) result;
            var courses = await helper.GetCoursesAsync();
            var course = courses.SingleOrDefault(x => x.Cours_Id == coursId);
            result = (course.Cours_Id,course.Nom_Cours);
            return result;
        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            string courseid = drpcourseid.Text;
            string studentid = drpstudentid.Text;
            string grade = txtgrade.Text;
            string notes = txtnotes.Text;

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
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"Enrollments/{_id}";
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        JsonSerializerOptions options = new JsonSerializerOptions()
                        {
                            ReferenceHandler = ReferenceHandler.IgnoreCycles,
                            WriteIndented = true
                        };
                        List<Models.Enrollments> enrollements = await helper.GetEnrollmentsAsync();
                        Models.Enrollments edit = enrollements.SingleOrDefault(x => x.InscriptionID == _id);
                        var data = new
                        {
                            InscriptionID = _id,
                            EleveId = int.Parse(drpstudentid.EditValue.ToString()),
                            CoursId = int.Parse(drpcourseid.EditValue.ToString()),
                            Date_Inscription = DateTime.Parse(dtdateinsc.EditValue.ToString()),
                            Grade = double.Parse(grade),
                            Statut = ckstatus.Checked,
                            Notes = notes,
                            ModifierAu = DateTime.Now,
                            ModifierPar = ApplicationHelpers.GetSystemUser(_email),
                            AjouterAu = edit.AjouterAu,
                            AjouterPar = edit.AjouterPar
                        };

                        string jsonData = JsonSerializer.Serialize(data, options);

                        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("La Nouvelle inscription a été mis a jour");
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
                        throw ex;
                    }
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void lkactualstudentid_Click(object sender, EventArgs e)
        {
            var student = await GetStudentAsync2(_id);
            drpstudentid.Text = student.studentName;
            "".DisplayDialog(ApplicationHelpers.GetAppDomain()+$":{student.studentName}, Id:{student.studentId}");
        }

        private async void lkactualcourseid_Click(object sender, EventArgs e)
        {
            var course = await GetCourseName2(_id);
            drpcourseid.Text = course.courseName;
            "".DisplayDialog("Cours:"+course.courseName+",Id:"+course.courseId);
        }

        private void btnclose2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnedit2_Click(object sender, EventArgs e)
        {
            string courseid = drpcourseid.Text;
            string studentid = drpstudentid.Text;
            string grade = txtgrade.Text;
            string notes = txtnotes.Text;

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
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"Enrollments/{_id}";
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        JsonSerializerOptions options = new JsonSerializerOptions()
                        {
                            ReferenceHandler = ReferenceHandler.IgnoreCycles,
                            WriteIndented = true
                        };
                        List<Models.Enrollments> enrollements = await helper.GetEnrollmentsAsync();
                        Models.Enrollments edit = enrollements.SingleOrDefault(x => x.InscriptionID == _id);
                        var data = new
                        {
                            InscriptionID = _id,
                            EleveId = int.Parse(drpstudentid.EditValue.ToString()),
                            CoursId = int.Parse(drpcourseid.EditValue.ToString()),
                            Date_Inscription = DateTime.Parse(dtdateinsc.EditValue.ToString()),
                            Grade = double.Parse(grade),
                            Statut = ckstatus.Checked,
                            Notes = notes,
                            ModifierAu = DateTime.Now,
                            ModifierPar = ApplicationHelpers.GetSystemUser(_email),
                            AjouterAu = edit.AjouterAu,
                            AjouterPar = edit.AjouterPar
                        };

                        string jsonData = JsonSerializer.Serialize(data, options);

                        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("La Nouvelle inscription a été mis a jour");
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
                        throw ex;
                    }
                }
            }
                }
    }
}