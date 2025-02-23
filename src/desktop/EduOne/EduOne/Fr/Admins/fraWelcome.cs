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