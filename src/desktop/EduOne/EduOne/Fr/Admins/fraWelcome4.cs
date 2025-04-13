using DevExpress.XtraEditors;
using EduOne.Fr.Admins.Classrooms;
using EduOne.Fr.Admins.Courses;
using EduOne.Fr.Admins.DepartmentHeads;
using EduOne.Fr.Admins.Departments;
using EduOne.Fr.Admins.Enrollments;
using EduOne.Fr.Admins.Finances.SemestersFees;
using EduOne.Fr.Admins.Semesters;
using EduOne.Fr.Admins.Settings;
using EduOne.Fr.Admins.Staffs;
using EduOne.Fr.Admins.Students;
using EduOne.Fr.Helpers;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace EduOne.Fr.Admins
{
    public partial class fraWelcome4 : Telerik.WinControls.UI.RadForm
    {
        readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraWelcome4(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void ShowFormInPanel(RadForm frm, System.Windows.Forms.SplitterPanel panel)
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

        private void ShowFormInPanel(XtraForm frm, System.Windows.Forms.SplitterPanel panel)
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
        private void kryptonTreeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView2.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Un Personnel":
                        var form1 = new fraNewStaff(_email);
                        ShowFormInPanel(form1, splitContainer1.Panel2);
                        break;
                    case "Gestion Du Personnel":
                        var form2 = new fraManageStaffs(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView10_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView10.SelectedNode.Text;
            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Clé":
                        var form2 = new fraAddApplicationSetting(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
                        break;
                    case "Gestion Des Clés":
                        var form3 = new fraManageAppSettings(_email);
                        ShowFormInPanel(form3, splitContainer1.Panel2);
                        break;//
                    case "Gérer les paiements des étudiants(eleves)":
                        var form4 = new fraEnrollmentManager(_email);
                        ShowFormInPanel(form4, splitContainer1.Panel2);
                        break;//
                    case "Gestion Des Frais":
                        var form = new fraStudentEnrollementFeesManager(_email);
                        ShowFormInPanel(form, splitContainer1.Panel2);
                        break;//Gestion Des Frais
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
                    case "Ajouter Chef Département":
                        var form1 = new fraAddDepartmentHead(_email);
                        ShowFormInPanel(form1, splitContainer1.Panel2);
                        break;
                    case "Gestion Chefs Départements":
                        var form2 = new fraDepartmentHeads(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
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
                    case "Ajouter Un Département":
                        var form1 = new fraAddDepartment(_email);
                        ShowFormInPanel(form1, splitContainer1.Panel2);
                        break;
                    case "Gestion Des Départements":
                        var form2 = new fraDepartments2(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView6_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView6.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Nouvelle Salle De Classe":
                        var form1 = new fraAddClassRoom(_email);
                        ShowFormInPanel(form1, splitContainer1.Panel2);
                        break;
                    case "Gestion Des Salle De Classe":
                        var form2 = new frManageClassRooms(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
                        break;
                    case "Nouvelle Inscription":
                        var form3 = new frNewEnrollment(_email);
                        ShowFormInPanel(form3, splitContainer1.Panel2);
                        break;
                    case "Gestion Des Inscriptions":
                        var form4 = new fraEnrollmentManager(_email);
                        ShowFormInPanel(form4, splitContainer1.Panel2);
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
                        ShowFormInPanel(form1, splitContainer1.Panel2);
                        break;
                    case "Gestion Des Semestres":
                        var form2 = new fraSemesters(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView8_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView8.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Gestion Des Frais Semestres":
                        var form2 = new fraAddSemesterFee2(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
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
                        ShowFormInPanel(form1, splitContainer1.Panel2);
                        break;
                    case "Gestion Des Eleves":
                        var form2 = new fraManageStudents(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView9_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView9.SelectedNode.Text;

            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Ajouter Un Cours":
                        var form1 = new fraNewCourse(_email);
                        ShowFormInPanel(form1, splitContainer1.Panel2);
                        break;
                    case "Gestion Des Cours":
                        var form2 = new fraCourses(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView11_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView11.SelectedNode.Text;
            if (selText.Length > 0)
            {
                switch (selText)
                {
                    case "Nouvelle Inscription":
                        var form2 = new frNewEnrollment(_email);
                        ShowFormInPanel(form2, splitContainer1.Panel2);
                        break;
                    case "Gestion Des Inscriptions":
                        var form3 = new fraEnrollmentManager(_email);
                        ShowFormInPanel(form3, splitContainer1.Panel2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void kryptonTreeView15_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selText = kryptonTreeView15.SelectedNode.Text;
            if (selText.Length > 0)
            {
                switch (selText)
                {

                    case "Nouvelle Graduation":
                        var form4 = new frNewEnrollment(_email);
                        ShowFormInPanel(form4, splitContainer1.Panel2);//frNewEnrollment
                        break;
                    case "Graduations":
                        var form = new fraEnrollmentManager(_email);
                        ShowFormInPanel(form, splitContainer1.Panel2);//frNewEnrollment
                        break;
                    default:
                        break;
                }
            }
        }

        private void fraWelcome4_Load(object sender, EventArgs e)
        {
            Text = $"Bienvenue chez EduOne:{_email}";
        }

        private async void kryptonTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var IsInProd=helper.IsAppInProd();//
            var devReportUrl=await ApplicationSettingsHelper.GetApplicationSettingAsync("APPLICATION.REPORTSERVER.DEV.URL");
            var prodReportUrl = await ApplicationSettingsHelper.GetApplicationSettingAsync("APPLICATION.REPORTSERVER.PROD.URL");
            if (IsInProd)
            {
                Process.Start(prodReportUrl);
            }
            else
            {
                Process.Start(devReportUrl);
            }
        }
    }
}
