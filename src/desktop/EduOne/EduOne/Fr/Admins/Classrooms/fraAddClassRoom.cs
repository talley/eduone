using System;
using System.Text;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Helpers;
using System.Net.Http;
using EduOne.Fr.Helpers;
using EduOne.Fr.helpers;

namespace EduOne.Fr.Admins.Classrooms
{
	public partial class fraAddClassRoom: DevExpress.XtraEditors.XtraForm
	{
        readonly  string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraAddClassRoom(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void fraAddClassRoom_Load(object sender, EventArgs e)
        {

        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            string roomNumber = txtnumerochambre.Text.Trim();
            string batiment = txtbatim.Text.Trim();
            int capacity = int.Parse(txtcapacity.Value.ToString());
            bool status = ckstatus.Checked;
            string notes = txtnotes.Text;

            if (roomNumber.Length == 0)
            {
                "".DisplayErrorFrDialog("Numéro de chambre");
            }
            else if (batiment.Length == 0)
            {
                "".DisplayErrorFrDialog("Nom du Bâtiment");
            }
            else if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog("Notes");
            }
            else
            {
                var data = new
                {
                    Id=0,
                    NuméroChambre=roomNumber,
                    Bâtiment=batiment,
                    Capacité=capacity,
                    Status=status,
                    Notes=notes,
                    AjouterAu=DateTime.Now,
                    AjouterPar=ApplicationHelpers.GetSystemUser(_email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "Classrooms";
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
                                "".DisplayDialog("La salle de classe a été ajoutée.");
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}