namespace EduOne
{
    partial class XtraForm1
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
            this.lkactualcourseid = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lkactualstudentid = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.drpcourseid = new DevExpress.XtraEditors.LookUpEdit();
            this.drpstudentid = new DevExpress.XtraEditors.LookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.drpcourseid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpstudentid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgrade.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkactualcourseid
            // 
            this.lkactualcourseid.Location = new System.Drawing.Point(1608, 103);
            this.lkactualcourseid.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lkactualcourseid.Name = "lkactualcourseid";
            this.lkactualcourseid.Size = new System.Drawing.Size(35, 16);
            this.lkactualcourseid.TabIndex = 47;
            this.lkactualcourseid.Text = "Actuel";
            // 
            // lkactualstudentid
            // 
            this.lkactualstudentid.Location = new System.Drawing.Point(1615, 43);
            this.lkactualstudentid.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lkactualstudentid.Name = "lkactualstudentid";
            this.lkactualstudentid.Size = new System.Drawing.Size(35, 16);
            this.lkactualstudentid.TabIndex = 46;
            this.lkactualstudentid.Text = "Actuel";
            // 
            // drpcourseid
            // 
            this.drpcourseid.Location = new System.Drawing.Point(267, 103);
            this.drpcourseid.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.drpcourseid.Name = "drpcourseid";
            this.drpcourseid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpcourseid.Properties.NullText = "";
            this.drpcourseid.Size = new System.Drawing.Size(1339, 22);
            this.drpcourseid.TabIndex = 45;
            // 
            // drpstudentid
            // 
            this.drpstudentid.Location = new System.Drawing.Point(267, 39);
            this.drpstudentid.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.drpstudentid.Name = "drpstudentid";
            this.drpstudentid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpstudentid.Properties.NullText = "";
            this.drpstudentid.Size = new System.Drawing.Size(1339, 22);
            this.drpstudentid.TabIndex = 44;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(495, 1047);
            this.btnclose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(236, 45);
            this.btnclose.TabIndex = 43;
            this.btnclose.Text = "Fermer";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(249, 1047);
            this.btnadd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(236, 45);
            this.btnadd.TabIndex = 42;
            this.btnadd.Text = "Mettre A Jour";
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(162, 281);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(868, 377);
            this.txtnotes.TabIndex = 41;
            // 
            // ckstatus
            // 
            this.ckstatus.Location = new System.Drawing.Point(258, 343);
            this.ckstatus.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(148, 19);
            this.ckstatus.TabIndex = 40;
            // 
            // dtdateinsc
            // 
            this.dtdateinsc.EditValue = null;
            this.dtdateinsc.Location = new System.Drawing.Point(258, 185);
            this.dtdateinsc.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.txtgrade.Location = new System.Drawing.Point(257, 260);
            this.txtgrade.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtgrade.Name = "txtgrade";
            this.txtgrade.Size = new System.Drawing.Size(228, 22);
            this.txtgrade.TabIndex = 38;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(33, 433);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 16);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Notes";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(38, 346);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 16);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "Statut";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(45, 265);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 35;
            this.labelControl4.Text = "Grade";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(39, 185);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(89, 16);
            this.labelControl3.TabIndex = 34;
            this.labelControl3.Text = "Date Inscription";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(45, 107);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 16);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "Choisir Cours";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(45, 34);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 16);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Choisir Eleve";
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 760);
            this.Controls.Add(this.lkactualcourseid);
            this.Controls.Add(this.lkactualstudentid);
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
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.drpcourseid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpstudentid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdateinsc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgrade.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.HyperlinkLabelControl lkactualcourseid;
        private DevExpress.XtraEditors.HyperlinkLabelControl lkactualstudentid;
        private DevExpress.XtraEditors.LookUpEdit drpcourseid;
        private DevExpress.XtraEditors.LookUpEdit drpstudentid;
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
    }
}