using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using EduOne.Exts;
using EduOne.Fr.helpers;

namespace EduOne.Fr.Admins.Settings
{
	public partial class fraManageAppSettings: DevExpress.XtraEditors.XtraForm
	{
        string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraManageAppSettings(string email)
		{
            InitializeComponent();
            _email = email;
		}

        private async void fraManageAppSettings_Load(object sender, EventArgs e)
        {
            var settings = await helper.GetApplicationSettings();
            var needed= settings.Where(x => x.CanBeAltered == true).ToList();
            gridControl1.DataSource = needed;
            gridView1.BestFitColumns();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;
            //MessageBox.Show((string)gridView1.GetFocusedRowCellValue("Id"));

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr de vouloir mettre à jour les informations de cette Clé?", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    //  var Id = (int)view.GetRowCellValue(view.FocusedRowHandle, "coid");
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "ID");
                    var id = int.Parse(oid.ToString());
                    var edit_user_form = new fraEditAppSetting("test@test.com", id);
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