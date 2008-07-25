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
        string ngaytra;
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

        public void init(string dbname, Int64 sotien, string ngaydaohan)
        {
            CashDB = new db(dbname);
            txtTong.Text = sotien.ToString();
            tongtien = sotien;
            ngaytra = ngaydaohan;
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
            for (i = 0; i < rows - 1; i++)
            {
                dtGridRow = new DataGridViewRow();
                dtGridCF.Rows.Add(dtGridRow);
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

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CashDB.close();
            this.Close();
        }

        private void dtGridCF_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
             
        }
    }
}