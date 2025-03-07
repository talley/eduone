using System;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.Reports
{
	public partial class frarptAllUsers: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        public frarptAllUsers(string email)
        {
            InitializeComponent();
            crystalReportViewer1.ReportRefresh += CrystalReportViewer1_ReportRefresh;
            _email = email;
        }

        private void CrystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            crystalReportViewer1.LogOnInfo = ReportsHelper.GetLogOnInfos();
            crystalReportViewer1.ReportSource = crAllUsers1;
            crystalReportViewer1.RefreshReport();
        }

        private void frarptAllUsers_Load(object sender, EventArgs e)
        {
            //ReportDocument doc = crAllUsers1;
            var info = ReportsHelper.GetLogOnInfos();
            crAllUsers1.SetDatabaseLogon(DbHelpers.DbUser, DbHelpers.DbUserPass,DbHelpers.DbHost,DbHelpers.DbName);

            crystalReportViewer1.LogOnInfo = info;

        }
    }
}