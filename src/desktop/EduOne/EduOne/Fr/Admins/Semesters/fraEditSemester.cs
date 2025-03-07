using System;
using System.Text;
using System.Linq;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using System.Net.Http;

namespace EduOne.Fr.Admins.Semesters
{
	public partial class fraEditSemester: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        readonly int _id;
        public fraEditSemester(string email,int id)
		{
            InitializeComponent();
            _email = email;
            _id = id;
		}

        private async void fraEditSemester_Load(object sender, EventArgs e)
        {
            var semesters = await helper.GetSemestersAsync();
            var edit = semesters.SingleOrDefault(x => x.ID == _id);

            txtnotes.Text = edit.Notes;
            txtsemester.Text = edit.Semestre;
            txtyear.Text = edit.Année.ToString();

            if (edit.Statut)
            {
                ckstatus.Checked = true;
            }
            else
            {
                ckstatus.Checked = false;
            }
        }

        private  async void btnadd_Click(object sender, EventArgs e)
        {
            var syear = txtyear.Text;
            var semester = txtsemester.Text;
            var status = ckstatus.Checked;
            var notes = txtnotes.Text.Trim();

            if (semester.Length == 0)
            {
                "".DisplayErrorFrDialog(" semestre");
            }
            else if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog("Note");
            }
            else
            {
                var semesters = await helper.GetSemestersAsync();
                var edit = semesters.SingleOrDefault(x => x.ID == _id);
                var data = new
                {
                    ID =_id,
                    Année = int.Parse(syear),
                    Semestre = semester,
                    Notes = notes,
                    Statut=status,
                    AjouterAu = edit.AjouterAu,
                    AjouterPar = edit.AjouterPar,
                    ModifierAu = DateTime.Now,
                    ModifierPar = ApplicationHelpers.GetSystemUser(_email),
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"Semesters/{_id}";

                using (var client = new HttpClient())
                {
                    try
                    {
                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog($"Ce semestre a été mis a jour");
                                btnadd.Enabled = false;
                            }));
                            ;
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