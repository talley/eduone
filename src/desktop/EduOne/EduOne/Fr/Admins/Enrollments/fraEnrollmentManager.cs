using System;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using System.Diagnostics;
using System.IO;

namespace EduOne.Fr.Admins.Enrollments
{
	public partial class fraEnrollmentManager: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraEnrollmentManager(string email)
		{
            InitializeComponent();
            _email = email;
		}

        private async void fraEnrollmentManager_Load(object sender, EventArgs e)
        {
            var enrollments = await helper.GetEnrollmentsAsync();

            var needed_enrollments = await Task.WhenAll(

                enrollments.Select(async x => new
                {
                    x.InscriptionID,
                    x.EleveId,
                    Eleve = await GetStudentAsync(x.EleveId).ConfigureAwait(false),
                    x.CoursId,
                    Cour = await GetCourseName(x.CoursId).ConfigureAwait(false),
                    x.Date_Inscription,
                    x.Grade,
                    x.Statut,
                    Notes = x.Notes.Left(100),
                    x.AjouterAu,
                    x.AjouterPar,
                    x.ModifierAu,
                    x.ModifierPar
                }).ToList()
                );

            gridControl1.DataSource = needed_enrollments;
            gridView1.BestFitColumns();

           // gridView1.Columns[""].Visible = false;
        }

        private async Task<string> GetStudentAsync(int eleveId)
        {
            string result;
            var students = await helper.GetStudentsAsync();
            var student = students.SingleOrDefault(x => x.Id == eleveId);
            result = student.Nom + " " + student.Prénom;
            return result;
        }

        private async Task<string> GetCourseName(int coursId)
        {
            string result;
            var courses = await helper.GetCoursesAsync();
            var course = courses.SingleOrDefault(x => x.Cours_Id==coursId);
            result = course.Nom_Cours;
            return result;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr de vouloir mettre à jour les informations de cette inscription?", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "InscriptionID");
                    var id = int.Parse(oid.ToString());
                    var edit_user_form = new fraEditEnrollment("test@test.com", id);
                    edit_user_form.ShowDialog();

                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }

        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var xlsx_file = Path.Combine(Path.GetTempPath(), "Inscriptions.xlsx");
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
                var pdf_file = Path.Combine(Path.GetTempPath(), "Inscriptions.pdf");
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
                var html_file = Path.Combine(Path.GetTempPath(), "Instructions.html");
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
    }
}