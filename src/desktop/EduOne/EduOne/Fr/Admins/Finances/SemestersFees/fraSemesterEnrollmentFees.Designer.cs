namespace EduOne.Fr.Admins.Finances.SemestersFees
{
    partial class fraSemesterEnrollmentFees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fraSemesterEnrollmentFees));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.drpstudents = new DevExpress.XtraEditors.LookUpEdit();
            this.drpsemesters = new DevExpress.XtraEditors.LookUpEdit();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtamountdue = new DevExpress.XtraEditors.TextEdit();
            this.txtamountrec = new DevExpress.XtraEditors.TextEdit();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.btnpay = new DevExpress.XtraEditors.SimpleButton();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.txtbalance = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.btncalculate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.drpstudents.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpsemesters.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamountdue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamountrec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbalance.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(220, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(170, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Veuillez traiter le paiement ici";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(49, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(129, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Choisir Eleve(Étudiant)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(49, 124);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Semestre";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(49, 176);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Statut";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(50, 282);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 16);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "MontantReçu";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(49, 230);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 16);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Montant Dû";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(51, 381);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(32, 16);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Notes";
            // 
            // drpstudents
            // 
            this.drpstudents.Location = new System.Drawing.Point(220, 76);
            this.drpstudents.Name = "drpstudents";
            this.drpstudents.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpstudents.Properties.NullText = "";
            this.drpstudents.Size = new System.Drawing.Size(841, 22);
            this.drpstudents.TabIndex = 7;
            // 
            // drpsemesters
            // 
            this.drpsemesters.Location = new System.Drawing.Point(220, 121);
            this.drpsemesters.Name = "drpsemesters";
            this.drpsemesters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpsemesters.Properties.NullText = "";
            this.drpsemesters.Size = new System.Drawing.Size(841, 22);
            this.drpsemesters.TabIndex = 8;
            this.drpsemesters.SelectionChanged += new System.EventHandler<DevExpress.XtraEditors.Controls.PopupSelectionChangedEventArgs>(this.drpsemesters_SelectionChanged);
            this.drpsemesters.EditValueChanged += new System.EventHandler(this.drpsemesters_EditValueChanged);
            // 
            // ckstatus
            // 
            this.ckstatus.Enabled = false;
            this.ckstatus.Location = new System.Drawing.Point(220, 172);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(94, 19);
            this.ckstatus.TabIndex = 9;
            // 
            // txtamountdue
            // 
            this.txtamountdue.EditValue = "0";
            this.txtamountdue.Enabled = false;
            this.txtamountdue.Location = new System.Drawing.Point(220, 224);
            this.txtamountdue.Name = "txtamountdue";
            this.txtamountdue.Properties.Appearance.BackColor = System.Drawing.Color.Green;
            this.txtamountdue.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtamountdue.Properties.Appearance.Options.UseBackColor = true;
            this.txtamountdue.Properties.Appearance.Options.UseForeColor = true;
            this.txtamountdue.Size = new System.Drawing.Size(305, 22);
            this.txtamountdue.TabIndex = 11;
            this.txtamountdue.EditValueChanged += new System.EventHandler(this.txtamountdue_EditValueChanged);
            // 
            // txtamountrec
            // 
            this.txtamountrec.EditValue = "";
            this.txtamountrec.Location = new System.Drawing.Point(220, 279);
            this.txtamountrec.Name = "txtamountrec";
            this.txtamountrec.Size = new System.Drawing.Size(305, 22);
            this.txtamountrec.TabIndex = 12;
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(220, 381);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(839, 308);
            this.txtnotes.TabIndex = 13;
            // 
            // btnpay
            // 
            this.btnpay.Location = new System.Drawing.Point(220, 707);
            this.btnpay.Name = "btnpay";
            this.btnpay.Size = new System.Drawing.Size(213, 29);
            this.btnpay.TabIndex = 14;
            this.btnpay.Text = "Traiter le paiement";
            this.btnpay.Click += new System.EventHandler(this.btnpaid_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(448, 707);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(94, 29);
            this.btnclose.TabIndex = 15;
            this.btnclose.Text = "Fermer";
            // 
            // txtbalance
            // 
            this.txtbalance.EditValue = "0";
            this.txtbalance.Enabled = false;
            this.txtbalance.Location = new System.Drawing.Point(219, 333);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.Size = new System.Drawing.Size(305, 22);
            this.txtbalance.TabIndex = 17;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(49, 336);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(44, 16);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "Balance";
            // 
            // btncalculate
            // 
            this.btncalculate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btncalculate.ImageOptions.Image")));
            this.btncalculate.Location = new System.Drawing.Point(530, 329);
            this.btncalculate.Name = "btncalculate";
            this.btncalculate.Size = new System.Drawing.Size(126, 29);
            this.btncalculate.TabIndex = 18;
            this.btncalculate.Text = "Calculer";
            this.btncalculate.Click += new System.EventHandler(this.btncalculate_Click);
            // 
            // fraSemesterEnrollmentFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 745);
            this.Controls.Add(this.btncalculate);
            this.Controls.Add(this.txtbalance);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnpay);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.txtamountrec);
            this.Controls.Add(this.txtamountdue);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.drpsemesters);
            this.Controls.Add(this.drpstudents);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraSemesterEnrollmentFees";
            this.Text = "fraSemesterEnrollmentFees";
            this.Load += new System.EventHandler(this.fraSemesterEnrollmentFees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drpstudents.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpsemesters.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamountdue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamountrec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbalance.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit drpstudents;
        private DevExpress.XtraEditors.LookUpEdit drpsemesters;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraEditors.TextEdit txtamountdue;
        private DevExpress.XtraEditors.TextEdit txtamountrec;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.SimpleButton btnpay;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.TextEdit txtbalance;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btncalculate;
    }
}