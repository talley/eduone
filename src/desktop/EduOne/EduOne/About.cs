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