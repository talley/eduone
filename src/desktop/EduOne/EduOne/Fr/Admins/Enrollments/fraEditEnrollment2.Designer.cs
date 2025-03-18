namespace EduOne.Fr.Admins.Enrollments
{
    partial class fraEditEnrollment2
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnaddnote = new DevExpress.XtraEditors.SimpleButton();
            this.btnclose2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnedit = new DevExpress.XtraEditors.SimpleButton();
            this.lkactualcourseid = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lkactualstudentid = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.dtdateinsc = new DevExpress.XtraEditors.DateEdit();
            this.txtgrade = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.txtnote2 = new DevExpress.XtraRichEdit.RichEditControl();
            this.btnnewnote = new DevExpress.XtraEditors.SimpleButton();
            this.txtstudentid = new DevExpress.XtraEditors.TextEdit();
            this.txtcourseid = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgrade.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtstudentid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcourseid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1315, 886);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtcourseid);
            this.xtraTabPage1.Controls.Add(this.txtstudentid);
            this.xtraTabPage1.Controls.Add(this.btnaddnote);
            this.xtraTabPage1.Controls.Add(this.btnclose2);
            this.xtraTabPage1.Controls.Add(this.btnedit);
            this.xtraTabPage1.Controls.Add(this.lkactualcourseid);
            this.xtraTabPage1.Controls.Add(this.lkactualstudentid);
            this.xtraTabPage1.Controls.Add(this.btnclose);
            this.xtraTabPage1.Controls.Add(this.btnadd);
            this.xtraTabPage1.Controls.Add(this.txtnotes);
            this.xtraTabPage1.Controls.Add(this.ckstatus);
            this.xtraTabPage1.Controls.Add(this.dtdateinsc);
            this.xtraTabPage1.Controls.Add(this.txtgrade);
            this.xtraTabPage1.Controls.Add(this.labelControl6);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1308, 852);
            this.xtraTabPage1.Text = "Modifier l\'inscription";
            // 
            // btnaddnote
            // 
            this.btnaddnote.Location = new System.Drawing.Point(370, 806);
            this.btnaddnote.Name = "btnaddnote";
            this.btnaddnote.Size = new System.Drawing.Size(139, 29);
            this.btnaddnote.TabIndex = 50;
            this.btnaddnote.Text = "Ajouter Note";
            this.btnaddnote.Click += new System.EventHandler(this.btnaddnote_Click);
            // 
            // btnclose2
            // 
            this.btnclose2.Location = new System.Drawing.Point(515, 806);
            this.btnclose2.Name = "btnclose2";
            this.btnclose2.Size = new System.Drawing.Size(94, 29);
            this.btnclose2.TabIndex = 49;
            this.btnclose2.Text = "Fermer";
            this.btnclose2.Click += new System.EventHandler(this.btnclose2_Click);
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(259, 806);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(94, 29);
            this.btnedit.TabIndex = 48;
            this.btnedit.Text = "Modifier";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // lkactualcourseid
            // 
            this.lkactualcourseid.Location = new System.Drawing.Point(1600, 89);
            this.lkactualcourseid.Margin = new System.Windows.Forms.Padding(5);
            this.lkactualcourseid.Name = "lkactualcourseid";
            this.lkactualcourseid.Size = new System.Drawing.Size(35, 16);
            this.lkactualcourseid.TabIndex = 47;
            this.lkactualcourseid.Text = "Actuel";
            // 
            // lkactualstudentid
            // 
            this.lkactualstudentid.Location = new System.Drawing.Point(1607, 29);
            this.lkactualstudentid.Margin = new System.Windows.Forms.Padding(5);
            this.lkactualstudentid.Name = "lkactualstudentid";
            this.lkactualstudentid.Size = new System.Drawing.Size(35, 16);
            this.lkactualstudentid.TabIndex = 46;
            this.lkactualstudentid.Text = "Actuel";
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(487, 1033);
            this.btnclose.Margin = new System.Windows.Forms.Padding(5);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(236, 45);
            this.btnclose.TabIndex = 43;
            this.btnclose.Text = "Fermer";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(241, 1033);
            this.btnadd.Margin = new System.Windows.Forms.Padding(5);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(236, 45);
            this.btnadd.TabIndex = 42;
            this.btnadd.Text = "Mettre A Jour";
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(253, 290);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(868, 496);
            this.txtnotes.TabIndex = 41;
            // 
            // ckstatus
            // 
            this.ckstatus.Location = new System.Drawing.Point(250, 249);
            this.ckstatus.Margin = new System.Windows.Forms.Padding(5);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(148, 19);
            this.ckstatus.TabIndex = 40;
            // 
            // dtdateinsc
            // 
            this.dtdateinsc.EditValue = null;
            this.dtdateinsc.Enabled = false;
            this.dtdateinsc.Location = new System.Drawing.Point(255, 129);
            this.dtdateinsc.Margin = new System.Windows.Forms.Padding(5);
            this.dtdateinsc.Name = "dtdateinsc";
            this.dtdateinsc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdateinsc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtdateinsc.Properties.CalendarTimeProperties.MaskSettings.Set("culture", "fr-FR");
            this.dtdateinsc.Size = new System.Drawing.Size(608, 22);
            this.dtdateinsc.TabIndex = 39;
            // 
            // txtgrade
            // 
            this.txtgrade.Location = new System.Drawing.Point(254, 191);
            this.txtgrade.Margin = new System.Windows.Forms.Padding(5);
            this.txtgrade.Name = "txtgrade";
            this.txtgrade.Size = new System.Drawing.Size(228, 22);
            this.txtgrade.TabIndex = 38;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(43, 343);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 16);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Notes";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 252);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 16);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "Statut";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(30, 194);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 35;
            this.labelControl4.Text = "Grade";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 132);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(89, 16);
            this.labelControl3.TabIndex = 34;
            this.labelControl3.Text = "Date Inscription";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 76);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 16);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "Choisir Cours";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 28);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 16);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Choisir Eleve";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.txtnote2);
            this.xtraTabPage2.Controls.Add(this.btnnewnote);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageEnabled = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(1308, 852);
            this.xtraTabPage2.Text = "Notes d\'inscription";
            // 
            // txtnote2
            // 
            this.txtnote2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtnote2.Location = new System.Drawing.Point(0, 0);
            this.txtnote2.Name = "txtnote2";
            this.txtnote2.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnote2.Size = new System.Drawing.Size(1308, 823);
            this.txtnote2.TabIndex = 1;
            // 
            // btnnewnote
            // 
            this.btnnewnote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnnewnote.Location = new System.Drawing.Point(0, 823);
            this.btnnewnote.Name = "btnnewnote";
            this.btnnewnote.Size = new System.Drawing.Size(1308, 29);
            this.btnnewnote.TabIndex = 0;
            this.btnnewnote.Text = "Ajouter La Note";
            this.btnnewnote.Click += new System.EventHandler(this.btnnewnote_Click);
            // 
            // txtstudentid
            // 
            this.txtstudentid.Enabled = false;
            this.txtstudentid.Location = new System.Drawing.Point(255, 36);
            this.txtstudentid.Name = "txtstudentid";
            this.txtstudentid.Size = new System.Drawing.Size(608, 22);
            this.txtstudentid.TabIndex = 51;
            // 
            // txtcourseid
            // 
            this.txtcourseid.Enabled = false;
            this.txtcourseid.Location = new System.Drawing.Point(255, 73);
            this.txtcourseid.Name = "txtcourseid";
            this.txtcourseid.Size = new System.Drawing.Size(608, 22);
            this.txtcourseid.TabIndex = 52;
            // 
            // fraEditEnrollment2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 886);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "fraEditEnrollment2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier l`inscription";
            this.Load += new System.EventHandler(this.fraEditEnrollment2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgrade.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtstudentid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcourseid.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.HyperlinkLabelControl lkactualcourseid;
        private DevExpress.XtraEditors.HyperlinkLabelControl lkactualstudentid;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraEditors.DateEdit dtdateinsc;
        private DevExpress.XtraEditors.TextEdit txtgrade;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnclose2;
        private DevExpress.XtraEditors.SimpleButton btnedit;
        private DevExpress.XtraRichEdit.RichEditControl txtnote2;
        private DevExpress.XtraEditors.SimpleButton btnnewnote;
        private DevExpress.XtraEditors.SimpleButton btnaddnote;
        private DevExpress.XtraEditors.TextEdit txtstudentid;
        private DevExpress.XtraEditors.TextEdit txtcourseid;
    }
}