namespace mKYS.Musteri
{
    partial class TeklifNoSec
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
            this.txt_teklifno = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_teklifno.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_teklifno
            // 
            this.txt_teklifno.Location = new System.Drawing.Point(76, 26);
            this.txt_teklifno.Name = "txt_teklifno";
            this.txt_teklifno.Size = new System.Drawing.Size(124, 20);
            this.txt_teklifno.TabIndex = 0;
            this.txt_teklifno.TextChanged += new System.EventHandler(this.txt_teklifno_TextChanged);
            this.txt_teklifno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_teklifno_KeyDown);
            this.txt_teklifno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_teklifno_KeyPress);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(76, 56);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(124, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Devam Et";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Teklif No:";
            // 
            // TeklifNoSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 99);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txt_teklifno);
            this.Name = "TeklifNoSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teklif Numarası Seç";
            this.Load += new System.EventHandler(this.TeklifNoSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_teklifno.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_teklifno;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}