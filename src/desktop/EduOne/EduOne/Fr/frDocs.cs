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