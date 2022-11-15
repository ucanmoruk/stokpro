namespace mKYS.Musteri
{
    partial class ManuelProforma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManuelProforma));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.combo_firma = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btn_fatura = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txt_adres = new DevExpress.XtraEditors.TextEdit();
            this.txt_mail = new DevExpress.XtraEditors.TextEdit();
            this.txt_firma = new DevExpress.XtraEditors.TextEdit();
            this.txt_vergino = new DevExpress.XtraEditors.TextEdit();
            this.txt_evrak = new DevExpress.XtraEditors.TextEdit();
            this.txt_vdaire = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combo_firma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_adres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_firma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_vergino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_evrak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_vdaire.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView1_CustomSummaryCalculate);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(615, 346);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 352);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 191);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(625, 356);
            this.panelControl1.TabIndex = 5;
            // 
            // combo_firma
            // 
            this.combo_firma.Location = new System.Drawing.Point(149, 90);
            this.combo_firma.Name = "combo_firma";
            this.combo_firma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_firma.Size = new System.Drawing.Size(439, 20);
            this.combo_firma.TabIndex = 3;
            this.combo_firma.SelectedIndexChanged += new System.EventHandler(this.combo_firma_SelectedIndexChanged);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(249, 145);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(44, 13);
            this.labelControl10.TabIndex = 34;
            this.labelControl10.Text = "Vergi No:";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(80, 145);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(63, 13);
            this.labelControl12.TabIndex = 35;
            this.labelControl12.Text = "Vergi Dairesi:";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(110, 119);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(32, 13);
            this.labelControl13.TabIndex = 36;
            this.labelControl13.Text = "Adres:";
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(26, 93);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(117, 13);
            this.labelControl14.TabIndex = 37;
            this.labelControl14.Text = "Faturalandırılacak Firma:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btn_fatura);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 547);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(625, 127);
            this.groupControl2.TabIndex = 4;
            // 
            // btn_fatura
            // 
            this.btn_fatura.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btn_fatura.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_fatura.Appearance.Options.UseBorderColor = true;
            this.btn_fatura.Appearance.Options.UseFont = true;
            this.btn_fatura.Appearance.Options.UseTextOptions = true;
            this.btn_fatura.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_fatura.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_fatura.ImageOptions.Image")));
            this.btn_fatura.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_fatura.ImageOptions.ImageToTextIndent = 10;
            this.btn_fatura.Location = new System.Drawing.Point(404, 47);
            this.btn_fatura.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btn_fatura.Name = "btn_fatura";
            this.btn_fatura.Size = new System.Drawing.Size(187, 61);
            this.btn_fatura.TabIndex = 9;
            this.btn_fatura.Text = "Proforma Oluştur";
            this.btn_fatura.Click += new System.EventHandler(this.btn_fatura_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.separatorControl1);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.txt_adres);
            this.groupControl1.Controls.Add(this.txt_mail);
            this.groupControl1.Controls.Add(this.txt_firma);
            this.groupControl1.Controls.Add(this.txt_vergino);
            this.groupControl1.Controls.Add(this.txt_evrak);
            this.groupControl1.Controls.Add(this.txt_vdaire);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.combo_firma);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.labelControl14);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(625, 191);
            this.groupControl1.TabIndex = 3;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(152, 61);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(439, 23);
            this.separatorControl1.TabIndex = 44;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(59, 37);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(83, 13);
            this.labelControl8.TabIndex = 43;
            this.labelControl8.Text = "Evrak No / Firma:";
            // 
            // txt_adres
            // 
            this.txt_adres.Location = new System.Drawing.Point(149, 116);
            this.txt_adres.Name = "txt_adres";
            this.txt_adres.Size = new System.Drawing.Size(439, 20);
            this.txt_adres.TabIndex = 4;
            // 
            // txt_mail
            // 
            this.txt_mail.Location = new System.Drawing.Point(432, 142);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(156, 20);
            this.txt_mail.TabIndex = 7;
            // 
            // txt_firma
            // 
            this.txt_firma.Location = new System.Drawing.Point(249, 34);
            this.txt_firma.Name = "txt_firma";
            this.txt_firma.Size = new System.Drawing.Size(339, 20);
            this.txt_firma.TabIndex = 2;
            // 
            // txt_vergino
            // 
            this.txt_vergino.Location = new System.Drawing.Point(299, 142);
            this.txt_vergino.Name = "txt_vergino";
            this.txt_vergino.Size = new System.Drawing.Size(86, 20);
            this.txt_vergino.TabIndex = 6;
            // 
            // txt_evrak
            // 
            this.txt_evrak.Location = new System.Drawing.Point(149, 34);
            this.txt_evrak.Name = "txt_evrak";
            this.txt_evrak.Size = new System.Drawing.Size(92, 20);
            this.txt_evrak.TabIndex = 1;
            // 
            // txt_vdaire
            // 
            this.txt_vdaire.Location = new System.Drawing.Point(150, 142);
            this.txt_vdaire.Name = "txt_vdaire";
            this.txt_vdaire.Size = new System.Drawing.Size(91, 20);
            this.txt_vdaire.TabIndex = 5;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(404, 145);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(22, 13);
            this.labelControl11.TabIndex = 33;
            this.labelControl11.Text = "Mail:";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // ManuelProforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 674);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "ManuelProforma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManuelProforma";
            this.Load += new System.EventHandler(this.ManuelProforma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.combo_firma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_adres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_firma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_vergino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_evrak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_vdaire.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit combo_firma;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btn_fatura;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txt_adres;
        private DevExpress.XtraEditors.TextEdit txt_mail;
        private DevExpress.XtraEditors.TextEdit txt_firma;
        private DevExpress.XtraEditors.TextEdit txt_vergino;
        private DevExpress.XtraEditors.TextEdit txt_evrak;
        private DevExpress.XtraEditors.TextEdit txt_vdaire;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}