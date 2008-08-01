using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quanlydongtien
{
    public partial class Dongchitiet : Form
    {
        db CashDB;
        Color activeC = Color.Yellow;
        Color NegativeC = Color.Pink;
        Boolean rowColor = true;
        Boolean initfrm = true;
        Boolean realdata;
        public Dongchitiet()
        {
            InitializeComponent();
        }

        private void Dongchitiet_Load(object sender, EventArgs e)
        {

        }

        public void init(string dbname, string ngaydt, Int64 soducu, Int64 dunocuoiky, Boolean real)
        {
            string sqlStrVG, sqlStrVL;
            string sqlStrRG, sqlStrRL;
            CashDB = new db(dbname);
            lblDunocu.Text = soducu.ToString();
            lblSoducuoi.Text = dunocuoiky.ToString();
            lblNgay.Text = ngaydt;
            sqlStrVG = "SELECT [MaDT], [Sotien], [MaHD], [NoQH], [Datra], [Real], [Mota] FROM [DONGTIEN] ";
            sqlStrVG = sqlStrVG + "WHERE [Sotien] > 0 AND FORMAT([Ngaytra], 'dd/mm/yyyy') = '" + lblNgay.Text + "'";
            if (realdata)
                sqlStrVG = sqlStrVG + "AND [Real] = Yes";
            FillDG(sqlStrVG, dtGridGIn);

            sqlStrVL = "SELECT [MaDT], [Sotienlai], [MaHD], [NoQH], [Datra], [Real], [Mota], [Tienchiulai], [Laisuat] FROM [Tienlai] ";
            sqlStrVL = sqlStrVL + "WHERE [Sotienlai] > 0 AND FORMAT([Ngaytra], 'dd/mm/yyyy') = '" + lblNgay.Text + "'";
            if (realdata)
                sqlStrVL = sqlStrVL + "AND [Real] = Yes";
            FillDG(sqlStrVL, dtGridLIn);

            sqlStrRG = "SELECT [MaDT], ABS([Sotien]), [MaHD], [NoQH], [Datra], [Real], [Mota] FROM [DONGTIEN] ";
            sqlStrRG = sqlStrRG + "WHERE [Sotien] < 0 AND FORMAT([Ngaytra], 'dd/mm/yyyy') = '" + lblNgay.Text + "'";
            if (realdata)
                sqlStrRG = sqlStrRG + "AND [Real] = Yes";
            FillDG(sqlStrRG, dtGridGOut);

            sqlStrRL = "SELECT [MaDT], ABS([Sotienlai]), [MaHD], [NoQH], [Datra], [Real], [Mota], [Tienchiulai], [Laisuat] FROM [Tienlai] ";
            sqlStrRL = sqlStrRL + "WHERE [Sotienlai] < 0 AND FORMAT([Ngaytra], 'dd/mm/yyyy') = '" + lblNgay.Text + "'";
            if (realdata)
                sqlStrRL = sqlStrVL + "AND [Real] = Yes";
            FillDG(sqlStrRL, dtGridLOut);
            this.Show();
        }

        private void FillDG(string sqlStr, DataGridView dtGridView)
        {
            DataSet ds;
            int i;
            ds = CashDB.genDataset(sqlStr);
            dtGridView.DataSource = ds.Tables[0];
            for (i = 0; i < dtGridView.Columns.Count; i++)
            {
                dtGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (i = 0; i < dtGridView.Rows.Count; i++)
            {
                if (rowColor == true)
                {
                    dtGridView.Rows[i].DefaultCellStyle.BackColor = activeC;
                    rowColor = !rowColor;
                }
                else
                {
                    dtGridView.Rows[i].DefaultCellStyle.BackColor = NegativeC;
                    rowColor = !rowColor;
                }
            }
            rowColor = true;
        }
    }
}