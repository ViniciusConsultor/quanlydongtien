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
        int laisuat;
        db contractDb;
        string dbfile;
        Boolean edit;
        string MaHD;
        int HTTra;
        ArrayList LSHuydong;
        ArrayList LSChovay;
        ArrayList ListContracts;
        NhapKyTraNo frmNhapTN;
        public NhapthongtinHD()
        {
            InitializeComponent();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            string sqlStr;
            string tongtien;
            Boolean real, chovay;
            chovay = false;
            if (check_validate() == false)
                return;
            if (cbxLoaiHD.Text == "Cho Vay")
            {
                tongtien = "-" + txtTongtien.Text;
                chovay = true;
            }
            else tongtien = txtTongtien.Text;
            real = !chkReal.Checked;
            if (edit == true)
            {
                
                sqlStr = "UPDATE [HOPDONG] SET [Real] = " + chkReal.Enabled.ToString();
                sqlStr = sqlStr + ", [DESC] = '" + txtDesc.Text + "', [Laisuat] = " + cbxLaisuat.Text + " WHERE [MaHD] = " + MaHD;
                contractDb.runSQLCmd(sqlStr);
                contractDb.close();
                this.Close();
            }
            else
            {
                sqlStr = "INSERT INTO [HOPDONG] ([MaHD], [MaKH], [NgayHD], [Tongtien], [Real], [Kyhan], [DonVT], [Laisuat], [Desc]";
                sqlStr = sqlStr + ", [Hoanthanh], [NoQH], [Tratruoc], [Hinhthuctra]) VALUES ('";
                sqlStr = sqlStr + txtMaHD.Text + "', '" + cbxMaKH.Text + "', '" + cbxDateContracts.Value.ToShortDateString();
                sqlStr = sqlStr + "', " + tongtien + ", " + real.ToString();
                sqlStr = sqlStr + ", " + cbxKyhan.Text + ", '" + cbxDonvitinh.Text;
                sqlStr = sqlStr + "', " + cbxLaisuat.Text + ", '" + txtDesc.Text;
                sqlStr = sqlStr + "', No, No, No, " + HTTra + ")";
                if (contractDb.runSQLCmd(sqlStr) == false)
                    return;
                sqlStr = "INSERT INTO [DONGTIEN] ([MaHD], [NoQH], [Datra], [Real], [MoTa], [Sotien], [NgayTra]) VALUES (";
                sqlStr = sqlStr + "'" + txtMaHD.Text + "', No, No, " + real.ToString() + ", '" + txtDesc.Text + "', ";
                sqlStr = sqlStr + tongtien + ", '" + cbxDateContracts.Value.ToShortDateString() + "')";
                if (contractDb.runSQLCmd(sqlStr) == false)
                    return;
                frmNhapTN.Save_Data(real, txtMaHD.Text, dbfile, chovay, int.Parse(cbxLaisuat.Text));
                contractDb.close();
                this.Close();
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
            laisuat = 0;
            MaHD = "";
            HTTra = TraDinhKy;
            optTraDK.Checked = true;
            dbfile = dbname;
            frmNhapTN = new NhapKyTraNo();
            frmNhapTN.saved = false;
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
                sqlStr = "SELECT [LaiSuat], [LoaiLS] FROM [LAISUAT]";
                oleReader = contractDb.genDataReader(sqlStr);
                LSChovay = new ArrayList();
                LSHuydong = new ArrayList();
                while (oleReader.Read())
                {
                    if (oleReader["LoaiLS"].ToString() == "1")
                    {
                        LSChovay.Add(oleReader["LaiSuat"].ToString());
                        cbxLaisuat.Items.Add(oleReader["LaiSuat"].ToString());
                    }
                    else LSHuydong.Add(oleReader["LaiSuat"].ToString());
                }
                Create_List_CT();
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
            int i;
            MaHD = maHD;
            edit = true;
            dbfile = dbname;
            txtMaHD.Text = maHD;
            txtMaHD.Enabled = false;
            frmNhapTN = new NhapKyTraNo(dbname);
            frmNhapTN.saved = false;
            if (contractDb == null)
            {
                MessageBox.Show("Loi ket noi den database");
                this.Close();
            }

            sqlStr = "SELECT [MaKH] FROM [KHACHHANG] ORDER BY [MaKH]";
            oleReader = contractDb.genDataReader(sqlStr);
            while (oleReader.Read())
            {
                cbxMaKH.Items.Add(oleReader[0].ToString());
            }
            
            sqlStr = "SELECT [MaKH], [NgayHD], [Tongtien], [Real], [Kyhan], [DonVT], [Laisuat], [Desc] FROM [HOPDONG]";
            sqlStr = sqlStr + " WHERE [MaHD] = '" + maHD + "'";
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
                    chkReal.Checked = !(Boolean.Parse(oleReader["Real"].ToString()));                    
                    cbxDateContracts.Value = DateTime.Parse(oleReader["NgayHD"].ToString());
                    cbxDateContracts.Enabled = false;
                    txtDesc.Text = oleReader["Desc"].ToString();
                    laisuat = int.Parse(oleReader["Laisuat"].ToString());
                    cbxLaisuat.Text = oleReader["Laisuat"].ToString();
//                    cbxLaisuat.Enabled = false;
                }

                laisuat = int.Parse(cbxLaisuat.Text);
                if (tongtien > 0)
                {
                    cbxLoaiHD.Text = cbxLoaiHD.Items[1].ToString();
                    txtTongtien.Text = tongtien.ToString();
                }
                else
                {
                    cbxLoaiHD.Text = cbxLoaiHD.Items[0].ToString();
                    tongtien = Math.Abs(tongtien);
                    txtTongtien.Text = tongtien.ToString();
                }
                txtTongtien.Enabled = false;
                cbxLoaiHD.Enabled = false;
                cbxMaKH.Text = cbxMaKH.Items[0].ToString();
                grBoxKytra.Enabled = false;
                sqlStr = "SELECT [LaiSuat], [LoaiLS] FROM [LAISUAT]";
                oleReader = contractDb.genDataReader(sqlStr);
                LSChovay = new ArrayList();
                LSHuydong = new ArrayList();
                while (oleReader.Read())
                {
                    if (oleReader["LoaiLS"].ToString() == "1")
                    {
                        LSChovay.Add(oleReader["LaiSuat"].ToString());
                        cbxLaisuat.Items.Add(oleReader["LaiSuat"].ToString());
                    }
                    else LSHuydong.Add(oleReader["LaiSuat"].ToString());
                }
                Create_List_CT();
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
            cbxDonVi.Text = cbxDonvitinh.Text = "Ngay";
        }

        private void optTraDK_CheckedChanged(object sender, EventArgs e)
        {
            if (optTraDK.Checked == false)
                return;
            HTTra = TraDinhKy;
            grKytrano.Enabled = true;
        }

        private void optTraNL_CheckedChanged(object sender, EventArgs e)
        {
            DateTime ngayHD;
            Int64 tongtien;
            int kyhan, laisuat;
            string ngaydaohan;
            if (optTraNL.Checked == false)
                return;
            HTTra = TraNhieuLan;
            grKytrano.Enabled = false;
            if (txtMaHD.Text == null)
            {
                txtMaHD.Focus();
                return;
            }
            if (cbxKyhan.Text == "")
            {
                cbxKyhan.Focus();
                return;
            }
            kyhan = int.Parse(cbxKyhan.Text);
            if (cbxLaisuat.Text == "")
            {
                cbxLaisuat.Focus();
                return;
            }
            laisuat = int.Parse(cbxLaisuat.Text);
            if (txtTongtien.Text == "")
            {
                txtTongtien.Focus();
                return;
            }
            if (!Utilities.isInt64(txtTongtien.Text))
            {
                txtTongtien.Focus();
                return;
            }
            tongtien = Int64.Parse(txtTongtien.Text);
            ngayHD = cbxDateContracts.Value;
            if (cbxDonvitinh.Text == "Ngay")
                ngaydaohan = ngayHD.AddDays(kyhan).ToShortDateString();
            else if (cbxDonvitinh.Text == "Thang")
                ngaydaohan = ngayHD.AddMonths(kyhan).ToShortDateString();
            else
                ngaydaohan = ngayHD.AddYears(kyhan).ToShortDateString();
            frmNhapTN.init(tongtien, ngaydaohan, cbxDateContracts.Value.ToShortDateString(), laisuat);
            frmNhapTN.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DateTime ngayHD;
            Int64 tongtien;
            int kyhan, laisuat;
            string ngaydaohan;
            if (radioButton1.Checked == false)
                return;
            if (txtMaHD.Text == null)
            {
                txtMaHD.Focus();
                return;
            }
            if (cbxKyhan.Text == "")
            {
                cbxKyhan.Focus();
                return;
            }
            kyhan = int.Parse(cbxKyhan.Text);
            if (cbxLaisuat.Text == "")
            {
                cbxLaisuat.Focus();
                return;
            }
            laisuat = int.Parse(cbxLaisuat.Text);
            if (txtTongtien.Text == "")
            {
                txtTongtien.Focus();
                return;
            }
            if (!Utilities.isInt64(txtTongtien.Text))
            {
                txtTongtien.Focus();
                return;
            }
            ngayHD = cbxDateContracts.Value;            

            if (cbxDonvitinh.Text == "Ngay")
                ngaydaohan = ngayHD.AddDays(kyhan).ToShortDateString();
            else if (cbxDonvitinh.Text == "Thang")
                ngaydaohan = ngayHD.AddMonths(kyhan).ToShortDateString();
            else
                ngaydaohan = ngayHD.AddYears(kyhan).ToShortDateString();

            tongtien = Int64.Parse(txtTongtien.Text);

            HTTra = TraMotLan;
            grKytrano.Enabled = false;
            frmNhapTN.init(tongtien, ngaydaohan, ngayHD.ToShortDateString(), laisuat, true);
            frmNhapTN.ShowDialog();
        }

        private void Create_List_CT()
        {
            string sqlStr;
            OleDbDataReader oleReader;
            sqlStr = "SELECT [MaHD] FROM [HOPDONG]";
            oleReader = contractDb.genDataReader(sqlStr);
            ListContracts = new ArrayList();
            if (oleReader == null)
            {
                this.Close();
                return;
            }
            while (oleReader.Read())
                ListContracts.Add(oleReader[0].ToString());
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            string mahd;
            int i;
            Boolean found = false;
            if (edit == true)
                return;
            if (ListContracts.Count == 0)
                return;
            mahd = txtMaHD.Text;
            for (i = 0; i < ListContracts.Count; i++)
            {
                if (ListContracts[i].ToString().Contains(mahd))
                {
                    found = true;
                    break;
                }
            }
            if (found == false)
                return;
            lblContractCode.Text = ListContracts[i].ToString();
        }

        private void cbxDonvitinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDonvitinh.Text == "Ngay")
            {
                if (cbxDonVi.Text == "Thang" || cbxDonVi.Text == "Nam") 
                {
                    cbxDonVi.Text = "Ngay";
                }
                if (cbxDonvitinh.Text == "Thang")
                    if (cbxDonVi.Text == "Nam")
                        cbxDonVi.Text = "Thang";
            }
        }

        private void cbxKytra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (check_validate() == false)
            {
                cbxKytra.Text = "1";
                cbxKytra.Focus();
            }
        }

        private Boolean check_validate()
        {
            DateTime ngaydaohan, ngayHD;
            DateTime tralandau;
            int kyhan;
            ngayHD = cbxDateContracts.Value;
            kyhan = int.Parse(cbxKyhan.Text);
            if (cbxDonvitinh.Text == "Ngay")
                ngaydaohan = ngayHD.AddDays(kyhan);
            else if (cbxDonvitinh.Text == "Thang")
                ngaydaohan = ngayHD.AddMonths(kyhan);
            else
                ngaydaohan = ngayHD.AddYears(kyhan);
            if (cbxDonVi.Text == "Ngay")
                tralandau = ngayHD.AddDays(int.Parse(cbxKytra.Text));
            else if (cbxDonVi.Text == "Thang")
                tralandau = ngayHD.AddMonths(int.Parse(cbxKytra.Text));
            else tralandau = tralandau = ngayHD.AddYears(int.Parse(cbxKytra.Text));
            if (tralandau > ngaydaohan)
                return false;
            else return true;
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            int solantra, kytrano;
            DateTime ngaydaohan;
            TimeSpan difference;
            Int64 Sotien;
            int laisuat;
            string ngayHD;
            if ((txtMaHD.Text == "") || (txtMaHD.Text == null))
            {
                txtMaHD.Focus();
                return;
            }

            if (!Utilities.isDateTime(txtDate.Text))
            {
                txtDate.Focus();
                return;
            }            

            if (cbxDonvitinh.Text == "Ngay")
                ngaydaohan = cbxDateContracts.Value.AddDays(int.Parse(cbxKyhan.Text));
            else if (cbxDonvitinh.Text == "Thang")
                ngaydaohan = cbxDateContracts.Value.AddMonths(int.Parse(cbxKyhan.Text));
            else ngaydaohan = cbxDateContracts.Value.AddYears(int.Parse(cbxKyhan.Text));
            difference = ngaydaohan.Subtract(DateTime.Parse(txtDate.Text));

            if (difference.Days <= 0)
            {
                MessageBox.Show("Nhap sai ngay tra lan dau", "Loi vao du lieu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDate.Focus();
                return;
            }
            if (cbxDonVi.Text == "Ngay")
                kytrano = int.Parse(cbxKytra.Text);
            else if (cbxDonVi.Text == "Thang")
                kytrano = int.Parse(cbxKytra.Text) * 30;  //Trung binh mot thang co 30 ngay
            else kytrano = int.Parse(cbxKytra.Text) * 365; //Mot nam co 365 ngay
            
            solantra = difference.Days / kytrano;
            if ((solantra * kytrano) < difference.Days)
                solantra = solantra + 2;
            else solantra = solantra + 1;
            
            if (cbxLaisuat.Text == "")
            {
                cbxLaisuat.Focus();
                return;
            }
            laisuat = int.Parse(cbxLaisuat.Text);
            if (!Utilities.isInt64(txtTongtien.Text))
            {
                txtTongtien.Focus();
                return;
            }
            Sotien = Int64.Parse(txtTongtien.Text);

            ngayHD = cbxDateContracts.Value.ToShortDateString();
            //frmNhapTN.init(Sotien, ngaydaohan, cbxDateContracts.Value.ToShortDateString(), laisuat, solantra, int.Parse(cbxKytra.Text), txtDate.Text);
            if (cbxDonVi.Text == "Ngay")
            {
                frmNhapTN.init(Sotien, ngaydaohan.ToShortDateString(), ngayHD, laisuat, solantra, kytrano, txtDate.Text);
            }
            else if (cbxDonVi.Text == "Thang")
            {
                kytrano = int.Parse(cbxKytra.Text);
                frmNhapTN.init(Sotien, ngaydaohan.ToShortDateString(), ngayHD, laisuat, solantra, int.Parse(cbxKyhan.Text), txtDate.Text, false);
            }
            else
            {
                frmNhapTN.init(Sotien, ngaydaohan.ToShortDateString(), ngayHD, laisuat, solantra, int.Parse(cbxKyhan.Text), txtDate.Text, true);
            }
            frmNhapTN.ShowDialog();
        }

        private void cmdKytraShow_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                if (frmNhapTN.saved == false)
                    return;
                frmNhapTN.Set_Readonly();
                frmNhapTN.ShowDialog();
            }
        }

        private void cbxLaisuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tinhlai frmTinhLai = new Tinhlai();
            if (edit == false)
                return;
            else
            {
                if (cbxLaisuat.Text == laisuat.ToString())
                    return;
                frmTinhLai.init(dbfile, txtMaHD.Text, int.Parse(cbxLaisuat.Text));
                frmTinhLai.ShowDialog();
                if (frmTinhLai.saved == false)
                    cbxLaisuat.Text = laisuat.ToString();
            }
        }
    
    }
}