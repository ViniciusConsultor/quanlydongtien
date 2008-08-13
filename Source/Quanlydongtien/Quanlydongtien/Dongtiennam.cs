using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
namespace Quanlydongtien
{
    public partial class Dongtiennam : Form
    {
        db CashDB;
        Boolean realdata;
        string dbfile;
        string workingdir;
        public Dongtiennam()
        {
            InitializeComponent();
        }

        private void Dongtiennam_Load(object sender, EventArgs e)
        {
            
        }

        public void init(string dbname, string wdir)
        {
            int i;
            Int64 tiendu;
            CashDB = new db(dbname);
            if (create_dtGrid() == false) return;
            if (FillDG() == false) return;
            dbfile = dbname;
            realdata = false;
            workingdir = wdir;
            for (i = 0; i < dtGridCash.Rows.Count; i++)
            {
                tiendu = Int64.Parse(dtGridCash.Rows[i].Cells["Tienvao"].Value.ToString());
                if (dtGridCash.Rows[i].Cells["Tienra"].Value != null)
                    tiendu = tiendu - Int64.Parse(dtGridCash.Rows[i].Cells["Tienra"].Value.ToString());
                dtGridCash.Rows[i].Cells["Ducuoi"].Value = tiendu;
            }
            Tinh_So_Du();
            for (i = 0; i < dtGridCash.Rows.Count; i++)
            {
                tiendu = Int64.Parse(dtGridCash.Rows[i].Cells["Ducuoi"].Value.ToString());
                if (tiendu < 0)
                {
                    dtGridCash.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                if (tiendu > 1000000000)
                {
                    dtGridCash.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            
            this.ShowDialog();
        }

        private void chkReal_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            Int64 tiendu;
            realdata = chkReal.Checked;
            Clear();
            create_dtGrid();
            FillDG();
            for (i = 0; i < dtGridCash.Rows.Count; i++)
            {
                tiendu = Int64.Parse(dtGridCash.Rows[i].Cells["Tienvao"].Value.ToString());
                if (dtGridCash.Rows[i].Cells["Tienra"].Value != null)
                    tiendu = tiendu - Int64.Parse(dtGridCash.Rows[i].Cells["Tienra"].Value.ToString());
                dtGridCash.Rows[i].Cells["Ducuoi"].Value = tiendu;
            }
            Tinh_So_Du();

            for (i = 0; i < dtGridCash.Rows.Count; i++)
            {
                tiendu = Int64.Parse(dtGridCash.Rows[i].Cells["Ducuoi"].Value.ToString());
                if (tiendu < 0)
                {
                    dtGridCash.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                if (tiendu > 1000000000)
                {
                    dtGridCash.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
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
                if (realdata == false)
                {
                    sqlStrVG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [DONGTIEN] WHERE ([SOTIEN] > 0) AND (([NoQH] = 0) OR ([Datra] = Yes)) GROUP BY FORMAT([Ngaytra], 'yyyy')";
                    sqlStrVL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [TIENLAI] WHERE [Sotienlai] > 0 AND (([NoQH] = 0) OR ([Datra] = Yes)) GROUP BY FORMAT([Ngaytra], 'yyyy')";
                }
                else
                {
                    sqlStrVG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [DONGTIEN] WHERE ([SOTIEN] > 0) AND ([Real] = Yes)AND (([NoQH] = 0) OR ([Datra] = Yes)) GROUP BY FORMAT([Ngaytra], 'yyyy')";
                    sqlStrVL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [TIENLAI] WHERE [Sotienlai] > 0 AND ([Real] = Yes)AND (([NoQH] = 0) OR ([Datra] = Yes)) GROUP BY FORMAT([Ngaytra], 'yyyy')";
                }
                oleReaderG = CashDB.genDataReader(sqlStrVG);
                oleReaderL = CashDB.genDataReader(sqlStrVL);
                if (oleReaderG == null || oleReaderL == null)
                    return false;
                while (oleReaderG.Read())
                {
                    tiengoc.Add(oleReaderG["Tien"].ToString());
                    namtragoc.Add(oleReaderG["Nam"].ToString());
                }

                while (oleReaderL.Read())
                {
                    tienlai.Add(oleReaderL["Tien"].ToString());
                    namtralai.Add(oleReaderL["Nam"].ToString());
                }

                for (i = 0; i < tiengoc.Count;  i++)
                {
                    tientragoc = Int64.Parse(tiengoc[i].ToString());
                    for (j = 0; j < tienlai.Count; j++)
                    {
                        if (namtralai[j].ToString() == namtragoc[i].ToString())
                            tientragoc = tientragoc + Int64.Parse(tienlai[i].ToString());
                    }
                    dtGridCash.Rows[i].Cells["Tienvao"].Value = tientragoc;
                }

                //Add to tienra column

                tiengoc = new ArrayList();
                tienlai = new ArrayList();
                namtragoc = new ArrayList();
                namtralai = new ArrayList();
                if (realdata == false)
                {
                    sqlStrVG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [DONGTIEN] WHERE [SOTIEN] < 0 AND (([NoQH] = 0) OR ([Datra] = Yes)) GROUP BY FORMAT([Ngaytra], 'yyyy')";
                    sqlStrVL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [TIENLAI] WHERE [Sotienlai] < 0 AND (([NoQH] = 0) OR ([Datra] = Yes)) GROUP BY FORMAT([Ngaytra], 'yyyy')";
                }
                else
                {
                    sqlStrVG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [DONGTIEN] WHERE [SOTIEN] < 0 AND ([Real] = Yes) AND (([NoQH] = 0) OR ([Datra] = Yes)) GROUP BY FORMAT([Ngaytra], 'yyyy')";
                    sqlStrVL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [TIENLAI] WHERE [Sotienlai] < 0 AND ([Real] = Yes) AND (([NoQH] = 0) OR ([Datra] = Yes)) GROUP BY FORMAT([Ngaytra], 'yyyy')";
                }
                oleReaderG = CashDB.genDataReader(sqlStrVG);
                oleReaderL = CashDB.genDataReader(sqlStrVL);
                if (oleReaderG == null || oleReaderL == null)
                    return false;
                while (oleReaderG.Read())
                {
                    tiengoc.Add(oleReaderG["Tien"].ToString());
                    namtragoc.Add(oleReaderG["Nam"].ToString());
                }

                while (oleReaderL.Read())
                {
                    tienlai.Add(oleReaderL["Tien"].ToString());
                    namtralai.Add(oleReaderL["Nam"].ToString());
                }

                for (i = 0; i < tiengoc.Count; i++)
                {
                    tientragoc = Int64.Parse(tiengoc[i].ToString());
                    for (j = 0; j < tienlai.Count; j++)
                    {
                        if (namtralai[j].ToString() == namtragoc[i].ToString())
                            tientragoc = tientragoc + Int64.Parse(tienlai[i].ToString());
                    }
                    dtGridCash.Rows[i].Cells["Tienra"].Value = Math.Abs(tientragoc);
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
            string sqlStr;
            int minyear, maxyear;
            string fieldname;
            int i;
            OleDbDataReader oleReader;
            sqlStr = "SELECT Min(Format(NgayTra,'yyyy')) AS Minyear, Max(Format(NgayTra,'yyyy')) AS Maxyear FROM Dongtien";
            oleReader = CashDB.genDataReader(sqlStr);
            try
            {
                if (oleReader == null)
                    return false;
                else
                {
                    if (oleReader.Read())
                    {
                        minyear = int.Parse(oleReader["Minyear"].ToString());
                        maxyear = int.Parse(oleReader["Maxyear"].ToString());
                    }
                    else return false;
                    i = minyear;
                    while (i <= maxyear)
                    {
                        dtGridCash.Rows.Add();
                        dtGridCash.Rows[i - minyear].Cells["Nam"].Value = i.ToString();
                        dtGridCash.Rows[i - minyear].Cells["Tienvao"].Value = "0";
                        dtGridCash.Rows[i - minyear].Cells["Tienra"].Value = "0";
                        dtGridCash.Rows[i - minyear].Cells["Ducuoi"].Value = "0";
                        i++;
                    }
                    return true;
                }
            }
            catch (Exception ex)
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

        private void dtGridCash_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nam;
            Int64 sodu;
            Dongtienthang frmDongTienThang = new Dongtienthang();
            nam = int.Parse(dtGridCash.Rows[e.RowIndex].Cells["Nam"].Value.ToString());
            if (e.RowIndex == 0)
                sodu = 0;
            else sodu = Int64.Parse(dtGridCash.Rows[e.RowIndex - 1].Cells["Ducuoi"].Value.ToString());
            frmDongTienThang.init(dbfile, realdata, nam, sodu, workingdir);
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
                    dtGridCash.Rows[i].Cells["Tienra"].Value = tienra_i;
                }
                else
                {
                    tienvao_i = Int64.Parse(dtGridCash.Rows[i].Cells["Tienvao"].Value.ToString());
                    tienvao_i = tienvao_i + sodu_i_1;
                    dtGridCash.Rows[i].Cells["Tienvao"].Value = tienvao_i;
                }
                sodu_i = sodu_i_1 + sodu_i;
                dtGridCash.Rows[i].Cells["Ducuoi"].Value = sodu_i;
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            string filename = "Dongtien_Nam.xls";
            string sheetnaem = "DongTienTongHop";
            filename = workingdir + @"\Baocao\Baocaodongtien\" + filename;
            Utilities.Export_To_Excel(dtGridCash, filename, sheetnaem);
        }
    }
}