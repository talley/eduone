namespace EduOne.Fr.Admins.Settings
{
    partial class fraAddApplicationSetting
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtkey = new DevExpress.XtraEditors.TextEdit();
            this.txtvalue = new DevExpress.XtraEditors.TextEdit();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.txtkey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 58);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Clé";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 136);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Valeur";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 222);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Statut";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(35, 315);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Notes";
            // 
            // txtkey
            // 
            this.txtkey.Location = new System.Drawing.Point(141, 54);
            this.txtkey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtkey.Name = "txtkey";
            this.txtkey.Size = new System.Drawing.Size(830, 22);
            this.txtkey.TabIndex = 4;
            // 
            // txtvalue
            // 
            this.txtvalue.Location = new System.Drawing.Point(141, 132);
            this.txtvalue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(830, 22);
            this.txtvalue.TabIndex = 5;
            // 
            // ckstatus
            // 
            this.ckstatus.EditValue = true;
            this.ckstatus.Location = new System.Drawing.Point(141, 220);
            this.ckstatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(10, 19);
            this.ckstatus.TabIndex = 6;
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(113, 252);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(858, 393);
            this.txtnotes.TabIndex = 7;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(141, 826);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(10, 36);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "Ajouter";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(279, 826);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(10, 36);
            this.btnclose.TabIndex = 9;
            this.btnclose.Text = "Fermer";
            // 
            // fraAddApplicationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 692);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.txtkey);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraAddApplicationSetting";
            this.Text = "Ajouter un paramètre d\'application";
            this.Load += new System.EventHandler(this.fraAddApplicationSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtkey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtkey;
        private DevExpress.XtraEditors.TextEdit txtvalue;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme1;
    }
}