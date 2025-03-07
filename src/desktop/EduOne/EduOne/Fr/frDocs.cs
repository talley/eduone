using System;

namespace EduOne.Fr
{
	public partial class frDocs: DevExpress.XtraEditors.XtraForm
	{
        public frDocs()
		{
            InitializeComponent();
		}

        private void frDocs_Load(object sender, EventArgs e)
        {
            pdfViewer1.LoadDocument("C:\\MyApps\\NET\\eduone\\src\\docs\\FR\\EduOneProject.pdf");
        }
    }
}