namespace EduOne.Fr.Tools
{
    partial class frAddTheme
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.drpthemes = new DevExpress.XtraEditors.LookUpEdit();
            this.txtheme = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.drpthemes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtheme.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(246, 212);
            this.btnclose.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(126, 29);
            this.btnclose.TabIndex = 19;
            this.btnclose.Text = "Fermer";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(105, 212);
            this.btnadd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(131, 29);
            this.btnadd.TabIndex = 18;
            this.btnadd.Text = "Ajouter";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 142);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 16);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Valeur";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(39, 44);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 16);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Thème";
            // 
            // drpthemes
            // 
            this.drpthemes.Location = new System.Drawing.Point(118, 48);
            this.drpthemes.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.drpthemes.Name = "drpthemes";
            this.drpthemes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpthemes.Properties.NullText = "";
            this.drpthemes.Size = new System.Drawing.Size(917, 22);
            this.drpthemes.TabIndex = 20;
            this.drpthemes.EditValueChanged += new System.EventHandler(this.drpthemes_EditValueChanged);
            // 
            // txtheme
            // 
            this.txtheme.Enabled = false;
            this.txtheme.Location = new System.Drawing.Point(118, 139);
            this.txtheme.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtheme.Name = "txtheme";
            this.txtheme.Size = new System.Drawing.Size(916, 22);
            this.txtheme.TabIndex = 15;
            // 
            // frAddTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 245);
            this.Controls.Add(this.drpthemes);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtheme);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frAddTheme";
            this.Text = "frAddTheme";
            this.Load += new System.EventHandler(this.frAddTheme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drpthemes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtheme.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.TextEdit txtheme;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit drpthemes;
    }
}