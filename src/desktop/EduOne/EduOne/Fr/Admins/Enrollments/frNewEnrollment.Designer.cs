namespace EduOne.Fr.Admins.Enrollments
{
    partial class frNewEnrollment
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtgrade = new DevExpress.XtraEditors.TextEdit();
            this.dtdateinsc = new DevExpress.XtraEditors.DateEdit();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.drpstudentid = new DevExpress.XtraEditors.LookUpEdit();
            this.drpcourseid = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.drpsemesters = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgrade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpstudentid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpcourseid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpsemesters.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(60, 108);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Choisir Eleve";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(60, 166);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Choisir Cours";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(56, 229);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(89, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Date Inscription";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(60, 292);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Grade";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(55, 358);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 16);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Statut";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(51, 426);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 16);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Notes";
            // 
            // txtgrade
            // 
            this.txtgrade.Location = new System.Drawing.Point(230, 289);
            this.txtgrade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtgrade.Name = "txtgrade";
            this.txtgrade.Size = new System.Drawing.Size(182, 22);
            this.txtgrade.TabIndex = 8;
            // 
            // dtdateinsc
            // 
            this.dtdateinsc.EditValue = null;
            this.dtdateinsc.Location = new System.Drawing.Point(231, 229);
            this.dtdateinsc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtdateinsc.Name = "dtdateinsc";
            this.dtdateinsc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdateinsc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdateinsc.Properties.CalendarTimeProperties.MaskSettings.Set("culture", "fr-FR");
            this.dtdateinsc.Size = new System.Drawing.Size(486, 22);
            this.dtdateinsc.TabIndex = 9;
            // 
            // ckstatus
            // 
            this.ckstatus.Location = new System.Drawing.Point(231, 355);
            this.ckstatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(118, 19);
            this.ckstatus.TabIndex = 10;
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(211, 457);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(868, 418);
            this.txtnotes.TabIndex = 11;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(200, 896);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(189, 36);
            this.btnadd.TabIndex = 12;
            this.btnadd.Text = "Ajouter";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(397, 896);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(189, 36);
            this.btnclose.TabIndex = 13;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // drpstudentid
            // 
            this.drpstudentid.Location = new System.Drawing.Point(238, 111);
            this.drpstudentid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drpstudentid.Name = "drpstudentid";
            this.drpstudentid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpstudentid.Properties.NullText = "";
            this.drpstudentid.Size = new System.Drawing.Size(1071, 22);
            this.drpstudentid.TabIndex = 14;
            // 
            // drpcourseid
            // 
            this.drpcourseid.Location = new System.Drawing.Point(238, 162);
            this.drpcourseid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drpcourseid.Name = "drpcourseid";
            this.drpcourseid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpcourseid.Properties.NullText = "";
            this.drpcourseid.Size = new System.Drawing.Size(1071, 22);
            this.drpcourseid.TabIndex = 15;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(61, 40);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(55, 16);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "Semestre";
            // 
            // drpsemesters
            // 
            this.drpsemesters.Location = new System.Drawing.Point(231, 40);
            this.drpsemesters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drpsemesters.Name = "drpsemesters";
            this.drpsemesters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpsemesters.Properties.NullText = "";
            this.drpsemesters.Size = new System.Drawing.Size(1078, 22);
            this.drpsemesters.TabIndex = 17;
            // 
            // frNewEnrollment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 945);
            this.Controls.Add(this.drpsemesters);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.drpcourseid);
            this.Controls.Add(this.drpstudentid);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.dtdateinsc);
            this.Controls.Add(this.txtgrade);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frNewEnrollment";
            this.Text = "Nouvelle inscription";
            this.Load += new System.EventHandler(this.frNewEnrollment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtgrade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpstudentid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpcourseid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpsemesters.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtgrade;
        private DevExpress.XtraEditors.DateEdit dtdateinsc;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.LookUpEdit drpstudentid;
        private DevExpress.XtraEditors.LookUpEdit drpcourseid;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit drpsemesters;
    }
}