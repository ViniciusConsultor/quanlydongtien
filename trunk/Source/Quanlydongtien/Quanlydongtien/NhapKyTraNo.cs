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
    public partial class NhapKyTraNo : Form
    {
        Int64 tongtien;
        db CashDB;
        int laisuat;
        string ngaytra;
        string ngayvay;
        Boolean tienra = false;
        public Boolean saved = false;
        public NhapKyTraNo()
        {
            InitializeComponent();
        }

        public NhapKyTraNo(string dbname)
        {
            InitializeComponent();
            CashDB = new db(dbname);
        }
        private void cmdSolan_Click(object sender, EventArgs e)
        {
            int rows;                        
            if (txtSolan.Text.Length == 0)
            {
                MessageBox.Show("Ban phai nhap so lan tra no!");
                txtSolan.Focus();
                return;

            }
            rows = int.Parse(txtSolan.Text);
            Create_kytra(rows);
        }

        public void init(string mahd, Boolean tienvay)
        {
            string sqlStrG, sqlStrL;

        }

        public void init(Int64 sotien, string ngaydaohan, string ngayhd, int laisuatvay)
        {
            txtTong.Text = sotien.ToString();
            tongtien = Math.Abs(sotien);
            ngaytra = ngaydaohan;
            ngayvay = ngayhd;
            lblLaisuat.Text = float.Parse(laisuatvay.ToString())/100 + " % Nam";
            this.laisuat = laisuatvay;
            if (sotien < 0)
                tienra = false;
            else tienra = true;
            Create_kytra(1);

            txtSolan.Enabled = true;
            cmdSolan.Enabled = true;
            dtGridCF.ReadOnly = false;
        }

        public void init(Int64 sotien, string ngaydaohan, string ngayhd, int laisuatvay, int solantra, int tansuat, string tralandau) //ngaytra: sau bao nhieu ngay se tra
        {
            Int64 tiengoc = 0;
            DateTime ngaytrano;
            Int64 tienlai = 0;
            Int64 tongtientra = 0;
            Int64 duno = 0;
            int i;
            lblLaisuat.Text = float.Parse(laisuatvay.ToString()) / 100 + " % Nam";
            txtTong.Text = sotien.ToString();
            tongtien = Math.Abs(sotien);
            ngaytra = ngaydaohan;
            ngayvay = ngayhd;
            laisuat = laisuatvay;
            txtSolan.Text = solantra.ToString();
            Create_kytra(solantra);
            tiengoc = sotien / solantra;
            duno = tongtien;
            dtGridCF.Rows[0].Cells["Ngaytra"].Value = tralandau;
            dtGridCF.Rows[0].Cells["Duno"].Value = duno;
            dtGridCF.Rows[0].Cells["Sotien"].Value = tiengoc;
            Tinhlai(0);
            tongtientra = Int64.Parse(dtGridCF.Rows[0].Cells["Tienlai"].Value.ToString()) + tiengoc;
            dtGridCF.Rows[0].Cells["Tongcong"].Value = tongtientra;
            ngaytrano = DateTime.Parse(tralandau);
            for (i = 1; i < dtGridCF.Rows.Count - 1; i++)
            {
                ngaytrano = ngaytrano.AddDays(tansuat);
                dtGridCF.Rows[i].Cells["Ngaytra"].Value = ngaytrano.ToShortDateString();
                dtGridCF.Rows[i].Cells["Sotien"].Value = tiengoc;
                Tinhlai(i);
                duno = duno - tiengoc;
                dtGridCF.Rows[i].Cells["Duno"].Value = duno;
                tongtientra = Int64.Parse(dtGridCF.Rows[i].Cells["Tienlai"].Value.ToString()) + tiengoc;
                dtGridCF.Rows[i].Cells["Tongcong"].Value = tongtientra;
            }
            dtGridCF.Rows[i].Cells["Ngaytra"].Value = ngaytra;
            Tinhlai(i);
            dtGridCF.Rows[i].Cells["Sotien"].Value = tongtien - tiengoc * i;
            dtGridCF.Rows[i].Cells["Duno"].Value = tongtien - tiengoc * i;
            tongtientra = Int64.Parse(dtGridCF.Rows[i].Cells["Tienlai"].Value.ToString()) + tiengoc;
            dtGridCF.Rows[i].Cells["Tongcong"].Value = tongtientra;

            txtSolan.Enabled = false;
            cmdSolan.Enabled = false;
            dtGridCF.ReadOnly = true;
        }

        public void init(Int64 sotien, string ngaydaohan, string ngayhd, int laisuatvay, int solantra, int tansuat, string tralandau, Boolean year)
        //year = true: tra theo nam; year = false tra theo thang
        {
            Int64 tiengoc = 0;
            DateTime ngaytrano;
            Int64 tienlai = 0;
            Int64 tongtientra = 0;
            Int64 duno = 0;
            int i;
            lblLaisuat.Text = float.Parse(laisuatvay.ToString()) / 100 + " % Nam";
            txtTong.Text = sotien.ToString();
            tongtien = Math.Abs(sotien);
            ngaytra = ngaydaohan;
            ngayvay = ngayhd;
            laisuat = laisuatvay;
            txtSolan.Text = solantra.ToString();
            Create_kytra(solantra);
            tiengoc = sotien / solantra;
            duno = tongtien;
            dtGridCF.Rows[0].Cells["Ngaytra"].Value = tralandau;
            dtGridCF.Rows[0].Cells["Duno"].Value = duno;
            dtGridCF.Rows[0].Cells["Sotien"].Value = tiengoc;
            Tinhlai(0);
            tongtientra = Int64.Parse(dtGridCF.Rows[0].Cells["Tienlai"].Value.ToString()) + tiengoc;
            dtGridCF.Rows[0].Cells["Tongcong"].Value = tongtientra;
            ngaytrano = DateTime.Parse(tralandau);
            for (i = 1; i < dtGridCF.Rows.Count - 1; i++)
            {
                if (year == true)
                    ngaytrano = ngaytrano.AddYears(tansuat);
                else ngaytrano = ngaytrano.AddMonths(tansuat);
                dtGridCF.Rows[i].Cells["Ngaytra"].Value = ngaytrano.ToShortDateString();
                dtGridCF.Rows[i].Cells["Sotien"].Value = tiengoc;
                Tinhlai(i);
                duno = duno - tiengoc;
                dtGridCF.Rows[i].Cells["Duno"].Value = duno;
                tongtientra = Int64.Parse(dtGridCF.Rows[i].Cells["Tienlai"].Value.ToString()) + tiengoc;
                dtGridCF.Rows[i].Cells["Tongcong"].Value = tongtientra;
            }
            dtGridCF.Rows[i].Cells["Ngaytra"].Value = ngaytra;
            Tinhlai(i);
            dtGridCF.Rows[i].Cells["Sotien"].Value = tongtien - tiengoc * i;
            dtGridCF.Rows[i].Cells["Duno"].Value = tongtien - tiengoc * i;
            tongtientra = Int64.Parse(dtGridCF.Rows[i].Cells["Tienlai"].Value.ToString()) + tiengoc;
            dtGridCF.Rows[i].Cells["Tongcong"].Value = tongtientra;

            txtSolan.Enabled = false;
            cmdSolan.Enabled = false;
            dtGridCF.ReadOnly = true;
        }

        public void init(Int64 sotien, string ngaydaohan, string ngayhd, int laisuatvay, Boolean tramotlan)
        {
            txtTong.Text = sotien.ToString();
            tongtien = Math.Abs(sotien);
            ngaytra = ngaydaohan;
            ngayvay = ngayhd;
            lblLaisuat.Text = float.Parse(laisuatvay.ToString()) / 100 + " % Nam";
            txtSolan.Text = "1";
            this.laisuat = laisuatvay;
            if (sotien < 0)
                tienra = false;
            else tienra = true;
            Create_kytra(1);
            dtGridCF.Rows[0].Cells["Sotien"].Value = tongtien;
            Tinhlai(0);
            dtGridCF.Rows[0].Cells["Tongcong"].Value = tongtien + Int64.Parse(dtGridCF.Rows[0].Cells["Tienlai"].Value.ToString());
            txtSolan.Enabled = false;
            cmdSolan.Enabled = false;
            dtGridCF.ReadOnly = true; ;
        }
        private void Create_kytra(int rows)
        {
            DataGridViewTextBoxColumn texboxCol;
            DataGridViewTextBoxCell texboxCel;
            DataGridViewRow dtGridRow;
            int i;
            Clear();
            texboxCol = new DataGridViewTextBoxColumn();
            texboxCol.HeaderText = "Ngay tra no";
            texboxCol.Name = "Ngaytra";
            dtGridCF.Columns.Add(texboxCol);
            texboxCol = new DataGridViewTextBoxColumn();
            texboxCol.HeaderText = "Du no";
            texboxCol.Name = "Duno";
            texboxCol.ReadOnly = true;
            dtGridCF.Columns.Add(texboxCol);
            texboxCol = new DataGridViewTextBoxColumn();
            texboxCol.HeaderText = "So tien tra goc";
            texboxCol.Name = "Sotien";
            dtGridCF.Columns.Add(texboxCol);
            texboxCol = new DataGridViewTextBoxColumn();
            texboxCol.HeaderText = "Tien lai";
            texboxCol.Name = "Tienlai";
            texboxCol.ReadOnly = true;
            dtGridCF.Columns.Add(texboxCol);
            texboxCol = new DataGridViewTextBoxColumn();
            texboxCol.HeaderText = "Tong cong";
            texboxCol.Name = "Tongcong";
            texboxCol.ReadOnly = true;
            dtGridCF.Columns.Add(texboxCol);
            for (i = 0; i < rows - 1; i++)
            {
                dtGridRow = new DataGridViewRow();
                dtGridCF.Rows.Add(dtGridRow);
                dtGridCF.Rows[i].Cells["Ngaytra"].Value = "";
                dtGridCF.Rows[i].Cells["Duno"].Value = "";
                dtGridCF.Rows[i].Cells["Sotien"].Value = "0";
                dtGridCF.Rows[i].Cells["Tienlai"].Value = "0";
                dtGridCF.Rows[i].Cells["Tongcong"].Value = "0";
            }
            dtGridRow = new DataGridViewRow();
            texboxCel = new DataGridViewTextBoxCell();
            texboxCel.Value = ngaytra;
            dtGridRow.Cells.Add(texboxCel);

            texboxCel = new DataGridViewTextBoxCell();
            texboxCel.Value = tongtien;
            dtGridRow.Cells.Add(texboxCel);

            texboxCel = new DataGridViewTextBoxCell();
            texboxCel.Value = tongtien;
            dtGridRow.Cells.Add(texboxCel);

            dtGridRow.ReadOnly = true;
            dtGridCF.Rows.Add(dtGridRow);
            dtGridCF.Rows[i].Cells["Tienlai"].Value = "0";
            dtGridCF.Rows[i].Cells["Tongcong"].Value = "0";
        }

        private void Clear()
        {
            while (dtGridCF.Rows.Count > 1)
            {
                dtGridCF.Rows.RemoveAt(dtGridCF.Rows.Count - 2);
            }
            while (dtGridCF.ColumnCount > 0)
                dtGridCF.Columns.RemoveAt(dtGridCF.ColumnCount - 1);
        }

        private void txtSolan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtSolan.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ban nhap khong phai gia tri so \n Hoac gia tri qua lon");
                txtSolan.Focus();
                return;
            }
        }

        private void dtGridCF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

        }

        private void NhapKyTraNo_Load(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click_1(object sender, EventArgs e)
        {
            int i;
            Int64 tientra;
            
            for (i = 0; i < dtGridCF.Rows.Count - 1; i++)
                if (dtGridCF.Rows[i].Cells["Ngaytra"].Value.ToString() == "")
                {
                    MessageBox.Show("Ban phai nhap day du cac ky tra no", "Loi vao du lieu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            saved = true;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            saved = false;
            this.Close();
        }

        private void dtGridCF_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void dtGridCF_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell dtGridCell;
            Int64 sotien = 0;
            int i;
            Int64 tientra;
            if (dtGridCF.SelectedCells.Count == 0)
                return;
            if (dtGridCF.Columns[e.ColumnIndex].Name != "Sotien")
            {
                dtGridCell = dtGridCF.Rows[e.RowIndex].Cells["Ngaytra"];
                if (dtGridCell.Value == null)
                    return;
                if (!Utilities.isDateTime(dtGridCell.Value.ToString()))
                {
                    dtGridCell.Value = "";
                    dtGridCF.CurrentCell = dtGridCell;
                    return;
                }
                if (DateTime.Parse(ngayvay) > DateTime.Parse(dtGridCell.Value.ToString()) || DateTime.Parse(dtGridCell.Value.ToString()) > DateTime.Parse(ngaytra))
                {
                    dtGridCell.Value = "";
                    dtGridCF.CurrentCell = dtGridCell;
                    return;
                }
            }
            dtGridCell = dtGridCF.Rows[e.RowIndex].Cells["Sotien"];
            if (dtGridCell.Value != null)
            {
                if (!Utilities.isInt64(dtGridCell.Value.ToString()))
                {
                    dtGridCell.Value = "0";
                    dtGridCF.CurrentCell = dtGridCell;
                    return;
                }
                if ((Int64.Parse(dtGridCell.Value.ToString()) > tongtien) || (Int64.Parse(dtGridCell.Value.ToString()) < 0))
                {
                    dtGridCell.Value = "0";
//                    dtGridCF.CurrentCell = dtGridCell;
                    return;
                }
            }
            for (i = 0; i < dtGridCF.Rows.Count - 1; i++)
            {
                dtGridCell = dtGridCF.Rows[i].Cells["Sotien"];
                if (dtGridCell.Value == null)
                    continue;
                if (dtGridCell.Value.ToString() == "")
                    continue;
                dtGridCF.Rows[i].Cells["Duno"].Value = tongtien - sotien;
                sotien = sotien + Int64.Parse(dtGridCell.Value.ToString());
                Tinhlai(i);
                tientra = Int64.Parse(dtGridCell.Value.ToString()) + Int64.Parse(dtGridCF.Rows[i].Cells["Tienlai"].Value.ToString());
                dtGridCF.Rows[i].Cells["Tongcong"].Value = tientra;
            }
            dtGridCF.Rows[dtGridCF.Rows.Count - 1].Cells["Sotien"].Value = tongtien - sotien;
            dtGridCF.Rows[dtGridCF.Rows.Count - 1].Cells["Duno"].Value = tongtien - sotien;
            Tinhlai(dtGridCF.Rows.Count - 1);
            tientra = Int64.Parse(dtGridCell.Value.ToString()) + Int64.Parse(dtGridCF.Rows[i].Cells["Tienlai"].Value.ToString());
            dtGridCF.Rows[i].Cells["Tongcong"].Value = tientra;
        }

        //Tinh cac ky tra lai cho khach hang
        private void Tinhlai(int row_i)
        {
            Int64 tongtien_i, tienlai;
            DateTime ngaytra;
            TimeSpan difference;
            int ngaychiulai;
            tongtien_i = TinhtienNrows(row_i);
            if (dtGridCF.Rows[row_i].Cells["Ngaytra"].Value.ToString() == "")
                return;
            ngaytra = DateTime.Parse(dtGridCF.Rows[row_i].Cells["Ngaytra"].Value.ToString());
            difference = ngaytra.Subtract(DateTime.Parse(ngayvay));
            ngaychiulai = difference.Days;
            tienlai = ((tongtien - tongtien_i) * ngaychiulai * laisuat) / (360 * 100 *100);
            dtGridCF.Rows[row_i].Cells["Tienlai"].Value = tienlai;
        }

        //Tinh tong so tien cua n hang
        private Int64 TinhtienNrows(int rows)
        {
            int i;
            Int64 sotien = 0;
            for (i = 0; i < rows; i++)
            {
                if ((dtGridCF.Rows[i].Cells["Sotien"].Value != null))
                    sotien = sotien + Int64.Parse((dtGridCF.Rows[i].Cells["Sotien"].Value.ToString()));
            }
            return sotien;
        }

        public void Set_Readonly()
        {
            cmdSolan.Enabled = false;
            cmdClose.Enabled = false;
            txtSolan.Enabled = false;
            txtTong.Enabled = false;
            dtGridCF.ReadOnly = true;
        }


        public void Save_Data(Boolean real, string MaHD, string dbname, Boolean chovay, int laisuat)
        {
            string sqlStrG, sqlStrL;
            string tientraG, tientraL;
            string ngaytra;
            int i;
            CashDB = new db(dbname);
            for (i = 0; i < dtGridCF.Rows.Count; i++)
            {
                ngaytra = dtGridCF.Rows[i].Cells["Ngaytra"].Value.ToString();
                tientraG = dtGridCF.Rows[i].Cells["Sotien"].Value.ToString();
                tientraL = dtGridCF.Rows[i].Cells["Tienlai"].Value.ToString();
                if (chovay == false)
                {
                    tientraG = "-" + tientraG;
                    tientraL = "-" + tientraL;
                }
                sqlStrG = "INSERT INTO [DONGTIEN] ([MaHD], [NoQH], [Datra], [Real], [MoTa], [Sotien], [NgayTra]) ";
                sqlStrG = sqlStrG + "VALUES ('" + MaHD +"', No, No, " + real.ToString() + ", 'Tra goc ky " + (i+1).ToString();
                sqlStrG = sqlStrG + "', " + tientraG + ", '" + ngaytra + "')";

                sqlStrL = "INSERT INTO [TIENLAI] ([MaHD], [NoQH], [Datra], [Real], [MoTa], [Sotienlai], [NgayTra], [Tienchiulai], [Laisuat])";
                sqlStrL = sqlStrL + "VALUES ('" + MaHD + "', 0, No, " + real.ToString() + ", 'Tra lai ky " + (i+1).ToString();
                sqlStrL = sqlStrL + "', " + tientraL + ", '" + ngaytra + "', " + dtGridCF.Rows[i].Cells["Duno"].Value.ToString();
                sqlStrL = sqlStrL + ", " + laisuat + ")";
                CashDB.runSQLCmd(sqlStrG);
                CashDB.runSQLCmd(sqlStrL);
            }
            CashDB.close();
        }
    }
}