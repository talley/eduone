using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using System.Diagnostics;
using System.IO;
using EduOne.Fr.helpers;
using EduOne.Fr.Admins.Finances;

namespace EduOne.Fr.Admins.Enrollments
{
	public partial class fraStudentEnrollementFeesManager: DevExpress.XtraEditors.XtraForm
	{
		readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraStudentEnrollementFeesManager(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraStudentEnrollementFeesManager_Load(object sender, EventArgs e)
        {
            var studentsfees = await helper.GetSemesterEnrollmentFeesAsync();
            var students = await helper.GetStudentsAsync();
            var semesters = await helper.GetSemestersAsync();

                if (students.Any())
                {
                    var needed_students = students.Select(x => new
                    {
                        x.Id,
                        Nom = x.Nom + " " + x.Prénom,
                        x.LieuNaissance,
                        x.DateNaissance,
                        x.Genre,
                        x.Email,
                        Téléphone = x.TelePhone,
                        x.Addresse,
                        x.Ville,
                        x.Date_Inscription,
                        x.Statut
                    });

                    drpstudents.Properties.DataSource = needed_students;
                    drpstudents.Properties.DisplayMember = "Nom";
                    drpstudents.Properties.ValueMember = "Id";
                    drpstudents.Properties.BestFit();
                }

            var needed_studentsfees = await Task.WhenAll(
                 studentsfees.Select(async x => new
                 {
                     x.GID,
                     x.Id,
                     Élève = await helper.GetStudentLastFirstName(x.EleveId),
                     Semestre = await helper.GetSemesterNameAsync(x.SemestreId),
                     x.MontantDu,
                     x.MontantReçu,
                     x.Balance,
                     x.Statut,
                     x.Notes,
                     x.AjouterAu,
                     x.AjouterPar,
                     x.ModifierAu,
                     x.ModifierPar
                 }).ToList()
                );

            gridControl1.DataSource = needed_studentsfees;
            gridView1.BestFitColumns();


            }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var xlsx_file = Path.Combine(Path.GetTempPath(), "FraisEleves.xlsx");
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
                var pdf_file = Path.Combine(Path.GetTempPath(), "FraisEleves.pdf");
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
                var html_file = Path.Combine(Path.GetTempPath(), "FraisEleves.html");
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

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           var view = gridView1;

            if (gridControl1.MainView is DevExpress.XtraGrid.Views.Grid.GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr de vouloir mettre à jour les informations des frais de ce eleve(etudiant)?", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    //  var Id = (int)view.GetRowCellValue(view.FocusedRowHandle, "coid");
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Id");
                    var id = int.Parse(oid.ToString());
                    var edit_user_form = new fraEditStudentSemesterFee("test@test.com", id);
                    edit_user_form.ShowDialog();

                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }
        }

        private async void btnsearch_Click(object sender, EventArgs e)
        {
            var studentsfees = await helper.GetSemesterEnrollmentFeesAsync();
            var needed_studentsfees = await Task.WhenAll(
               studentsfees.Select(async x => new
               {
                   x.GID,
                   x.Id,
                   Élève = await helper.GetStudentLastFirstName(x.EleveId),
                   Semestre = await helper.GetSemesterNameAsync(x.SemestreId),
                   x.MontantDu,
                   x.MontantReçu,
                   x.Balance,
                   x.Statut,
                   x.Notes,
                   x.AjouterAu,
                   x.AjouterPar,
                   x.ModifierAu,
                   x.ModifierPar
               }).ToList()
              );

            var search = drpstudents.Text;

            if (search.IsNull())
            {
                "".DisplayErrorFrDialog(" Eleve(Etudiant)");
            }
            else
            {
                var isearch = int.Parse(drpstudents.EditValue.ToString());

                var result = needed_studentsfees.Where(x => x.Id == isearch).ToList();
                gridControl1.DataSource = result;
                gridView1.BestFitColumns();
            }
        }
    }
    }
