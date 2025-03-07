using System;
using System.Text;
using System.Linq;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using System.Net.Http;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.Settings
{
	public partial class fraAddApplicationSetting: DevExpress.XtraEditors.XtraForm
	{
        string _email;

        public fraAddApplicationSetting(string email)
		{
            InitializeComponent();
            _email = email;
		}

        private void fraAddApplicationSetting_Load(object sender, EventArgs e)
        {

        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var helper = new CommonHelpers();
            var key = txtkey.Text.Trim();
            var value = txtvalue.Text;
            var notes = txtnotes.Text;


            if (key.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Clé");
            }
            else if (value.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Valeur");
            }
            else if (notes.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Notes");
            }
            else
            {
                var data = new
                {
                    ID=0,
                    AppKey = key,
                    AppValue = value,
                    CanBeAltered=true,
                    Notes = notes,
                    Statut=ckstatus.Checked,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(_email)
                };

                var settings = await helper.GetApplicationSettings();
                if (settings.Any())
                {

                    var setting = settings.SingleOrDefault(x => x.AppKey == key);
                    if(setting != null)
                    {
                        "".DisplayDialog("Cette Clé existe deja");
                    }
                    else
                    {
                            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "ApplicationSettings";

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
                                            "".DisplayDialog($"Ce cours ({key} ) a été créé");
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
        }

}