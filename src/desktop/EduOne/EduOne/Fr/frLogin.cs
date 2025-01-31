using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.Admins;
using EduOne.Helpers;
using Config = System.Configuration.ConfigurationManager;


namespace EduOne.Fr
{
    public partial class frLogin : DevExpress.XtraEditors.XtraForm
    {
        public frLogin()
        {
            InitializeComponent();
        }

        private async void btnlogin_Click_old(object sender, EventArgs e)
        {
            var email = txtemail.Text.Trim();
            var password=txtpass.Text.Trim();

            if (email.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Email");
            }
            else if (password.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Password");
            }
            else
            {
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + $"Commons/Security/Authenticate/{email}/{password}";
                using (var client = new HttpClient())
                {
                    try
                    {
                        //var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            "".DisplayDialog("L'utilisateur a été authentifié.");
                            var welcomeForm = new fraWelcome(email);
                            Hide();
                            welcomeForm.ShowDialog();
                        }
                        else
                        {
                            XtraMessageBox.Show($"L'utilisateur n`a pas été authentifié. Erreur: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }

            }
        }


        private async void btnlogin_Click(object sender, EventArgs e)
        {
            var email = txtemail.Text.Trim();
            var password = txtpass.Text.Trim();

            if (email.Length == 0)
            {
                Invoke(new Action(() => ".".DisplayErrorFrDialog(" Email")));
            }
            else if (password.Length == 0)
            {
                Invoke(new Action(() => ".".DisplayErrorFrDialog(" Password")));
            }
            else
            {
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + $"Commons/Security/Authenticate/{email}/{password}";
                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result=bool.Parse(responseData);
                            if (result)
                            {

                                Invoke(new Action(() =>
                                {
                                    "".DisplayDialog("L'utilisateur a été authentifié.");
                                    var welcomeForm = new fraWelcome(email);
                                    Hide();
                                    welcomeForm.ShowDialog();
                                }));
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                    XtraMessageBox.Show($"L'utilisateur n'a pas été authentifié. Erreur: {response.StatusCode}")
                                ));
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                            XtraMessageBox.Show($"An error occurred: {ex.Message}")
                        ));
                    }
                }
            }
        }

        private bool IsAppInProd()
        {
            bool isAppInProd = bool.Parse(Config.AppSettings["IS_PROD"]);
            return isAppInProd;
        }
    }
}