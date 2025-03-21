namespace EduOne.Fr.Admins.Courses
{
    partial class fraEditCourse
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
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.btnedit = new DevExpress.XtraEditors.SimpleButton();
            this.drpdepts = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcoursename = new DevExpress.XtraEditors.TextEdit();
            this.txtdesc = new DevExpress.XtraRichEdit.RichEditControl();
            this.lblid = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpdepts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcoursename.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ckstatus
            // 
            this.ckstatus.EditValue = true;
            this.ckstatus.Location = new System.Drawing.Point(136, 163);
            this.ckstatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "Oui/Non";
            this.ckstatus.Size = new System.Drawing.Size(118, 20);
            this.ckstatus.TabIndex = 35;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(28, 165);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 16);
            this.labelControl5.TabIndex = 34;
            this.labelControl5.Text = "Statut";
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(335, 643);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(186, 36);
            this.btnclose.TabIndex = 33;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(136, 643);
            this.btnedit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(175, 36);
            this.btnedit.TabIndex = 32;
            this.btnedit.Text = "Mis A Jour";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // drpdepts
            // 
            this.drpdepts.Location = new System.Drawing.Point(799, 106);
            this.drpdepts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drpdepts.Name = "drpdepts";
            this.drpdepts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpdepts.Properties.NullText = "";
            this.drpdepts.Size = new System.Drawing.Size(426, 22);
            this.drpdepts.TabIndex = 31;
            // 
            // txtcoursename
            // 
            this.txtcoursename.Location = new System.Drawing.Point(136, 104);
            this.txtcoursename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtcoursename.Name = "txtcoursename";
            this.txtcoursename.Size = new System.Drawing.Size(504, 22);
            this.txtcoursename.TabIndex = 30;
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(136, 215);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtdesc.Size = new System.Drawing.Size(1089, 405);
            this.txtdesc.TabIndex = 29;
            // 
            // lblid
            // 
            this.lblid.Location = new System.Drawing.Point(170, 22);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(83, 16);
            this.lblid.TabIndex = 28;
            this.lblid.Text = "Modifier Cours";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 215);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 16);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Description";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(699, 110);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 16);
            this.labelControl2.TabIndex = 26;
            this.labelControl2.Text = "Département";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 105);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 16);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Nom Du Cours";
            // 
            // fraEditCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 710);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.drpdepts);
            this.Controls.Add(this.txtcoursename);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraEditCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier Le Cours";
            this.Load += new System.EventHandler(this.fraEditCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpdepts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcoursename.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnedit;
        private DevExpress.XtraEditors.LookUpEdit drpdepts;
        private DevExpress.XtraEditors.TextEdit txtcoursename;
        private DevExpress.XtraRichEdit.RichEditControl txtdesc;
        private DevExpress.XtraEditors.LabelControl lblid;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}