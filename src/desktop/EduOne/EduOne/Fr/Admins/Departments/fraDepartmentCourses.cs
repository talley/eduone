using System;
using System.Data;
using System.Linq;
using EduOne.Exts;
using EduOne.Fr.Helpers;

namespace EduOne.Fr.Admins.Departments
{
    public partial class fraDepartmentCourses : DevExpress.XtraEditors.XtraForm
    {
        private CommonHelpers helper = new CommonHelpers();
        string _email;
        int _id;
        public fraDepartmentCourses(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraDepartmentCourses_Load(object sender, EventArgs e)
        {
            var depts=await helper.GetDepartmentsAsync();
            var courses=await helper.GetCoursesAsync();

            var results = (from d in depts
                          join c in courses
                          on d.Id equals c.ID_Department
                          where d.Id == _id
                          select new
                          {
                              c.Nom_Cours,
                              Description= c.Description.Left(100)
                          }).ToList();

            gridControl1.DataSource = results;
        }
    }
}