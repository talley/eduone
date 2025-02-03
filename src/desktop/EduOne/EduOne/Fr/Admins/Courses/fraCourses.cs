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
using EduOne.Fr.Models;
using EduOne.Helpers;
using EduOne.Fr.Models;

using Config = System.Configuration.ConfigurationManager;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using EduOne.Fr.helpers;

namespace EduOne.Fr.Admins.Courses
{
    public partial class fraCourses : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        public fraCourses(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraCourses_Load(object sender, EventArgs e)
        {
            var courses=await GetCoursesAsync();

            var dcourses = courses.Where(x => x.Statut).Select(x => new { x.Nom_Cours, x.Statut }).ToList();
             drpcourses.Properties.DataSource = dcourses;
            drpcourses.Properties.DisplayMember = "Nom_Cours";
            drpcourses.Properties.ValueMember = "Nom_Cours";
            drpcourses.Properties.BestFit();

            var needed_courses = await Task.WhenAll(
             courses.Select(async x => new
             {
                 x.Cours_Id,
                 x.Nom_Cours,
                 x.Description,
                 Département = await GetDepartmentNameAsync(x.ID_Department).ConfigureAwait(false),
                 x.Statut,
                 x.AjouterAu,
                 x.AjouterPar,
                 x.ModifierAu,
                 x.ModifierPar
             })
 );

            var neededCoursesList = needed_courses.ToList();


            gridControl1.DataSource = neededCoursesList;
            gridView1.BestFitColumns();
        }

        private async Task<List<Departments>> GetDepartmentAsync()
        {
            var dpts = new List<Departments>();
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Departments";

            using (var client = new HttpClient())
            {
                try
                {

                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        dpts = JsonConvert.DeserializeObject<List<Departments>>(responseData);
                    }
                    else
                    {
                        XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (HttpRequestException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            return dpts;
        }
        private async Task<string> GetDepartmentNameAsync(int iD_Department)
        {
            string department = "";
            var dpts = await GetDepartmentAsync();
            var xdepartment = dpts.SingleOrDefault(x => x.Id == iD_Department);
            department=xdepartment.Nom_Département;
            return department;
        }

        private bool IsAppInProd()
        {
            bool isAppInProd = bool.Parse(Config.AppSettings["IS_PROD"]);
            return isAppInProd;
        }

        private async Task<List<EduOne.Fr.Models.Courses>> GetCoursesAsync()
        {
            var courses=new List<Models.Courses>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Courses";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        courses=JsonConvert.DeserializeObject<List<Models.Courses>>(responseData);
                    }
                    else
                    {
                        XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (HttpRequestException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return courses;
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var xlsx_file = Path.Combine(Path.GetTempPath(), "Cours.xlsx");
                if (File.Exists(xlsx_file))
                {
                    File.Delete(xlsx_file);
                }
                if (gridView1.RowCount > 0)
                {

                    gridControl1.ExportToXlsx(xlsx_file);
                    Process.Start(xlsx_file);
                }
            }
            catch (Exception ex)
            {

                ".".DisplayDialog("Ce fichier est ouvert dans Excel Veuillez le fermer.");
            }
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                var pdf_file = Path.Combine(Path.GetTempPath(), "Cours.pdf");
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
            catch (Exception ex)
            {

                ".".DisplayDialog("Ce fichier est ouvert dans Adobe Reader. Veuillez le fermer.");
            }
        }

        private void btnhtml_Click(object sender, EventArgs e)
        {
            try
            {
                var html_file = Path.Combine(Path.GetTempPath(), "Cours.html");
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

                ".".DisplayDialog("Ce fichier est ouvert dans Internet browser. Veuillez le fermer.");
            }
        }

        private async void btnsearch_Click(object sender, EventArgs e)
        {
            var course = drpcourses.Text;
            if (course.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Cours");
            }
            else
            {
                var scourse=drpcourses.EditValue.ToString();
                var courses = await GetCoursesAsync();
                if (courses.Any())
                {
                    var results=courses.Where(x=>x.Nom_Cours.Contains(scourse) || x.Nom_Cours.StartsWith(scourse)).ToList();

                    gridControl1.DataSource = results;
                    gridView1.BestFitColumns();
                }
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var da=e.CellValue;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr de vouloir mettre à jour les informations du cours?", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Cours_Id");
                    var id = int.Parse(oid.ToString());
                    var edit_user_form = new fraEditCourse("test@test.com", id);
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