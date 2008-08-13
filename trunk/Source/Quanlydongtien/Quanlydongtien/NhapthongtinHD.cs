using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using Microsoft.Office.Interop.Word;

namespace Quanlydongtien
{
    public partial class NhapthongtinHD : Form
    {
        const int TraDinhKy = 1;
        const int TraNhieuLan = 2;
        const int TraMotLan = 3;
        int laisuat;
        string oldLS;
        string dirWork;
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
            double phiuythac;
            chovay = false;
            if (Check_Data() == false)
                return;
            if (check_validate() == false)
                return;
            if (cbxLoaiHD.Text == "Cho Vay")
            {
                tongtien = "-" + txtTongtien.Text;
                chovay = true;
            }
            else tongtien = txtTongtien.Text;
            real = !chkReal.Checked;
            laisuat = (int)(float.Parse(cbxLaisuat.Text) * 100);
            if (edit == true)
            {
                
                sqlStr = "UPDATE [HOPDONG] SET [Real] = " + real.ToString();
                sqlStr = sqlStr + ", [DESC] = '" + txtDesc.Text + "', [Laisuat] = " + cbxLaisuat.Text + " WHERE [MaHD] = '" + MaHD + "'";
                contractDb.runSQLCmd(sqlStr);
                sqlStr = "UPDATE [DONGTIEN] SET [Real] = " + real.ToString() + "WHERE [MaHD] ='" + MaHD + "'";
                contractDb.runSQLCmd(sqlStr);
                
                sqlStr = "UPDATE [TIENLAI] SET [Real] = " + real.ToString() + "WHERE [MaHD] ='" + MaHD + "'";
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
                sqlStr = sqlStr + "', " + laisuat.ToString() + ", '" + txtDesc.Text;
                sqlStr = sqlStr + "', No, No, No, " + HTTra + ")";
                if (contractDb.runSQLCmd(sqlStr) == false)
                    return;
                sqlStr = "INSERT INTO [DONGTIEN] ([MaHD], [NoQH], [Datra], [Real], [MoTa], [Sotien], [NgayTra]) VALUES (";
                sqlStr = sqlStr + "'" + txtMaHD.Text + "', No, No, " + real.ToString() + ", '" + txtDesc.Text + "', ";
                sqlStr = sqlStr + tongtien + ", '" + cbxDateContracts.Value.ToShortDateString() + "')";
                if (contractDb.runSQLCmd(sqlStr) == false)
                    return;
                if (!Utilities.isDouble(txtPhiUT.Text))
                {
                    MessageBox.Show("Ban phai nhap lai thong tin ve " + lblUythac.Text);
                    txtPhiUT.Focus();
                    return;
                }
                phiuythac = double.Parse(txtPhiUT.Text);
                frmNhapTN.Save_Data(real, txtMaHD.Text, dbfile, chovay, laisuat, phiuythac);                
                contractDb.close();
                this.Close();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            contractDb.close();
        }

        public Boolean init(string dbname, string workingdir)
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
            dirWork = workingdir;
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
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                contractDb.close();
                this.Close();
                return false;
            }
        }
        public void init(string dbname, string maHD, string workingdir)
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
            cmdKytraShow.Enabled = false;
            frmNhapTN = new NhapKyTraNo(dbname);
            frmNhapTN.saved = false;
            cmdViewContracts.Enabled = true;
            cmdViewContracts.Visible = true;
            dirWork = workingdir;
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
                    cbxLaisuat.Text = float.Parse(laisuat.ToString()) / 100 + "";
                    oldLS = cbxLaisuat.Text;
//                    cbxLaisuat.Enabled = false;
                }             
                if (chkReal.Checked == false)
                    chkReal.Enabled = false;
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
//                cbxMaKH.Text = cbxMaKH.Items[0].ToString();
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
            if (cbxLoaiHD.Text == "Cho vay")
                lblUythac.Text = "Phi cho vay";
            else lblUythac.Text = "Phi uy thac";
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
                optTraNL.Checked = false;
                return;
            }
            if (cbxKyhan.Text == "")
            {
                cbxKyhan.Focus();
                optTraNL.Checked = false;
                return;
            }
            kyhan = int.Parse(cbxKyhan.Text);
            if (cbxLaisuat.Text == "")
            {
                cbxLaisuat.Focus();
                optTraNL.Checked = false;
                return;
            }

            if (!Utilities.isFloat(cbxLaisuat.Text))
            {
                cbxLaisuat.Focus();
                optTraNL.Checked = false;
                return;
            }
            laisuat = (int)(double.Parse(cbxLaisuat.Text) * 100);
            if (txtTongtien.Text == "")
            {
                txtTongtien.Focus();
                optTraNL.Checked = false;
                return;
            }
            if (!Utilities.isInt64(txtTongtien.Text))
            {
                txtTongtien.Focus();
                optTraNL.Checked = false;
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
            if (frmNhapTN.saved == true)
                cmdAccept.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DateTime ngayHD;
            Int64 tongtien;
            int kyhan;
            int laisuat;
            string ngaydaohan;
            if (radioButton1.Checked == false)
                return;
            if (txtMaHD.Text == null)
            {
                txtMaHD.Focus();
                radioButton1.Checked = false;
                return;
            }
            if (cbxKyhan.Text == "")
            {
                cbxKyhan.Focus();
                radioButton1.Checked = false;
                return;
            }
            kyhan = int.Parse(cbxKyhan.Text);
            if (cbxLaisuat.Text == "")
            {
                cbxLaisuat.Focus();
                radioButton1.Checked = false;
                return;
            }

            if (!Utilities.isFloat(cbxLaisuat.Text))
            {
                cbxLaisuat.Focus();
                radioButton1.Checked = false;
                return;
            }
            laisuat = (int)(double.Parse(cbxLaisuat.Text) * 100);
            if (txtTongtien.Text == "")
            {
                txtTongtien.Focus();
                radioButton1.Checked = false;
                return;
            }
            if (!Utilities.isInt64(txtTongtien.Text))
            {
                txtTongtien.Focus();
                radioButton1.Checked = false;
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
            if (frmNhapTN.saved == true)
                cmdAccept.Enabled = true;
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
            {
                lblContractCode.Text = "";
                return;
            }
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
            {                
                return false;
            }
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
            laisuat = (int)(double.Parse(cbxLaisuat.Text) * 100);
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
            cmdAccept.Enabled = frmNhapTN.saved;
        }

        private void cmdKytraShow_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                if (frmNhapTN.saved == false)
                    return;
                frmNhapTN.Set_Readonly();
                frmNhapTN.ShowDialog();
                cmdViewContracts.Enabled = true;

                cmdViewContracts.Visible = true;
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
                else
                {
                    cmdClose.Enabled = false;
                }
            }
        }

        private void cbxLaisuat_Leave(object sender, EventArgs e)
        {
            Tinhlai frmTinhLai = new Tinhlai();
            int laimoi;
            if (edit == false)
                return;
            else
            {
                if (cbxLaisuat.Text == oldLS)
                    return;
                laimoi = (int)(double.Parse(cbxLaisuat.Text) * 100);
                frmTinhLai.init(dbfile, txtMaHD.Text, laimoi);
                frmTinhLai.ShowDialog();
                if (frmTinhLai.saved == false)
                    cbxLaisuat.Text = laisuat.ToString();
            }
        }

        private Boolean Check_Data()
        {
            try
            {
                if (txtMaHD.Text.Length == 0)
                {
                    MessageBox.Show("Ban phai nhap ma hop dong!");
                    txtMaHD.Focus();
                    return false;
                }

                if (cbxLoaiHD.Text.Length == 0)
                {
                    MessageBox.Show("Ban phai nhap loai hop dong");
                    cbxLoaiHD.Focus();
                    return false;
                }


                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        private void cmdViewContracts_Click(object sender, EventArgs e)
        {
            string sotien;
            string benvay;
            string identi, ngaycap, noicap, soDT, Diachi, BankAccount, BankName;
            string makh, ngayhd, kyhan, laisuat, mahd;
            string sqlStr, strDate;
            int maloaiKH, length, i;
            object sourcefile;
            object destfile;
            DateTime ngaydaohan;
            OleDbDataReader oleReader;
            ApplicationClass word = new ApplicationClass();
            Document doc = new Document();

            if (cbxDonvitinh.Text == "Ngay")
                ngaydaohan = cbxDateContracts.Value.AddDays(int.Parse(cbxKyhan.Text));
            else if (cbxDonvitinh.Text == "Thang")
                ngaydaohan = cbxDateContracts.Value.AddMonths(int.Parse(cbxKyhan.Text));
            else ngaydaohan = cbxDateContracts.Value.AddYears(int.Parse(cbxKyhan.Text));

            System.Diagnostics.Process Proc = new System.Diagnostics.Process();
            makh = cbxMaKH.Text;
            ngayhd = cbxDateContracts.Value.ToShortDateString();
            kyhan = cbxKyhan.Text;
            laisuat = cbxLaisuat.Text;
            sotien = txtTongtien.Text;
            length = sotien.Length;
            benvay = "";
            Diachi = "";
            soDT = "";
            ngaycap = "";
            identi = "";
            BankAccount = "";
            BankName = "";
            mahd = txtMaHD.Text.Replace("\\", "_");
            mahd = mahd.Replace("/", "_");
            mahd = mahd.Replace(":", "_");
            strDate = cbxDateContracts.Value.ToShortDateString().Replace("/", "_");
            i = 1;
            while (3*i < length)
            {
                sotien = sotien.Insert(length - 3*i, ".");
                i++;
            }
            sqlStr = "SELECT [TenKH], [DinhDanh], FORMAT([Ngaycap], 'dd/mm/yyyy') AS Ngaycap, [Noicap], [SoDT], [Diachi], [TaikhoanNH], [TenNH], [MaLoaiKH] FROM [KHACHHANG] WHERE [MaKH] = '" + makh + "'";
            maloaiKH = 0;
            try
            {
                oleReader = contractDb.genDataReader(sqlStr);
                if (oleReader.Read())
                {
                    benvay = oleReader["TenKH"].ToString();
                    identi = oleReader["Dinhdanh"].ToString();
                    ngaycap = oleReader["Ngaycap"].ToString();
                    noicap = oleReader["Noicap"].ToString();
                    soDT = oleReader["SoDT"].ToString();
                    Diachi = oleReader["Diachi"].ToString();
                    BankAccount = oleReader["TaikhoanNH"].ToString();
                    BankName = oleReader["TenNH"].ToString();
                    maloaiKH = int.Parse(oleReader["MaLoaiKH"].ToString());
                    benvay = benvay.Replace(" ", "");
                }
            }
            catch (Exception ex)
            {
                return;
            }

            //Ghi hop dong ra file
            if (cbxLoaiHD.Text == "Cho vay")
            {
                if (maloaiKH == 1)
                    //Khach hang doanh nghiep
                    //sourcefile = @"E:\Project\SVN\quanlydongtien\Source\Quanlydongtien\Quanlydongtien\bin\Temp\Hopdong\Khachhangdoanhnghiep.doc";
                    sourcefile = @dirWork + "\\Temp\\Hopdong\\Chovay\\Khachhangdoanhnghiep.doc";
                else
                    //Khach hang ca nhan
                    sourcefile = @dirWork + "\\Temp\\Hopdong\\Chovay\\Khachhangcanhan.doc";
            }
            else
            {
                if (maloaiKH == 1)
                    sourcefile = @dirWork + @"\Temp\Hopdong\Huydong\Khachhangdoanhnghiep.doc";
                else sourcefile = @dirWork + @"\Temp\Hopdong\Huydong\Khachhangcanhan.doc";
            }

            if (maloaiKH == 1)
                destfile = @dirWork + @"\Contracts\Chovay\" + mahd + "_" + strDate + ".doc";
            else destfile = @dirWork + @"\Contracts\Huydong\" + mahd + "_" + strDate + ".doc"; ;
            object missing = Type.Missing;

            try
            {
                doc = word.Documents.Open(ref sourcefile, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                doc.Activate();
                if (!Utilities.Replace_String_In_Word_File(ref doc, "#TEN KHACH HANG#", benvay))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                    return;
                    //doc.SaveAs(ref destfile, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Dia chi khach hang#", Diachi))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }
                
                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Dien thoai#", soDT))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);                    
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Tong so tien#", sotien))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);                    
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Laisuat#", laisuat))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Thoihan#", kyhan))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Donvi#", cbxDonvitinh.Text))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Ngayhopdong#", cbxDonvitinh.Text))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Ngaydaohan#", ngaydaohan.ToShortDateString()))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Phiuythacvon#", txtPhiUT.Text))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "#Account Numver#", BankAccount))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }

                if (!Utilities.Replace_String_In_Word_File(ref doc, "##Bank Name##", BankName))
                {
                    doc.Close(ref missing, ref missing, ref missing);
                    word.Application.Quit(ref missing, ref missing, ref missing);
                }

                doc.SaveAs(ref destfile, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                doc.Close(ref missing, ref missing, ref missing);
                word.Application.Quit(ref missing, ref missing, ref missing);
                Proc.StartInfo.FileName = @"WINWORD.EXE";
                Proc.StartInfo.Arguments = destfile.ToString();
                Proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                doc.Close(ref missing, ref missing, ref missing);
                word.Application.Quit(ref missing, ref missing, ref missing);
            }
        }

        private void txtTongtien_Leave(object sender, EventArgs e)
        {
            txtTongtien.Text = txtTongtien.Text.Replace(".", "");
            txtTongtien.Text = txtTongtien.Text.Replace(",", "");
        }
    
    }
}