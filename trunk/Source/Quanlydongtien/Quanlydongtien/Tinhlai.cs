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
    public partial class Tinhlai : Form
    {
        db CashDB;
        public Boolean saved = false;
        public Tinhlai()
        {
            InitializeComponent();
        }

        private void Tinhlai_Load(object sender, EventArgs e)
        {

        }

        public void init(string dbname, string mahd, int laisuat)
        {
            CashDB = new db(dbname);
            txtMaHD.Text = mahd;
            txtLaisuat.Text = laisuat.ToString();
            dtGridCF.AllowUserToAddRows = false;
            Tinhlailai();
            dtGridCF.ReadOnly = true;
        }

        private void Tinhlailai()
        {
            string sqlStr;
            Int64 ngaychiulai, laicu, laimoi;
            Int64 tienchiulai, sotienlai;
            OleDbDataReader oleReader;
            int rows;
            sqlStr = "SELECT [MaDT], [Sotienlai], [NgayTra], [Tienchiulai], [Laisuat] FROM [TIENLAI] WHERE";
            sqlStr = sqlStr + "[MaHD] = '" + txtMaHD.Text + "' AND [Datra] = No AND [Noquahan] = 0";
            oleReader = CashDB.genDataReader(sqlStr);
            if (oleReader == null)
                this.Close();
            rows = 0;
            laimoi = int.Parse(txtLaisuat.Text);
            while (oleReader.Read())
            {
                dtGridCF.Rows.Add();
                dtGridCF.Rows[rows].Cells["MaDongTien"].Value = oleReader["MaDT"].ToString();
                dtGridCF.Rows[rows].Cells["Ngaytra"].Value = oleReader["NgayTra"].ToString();
                laicu = Int64.Parse(oleReader["Laisuat"].ToString());
                tienchiulai = Int64.Parse(oleReader["Tienchiulai"].ToString());
                sotienlai = Int64.Parse(oleReader["Sotienlai"].ToString());
                ngaychiulai = (sotienlai * 360 * 100) / (tienchiulai * laicu);
                sotienlai = (tienchiulai * laimoi) / (360 * 100);
                dtGridCF.Rows[rows].Cells["Tienlai"].Value = sotienlai;
                rows++;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string sqlStr;
            int i;
            for (i = 0; i < dtGridCF.Rows.Count; i++)
            {
                sqlStr = "UPDATE [LAISUAT] SET [Sotienlai] = " + dtGridCF.Rows[i].Cells["Tienlai"].Value.ToString();
                sqlStr = ", [Laisuat] = " + txtLaisuat.Text + "WHERE [MaDT] = " + dtGridCF.Rows[i].Cells["MaDongTien"].Value.ToString();
                CashDB.runSQLCmd(sqlStr);
            }
            saved = true;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            saved = false;
            CashDB.close();
            this.Close();
        }
    }
}