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
using EduOne.Data.Fr;
using EduOne.Repositories.Fr;

namespace EduOne.Fr.Admins
{
    public partial class fraAddUser : DevExpress.XtraEditors.XtraForm
    {
        private IRepository<ApplicationRoles> repository = new ApplicationRolesRepository();

        public fraAddUser()
        {
            InitializeComponent();
        }

        private async void fraAddUser_Load(object sender, EventArgs e)
        {
            //drproles.Properties.Columns["Id"].Visible = false;
            var roles = await repository.GetAllAsync();
            var needed_roles = roles.Select(x => new
            {
               x.NomRole,x.Description,x.Id
            });
            drproles.Properties.DataSource = needed_roles;
            drproles.Properties.DisplayMember = "NomRole";
            drproles.Properties.ValueMember = "Id";

            drproles.Properties.BestFit();



        }
    }
}