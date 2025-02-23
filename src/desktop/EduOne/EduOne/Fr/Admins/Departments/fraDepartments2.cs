using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.Departments
{
    public partial class fraDepartments2 : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        internal CommonHelpers _commonHelpers = new CommonHelpers();
        public fraDepartments2(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void btnsearch_Click(object sender, EventArgs e)
        {
            var dpt = drpdepts.Text;
            if (dpt == "")
            {
                ".".DisplayErrorFrDialog("Département");
            }
            else
            {
                var depts = await _commonHelpers.GetDepartmentsAsync();
                var id = drpdepts.EditValue.ToString();
                var result = depts.Where(x => x.Nom_Département == id).ToList();

                gridControl1.DataSource = result;
                gridView1.BestFitColumns();

            }
        }

        private async void fraDepartments2_Load(object sender, EventArgs e)
        {
            var helper = new CommonHelpers();
            var depts = await helper.GetDepartmentAsync();

            var drpdeptsdata = depts.OrderBy(x => x.Nom_Département).Select(x => new { x.Id, x.Nom_Département }).ToList();

            drpdepts.Properties.DataSource = drpdeptsdata;
            drpdepts.Properties.DisplayMember = "Nom_Département";
            drpdepts.Properties.ValueMember = "Nom_Département";
            drpdepts.Properties.BestFit();

            gridControl1.DataSource = depts;
            gridView1.BestFitColumns();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr que vous vouliez voir les cours de cet département", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Id");
                    var id = int.Parse(oid.ToString());
                    var courses_form = new fraDepartmentCourses("test@test.com", id);
                    courses_form.ShowDialog();
                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr que vous vouliez modifier de cet département", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Id");
                    var id = int.Parse(oid.ToString());
                    var courses_form = new fraEditDepartment("test@test.com", id);
                    courses_form.ShowDialog();
                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            var pdf_file = Path.Combine(Path.GetTempPath(), "Département.pdf");

            try
            {
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
                ".".DisplayDialog($"Ce fichier est ouvert dans Adobe Reader. Veuillez le fermer.{ex.Message}");
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            var excel_file = Path.Combine(Path.GetTempPath(), "Département.xlsx");

            try
            {
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
            catch (Exception ex)
            {
                ".".DisplayDialog($"Ce fichier est ouvert dans Excel Veuillez le fermer.{ex.Message}");
            }
        }

        private void btnhtml_Click(object sender, EventArgs e)
        {
            var html_file = Path.Combine(Path.GetTempPath(), "Département.html");

            try
            {
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
                ".".DisplayDialog($"Ce fichier est ouvert dans Excel Veuillez le fermer.{ex.Message}");
            }
        }
    }
}