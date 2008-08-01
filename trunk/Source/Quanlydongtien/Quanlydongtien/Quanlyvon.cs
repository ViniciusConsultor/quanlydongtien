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
    public partial class Quanlyvon : Form
    {
        db CashDB;
        Int64 voncu;
        public Quanlyvon()
        {
            InitializeComponent();
        }

        private void Quanlyvon_Load(object sender, EventArgs e)
        {

        }
        public void init(string dbName)
        {
            string sqlStr;
            string matien, sotien;
            OleDbDataReader oleReader;
            CashDB = new db(dbName);
            sqlStr = "SELECT [Matien], [SoLuong] FROM [Tien]";
            oleReader = CashDB.genDataReader(sqlStr);
            if (oleReader == null)
                return;
            try
            {
                while (oleReader.Read())
                {
                    matien = oleReader["Matien"].ToString();
                    sotien = oleReader["SoLuong"].ToString();
                    if (matien == "TienVon")
                        txtTienvon.Text = sotien;
                    else if (matien == "Tienlai")
                        txtLai.Text = sotien;
                    else txtTienmat.Text = sotien;
                }
                voncu = Int64.Parse(txtTienvon.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            string sqlStr;
            Int64 vonmoi;
            Int64 tienmat;
            vonmoi = Int64.Parse(txtTienvon.Text);
            if (vonmoi != voncu)
            {
                sqlStr = "UPDATE [TIEN] SET [SoLuong] = " + txtTienvon.Text + " WHERE [Matien] = 'Tienvon'";
                CashDB.runSQLCmd(sqlStr);
                sqlStr = "UPDATE [DONGTIEN] SET [Sotien] = " + txtTienvon.Text + " WHERE [MaHD] = 'Tienvon'";
                CashDB.runSQLCmd(sqlStr);
                tienmat = Int64.Parse(txtTienmat.Text);
                tienmat = tienmat + (vonmoi - voncu);
                sqlStr = "UPDATE [TIEN] SET [SoLuong] = " + tienmat.ToString() + " WHERE [Matien] = 'TongTien'";
                CashDB.runSQLCmd(sqlStr);
            }
            CashDB.close();
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CashDB.close();
            this.Close();
        }


    }
}