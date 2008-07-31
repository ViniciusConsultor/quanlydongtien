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
    public partial class NhapthongtinKH : Form
    {
        db CusDb;
        Boolean newuser = true;        
        public NhapthongtinKH()
        {
            InitializeComponent();
        }

        public void init(string dbname)
        {
            CusDb = new db(dbname);
            newuser = true;
            chkPhanloai.Checked = true;
        }

        public void init(string dbname, string cusId)
        {
            string sqlStr;
            OleDbDataReader oleReader;
            string tenKH, dinhdanh, ngaycap, noicap, SoDT, Diachi, TKNH, TenNH, MaLoaiKH;
            CusDb = new db(dbname);
            txtCusCode.Text = cusId;
            txtCusCode.Enabled = false;            
            sqlStr = "SELECT [TenKH], [DinhDanh], [Ngaycap], [Noicap], [SoDT], [Diachi], [TaikhoanNH], [TenNH], [MaLoaiKH]";
            sqlStr = sqlStr + "FROM [KHACHHANG] WHERE [MaKH] ='" + cusId + "'";
            oleReader = CusDb.genDataReader(sqlStr);
            if (oleReader == null)
                return;
            if (oleReader.Read())
            {
                tenKH = oleReader["TenKH"].ToString();
                dinhdanh = oleReader["DinhDanh"].ToString();
                ngaycap = oleReader["Ngaycap"].ToString();
                noicap = oleReader["Noicap"].ToString();
                SoDT = oleReader["SoDT"].ToString();
                Diachi = oleReader["Diachi"].ToString();
                TKNH = oleReader["TaikhoanNH"].ToString();
                TenNH = oleReader["TenNH"].ToString();
                MaLoaiKH = oleReader["MaLoaiKH"].ToString();
                if (tenKH.Length > 0)
                    this.txtCusName.Text = tenKH;
                if (dinhdanh.Length > 0)
                    txtIdentCardNum.Text = dinhdanh;
                if (ngaycap.Length > 0)
                    txtIssDate.Text = ngaycap;
                if (noicap.Length > 0)
                    txtIssPlace.Text = noicap;
                if (SoDT.Length > 0)
                    txtPhoneNum.Text = SoDT;
                if (Diachi.Length > 0)
                    txtAddress.Text = Diachi;
                if (TKNH.Length > 0)
                    txtAccount.Text = TKNH;
                if (tenKH.Length > 0)
                    txtBank.Text = TenNH;
                if (check_loai_KH(int.Parse(MaLoaiKH)))
                {
                    chkPhanloai.Checked = false;                //Khach hang doanh nghiep
                    lblIdenti.Text = "So DKKD";
                }
                else                //Khach hang ca nhan
                {
                    chkPhanloai.Checked = true;                    
                    lblIdenti.Text = "So CMT";
                }
                this.Text = "Chinh sua thong tin nguoi dung";
                newuser = false;
            }
        }
        
        //True is corporate finance
        //false is individual finance
        private Boolean check_loai_KH(int MaLoaiKH)
        {
            string sqlStr = "SELECT [TenLoaiKH] FROM [LoaiKH] WHERE ";
            OleDbDataReader oleReader;
            sqlStr = sqlStr + "[MaLoaiKH] =" + MaLoaiKH;
            string tenloaiKH;
            try
            {
                oleReader = CusDb.genDataReader(sqlStr);
                if (oleReader == null)
                    return false;
                if (oleReader.Read())
                {
                    tenloaiKH = oleReader.GetValue(0).ToString();
                    if (tenloaiKH == "Khach hang doanh nghiep")
                        return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl.ToString().Contains("TextBox"))
                    if (ctl.Text.Length == 0)
                    {
                        MessageBox.Show("Ban phai nhap day du thong tin ve khach hang!");
                        ctl.Focus();
                        return;
                    }
            }
            if (Utilities.isDateTime(txtIssDate.Text) == false)
            {
                MessageBox.Show("Ban nhap chu dung dinh dang ngay thang!");
                return;
            }
            if (newuser == true)
                Create_New_User();
            else UpdateUser();
            CusDb.close();
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CusDb.close();
            this.Close();
        }

        private void NhapthongtinKH_Load(object sender, EventArgs e)
        {
            
        }

        private void chkPhanloai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPhanloai.Checked == false)
            {
                lblIdenti.Text = "So DKKD";
            }
            else
            {
                lblIdenti.Text = "So CMT";
            }
        }

        private void UpdateUser()
        {
            string sqlStr;
            int LoaiKH;
            if (chkPhanloai.Checked == false) //Khach hang doanh nghiep
                LoaiKH = 1;
            else LoaiKH = 2;
            sqlStr = "UPDATE [KHACHHANG] SET [TenKH] = '" + txtCusName.Text + "', ";
            sqlStr = sqlStr + "[DinhDanh] = '" + txtIdentCardNum.Text + "', ";
            sqlStr = sqlStr + "[Ngaycap] = '" + txtIssDate.Text + "', ";
            sqlStr = sqlStr + "[NoiCap] = '" + txtIssPlace.Text + "', ";
            sqlStr = sqlStr + "[SoDT] = '" + txtPhoneNum.Text + "', ";
            sqlStr = sqlStr + "[Diachi] = '" + txtAddress.Text + "', ";
            sqlStr = sqlStr + "[TaikhoanNH] = '" + txtAccount.Text + "', ";
            sqlStr = sqlStr + "[TenNH] = '" + txtBank.Text + "', ";
            sqlStr = sqlStr + "[MaLoaiKH] = " + LoaiKH;
            sqlStr = sqlStr + " WHERE [MaKH] = '" + txtCusCode.Text + "'";
            try
            {
                CusDb.runSQLCmd(sqlStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Create_New_User()
        {
            string sqlStr;
            int LoaiKH;
            if (chkPhanloai.Checked == false)
                LoaiKH = 1;
            else LoaiKH = 2;
            sqlStr = "INSERT INTO [KHACHHANG] ([MaKH], [TenKH], [DinhDanh], [Ngaycap], [NoiCap], [SoDT], [Diachi], [TaikhoanNH], [TenNH], [MaLoaiKH])";
            sqlStr = sqlStr + "VALUES ('" + txtCusCode.Text + "', '";
            sqlStr = sqlStr + txtCusName.Text + "', '" + txtIdentCardNum.Text + "', '" + txtIssDate.Text + "', '";
            sqlStr = sqlStr + txtIssPlace.Text + "', '" + txtPhoneNum.Text + "', '";
            sqlStr = sqlStr + txtAddress.Text + "', '" + txtAccount.Text + "', '";
            sqlStr = sqlStr + txtBank.Text + "', " + LoaiKH + ")";
            try
            {
                CusDb.runSQLCmd(sqlStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}