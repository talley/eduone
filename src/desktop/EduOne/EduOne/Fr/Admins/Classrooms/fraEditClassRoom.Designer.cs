namespace EduOne.Fr.Admins.Classrooms
{
    partial class fraEditClassRoom
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
            this.ckstatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtcapacity = new Krypton.Toolkit.KryptonNumericUpDown();
            this.txtbatim = new DevExpress.XtraEditors.TextEdit();
            this.txtnumerochambre = new DevExpress.XtraEditors.TextEdit();
            this.txtnotes = new DevExpress.XtraRichEdit.RichEditControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbatim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumerochambre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(183, 633);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(150, 29);
            this.btnclose.TabIndex = 25;
            this.btnclose.Text = "Fermer";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(27, 633);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(150, 29);
            this.btnadd.TabIndex = 24;
            this.btnadd.Text = "Mettre A Jour";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // ckstatus
            // 
            this.ckstatus.Location = new System.Drawing.Point(575, 87);
            this.ckstatus.Name = "ckstatus";
            this.ckstatus.Properties.Caption = "";
            this.ckstatus.Size = new System.Drawing.Size(94, 19);
            this.ckstatus.TabIndex = 23;
            // 
            // txtcapacity
            // 
            this.txtcapacity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtcapacity.InputControlStyle = Krypton.Toolkit.InputControlStyle.Custom3;
            this.txtcapacity.Location = new System.Drawing.Point(149, 89);
            this.txtcapacity.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtcapacity.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtcapacity.Name = "txtcapacity";
            this.txtcapacity.Size = new System.Drawing.Size(301, 26);
            this.txtcapacity.TabIndex = 22;
            this.txtcapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtbatim
            // 
            this.txtbatim.Location = new System.Drawing.Point(575, 25);
            this.txtbatim.Name = "txtbatim";
            this.txtbatim.Size = new System.Drawing.Size(304, 22);
            this.txtbatim.TabIndex = 21;
            // 
            // txtnumerochambre
            // 
            this.txtnumerochambre.Location = new System.Drawing.Point(149, 25);
            this.txtnumerochambre.Name = "txtnumerochambre";
            this.txtnumerochambre.Size = new System.Drawing.Size(304, 22);
            this.txtnumerochambre.TabIndex = 20;
            // 
            // txtnotes
            // 
            this.txtnotes.Location = new System.Drawing.Point(27, 193);
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtnotes.Size = new System.Drawing.Size(852, 423);
            this.txtnotes.TabIndex = 19;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(23, 159);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 16);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "Notes";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(493, 89);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Statut";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 89);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 16);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Capacité";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(493, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 16);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Bâtiment";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 16);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Numéro Chambre";
            // 
            // fraEditClassRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 676);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.ckstatus);
            this.Controls.Add(this.txtcapacity);
            this.Controls.Add(this.txtbatim);
            this.Controls.Add(this.txtnumerochambre);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "fraEditClassRoom";
            this.Text = "Modifier La Salle";
            this.Load += new System.EventHandler(this.fraEditClassRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ckstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbatim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumerochambre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.CheckEdit ckstatus;
        private Krypton.Toolkit.KryptonNumericUpDown txtcapacity;
        private DevExpress.XtraEditors.TextEdit txtbatim;
        private DevExpress.XtraEditors.TextEdit txtnumerochambre;
        private DevExpress.XtraRichEdit.RichEditControl txtnotes;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}