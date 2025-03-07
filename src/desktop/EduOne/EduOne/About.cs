using System;

namespace EduOne
{
	public partial class About: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        public About(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}