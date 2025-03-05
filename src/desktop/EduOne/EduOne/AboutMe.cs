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

namespace EduOne
{
	public partial class AboutMe: DevExpress.XtraEditors.XtraForm
	{
        public AboutMe()
		{
            InitializeComponent();
		}

        private void AboutMe_Load(object sender, EventArgs e)
        {
            //"C:\\Users\\Abibou\\Documents\\About Me.docx"
            richEditControl1.LoadDocument("C:\\MyApps\\NET\\eduone\\src\\desktop\\EduOne\\EduOne\\Documents\\AboutMe.docx");
        }
    }
}