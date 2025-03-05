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
using DevExpress.Utils;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EduOne.Fr.Admins.Finances.SemestersFees
{
	public partial class fraSemesterEnrollmentFees: DevExpress.XtraEditors.XtraForm
	{
		readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraSemesterEnrollmentFees(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraSemesterEnrollmentFees_Load(object sender, EventArgs e)
        {
            var students = await helper.GetStudentsAsync();
            var studentsfees = await helper.GetSemesterEnrollmentFeesAsync();
            if (studentsfees.Any())
            {
                var result = (from st in students
                             join fee in studentsfees on st.Id equals fee.SemestreId
                             where fee.Statut==false
                             select new
                             {
                                 st.Id,
                                 Nom = st.Nom + " " + st.Prénom,
                                 st.LieuNaissance,
                                 st.DateNaissance,
                                 st.Genre,
                                 st.Email,
                                 Téléphone = st.TelePhone,
                                 st.Addresse,
                                 st.Ville,
                                 st.Date_Inscription,
                                 st.Statut
                             }).ToList();

                drpstudents.Properties.DataSource = result;
                drpstudents.Properties.DisplayMember = "Nom";
                drpstudents.Properties.ValueMember = "Id";
                drpstudents.Properties.BestFit();
            }
            else
            {

                if (students.Any())
                {
                    var needed_students = students.Select(x => new
                    {
                        x.Id,
                        Nom = x.Nom + " " + x.Prénom,
                        x.LieuNaissance,
                        x.DateNaissance,
                        x.Genre,
                        x.Email,
                        Téléphone = x.TelePhone,
                        x.Addresse,
                        x.Ville,
                        x.Date_Inscription,
                        x.Statut
                    });

                    drpstudents.Properties.DataSource = needed_students;
                    drpstudents.Properties.DisplayMember = "Nom";
                    drpstudents.Properties.ValueMember = "Id";
                    drpstudents.Properties.BestFit();
                }

                List<Models.Semesters> semesters = await helper.GetSemestersAsync();
                if (semesters.Any())
                {
                    drpsemesters.Properties.DataSource = semesters;
                    drpsemesters.Properties.DisplayMember = "Semestre";
                    drpsemesters.Properties.ValueMember = "ID";
                    drpsemesters.Properties.BestFit();
                }
            }

        }

        private void drpsemesters_SelectionChanged(object sender, DevExpress.XtraEditors.Controls.PopupSelectionChangedEventArgs e)
        {
            int x = 100;
        }

        private async void drpsemesters_EditValueChanged(object sender, EventArgs e)
        {
            var semesterFees = await helper.GetSemestersFeesAsync();
            if (semesterFees.Any())
            {
                int Id = int.Parse(drpsemesters.EditValue.ToString());
                Models.SemesestersFees semesterFee = semesterFees.SingleOrDefault(x => x.SemestreId == Id);
                if (semesterFee != null)
                {

                    txtamountdue.Text = semesterFee.Frais.ToString();
                }
            }
        }

        private async void btnpaid_Click(object sender, EventArgs e)
        {
            string student = drpstudents.Text;
            string semester = drpsemesters.Text;
            bool status = ckstatus.Checked;
            string amountDue = txtamountdue.Text;
            string amountRect = txtamountrec.Text;
            string balance = txtbalance.Text;
            string notes = txtnotes.Text;

            if (student.Length == 0)
            {
                "".DisplayErrorFrDialog("Étudiant(Eleve)");
            }
            else if (semester.Length == 0)
            {
                "".DisplayErrorFrDialog("Semestre");
            }
            else if (amountRect.Length == 0)
            {
                "".DisplayErrorFrDialog("Montant reçu");
            }
            else if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog("Notes");
            }
            else
            {
                int studentId = int.Parse(drpstudents.EditValue.ToString());
                int semesterId = int.Parse(drpsemesters.EditValue.ToString());
                decimal d_amountDue = decimal.Parse(amountDue);
                decimal d_amountRec = decimal.Parse(amountRect);
                decimal d_balance = decimal.Parse(balance);

                if (amountRect.Length > 0 && amountDue.Length > 0)
                {
                    decimal xbalance = d_amountDue - d_amountRec;
                    if (xbalance <= 0)
                    {
                        txtbalance.BackColor = Color.Green;
                        txtbalance.ForeColor = Color.White;
                        txtbalance.Text = Math.Abs(xbalance).ToString();
                        ckstatus.Checked = true;
                        await ExecutePaymentAsync(notes, studentId, semesterId, d_amountRec, d_balance).ConfigureAwait(false);
                    }
                    else
                    {
                        "".DisplayDialog("Le montant reçu est inférieur au montant dû.");
                        ckstatus.Checked = false;
                        txtbalance.BackColor = Color.Red;
                        txtbalance.ForeColor = Color.White;
                        txtbalance.Text = Math.Abs(xbalance).ToString();
                        await ExecutePaymentAsync(notes, studentId, semesterId, d_amountRec, d_balance).ConfigureAwait(false);
                    }
                }
            }
        }

        private async Task ExecutePaymentAsync(string notes, int studentId, int semesterId, decimal d_amountRec, decimal d_balance)
        {
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "SemesterEnrollmentFees";
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
                        GID = Guid.NewGuid(),
                        Id = 0,
                        EleveId = studentId,
                        SemestreId = semesterId,
                        Statut = ckstatus.Checked,
                        MontantReçu = d_amountRec,
                        Balance = d_balance,
                        Notes = notes,
                        AjouterAu = DateTime.Now,
                        AjouterPar = ApplicationHelpers.GetSystemUser(_email)
                    };

                    string jsonData = JsonSerializer.Serialize(data, options);

                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        Invoke(new Action(() =>
                        {
                            "".DisplayDialog("Le paiement de l'étudiant(eleve) a été soumis");
                            btnpay.Enabled = false;
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

        private void txtamountdue_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            string semester = drpsemesters.Text;
            string amountDue = txtamountdue.Text;
            string amountRect = txtamountrec.Text;
            if (amountRect.Length == 0)
            {
                "".DisplayErrorFrDialog("Montant reçu");

            }
            else if (semester.Length == 0)
            {
                "".DisplayErrorFrDialog("Semestre");
            }
            else
            {
                if (amountRect.Length > 0 && amountDue.Length > 0)
                {
                    decimal d_amountDue = decimal.Parse(amountDue);
                    decimal d_amountRec = decimal.Parse(amountRect);
                    decimal balance = d_amountDue - d_amountRec;
                    if (balance <= 0)
                    {
                        ckstatus.Checked = true;
                        txtbalance.BackColor = Color.Green;
                        txtbalance.ForeColor = Color.White;
                        txtbalance.Text = Math.Abs(balance).ToString();
                    }
                    else
                    {
                        "".DisplayErrorFrDialog("Le montant reçu est inférieur au montant dû.");
                        txtbalance.BackColor = Color.Red;
                        txtbalance.ForeColor = Color.White;
                        txtbalance.Text = Math.Abs(balance).ToString();
                        ckstatus.Checked = false;
                    }
                }

            }
        }
    }
}