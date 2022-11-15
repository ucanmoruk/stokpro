namespace mKYS.Musteri
{
    partial class FaturaKaydet
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtRaporNo = new DevExpress.XtraEditors.TextEdit();
            this.txtFaturaNo = new DevExpress.XtraEditors.TextEdit();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.combo_raporfirma = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.combo_faturafirma = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.combo_proje = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtKDV = new DevExpress.XtraEditors.TextEdit();
            this.txtToplam = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaporNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_raporfirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_faturafirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_proje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(207, 105);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fatura No:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(225, 136);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tutar:";
            // 
            // labelControl3
            // 
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(373, 136);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "KDV:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(490, 136);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Toplam:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(269, 169);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(329, 32);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtRaporNo
            // 
            this.txtRaporNo.Location = new System.Drawing.Point(80, 20);
            this.txtRaporNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtRaporNo.Name = "txtRaporNo";
            this.txtRaporNo.Properties.ReadOnly = true;
            this.txtRaporNo.Size = new System.Drawing.Size(47, 20);
            this.txtRaporNo.TabIndex = 1;
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Location = new System.Drawing.Point(271, 103);
            this.txtFaturaNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(130, 20);
            this.txtFaturaNo.TabIndex = 5;
            this.txtFaturaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFaturaNo_KeyPress);
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(271, 133);
            this.txtTutar.Margin = new System.Windows.Forms.Padding(2);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(92, 20);
            this.txtTutar.TabIndex = 7;
            this.txtTutar.TextChanged += new System.EventHandler(this.txtTutar_TextChanged);
            this.txtTutar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTutar_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(24, 23);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Evrak No:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(145, 21);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(114, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Raporlandırılacak Firma:";
            // 
            // combo_raporfirma
            // 
            this.combo_raporfirma.Location = new System.Drawing.Point(270, 18);
            this.combo_raporfirma.Name = "combo_raporfirma";
            this.combo_raporfirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_raporfirma.Size = new System.Drawing.Size(329, 20);
            this.combo_raporfirma.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(143, 50);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(117, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Faturalandırılacak Firma:";
            // 
            // combo_faturafirma
            // 
            this.combo_faturafirma.Location = new System.Drawing.Point(270, 47);
            this.combo_faturafirma.Name = "combo_faturafirma";
            this.combo_faturafirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_faturafirma.Size = new System.Drawing.Size(329, 20);
            this.combo_faturafirma.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(431, 106);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(28, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Tarih:";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(478, 103);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Size = new System.Drawing.Size(121, 20);
            this.dateEdit1.TabIndex = 6;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(227, 77);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(29, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Proje:";
            // 
            // combo_proje
            // 
            this.combo_proje.Location = new System.Drawing.Point(271, 75);
            this.combo_proje.Margin = new System.Windows.Forms.Padding(2);
            this.combo_proje.Name = "combo_proje";
            this.combo_proje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_proje.Size = new System.Drawing.Size(328, 20);
            this.combo_proje.TabIndex = 4;
            // 
            // txtKDV
            // 
            this.txtKDV.Location = new System.Drawing.Point(403, 133);
            this.txtKDV.Name = "txtKDV";
            this.txtKDV.Size = new System.Drawing.Size(69, 20);
            this.txtKDV.TabIndex = 8;
            // 
            // txtToplam
            // 
            this.txtToplam.Location = new System.Drawing.Point(533, 133);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.Size = new System.Drawing.Size(66, 20);
            this.txtToplam.TabIndex = 9;
            // 
            // FaturaKaydet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 222);
            this.Controls.Add(this.txtToplam);
            this.Controls.Add(this.txtKDV);
            this.Controls.Add(this.combo_proje);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.combo_faturafirma);
            this.Controls.Add(this.combo_raporfirma);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FaturaKaydet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatura Kaydet";
            this.Load += new System.EventHandler(this.FaturaGuncelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtRaporNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_raporfirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_faturafirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_proje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.TextEdit txtRaporNo;
        private DevExpress.XtraEditors.TextEdit txtFaturaNo;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit combo_raporfirma;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit combo_faturafirma;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit combo_proje;
        private DevExpress.XtraEditors.TextEdit txtKDV;
        private DevExpress.XtraEditors.TextEdit txtToplam;
    }
}