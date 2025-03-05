namespace EduOne.Fr.Admins.Finances
{
    partial class fraEditStudentSemesterFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fraEditStudentSemesterFee));
            this.btncalculate = new DevExpress.XtraEditors.SimpleButton();
            this.txtbalance = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.btnpay = new DevExpress.XtraEditors.SimpleButton();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.txtamountrec = new DevExpress.XtraEditors.TextEdit();
            this.txtamountdue = new DevExpress.XtraEditors.TextEdit();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtstudentid = new DevExpress.XtraEditors.TextEdit();
            this.txtsemesterid = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamountrec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamountdue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstudentid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsemesterid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btncalculate
            // 
            this.btncalculate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btncalculate.ImageOptions.Image")));
            this.btncalculate.Location = new System.Drawing.Point(493, 330);
            this.btncalculate.Name = "btncalculate";
            this.btncalculate.Size = new System.Drawing.Size(126, 29);
            this.btncalculate.TabIndex = 37;
            this.btncalculate.Text = "Calculer";
            this.btncalculate.Click += new System.EventHandler(this.btncalculate_Click);
            // 
            // txtbalance
            // 
            this.txtbalance.EditValue = "0";
            this.txtbalance.Enabled = false;
            this.txtbalance.Location = new System.Drawing.Point(182, 334);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.Size = new System.Drawing.Size(305, 22);
            this.txtbalance.TabIndex = 36;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 337);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(44, 16);
            this.labelControl9.TabIndex = 35;
            this.labelControl9.Text = "Balance";
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(411, 708);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(94, 29);
            this.btnclose.TabIndex = 34;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnpay
            // 
            this.btnpay.Location = new System.Drawing.Point(183, 708);
            this.btnpay.Name = "btnpay";
            this.btnpay.Size = new System.Drawing.Size(213, 29);
            this.btnpay.TabIndex = 33;
            this.btnpay.Text = "Modifier Le paiement";
            this.btnpay.Click += new System.EventHandler(this.btnpay_Click);
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(183, 382);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(839, 308);
            this.txtnotes.TabIndex = 32;
            // 
            // txtamountrec
            // 
            this.txtamountrec.EditValue = "";
            this.txtamountrec.Location = new System.Drawing.Point(183, 280);
            this.txtamountrec.Name = "txtamountrec";
            this.txtamountrec.Size = new System.Drawing.Size(305, 22);
            this.txtamountrec.TabIndex = 31;
            // 
            // txtamountdue
            // 
            this.txtamountdue.EditValue = "0";
            this.txtamountdue.Enabled = false;
            this.txtamountdue.Location = new System.Drawing.Point(183, 225);
            this.txtamountdue.Name = "txtamountdue";
            this.txtamountdue.Properties.Appearance.BackColor = System.Drawing.Color.Green;
            this.txtamountdue.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtamountdue.Properties.Appearance.Options.UseBackColor = true;
            this.txtamountdue.Properties.Appearance.Options.UseForeColor = true;
            this.txtamountdue.Size = new System.Drawing.Size(305, 22);
            this.txtamountdue.TabIndex = 30;
            // 
            // ckstatus
            // 
            this.ckstatus.Enabled = false;
            this.ckstatus.Location = new System.Drawing.Point(183, 173);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(94, 19);
            this.ckstatus.TabIndex = 28;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 382);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(32, 16);
            this.labelControl7.TabIndex = 25;
            this.labelControl7.Text = "Notes";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 231);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 16);
            this.labelControl6.TabIndex = 24;
            this.labelControl6.Text = "Montant Dû";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 283);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 16);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "MontantReçu";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 177);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 22;
            this.labelControl4.Text = "Statut";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 125);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 16);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "Semestre";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(129, 16);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "Choisir Eleve(Étudiant)";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(183, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(170, 16);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Veuillez traiter le paiement ici";
            // 
            // txtstudentid
            // 
            this.txtstudentid.EditValue = "";
            this.txtstudentid.Enabled = false;
            this.txtstudentid.Location = new System.Drawing.Point(182, 74);
            this.txtstudentid.Name = "txtstudentid";
            this.txtstudentid.Size = new System.Drawing.Size(305, 22);
            this.txtstudentid.TabIndex = 38;
            // 
            // txtsemesterid
            // 
            this.txtsemesterid.EditValue = "";
            this.txtsemesterid.Enabled = false;
            this.txtsemesterid.Location = new System.Drawing.Point(182, 122);
            this.txtsemesterid.Name = "txtsemesterid";
            this.txtsemesterid.Size = new System.Drawing.Size(305, 22);
            this.txtsemesterid.TabIndex = 39;
            // 
            // fraEditStudentSemesterFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 771);
            this.Controls.Add(this.txtsemesterid);
            this.Controls.Add(this.txtstudentid);
            this.Controls.Add(this.btncalculate);
            this.Controls.Add(this.txtbalance);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnpay);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.txtamountrec);
            this.Controls.Add(this.txtamountdue);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fraEditStudentSemesterFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier Frais De L`eleve(etudiant)";
            this.Load += new System.EventHandler(this.fraEditStudentSemesterFee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtbalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamountrec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamountdue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstudentid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsemesterid.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btncalculate;
        private DevExpress.XtraEditors.TextEdit txtbalance;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnpay;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.TextEdit txtamountrec;
        private DevExpress.XtraEditors.TextEdit txtamountdue;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtstudentid;
        private DevExpress.XtraEditors.TextEdit txtsemesterid;
    }
}