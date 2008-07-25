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
    public partial class Quanlyhopdong : Form
    {
        string dbname;
        ArrayList lstMaKH;
        db ContractDB;
        Color activeC = Color.Yellow;
        Color NegativeC = Color.Pink;
        Boolean rowColor = true;
        Boolean nhapdulieu;
        public Quanlyhopdong()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ContractDB.close();
        }

        public void init(string dbfile, Boolean edit)
        {
            string sqlStr;
            OleDbDataReader oleReader;
            lstMaKH = new ArrayList();
            dbname = dbfile;
            ContractDB = new db(dbfile);
            sqlStr = "SELECT [MaHD], [MaKH], [NgayHD], [Tongtien], [Real], [Hoanthanh], [NoQH], [Laisuat] FROM [HOPDONG] ORDER BY [MaHD]";
            FillDG(sqlStr);
            dtGridContracts.AllowUserToAddRows = false;
            sqlStr = "SELECT [MaKH], [TenKH] FROM [KHACHHANG]";
            oleReader = ContractDB.genDataReader(sqlStr);
            if (oleReader == null)
            {
                MessageBox.Show("Loi ket noi den database");
                return;
            }
            while (oleReader.Read())
            {
                cbxCusName.Items.Add(oleReader["TenKH"]);
                lstMaKH.Add(oleReader["MaKH"]);
            }
            cbxCusName.Items.Add("All");
            cbxCusName.Text = "All";
            nhapdulieu = edit;
            if (nhapdulieu == false)
                cmdAdd.Enabled = false;
            else cmdAdd.Enabled = true;
        }
        private void FillDG(string sqlStr)
        {
            //string sqlStr;
            DataSet ds;
            int i;
//            sqlStr = "SELECT [MaHD], [MaKH], [NgayHD], [Tongtien], [Real], [Hoanthanh], [NoQH], [Laisuat] FROM [HOPDONG]";
            ds = ContractDB.genDataset(sqlStr);
            if (ds != null)
                dtGridContracts.DataSource = ds.Tables[0];
            else
                return;
            for (i = 0; i < dtGridContracts.Columns.Count; i++)
            {
                dtGridContracts.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (i = 0; i < dtGridContracts.Rows.Count; i++)
            {
                if (rowColor)
                    dtGridContracts.Rows[i].DefaultCellStyle.BackColor = activeC;
                else dtGridContracts.Rows[i].DefaultCellStyle.BackColor = NegativeC;
                rowColor = !rowColor;
            }
        }

        private void Quanlyhopdong_Load(object sender, EventArgs e)
        {
            
        }

        private void clear()
        {
            while (dtGridContracts.Rows.Count > 1)
            {
                dtGridContracts.Rows.RemoveAt(dtGridContracts.Rows.Count - 2);
            }
            while (dtGridContracts.ColumnCount > 0)
                dtGridContracts.Columns.RemoveAt(dtGridContracts.ColumnCount - 1);
            rowColor = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sqlStr, makh;
            int i;
            clear();
            sqlStr = "SELECT [MaHD], [MaKH], [NgayHD], [Tongtien], [Real], [Hoanthanh], [NoQH], [Laisuat] FROM [HOPDONG] WHERE";
            if (cbxMoney.Text != "All")
            {
                
                sqlStr = sqlStr + " ABS([Tongtien]) > " + cbxMoney.Text + " AND";
            }
            i = cbxCusName.Items.IndexOf(cbxCusName.Text);            
            if (cbxCusName.Text != "All")
                makh = lstMaKH[i].ToString();
            else makh = "";

            sqlStr = sqlStr + " [MaKH] LIKE '%" + makh + "%'";
            FillDG(sqlStr);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string sqlStr, makh;

            int i;
            clear();
            sqlStr = "SELECT [MaHD], [MaKH], [NgayHD], [Tongtien], [Real], [Hoanthanh], [NoQH], [Laisuat] FROM [HOPDONG] WHERE";
            if (cbxMoney.Text != "All")
            {

                sqlStr = sqlStr + " ABS([Tongtien]) > " + cbxMoney.Text + " AND";
            }
            i = cbxCusName.Items.IndexOf(cbxCusName.Text);
            if (cbxCusName.Text != "All")
                makh = lstMaKH[i].ToString();
            else makh = "";

            sqlStr = sqlStr + " [MaKH] LIKE '%" + makh + "%'";
            FillDG(sqlStr);
        }

        private void cbxCusName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtGridContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            string mahd;
            DataGridViewRow dtGridRow;
            NhapthongtinHD frmEditContracts = new NhapthongtinHD();
            if (dtGridContracts.RowCount == 0)
                return;
            if (dtGridContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ban phai chon hang can sua...");
                return;
            }
            dtGridRow = dtGridContracts.SelectedRows[0];
            mahd = dtGridRow.Cells["MaHD"].Value.ToString();
            frmEditContracts.init(dbname);

        }
    }
}