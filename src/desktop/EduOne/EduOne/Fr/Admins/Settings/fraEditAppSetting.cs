using System;
using System.Text;
using System.Linq;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using System.Net.Http;

namespace EduOne.Fr.Admins.Settings
{
    public partial class fraEditAppSetting : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        readonly int _id;
        readonly CommonHelpers helper = new CommonHelpers();

        public fraEditAppSetting(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditAppSetting_Load(object sender, EventArgs e)
        {
            var settings = await helper.GetApplicationSettings();
            var edit = settings.SingleOrDefault(x => x.ID == _id);

            txtkey.Text = edit.AppKey;
            txtvalue.Text = edit.AppValue;
            txtnotes.Text = edit.Notes;

            if (edit.Statut)
            {
                ckstatus.Checked = true;
            }
        }

        private async void btnedit_Click(object sender, EventArgs e)
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
                var settings = await helper.GetApplicationSettings();
                var edit = settings.SingleOrDefault(x => x.ID == _id);
                var data = new
                {
                    ID = _id,
                    AppKey = key,
                    AppValue = value,
                    CanBeAltered = true,
                    Notes = notes,
                    Statut = ckstatus.Checked,
                    AjouterAu = edit.AjouterAu,
                    AjouterPar = edit.AjouterPar,
                    ModifierAu = DateTime.Now,
                    ModifierPar = ApplicationHelpers.GetSystemUser(_email)
                };

                if (settings.Any())
                {


                        string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"ApplicationSettings/{_id}";

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
                                        "".DisplayDialog($"Ce cours ({key} ) a été mis a jour");
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}