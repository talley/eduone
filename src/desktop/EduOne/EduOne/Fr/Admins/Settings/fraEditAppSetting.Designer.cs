namespace EduOne.Fr.Admins.Settings
{
    partial class fraEditAppSetting
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
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.btnedit = new DevExpress.XtraEditors.SimpleButton();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtvalue = new DevExpress.XtraEditors.TextEdit();
            this.txtkey = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkey.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(217, 656);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(94, 29);
            this.btnclose.TabIndex = 19;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(107, 656);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(94, 29);
            this.btnedit.TabIndex = 18;
            this.btnedit.Text = "Modifier";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(107, 247);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(853, 393);
            this.txtnotes.TabIndex = 17;
            // 
            // ckstatus
            // 
            this.ckstatus.Location = new System.Drawing.Point(107, 171);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(94, 19);
            this.ckstatus.TabIndex = 16;
            // 
            // txtvalue
            // 
            this.txtvalue.Location = new System.Drawing.Point(107, 101);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(853, 22);
            this.txtvalue.TabIndex = 15;
            // 
            // txtkey
            // 
            this.txtkey.Enabled = false;
            this.txtkey.Location = new System.Drawing.Point(107, 38);
            this.txtkey.Name = "txtkey";
            this.txtkey.Properties.Appearance.BackColor = System.Drawing.Color.Red;
            this.txtkey.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtkey.Properties.Appearance.Options.UseBackColor = true;
            this.txtkey.Properties.Appearance.Options.UseForeColor = true;
            this.txtkey.Size = new System.Drawing.Size(853, 22);
            this.txtkey.TabIndex = 14;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 247);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 16);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Notes";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 173);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 16);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Statut";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 104);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 16);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Valeur";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 16);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Clé";
            // 
            // fraEditAppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 722);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.txtkey);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraEditAppSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mis a jour";
            this.Load += new System.EventHandler(this.fraEditAppSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkey.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnedit;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraEditors.TextEdit txtvalue;
        private DevExpress.XtraEditors.TextEdit txtkey;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}