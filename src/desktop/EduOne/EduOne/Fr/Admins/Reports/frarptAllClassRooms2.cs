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

namespace EduOne.Fr.Admins.Reports
{
    public partial class frarptAllClassRooms2 : DevExpress.XtraEditors.XtraForm
    {
        readonly string _email;
        public frarptAllClassRooms2(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void frarptAllClassRooms2_Load(object sender, EventArgs e)
        {
            //reportDocument1.FileName = "rptClassRooms.rpt";
            ////ReportDocument doc = crAllUsers1;
            //var info = ReportsHelper.GetLogOnInfos();
            //reportDocument1.SetDatabaseLogon(DbHelpers.DbUser, DbHelpers.DbUserPass, DbHelpers.DbHost, DbHelpers.DbName);

            //crystalReportViewer1.LogOnInfo = info;
        }
    }
}