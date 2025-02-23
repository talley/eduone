namespace EduOne.Fr.Admins.Semesters
{
    partial class fraAddSemester
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
            this.txtyear = new DevExpress.XtraEditors.TextEdit();
            this.txtsemester = new DevExpress.XtraEditors.TextEdit();
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtyear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsemester.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Année";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(36, 102);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Semestre";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(40, 255);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Notes";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(36, 177);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Statut";
            // 
            // txtyear
            // 
            this.txtyear.Location = new System.Drawing.Point(152, 40);
            this.txtyear.Name = "txtyear";
            this.txtyear.Properties.Appearance.BackColor = System.Drawing.Color.Green;
            this.txtyear.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtyear.Properties.Appearance.Options.UseBackColor = true;
            this.txtyear.Properties.Appearance.Options.UseForeColor = true;
            this.txtyear.Size = new System.Drawing.Size(478, 22);
            this.txtyear.TabIndex = 4;
            // 
            // txtsemester
            // 
            this.txtsemester.Location = new System.Drawing.Point(152, 98);
            this.txtsemester.Name = "txtsemester";
            this.txtsemester.Size = new System.Drawing.Size(478, 22);
            this.txtsemester.TabIndex = 5;
            // 
            // ckstatus
            // 
            this.ckstatus.EditValue = true;
            this.ckstatus.Location = new System.Drawing.Point(154, 172);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(94, 24);
            this.ckstatus.TabIndex = 6;
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(155, 257);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(891, 304);
            this.txtnotes.TabIndex = 7;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(152, 583);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(94, 29);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "Ajouter";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(252, 583);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(94, 29);
            this.btnclose.TabIndex = 9;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // fraAddSemester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 620);
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
            this.Name = "fraAddSemester";
            this.Text = "fraAddSemester";
            this.Load += new System.EventHandler(this.fraAddSemester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtyear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsemester.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtyear;
        private DevExpress.XtraEditors.TextEdit txtsemester;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.SimpleButton btnclose;
    }
}