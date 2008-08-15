using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.OleDb;

namespace Quanlyloinhuan
{
    public partial class Form1 : Form
    {
        string dbFileName;
        db userdb;
        Int64 tienvon;
        string workingdir;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sqlStr;
            OleDbDataReader oleReader;
            config();
            userdb = new db(dbFileName);
            sqlStr = "SELECT [SoLuong] FROM [TIEN] WHERE [MaTien] = 'TienVon'";
            oleReader = userdb.genDataReader(sqlStr);
            if (oleReader.Read())
                tienvon = Int64.Parse(oleReader["SoLuong"].ToString());
            create_dtGrid();
            FillDG();
        }

        private void config()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement root;
            XmlNode xNode;
            xmldoc.Load("..\\config\\conf.xml");
            root = xmldoc.DocumentElement;
            xNode = root.SelectSingleNode("/config/dbFile").FirstChild;
            dbFileName = xNode.OuterXml.Trim();

            xNode = root.SelectSingleNode("/config/workingdir").FirstChild;
            workingdir = xNode.OuterXml.Trim();
        }

        private void FillDG()
        {
            string sqlStr;
            OleDbDataReader oleReader;
            double tysuat;
            int nam;
            int i;
            Int64 loinhuan;
            if (chkReal.Checked == true)
            {
                sqlStr = "SELECT SUM([Soluong]) AS Loinhuan, [Nam] FROM [LOINHUAN] GROUP BY [NAM] ORDER BY [NAM]";
            }
            else
            {
                sqlStr = "SELECT SUM([Soluong]) AS Loinhuan, [Nam] FROM [LOINHUANGIADINH] GROUP BY [NAM] ORDER BY [NAM]";
            }
            oleReader = userdb.genDataReader(sqlStr);

            try
            {
                while (oleReader.Read())
                {
                    nam = int.Parse(oleReader["Nam"].ToString());
                    loinhuan = Int64.Parse(oleReader["Loinhuan"].ToString());
                    if (tienvon != 0)
                        tysuat = (double)(Math.Round((decimal)(loinhuan * 100 / tienvon), 2));
                    else tysuat = 0;
                    for (i =0; i < dtGridProfit.Rows.Count; i++)
                        if (dtGridProfit.Rows[i].Cells["Nam"].Value.ToString() == nam.ToString())
                        {
                            dtGridProfit.Rows[i].Cells["Loinhuan"].Value = loinhuan;
                            dtGridProfit.Rows[i].Cells["Tienvon"].Value = tienvon;
                            dtGridProfit.Rows[i].Cells["Tysuat"].Value = tysuat;
                            if (loinhuan < 0)
                                dtGridProfit.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            else dtGridProfit.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                            break;
                        }
                }
              
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private Boolean create_dtGrid()
        {
            string sqlStr;
            int minyear, maxyear;
            string fieldname;
            int i;
            OleDbDataReader oleReader;
            sqlStr = "SELECT Min(Format(NgayTra,'yyyy')) AS Minyear, Max(Format(NgayTra,'yyyy')) AS Maxyear FROM Dongtien";
            oleReader = userdb.genDataReader(sqlStr);
            try
            {
                if (oleReader == null)
                    return false;
                else
                {
                    if (oleReader.Read())
                    {
                        minyear = int.Parse(oleReader["Minyear"].ToString());
                        maxyear = int.Parse(oleReader["Maxyear"].ToString());
                    }
                    else return false;
                    i = minyear;
                    while (i <= maxyear)
                    {
                        dtGridProfit.Rows.Add();
                        dtGridProfit.Rows[i - minyear].Cells["Nam"].Value = i.ToString();
                        dtGridProfit.Rows[i - minyear].Cells["Loinhuan"].Value = "0";
                        dtGridProfit.Rows[i - minyear].Cells["Tienvon"].Value = "0";
                        dtGridProfit.Rows[i - minyear].Cells["Tysuat"].Value = "0";
                        i++;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private void dtGridProfit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nam;
            string sqlStr;
            int i;
            try
            {
                nam = dtGridProfit.Rows[e.RowIndex].Cells["Nam"].Value.ToString();
                lblNam.Text = nam;
                if (chkReal.Checked)
                {
                    sqlStr = "SELECT [Thang], [Soluong] AS Loinhuan FROM [LOINHUAN] WHERE [Nam] = " + nam;
                }
                else
                    sqlStr = "SELECT [Soluong] AS Loinhuan, [Thang] FROM [LOINHUAN] WHERE [Nam] = " + nam;
                sqlStr = sqlStr + " ORDER BY [Thang]";
                clear_DataGrid(dtGridProMonth);
                if (dtGridProMonth.Columns.Count > 0)
                {
                    dtGridProMonth.Columns.RemoveAt(1);
                    dtGridProMonth.Columns.RemoveAt(0);
                }
                userdb.fillDtGridView(sqlStr, dtGridProMonth);
                for (i = 0; i < dtGridProMonth.Rows.Count; i++)
                {
                    Int64 loinhuan;
                    loinhuan = Int64.Parse(dtGridProMonth.Rows[i].Cells["Loinhuan"].Value.ToString());
                    if (loinhuan <= 0)
                        dtGridProMonth.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    else dtGridProMonth.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = @workingdir + @"\Baocao\Loinhuan\" + "Loinhuan.xls";
            Utilities.Export_To_Excel(dtGridProfit, filename, "Loinhuan");
        }

        private void cmdLoiNhuanThang_Click(object sender, EventArgs e)
        {
            string filename;
            string sheetName;
            filename = @workingdir + @"\Baocao\Loinhuan\" + "Loinhuan_" + lblNam.Text + ".xls";
            sheetName = lblNam.Text;
            Utilities.Export_To_Excel(dtGridProMonth, filename, sheetName);
        }


        private void chkReal_CheckedChanged(object sender, EventArgs e)
        {
            clear_DataGrid(dtGridProfit);
            clear_DataGrid(dtGridProMonth);
            create_dtGrid();
            FillDG();
        }

        private void clear_DataGrid(DataGridView dtGrid)
        {
            int i;
            while (dtGrid.Rows.Count > 0)
                dtGrid.Rows.RemoveAt(dtGrid.Rows.Count - 1);
        }

        private void dtGridProfit_AllowUserToOrderColumnsChanged(object sender, EventArgs e)
        {
            return;
        }

        private void dtGridProfit_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            return;
        }
    }
}