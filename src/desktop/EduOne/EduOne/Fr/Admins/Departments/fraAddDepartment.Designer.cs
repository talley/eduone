namespace EduOne.Fr.Admins.Departments
{
    partial class fraAddDepartment
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
            this.txtdept = new DevExpress.XtraEditors.TextEdit();
            this.drpdepts = new DevExpress.XtraEditors.LookUpEdit();
            this.txtdesc = new DevExpress.XtraRichEdit.RichEditControl();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtdept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpdepts.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(104, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nom Département";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(33, 143);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Chef Département";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 225);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Description";
            // 
            // txtdept
            // 
            this.txtdept.Location = new System.Drawing.Point(177, 65);
            this.txtdept.Name = "txtdept";
            this.txtdept.Size = new System.Drawing.Size(526, 22);
            this.txtdept.TabIndex = 3;
            // 
            // drpdepts
            // 
            this.drpdepts.Location = new System.Drawing.Point(177, 137);
            this.drpdepts.Name = "drpdepts";
            this.drpdepts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpdepts.Properties.NullText = "";
            this.drpdepts.Size = new System.Drawing.Size(526, 22);
            this.drpdepts.TabIndex = 4;
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(174, 227);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtdesc.Size = new System.Drawing.Size(708, 391);
            this.txtdesc.TabIndex = 5;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(177, 635);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(132, 29);
            this.btnadd.TabIndex = 6;
            this.btnadd.Text = "Ajouter";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(315, 635);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(132, 29);
            this.btnclose.TabIndex = 7;
            this.btnclose.Text = "Fermer";
            // 
            // fraAddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 687);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.drpdepts);
            this.Controls.Add(this.txtdept);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraAddDepartment";
            this.Load += new System.EventHandler(this.fraAddDepartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtdept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpdepts.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtdept;
        private DevExpress.XtraEditors.LookUpEdit drpdepts;
        private DevExpress.XtraRichEdit.RichEditControl txtdesc;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.SimpleButton btnclose;
    }
}