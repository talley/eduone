using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduOne.Fr.Users
{
    public partial class fruWelcome : DevExpress.XtraEditors.XtraForm
    {
       readonly string _email;
        public fruWelcome(string email)
        {
            InitializeComponent();
            _email = email;
        }
    }
}