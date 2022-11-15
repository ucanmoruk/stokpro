namespace mKYS.Musteri
{
    partial class FaturaGuncelle
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
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.txtFaturaNo = new DevExpress.XtraEditors.TextEdit();
            this.txtRaporNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txt_aciklama = new DevExpress.XtraEditors.TextEdit();
            this.txtKDV = new DevExpress.XtraEditors.TextEdit();
            this.txtToplam = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_proje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_faturafirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_raporfirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaporNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(270, 175);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(328, 29);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Güncelle";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // combo_proje
            // 
            this.combo_proje.Location = new System.Drawing.Point(270, 78);
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
            this.dateEdit1.Location = new System.Drawing.Point(477, 106);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Size = new System.Drawing.Size(121, 20);
            this.dateEdit1.TabIndex = 6;
            // 
            // combo_faturafirma
            // 
            this.combo_faturafirma.Location = new System.Drawing.Point(269, 50);
            this.combo_faturafirma.Name = "combo_faturafirma";
            this.combo_faturafirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_faturafirma.Size = new System.Drawing.Size(329, 20);
            this.combo_faturafirma.TabIndex = 3;
            // 
            // combo_raporfirma
            // 
            this.combo_raporfirma.Location = new System.Drawing.Point(269, 21);
            this.combo_raporfirma.Name = "combo_raporfirma";
            this.combo_raporfirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_raporfirma.Properties.ReadOnly = true;
            this.combo_raporfirma.Size = new System.Drawing.Size(329, 20);
            this.combo_raporfirma.TabIndex = 2;
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(270, 136);
            this.txtTutar.Margin = new System.Windows.Forms.Padding(2);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(92, 20);
            this.txtTutar.TabIndex = 7;
            this.txtTutar.EditValueChanged += new System.EventHandler(this.txtTutar_EditValueChanged);
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Location = new System.Drawing.Point(270, 106);
            this.txtFaturaNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(130, 20);
            this.txtFaturaNo.TabIndex = 5;
            // 
            // txtRaporNo
            // 
            this.txtRaporNo.Location = new System.Drawing.Point(79, 23);
            this.txtRaporNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtRaporNo.Name = "txtRaporNo";
            this.txtRaporNo.Properties.ReadOnly = true;
            this.txtRaporNo.Size = new System.Drawing.Size(47, 20);
            this.txtRaporNo.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(489, 139);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Toplam:";
            // 
            // labelControl3
            // 
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(372, 139);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 13);
            this.labelControl3.TabIndex = 22;
            this.labelControl3.Text = "KDV:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(224, 139);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Tutar:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(142, 53);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(117, 13);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "Faturalandırılacak Firma:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(144, 24);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(114, 13);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "Raporlandırılacak Firma:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(23, 26);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 13);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "Evrak No:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(430, 109);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(28, 13);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Tarih:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(223, 80);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(29, 13);
            this.labelControl9.TabIndex = 20;
            this.labelControl9.Text = "Proje:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(206, 108);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Fatura No:";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(413, 81);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(45, 13);
            this.labelControl10.TabIndex = 20;
            this.labelControl10.Text = "Açıklama:";
            // 
            // txt_aciklama
            // 
            this.txt_aciklama.Location = new System.Drawing.Point(477, 78);
            this.txt_aciklama.Name = "txt_aciklama";
            this.txt_aciklama.Size = new System.Drawing.Size(121, 20);
            this.txt_aciklama.TabIndex = 23;
            // 
            // txtKDV
            // 
            this.txtKDV.Location = new System.Drawing.Point(405, 136);
            this.txtKDV.Name = "txtKDV";
            this.txtKDV.Size = new System.Drawing.Size(69, 20);
            this.txtKDV.TabIndex = 8;
            // 
            // txtToplam
            // 
            this.txtToplam.Location = new System.Drawing.Point(534, 136);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.Size = new System.Drawing.Size(64, 20);
            this.txtToplam.TabIndex = 9;
            // 
            // FaturaGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 224);
            this.Controls.Add(this.txtToplam);
            this.Controls.Add(this.txtKDV);
            this.Controls.Add(this.txt_aciklama);
            this.Controls.Add(this.combo_proje);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.combo_faturafirma);
            this.Controls.Add(this.combo_raporfirma);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.txtFaturaNo);
            this.Controls.Add(this.txtRaporNo);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnKaydet);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FaturaGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatura Güncelle";
            this.Load += new System.EventHandler(this.FaturaGuncelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combo_proje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_faturafirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_raporfirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaporNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.ComboBoxEdit combo_proje;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit combo_faturafirma;
        private DevExpress.XtraEditors.ComboBoxEdit combo_raporfirma;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.TextEdit txtFaturaNo;
        private DevExpress.XtraEditors.TextEdit txtRaporNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txt_aciklama;
        private DevExpress.XtraEditors.TextEdit txtKDV;
        private DevExpress.XtraEditors.TextEdit txtToplam;
    }
}