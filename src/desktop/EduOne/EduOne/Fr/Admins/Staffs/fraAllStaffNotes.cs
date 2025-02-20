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

namespace EduOne.Fr.Admins.Staffs
{
	public partial class fraAllStaffNotes: DevExpress.XtraEditors.XtraForm
	{
       readonly string _email;
       readonly int _staffId;
        readonly CommonHelpers helpers = new CommonHelpers();

        public fraAllStaffNotes(string email, int id)
		{
            InitializeComponent();
            _email = email;
            _staffId = id;
		}

        private async void fraAllStaffNotes_Load(object sender, EventArgs e)
        {
            var staffNotess = await helpers.GetStaffNotesAsync();
            var results = staffNotess.Where(x => x.EId == _staffId).ToList();

            var data = new List<Data>();

            foreach (var item in results)
            {
                data.Add(new Data { Notes = item.Notes });
            }
            gridControl1.DataSource = results;

        }
    }

    struct Data
    {
        public string Notes { get; set; }
    }
}