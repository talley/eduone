using System;
using System.Text;
using System.Linq;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Helpers;
using System.Net.Http;

namespace EduOne.Fr.Admins.Classrooms
{
    public partial class fraEditClassRoom : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        readonly int _id;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraEditClassRoom(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditClassRoom_Load(object sender, EventArgs e)
        {
            var classrooms = await helper.GetClassRoomsAsync();
            var classroom = classrooms.SingleOrDefault(x => x.Id == _id);

            txtbatim.Text = classroom.Bâtiment;
            txtcapacity.Value = classroom.Capacité;
            txtnotes.Text = classroom.Notes;
            txtnumerochambre.Text = classroom.NuméroChambre;
            if (classroom.Statut)
            {
                ckstatus.Checked = true;
            }
            else
            {
                ckstatus.Checked = false;
            }

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
                var classrooms = await helper.GetClassRoomsAsync();
                var classroom = classrooms.SingleOrDefault(x => x.Id == _id);

                var data = new
                {
                    Id = _id,
                    NuméroChambre = roomNumber,
                    Bâtiment = batiment,
                    Capacité = capacity,
                    Statut = status,
                    Notes = notes,
                    AjouterAu = classroom.AjouterAu,
                    AjouterPar = classroom.AjouterPar,
                    ModifierAu = DateTime.Now,
                    ModifierPar = ApplicationHelpers.GetSystemUser(_email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"Classrooms/{_id}";

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
                                "".DisplayDialog("La salle de classe a été mis a jour.");
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