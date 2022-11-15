namespace mKYS.Numune
{
    partial class Aciklama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aciklama));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_rapor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_aciklama = new System.Windows.Forms.RichTextBox();
            this.txt_revsebep = new System.Windows.Forms.RichTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_rev = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rapor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rev.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(109, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Rapor No:";
            // 
            // txt_rapor
            // 
            this.txt_rapor.Location = new System.Drawing.Point(173, 20);
            this.txt_rapor.Name = "txt_rapor";
            this.txt_rapor.Size = new System.Drawing.Size(100, 20);
            this.txt_rapor.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(49, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Açıklama:";
            // 
            // txt_aciklama
            // 
            this.txt_aciklama.Location = new System.Drawing.Point(109, 52);
            this.txt_aciklama.Name = "txt_aciklama";
            this.txt_aciklama.Size = new System.Drawing.Size(383, 67);
            this.txt_aciklama.TabIndex = 2;
            this.txt_aciklama.Text = "Bu rapordaki test değerlendirmeleri, “Kimyasalların Kaydı, Değerlendirilmesi, İzn" +
    "i ve Kısıtlanması Hakkında Yönetmelik” ve standartlar ile yürürlükte olan diğer " +
    "ilgili mevzuata göre yapılmıştır.";
            // 
            // txt_revsebep
            // 
            this.txt_revsebep.Location = new System.Drawing.Point(109, 136);
            this.txt_revsebep.Name = "txt_revsebep";
            this.txt_revsebep.Size = new System.Drawing.Size(383, 69);
            this.txt_revsebep.TabIndex = 3;
            this.txt_revsebep.Text = "";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(46, 139);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Revizyon:";
            // 
            // txt_rev
            // 
            this.txt_rev.Location = new System.Drawing.Point(392, 20);
            this.txt_rev.Name = "txt_rev";
            this.txt_rev.Size = new System.Drawing.Size(100, 20);
            this.txt_rev.TabIndex = 1;
            this.txt_rev.TextChanged += new System.EventHandler(this.txt_rev_TextChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(318, 23);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Revizyon No:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton1.Location = new System.Drawing.Point(109, 227);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(383, 49);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Aciklama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 303);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txt_revsebep);
            this.Controls.Add(this.txt_aciklama);
            this.Controls.Add(this.txt_rev);
            this.Controls.Add(this.txt_rapor);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Name = "Aciklama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Açıklama / Revizyon";
            this.Load += new System.EventHandler(this.Aciklama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_rapor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rev.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_rapor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RichTextBox txt_aciklama;
        private System.Windows.Forms.RichTextBox txt_revsebep;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_rev;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}