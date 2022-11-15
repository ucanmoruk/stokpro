namespace mKYS.Duyuru
{
    partial class DuyuruYeni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuyuruYeni));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memo_mesaj = new DevExpress.XtraEditors.MemoEdit();
            this.btn_yayin = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Combo_alici = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_konu = new DevExpress.XtraEditors.TextEdit();
            this.popup = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.memo_mesaj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Combo_alici.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_konu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 94);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mesajınız:";
            // 
            // memo_mesaj
            // 
            this.memo_mesaj.Location = new System.Drawing.Point(87, 92);
            this.memo_mesaj.Name = "memo_mesaj";
            this.memo_mesaj.Size = new System.Drawing.Size(341, 69);
            this.memo_mesaj.TabIndex = 4;
            // 
            // btn_yayin
            // 
            this.btn_yayin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_yayin.Appearance.Options.UseFont = true;
            this.btn_yayin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_yayin.ImageOptions.Image")));
            this.btn_yayin.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_yayin.ImageOptions.ImageToTextIndent = 15;
            this.btn_yayin.Location = new System.Drawing.Point(276, 176);
            this.btn_yayin.Name = "btn_yayin";
            this.btn_yayin.Size = new System.Drawing.Size(151, 51);
            this.btn_yayin.TabIndex = 6;
            this.btn_yayin.Text = "Gönder";
            this.btn_yayin.Click += new System.EventHandler(this.btn_yayin_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(45, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Alıcılar:";
            // 
            // Combo_alici
            // 
            this.Combo_alici.Location = new System.Drawing.Point(86, 23);
            this.Combo_alici.Name = "Combo_alici";
            this.Combo_alici.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Combo_alici.Properties.Items.AddRange(new object[] {
            "Tüm personel",
            "Özel"});
            this.Combo_alici.Size = new System.Drawing.Size(341, 20);
            this.Combo_alici.TabIndex = 1;
            this.Combo_alici.SelectedIndexChanged += new System.EventHandler(this.Combo_alici_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(49, 58);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Konu:";
            // 
            // txt_konu
            // 
            this.txt_konu.Location = new System.Drawing.Point(87, 56);
            this.txt_konu.Name = "txt_konu";
            this.txt_konu.Size = new System.Drawing.Size(340, 20);
            this.txt_konu.TabIndex = 3;
            // 
            // popup
            // 
            this.popup.EditValue = "Personeller..";
            this.popup.Location = new System.Drawing.Point(246, 23);
            this.popup.Name = "popup";
            this.popup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popup.Properties.PopupControl = this.popupContainerControl1;
            this.popup.Size = new System.Drawing.Size(181, 20);
            this.popup.TabIndex = 2;
            this.popup.Visible = false;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.gridControl1);
            this.popupContainerControl1.Location = new System.Drawing.Point(12, 209);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(240, 136);
            this.popupContainerControl1.TabIndex = 7;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(240, 136);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(87, 176);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(165, 20);
            this.dateEdit1.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(45, 179);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Tarih:";
            // 
            // DuyuruYeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 287);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popup);
            this.Controls.Add(this.txt_konu);
            this.Controls.Add(this.Combo_alici);
            this.Controls.Add(this.btn_yayin);
            this.Controls.Add(this.memo_mesaj);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DuyuruYeni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Duyuru!";
            this.Load += new System.EventHandler(this.DuyuruYeni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memo_mesaj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Combo_alici.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_konu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memo_mesaj;
        private DevExpress.XtraEditors.SimpleButton btn_yayin;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit Combo_alici;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_konu;
        private DevExpress.XtraEditors.PopupContainerEdit popup;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}