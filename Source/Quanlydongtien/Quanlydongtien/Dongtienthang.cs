using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace Quanlydongtien
{
    public partial class Dongtienthang : Form
    {
        db CashDB;
        Boolean realdata;
        int nam;
        string dbfile;
        Int64 dunamtruoc;
        public Dongtienthang()
        {
            InitializeComponent();
        }

        private void Dongtienthang_Load(object sender, EventArgs e)
        {

        }

        public void init(string dbname, Boolean real, int namtien, Int64 sodu)
        {
            int i;
            CashDB = new db(dbname);
            nam = namtien;
            realdata = real;
            create_dtGrid();
            FillDG();
            lblNam.Text = namtien.ToString();
            dbfile = dbname;
            for (i = 0; i < dtGridCash.Rows.Count; i++)
            {
                dtGridCash.Rows[i].Cells["Ducuoi"].Value = Int64.Parse(dtGridCash.Rows[i].Cells["Tienvao"].Value.ToString()) - Int64.Parse(dtGridCash.Rows[i].Cells["Tienra"].Value.ToString());
            }
            dtGridCash.Rows[0].Cells["Ducuoi"].Value = Int64.Parse(dtGridCash.Rows[0].Cells["Ducuoi"].Value.ToString()) + sodu;
            dunamtruoc = sodu;
            lblDuno.Text = dunamtruoc.ToString();
            Tinh_So_Du();
            this.ShowDialog();
        }

        private Boolean FillDG()
        {
            string sqlStrRG, sqlStrRL;
            string sqlStrVL, sqlStrVG;
            ArrayList tiengoc, tienlai;
            ArrayList namtragoc, namtralai;
            int i, j;
            OleDbDataReader oleReaderG, oleReaderL;
            Int64 tientragoc, tientralai;
            try
            {
                tiengoc = new ArrayList();
                tienlai = new ArrayList();
                namtragoc = new ArrayList();
                namtralai = new ArrayList();
                sqlStrVG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'mm') AS Thang from [DONGTIEN] WHERE ([SOTIEN] > 0) AND (([NoQH] = 0) OR ([Datra] = Yes)) ";
                if (realdata)
                    sqlStrVG = sqlStrVG + "AND (FORMAT([Ngaytra], 'yyyy') = '" + nam + "') AND ([Real] = " + realdata.ToString() + ")GROUP BY FORMAT([Ngaytra], 'mm')";
                else sqlStrVG = sqlStrVG + "AND (FORMAT([Ngaytra], 'yyyy') = '" + nam + "') GROUP BY FORMAT([Ngaytra], 'mm')";
                sqlStrVL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'mm') AS Thang from [TIENLAI] WHERE [Sotienlai] > 0 AND (([NoQH] = 0) OR ([Datra] = Yes))";
                if (realdata)
                    sqlStrVL = sqlStrVL + "  AND ((FORMAT([Ngaytra], 'yyyy') = '" + nam + "')) AND ([Real] = " +  realdata.ToString() +") GROUP BY FORMAT([Ngaytra], 'mm')";
                else sqlStrVL = sqlStrVL + "  AND ((FORMAT([Ngaytra], 'yyyy') = '" + nam + "')) GROUP BY FORMAT([Ngaytra], 'mm')";
                oleReaderG = CashDB.genDataReader(sqlStrVG);
                oleReaderL = CashDB.genDataReader(sqlStrVL);
                if (oleReaderG == null || oleReaderL == null)
                    return false;
                while (oleReaderG.Read())
                {
                    tiengoc.Add(oleReaderG["Tien"].ToString());
                    namtragoc.Add(oleReaderG["Thang"].ToString());
                }

                while (oleReaderL.Read())
                {
                    tienlai.Add(oleReaderL["Tien"].ToString());
                    namtralai.Add(oleReaderL["Thang"].ToString());
                }

                for (i = 0; i < tiengoc.Count; i++)
                {
                    tientragoc = Int64.Parse(tiengoc[i].ToString());
                    for (j = 0; j < tienlai.Count; j++)
                    {
                        if (namtralai[j].ToString() == namtragoc[i].ToString())
                            tientragoc = tientragoc + Int64.Parse(tienlai[j].ToString());
                    }
                    for (j = 0; j < dtGridCash.Rows.Count; j++)
                        if ((dtGridCash.Rows[j].Cells["Thang"].Value.ToString()) == namtragoc[i].ToString())
                            dtGridCash.Rows[j].Cells["Tienvao"].Value = tientragoc;
                }

                //Add to tienra column

                tiengoc = new ArrayList();
                tienlai = new ArrayList();
                namtragoc = new ArrayList();
                namtralai = new ArrayList();
                sqlStrRG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'mm') AS Thang from [DONGTIEN] WHERE [SOTIEN] < 0 AND (([NoQH] = 0) OR ([Datra] = Yes))";
                if (realdata)
                    sqlStrRG = sqlStrRG + " AND ((FORMAT([Ngaytra], 'yyyy') = '" + nam + "')) AND ([Real] = " + realdata.ToString() +") GROUP BY FORMAT([Ngaytra], 'mm')";
                else sqlStrRG = sqlStrRG + " AND ((FORMAT([Ngaytra], 'yyyy') = '" + nam + "')) GROUP BY FORMAT([Ngaytra], 'mm')";
                sqlStrRL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'mm') AS Thang from [TIENLAI] WHERE [Sotienlai] < 0 AND (([NoQH] = 0) OR ([Datra] = Yes))";
                if (realdata)
                    sqlStrRL = sqlStrRL + " AND ((FORMAT([Ngaytra], 'yyyy') = '" + nam +"')) AND ([Real] = " + realdata.ToString() +")GROUP BY FORMAT([Ngaytra], 'mm')";
                else sqlStrRL = sqlStrRL + " AND ((FORMAT([Ngaytra], 'yyyy') = '" + nam + "')) GROUP BY FORMAT([Ngaytra], 'mm')";
                oleReaderG = CashDB.genDataReader(sqlStrRG);
                oleReaderL = CashDB.genDataReader(sqlStrRL);
                if (oleReaderG == null || oleReaderL == null)
                    return false;
                while (oleReaderG.Read())
                {
                    tiengoc.Add(oleReaderG["Tien"].ToString());
                    namtragoc.Add(oleReaderG["Thang"].ToString());
                }

                while (oleReaderL.Read())
                {
                    tienlai.Add(oleReaderL["Tien"].ToString());
                    namtralai.Add(oleReaderL["Thang"].ToString());
                }

                for (i = 0; i < tiengoc.Count; i++)
                {
                    tientragoc = Int64.Parse(tiengoc[i].ToString());
                    for (j = 0; j < tienlai.Count; j++)
                    {
                        if (namtralai[j].ToString() == namtragoc[i].ToString())
                            tientragoc = tientragoc + Int64.Parse(tienlai[j].ToString());
                    }
                    for (j = 0; j < dtGridCash.Rows.Count; j++)
                    {
                        if ((dtGridCash.Rows[j].Cells["Thang"].Value.ToString()) == namtragoc[i].ToString())
                            dtGridCash.Rows[j].Cells["Tienra"].Value = Math.Abs(tientragoc);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Boolean create_dtGrid()
        {
            int i;
            try
            {
                for (i = 1; i <= 12; i++)
                {
                    dtGridCash.Rows.Add();
                    if (i < 10)
                        dtGridCash.Rows[i - 1].Cells["Thang"].Value ="0" + i.ToString();
                    else dtGridCash.Rows[i - 1].Cells["Thang"].Value = i.ToString();
                    dtGridCash.Rows[i - 1].Cells["Tienvao"].Value = "0";
                    dtGridCash.Rows[i - 1].Cells["Tienra"].Value = "0";
                    dtGridCash.Rows[i - 1].Cells["Ducuoi"].Value = "0";
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Clear()
        {
            while (dtGridCash.Rows.Count > 0)
            {
                dtGridCash.Rows.RemoveAt(dtGridCash.Rows.Count - 1);
            }
        }

        private void Tinh_So_Du()
        {
            int i;
            Int64 sodu_i_1, sodu_i, tienvao_i, tienra_i;
            sodu_i = Int64.Parse(dtGridCash.Rows[0].Cells["Ducuoi"].Value.ToString());
            for (i = 1; i < dtGridCash.Rows.Count; i++)
            {
                sodu_i_1 = sodu_i;
                sodu_i = Int64.Parse(dtGridCash.Rows[i].Cells["Ducuoi"].Value.ToString());
                if (sodu_i_1 < 0)
                {
                    tienra_i = Int64.Parse(dtGridCash.Rows[i].Cells["Tienra"].Value.ToString());
                    tienra_i = tienra_i - sodu_i_1;
               //     dtGridCash.Rows[i].Cells["Tienra"].Value = tienra_i;
                }
                else
                {
                    tienvao_i = Int64.Parse(dtGridCash.Rows[i].Cells["Tienvao"].Value.ToString());
                    tienvao_i = tienvao_i + sodu_i_1;
                   // dtGridCash.Rows[i].Cells["Tienvao"].Value = tienvao_i;
                }
                sodu_i = sodu_i_1 + sodu_i;
                dtGridCash.Rows[i].Cells["Ducuoi"].Value = sodu_i;
            }
        }

        private void dtGridCash_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Dongtienngay frmDTN = new Dongtienngay();
            string thang;
            int sothang;
            Int64 sodu;
            sothang = int.Parse(dtGridCash.Rows[e.RowIndex].Cells["Thang"].Value.ToString());
            if (sothang < 10)
                thang = "0" + sothang.ToString();
            else thang = sothang.ToString();
            if (e.RowIndex == 0)
                sodu = dunamtruoc;
            else sodu = Int64.Parse(dtGridCash.Rows[e.RowIndex - 1].Cells["Ducuoi"].Value.ToString());
            frmDTN.init(dbfile, realdata, thang + "/" + nam.ToString(), sodu);
        }

        private void dtGridCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }        
 
    }
}