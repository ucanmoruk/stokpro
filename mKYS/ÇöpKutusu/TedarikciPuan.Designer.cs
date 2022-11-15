namespace mKYS.Talep
{
    partial class TedarikciPuan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TedarikciPuan));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_firma = new DevExpress.XtraEditors.TextEdit();
            this.txt_puan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.combo_deger = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            this.txt_aciklama = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_firma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_puan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_deger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Firma Adı:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(55, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Puan:";
            // 
            // txt_firma
            // 
            this.txt_firma.Location = new System.Drawing.Point(93, 26);
            this.txt_firma.Name = "txt_firma";
            this.txt_firma.Size = new System.Drawing.Size(367, 20);
            this.txt_firma.TabIndex = 1;
            // 
            // txt_puan
            // 
            this.txt_puan.Location = new System.Drawing.Point(93, 61);
            this.txt_puan.Name = "txt_puan";
            this.txt_puan.Size = new System.Drawing.Size(123, 20);
            this.txt_puan.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(239, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Değerlendirme:";
            // 
            // combo_deger
            // 
            this.combo_deger.Location = new System.Drawing.Point(318, 61);
            this.combo_deger.Name = "combo_deger";
            this.combo_deger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_deger.Properties.Items.AddRange(new object[] {
            "Uygun",
            "Uygun Değil",
            "Değerlendirme Yapılmadı"});
            this.combo_deger.Size = new System.Drawing.Size(142, 20);
            this.combo_deger.TabIndex = 3;
            // 
            // btn_ok
            // 
            this.btn_ok.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_ok.Appearance.Options.UseFont = true;
            this.btn_ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.ImageOptions.Image")));
            this.btn_ok.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ok.ImageOptions.ImageToTextIndent = 15;
            this.btn_ok.Location = new System.Drawing.Point(93, 128);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(367, 43);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "Değerlendir";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_aciklama
            // 
            this.txt_aciklama.Location = new System.Drawing.Point(93, 95);
            this.txt_aciklama.Name = "txt_aciklama";
            this.txt_aciklama.Size = new System.Drawing.Size(367, 20);
            this.txt_aciklama.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(38, 98);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Açıklama:";
            // 
            // TedarikciPuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 196);
            this.Controls.Add(this.txt_aciklama);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.combo_deger);
            this.Controls.Add(this.txt_puan);
            this.Controls.Add(this.txt_firma);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "TedarikciPuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tedarikçi Puan Ekleme";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TedarikciPuan_FormClosed);
            this.Load += new System.EventHandler(this.TedarikciPuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_firma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_puan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_deger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_firma;
        private DevExpress.XtraEditors.TextEdit txt_puan;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit combo_deger;
        private DevExpress.XtraEditors.SimpleButton btn_ok;
        private DevExpress.XtraEditors.TextEdit txt_aciklama;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}