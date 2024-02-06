namespace mKYS
{
    partial class YeniStok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniStok));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.combo_tur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtkod = new DevExpress.XtraEditors.TextEdit();
            this.txtad = new DevExpress.XtraEditors.TextEdit();
            this.txtenad = new DevExpress.XtraEditors.TextEdit();
            this.txtcas = new DevExpress.XtraEditors.TextEdit();
            this.txtambalaj = new DevExpress.XtraEditors.TextEdit();
            this.txtozellik = new DevExpress.XtraEditors.TextEdit();
            this.txtsaklama = new DevExpress.XtraEditors.TextEdit();
            this.txtlimit = new DevExpress.XtraEditors.TextEdit();
            this.combobirim = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtenad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtambalaj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtozellik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsaklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlimit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combobirim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(59, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tür / Kod: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(57, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Türkçe Ad:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(52, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "İngilizce Ad:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(71, 121);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Cas No:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(68, 149);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Ambalaj:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(76, 178);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(34, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Özellik:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(33, 208);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(77, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Saklama Koşulu:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(27, 238);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(83, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Kritik Limit / Birim:";
            // 
            // combo_tur
            // 
            this.combo_tur.Location = new System.Drawing.Point(121, 24);
            this.combo_tur.Name = "combo_tur";
            this.combo_tur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_tur.Properties.Items.AddRange(new object[] {
            "Katı",
            "Sıvı",
            "Standart",
            "Sarf",
            "QC",
            "CRM",
            "Hizmet",
            "Kırtasiye",
            "Cihaz Sarf",
            "Besiyeri",
            "Kültür"});
            this.combo_tur.Size = new System.Drawing.Size(118, 20);
            this.combo_tur.TabIndex = 1;
            // 
            // txtkod
            // 
            this.txtkod.Location = new System.Drawing.Point(245, 24);
            this.txtkod.Name = "txtkod";
            this.txtkod.Size = new System.Drawing.Size(102, 20);
            this.txtkod.TabIndex = 2;
            // 
            // txtad
            // 
            this.txtad.Location = new System.Drawing.Point(121, 57);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(226, 20);
            this.txtad.TabIndex = 3;
            // 
            // txtenad
            // 
            this.txtenad.Location = new System.Drawing.Point(121, 87);
            this.txtenad.Name = "txtenad";
            this.txtenad.Size = new System.Drawing.Size(226, 20);
            this.txtenad.TabIndex = 4;
            // 
            // txtcas
            // 
            this.txtcas.Location = new System.Drawing.Point(121, 118);
            this.txtcas.Name = "txtcas";
            this.txtcas.Size = new System.Drawing.Size(226, 20);
            this.txtcas.TabIndex = 5;
            // 
            // txtambalaj
            // 
            this.txtambalaj.Location = new System.Drawing.Point(121, 147);
            this.txtambalaj.Name = "txtambalaj";
            this.txtambalaj.Size = new System.Drawing.Size(226, 20);
            this.txtambalaj.TabIndex = 6;
            // 
            // txtozellik
            // 
            this.txtozellik.Location = new System.Drawing.Point(121, 176);
            this.txtozellik.Name = "txtozellik";
            this.txtozellik.Size = new System.Drawing.Size(226, 20);
            this.txtozellik.TabIndex = 7;
            // 
            // txtsaklama
            // 
            this.txtsaklama.Location = new System.Drawing.Point(121, 205);
            this.txtsaklama.Name = "txtsaklama";
            this.txtsaklama.Size = new System.Drawing.Size(226, 20);
            this.txtsaklama.TabIndex = 8;
            // 
            // txtlimit
            // 
            this.txtlimit.Location = new System.Drawing.Point(121, 235);
            this.txtlimit.Name = "txtlimit";
            this.txtlimit.Size = new System.Drawing.Size(136, 20);
            this.txtlimit.TabIndex = 9;
            // 
            // combobirim
            // 
            this.combobirim.Location = new System.Drawing.Point(263, 235);
            this.combobirim.Name = "combobirim";
            this.combobirim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combobirim.Properties.Items.AddRange(new object[] {
            "Adet",
            "ml",
            "mg",
            "g",
            "L",
            "Kutu",
            "Paket"});
            this.combobirim.Size = new System.Drawing.Size(84, 20);
            this.combobirim.TabIndex = 10;
            // 
            // btnadd
            // 
            this.btnadd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnadd.Appearance.Options.UseFont = true;
            this.btnadd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.ImageOptions.Image")));
            this.btnadd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnadd.ImageOptions.ImageToTextIndent = 10;
            this.btnadd.Location = new System.Drawing.Point(121, 276);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(226, 34);
            this.btnadd.TabIndex = 11;
            this.btnadd.Text = "Yeni Stok Oluştur";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // YeniStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 338);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtlimit);
            this.Controls.Add(this.txtsaklama);
            this.Controls.Add(this.txtozellik);
            this.Controls.Add(this.txtambalaj);
            this.Controls.Add(this.txtcas);
            this.Controls.Add(this.txtenad);
            this.Controls.Add(this.txtad);
            this.Controls.Add(this.txtkod);
            this.Controls.Add(this.combobirim);
            this.Controls.Add(this.combo_tur);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "YeniStok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Stok Kartı";
            this.Load += new System.EventHandler(this.YeniStok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combo_tur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtenad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtambalaj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtozellik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsaklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlimit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combobirim.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit combo_tur;
        private DevExpress.XtraEditors.TextEdit txtkod;
        private DevExpress.XtraEditors.TextEdit txtad;
        private DevExpress.XtraEditors.TextEdit txtenad;
        private DevExpress.XtraEditors.TextEdit txtcas;
        private DevExpress.XtraEditors.TextEdit txtambalaj;
        private DevExpress.XtraEditors.TextEdit txtozellik;
        private DevExpress.XtraEditors.TextEdit txtsaklama;
        private DevExpress.XtraEditors.TextEdit txtlimit;
        private DevExpress.XtraEditors.ComboBoxEdit combobirim;
        private DevExpress.XtraEditors.SimpleButton btnadd;
    }
}