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

namespace EduOne.Fr.Admins.Reports
{
	public partial class frarptDepartments: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        public frarptDepartments(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void frarptDepartments_Load(object sender, EventArgs e)
        {
            var info = ReportsHelper.GetLogOnInfos();
            DepartmentsReport1.SetDatabaseLogon(DbHelpers.DbUser, DbHelpers.DbUserPass, DbHelpers.DbHost, DbHelpers.DbName);
            crystalReportViewer1.LogOnInfo = info;
        }
    }
}