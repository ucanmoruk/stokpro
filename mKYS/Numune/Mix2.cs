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
    public partial class Mix2 : Form
    {
        public Mix2()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select No, Grup, Tanim as 'Tanımlama', ID from Tanimlama where RaporID = '" + raporID + "' and Durumu =N'Aktif' order by No asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();

            gridView1.Columns["ID"].Visible = false;

            gridView1.VisibleColumns[0].Width = 10;
            this.gridView1.Columns["No"].Width = 10;
            this.gridView1.Columns[1].Width = 10;
            this.gridView1.Columns[2].Width = 100;

        }

        void listele2()
        {

            DataTable d2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select d.ID as 'ID', d.Ad, d.Method as 'Metot', d.Matriks, r.ID as 'x1ID' from StokAnalizListesi d 
            inner join NumuneX1 r on r.AnalizID = d.ID inner join NKR n on n.ID = r.RaporID 
            where n.RaporNo = N'" + raporno + "' ", bgl.baglanti());
            da2.Fill(d2);
            gridControl2.DataSource = d2;
            bgl.baglanti().Close();

            gridView2.Columns["ID"].Visible = false;
            gridView2.Columns["x1ID"].Visible = false;
            gridView2.VisibleColumns[0].Width = 10;
            this.gridView2.Columns[1].Width = 110;
            this.gridView2.Columns[2].Width = 60;
            this.gridView2.Columns[3].Width = 60;
        }

        void listele3()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select l.Ad as 'Analiz', l.Method, x.Kod, x.Aciklama, x.ID, x.AnalizID, x.x3ID from Numunex2 x 
            left join StokAnalizListesi l on x.AnalizID = l.ID 
            where RaporID = '"+raporID+"' order by l.Ad, x.Kod", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
            bgl.baglanti().Close();

            gridView3.Columns["ID"].Visible = false;
            gridView3.Columns["AnalizID"].Visible = false;
            gridView3.Columns["x3ID"].Visible = false;

            gridView3.VisibleColumns[0].Width = 10;
            this.gridView3.Columns["Analiz"].Width = 100;
            this.gridView3.Columns["Aciklama"].Width = 100;
            this.gridView3.Columns["Kod"].Width = 40;
            this.gridView3.Columns["Method"].Width = 60;
        }

        public static string raporno, raporID;

        private void Mix2_Load(object sender, EventArgs e)
        {
            listele();
            listele2();
            listele3();
            Text = raporno + " Numaralı Numune"; 
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        int y, y2, x3ID, tekrar;
        string mgrup, mtanim, agrup, atanim, x2ID, loq2 ;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // tek ekle
            if (gridView1.SelectedRowsCount > 0)
            {
                if (gridView2.SelectedRowsCount > 0)
                {
                    DateTime tarih = DateTime.Now;
                    for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                    {

                        id = gridView2.GetSelectedRows()[i].ToString();
                        y = Convert.ToInt32(id);
                        analizID = gridView2.GetRowCellValue(y, "ID").ToString();

                        SqlCommand komut2 = new SqlCommand("Select * from NumuneX1 where AnalizID = '" + analizID + "' and RaporID = '" + raporID + "'", bgl.baglanti());
                        SqlDataReader dr2 = komut2.ExecuteReader();
                        while (dr2.Read())
                        {
                            x3ID = Convert.ToInt32(dr2["x3ID"]);
                        }
                        bgl.baglanti().Close();

                        for (int z = 0; z < gridView1.SelectedRowsCount; z++)
                        {
                            id2 = gridView1.GetSelectedRows()[z].ToString();
                            y2 = Convert.ToInt32(id2);
                            mgrup = gridView1.GetRowCellValue(y2, "No").ToString();
                            mtanim = gridView1.GetRowCellValue(y2, "Tanımlama").ToString();
                            agrup = gridView1.GetRowCellValue(y2, "Grup").ToString();
                            atanim = mtanim + " (" + agrup + ")";

                            SqlCommand add2 = new SqlCommand("insert into NumuneX2 (AnalizID, Aciklama, Kod, RaporID, Tarih, KID, x3ID) values (@o2,@o3,@o4, @o5, @o6, @o7, @o8) SET @ID=SCOPE_IDENTITY(); " +
                           "insert into Numune_Tartim (MixID) values (IDENT_CURRENT('NumuneX2')) ; ", bgl.baglanti());
                            add2.Parameters.AddWithValue("@o2", analizID);
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

                            SqlCommand add12 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + raporno + "' and No = '" + mgrup + "' ", bgl.baglanti());
                            add12.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }

                    }
                    gridView1.ClearSelection();
                    gridView2.ClearSelection();
                    listele3();
                }
                else
                {
                    MessageBox.Show("Sanırım hem tanım hem de analiz da seçmen gerekir!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Sanırım hem tanım hem de analiz da seçmen gerekir!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        string no1, tanim1, no2, tanim2, agrup2, mix2, kod2, no3, tanim3, agrup3, mix3, kod3, loq, nTur, degerlendirme, altAnalizID;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= gridView3.RowCount - 1; i++)
            {
                x2ID = gridView3.GetRowCellValue(i, "ID").ToString();
                analizID = gridView3.GetRowCellValue(i, "AnalizID").ToString();
                x3ID = Convert.ToInt32(gridView3.GetRowCellValue(i, "x3ID").ToString());

                SqlCommand komut = new SqlCommand(@"select Count(ID) from Numunex5 where X2ID = '"+x2ID+"' ", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    tekrar = Convert.ToInt32(dr[0].ToString());
                    DateTime tarih = DateTime.Now;
                    if (tekrar == 0)
                    {
                      

                        SqlCommand add2 = new SqlCommand("update Rapor_Durum set Durum=@a1, Tarih=@a2, TanimlayanID=@a3 where RaporID = N'" + raporID + "' ", bgl.baglanti());
                        add2.Parameters.AddWithValue("@a1", "Mix Yapıldı");
                        add2.Parameters.AddWithValue("@a2", tarih);
                        add2.Parameters.AddWithValue("@a3", Giris.kullaniciID);
                        add2.ExecuteNonQuery();
                        bgl.baglanti().Close();
                  
                        SqlCommand komutx = new SqlCommand(@"select x.RaporID, d.ID, l.Kod, l.Ad, l.Method, d.Aciklama, d.LOQ, y.Limit, y.Birim, z.Tur from Numunex1 x
                        left join StokAnalizListesi l on x.AnalizID = l.ID
                        left join StokAnalizDetay d on l.ID = d.AnalizID
                        left join NKR z on x.RaporID = z.ID
                        inner join Numunex4 y on d.ID = y.AltAnalizID
                        where x.RaporID = '" + raporID + "' and d.Durum = 'Aktif' and y.x3ID = '" + x3ID + "' and x.AnalizID = '" + analizID + "'", bgl.baglanti());
                        SqlDataReader drx = komutx.ExecuteReader();
                        while (drx.Read())
                            {
                                loq = drx["LOQ"].ToString();
                                nTur = drx["Tur"].ToString();
                                altAnalizID = drx["ID"].ToString();

                                if (nTur == "Kozmetik")
                                {
                                    if (loq == "" || loq == null || loq == "-")
                                        loq2 = "Tespit Edilmedi";
                                    else
                                        loq2 = "<" + loq;
                                    degerlendirme = "Uygun";

                                    SqlCommand add = new SqlCommand("insert into NumuneX5(x2ID, AltAnalizID, Limit, Birim, Sonuc, Degerlendirme, Durum) values (@o1,@o2,@o3,@o4,@o5,@o6,@o7)", bgl.baglanti());
                                    add.Parameters.AddWithValue("@o1", x2ID);
                                    add.Parameters.AddWithValue("@o2", altAnalizID);
                                    add.Parameters.AddWithValue("@o3", drx["Limit"].ToString());
                                    add.Parameters.AddWithValue("@o4", drx["Birim"].ToString());
                                    add.Parameters.AddWithValue("@o5", loq2);
                                    add.Parameters.AddWithValue("@o6", degerlendirme);
                                    add.Parameters.AddWithValue("@o7", "Analizde");
                                    add.ExecuteNonQuery();
                                    bgl.baglanti().Close();
                                }
                                else
                                {
                                    if (loq == "" || loq == null || loq == "-")
                                        loq2 = "N.D.";
                                    else
                                        loq2 = "<" + loq;
                                    degerlendirme = "GEÇER";

                                    SqlCommand add = new SqlCommand("insert into NumuneX5(x2ID, AltAnalizID, Limit, Birim, Sonuc, Degerlendirme, Durum) values (@o1,@o2,@o3,@o4,@o5,@o6,@o7)", bgl.baglanti());
                                    add.Parameters.AddWithValue("@o1", x2ID);
                                    add.Parameters.AddWithValue("@o2", altAnalizID);
                                    add.Parameters.AddWithValue("@o3", drx["Limit"].ToString());
                                    add.Parameters.AddWithValue("@o4", drx["Birim"].ToString());
                                    add.Parameters.AddWithValue("@o5", loq2);
                                    add.Parameters.AddWithValue("@o6", degerlendirme);
                                    add.Parameters.AddWithValue("@o7", "Analizde");
                                    add.ExecuteNonQuery();
                                    bgl.baglanti().Close();
                                }

                            }
                        bgl.baglanti().Close();
                        
                    }
                    else
                    {
                        SqlCommand add2 = new SqlCommand("update Rapor_Durum set Durum=@a1, Tarih=@a2, TanimlayanID=@a3 where RaporID = N'" + raporID + "' ", bgl.baglanti());
                        add2.Parameters.AddWithValue("@a1", "Mix Yapıldı");
                        add2.Parameters.AddWithValue("@a2", tarih);
                        add2.Parameters.AddWithValue("@a3", Giris.kullaniciID);
                        add2.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                }
                dr.Close();
                bgl.baglanti().Close();


            }


            //SqlCommand komut = new SqlCommand(@"select Count(ID) from Numunex5 where X2ID in (select ID from NumuneX2 where RaporID = '"+raporID+"')", bgl.baglanti());
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    tekrar = Convert.ToInt32(dr[0].ToString()); 
            //}
            //dr.Close();
            //bgl.baglanti().Close();

            //if (tekrar == 0)
            //{
            //    DateTime tarih = DateTime.Now;

            //    SqlCommand add2 = new SqlCommand("update Rapor_Durum set Durum=@a1, Tarih=@a2, TanimlayanID=@a3 where RaporID = N'" + raporID + "' ", bgl.baglanti());
            //    add2.Parameters.AddWithValue("@a1", "Mix Yapıldı");
            //    add2.Parameters.AddWithValue("@a2", tarih);
            //    add2.Parameters.AddWithValue("@a3", Giris.kullaniciID);
            //    add2.ExecuteNonQuery();
            //    bgl.baglanti().Close();

            //    for (int i = 0; i <= gridView3.RowCount-1; i++)
            //    {
            //        x2ID = gridView3.GetRowCellValue(i, "ID").ToString();
            //        analizID = gridView3.GetRowCellValue(i, "AnalizID").ToString();
            //        x3ID = Convert.ToInt32(gridView3.GetRowCellValue(i, "x3ID").ToString());

            //        SqlCommand komutx = new SqlCommand(@"select x.RaporID, d.ID, l.Kod, l.Ad, l.Method, d.Aciklama, d.LOQ, y.Limit, y.Birim, z.Tur from Numunex1 x
            //        left join StokAnalizListesi l on x.AnalizID = l.ID
            //        left join StokAnalizDetay d on l.ID = d.AnalizID
            //        left join NKR z on x.RaporID = z.ID
            //        inner join Numunex4 y on d.ID = y.AltAnalizID
            //        where x.RaporID = '" + raporID + "' and d.Durum = 'Aktif' and y.x3ID = '" + x3ID + "' and x.AnalizID = '" + analizID + "'", bgl.baglanti());
            //        SqlDataReader drx = komutx.ExecuteReader();
            //        while (drx.Read())
            //        {
            //            loq = drx["LOQ"].ToString();
            //            nTur = drx["Tur"].ToString();
            //            altAnalizID = drx["ID"].ToString();

            //            if (nTur == "Kozmetik")
            //            {
            //                if (loq == "" || loq == null || loq == "-")
            //                    loq2 = "Tespit Edilmedi";
            //                else
            //                    loq2 = "<" + loq;
            //                degerlendirme = "Uygun";

            //                SqlCommand add = new SqlCommand("insert into NumuneX5(x2ID, AltAnalizID, Limit, Birim, Sonuc, Degerlendirme, Durum) values (@o1,@o2,@o3,@o4,@o5,@o6,@o7)", bgl.baglanti());
            //                add.Parameters.AddWithValue("@o1", x2ID);
            //                add.Parameters.AddWithValue("@o2", altAnalizID);
            //                add.Parameters.AddWithValue("@o3", drx["Limit"].ToString());
            //                add.Parameters.AddWithValue("@o4", drx["Birim"].ToString());
            //                add.Parameters.AddWithValue("@o5", loq2);
            //                add.Parameters.AddWithValue("@o6", degerlendirme);
            //                add.Parameters.AddWithValue("@o7", "Analizde");
            //                add.ExecuteNonQuery();
            //                bgl.baglanti().Close();
            //            }
            //            else
            //            {
            //                if (loq == "" || loq == null || loq == "-")
            //                    loq2 = "N.D.";
            //                else
            //                    loq2 = "<" + loq;
            //                degerlendirme = "Geçer";

            //                SqlCommand add = new SqlCommand("insert into NumuneX5(x2ID, AltAnalizID, Limit, Birim, Sonuc, Degerlendirme, Durum) values (@o1,@o2,@o3,@o4,@o5,@o6,@o7)", bgl.baglanti());
            //                add.Parameters.AddWithValue("@o1", x2ID);
            //                add.Parameters.AddWithValue("@o2", altAnalizID);
            //                add.Parameters.AddWithValue("@o3", drx["Limit"].ToString());
            //                add.Parameters.AddWithValue("@o4", drx["Birim"].ToString());
            //                add.Parameters.AddWithValue("@o5", loq2);
            //                add.Parameters.AddWithValue("@o6", degerlendirme);
            //                add.Parameters.AddWithValue("@o7", "Analizde");
            //                add.ExecuteNonQuery();
            //                bgl.baglanti().Close();
            //            }

            //        }
            //        bgl.baglanti().Close();
            //    }
            //}
            //else
            //{

            //}

           

            this.Close();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Mix ekle
            if (gridView1.SelectedRowsCount > 0)
            {
                if (gridView2.SelectedRowsCount > 0)
                {
                    DateTime tarih = DateTime.Now;
                    for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                    {

                        id = gridView2.GetSelectedRows()[i].ToString();
                        y = Convert.ToInt32(id);
                        analizID = gridView2.GetRowCellValue(y, "ID").ToString();

                        SqlCommand komut2 = new SqlCommand("Select * from NumuneX1 where AnalizID = '" + analizID + "' and RaporID = '" + raporID + "'", bgl.baglanti());
                        SqlDataReader dr2 = komut2.ExecuteReader();
                        while (dr2.Read())
                        {
                            x3ID = Convert.ToInt32(dr2["x3ID"]);
                        }
                        bgl.baglanti().Close();

                        if (gridView1.SelectedRowsCount == 2)
                        {
                            int ym = Convert.ToInt32(gridView1.GetSelectedRows()[0].ToString());
                            int zm = Convert.ToInt32(gridView1.GetSelectedRows()[1].ToString());
                            no1 = gridView1.GetRowCellValue(ym, "No").ToString();
                            tanim1 = gridView1.GetRowCellValue(ym, "Tanımlama").ToString();
                            no2 = gridView1.GetRowCellValue(zm, "No").ToString();
                            tanim2 = gridView1.GetRowCellValue(zm, "Tanımlama").ToString();
                            agrup = gridView1.GetRowCellValue(ym, "Grup").ToString();
                            agrup2 = gridView1.GetRowCellValue(zm, "Grup").ToString();
                            mix2 = tanim1 + " (" + agrup + ")" + " + " + tanim2 + " (" + agrup2 + ")";
                            kod2 = no1 + "+" + no2;

                            SqlCommand add2 = new SqlCommand("insert into NumuneX2 ( AnalizID, Aciklama, Kod, RaporID, Tarih, KID, x3ID) values (@o2,@o3,@o4, @o5, @o6, @o7, @o8) SET @ID=SCOPE_IDENTITY(); " +
                            "insert into Numune_Tartim (MixID) values (IDENT_CURRENT('NumuneX2')) ; ", bgl.baglanti());
                            add2.Parameters.AddWithValue("@o2", analizID);
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


                            SqlCommand add12 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + raporno + "' and No = '" + no1 + "' ", bgl.baglanti());
                            add12.ExecuteNonQuery();
                            bgl.baglanti().Close();

                            SqlCommand add13 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + raporno + "' and No = '" + no2 + "' ", bgl.baglanti());
                            add12.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }
                        else if (gridView1.SelectedRowsCount == 3)
                        {
                            int y = Convert.ToInt32(gridView1.GetSelectedRows()[0].ToString());
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
                            mix3 = tanim1 + " (" + agrup + ")" + " + " + tanim2 + " (" + agrup2 + ")" + " + " + tanim3 + " (" + agrup3 + ")";
                            kod3 = no1 + "+" + no2 + "+" + no3;

                            SqlCommand add2 = new SqlCommand("insert into NumuneX2 ( AnalizID, Aciklama, Kod, RaporID, Tarih, KID, x3ID) values (@o2,@o3,@o4, @o5, @o6, @o7, @o8) SET @ID=SCOPE_IDENTITY();" +
                            "insert into Numune_Tartim (MixID) values (IDENT_CURRENT('NumuneX2')) ; ", bgl.baglanti());
                            add2.Parameters.AddWithValue("@o2", analizID);
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

                            SqlCommand add12 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + raporno + "' and No = '" + no1 + "' ", bgl.baglanti());
                            add12.ExecuteNonQuery();
                            bgl.baglanti().Close();

                            SqlCommand add13 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + raporno + "' and No = '" + no2 + "' ", bgl.baglanti());
                            add13.ExecuteNonQuery();
                            bgl.baglanti().Close();

                            SqlCommand add14 = new SqlCommand("update Tanimlama set Durum = '1' where RaporNo = '" + raporno + "' and No = '" + no3 + "' ", bgl.baglanti());
                            add14.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }
                        else
                        {
                            MessageBox.Show("Yalnızca 2 veya 3 parçayı mix yapabilirsin!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }


                    }
                    gridView1.ClearSelection();
                    gridView2.ClearSelection();
                    listele3();
                }
                else
                {
                    MessageBox.Show("Sanırım hem tanım hem de analiz da seçmen gerekir!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Sanırım hem tanım hem de analiz da seçmen gerekir!", "Yanlış mıyım?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // mix sil
            try
            {
                if (gridView3.SelectedRowsCount > 0)
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Seçili mixleri silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        for (int i = 0; i < gridView3.SelectedRowsCount; i++)
                        {
                            id = gridView3.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            tanimID = gridView3.GetRowCellValue(y, "ID").ToString();
                            SqlCommand add = new SqlCommand("delete from NumuneX2 where ID = @p1 ; " +
                                " delete from Numune_Tartim where MixID = @p1", bgl.baglanti());
                            add.Parameters.AddWithValue("@p1", tanimID);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }

                        MessageBox.Show("Başarılı.");

                        listele3();
                    }
                }
                else
                {
                    MessageBox.Show("Neyi mesela ?");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Haydaaa!! : " + ex.Message);
            }
        }

        string analizID;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // analiz sil
            try
            {
                if (gridView2.SelectedRowsCount > 0)
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Seçili analizleri silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                        {
                            id = gridView2.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            analizID = gridView2.GetRowCellValue(y, "x1ID").ToString();
                            SqlCommand add = new SqlCommand("delete from NumuneX1 where ID = @p1", bgl.baglanti());
                            add.Parameters.AddWithValue("@p1", analizID);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }

                        MessageBox.Show("Sildiğin analizleri mix bölümünde varsa oradan da silmelisin. Bir dost.");

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
                MessageBox.Show("Haydaaa!! : " + ex.Message);
            }
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu2.ShowPopup(p2);
            }
        }

        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu3.ShowPopup(p2);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" || e.Column.FieldName == "Grup")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        string id, id2, tanimID;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // tanım sil
            try
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Seçili tanımları silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            id = gridView1.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            tanimID = gridView1.GetRowCellValue(y, "ID").ToString();
                            SqlCommand add = new SqlCommand("update Tanimlama set Durumu = 'Pasif' where ID = @p1", bgl.baglanti());
                            add.Parameters.AddWithValue("@p1", tanimID);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }

                        MessageBox.Show("Sildiğin tanımları mix bölümünde varsa oradan da silmelisin. Bir dost.");

                        listele();
                    }
                }
                else
                {
                    MessageBox.Show("Neyi mesela ?");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Haydaaa!! : " + ex.Message);
            }
        }


    }
}
