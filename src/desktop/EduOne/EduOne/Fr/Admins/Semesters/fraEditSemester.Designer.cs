namespace EduOne.Fr.Admins.Semesters
{
    partial class fraEditSemester
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
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtsemester = new DevExpress.XtraEditors.TextEdit();
            this.txtyear = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsemester.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtyear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(228, 562);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(94, 29);
            this.btnclose.TabIndex = 19;
            this.btnclose.Text = "Fermer";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(128, 562);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(94, 29);
            this.btnadd.TabIndex = 18;
            this.btnadd.Text = "Modifier";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(131, 236);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(891, 304);
            this.txtnotes.TabIndex = 17;
            // 
            // ckstatus
            // 
            this.ckstatus.Location = new System.Drawing.Point(130, 151);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(94, 24);
            this.ckstatus.TabIndex = 16;
            // 
            // txtsemester
            // 
            this.txtsemester.Location = new System.Drawing.Point(128, 77);
            this.txtsemester.Name = "txtsemester";
            this.txtsemester.Size = new System.Drawing.Size(478, 22);
            this.txtsemester.TabIndex = 15;
            // 
            // txtyear
            // 
            this.txtyear.Location = new System.Drawing.Point(128, 19);
            this.txtyear.Name = "txtyear";
            this.txtyear.Properties.Appearance.BackColor = System.Drawing.Color.Green;
            this.txtyear.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtyear.Properties.Appearance.Options.UseBackColor = true;
            this.txtyear.Properties.Appearance.Options.UseForeColor = true;
            this.txtyear.Size = new System.Drawing.Size(478, 22);
            this.txtyear.TabIndex = 14;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 156);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Statut";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 234);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 16);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Notes";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 16);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Semestre";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 16);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Année";
            // 
            // fraEditSemester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 616);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.txtsemester);
            this.Controls.Add(this.txtyear);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraEditSemester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier Semestre";
            this.Load += new System.EventHandler(this.fraEditSemester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsemester.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtyear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraEditors.TextEdit txtsemester;
        private DevExpress.XtraEditors.TextEdit txtyear;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}