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
using EduOne.Fr.Helpers;
using EduOne.Helpers;
using System.Net.Http;
using EduOne.Fr.Models;
using Telerik.WinControls.VirtualKeyboard;

namespace EduOne.Fr.Tools
{
	public partial class frAddTheme: DevExpress.XtraEditors.XtraForm
	{
        string _email;
        public frAddTheme(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void frAddTheme_Load(object sender, EventArgs e)
        {
            var themes = ThemeManager.Availables().OrderBy(x=>x).ToList();

            var myThemes = new List<MyTheme>();
            int count = 1;
            foreach(var t in themes)
            {
                myThemes.Add(new MyTheme {Id=count,Theme=t });
                count++;
            }

            drpthemes.Properties.DataSource = myThemes;
            drpthemes.Properties.DisplayMember = "Theme";
            drpthemes.Properties.ValueMember = "Theme";
            drpthemes.Properties.BestFit();
        }

        private void drpthemes_EditValueChanged(object sender, EventArgs e)
        {
            txtheme.Text = drpthemes.EditValue.ToString();
        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var helper = new CommonHelpers();
            var theme = txtheme.Text;


            if (theme.Length == 0)
            {
                ".".DisplayErrorFrDialog(" thème");
            }
            else
            {
                var data = new
                {
                    Id = 0,
                    Email=_email,
                    Thème=theme,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(_email)
                };
                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "UserThemes";
                var themes = await helper.GetUsersThemesAsync();
                if (themes.Any())
                {
                    var userTheme = themes.SingleOrDefault(x => x.Email == _email);
                    if (userTheme != null)
                    {
                        string delUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"UserThemes/{userTheme.Id}";
                        //delete it
                        using (var client = new HttpClient())
                        {
                            await client.DeleteAsync(delUrl).ConfigureAwait(false);
                        }
                    }
                }
                else
                {
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
                                    "".DisplayDialog("Ce thème a été ajouté");
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
                    } // end using

                }
                }

                    }
                }
    }
    struct MyTheme
    {
        public int Id { get; set; }
        public string Theme { get; set; }
    }
