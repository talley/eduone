using DevExpress.XtraEditors;
using EduOne.Fr.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace EduOne.Fr.Admins
{
    public partial class fraWelcome3 : Telerik.WinControls.UI.RadForm
    {
        string _email;
        public fraWelcome3(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void kryptonTreeView14_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //
            //
            //

            var selText = kryptonTreeView14.SelectedNode.Text;

            switch (selText)
            {
                case "Définir le thème":
                    var form1 = new frAddTheme(_email);
                    ShowFormInPanel(form1, splitPanel2);
                    break;
                case "Visionneuse PDF":
                    var form2 = new frPdfViewer();
                    ShowFormInPanel(form2,splitPanel2);//frExceViewer
                    break;
                case "Visionneuse Excel":
                    var form3 = new frExceViewer();
                    ShowFormInPanel(form3, splitPanel2);//frExceViewer
                    break;
                default:
                    break;
            }
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
    }
}
