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
        Int64 tienmat;
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
            OleDbDataReader oleReader;
            Mahd = mahd;
            int i;
            try
            {
                CashDB = new db(dbname);
                DatraG = new ArrayList();
                DatraL = new ArrayList();
                txtMaHD.Text = mahd;
                sqlStr = "SELECT [SoLuong] FROM [TIEN] WHERE [MaTien] = 'TongTien'";
                oleReader = CashDB.genDataReader(sqlStr);
                if (oleReader.Read())
                    tienmat = Int64.Parse(oleReader[0].ToString());
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
                    if (dtGridCFL.Rows[i].Cells["Datra"].Value.ToString() == "True")
                    {
                        DatraL.Add("True");
                    }
                    else DatraL.Add("False");

                }

                for (i = 0; i < dtGridCFG.Rows.Count; i++)
                {
                    if (dtGridCFG.Rows[i].Cells["Datra"].Value.ToString() == "True")
                    {
                        DatraG.Add("True");
                    }
                    else DatraG.Add("False");
                }

                for (i = 0; i < dtGridCFG.Rows.Count; i++)
                {
                    if (rowColor)
                    {
                        dtGridCFL.Rows[i].DefaultCellStyle.BackColor = activeC;
                        dtGridCFG.Rows[i].DefaultCellStyle.BackColor = activeC;
                    }
                    else
                    {
                        dtGridCFG.Rows[i].DefaultCellStyle.BackColor = NegativeC;
                        dtGridCFL.Rows[i].DefaultCellStyle.BackColor = NegativeC;
                    }
                    rowColor = !rowColor;
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
            Int64 tientra = 0;
            for (i = 0; i < dtGridCFG.Rows.Count; i++)
            {
                if (DatraG[i].ToString() == "True")
                    continue;
                if (dtGridCFG.Rows[i].Cells["Datra"].Value.ToString() == "False")
                    continue;
                Datra = "Yes";
                tientra = tientra + Int64.Parse(dtGridCFG.Rows[i].Cells["Sotien"].ToString());
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
                tientra = tientra + Int64.Parse(dtGridCFL.Rows[i].Cells["Sotien"].ToString());
                sqlStrL = "UPDATE [TIENLAI] SET [Datra] = " + Datra;
                sqlStrL = sqlStrL + " WHERE [MaDT] = " + dtGridCFL.Rows[i].Cells["MaDT"].Value.ToString() + "";
                CashDB.runSQLCmd(sqlStrL);
            }
            tienmat = tienmat + tientra;
            sqlStr = "UPDATE [TIEN] SET [SoLuong] = " + tienmat + " WHERE [Matien] = 'TongTien'";
            CashDB.runSQLCmd(sqlStr);
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

        private void dtGridCFG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dtGridCFG.Columns[e.ColumnIndex].Name != "Datra")
            //    return;
            //if ((dtGridCFG.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "False") && (DatraG[e.RowIndex].ToString() == "True"))
            //    dtGridCFG.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
        }

        private void dtGridCFL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtGridCFG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtGridCFG_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}