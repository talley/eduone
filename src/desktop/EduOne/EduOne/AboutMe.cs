using System;

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