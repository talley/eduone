using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduOne.Fr.Admins.Audits
{
    public partial class fraTransactionHistories : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        readonly CommonHelpers _helpers = new CommonHelpers();
        public fraTransactionHistories(string email )
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraTransactionHistories_Load(object sender, EventArgs e)
        {
            var data = await _helpers.GetTransctionHistoriesAsync();
            gridControl1.DataSource = data;
            gridView1.BestFitColumns();
        }
    }
}