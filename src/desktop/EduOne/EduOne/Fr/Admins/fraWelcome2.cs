using DevExpress.XtraEditors;
using EduOne.Fr.Admins.Courses;
using EduOne.Fr.Admins.DepartmentHeads;
using EduOne.Fr.Admins.Departments;
using EduOne.Fr.Admins.Semesters;
using EduOne.Fr.Admins.Staffs;
using EduOne.Fr.Admins.Students;
using EduOne.Fr.helpers;
using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace EduOne.Fr.Admins
{
    public partial class fraWelcome2 : Telerik.WinControls.UI.RadForm
    {
        readonly string _email;
        public fraWelcome2(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void fraWelcome2_Load(object sender, EventArgs e)
        {
            string msg = $"Bienvenue sur: {ApplicationHelpers.AppName}";
            Text = msg;
        }

        private void ShowFormInPanel(RadForm frm, SplitPanel panel)
        {
            frm.TopLevel = false;
            foreach (Control ctr in panel.Controls)
            {
                if (ctr != frm)
                    ctr.Visible = false;
            }
            if (!panel.Controls.Contains(frm))
            {
                panel.Controls.Add(frm);
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
            else
            {
                frm.Visible = true;
            }
        }

        private void ShowFormInPanel(XtraForm frm, SplitPanel panel)
        {
            frm.TopLevel = false;
            foreach (Control ctr in panel.Controls)
            {
                if (ctr != frm)
                    ctr.Visible = false;
            }
            if (!panel.Controls.Contains(frm))
            {
                panel.Controls.Add(frm);
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
            else
            {
                frm.Visible = true;
            }
        }

        private void kryptonTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView1.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Chef Département":
                        var form1 = new fraAddDepartmentHead(_email);
                        ShowFormInPanel(form1, splitPanel2);
                        break;
                    case "Gestion Chefs Départements":
                        var form2 = new fraDepartmentHeads(_email);
                        ShowFormInPanel(form2, splitPanel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView2.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Un Département":
                        var form1 = new fraAddDepartment(_email);
                        ShowFormInPanel(form1, splitPanel2);
                        break;
                    case "Gestion Des Départements":
                        var form2 = new fraDepartments2(_email);
                        ShowFormInPanel(form2, splitPanel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView3.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Un Personnel":
                        var form1 = new fraNewStaff(_email);
                        ShowFormInPanel(form1, splitPanel2);
                        break;
                    case "Gestion Du Personnel":
                        var form2 = new fraManageStaffs(_email);
                        ShowFormInPanel(form2, splitPanel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {

            var selText = kryptonTreeView4.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Un Cours":
                        var form1 = new fraNewCourse(_email);
                        ShowFormInPanel(form1, splitPanel2);
                        break;
                    case "Gestion Des Cours":
                        var form2 = new fraCourses(_email);
                        ShowFormInPanel(form2, splitPanel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView5_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView5.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Un Eleve":
                        var form1 = new fraAddStudent(_email);
                        ShowFormInPanel(form1, splitPanel2);
                        break;
                    case "Gestion Des Eleves":
                        var form2 = new fraManageStudents(_email);
                        ShowFormInPanel(form2, splitPanel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView7_AfterSelect(object sender, TreeViewEventArgs e)
        {

            var selText = kryptonTreeView7.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Semestre":
                        var form1 = new fraAddSemester(_email);
                        ShowFormInPanel(form1, splitPanel2);
                        break;
                    case "Gestion Des Semestres":
                        var form2 = new fraSemesters(_email);
                        ShowFormInPanel(form2, splitPanel2);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
