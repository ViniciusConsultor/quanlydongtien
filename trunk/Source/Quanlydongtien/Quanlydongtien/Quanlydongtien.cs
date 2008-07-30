using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Quanlydongtien
{
    public partial class Quanlydongtien : Form
    {
        db CashDB;
        string Mahd;
        Color activeC = Color.Yellow;
        Color NegativeC = Color.Pink;
        Boolean rowColor = true;
        public Quanlydongtien()
        {
            InitializeComponent();
        }

        private void Quanlydongtien_Load(object sender, EventArgs e)
        {

        }

        public void init(string mahd, string dbname)
        {
            string sqlStrG, sqlStrL;
            Mahd = mahd;
            int i;
            try
            {
                CashDB = new db(dbname);
                txtMaHD.Text = mahd;
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
                        dtGridCFL.Rows[i].Cells["Datra"].ReadOnly = true;
                    }

                }

                for (i = 0; i < dtGridCFG.Rows.Count; i++)
                {
                    if (dtGridCFG.Rows[i].Cells["Datra"].Value.ToString() == "True")
                    {
                        dtGridCFG.Rows[i].Cells["Datra"].ReadOnly = true;
                    }
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
            }
            catch (Exception ex)
            {
                return;
            }
        }


        private void cmdUpadate_Click(object sender, EventArgs e)
        {
            string sqlStrL, sqlStrG;
            int i;
            string Datra;
            for (i = 0; i < dtGridCFG.Rows.Count; i++)
            {
                if (dtGridCFG.Rows[i].Cells["Datra"].ReadOnly == true)
                    continue;
                if (dtGridCFG.Rows[i].Cells["Datra"].Value.ToString() == "True")
                    Datra = "Yes";
                else Datra = "No";
                sqlStrG = "UPDATE [DONGTIEN] SET [Datra] = " + Datra;
                sqlStrG = sqlStrG + " WHERE [MaDT] = " + dtGridCFG.Rows[i].Cells["MaDT"].Value.ToString() + "";
                CashDB.runSQLCmd(sqlStrG);
            }

            for (i = 0; i < dtGridCFL.Rows.Count; i++)
            {
                if (dtGridCFL.Rows[i].ReadOnly == true)
                    continue;
                if (dtGridCFL.Rows[i].Cells["Datra"].Value.ToString() == "True")
                    Datra = "Yes";
                else Datra = "No";
                sqlStrL = "UPDATE [TIENLAI] SET [Datra] = " + Datra;
                sqlStrL = sqlStrL + " WHERE [MaDT] = " + dtGridCFL.Rows[i].Cells["MaDT"].Value.ToString() + "";
                CashDB.runSQLCmd(sqlStrL);
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