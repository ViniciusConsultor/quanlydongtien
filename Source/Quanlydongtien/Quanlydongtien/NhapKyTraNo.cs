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
        db CashDB;
        Int64 tongtien;
        int laisuat;
        string ngaytra;
        string ngayvay;
        string MaHD;
        Boolean tienra = false;
        public Boolean saved = false;
        public NhapKyTraNo()
        {
            InitializeComponent();
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
            Clear();
            Create_kytra(rows);
        }

        public void init(string dbname, Int64 sotien, string ngaydaohan, string mahd, string ngayhd, int laisuatvay)
        {
            CashDB = new db(dbname);
            txtTong.Text = sotien.ToString();
            tongtien = Math.Abs(sotien);
            ngaytra = ngaydaohan;
            ngayvay = ngayhd;
            this.laisuat = laisuatvay;
            if (sotien < 0)
                tienra = false;
            else tienra = true;
            Create_kytra(1);
        }

        private void Create_kytra(int rows)
        {
            DataGridViewTextBoxColumn texboxCol;
            CalendarColumn cldCol;
            DataGridViewTextBoxCell texboxCel;
            DataGridViewRow dtGridRow;
            int i;
            texboxCol = new DataGridViewTextBoxColumn();
            texboxCol.HeaderText = "Ngay tra no";
            texboxCol.Name = "Ngaytra";
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
            for (i = 0; i < rows - 1; i++)
            {
                dtGridRow = new DataGridViewRow();
                dtGridCF.Rows.Add(dtGridRow);
                dtGridCF.Rows[i].Cells["Ngaytra"].Value = "";
                dtGridCF.Rows[i].Cells["Sotien"].Value = "";
                dtGridCF.Rows[i].Cells["Tienlai"].Value = "";
            }
            dtGridRow = new DataGridViewRow();
            texboxCel = new DataGridViewTextBoxCell();
            texboxCel.Value = ngaytra;
            dtGridRow.Cells.Add(texboxCel);
            texboxCel = new DataGridViewTextBoxCell();
            texboxCel.Value = tongtien;
            dtGridRow.Cells.Add(texboxCel);
            dtGridCF.Rows.Add(dtGridRow);
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
            saved = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CashDB.close();
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
            }
            dtGridCell = dtGridCF.Rows[e.RowIndex].Cells["Sotien"];
            if (dtGridCell.Value != null)
            {
                if (!Utilities.isInt64(dtGridCell.Value.ToString()))
                {
                    dtGridCell.Value = "";
                    dtGridCF.CurrentCell = dtGridCell;
                    return;
                }
            }
            for (i = 0; i < dtGridCF.Rows.Count - 1; i++)
            {
                dtGridCell = dtGridCF.Rows[i].Cells["Sotien"];
                if (dtGridCell.Value == null)
                    continue;
                sotien = sotien + Int64.Parse(dtGridCell.Value.ToString());
            }
            dtGridCF.Rows[dtGridCF.Rows.Count - 1].Cells["Sotien"].Value = tongtien - sotien;
        }

        //Tinh cac ky tra lai cho khach hang
        private void Tinhlai(int row_i)
        {
            Int64 tongtien_i, tienlai;
            DateTime ngaytra;
            TimeSpan difference;
            int ngaychiulai;
            tongtien_i = TinhtienNrows(row_i - 1);
            if (dtGridCF.Rows[row_i].Cells["Ngaytra"].Value.ToString() == "")
                return;
            ngaytra = DateTime.Parse(dtGridCF.Rows[row_i].Cells["Ngaytra"].Value.ToString());
            difference = ngaytra.Subtract(DateTime.Parse(ngayvay));
            ngaychiulai = difference.Days;
            tienlai = ((tongtien - tongtien_i) * ngaychiulai * laisuat) / 36000;
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
    }
}