using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using EduOne.Data.Fr;
using EduOne.Helpers;
using EduOne.Repositories.Fr;
using Dapper;
using EduOne.Exts;
using EduOne.Fr.helpers;
using System.Net.Http;
using Config = System.Configuration.ConfigurationManager;
using EduOne.Fr.Helpers;
namespace EduOne.Fr.Admins
{
    public partial class fraAddUser : DevExpress.XtraEditors.XtraForm
    {
        private IRepository<ApplicationRoles> repository = new ApplicationRolesRepository();
        private readonly CommonHelpers helper = new CommonHelpers();
        readonly string _email;
        public fraAddUser()
        {
            InitializeComponent();
        }

        private async void fraAddUser_Load(object sender, EventArgs e)
        {
            //drproles.Properties.Columns["Id"].Visible = false;

            var roles = await helper.GetApplicationRolesAsync();
            var needed_roles = roles.Select(x => new
            {
               x.NomRole,x.Description,x.Id
            });
            drproles.Properties.DataSource = needed_roles;
            drproles.Properties.DisplayMember = "NomRole";
            drproles.Properties.ValueMember = "Id";

            drproles.Properties.BestFit();



        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var name = "Abibou";
            var r = await EncryptPasswordAsync(name);
            var username = txtusername.Text.Trim();
            var pass = txtpass.Text;
            var statut = ckstatus.Checked;
            var lname=txtlname.Text.Trim();
            var fname=txtfname.Text.Trim();
            var dob = dtdob.Text.ToString();
            var email = txtemail.Text.Trim();
            var role = drproles.Text;
            var notes = txtnotes.Text.Trim();

            if (username.Length == 0)
            {
                username.DisplayErrorFrDialog("Utilisateur");
            }
            else if(pass.Length==0)
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
            else if (email.Length>0 && !email.IsEmailValid())
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
                var users = await helper.GetApplicationUsersAsync();
                var user = users.SingleOrDefault(x => x.Email == email);
                if (user != null)
                {
                    "".DisplayDialog("Ce nom d'utilisateur existe déjà, entrez-en un autre.");
                }
                else
                {
                var data =new
                {
                    RoleId=await GetRoleIdAsync(role),
                    Utilisateur=username,
                    Password=pass,
                    Statut=statut,
                    Nom=lname,
                    Prenom=fname,
                    DateNaissance=dtdob.EditValue,
                    Notes=notes,
                    Email=email,
                    AjouterAu=DateTime.Now,
                    AjouterPar=ApplicationHelpers.GetSystemUser(email)
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(new CommonHelpers().IsAppInProd()) + "ApplicationUsers";
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
                                    "".DisplayDialog("L'utilisateur a été créé");
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
        }



        //WILL BE MOVED TO API
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
                result =await sqlcon.ExecuteScalarAsync<byte[]>(query, commandType: CommandType.Text);
            }
            return result;
        }
    }
}