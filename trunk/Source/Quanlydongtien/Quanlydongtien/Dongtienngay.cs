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
    public partial class Dongtienngay : Form
    {
        db CashDB;
        Boolean realdata;
        string dbfile;
        Int64 duthangtruoc;
        public Dongtienngay()
        {
            InitializeComponent();
        }

        private void Dongtienngay_Load(object sender, EventArgs e)
        {

        }

        public void init(string dbname, Boolean real, string ngaythang, Int64 sodu)
        {
            int i;
            realdata = real;
            CashDB = new db(dbname);
            dbfile = dbname;
            lblthang.Text = ngaythang;
            create_dtGrid();
            lblDuno.Text = sodu.ToString();
            FillDG();
            for (i = 0; i < dtGridCash.Rows.Count; i++)
            {
                dtGridCash.Rows[i].Cells["Ducuoi"].Value = Int64.Parse(dtGridCash.Rows[i].Cells["Tienvao"].Value.ToString()) - Int64.Parse(dtGridCash.Rows[i].Cells["Tienra"].Value.ToString());
            }
            dtGridCash.Rows[0].Cells["Ducuoi"].Value = Int64.Parse(dtGridCash.Rows[0].Cells["Ducuoi"].Value.ToString()) + sodu;
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
                sqlStrVG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'dd') AS Ngay from [DONGTIEN] WHERE ([SOTIEN] > 0) AND (([NoQH] = 0) OR ([Datra] = Yes)) ";
                if (realdata)
                    sqlStrVG = sqlStrVG + "AND (FORMAT([Ngaytra], 'mm/yyyy') = '" + lblthang.Text + "') AND ([Real] = " + realdata.ToString() + ")GROUP BY FORMAT([Ngaytra], 'dd')";
                else sqlStrVG = sqlStrVG + "AND (FORMAT([Ngaytra], 'mm/yyyy') = '" + lblthang.Text + "') GROUP BY FORMAT([Ngaytra], 'dd')";
                sqlStrVL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'dd') AS Ngay from [TIENLAI] WHERE [Sotienlai] > 0 AND (([NoQH] = 0) OR ([Datra] = Yes))";
                if (realdata)
                    sqlStrVL = sqlStrVL + "  AND ((FORMAT([Ngaytra], 'mm/yyyy') = '" + lblthang.Text + "')) AND ([Real] = " + realdata.ToString() + ") GROUP BY FORMAT([Ngaytra], 'dd')";
                else sqlStrVL = sqlStrVL + "  AND ((FORMAT([Ngaytra], 'mm/yyyy') = '" + lblthang.Text + "')) GROUP BY FORMAT([Ngaytra], 'dd')";
                oleReaderG = CashDB.genDataReader(sqlStrVG);
                oleReaderL = CashDB.genDataReader(sqlStrVL);
                if (oleReaderG == null || oleReaderL == null)
                    return false;
                while (oleReaderG.Read())
                {
                    tiengoc.Add(oleReaderG["Tien"].ToString());
                    namtragoc.Add(oleReaderG["Ngay"].ToString());
                }

                while (oleReaderL.Read())
                {
                    tienlai.Add(oleReaderL["Tien"].ToString());
                    namtralai.Add(oleReaderL["Ngay"].ToString());
                }

                for (i = 0; i < tiengoc.Count; i++)
                {
                    tientragoc = Int64.Parse(tiengoc[i].ToString());
                    for (j = 0; j < tienlai.Count; j++)
                    {
                        if (namtralai[j].ToString() == namtragoc[j].ToString())
                            tientragoc = tientragoc + Int64.Parse(tienlai[i].ToString());
                    }
                    for (j = 0; j < dtGridCash.Rows.Count; j++)
                    {
                        
                        if ((dtGridCash.Rows[j].Cells["Ngay"].Value.ToString()) == namtragoc[i].ToString())
                            dtGridCash.Rows[j].Cells["Tienvao"].Value = tientragoc;
                    }
                }

                //Add to tienra column

                tiengoc = new ArrayList();
                tienlai = new ArrayList();
                namtragoc = new ArrayList();
                namtralai = new ArrayList();
                sqlStrRG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'dd') AS Ngay from [DONGTIEN] WHERE [SOTIEN] < 0 AND (([NoQH] = 0) OR ([Datra] = Yes))";
                if (realdata)
                    sqlStrRG = sqlStrRG + " AND ((FORMAT([Ngaytra], 'mm/yyyy') = '" + lblthang.Text + "')) AND ([Real] = " + realdata.ToString() + ") GROUP BY FORMAT([Ngaytra], 'dd')";
                else sqlStrRG = sqlStrRG + " AND ((FORMAT([Ngaytra], 'mm/yyyy') = '" + lblthang.Text + "')) GROUP BY FORMAT([Ngaytra], 'dd')";
                sqlStrRL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'dd') AS Ngay from [TIENLAI] WHERE [Sotienlai] < 0 AND (([NoQH] = 0) OR ([Datra] = Yes))";
                if (realdata)
                    sqlStrRL = sqlStrRL + " AND ((FORMAT([Ngaytra], 'mm/yyyy') = '" + lblthang.Text + "')) AND ([Real] = " + realdata.ToString() + ")GROUP BY FORMAT([Ngaytra], 'dd')";
                else sqlStrRL = sqlStrRL + " AND ((FORMAT([Ngaytra], 'mm/yyyy') = '" + lblthang.Text + "')) GROUP BY FORMAT([Ngaytra], 'dd')";
                oleReaderG = CashDB.genDataReader(sqlStrRG);
                oleReaderL = CashDB.genDataReader(sqlStrRL);
                if (oleReaderG == null || oleReaderL == null)
                    return false;
                while (oleReaderG.Read())
                {
                    tiengoc.Add(oleReaderG["Tien"].ToString());
                    namtragoc.Add(oleReaderG["Ngay"].ToString());
                }

                while (oleReaderL.Read())
                {
                    tienlai.Add(oleReaderL["Tien"].ToString());
                    namtralai.Add(oleReaderL["Ngay"].ToString());
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
                        if ((dtGridCash.Rows[j].Cells["Ngay"].Value.ToString()) == namtragoc[i].ToString())
                            dtGridCash.Rows[j].Cells["Tienra"].Value = Math.Abs(tientragoc);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
//                    dtGridCash.Rows[i].Cells["Tienra"].Value = tienra_i;
                }
                else
                {
                    tienvao_i = Int64.Parse(dtGridCash.Rows[i].Cells["Tienvao"].Value.ToString());
                    tienvao_i = tienvao_i + sodu_i_1;
  //                  dtGridCash.Rows[i].Cells["Tienvao"].Value = tienvao_i;
                }
                sodu_i = sodu_i_1 + sodu_i;
                dtGridCash.Rows[i].Cells["Ducuoi"].Value = sodu_i;
            }
        }

        private Boolean create_dtGrid()
        {
            int i;
            DateTime currMonth = DateTime.Parse(lblthang.Text);
            DateTime nextMonth = currMonth.AddMonths(1);
            TimeSpan difDays = nextMonth.Subtract(currMonth);
            try
            {
                for (i = 1; i <= difDays.Days; i++)
                {
                    dtGridCash.Rows.Add();
                    if (i < 10)
                        dtGridCash.Rows[i - 1].Cells["Ngay"].Value = "0" + i.ToString();
                    else dtGridCash.Rows[i - 1].Cells["Ngay"].Value = i.ToString();
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

        private void dtGridCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtGridCash_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Dongchitiet frmDongchitiet = new Dongchitiet();
            Int64 soducu, duno;
            string ngay;
            ngay = dtGridCash.Rows[e.RowIndex].Cells["Ngay"].Value.ToString() + "/" + lblthang.Text;
            if (e.RowIndex == 0)
                soducu = duthangtruoc;
            else soducu = Int64.Parse(dtGridCash.Rows[e.RowIndex - 1].Cells["Ducuoi"].Value.ToString());
            duno = Int64.Parse(dtGridCash.Rows[e.RowIndex].Cells["Ducuoi"].Value.ToString());
            frmDongchitiet.init(dbfile, ngay, soducu, duno, realdata);
        }
    }
}