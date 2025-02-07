using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EduOne.Exts;
using EduOne.Fr.Admins.Departments;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.DepartmentHeads
{
    public partial class fraDepartmentHeads : DevExpress.XtraEditors.XtraForm
    {
        private CommonHelpers helper=new CommonHelpers();
        string _email;
        public fraDepartmentHeads(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraDepartmentHeads_Load(object sender, EventArgs e)
        {
            var result=await helper.GetDepartmentHeadsAsync();

            var dptlist = result.Select(x =>
            new {
                x.Id,
                Nom=x.Prénom+ " "+x.Nom,
                x.TelePhone,
            }
            ).ToList();

            drpdptchefs.Properties.DataSource = dptlist;
            drpdptchefs.Properties.DisplayMember = "Nom";
            drpdptchefs.Properties.ValueMember = "Id";
            drpdptchefs.Properties.BestFit();


            gridControl1.DataSource = result;
            gridView1.BestFitColumns();
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                var pdf_file = Path.Combine(Path.GetTempPath(), "Chef_Departments.pdf");
                if (File.Exists(pdf_file))
                {
                    File.Delete(pdf_file);
                }
                if (gridView1.RowCount > 0)
                {
                    gridControl1.ExportToPdf(pdf_file);
                }
            }
            catch (Exception)
            {

                ".".DisplayDialog("Ce fichier est ouvert dans Adobe Reader. Veuillez d'abord le fermer.");
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var excel_file = Path.Combine(Path.GetTempPath(), "Chef_Departments.xlsx");
                if (File.Exists(excel_file))
                {
                    File.Delete(excel_file);
                }
                if (gridView1.RowCount > 0)
                {
                    gridControl1.ExportToXlsx(excel_file);
                }
            }
            catch (Exception)
            {

                ".".DisplayDialog("Ce fichier est ouvert dans Excel. Veuillez d'abord le fermer.");
            }
        }

        private void btnhtml_Click(object sender, EventArgs e)
        {
            try
            {
                var html_file = Path.Combine(Path.GetTempPath(), "Chef_Departments.html");
                if (File.Exists(html_file))
                {
                    File.Delete(html_file);
                }
                if (gridView1.RowCount > 0)
                {
                    gridControl1.ExportToHtml(html_file);
                }
            }
            catch (Exception)
            {

                ".".DisplayDialog("Ce fichier est ouvert dans Firefox,Chrome,Edge. Veuillez d'abord le fermer.");
            }
        }

        private async void btnsearch_Click(object sender, EventArgs e)
        {
            var result = await helper.GetDepartmentHeadsAsync();
            var searchText=drpdptchefs.Text;
            if (searchText.Length == 0)
            {
                ".".DisplayErrorFrDialog(" Chef du département");
            }
            else
            {
                var Id=int.Parse(drpdptchefs.EditValue.ToString());
                var data=result.Where(x=>x.Id==Id).ToList();

                gridControl1.DataSource = data;
                gridView1.BestFitColumns();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr que vous vouliez modifier le chef du département", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Id");
                    var id = int.Parse(oid.ToString());
                    var courses_form = new fraEditDepartmentChef("test@test.com", id);
                    courses_form.ShowDialog();
                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }
        }
    }
}