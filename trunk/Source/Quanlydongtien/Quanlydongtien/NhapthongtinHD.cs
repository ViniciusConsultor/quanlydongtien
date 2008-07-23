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
        db contractDb;

        public NhapthongtinHD()
        {
            InitializeComponent();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {

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
            if (contractDb == null)
            {
                MessageBox.Show("Loi ket noi den database");
                this.Close();
            }
            sqlStr = "SELECE [MaKH] FROM [KHACHHANG]";
            try
            {
                oleReader = contractDb.genDataReader(sqlStr);
                while (oleReader.Read())
                    
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
    }
}