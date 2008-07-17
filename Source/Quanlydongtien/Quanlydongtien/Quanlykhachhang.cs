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
    public partial class Quanlykhachhang : Form
    {
        /*
         * three variable activeC, NegativeC and rowColor using the assign backcolor to gridrow
         */
        Color activeC = Color.Yellow;
        Color NegativeC = Color.Pink;
        Boolean rowColor = true;
        Boolean initfrm = true;
        db QlkhDb;
        ArrayList LoaiKHList;
        public Quanlykhachhang()
        {
            InitializeComponent();
        }

        private void Quanlykhachhang_Load(object sender, EventArgs e)
        {

        }
        /*
         * Init function using to create object db for Quanlykhachhang
         * And this function is using to import list custommer from database to form
         */
        public void init(string dbFile)
        {
            string sqlString;
            OleDbDataReader oleReader;
            string LoaiKH;
            int MaLoaiKH, i;
            LoaiKHList = new ArrayList();            
            QlkhDb = new db(dbFile);
            sqlString = "SELECT [MaLoaiKH], [LoaiKH] FROM [LOAIKH]";
            
            try
            {
                oleReader = QlkhDb.genDataReader(sqlString);
                if (oleReader == null)
                {
                    MessageBox.Show("Loi ket noi den database!");
                    this.Close();
                }
                while(oleReader.Read())
                {
                    MaLoaiKH = int.Parse(oleReader.GetValue(0).ToString());
                    LoaiKH = oleReader.GetString(1);
                    cbxLoaiKH.Items.Add(LoaiKH);
                    LoaiKHList.Add(MaLoaiKH);
                }
                cbxLoaiKH.Items.Add("All");
                cbxLoaiKH.Text = cbxLoaiKH.Items[0].ToString();
                sqlString = "SELECT [MAKH], [TenKH], [TaikhoanNH], [TenNH], [DinhDanh],[SoDT], [Diachi] FROM [KHACHHANG]";
                QlkhDb.fillDtGridView(sqlString, dtGridKH);
                for (i = 0; i < dtGridKH.Rows.Count; i++)
                {
                    if (rowColor)
                        dtGridKH.Rows[i].DefaultCellStyle.BackColor = activeC;
                    else dtGridKH.Rows[i].DefaultCellStyle.BackColor = NegativeC;
                    rowColor = !rowColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                QlkhDb.close();
                this.Close();
            }
        }

        private void cbxLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index, i;
            string sqlString;
            string loaiKH;
            if (initfrm == true)
            {
                initfrm = false;
                return;
            }
            loaiKH = cbxLoaiKH.Text;
            index = cbxLoaiKH.FindString(loaiKH);
            if (index >= LoaiKHList.Count)
            {
                sqlString = "SELECT [MAKH], [TenKH], [TaikhoanNH], [TenNH], [DinhDanh],[SoDT], [Diachi] FROM [KHACHHANG]";
            }
            else
            {
                sqlString = "SELECT [MAKH], [TenKH], [TaikhoanNH], [TenNH], [DinhDanh],[SoDT], [Diachi] FROM [KHACHHANG]";
                sqlString = sqlString + "WHERE [MaLoaiKH] = " + LoaiKHList[index].ToString();
            }
            clear();
            QlkhDb.fillDtGridView(sqlString, dtGridKH);
            for (i = 0; i < dtGridKH.Rows.Count; i++)
            {
                if (rowColor)
                    dtGridKH.Rows[i].DefaultCellStyle.BackColor = activeC;
                else dtGridKH.Rows[i].DefaultCellStyle.BackColor = NegativeC;
                rowColor = !rowColor;
            }
        }
        private void clear()
        {
            while (dtGridKH.Rows.Count > 1)
            {
                dtGridKH.Rows.RemoveAt(dtGridKH.Rows.Count - 2);
            }
            while (dtGridKH.ColumnCount > 0)
                dtGridKH.Columns.RemoveAt(dtGridKH.ColumnCount - 1);
            rowColor = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            QlkhDb.close();
            this.Close();
        }
    }
}