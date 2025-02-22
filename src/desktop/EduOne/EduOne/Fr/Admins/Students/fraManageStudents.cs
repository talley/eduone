using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduOne.Fr.Admins.Students
{
    public partial class fraManageStudents : XtraForm
    {
        string _email;
        CommonHelpers helper=new CommonHelpers();
        public fraManageStudents(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraManageStudents_Load(object sender, EventArgs e)
        {
            List<Models.Students> students = await GetStudentsAsync();

            gridControl1.DataSource = students;
            gridView1.BestFitColumns();

            gridView1.Columns["GlobalId"].Visible = false;
            gridView1.Columns["ModifierAu"].Visible = true;
            gridView1.Columns["Notes"].Visible = false;
            gridView1.Columns["Fax"].Visible = false;
            gridView1.Columns["Addresse2"].Visible = false;
            var columns = new List<string>()
            {
                "GlobalId","Id","Nom","Prénom","Surnom","LieuNaissance",
                "DateNaissance","Genre","Email","TelePhone","Fax",
                "Addresse","Ville","État","Pays","Date_Inscription",
                "Statut","AjouterAu","AjouterPar","ModifierAu",
                "ModifierPar"
            };
            var sorted=columns.OrderBy(x => x).ToList();
            foreach (var column in sorted)
            {
                drpcolumns.Properties.Items.Add(column);
            }
        }

        private async Task<List<Models.Students>> GetStudentsAsync()
        {
            var students=new List<Models.Students>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "Students";
            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        students=JsonConvert.DeserializeObject<List<Models.Students>>(responseData);
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
            return students;
        }

        private void btnhtml_Click(object sender, EventArgs e)
        {
            try
            {
                var html_file = Path.Combine(Path.GetTempPath(), "Students.html");
                if (File.Exists(html_file)) { File.Delete(html_file); }
                if (gridView1.RowCount > 0)
                {
                    gridView1.Columns["GlobalId"].Visible = false;
                    gridView1.Columns["ModifierAu"].Visible = false;
                    gridView1.Columns["Notes"].Visible = false;
                    gridView1.Columns["Fax"].Visible = false;
                    gridView1.Columns["Addresse2"].Visible = false;
                    gridView1.BestFitColumns();
                    gridControl1.ExportToHtml(html_file);
                    Process.Start(html_file);
                }
            }
            catch (Exception ex)
            {
                ".".DisplayExportErrorDialog("Adobe Reader");
            }
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                var pdf_file = Path.Combine(Path.GetTempPath(), "Students.pdf");
                if (File.Exists(pdf_file)) { File.Delete(pdf_file); }
                if (gridView1.RowCount > 0)
                {
                    gridView1.Columns["GlobalId"].Visible = false;
                    gridView1.Columns["ModifierAu"].Visible = false;
                    gridView1.Columns["Notes"].Visible = false;
                    gridView1.Columns["Fax"].Visible = false;
                    gridView1.Columns["Addresse2"].Visible = false;
                    gridView1.BestFitColumns();
                    gridControl1.ExportToPdf(pdf_file);
                    Process.Start(pdf_file);
                }
            }
            catch (Exception ex)
            {
                ".".DisplayExportErrorDialog($"Adobe Reader,Erreur :{ex.Message}");
            }
        }

        private async void btnsearch_Click(object sender, EventArgs e)
        {
            var criteria=drpcolumns.Text;
            var search=txtsearch.Text.Trim();
            var results=new List<Models.Students>();

            if (criteria.Length == 0)
            {
                ".".DisplayErrorFrDialog(" critere");
            }
            else if (search.Length == 0)
            {
                ".".DisplayErrorFrDialog(" la valeur pour la recherceh");
            }
            else
            {

                var students = await GetStudentsAsync();
                if (students.Any())
                {
                    var status = ckstatus.Checked;
                    switch (criteria)
                    {


                        case "GlobalId":
                          results=students.Where(x=>x.GlobalId==Guid.Parse(search) && x.Statut==status).ToList();
                          break;
                        case "Id":
                            results = students.Where(x => x.Id == int.Parse(search) && x.Statut == status).ToList();
                            break;
                        case "Nom":
                            results = students.Where(x => x.Nom.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "Surnom":
                            results = students.Where(x => x.Surnom.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "LieuNaissance":
                            results = students.Where(x => x.LieuNaissance.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "DateNaissance":
                            results = students.Where(x => x.DateNaissance==DateTime.Parse(search) && x.Statut == status).ToList();
                            break;
                        case "Genre":
                            results = students.Where(x => x.Genre.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "Email":
                            results = students.Where(x => x.Email.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "TelePhone":
                            results = students.Where(x => x.TelePhone.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "Fax":
                            results = students.Where(x => x.Fax.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "Addresse":
                            results = students.Where(x => x.Addresse.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "Ville":
                            results = students.Where(x => x.Ville.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "État":
                            results = students.Where(x => x.État.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "Pays":
                            results = students.Where(x => x.Pays.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "Date_Inscription":
                            results = students.Where(x => x.Date_Inscription==DateTime.Parse(search)).ToList();
                            break;
                        case "AjouterAu":
                            results = students.Where(x => x.AjouterAu==DateTime.Parse(search) && x.Statut == status).ToList();
                            break;
                        case "AjouterPar":
                            results = students.Where(x => x.AjouterPar.Contains(search) && x.Statut == status).ToList();
                            break;
                        case "ModifierAu":
                            results = students.Where(x => x.ModifierAu == DateTime.Parse(search) && x.Statut == status).ToList();
                            break;
                        case "ModifierPar":
                            results = students.Where(x => x.ModifierPar.Contains(search) && x.Statut == status).ToList();
                            break;
                        default:
                            "".DisplayDialog("Veuillez fournir des critères valides. Assurez-vous que le critère de date a le bon format.");
                            break;
                    }
                }

                gridControl1.DataSource = results;
                gridView1.BestFitColumns();
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var excel_file = Path.Combine(Path.GetTempPath(), "Students.xlsx");
                if (File.Exists(excel_file)) { File.Delete(excel_file); }
                if (gridView1.RowCount > 0)
                {
                    gridView1.Columns["GlobalId"].Visible = false;
                    gridView1.Columns["ModifierAu"].Visible = false;
                    gridView1.Columns["Notes"].Visible = false;
                    gridView1.Columns["Fax"].Visible = false;
                    gridView1.Columns["Addresse2"].Visible = false;
                    gridControl1.ExportToXlsx(excel_file);
                    Process.Start(excel_file);
                }
            }
            catch (Exception ex)
            {
                ".".DisplayExportErrorDialog("Excel");
            }
        }

        private void btnword_Click(object sender, EventArgs e)
        {
            try
            {
                var word_file = Path.Combine(Path.GetTempPath(), "Students.docx");
                if (File.Exists(word_file)) { File.Delete(word_file); }
                if (gridView1.RowCount > 0)
                {
                    gridView1.Columns["GlobalId"].Visible = false;
                    gridView1.Columns["ModifierAu"].Visible = false;
                    gridView1.Columns["Notes"].Visible = false;
                    gridView1.Columns["Fax"].Visible = false;
                    gridView1.Columns["Addresse2"].Visible = false;
                    gridView1.BestFitColumns();
                    gridControl1.ExportToDocx(word_file);
                    Process.Start(word_file);
                }
            }
            catch (Exception ex)
            {
                ".".DisplayExportErrorDialog("Word");
            }
        }

        private void btntext_Click(object sender, EventArgs e)
        {
            try
            {
                var txtfile = Path.Combine(Path.GetTempPath(), "Students.txt");
                if (File.Exists(txtfile)) { File.Delete(txtfile); }
                if (gridView1.RowCount > 0)
                {
                    gridView1.Columns["GlobalId"].Visible = false;
                    gridView1.Columns["ModifierAu"].Visible = false;
                    gridView1.Columns["Notes"].Visible = false;
                    gridView1.Columns["Fax"].Visible = false;
                    gridView1.Columns["Addresse2"].Visible = false;
                    gridView1.BestFitColumns();
                    gridControl1.ExportToText(txtfile);
                    Process.Start(txtfile);
                }
            }
            catch (Exception ex)
            {
                ".".DisplayExportErrorDialog(" Text Editor");
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr de vouloir mettre à jour les informations de l`Étudiant?", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Id");
                    var id = int.Parse(oid.ToString());
                    var edit_user_form = new fraEditStudent("test@test.com", id);
                    edit_user_form.ShowDialog();

                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }

        }
    }
}