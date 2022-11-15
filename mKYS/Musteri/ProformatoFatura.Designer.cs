namespace mKYS.Musteri
{
    partial class ProformatoFatura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProformatoFatura));
            this.combo_proje = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.combo_faturafirma = new DevExpress.XtraEditors.ComboBoxEdit();
            this.combo_raporfirma = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtToplam = new DevExpress.XtraEditors.TextEdit();
            this.txtKDV = new DevExpress.XtraEditors.TextEdit();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.txtFaturaNo = new DevExpress.XtraEditors.TextEdit();
            this.txtRaporNo = new DevExpress.XtraEditors.TextEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.combo_proje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_faturafirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_raporfirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaporNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_proje
            // 
            this.combo_proje.Location = new System.Drawing.Point(263, 80);
            this.combo_proje.Margin = new System.Windows.Forms.Padding(2);
            this.combo_proje.Name = "combo_proje";
            this.combo_proje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_proje.Size = new System.Drawing.Size(328, 20);
            this.combo_proje.TabIndex = 24;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(470, 108);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Size = new System.Drawing.Size(121, 20);
            this.dateEdit1.TabIndex = 26;
            // 
            // combo_faturafirma
            // 
            this.combo_faturafirma.Location = new System.Drawing.Point(262, 52);
            this.combo_faturafirma.Name = "combo_faturafirma";
            this.combo_faturafirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_faturafirma.Size = new System.Drawing.Size(329, 20);
            this.combo_faturafirma.TabIndex = 23;
            // 
            // combo_raporfirma
            // 
            this.combo_raporfirma.Location = new System.Drawing.Point(262, 23);
            this.combo_raporfirma.Name = "combo_raporfirma";
            this.combo_raporfirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_raporfirma.Size = new System.Drawing.Size(329, 20);
            this.combo_raporfirma.TabIndex = 22;
            // 
            // txtToplam
            // 
            this.txtToplam.Location = new System.Drawing.Point(527, 138);
            this.txtToplam.Margin = new System.Windows.Forms.Padding(2);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.Properties.ReadOnly = true;
            this.txtToplam.Size = new System.Drawing.Size(64, 20);
            this.txtToplam.TabIndex = 29;
            // 
            // txtKDV
            // 
            this.txtKDV.Location = new System.Drawing.Point(398, 138);
            this.txtKDV.Margin = new System.Windows.Forms.Padding(2);
            this.txtKDV.Name = "txtKDV";
            this.txtKDV.Properties.ReadOnly = true;
            this.txtKDV.Size = new System.Drawing.Size(69, 20);
            this.txtKDV.TabIndex = 28;
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(263, 138);
            this.txtTutar.Margin = new System.Windows.Forms.Padding(2);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(92, 20);
            this.txtTutar.TabIndex = 27;
            this.txtTutar.TextChanged += new System.EventHandler(this.txtTutar_TextChanged);
            this.txtTutar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTutar_KeyPress);
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Location = new System.Drawing.Point(263, 108);
            this.txtFaturaNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(130, 20);
            this.txtFaturaNo.TabIndex = 25;
            // 
            // txtRaporNo
            // 
            this.txtRaporNo.Location = new System.Drawing.Point(72, 25);
            this.txtRaporNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtRaporNo.Name = "txtRaporNo";
            this.txtRaporNo.Properties.ReadOnly = true;
            this.txtRaporNo.Size = new System.Drawing.Size(47, 20);
            this.txtRaporNo.TabIndex = 21;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnKaydet.ImageOptions.ImageToTextIndent = 15;
            this.btnKaydet.Location = new System.Drawing.Point(261, 174);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(329, 39);
            this.btnKaydet.TabIndex = 30;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(482, 141);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Toplam:";
            // 
            // labelControl3
            // 
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(365, 141);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 13);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "KDV:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(217, 141);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 13);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "Tutar:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(135, 55);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(117, 13);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "Faturalandırılacak Firma:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(137, 26);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(114, 13);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "Raporlandırılacak Firma:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 28);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Evrak No:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(423, 111);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(28, 13);
            this.labelControl8.TabIndex = 13;
            this.labelControl8.Text = "Tarih:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(216, 82);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(29, 13);
            this.labelControl9.TabIndex = 20;
            this.labelControl9.Text = "Proje:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(199, 110);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Fatura No:";
            // 
            // ProformatoFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 234);
            this.Controls.Add(this.combo_proje);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.combo_faturafirma);
            this.Controls.Add(this.combo_raporfirma);
            this.Controls.Add(this.txtToplam);
            this.Controls.Add(this.txtKDV);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.txtFaturaNo);
            this.Controls.Add(this.txtRaporNo);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl1);
            this.Name = "ProformatoFatura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proforma Faturalandır";
            this.Load += new System.EventHandler(this.ProformatoFatura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combo_proje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_faturafirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_raporfirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaporNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.ComboBoxEdit combo_proje;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit combo_faturafirma;
        private DevExpress.XtraEditors.ComboBoxEdit combo_raporfirma;
        private DevExpress.XtraEditors.TextEdit txtToplam;
        private DevExpress.XtraEditors.TextEdit txtKDV;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.TextEdit txtFaturaNo;
        private DevExpress.XtraEditors.TextEdit txtRaporNo;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}