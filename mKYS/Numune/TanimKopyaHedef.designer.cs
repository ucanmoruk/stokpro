namespace mKYS.Numune
{
    partial class TanimKopyaHedef
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TanimKopyaHedef));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_hedef = new DevExpress.XtraEditors.TextEdit();
            this.btn_go = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_hedef.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(186, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Hangi rapor numarasına kopyalayalım ?";
            // 
            // txt_hedef
            // 
            this.txt_hedef.Location = new System.Drawing.Point(227, 22);
            this.txt_hedef.Name = "txt_hedef";
            this.txt_hedef.Size = new System.Drawing.Size(118, 20);
            this.txt_hedef.TabIndex = 1;
            this.txt_hedef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_hedef_KeyDown);
            // 
            // btn_go
            // 
            this.btn_go.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_go.Location = new System.Drawing.Point(364, 15);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(113, 34);
            this.btn_go.TabIndex = 2;
            this.btn_go.Text = "GOOOOO!!!";
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // TanimKopyaHedef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 66);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.txt_hedef);
            this.Controls.Add(this.labelControl1);
            this.KeyPreview = true;
            this.Name = "TanimKopyaHedef";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hedef!";
            this.Load += new System.EventHandler(this.TanimKopyaHedef_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_hedef.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_hedef;
        private DevExpress.XtraEditors.SimpleButton btn_go;
    }
}