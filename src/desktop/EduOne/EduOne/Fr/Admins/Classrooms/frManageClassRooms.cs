using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using EduOne.Exts;
using EduOne.Fr.helpers;
using System.Diagnostics;
using System.IO;

namespace EduOne.Fr.Admins.Classrooms
{
	public partial class frManageClassRooms: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public frManageClassRooms(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void frManageClassRooms_Load(object sender, EventArgs e)
        {
            Text = "Gérer les salles de classe";

            var data =await helper.GetClassRoomsAsync();

            var needed_clr = data.Select(x => new
            {
                x.Id,x.Bâtiment,x.Capacité,x.NuméroChambre,x.Statut
            }).ToList();

            drpclassrooms.Properties.DataSource = needed_clr;
            drpclassrooms.Properties.DisplayMember = "NuméroChambre";
            drpclassrooms.Properties.ValueMember = "Id";
            drpclassrooms.Properties.BestFit();


            gridControl1.DataSource = data;
            gridView1.BestFitColumns();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr de vouloir mettre à jour les informations de cette classe?", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Id");
                    var id = int.Parse(oid.ToString());
                    var edit_user_form = new fraEditClassRoom("test@test.com", id);
                    edit_user_form.ShowDialog();

                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var xlsx_file = Path.Combine(Path.GetTempPath(), "Salles.xlsx");
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
                var pdf_file = Path.Combine(Path.GetTempPath(), "Salles.pdf");
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
                var html_file = Path.Combine(Path.GetTempPath(), "Salles.html");
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
            var data = await helper.GetClassRoomsAsync();

            var search = drpclassrooms.Text;
            if (search.Length == 0)
            {
                "".DisplayErrorFrDialog(" la salle");
            }
            else
            {
                var id = int.Parse(drpclassrooms.EditValue.ToString());
                data = data.Where(x => x.Id == id).ToList();

                gridControl1.DataSource = data;
                gridView1.BestFitColumns();
            }

        }
    }
}