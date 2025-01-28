namespace EduOne.Fr.Admins
{
    partial class fraEditUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtdob = new DevExpress.XtraEditors.DateEdit();
            this.drproles = new DevExpress.XtraEditors.LookUpEdit();
            this.btnclear = new DevExpress.XtraEditors.SimpleButton();
            this.btnedituser = new DevExpress.XtraEditors.SimpleButton();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtlname = new DevExpress.XtraEditors.TextEdit();
            this.txtpass = new DevExpress.XtraEditors.TextEdit();
            this.txtemail = new DevExpress.XtraEditors.TextEdit();
            this.txtfname = new DevExpress.XtraEditors.TextEdit();
            this.txtusername = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnchangepwd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtdob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdob.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drproles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtemail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtusername.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtdob
            // 
            this.dtdob.EditValue = null;
            this.dtdob.Location = new System.Drawing.Point(541, 171);
            this.dtdob.Name = "dtdob";
            this.dtdob.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdob.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdob.Size = new System.Drawing.Size(266, 22);
            this.dtdob.TabIndex = 40;
            // 
            // drproles
            // 
            this.drproles.Location = new System.Drawing.Point(541, 237);
            this.drproles.Name = "drproles";
            this.drproles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drproles.Properties.NullText = "";
            this.drproles.Size = new System.Drawing.Size(266, 22);
            this.drproles.TabIndex = 39;
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(325, 653);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(179, 29);
            this.btnclear.TabIndex = 38;
            this.btnclear.Text = "Effacer";
            // 
            // btnedituser
            // 
            this.btnedituser.Location = new System.Drawing.Point(131, 653);
            this.btnedituser.Name = "btnedituser";
            this.btnedituser.Size = new System.Drawing.Size(179, 29);
            this.btnedituser.TabIndex = 37;
            this.btnedituser.Text = "Modifier";
            this.btnedituser.Click += new System.EventHandler(this.btnedituser_Click);
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(131, 302);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(676, 337);
            this.txtnotes.TabIndex = 36;
            // 
            // ckstatus
            // 
            this.ckstatus.Location = new System.Drawing.Point(131, 105);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "Oui/Non";
            this.ckstatus.Size = new System.Drawing.Size(94, 20);
            this.ckstatus.TabIndex = 35;
            // 
            // txtlname
            // 
            this.txtlname.Location = new System.Drawing.Point(541, 103);
            this.txtlname.Name = "txtlname";
            this.txtlname.Size = new System.Drawing.Size(266, 22);
            this.txtlname.TabIndex = 34;
            // 
            // txtpass
            // 
            this.txtpass.Enabled = false;
            this.txtpass.Location = new System.Drawing.Point(541, 43);
            this.txtpass.Name = "txtpass";
            this.txtpass.Properties.Appearance.BackColor = System.Drawing.Color.Red;
            this.txtpass.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtpass.Properties.Appearance.Options.UseBackColor = true;
            this.txtpass.Properties.Appearance.Options.UseForeColor = true;
            this.txtpass.Size = new System.Drawing.Size(266, 22);
            this.txtpass.TabIndex = 33;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(131, 237);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(266, 22);
            this.txtemail.TabIndex = 32;
            // 
            // txtfname
            // 
            this.txtfname.Location = new System.Drawing.Point(131, 171);
            this.txtfname.Name = "txtfname";
            this.txtfname.Size = new System.Drawing.Size(266, 22);
            this.txtfname.TabIndex = 31;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(131, 43);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(266, 22);
            this.txtusername.TabIndex = 30;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 302);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(32, 16);
            this.labelControl9.TabIndex = 29;
            this.labelControl9.Text = "Notes";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(459, 240);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(25, 16);
            this.labelControl8.TabIndex = 28;
            this.labelControl8.Text = "Role";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 240);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(31, 16);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "Email";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(460, 174);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(57, 16);
            this.labelControl6.TabIndex = 26;
            this.labelControl6.Text = "Naissance";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(460, 103);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(26, 16);
            this.labelControl5.TabIndex = 25;
            this.labelControl5.Text = "Nom";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(459, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 16);
            this.labelControl4.TabIndex = 24;
            this.labelControl4.Text = "Password";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 177);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 16);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "Prénom";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 16);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Status";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 16);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Utilisateur";
            // 
            // btnchangepwd
            // 
            this.btnchangepwd.Location = new System.Drawing.Point(813, 43);
            this.btnchangepwd.Name = "btnchangepwd";
            this.btnchangepwd.Size = new System.Drawing.Size(117, 25);
            this.btnchangepwd.TabIndex = 41;
            this.btnchangepwd.Text = "Changer";
            this.btnchangepwd.Click += new System.EventHandler(this.btnchangepwd_Click);
            // 
            // fraEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 693);
            this.Controls.Add(this.btnchangepwd);
            this.Controls.Add(this.dtdob);
            this.Controls.Add(this.drproles);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnedituser);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.txtlname);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtfname);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraEditUser";
            this.Text = "fraEditUser";
            this.Load += new System.EventHandler(this.fraEditUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtdob.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drproles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtemail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtusername.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtdob;
        private DevExpress.XtraEditors.LookUpEdit drproles;
        private DevExpress.XtraEditors.SimpleButton btnclear;
        private DevExpress.XtraEditors.SimpleButton btnedituser;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraEditors.TextEdit txtlname;
        private DevExpress.XtraEditors.TextEdit txtpass;
        private DevExpress.XtraEditors.TextEdit txtemail;
        private DevExpress.XtraEditors.TextEdit txtfname;
        private DevExpress.XtraEditors.TextEdit txtusername;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnchangepwd;
    }
}