using System;
using System.Linq;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.Staffs
{
	public partial class fraStaffNotes: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly int _id;
        CommonHelpers helpers = new CommonHelpers();
        public fraStaffNotes(string email,int id)
		{
            InitializeComponent();

            _email = email;
            _id = id;
		}

        private async void fraStaffNotes_Load(object sender, EventArgs e)
        {
            var staffs = await helpers.GetStaffsAsync();
            if (staffs.Any())
            {
                var staff = staffs.SingleOrDefault(x => x.Id == _id);

                if (staff != null)
                {
                    txtnotes.Text = staff.Notes;
                }
            }
        }
    }
}