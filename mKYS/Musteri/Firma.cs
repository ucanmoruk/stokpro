using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace mKYS.Musteri
{
    public partial class Firmalar : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();
        NumuneKabul n = new NumuneKabul();
        string parola;
        public int firmaID;
        public string firmaadi;
        Yetkili y;

        public Firmalar()
        {
            InitializeComponent();
        }
        
        public void parolaolustur()
        {
            char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                parola += cr[r.Next(0, cr.Length - 1)].ToString();
            }

        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_firmaad.Text == "")
                {
                    MessageBox.Show("Firma Adı Giriniz.", "Bu bir uyarıdır!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    parolaolustur();

                    //  SqlCommand komut = new SqlCommand("insert into Firma (Firma_Adi,Adres,Vergi_Dairesi,Vergi_No,Telefon,Plasiyer,mail) values (@f1,@f2,@f3,@f4,@f5,@f6,@f7) ; insert into Yetkili (Yetkili,Mail,Telefon,Firma_ID) values (@y1,@y2,@y3,IDENT_CURRENT('Firma'))", bgl.baglanti());
                    SqlCommand komut = new SqlCommand("insert into Firma (Firma_Adi,Adres,Vergi_Dairesi,Vergi_No,Telefon,Plasiyer,mail,durum,Sektor,Hizmet,Kod,Parola,Tur) values (@f1,@f2,@f3,@f4,@f5,@f6,@f7,@f8,@f9,@f10,Concat('MS',IDENT_CURRENT('Firma')),@f12,@f13) ", bgl.baglanti());
                    komut.Parameters.AddWithValue("@f1", txt_firmaad.Text);
                    komut.Parameters.AddWithValue("@f2", txt_adres.Text);
                    komut.Parameters.AddWithValue("@f3", txt_vergid.Text);
                    komut.Parameters.AddWithValue("@f4", txt_vergino.Text);
                    komut.Parameters.AddWithValue("@f5", txt_telefon.Text);
                    komut.Parameters.AddWithValue("@f6", combo_plasiyer.Text);
                    komut.Parameters.AddWithValue("@f7", txt_Mail.Text);
                    komut.Parameters.AddWithValue("@f8", "Aktif");
                    komut.Parameters.AddWithValue("@f9", txt_sektor.Text);
                    komut.Parameters.AddWithValue("@f10", txt_not.Text);
                    komut.Parameters.AddWithValue("@f12", parola);
                    komut.Parameters.AddWithValue("@f13", combo_tur.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    temizle();

                    listele();
                    n.Firma();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata : "+ ex.Message);
            }


        }

        public void temizle()
        {
            txt_adres.Text = "";
            txt_firmaad.Text = "";
            txt_Mail.Text = "";
            txt_plasiyer.Text = "";
            txt_telefon.Text = "";
            txt_vergino.Text = "";
            txt_vergid.Text = "";
            combo_plasiyer.Text = "";
            txt_sektor.Text = "";
            txt_not.Text = "";
        }

        public void listele()
        {
            DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select Firma_Adi,f.Telefon,f.Adres,f.Vergi_Dairesi,f.Vergi_No,y.Yetkili,y.Telefon,y.Mail,p.Plasiyer from Firma f inner join Yetkili y on y.Firma_ID = f.ID inner join Plasiyer p on p.ID = f.Plasiyer_ID ", bgl.baglanti());
            //SqlDataAdapter da = new SqlDataAdapter("select Firma_Adi,Adres,Vergi_Dairesi,Vergi_No,f.Telefon,Plasiyer,f.Mail,Yetkili,y.Mail,y.Telefon from Firma f inner join Yetkili y on y.Firma_ID = f.ID", bgl.baglanti());
            //son hali alttakiydi
            SqlDataAdapter da = new SqlDataAdapter(@"select f.ID, f.Firma_Adi as 'Firma Adı' , f.Adres, f.Telefon, f.Mail, f.Vergi_Dairesi as 'Vergi Dairesi',
                f.Vergi_No as 'Vergi No', f.Sektor, k.Ad + ' '+k.Soyad as 'Plasiyer' ,f.Hizmet as 'Not', f.Kod, f.Parola,f.Tur as 'Firma Türü', f.Odeme as 'Odeme Türü', f.Vade 
                from Firma f 
				left join StokKullanici k on f.PlasiyerID = k.ID where f.Durum = 'Aktif'", bgl.baglanti());
            //  SqlDataAdapter da = new SqlDataAdapter("select  Firma_Adi as 'Firma Adı' , Adres, Telefon, Mail, Vergi_Dairesi as 'Vergi Dairesi', Vergi_No as 'Vergi No', Sektor, Plasiyer,Hizmet as 'Not', Tur as 'Firma Türü' from Firma where Durum = 'Aktif'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView3.Columns["ID"].Visible = false;
        }

        private void Firmalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
            this.gridView3.Columns[6].Width = 75;
            this.gridView3.Columns[7].Width = 75;
            this.gridView3.Columns[5].Width = 100;
            this.gridView3.Columns[2].Width = 100;
            this.gridView3.Columns[4].Width = 100;
            this.gridView3.Columns[0].Width = 200;
            this.gridView3.Columns[1].Width = 200;
        }

        //int plasiyerID=0;
        //private void comboPlasiyer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlCommand komutplasiyer = new SqlCommand("Select ID From Plasiyer where Plasiyer = '"+comboPlasiyer.Text+"' ", bgl.baglanti());

        //    SqlDataReader dr = komutplasiyer.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        plasiyerID = Convert.ToInt32(dr[0].ToString());
        //        lbl_firmaid.Text = plasiyerID.ToString();
        //    }           
        //    bgl.baglanti().Close();

        //}

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_firmaad.Text == "")
                {
                    MessageBox.Show("Neyi ?", "Bu bir uyarıdır!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    SqlCommand komut = new SqlCommand("Update Firma Set Firma_Adi = N'" + txt_firmaad.Text + "', Hizmet = N'"+txt_not.Text+"', Adres = N'" + txt_adres.Text + "', Telefon = N'" + txt_telefon.Text + "',  Mail = N'" + txt_Mail.Text + "', Vergi_Dairesi = N'" + txt_vergid.Text + "', Vergi_No = N'" + txt_vergino.Text + "', Sektor = N'" + txt_sektor.Text + "',Plasiyer = N'" + combo_plasiyer.Text + "', Tur= N'"+combo_tur.Text+"' where ID = N'" + lbl_ID.Text + "' ", bgl.baglanti());
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    temizle();

                    listele();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata : "+ ex.Message);
            }
        }
       
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(gridView3.FocusedRowHandle >= 0)
            {
                int fID = Convert.ToInt32(gridView3.GetFocusedRowCellValue("ID"));
                string fAdi = gridView3.GetFocusedRowCellValue("Firma Adı").ToString();

                y = new Yetkili();
                y.firmaID = fID;
                y.firmaAdi = fAdi;
                y.ShowDialog();
            }
        }

        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                   // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update Firma set Durum=@a1 , Firma_Adi=@a2 where ID = @p1", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@p1", firmaID);
                    komutSil.Parameters.AddWithValue("@a2", "[Silindi] " + firmaadi);
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    listele();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : "+ ex.Message);
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
          
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                txt_firmaad.Text = dr["Firma Adı"].ToString();
                firmaadi = dr["Firma Adı"].ToString();
                txt_adres.Text = dr["Adres"].ToString();
                txt_telefon.Text = dr["Telefon"].ToString();
                txt_vergid.Text = dr["Vergi Dairesi"].ToString();
                txt_vergino.Text = dr["Vergi No"].ToString();
                txt_Mail.Text = dr["Mail"].ToString();
                txt_sektor.Text = dr["Sektor"].ToString();
                txt_not.Text = dr["Not"].ToString();
                combo_plasiyer.Text = dr["Plasiyer"].ToString();
                combo_tur.Text = dr["Firma Türü"].ToString();

                SqlCommand komutID = new SqlCommand("Select ID From Firma where Firma_Adi= N'" + txt_firmaad.Text + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    firmaID = Convert.ToInt32(drI[0].ToString());
                    lbl_ID.Text = firmaID.ToString();
                }
                bgl.baglanti().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void gridView3_RowCellStyle_1(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Telefon" || e.Column.FieldName == "Vergi No" || e.Column.FieldName == "Sektor" || e.Column.FieldName == "Plasiyer" || e.Column.FieldName == "Vergi Dairesi")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string path = "output.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView3.FocusedRowHandle >= 0)
            {
                int fID = Convert.ToInt32(gridView3.GetFocusedRowCellValue("ID"));

                FirmaYeni firmaYeni = new FirmaYeni();
                firmaYeni.isUpdated = true;
                firmaYeni.firmaUpdateID = fID;
                firmaYeni.Show();
            }

        }
    }
};



