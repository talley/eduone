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
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EduOne.Fr.Admins.Enrollments
{
    public partial class fraEditEnrollment2 : DevExpress.XtraEditors.XtraForm
    {

        readonly string _email;
        readonly int _id;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraEditEnrollment2(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditEnrollment2_Load(object sender, EventArgs e)
        {
            var enrollements = await helper.GetEnrollmentsAsync();
            var edit = enrollements.SingleOrDefault(x => x.InscriptionID == _id);



            Invoke(new Action(() =>
            {
                txtgrade.Text = edit.Grade.ToString();
                txtnotes.Text = edit.Notes;
                dtdateinsc.Text = edit.Date_Inscription.ToString();

                txtcourseid.Text = edit.CoursId.ToString();
                txtstudentid.Text = edit.EleveId.ToString();

                if (edit.Statut)
                {
                    ckstatus.Checked = true;
                }
            }));
        }


        private async Task<(int studentId, string studentName)> GetStudentAsync2(int eleveId)
        {
            (int, string) result;
            var students = await helper.GetStudentsAsync();
            var student = students.SingleOrDefault(x => x.Id == eleveId);
            result = (student.Id, student.Nom + " " + student.Prénom);
            return result;
        }
        private async Task<(int courseId, string courseName)> GetCourseName2(int coursId)
        {
            (int, string) result;
            var courses = await helper.GetCoursesAsync();
            var course = courses.SingleOrDefault(x => x.Cours_Id == coursId);
            result = (course.Cours_Id, course.Nom_Cours);
            return result;
        }

        private void btnclose2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnaddnote_Click(object sender, EventArgs e)
        {
            xtraTabControl1.TabPages[1].PageEnabled = true;
            btnaddnote.Enabled = false;
        }

        private async void btnnewnote_Click(object sender, EventArgs e)
        {
            var notes = txtnote2.Text;
            if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog(" Notes");
            }
            else
            {

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "EnrollmentNotes";
                using (HttpClient client = new HttpClient())
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
                            AjouterPar = ApplicationHelpers.GetSystemUser(_email),
                        };

                        string jsonData = JsonSerializer.Serialize(data, options);

                        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("La Nouvelle inscription a été ajouter");
                                btnnewnote.Enabled = false;
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

        private async void btnedit_Click(object sender, EventArgs e)
        {
            string courseid = txtcourseid.Text;
            string studentid = txtstudentid.Text;
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
                            EleveId = int.Parse(txtstudentid.Text),
                            CoursId = int.Parse(txtcourseid.Text),
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
                        throw ex;
                    }
                }
            }
        }


    }
}