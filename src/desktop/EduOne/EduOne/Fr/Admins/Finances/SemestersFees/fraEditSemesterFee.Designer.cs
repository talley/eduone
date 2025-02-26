namespace EduOne.Fr.Admins.Finances.SemestersFees
{
    partial class fraEditSemesterFee
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
            this.btnedit = new DevExpress.XtraEditors.SimpleButton();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.txtfees = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtsemester = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfees.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsemester.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(232, 624);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(94, 29);
            this.btnclose.TabIndex = 15;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(132, 624);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(94, 29);
            this.btnedit.TabIndex = 14;
            this.btnedit.Text = "Modifier";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(131, 159);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(762, 459);
            this.txtnotes.TabIndex = 13;
            // 
            // txtfees
            // 
            this.txtfees.EditValue = "0.00";
            this.txtfees.Location = new System.Drawing.Point(132, 89);
            this.txtfees.Name = "txtfees";
            this.txtfees.Properties.Appearance.BackColor = System.Drawing.Color.Green;
            this.txtfees.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtfees.Properties.Appearance.Options.UseBackColor = true;
            this.txtfees.Properties.Appearance.Options.UseForeColor = true;
            this.txtfees.Size = new System.Drawing.Size(761, 22);
            this.txtfees.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(0, 157);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Notes";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(-1, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(106, 16);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Frais Du Semestre";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(-8, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 16);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = " Semestre";
            // 
            // txtsemester
            // 
            this.txtsemester.Enabled = false;
            this.txtsemester.Location = new System.Drawing.Point(132, 23);
            this.txtsemester.Name = "txtsemester";
            this.txtsemester.Properties.Appearance.BackColor = System.Drawing.Color.Red;
            this.txtsemester.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtsemester.Properties.Appearance.Options.UseBackColor = true;
            this.txtsemester.Properties.Appearance.Options.UseForeColor = true;
            this.txtsemester.Size = new System.Drawing.Size(761, 22);
            this.txtsemester.TabIndex = 16;
            // 
            // fraEditSemesterFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 663);
            this.Controls.Add(this.txtsemester);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.txtfees);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraEditSemesterFee";
            this.Text = "Modifier Frais Du Semestre";
            this.Load += new System.EventHandler(this.fraEditSemesterFee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtfees.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsemester.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnedit;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.TextEdit txtfees;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtsemester;
    }
}