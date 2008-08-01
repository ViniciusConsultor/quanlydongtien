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
    public partial class Quanlydongtien : Form
    {
        db CashDB;
        string Mahd;
        Color activeC = Color.Yellow;
        Color NegativeC = Color.Pink;
        Boolean rowColor = true; 
        ArrayList DatraG, DatraL;
        Int64 tienmat, tienlai;
        public Quanlydongtien()
        {
            InitializeComponent();
        }

        private void Quanlydongtien_Load(object sender, EventArgs e)
        {

        }

        public void init(string mahd, string dbname)
        {
            string sqlStrG, sqlStrL, sqlStr;
            string matien;
            OleDbDataReader oleReader;
            Mahd = mahd;
            int i;
            try
            {
                CashDB = new db(dbname);
                DatraG = new ArrayList();
                DatraL = new ArrayList();
                txtMaHD.Text = mahd;
                sqlStr = "SELECT [SoLuong], [MaTien] FROM [TIEN]";
                oleReader = CashDB.genDataReader(sqlStr);
                if (oleReader == null)
                    return;
                while (oleReader.Read())
                {
                    matien = oleReader["Matien"].ToString();
                    if (matien == "TongTien")
                        tienmat = Int64.Parse(oleReader["SoLuong"].ToString());
                    if (matien == "Tienlai") tienlai = Int64.Parse(oleReader["SoLuong"].ToString());
                }
                sqlStrG = "SELECT [MaDT], [Sotien], FORMAT([NgayTra], 'dd/mm/yyyy') AS Ngaytratien, [NoQH], [Datra], [Real] FROM [DONGTIEN] WHERE [MaHD] ='" + mahd + "'";
                sqlStrL = "SELECT [MaDT], [Sotienlai], FORMAT([NgayTra], 'dd/mm/yyyy') AS Ngaytratien, [NoQH], [Datra], [Real] FROM [TIENLAI] WHERE [MaHD] ='" + mahd + "'";
                FillDG(sqlStrG, dtGridCFG);
                FillDG(sqlStrL, dtGridCFL);

                if (dtGridCFL.Rows.Count == 0)
                    return;
                if (dtGridCFG.Rows.Count == 0)
                    return;
                dtGridCFL.Columns["MaDT"].ReadOnly = true;
                dtGridCFL.Columns["Sotienlai"].ReadOnly = true;
                dtGridCFL.Columns["Real"].ReadOnly = true;
                dtGridCFL.Columns["Ngaytratien"].ReadOnly = true;
                dtGridCFL.Columns["NoQH"].ReadOnly = true;

                dtGridCFG.Columns["MaDT"].ReadOnly = true;
                dtGridCFG.Columns["Sotien"].ReadOnly = true;
                dtGridCFG.Columns["Real"].ReadOnly = true;
                dtGridCFG.Columns["Ngaytratien"].ReadOnly = true;
                dtGridCFG.Columns["NoQH"].ReadOnly = true;

                for (i = 0; i < dtGridCFL.Rows.Count; i++)
                {
                    DateTime ngaytralai = DateTime.Parse(dtGridCFL.Rows[i].Cells["Ngaytratien"].Value.ToString());
                    TimeSpan difDay = ngaytralai.Subtract(DateTime.Today);
                    if ((dtGridCFL.Rows[i].Cells["Datra"].Value.ToString() == "True") || (difDay.Days > 0))
                    {
                        DatraL.Add("True");
                    }
                    else DatraL.Add("False");

                }

                for (i = 0; i < dtGridCFG.Rows.Count; i++)
                {
                    DateTime ngaytralai = DateTime.Parse(dtGridCFG.Rows[i].Cells["Ngaytratien"].Value.ToString());
                    TimeSpan difDay = ngaytralai.Subtract(DateTime.Today);
                    if ((dtGridCFG.Rows[i].Cells["Datra"].Value.ToString() == "True") || (difDay.Days > 0))
                    {
                        DatraG.Add("True");
                    }
                    else DatraG.Add("False");
                }
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                return;
            }
        }


        private void cmdUpadate_Click(object sender, EventArgs e)
        {
            string sqlStrL, sqlStrG, sqlStr;
            int i;
            string Datra;
            Boolean Realdata;
            Int64 tientra = 0;
            if ((dtGridCFG.Rows.Count == 0) && (dtGridCFL.Rows.Count == 0))
                return;
            if (dtGridCFG.Rows[0].Cells["Real"].Value.ToString() == "True")
                Realdata = true;
            else Realdata = false;
            for (i = 0; i < dtGridCFG.Rows.Count; i++)
            {
                if (DatraG[i].ToString() == "True")
                    continue;
                if (dtGridCFG.Rows[i].Cells["Datra"].Value.ToString() == "False")
                    continue;
                Datra = "Yes";
                tientra = tientra + Int64.Parse(dtGridCFG.Rows[i].Cells["Sotien"].Value.ToString());
                sqlStrG = "UPDATE [DONGTIEN] SET [Datra] = " + Datra;
                sqlStrG = sqlStrG + " WHERE [MaDT] = " + dtGridCFG.Rows[i].Cells["MaDT"].Value.ToString() + "";
                CashDB.runSQLCmd(sqlStrG);
            }

            for (i = 0; i < dtGridCFL.Rows.Count; i++)
            {
                if (DatraL[i].ToString() == "True")
                    continue;
                if (dtGridCFL.Rows[i].Cells["Datra"].Value.ToString() == "False")
                    continue;
                Datra = "Yes";
                tientra = tientra + Int64.Parse(dtGridCFL.Rows[i].Cells["Sotien"].Value.ToString());
                tienlai = tienlai + Int64.Parse(dtGridCFL.Rows[i].Cells["Sotien"].Value.ToString());
                sqlStrL = "UPDATE [TIENLAI] SET [Datra] = " + Datra;
                sqlStrL = sqlStrL + " WHERE [MaDT] = " + dtGridCFL.Rows[i].Cells["MaDT"].Value.ToString() + "";
                CashDB.runSQLCmd(sqlStrL);
            }

            if (Realdata)
            {
                tienmat = tienmat + tientra;
                sqlStr = "UPDATE [TIEN] SET [SoLuong] = " + tienmat + " WHERE [Matien] = 'TongTien'";
                CashDB.runSQLCmd(sqlStr);
                sqlStr = "UPDATE [TIEN] SET [SoLuong] = " + tienlai + " WHERE [Matien] = 'Tienlai'";
            }

            CashDB.close();
            this.Close();
        }

        private void FillDG(string sqlStr, DataGridView dtGrid)
        {
            //string sqlStr;
            DataSet ds;
            int i;
            //            sqlStr = "SELECT [MaHD], [MaKH], [NgayHD], [Tongtien], [Real], [Hoanthanh], [NoQH], [Laisuat] FROM [HOPDONG]";
            ds = CashDB.genDataset(sqlStr);
            if (ds != null)
                dtGrid.DataSource = ds.Tables[0];
            else
                return;
            for (i = 0; i < dtGridCFG.Columns.Count; i++)
            {
                dtGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void clear()
        {
            while (dtGridCFG.Rows.Count > 1)
            {
                dtGridCFG.Rows.RemoveAt(dtGridCFG.Rows.Count - 2);
            }
            while (dtGridCFG.ColumnCount > 0)
                dtGridCFG.Columns.RemoveAt(dtGridCFG.ColumnCount - 1);

            while (dtGridCFL.Rows.Count > 1)
            {
                dtGridCFL.Rows.RemoveAt(dtGridCFG.Rows.Count - 2);
            }
            while (dtGridCFL.ColumnCount > 0)
                dtGridCFG.Columns.RemoveAt(dtGridCFG.ColumnCount - 1);
            rowColor = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CashDB.close();
            this.Close();
        }
    }
}