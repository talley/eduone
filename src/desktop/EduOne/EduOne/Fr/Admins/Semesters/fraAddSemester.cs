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
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.Semesters
{
	public partial class fraAddSemester: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();

        public fraAddSemester(string email)
		{
            InitializeComponent();
            _email = email;
		}

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private  void fraAddSemester_Load(object sender, EventArgs e)
        {
            txtyear.Text = DateTime.Now.Year.ToString();
        }

        private async void btnadd_Click(object sender, EventArgs e)
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
                var data = new
                {
                    ID = 0,
                    Année = int.Parse(syear),
                    Semestre = semester,
                    Notes = notes,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(_email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "Semesters";

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

                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog($"Ce semestre a été créé");
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