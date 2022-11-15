namespace mKYS.Musteri
{
    partial class GorusmeEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GorusmeEkle));
            this.txt_yetkili = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.combo_tur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_iletisim = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_konu = new DevExpress.XtraEditors.TextEdit();
            this.txt_msj = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.txt_yetkili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_iletisim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_konu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_msj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_yetkili
            // 
            this.txt_yetkili.Location = new System.Drawing.Point(147, 82);
            this.txt_yetkili.Name = "txt_yetkili";
            this.txt_yetkili.Size = new System.Drawing.Size(136, 20);
            this.txt_yetkili.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tarih / Görüşme Türü:";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(147, 19);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(136, 20);
            this.dateEdit1.TabIndex = 1;
            // 
            // combo_tur
            // 
            this.combo_tur.Location = new System.Drawing.Point(289, 19);
            this.combo_tur.Name = "combo_tur";
            this.combo_tur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_tur.Properties.Items.AddRange(new object[] {
            "E-Mail",
            "Telefon",
            "Whatsapp",
            "Ziyaret"});
            this.combo_tur.Size = new System.Drawing.Size(149, 20);
            this.combo_tur.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(87, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Firma Adı:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(62, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Yetkili / İletişim:";
            // 
            // txt_iletisim
            // 
            this.txt_iletisim.Location = new System.Drawing.Point(289, 82);
            this.txt_iletisim.Name = "txt_iletisim";
            this.txt_iletisim.Size = new System.Drawing.Size(149, 20);
            this.txt_iletisim.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(108, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Konu:";
            // 
            // txt_konu
            // 
            this.txt_konu.Location = new System.Drawing.Point(147, 116);
            this.txt_konu.Name = "txt_konu";
            this.txt_konu.Size = new System.Drawing.Size(291, 20);
            this.txt_konu.TabIndex = 6;
            // 
            // txt_msj
            // 
            this.txt_msj.Location = new System.Drawing.Point(147, 153);
            this.txt_msj.Name = "txt_msj";
            this.txt_msj.Size = new System.Drawing.Size(291, 96);
            this.txt_msj.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(89, 157);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Açıklama:";
            // 
            // btn_save
            // 
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_save.ImageOptions.ImageToTextIndent = 15;
            this.btn_save.Location = new System.Drawing.Point(147, 271);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(291, 43);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Kaydet";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.EditValue = "[EditVals";
            this.gridLookUpEdit1.Location = new System.Drawing.Point(147, 51);
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit1.Properties.NullText = "Firma Seçiniz..";
            this.gridLookUpEdit1.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Size = new System.Drawing.Size(291, 20);
            this.gridLookUpEdit1.TabIndex = 3;
            this.gridLookUpEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit1_QueryPopUp);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // GorusmeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 339);
            this.Controls.Add(this.gridLookUpEdit1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_msj);
            this.Controls.Add(this.combo_tur);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_konu);
            this.Controls.Add(this.txt_iletisim);
            this.Controls.Add(this.txt_yetkili);
            this.Name = "GorusmeEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Müşteri Görüşme Kaydı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GorusmeEkle_FormClosing);
            this.Load += new System.EventHandler(this.GorusmeEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_yetkili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_iletisim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_konu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_msj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_yetkili;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit combo_tur;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_iletisim;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_konu;
        private DevExpress.XtraEditors.MemoEdit txt_msj;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}