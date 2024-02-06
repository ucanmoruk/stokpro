using DevExpress.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace mKYS.Numune
{
    public partial class LabTermin : Form
    {
        public LabTermin()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select n.Tarih, n.Servis, t.Termin, n.RaporNo, f.Firma_Adi, n.Numune_Adi, n.Grup, n.Tur, n.Aciklama, 
            r.Durum as 'Numune Durumu',n.Rapor_Durumu as 'Rapor Durumu' from NKR n
            left join Termin t on n.ID = t.RaporID
            left join Firma f on n.Firma_ID = f.ID
            left join Rapor_Durum r on n.ID = r.RaporID
            where n.Rapor_Durumu = 'Rapor Beklemede' and Year(n.Tarih) = 2023
            order by Termin asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            this.gridView3.Columns[0].Width = 90;
            this.gridView3.Columns[1].Width = 60;
            this.gridView3.Columns[2].Width = 60;
            this.gridView3.Columns[3].Width = 80;
            this.gridView3.Columns[4].Width = 200;
            this.gridView3.Columns[5].Width = 150;
            this.gridView3.Columns[6].Width = 50;
            this.gridView3.Columns[7].Width = 60;
            this.gridView3.Columns[8].Width = 90;
            this.gridView3.Columns[9].Width = 75;
            this.gridView3.Columns[10].Width = 75;
        }

        private void LabTermin_Load(object sender, EventArgs e)
        {
            listele();

            gridView3.Columns["Tarih"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView3.Columns["Tarih"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm ";
        }

        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Tarih" || e.Column.FieldName == "Servis" || e.Column.FieldName == "Termin" || e.Column.FieldName == "RaporNo" || e.Column.FieldName == "EvrakNo" || e.Column.FieldName == "Grup" || e.Column.FieldName == "Tur" || e.Column.FieldName == "Numune Durumu" || e.Column.FieldName == "Rapor Durumu")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string total = gridView3.GetRowCellValue(e.RowHandle, "Termin").ToString();
            //GridFormatRule gridFormatRule = new GridFormatRule();
            //FormatConditionRule3ColorScale formatConditionRule3ColorScale = new FormatConditionRule3ColorScale();
            //gridFormatRule.Column = gridView3.Columns["Termin"];
            //formatConditionRule3ColorScale.PredefinedName = "Green, White, Red";
            //gridFormatRule.Rule = formatConditionRule3ColorScale;
            //gridView3.FormatRules.Add(gridFormatRule);


            //FormatConditionRuleDataBar formatConditionRuleDataBar = new FormatConditionRuleDataBar();
            //gridFormatRule.Column = gridView3.Columns["Termin"];
            //formatConditionRuleDataBar.PredefinedName = "Blue Gradient";
            //gridFormatRule.Rule = formatConditionRuleDataBar;
            //gridView3.FormatRules.Add(gridFormatRule);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////excel
            string path = "terminlistesi.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }
    }
}
