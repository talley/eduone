using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using System.Net.Http;
using System.Globalization;

namespace EduOne.Fr.Admins.Finances.SemestersFees
{
    public partial class fraEditSemesterFee : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        readonly int _id;
        readonly CommonHelpers helper = new CommonHelpers();

        public fraEditSemesterFee(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task<string> GetSemesterAsync(int semestreId)
        {
            var semesters = await helper.GetSemestersAsync();
            var semester = semesters.SingleOrDefault(x => x.ID == semestreId);
            return semester.Semestre;
        }
        private async void fraEditSemesterFee_Load(object sender, EventArgs e)
        {
            "".DisplayDialog("Frais doivent etre comme sa: 257.00(ajouter .00 a la fin)");
            var fees = await helper.GetSemestersFeesAsync();
            if (fees != null)
            {
                var edit = fees.SingleOrDefault(x => x.Id == _id);

                if (edit != null)
                {
                    txtfees.Text = edit.Frais.ToString();
                    txtnotes.Text = edit.Notes;
                    txtsemester.Text = edit.SemestreId.ToString();// await GetSemesterAsync(edit.SemestreId);
                }
            }
        }

        private async void btnedit_Click(object sender, EventArgs e)
        {
            var s_semester = txtsemester.Text;
            var s_fees = txtfees.Text;
            var s_notes = txtnotes.Text;
            if (s_semester.Length == 0)
            {
                "".DisplayErrorFrDialog("Semestre");
            }
            else if (s_fees.Length == 0 || s_fees == "0")
            {
                "".DisplayErrorFrDialog("Frais");
            }
            else if (s_notes.Length == 0)
            {
                "".DisplayErrorFrDialog("Notes");
            }
            else
            {

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"SemesestersFees/{_id}";

                using (var client = new HttpClient())
                {
                    try
                    {
                        var edits = await helper.GetSemestersFeesAsync();
                        var edit = edits.SingleOrDefault(x => x.Id == _id);



                        var data = new
                        {
                            Id = _id,
                            SemestreId = int.Parse(txtsemester.Text.ToString()),
                            Frais = decimal.Parse(s_fees,CultureInfo.InvariantCulture),
                            Notes = s_notes,
                            AjouterAu = edit.AjouterAu,
                            AjouterPar = edit.AjouterPar,
                            ModifierAu = DateTime.Now,
                            ModifierPar = ApplicationHelpers.GetSystemUser(_email)
                        };

                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog($"Ce cours ({s_semester} ) a été mis a jour");
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
                    catch (ArgumentNullException ex)
                    {
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));
                    }
                    catch (HttpRequestException ex)
                    {
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));
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