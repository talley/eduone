namespace EduOne.Fr.Admins.Departments
{
    partial class fraEditDepartment
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
            this.txtdesc = new DevExpress.XtraRichEdit.RichEditControl();
            this.drpdepts = new DevExpress.XtraEditors.LookUpEdit();
            this.txtdept = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblhead = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.drpdepts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdept.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(310, 607);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(132, 29);
            this.btnclose.TabIndex = 15;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(172, 607);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(132, 29);
            this.btnedit.TabIndex = 14;
            this.btnedit.Text = "Modifier";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(169, 199);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtdesc.Size = new System.Drawing.Size(708, 391);
            this.txtdesc.TabIndex = 13;
            // 
            // drpdepts
            // 
            this.drpdepts.Location = new System.Drawing.Point(172, 109);
            this.drpdepts.Name = "drpdepts";
            this.drpdepts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpdepts.Properties.NullText = "";
            this.drpdepts.Size = new System.Drawing.Size(526, 22);
            this.drpdepts.TabIndex = 12;
            // 
            // txtdept
            // 
            this.txtdept.Location = new System.Drawing.Point(172, 37);
            this.txtdept.Name = "txtdept";
            this.txtdept.Size = new System.Drawing.Size(526, 22);
            this.txtdept.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 197);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Description";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 16);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Chef Département";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(104, 16);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Nom Département";
            // 
            // lblhead
            // 
            this.lblhead.Appearance.BackColor = System.Drawing.Color.Green;
            this.lblhead.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblhead.Appearance.Options.UseBackColor = true;
            this.lblhead.Appearance.Options.UseForeColor = true;
            this.lblhead.Location = new System.Drawing.Point(711, 112);
            this.lblhead.Name = "lblhead";
            this.lblhead.Size = new System.Drawing.Size(75, 16);
            this.lblhead.TabIndex = 16;
            this.lblhead.Text = "labelControl4";
            // 
            // fraEditDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 703);
            this.Controls.Add(this.lblhead);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.drpdepts);
            this.Controls.Add(this.txtdept);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraEditDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fraEditDepartment";
            this.Load += new System.EventHandler(this.fraEditDepartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drpdepts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdept.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnedit;
        private DevExpress.XtraRichEdit.RichEditControl txtdesc;
        private DevExpress.XtraEditors.LookUpEdit drpdepts;
        private DevExpress.XtraEditors.TextEdit txtdept;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblhead;
    }
}