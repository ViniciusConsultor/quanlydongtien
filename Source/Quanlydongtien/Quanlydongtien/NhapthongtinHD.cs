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
    public partial class NhapthongtinHD : Form
    {
        const int TraDinhKy = 1;
        const int TraNhieuLan = 2;
        const int TraMotLan = 3;
        db contractDb;
        Boolean edit;
        string MaHD;
        int HTTra;
        public NhapthongtinHD()
        {
            InitializeComponent();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            string sqlStr;
            string tongtien;
            if (cbxLoaiHD.Text == "Cho vay")
                tongtien = "-" + txtTongtien.Text;
            else tongtien = txtTongtien.Text;
            if (edit == true)
            {
                sqlStr = "UPDATE [HOPDONG] SET [Real] = " + chkReal.Enabled.ToString();
                sqlStr = sqlStr + ", [DESC] = '" + txtDesc.Text + "' WHERE [MaHD] = " + MaHD;
                contractDb.runSQLCmd(sqlStr);
            }
            else
            {
                sqlStr = "INSERT INTO [HOPDONG] ([MaKH], [NgayHD], [Tongtien], [Real], [Kyhan], [DonVT], [Laisuat], [Desc]";
                sqlStr = sqlStr + ", [Hoanthanh], [NoQH], [Tratruoc], [Hinhthuctra]) VALUES ('";
                sqlStr = sqlStr + cbxMaKH.Text + "', '" + cbxDateContracts.Value.ToShortDateString();
                sqlStr = sqlStr + "', " + tongtien + ", " + !chkReal.Checked.ToString();
                sqlStr = sqlStr + ", " + cbxKyhan.Text + ", '" + cbxDonvitinh.Text;
                sqlStr = sqlStr + "', " + cbxLaisuat.Text + ", '" + txtDesc.Text;
                sqlStr = sqlStr + "', No, No, No, " + HTTra + ")";
                contractDb.runSQLCmd(sqlStr);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            contractDb.close();
        }

        public void init(string dbname)
        {
            string sqlStr;
            OleDbDataReader oleReader;
            contractDb = new db(dbname);
            edit = false;
            MaHD = "";
            HTTra = TraDinhKy;
            optTraDK.Checked = true;
            if (contractDb == null)
            {
                MessageBox.Show("Loi ket noi den database");
                this.Close();
            }
            sqlStr = "SELECT [MaKH] FROM [KHACHHANG] ORDER BY [MaKH]";
            try
            {
                oleReader = contractDb.genDataReader(sqlStr);
                while (oleReader.Read())
                {
                    cbxMaKH.Items.Add(oleReader[0].ToString());
                }
                cbxMaKH.Text = cbxMaKH.Items[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                contractDb.close();
                this.Close();
            }
        }
        public void init(string dbname, string maHD)
        {
            string sqlStr;
            OleDbDataReader oleReader;
            contractDb = new db(dbname);
            Int64 tongtien = 0;
            MaHD = maHD;
            edit = true;
            if (contractDb == null)
            {
                MessageBox.Show("Loi ket noi den database");
                this.Close();
            }

            sqlStr = "SELECE [MaKH], [NgayHD], [Tongtien], [Real], [Kyhan], [DonVT], [Laisuat], [Desc] FROM [HOPDONG]";
            sqlStr = sqlStr + "[MaHD] = " + maHD;
            try
            {
                oleReader = contractDb.genDataReader(sqlStr);
                while (oleReader.Read())
                {
                    cbxMaKH.Text = oleReader["MaKH"].ToString();
                    cbxMaKH.Enabled = false;
                    tongtien = Int64.Parse(oleReader["Tongtien"].ToString());                    
                    cbxKyhan.Text = oleReader["Kyhan"].ToString();
                    cbxKyhan.Enabled = false;
                    cbxDonvitinh.Text = oleReader["DonVT"].ToString();
                    cbxDonvitinh.Enabled = false;
                    chkReal.Checked = Boolean.Parse(oleReader["Real"].ToString());
                    cbxDateContracts.Value = DateTime.ParseExact(oleReader["NgayHD"].ToString(), "dd-MM-yyyy", null);
                    cbxDateContracts.Enabled = false;
                    txtDesc.Text = oleReader["Desc"].ToString();
                    cbxLaisuat.Text = oleReader["Laisuat"].ToString();
                    cbxLaisuat.Enabled = false;
                }
                if (tongtien > 0)
                    cbxLoaiHD.Text = cbxLoaiHD.Items[0].ToString();
                else cbxLoaiHD.Text = cbxLoaiHD.Items[1].ToString();
                cbxLoaiHD.Enabled = false;
                cbxMaKH.Text = cbxMaKH.Items[0].ToString();
                grBoxKytra.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                contractDb.close();
                this.Close();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NhapthongtinHD_Load(object sender, EventArgs e)
        {

        }

        private void optTraDK_CheckedChanged(object sender, EventArgs e)
        {
            HTTra = TraDinhKy;
            cbxKytra.Enabled = true;
        }

        private void optTraNL_CheckedChanged(object sender, EventArgs e)
        {
            HTTra = TraNhieuLan;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            HTTra = TraMotLan;
        }
    }
}