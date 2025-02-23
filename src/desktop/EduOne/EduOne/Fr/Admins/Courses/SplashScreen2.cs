using System;
using DevExpress.XtraSplashScreen;

namespace EduOne.Fr.Admins.Courses
{
    public partial class SplashScreen2 : SplashScreen
    {
        public SplashScreen2()
        {
            InitializeComponent();
            this.labelCopyright.Text = $"Copyright © {DateTime.Now.Year}- Talley Ouro";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}