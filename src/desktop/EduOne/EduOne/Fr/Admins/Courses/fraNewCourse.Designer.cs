namespace EduOne.Fr.Admins.Courses
{
    partial class fraNewCourse
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
            this.txtdesc = new DevExpress.XtraRichEdit.RichEditControl();
            this.txtcoursename = new DevExpress.XtraEditors.TextEdit();
            this.drpdepts = new DevExpress.XtraEditors.LookUpEdit();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcoursename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpdepts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(57, 88);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nom Du Cours";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(594, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Département";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(57, 176);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Description";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(171, 22);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Nouveau cours";
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(171, 186);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtdesc.Size = new System.Drawing.Size(844, 438);
            this.txtdesc.TabIndex = 4;
            // 
            // txtcoursename
            // 
            this.txtcoursename.Location = new System.Drawing.Point(171, 89);
            this.txtcoursename.Name = "txtcoursename";
            this.txtcoursename.Size = new System.Drawing.Size(403, 22);
            this.txtcoursename.TabIndex = 5;
            // 
            // drpdepts
            // 
            this.drpdepts.Location = new System.Drawing.Point(674, 89);
            this.drpdepts.Name = "drpdepts";
            this.drpdepts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpdepts.Properties.NullText = "";
            this.drpdepts.Size = new System.Drawing.Size(341, 22);
            this.drpdepts.TabIndex = 20;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(171, 639);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(140, 29);
            this.btnadd.TabIndex = 21;
            this.btnadd.Text = "Ajouter";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(317, 639);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(149, 29);
            this.btnclose.TabIndex = 22;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(57, 136);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 16);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "Statut";
            // 
            // ckstatus
            // 
            this.ckstatus.EditValue = true;
            this.ckstatus.Location = new System.Drawing.Point(171, 134);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "Oui/Non";
            this.ckstatus.Size = new System.Drawing.Size(94, 20);
            this.ckstatus.TabIndex = 24;
            // 
            // fraNewCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 680);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.drpdepts);
            this.Controls.Add(this.txtcoursename);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraNewCourse";
            this.Text = "fraNewCourse";
            this.Load += new System.EventHandler(this.fraNewCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcoursename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpdepts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraRichEdit.RichEditControl txtdesc;
        private DevExpress.XtraEditors.TextEdit txtcoursename;
        private DevExpress.XtraEditors.LookUpEdit drpdepts;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
    }
}