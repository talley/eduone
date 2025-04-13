using System;
using System.Net.Http;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.Admins;
using EduOne.Fr.Helpers;
using EduOne.Fr.Users;
using EduOne.Helpers;
using EduOne.Security.Encryption;
using Newtonsoft.Json;
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
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(new CommonHelpers().IsAppInProd()) + $"Commons/Security/Authenticate/{email}/{password}";
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
            var url = WebServerHelpers.GetApplicationUrl();
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
                ///Security/GetEncryptedPassword/{email}
                string apiUrl1 = WebServerHelpers.GetApiApplicationUrl(new CommonHelpers().IsAppInProd()) + $"Commons/Security/GetEncryptedPassword/{email}";
                string apiUrl2 = WebServerHelpers.GetApiApplicationUrl(new CommonHelpers().IsAppInProd()) + $"Commons/Security/GetRoleName/{email}";
                using (var client = new HttpClient())
                {
                    try
                    {
                        var response1 = await client.GetAsync(apiUrl1).ConfigureAwait(false);

                        if (response1.IsSuccessStatusCode)
                        {
                            var responseData = await response1.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var user_password=JsonConvert.DeserializeObject<string>(responseData);
                            var converted_password =StringCipherHelper.DecryptString(user_password);


                            if (password == converted_password)
                            {
                                //role area
                                var response2 = await client.GetAsync(apiUrl2).ConfigureAwait(false);
                                if (response2.IsSuccessStatusCode)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        "".DisplayDialog("L'utilisateur a été authentifié.");

                                    }));

                                    var responseData2 = await response2.Content.ReadAsStringAsync().ConfigureAwait(false);
                                    var role = JsonConvert.DeserializeObject<string>(responseData2);

                                    switch (role)
                                    {
                                        case "Administrateur":


                                            Invoke(new Action(() =>
                                            {
                                                var welcomeForm = new fraWelcome4(email);
                                                Hide();
                                                welcomeForm.ShowDialog();
                                            }));

                                            break;
                                        case "Utilisateur":
                                            Invoke(new Action(() =>
                                            {
                                                var welcomeForm2 = new fruWelcome(email);
                                                Hide();
                                                welcomeForm2.ShowDialog();
                                            }));
                                            break;
                                        default:
                                            break;
                                    }
                                }


                            }
                            else
                            {
                                Invoke(new Action(() =>
                                    XtraMessageBox.Show($"L'utilisateur n'a pas été authentifié.")
                                ));
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            throw ex;
                           // XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));
                    }
                } //end using




            }
        }

    }

    [JsonObject]
    public partial class StringResult
    {
        [JsonProperty("result",IsReference =true)]
       // [JsonIgnore]
        public string Result { get; set; }
    }
}