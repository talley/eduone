using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EduOne.Fr.Admins
{
    public partial class fraWelcome : DevExpress.XtraEditors.XtraForm
    {
        private string _email;
        public fraWelcome(string email)
        {
            InitializeComponent();
            _email = email;
        }
    }
}