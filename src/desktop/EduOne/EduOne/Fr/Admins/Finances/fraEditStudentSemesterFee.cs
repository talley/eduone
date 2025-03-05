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
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.Finances
{
    public partial class fraEditStudentSemesterFee : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        readonly int _id;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraEditStudentSemesterFee(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {

            string semester = txtsemesterid.Text;
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
                        "".DisplayDialog("Le montant reçu est inférieur au montant dû.");
                        txtbalance.BackColor = Color.Red;
                        txtbalance.ForeColor = Color.White;
                        txtbalance.Text = Math.Abs(balance).ToString();
                        ckstatus.Checked = false;
                    }
                }
            }
        }


        private async void btnpay_Click(object sender, EventArgs e)
        {
            string student = txtstudentid.Text;
            string semester = txtsemesterid.Text;
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
                int studentId = int.Parse(txtstudentid.Text.ToString());
                int semesterId = int.Parse(txtsemesterid.Text.ToString());
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
                        await ExecutePaymentAsync(notes, studentId, semesterId, d_amountRec, d_balance, d_amountDue).ConfigureAwait(false);
                    }
                    else
                    {
                        "".DisplayDialog("Le montant reçu est inférieur au montant dû.");
                        ckstatus.Checked = false;
                        txtbalance.BackColor = Color.Red;
                        txtbalance.ForeColor = Color.White;
                        txtbalance.Text = Math.Abs(xbalance).ToString();
                        await ExecutePaymentAsync(notes, studentId, semesterId, d_amountRec, d_balance, d_amountDue).ConfigureAwait(false);
                    }
                }
            }
        }

        private async Task ExecutePaymentAsync(string notes, int studentId, int semesterId, decimal d_amountRec, decimal d_balance,decimal amountDue)
        {
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"SemesterEnrollmentFees/{_id}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    JsonSerializerOptions options = new JsonSerializerOptions()
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles,
                        WriteIndented = true
                    };
                    var result = await GetStudentSemesterFeeAsync();
                    var data = new
                    {
                        GID = result.GID,
                        Id = _id,
                        EleveId = studentId,
                        SemestreId = semesterId,
                        Statut = ckstatus.Checked,
                        MontantDu= amountDue,
                        MontantReçu = d_amountRec,
                        Balance = d_balance,
                        Notes = notes,
                        AjouterAu =result.AjouterAu,
                        AjouterPar = result.AjouterPar,
                        ModifierAu = DateTime.Now,
                        ModifierPar = ApplicationHelpers.GetSystemUser(_email)
                    };

                    string jsonData = JsonSerializer.Serialize(data, options);

                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

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

        private async void fraEditStudentSemesterFee_Load(object sender, EventArgs e)
        {
            var result =await GetStudentSemesterFeeAsync();

            if (result != null)
            {
                txtstudentid.Text = result.EleveId.ToString();
                txtsemesterid.Text = result.SemestreId.ToString();
                if (result.Statut)
                {
                    ckstatus.Checked = true;
                }
                txtamountdue.Text = result.MontantReçu.ToString();
                txtbalance.Text = result.Balance.ToString();
                txtnotes.Text = result.Notes;
            }
        }

        private async Task<Models.SemesterEnrollmentFees> GetStudentSemesterFeeAsync()
        {
            var results = await helper.GetSemesterEnrollmentFeesAsync();
            var result = results.SingleOrDefault(x => x.Id == _id);
            return result;
        }
    }
}