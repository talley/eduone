using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.Departments
{
    public partial class fraDepartments : DevExpress.XtraEditors.XtraForm
    {
        string _email;

        public fraDepartments(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraDepartments_Load(object sender, EventArgs e)
        {
            var helper = new CommonHelpers();
            var depts=await helper.GetDepartmentAsync();

            gridControl1.DataSource = depts;
            gridView1.BestFitColumns();
        }
    }
}