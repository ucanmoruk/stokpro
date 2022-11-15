using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Numune
{
    public partial class Mix : Form
    {
        public Mix()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt = new DataTable();
           // SqlDataAdapter da = new SqlDataAdapter("select No, Grup, Tanim as 'Tanımlama' from Tanimlama where RaporNo = '" + txt_raporno.Text + "' order by No asc", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter("select No, Grup, Tanim as 'Tanımlama' from Tanimlama where RaporID = '" + raporID + "' order by No asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();

            // Tüm analizleri listelemek içindi
            //DataTable dt2 = new DataTable();
            //SqlDataAdapter da2 = new SqlDataAdapter("select a.ID as 'ID', a.Kod, a.Ad, l.Kod from StokAnalizListesi a left join StokDKDListe l on a.Metot = l.ID where Durumu = 'Aktif' order by a.ID", bgl.baglanti());
            //da2.Fill(dt2);
            //gridLookUpEdit1.Properties.DataSource = dt2;
            //gridLookUpEdit1.Properties.DisplayMember = "Ad";
            //gridLookUpEdit1.Properties.ValueMember = "ID";

        }

        void listele2()
        {
            DataTable dt = new DataTable();
          //  SqlDataAdapter da = new SqlDataAdapter("select Kod, Aciklama as 'Tanımlama' from Mix where RaporNo = N'" + txt_raporno.Text + "' and MetotID = N'"+analizID+"' ", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter("select Kod, Aciklama as 'Tanımlama', ID from NumuneX2 where RaporID = N'" + raporID + "' and AnalizID = N'"+gridLookUpEdit1.EditValue+"' ", bgl.baglanti());
            da.Fill(dt);
            if (da == null)
            {

            }
            else
            {
                gridControl2.DataSource = dt;
            }

            bgl.baglanti().Close();

            gridView2.Columns["ID"].Visible = false;
        }

        int analizID, x3ID;
        string birim, loq, limit;
        void analizbul()
        {

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select d.ID as 'ID', d.Ad, d.Method as 'Metot', d.Matriks from StokAnalizListesi d 
            inner join NumuneX1 r on r.AnalizID = d.ID 
            inner join NKR n on n.ID = r.RaporID 
            where n.RaporNo = N'" + txt_raporno.Text + "'  ", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";

        }

        //int paket;
        //string paketadi;
        //void paketmi()
        //{
        //    SqlCommand komut = new SqlCommand("Select count(Tur) from Analizler where Tur = 'Paket' and ID in (select AnalizID from Rapor_Analiz where RaporID = '"+raporID+"')", bgl.baglanti());
        //    SqlDataReader dr = komut.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        paket = Convert.ToInt32(dr[0].ToString());
        //    }
        //    bgl.baglanti().Close();
        //}

        //void paketinadi()
        //{
        //    SqlCommand komut = new SqlCommand("Select Analiz_Adi from Analizler where ID in (select AnalizID from Rapor_Analiz where RaporID = '"+raporID+"')", bgl.baglanti());
        //    SqlDataReader dr = komut.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        paketadi = dr[0].ToString();
        //    }
        //    bgl.baglanti().Close();
        //}

        //void paketbul()
        //{
        //    DataTable dt2 = new DataTable();
        //    SqlDataAdapter da2 = new SqlDataAdapter(@"select d.ID as 'ID', a.Analiz_Adi as 'Ad', d.Metot, d.Matriks from Analizler a 
        //    inner join AnalizDetay d on d.AnalizID = a.ID 
        //    where a.ID in (select AnalizID from PaketAnaliz where Paket in (select Analiz_Adi from Analizler where ID in (select AnalizID from Rapor_Analiz where RaporID = '"+raporID+"'))) ", bgl.baglanti());
        //    da2.Fill(dt2);
        //    gridLookUpEdit1.Properties.DataSource = dt2;
        //    gridLookUpEdit1.Properties.DisplayMember = "Ad";
        //    gridLookUpEdit1.Properties.ValueMember = "ID";

        //    ////   SqlCommand komut = new SqlCommand("Select concat (Kod, ' - ',Analiz_Adi,' - ', Metot) from Analizler where ID in (select AnalizNo from PaketAnaliz where Paket = N'" + paketadi + "')", bgl.baglanti());
        //    //SqlCommand komut = new SqlCommand("select concat(a.Analiz_Adi, ' | ', d.Metot, ' | ', d.Matriks) from Analizler a inner join AnalizDetay d on d.AnalizID = a.ID " +
        //    //" where a.ID in (select AnalizID from PaketAnaliz where Paket in (select Analiz_Adi from Analizler where ID in (select AnalizID from Rapor_Analiz where RaporID in (select ID from NKR where RaporNo = N'" + txt_raporno.Text + "' )))) ", bgl.baglanti());
        //    //SqlDataReader dr = komut.ExecuteReader();
        //    //while (dr.Read())
        //    //{
        //    //    combo_analiz.Properties.Items.Add(dr[0]);
        //    //}
        //    //bgl.baglanti().Close();
        //}

        void analizidbul()
        {
            SqlCommand komut = new SqlCommand("Select ID, Birim, LOQ from StokAnalizDetay where AnalizID = '"+gridLookUpEdit1.EditValue+"'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                analizID = Convert.ToInt32(dr["ID"]);
                birim = dr["Birim"].ToString();
                loq = dr["LOQ"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("Select * from NumuneX1 where AnalizID = '" + gridLookUpEdit1.EditValue + "' and RaporID = '"+raporID+"'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                x3ID = Convert.ToInt32(dr2["x3ID"]);
            }
            bgl.baglanti().Close();

        }

        string loq2;
        void limitbul()
        {
            //SqlCommand komut = new SqlCommand(@"select x.RaporID, d.ID, x.Aciklama, l.Ad, l.Method, d.Aciklama, d.LOQ, z.Limit, z.Birim from NumuneX2 x
            //left join StokAnalizListesi l on x.AnalizID = l.ID
            //left join StokAnalizDetay d on l.ID = d.AnalizID
            //left join NumuneX4 z on d.ID = z.AltAnalizID
            //where z.x3ID = '" + x3ID+"' and x.RaporID = '"+raporID+"'", bgl.baglanti());
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    SqlCommand add = new SqlCommand("insert into NumuneX5(x2ID, AltAnalizID, Limit, Birim, Sonuc, Degerlendirme, Durum) values (@o1,@o2,@o3,@o4,@o5,@o6,@o7)", bgl.baglanti());
            //    add.Parameters.AddWithValue("@o1", x2ID);
            //    add.Parameters.AddWithValue("@o2", Convert.ToInt32(dr["ID"]));
            //    add.Parameters.AddWithValue("@o3", dr["Limit"].ToString());
            //    add.Parameters.AddWithValue("@o4", dr["Birim"].ToString());
            //    add.Parameters.AddWithValue("@o5", dr["LOQ"].ToString());
            //    add.Parameters.AddWithValue("@o6", "Uygun");
            //    add.Parameters.AddWithValue("@o7", "Analizde");
            //    add.ExecuteNonQuery();
            //    bgl.baglanti().Close();

            //}
            //bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand(@"select x.RaporID, d.ID, l.Kod, l.Ad, l.Method, d.Aciklama, d.LOQ, y.Limit, y.Birim from Numunex1 x
            left join StokAnalizListesi l on x.AnalizID = l.ID
            left join StokAnalizDetay d on l.ID = d.AnalizID
            inner join Numunex4 y on d.ID = y.AltAnalizID
            where x.RaporID = '"+raporID+"' and d.Durum = 'Aktif' and y.x3ID = '"+x3ID+"' and x.AnalizID = '"+gridLookUpEdit1.EditValue+"'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                loq2 = "<"+dr["LOQ"].ToString();
                SqlCommand add = new SqlCommand("insert into NumuneX5(x2ID, AltAnalizID, Limit, Birim, Sonuc, Degerlendirme, Durum) values (@o1,@o2,@o3,@o4,@o5,@o6,@o7)", bgl.baglanti());
                add.Parameters.AddWithValue("@o1", x2ID);
                add.Parameters.AddWithValue("@o2", Convert.ToInt32(dr["ID"]));
                add.Parameters.AddWithValue("@o3", dr["Limit"].ToString());
                add.Parameters.AddWithValue("@o4", dr["Birim"].ToString());
                add.Parameters.AddWithValue("@o5", loq2);
                add.Parameters.AddWithValue("@o6", "Uygun");
                add.Parameters.AddWithValue("@o7", "Analizde");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

            }
            bgl.baglanti().Close();


        }

        public static string raporno, raporID;
        private void Mix_Load(object sender, EventArgs e)
        {

            try
            {
                raporno = TanimlamaListesi.raporno;
                txt_raporno.Text = raporno;
                listele();

                analizbul();

                this.gridView1.Columns["No"].Width = 10;
                this.gridView1.Columns[1].Width = 10;
                this.gridView1.Columns[2].Width = 100;           


            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata 1: " + ex);
            }

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" || e.Column.FieldName == "Grup")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
        
        public static string id, mgrup, mtanim, maciklama, mkod;

        private void Mix_FormClosing(object sender, FormClosingEventArgs e)
        {
            raporID = null;
        }


        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit1.EditValue = null;
            }
        }

        // string yenianalizID;
        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            analizidbul();
            listele2();
            this.gridView2.Columns["Kod"].Width = 35;
            this.gridView2.Columns["Tanımlama"].Width = 200;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DateTime tarih = DateTime.Now;

            SqlCommand add2 = new SqlCommand("update Rapor_Durum set Durum=@a1, Tarih=@a2, TanimlayanID=@a3 where RaporID = N'" + raporID + "' ", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", "Mix Yapıldı");
            add2.Parameters.AddWithValue("@a2", tarih);
            add2.Parameters.AddWithValue("@a3", Giris.kullaniciID);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();

            //DialogResult Secim = new DialogResult();

            //Secim = MessageBox.Show("Hamveri raporunu yazdırmak ister misin ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //if (Secim == DialogResult.Yes)
            //{
            //    //MessageBox.Show("Dur bakalım onun biraz daha vakti var.", "Görüşmek Üzere");

            //    Raporlar.Hamveri.raporno = txt_raporno.Text ;
            //    using (mNiS.Raporlar.frmPrint frm = new mNiS.Raporlar.frmPrint())
            //    {
            //        frm.Hamveri();
            //        frm.ShowDialog();
            //    }

            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Hoşça kal.", "Görüşmek Üzere");
            //    this.Close();
            //}

            this.Close();

        }

        private void combo_analiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            analizidbul();
            listele2();
            this.gridView2.Columns["Kod"].Width = 35;
            this.gridView2.Columns["Tanımlama"].Width = 200;
        }

        public string tanimkaldir, mixID;
        private void btn_Kaldir_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.SelectedRowsCount > 0)
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Seçili tanımı kaldırmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                        {
                            id = gridView2.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            tanimkaldir = gridView2.GetRowCellValue(y, "Kod").ToString();
                            mixID = gridView2.GetRowCellValue(y, "ID").ToString();
                            SqlCommand add = new SqlCommand("delete from NumuneX2 where ID = @p3 and Kod = @p2 ;" +
                                "delete from Numune_Tartim where MixID = @p3 ; " +
                                "delete from NumuneX5 where x2ID = @p3", bgl.baglanti());
                          //  add.Parameters.AddWithValue("@p1", txt_raporno.Text);
                            add.Parameters.AddWithValue("@p2", tanimkaldir);
                            add.Parameters.AddWithValue("@p3", mixID);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }

                        SqlCommand add13 = new SqlCommand("update Tanimlama set Durum = '0' where RaporNo = '" + txt_raporno.Text + "' ", bgl.baglanti());
                        add13.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        MessageBox.Show("Tüm durumlar sıfırlandı. Bence tekrardan ekleme yap yoksa raporda tanım durumları karışabilir. Bir dost. ");

                        listele();
                        listele2();
                    }
                }
                else
                {
                    MessageBox.Show("Neyi mesela ?");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya! Bak ne oldu: " + ex.Message);
            }

        }

        public static string no1, no2, no3, tanim1, tanim2, tanim3, mix2, mix3, kod2,kod3, agrup,agrup2,agrup3, atanim;
        private void btn_mix_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridLookUpEdit1.EditValue == null)
                {
                    MessageBox.Show("E analiz seçmedin!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (gridView1.SelectedRowsCount == 2)
                    {
                            id = gridView1.GetSelectedRows()[0].ToString();
                            int y = Convert.ToInt32(id);
                            int z = Convert.ToInt32(gridView1.GetSelectedRows()[1].ToString());
                            no1 = gridView1.GetRowCellValue(y, "No").ToString();
                            tanim1 = gridView1.GetRowCellValue(y, "Tanımlama").ToString();
                            no2 = gridView1.GetRowCellValue(z, "No").ToString();
                            tanim2 = gridView1.GetRowCellValue(z, "Tanımlama").ToString();
                            agrup = gridView1.GetRowCellValue(y, "Grup").ToString();
                              agrup2 = gridView1.GetRowCellValue(z, "Grup").ToString();
                             mix2 = tanim1 + " ("+ agrup+ ")" + " + " + tanim2 + " (" + agrup2 + ")";
                            kod2 = no1 + "+" + no2;
                        DateTime tarih = DateTime.Now;

                        SqlCommand add2 = new SqlCommand("insert into NumuneX2 ( AnalizID, Aciklama, Kod, RaporID, Tarih, KID, x3ID) values (@o2,@o3,@o4, @o5, @o6, @o7, @o8) SET @ID=SCOPE_IDENTITY(); " +
                      "insert into Numune_Tartim (MixID) values (IDENT_CURRENT('NumuneX2')) ; ", bgl.baglanti());
                        add2.Parameters.AddWithValue("@o2", gridLookUpEdit1.EditValue);
                        add2.Parameters.AddWithValue("@o3", mix2);
                        add2.Parameters.AddWithValue("@o4", kod2);
                        add2.Parameters.AddWithValue("@o5", raporID);
                        add2.Parameters.AddWithValue("@o6", tarih);
                        add2.Parameters.AddWithValue("@o7", Giris.kullaniciID);
                        add2.Parameters.AddWithValue("@o8", x3ID);
                        add2.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        add2.ExecuteNonQuery();
                        x2ID = add2.Parameters["@ID"].Value.ToString();
                        bgl.baglanti().Close();

                        limitbul();

                        gridView1.ClearSelection();

                        SqlCommand add12 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + txt_raporno.Text + "' and No = '" + no1 + "' ", bgl.baglanti());
                        add12.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        SqlCommand add13 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + txt_raporno.Text + "' and No = '" + no2 + "' ", bgl.baglanti());
                        add12.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                    else if (gridView1.SelectedRowsCount == 3)
                    {
                        id = gridView1.GetSelectedRows()[0].ToString();
                        int y = Convert.ToInt32(id);
                        int z = Convert.ToInt32(gridView1.GetSelectedRows()[1].ToString());
                        int x = Convert.ToInt32(gridView1.GetSelectedRows()[2].ToString());
                        no1 = gridView1.GetRowCellValue(y, "No").ToString();
                        tanim1 = gridView1.GetRowCellValue(y, "Tanımlama").ToString();
                        no2 = gridView1.GetRowCellValue(z, "No").ToString();
                        tanim2 = gridView1.GetRowCellValue(z, "Tanımlama").ToString();
                        no3 = gridView1.GetRowCellValue(x, "No").ToString();
                        tanim3 = gridView1.GetRowCellValue(x, "Tanımlama").ToString();
                        agrup = gridView1.GetRowCellValue(y, "Grup").ToString();
                        agrup2 = gridView1.GetRowCellValue(z, "Grup").ToString();
                        agrup3 = gridView1.GetRowCellValue(x, "Grup").ToString();
                        mix3 = tanim1 + " (" + agrup + ")" + " + " + tanim2 + " (" + agrup2 + ")" + " + " + tanim3 + " (" + agrup3 + ")" ;
                        kod3 = no1 + "+" + no2 + "+" + no3;
                        DateTime tarih = DateTime.Now;

                        SqlCommand add2 = new SqlCommand("insert into NumuneX2 ( AnalizID, Aciklama, Kod, RaporID, Tarih, KID, x3ID) values (@o2,@o3,@o4, @o5, @o6, @o7, @o8) SET @ID=SCOPE_IDENTITY();" +
                        "insert into Numune_Tartim (MixID) values (IDENT_CURRENT('NumuneX2')) ; " , bgl.baglanti());
                        add2.Parameters.AddWithValue("@o2", gridLookUpEdit1.EditValue);
                        add2.Parameters.AddWithValue("@o3", mix3);
                        add2.Parameters.AddWithValue("@o4", kod3);
                        add2.Parameters.AddWithValue("@o5", raporID);
                        add2.Parameters.AddWithValue("@o6", tarih);
                        add2.Parameters.AddWithValue("@o7", Giris.kullaniciID);
                        add2.Parameters.AddWithValue("@o8", x3ID);
                        add2.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        add2.ExecuteNonQuery();
                        x2ID = add2.Parameters["@ID"].Value.ToString();
                        bgl.baglanti().Close();

                        limitbul();


                        gridView1.ClearSelection();


                        SqlCommand add12 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + txt_raporno.Text + "' and No = '" + no1 + "' ", bgl.baglanti());
                        add12.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        SqlCommand add13 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + txt_raporno.Text + "' and No = '" + no2 + "' ", bgl.baglanti());
                        add13.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        SqlCommand add14 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + txt_raporno.Text + "' and No = '" + no3 + "' ", bgl.baglanti());
                        add14.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }

                    
                    else
                    {
                        MessageBox.Show("Yalnızca 2 veya 3 parçayı mix yapabilirsin!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    listele2();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oldu!" + ex, "Ama bir sor niye?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public string x2ID;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (gridLookUpEdit1.EditValue == null)
                {
                    MessageBox.Show("E analiz seçmedin!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if(gridView1.SelectedRowsCount > 0)
                    {
                        DateTime tarih = DateTime.Now;
                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
    
                            id = gridView1.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            mgrup = gridView1.GetRowCellValue(y, "No").ToString();
                            mtanim = gridView1.GetRowCellValue(y, "Tanımlama").ToString();
                            agrup = gridView1.GetRowCellValue(y, "Grup").ToString();
                            atanim = mtanim + " (" + agrup + ")";

                        SqlCommand add2 = new SqlCommand("insert into NumuneX2 (AnalizID, Aciklama, Kod, RaporID, Tarih, KID, x3ID) values (@o2,@o3,@o4, @o5, @o6, @o7, @o8) SET @ID=SCOPE_IDENTITY(); " +
                          "insert into Numune_Tartim (MixID) values (IDENT_CURRENT('NumuneX2')) ; ", bgl.baglanti());
                        add2.Parameters.AddWithValue("@o2", gridLookUpEdit1.EditValue);
                        add2.Parameters.AddWithValue("@o3", atanim);
                        add2.Parameters.AddWithValue("@o4", mgrup);
                        add2.Parameters.AddWithValue("@o5", raporID);
                        add2.Parameters.AddWithValue("@o6", tarih);
                        add2.Parameters.AddWithValue("@o7", Giris.kullaniciID);
                        add2.Parameters.AddWithValue("@o8", x3ID);
                        add2.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        add2.ExecuteNonQuery();
                        x2ID = add2.Parameters["@ID"].Value.ToString();
                        bgl.baglanti().Close();

                        limitbul();
                    
                        SqlCommand add12 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '"+txt_raporno.Text+"' and No = '"+mgrup+"' " , bgl.baglanti());
                            add12.ExecuteNonQuery();
                            bgl.baglanti().Close();


                        }
                        gridView1.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Sanırım önce tanım da seçmen gerekir!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    listele2();                                       
                }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Hata 5 oldu!" + ex, "Ama bir sor niye?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }




    }
}
