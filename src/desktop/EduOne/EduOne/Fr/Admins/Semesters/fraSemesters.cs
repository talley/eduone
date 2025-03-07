using System;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using DevExpress.XtraGrid.Views.Card;

namespace EduOne.Fr.Admins.Semesters
{
	public partial class fraSemesters: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraSemesters(string email)
		{
            InitializeComponent();
            _email = email;
		}

        private async void fraSemesters_Load(object sender, EventArgs e)
        {
            var semesters = await helper.GetSemestersAsync();

            gridControl1.DataSource = semesters;

        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridControl1.MainView is CardView cardView)
            {
                var oid = cardView.GetRowCellValue(cardView.FocusedRowHandle, "ID");
                // Convert oid to the proper type if needed
                var id = int.Parse(oid.ToString());
                var edit_user_form = new fraEditSemester("test@test.com", id);
                edit_user_form.ShowDialog();
            }
            else
            {
                "".DisplayDialog("La transaction a été annulée.");
            }

        }
    }
}