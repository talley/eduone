using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using EduOne.Data.Fr;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Fr.Logging;
using EduOne.Helpers;
using EduOne.Repositories.Fr;
using Config = System.Configuration.ConfigurationManager;
namespace EduOne.Fr.Admins
{
    public partial class fraEditUser : DevExpress.XtraEditors.XtraForm
    {

        private IRepository<ApplicationRoles> repository = new ApplicationRolesRepository();
      //  private IRepository<ApplicationUsers> usersrepository = new ApplicationUsersRepository();
        private Guid _Id;
        private string _email;

        public fraEditUser(string email, Guid id)
        {
            InitializeComponent();

            _email = email;
            _Id = id;

        }

        private async void fraEditUser_Load(object sender, EventArgs e)
        {
            var roles = await ApplicationUsersHelper.GetRolesAsync();
            var roleAppend = "";
            var users=await ApplicationUsersHelper.GetApplicationUsersAsync();
            if (users != null)
            {
                var user=users.SingleOrDefault(x => x.Id == _Id);
                if (user != null)
                {
                    var role = roles.SingleOrDefault(x => x.Id == user.RoleId);
                    roleAppend = role.NomRole;
                    txtusername.Text = user.Utilisateur;
                    txtpass.Text = "";
                    ckstatus.Checked = user.Statut;
                    txtlname.Text = user.Nom;
                    txtfname.Text = user.Prenom;
                    dtdob.Text = user.DateNaissance.ToString();
                    txtemail.Text = user.Email;
                    drproles.Text = role.NomRole;///
                    txtnotes.Text =user.Notes;

                }

            }
            //var roles = await repository.GetAllAsync();
            var needed_roles = roles.Select(x => new
            {
                x.NomRole,
                x.Description,
                x.Id
            });

            drproles.Properties.DataSource = needed_roles;
            drproles.Properties.DisplayMember = "NomRole";
            drproles.Properties.ValueMember = "Id";

            drproles.Properties.BestFit();

            drproles.Text = roleAppend;
        }

        private async void btnedituser_Click(object sender, EventArgs e)
        {
             var Id = _Id;
            var name = "Abibou";
            var r = await EncryptPasswordAsync(name);
            var username = txtusername.Text.Trim();
            var pass = txtpass.Text;
            var statut = ckstatus.Checked;
            var lname = txtlname.Text.Trim();
            var fname = txtfname.Text.Trim();
            var dob = dtdob.Text.ToString();
            var email = txtemail.Text.Trim();
            var role = drproles.Text;
            var notes = txtnotes.Text.Trim();

            if (username.Length == 0)
            {
                username.DisplayErrorFrDialog("Utilisateur");
            }
            else if (pass.Length == 0)
            {
                "".DisplayErrorFrDialog("Password");
            }
            else if (lname.Length == 0)
            {
                "".DisplayErrorFrDialog("Nom");
            }
            else if (fname.Length == 0)
            {
                "".DisplayErrorFrDialog("Prénom");
            }
            else if (dob.Length == 0)
            {
                "".DisplayErrorFrDialog("Date de naissance");
            }
            else if (email.Length == 0)
            {
                "".DisplayErrorFrDialog(" email");
            }
            else if (email.Length > 0 && !email.IsEmailValid())
            {
                "".DisplayDialog("Veuillez entrer une adresse e-mail valide");
            }
            else if (role.Length == 0)
            {
                "".DisplayErrorFrDialog(" Role");
            }
            else if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog(" Notes");
            }
            else
            {
                var apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "/ApplicationUsers";
                var user = await GetApplicationUserAsync().ConfigureAwait(false);
                byte[] apipassword = null;
                var currentPass=user.Password;
                if (txtpass.Text.Length == 0)
                {
                    apipassword = currentPass;
                }
                else
                {
                    apipassword = await GetUserPasswordAsync(txtpass.Text);
                }
                var data = new
                {
                    Id = _Id,
                    RoleId = await GetRoleIdAsync(role),
                    Utilisateur = username,
                    Password = apipassword,
                    Statut = statut,
                    Nom = lname,
                    Prenom = fname,
                    DateNaissance = dtdob.EditValue,
                    Notes = notes,
                    Email = email,
                    AjouterAu = DateTime.Now,
                    AjouterPar = ApplicationHelpers.GetSystemUser(email)
                };

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
                            "".DisplayDialog("L'utilisateur a été modifier");
                            btnedituser.Enabled = false;
                        }
                        else
                        {
                            XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        private async Task<byte[]> GetUserPasswordAsync(string password_plain)
        {
            byte[] result = null;
            ////api/Commons/Security/EncryptPassword/{password}
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "/Commons/";
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl+ $"Security/EncryptPassword/{password_plain}").ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = Encoding.UTF8.GetBytes(responseData);
                    }
                    else
                    {
                        XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            return result;
        }

        private bool IsAppInProd()
        {
            bool isAppInProd =bool.Parse(Config.AppSettings["IS_PROD"]);
            return isAppInProd;
        }


        //THESE METHODS WILL BE MOVED TO THE API
        public async Task<ApplicationUsers> GetApplicationUserAsync()
        {
            var user = new ApplicationUsers();
            try
            {
                var users = await GetApplicationUsersAsync();
                user = users.SingleOrDefault(x => x.Id == _Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;

        }
        public async Task<List<ApplicationUsers>> GetApplicationUsersAsync()
        {
            var users = new List<ApplicationUsers>();

            try
            {
                users = await ApplicationUsersHelper.GetApplicationUsersAsync();
            }
            catch (Exception ex)
            {
                ex.LogExceptionToDatabase("EduOne", "fraEditUser", 175);
                "".DisplayDialog(ex.Message);
            }
            return users;

        }
        private async Task<Guid> GetRoleIdAsync(string role)
        {
            var cs = DbHelpers.CS;
            var query = $"SELECT dbo.func_get_roleId('{role}')";
            Guid result;
            using (IDbConnection sqlcon = new SqlConnection(cs))
            {
                result = await sqlcon.ExecuteScalarAsync<Guid>(query, commandType: CommandType.Text);
            }

            return result;
        }
        public async Task<byte[]> EncryptPasswordAsync(string password)
        {
            var cs = DbHelpers.CS;
            var query = $"SELECT dbo.func_encrypt_password('{password}')";
            byte[] result;
            using (IDbConnection sqlcon = new SqlConnection(cs))
            {
                result = await sqlcon.ExecuteScalarAsync<byte[]>(query, commandType: CommandType.Text);
            }

            return result;
        }

        private void btnchangepwd_Click(object sender, EventArgs e)
        {
            txtpass.Enabled = true;
        }
    }
}