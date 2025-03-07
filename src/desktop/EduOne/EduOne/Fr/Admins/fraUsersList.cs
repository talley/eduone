using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins
{
    public partial class fraUsersList : DevExpress.XtraEditors.XtraForm
    {
        readonly CommonHelpers helpers = new CommonHelpers();
        public fraUsersList()
        {
            InitializeComponent();
            //GridColumn gridColumn = gridView1.Columns.AddVisible("Modifier", string.Empty);
            //RepositoryItemButtonEdit repositoryItemButtonEdit = new RepositoryItemButtonEdit();
            //repositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            //repositoryItemButtonEdit.ButtonClick += repositoryItemButtonEdit1_ButtonClick;
            //gridControl1.RepositoryItems.Add(repositoryItemButtonEdit);
            //gridColumn.ColumnEdit = repositoryItemButtonEdit;
            //gridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
        }

       public struct CustomData
        {
            public Guid Id { get; set; }
            public string Rôle { get; set; }
            public string Utilisateur { get; set; }
            public bool Statut { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public DateTime DateNaissance { get; set; }
            public string Notes { get; set; }
            public string Email { get; set; }
            public DateTime AjouterAu { get; set; }
            public string AjouterPar { get; set; }
        }
        public async Task<List<CustomData>> SearchData()
        {
            var result = new List<CustomData>();
            var users = await helpers.GetApplicationUsersAsync();// GetUsersAsync();

            var xneeded_users = await Task.WhenAll(

                users.Select(async x => new
                {
                    x.Id,
                    Rôle = await GetRoleIdAsync(x.RoleId),
                    x.Utilisateur,
                    x.Statut,
                    x.Nom,
                    x.Prenom,
                    x.DateNaissance,
                    x.Notes,
                    x.Email,
                    x.AjouterAu,
                    x.AjouterPar
                }));


            foreach (var u in xneeded_users)
            {
                result.Add(new CustomData
                {
                    Id = u.Id,
                    Rôle=u.Rôle,
                    Utilisateur=u.Utilisateur,
                    Statut=u.Statut,
                    Nom=u.Nom,
                    Prenom=u.Prenom,
                    DateNaissance=u.DateNaissance,
                    Notes=u.Notes,
                    Email=u.Email,
                    AjouterAu=u.AjouterAu,
                    AjouterPar=u.AjouterPar,
                });
            }
            return result;
        }
        private async void fraUsersList_Load(object sender, EventArgs e)
        {
            //txtsearch.Properties.NullValuePrompt = "Entrer nom du l`utilisateur..";
            Text = "Liste des Utilisateurs";
            var users = await helpers.GetApplicationUsersAsync();// GetUsersAsync();

            var xneeded_users = await Task.WhenAll(

              users.Select(async x => new
              {
                  x.Id,
                  Rôle = await GetRoleIdAsync(x.RoleId),
                  x.Utilisateur,
                  x.Statut,
                  x.Nom,
                  x.Prenom,
                  x.DateNaissance,
                  x.Notes,
                  x.Email,
                  x.AjouterAu,
                  x.AjouterPar
              }));


            gridControl1.DataSource= xneeded_users.ToList();
            gridView1.BestFitColumns();

            var usernames = xneeded_users.Select(x =>new
            {
                x.Utilisateur,x.Nom,x.Prenom
            }).ToList();


            drpsearch.Properties.DataSource = usernames;
            drpsearch.Properties.DisplayMember = "Utilisateur";
            drpsearch.Properties.ValueMember = "Utilisateur";
        }

        public async Task<string> GetRoleIdAsync(Guid RoleId)
        {
            string result = "";
            var roles = await helpers.GetApplicationRolesAsync();// GetRolesAsync();
            var role = roles.SingleOrDefault(x => x.Id == RoleId);
            result= role.NomRole;
            return result;
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                var pdf_file = Path.Combine(Path.GetTempPath(), "Utilisateurs.pdf");
                if (File.Exists(pdf_file))
                {
                    File.Delete(pdf_file);
                }
                if (gridView1.RowCount > 0)
                {
                    gridControl1.ExportToPdf(pdf_file);

                    Process.Start(pdf_file);

                }
            }
            catch (Exception)
            {
                "".DisplayDialog("Ce fichier es ouvert en Adobe Reader.Fermer sa.");
            }

        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var excel_file = Path.Combine(Path.GetTempPath(), "Utilisateurs.xlsx");
                if (File.Exists(excel_file))
                {
                    File.Delete(excel_file);
                }
                if (gridView1.RowCount > 0)
                {
                    gridControl1.ExportToXlsx(excel_file);

                    Process.Start(excel_file);

                }
            }
            catch (Exception)
            {
                "".DisplayDialog("Ce fichier es ouvert en Adobe Excel.Fermer sa.");
            }
        }

        private void btnhtml_Click(object sender, EventArgs e)
        {
            try
            {
                var html_file = Path.Combine(Path.GetTempPath(), "Utilisateurs.html");
                if (File.Exists(html_file))
                {
                    File.Delete(html_file);
                }
                if (gridView1.RowCount > 0)
                {
                    gridControl1.ExportToHtml(html_file);

                    Process.Start(html_file);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void btnsearch_CheckedChanged(object sender, EventArgs e)
        {
            var data = await SearchData();
            var searchResult=new List<CustomData>();
            if (data != null)
            {
                var username=drpsearch.Text;
                if (username.Length>2)
                {
                    searchResult=data.Where(x=>x.Utilisateur== username).ToList();
                    gridControl1.DataSource = searchResult;
                    gridView1.BestFitColumns();

                }
                else
                {
                    "".DisplayDialog("Veuillez choisir le nom d'utilisateur");
                }
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;
            //MessageBox.Show((string)gridView1.GetFocusedRowCellValue("Id"));

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr de vouloir mettre à jour les informations utilisateur?", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    //  var Id = (int)view.GetRowCellValue(view.FocusedRowHandle, "coid");
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Id");
                    var id=Guid.Parse(oid.ToString());
                     var edit_user_form=new fraEditUser("test@test.com",id);
                    edit_user_form.ShowDialog();

                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var ex = sender;
        }


    }
}