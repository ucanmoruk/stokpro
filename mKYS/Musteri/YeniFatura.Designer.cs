namespace mKYS.Musteri
{
    partial class YeniFatura
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
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.combo_proje = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.combo_faturafirma = new DevExpress.XtraEditors.ComboBoxEdit();
            this.combo_raporfirma = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtToplam = new DevExpress.XtraEditors.TextEdit();
            this.txtKDV = new DevExpress.XtraEditors.TextEdit();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.txt_faturano = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.combo_evrak = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_aciklama = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_proje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_faturafirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_raporfirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_faturano.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_evrak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(256, 172);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(329, 24);
            this.btnKaydet.TabIndex = 11;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // combo_proje
            // 
            this.combo_proje.Location = new System.Drawing.Point(257, 78);
            this.combo_proje.Margin = new System.Windows.Forms.Padding(2);
            this.combo_proje.Name = "combo_proje";
            this.combo_proje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_proje.Size = new System.Drawing.Size(130, 20);
            this.combo_proje.TabIndex = 4;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(464, 106);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Properties.MaxValue = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            this.dateEdit1.Size = new System.Drawing.Size(121, 20);
            this.dateEdit1.TabIndex = 7;
            // 
            // combo_faturafirma
            // 
            this.combo_faturafirma.Location = new System.Drawing.Point(256, 50);
            this.combo_faturafirma.Name = "combo_faturafirma";
            this.combo_faturafirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_faturafirma.Size = new System.Drawing.Size(329, 20);
            this.combo_faturafirma.TabIndex = 3;
            // 
            // combo_raporfirma
            // 
            this.combo_raporfirma.Location = new System.Drawing.Point(256, 21);
            this.combo_raporfirma.Name = "combo_raporfirma";
            this.combo_raporfirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_raporfirma.Properties.ReadOnly = true;
            this.combo_raporfirma.Size = new System.Drawing.Size(329, 20);
            this.combo_raporfirma.TabIndex = 2;
            // 
            // txtToplam
            // 
            this.txtToplam.Location = new System.Drawing.Point(521, 136);
            this.txtToplam.Margin = new System.Windows.Forms.Padding(2);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.Properties.ReadOnly = true;
            this.txtToplam.Size = new System.Drawing.Size(64, 20);
            this.txtToplam.TabIndex = 10;
            // 
            // txtKDV
            // 
            this.txtKDV.Location = new System.Drawing.Point(392, 136);
            this.txtKDV.Margin = new System.Windows.Forms.Padding(2);
            this.txtKDV.Name = "txtKDV";
            this.txtKDV.Properties.ReadOnly = true;
            this.txtKDV.Size = new System.Drawing.Size(69, 20);
            this.txtKDV.TabIndex = 9;
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(257, 136);
            this.txtTutar.Margin = new System.Windows.Forms.Padding(2);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(92, 20);
            this.txtTutar.TabIndex = 8;
            this.txtTutar.TextChanged += new System.EventHandler(this.txtTutar_TextChanged_1);
            this.txtTutar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTutar_KeyPress_1);
            // 
            // txt_faturano
            // 
            this.txt_faturano.Location = new System.Drawing.Point(257, 106);
            this.txt_faturano.Margin = new System.Windows.Forms.Padding(2);
            this.txt_faturano.Name = "txt_faturano";
            this.txt_faturano.Size = new System.Drawing.Size(130, 20);
            this.txt_faturano.TabIndex = 6;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(476, 139);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(38, 13);
            this.labelControl6.TabIndex = 27;
            this.labelControl6.Text = "Toplam:";
            // 
            // labelControl7
            // 
            this.labelControl7.LineVisible = true;
            this.labelControl7.Location = new System.Drawing.Point(359, 139);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(23, 13);
            this.labelControl7.TabIndex = 28;
            this.labelControl7.Text = "KDV:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(213, 139);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(30, 13);
            this.labelControl8.TabIndex = 25;
            this.labelControl8.Text = "Tutar:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(129, 53);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(117, 13);
            this.labelControl9.TabIndex = 24;
            this.labelControl9.Text = "Faturalandırılacak Firma:";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(131, 24);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(114, 13);
            this.labelControl10.TabIndex = 23;
            this.labelControl10.Text = "Raporlandırılacak Firma:";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(10, 23);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(47, 13);
            this.labelControl11.TabIndex = 22;
            this.labelControl11.Text = "Evrak No:";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(420, 109);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(28, 13);
            this.labelControl12.TabIndex = 21;
            this.labelControl12.Text = "Tarih:";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(215, 80);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(29, 13);
            this.labelControl13.TabIndex = 26;
            this.labelControl13.Text = "Proje:";
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(193, 108);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(52, 13);
            this.labelControl14.TabIndex = 20;
            this.labelControl14.Text = "Fatura No:";
            // 
            // combo_evrak
            // 
            this.combo_evrak.EditValue = "20000";
            this.combo_evrak.Location = new System.Drawing.Point(62, 20);
            this.combo_evrak.Name = "combo_evrak";
            this.combo_evrak.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_evrak.Size = new System.Drawing.Size(49, 20);
            this.combo_evrak.TabIndex = 1;
            this.combo_evrak.TextChanged += new System.EventHandler(this.combo_evrak_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(409, 80);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "Açıklama:";
            // 
            // txt_aciklama
            // 
            this.txt_aciklama.Location = new System.Drawing.Point(464, 77);
            this.txt_aciklama.Name = "txt_aciklama";
            this.txt_aciklama.Size = new System.Drawing.Size(121, 20);
            this.txt_aciklama.TabIndex = 5;
            // 
            // YeniFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 214);
            this.Controls.Add(this.txt_aciklama);
            this.Controls.Add(this.combo_evrak);
            this.Controls.Add(this.combo_proje);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.combo_faturafirma);
            this.Controls.Add(this.combo_raporfirma);
            this.Controls.Add(this.txtToplam);
            this.Controls.Add(this.txtKDV);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.txt_faturano);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.btnKaydet);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "YeniFatura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YeniFatura";
            this.Load += new System.EventHandler(this.YeniFatura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combo_proje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_faturafirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_raporfirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_faturano.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_evrak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.ComboBoxEdit combo_proje;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit combo_faturafirma;
        private DevExpress.XtraEditors.ComboBoxEdit combo_raporfirma;
        private DevExpress.XtraEditors.TextEdit txtToplam;
        private DevExpress.XtraEditors.TextEdit txtKDV;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.TextEdit txt_faturano;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.ComboBoxEdit combo_evrak;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_aciklama;
    }
}