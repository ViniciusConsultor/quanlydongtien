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
    public partial class Dongtiennam : Form
    {
        db CashDB;
        Boolean realdata;
        public Dongtiennam()
        {
            InitializeComponent();
        }

        private void Dongtiennam_Load(object sender, EventArgs e)
        {
            
        }

        public void init(string dbname)
        {
            string sqlStrRG, sqlStrRL;
            string sqlStrVL, sqlStrVG;
            OleDbDataReader oleReaderG, oleReaderL;
            CashDB = new db(dbname);
            try
            {
                sqlStrVG = "SELECT sum ([Sotien]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [DONGTIEN] WHERE [SOTIEN] > 0 GROUP FORMAT([Ngaytra], 'mm')";
                sqlStrVL = "SELECT sum ([Sotienlai]) AS Tien, FORMAT([ngaytra], 'yyyy') AS Nam from [TIENLAI] WHERE [Sotienlai] > 0 GROUP FORMAT([Ngaytra], 'mm')";
                oleReaderG = CashDB.genDataReader(sqlStrVG);
                oleReaderL = CashDB.genDataReader(sqlStrVL);
            }
            catch (Exception ex)
            {
            }
        }

        private void chkReal_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}