using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using System.Data;

namespace Quanlydongtien
{
    class db
    {
        private string dbFile;
        private Boolean connected = false;
        OleDbConnection MyConnection;
        public db(string Namedb)
        {
            string cnnString;
            dbFile = Namedb;

            //Provider=Microsoft.Jet.OLEDB.4.0
            //Data Source=D:\MyProject\database\Tape.mdb
            //Jet OLEDB:Database Password=root
            MyConnection = new OleDbConnection();
            cnnString = "Provider=Microsoft.Jet.OLEDB.4.0;";
            cnnString = cnnString + "Data Source=" + @dbFile;
            MyConnection.ConnectionString = cnnString;
            try
            {
                MyConnection.Open();
                connected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connected = false;
            }
        }
        public OleDbDataReader genDataReader(string sqlString)
        {
            OleDbCommand oleCmd;
            if (connected == true)
            {
                oleCmd = new OleDbCommand(sqlString, MyConnection);
                try
                {
                    return oleCmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " In function genDataReader");
                    return null;
                }
            }
            else return null;
        }
        public DataSet genDataset(string sqlString)
        {
            OleDbCommand oleCmd;
            OleDbDataAdapter oleAdapter;
            DataSet tmpDs;
            if (connected == true)
            {
                oleCmd = new OleDbCommand(sqlString, MyConnection);
                oleAdapter = new OleDbDataAdapter(oleCmd);
                try
                {
                    tmpDs = new DataSet();
                    oleAdapter.Fill(tmpDs);
                    return tmpDs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " In function genDataReader");
                    return null;
                }
            }
            else return null;
        }
         /*
         * Func runSQLCmd is used to run sql command the not return the array value
         * Using when update or delete one table
         */
        public Boolean runSQLCmd(string sqlcmd)
        {
            try
            {
                OleDbCommand oleCmd;
                oleCmd = new OleDbCommand(sqlcmd, MyConnection);
                oleCmd.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Infunction runSQL");
                return false;
            }
        }
        public void fillListView(string sqlStr, ListView lstViewControl)
        {
            OleDbDataReader oleReader;
            oleReader = genDataReader(sqlStr);
            ListViewItem lstviewItem;
            int i;
            string columnName;
            string value;
            Type typeoffield;
            int typeindex; /*0 is int
                            * 1 is string
                            */
            typeindex = 0;
            if (oleReader == null)
                return;
            try
            {
                if (oleReader.Read())
                {
                    lstViewControl.BeginUpdate();
                    lstViewControl.Clear();
                    lstviewItem = new ListViewItem();
                    for (i = 0; i < oleReader.FieldCount; i++)
                    {
                        columnName = oleReader.GetName(i);
                        lstViewControl.Columns.Add(columnName);
                        typeoffield = oleReader.GetFieldType(i);
                        if (typeoffield == typeof(System.Int32))
                            typeindex = 0;
                        else typeindex = 1;
                        if (typeindex == 0)
                            value = oleReader.GetValue(i).ToString();
                        else value = oleReader.GetString(i);
                        if (i == 0)
                        {
                            lstviewItem = new ListViewItem();
                            lstviewItem.Text = value;
                        }
                        else lstviewItem.SubItems.Add(value);
                    }
                    lstViewControl.Items.Add(lstviewItem);
                }
                while (oleReader.Read())
                {
                    lstviewItem = new ListViewItem();
                    for (i = 0; i < oleReader.FieldCount; i++)
                    {
                        typeoffield = oleReader.GetFieldType(i);
                        if (typeoffield == typeof(System.Int32))
                            typeindex = 0;
                        else typeindex = 1;
                        if (typeindex == 0)
                            value = oleReader.GetValue(i).ToString();
                        else value = oleReader.GetString(i);
                        if (i == 0)
                        {
                            lstviewItem = new ListViewItem();
                            lstviewItem.Text = value;
                        }
                        else lstviewItem.SubItems.Add(value);

                    }
                    lstViewControl.Items.Add(lstviewItem);


                }
                lstViewControl.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in function fillListView with control :" + lstViewControl.Name);
                lstViewControl.EndUpdate();
            }
        }
        public void fillDtGridView(string sqlStr, DataGridView dtGrid)
        {
            OleDbDataReader oleReader;
            oleReader = genDataReader(sqlStr);
            int i;
            string columnName;
            string value;
            DataGridViewRow dtGridRow;
            DataGridViewTextBoxCell dtGridCell;
            if (oleReader == null)
                return;
            try
            {
                if (oleReader.Read())                    
                {
                    dtGridRow = new DataGridViewRow();
                    for (i = 0; i < oleReader.FieldCount; i++)
                    {
                        dtGridCell = new DataGridViewTextBoxCell();
                        columnName = oleReader.GetName(i);
                        dtGrid.Columns.Add(columnName, columnName);
                        dtGrid.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        value = oleReader.GetValue(i).ToString();
                        dtGridCell.Value = value;
                        dtGridRow.Cells.Add(dtGridCell);
                    }
                    dtGrid.Rows.Add(dtGridRow);
                }
                while (oleReader.Read())
                {
                    dtGridRow = new DataGridViewRow();                 
                    for (i = 0; i < oleReader.FieldCount; i++)
                    {
                        dtGridCell = new DataGridViewTextBoxCell();
                        value = oleReader.GetValue(i).ToString();
                        dtGridCell.Value = value;
                        dtGridRow.Cells.Add(dtGridCell);
                    }
                    dtGrid.Rows.Add(dtGridRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in function fillListView with control :" + dtGrid.Name);
            }
        }
        public void close()
        {
            MyConnection.Close();
            connected = false;
        }

        /*Batch process la chay giao dich cuoi ngay de:
         *   - Cap nhat lai so tien mat 
         *   - Cap nhat lai cac no qua han:
         *      + Neu ngay den han ma chua nop tien thi chuyen sang no qua han
         *      + Chuyen sang no qua han thi so tien se bi loai khoi dong tien 
         */
        public Boolean Batch_Process()
        {
            try
            {
                Tinhloinhuan();
                Tinhloinhuan_Giadinh();
                //Delete_Un_Real_Data();
                //Update_Overdue_Debt();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void Tinhloinhuan()
        {
            string sqlStr = "SELECT MIN(FORMAT([Ngaytra], 'yyyy')) AS minyear, MAX(FORMAT([Ngaytra], 'yyyy')) AS maxyear FROM [TIENLAI] WHERE [Real] = Yes";
            int i;
            int minyear, maxyear;
            OleDbDataReader oleReader;
            oleReader = genDataReader(sqlStr);
            if (oleReader.Read())
            {
                minyear = int.Parse(oleReader["minyear"].ToString());
                maxyear = int.Parse(oleReader["maxyear"].ToString());
                try
                {
                    while (minyear <= maxyear)
                    {
                        for (i = 1; i <= 12; i++)
                        {
                            Loinhuanthang(i, minyear);
                        }
                        minyear++;
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }            
        }

        private void Loinhuanthang(int thang, int nam)
        {
            string sqlStr;
            Int64 Loinhuan = 0;
            Int64 laithuc, tienlai, tienchiulai;
            Int64 laisuat, ngaychiulai;
            OleDbDataReader oleReader;
            string month;
            TimeSpan diffDays;
            DateTime ngayvay, ngaytra, nextMonth;
            string theFirstOfMonth = "01";
            string accMonth; //using in access
            string maLN;
            if (thang < 10)
                month = "0" + thang.ToString();
            else month = thang.ToString();
            theFirstOfMonth = theFirstOfMonth + "/" + month + "/" + nam.ToString();
            accMonth = month + "/" + "01" + "/" + nam.ToString();
            nextMonth = DateTime.Parse(theFirstOfMonth).AddMonths(1);
            sqlStr = "SELECT [Sotienlai], FORMAT([NgayTra], 'dd/mm/yyyy') AS Ngaytratien, [Tienchiulai], [Laisuat] FROM [TIENLAI]WHERE (([Ngaytra] > #" + accMonth + "#)) AND [Real] = Yes";
            oleReader = this.genDataReader(sqlStr);
            if (oleReader == null)
            {
                return;
            }
            try
            {
                while (oleReader.Read())
                {
                    tienchiulai = Int64.Parse(oleReader["Tienchiulai"].ToString());
                    ngaytra = DateTime.Parse(oleReader["Ngaytratien"].ToString());
                    tienlai = Int64.Parse(oleReader["Sotienlai"].ToString());
                    laisuat = Int64.Parse(oleReader["Laisuat"].ToString());
                    ngaychiulai = (Int64)Math.Round((decimal)(tienlai * 360 * 100 * 100) / (tienchiulai * laisuat));
                    ngayvay = ngaytra.AddDays(0 - Math.Abs(ngaychiulai));
                    if (ngayvay > nextMonth.AddDays(-1))
                        continue;
                    diffDays = Utilities.minDate(nextMonth.AddDays(-1), ngaytra) - Utilities.maxDate(ngayvay, nextMonth.AddMonths(-1));
                    laithuc = (tienchiulai * laisuat * diffDays.Days) / (360 * 100 * 100);
                    if (tienlai >= 0)
                        Loinhuan = Loinhuan + laithuc;
                    else
                        Loinhuan = Loinhuan - laithuc;
                }
            }
            catch (Exception ex)
            {
                return;
            }
            sqlStr = "SELECT [MaLN] FROM [LOINHUAN] WHERE [Thang] = '" + month + "' AND [Nam] = " + nam.ToString();
            oleReader = genDataReader(sqlStr);
            if (oleReader == null)
            {
                return;
             }
            else
            {
                if (oleReader.Read())
                {
                    maLN = oleReader["MaLN"].ToString();
                    sqlStr = "UPDATE [LOINHUAN] SET [Soluong] = " + Loinhuan.ToString() + " WHERE [MaLN] =" + maLN.ToString();
                }
                else
                {
                    sqlStr = "INSERT INTO [LOINHUAN] ([Thang], [Nam], [Soluong]) VALUES (";
                    sqlStr = sqlStr + "'" + month + "', " + nam.ToString() + "," + Loinhuan.ToString() + ")"; 
                }
                runSQLCmd(sqlStr);
            }
        }
        private void Delete_Un_Real_Data()
        {
            string crrDay;
            string sqlStr;
            string mahd;
            int year, month, day;
            DateTime today;
            OleDbDataReader oleReader;
            today = DateTime.Today;
            year = today.Year;
            month = today.Month;
            day = today.Day;
            crrDay = month.ToString() + "/" + day.ToString() + "/" + year.ToString();
            sqlStr = "SELECT [MaHD] FROM [HOPDONG] WHERE [Real] = No AND [NgayHD] < #" + crrDay + "#";
            oleReader = genDataReader(sqlStr);
            while (oleReader.Read())
            {
                mahd = oleReader["MaHD"].ToString();
                sqlStr = "DELETE FROM [HOPDONG] WHERE [MaHD] = '" + mahd + "'";
                runSQLCmd(sqlStr);
                sqlStr = "DELETE FROM [DONGTIEN] WHERE [MaHD] = '" + mahd + "'";
                runSQLCmd(sqlStr);
                sqlStr = "DELETE FROM [TIENLAI] WHERE [MaHD] = '" + mahd + "'";
                runSQLCmd(sqlStr);
            }
        }
        private void Update_Overdue_Debt()
        {
            OleDbDataReader oleReader;
            DateTime today = DateTime.Today;
            DateTime ngaytratien;
            TimeSpan diffDay;
            string crrDay, mahd, madt;
            int year, month, day, noqh;
            string ngaytra;
            string sqlStr;
            year = today.Year;
            month = today.Month;
            day = today.Day;
            try
            {
                crrDay = month.ToString() + "/" + day.ToString() + "/" + year.ToString();
                sqlStr = "SELECT [MaDT], [MaHD], FORMAT([NgayTra], 'dd/mm/yyyy') AS Ngaytratien FROM [DONGTIEN] ";
                sqlStr = sqlStr + "WHERE [Datra] = No AND [Real] = True AND [NgayTra] < #" + crrDay + "#";
                oleReader = genDataReader(sqlStr);
                while (oleReader.Read())
                {
                    madt = oleReader["MaDT"].ToString();
                    mahd = oleReader["MaHD"].ToString();
                    ngaytra = oleReader["Ngaytratien"].ToString();
                    ngaytratien = DateTime.Parse(ngaytra);
                    diffDay = today.Subtract(ngaytratien);
                    noqh = diffDay.Days;
                    sqlStr = "UPDATE [HOPDONG] SET [NoQH] = Yes WHER [MaHD] = '" + mahd + "'";
                    runSQLCmd(sqlStr);
                    sqlStr = "UPDATE [DONGTIEN] SET [NoQH] = " + noqh.ToString() + " WHERE [MaDT] = " + madt.ToString();
                    runSQLCmd(sqlStr);
                }

                //Update to [Tienlai] Table when one overdue debt appear
                sqlStr = "SELECT [MaDT], [MaHD], FORMAT([NgayTra], 'dd/mm/yyyy') AS Ngaytratien FROM [TIENLAI] ";
                sqlStr = sqlStr + "WHERE [Datra] = No AND [Real] = True AND [NgayTra] < #" + crrDay + "#";
                oleReader = genDataReader(sqlStr);
                while (oleReader.Read())
                {
                    madt = oleReader["MaDT"].ToString();
                    mahd = oleReader["MaHD"].ToString();
                    ngaytra = oleReader["Ngaytratien"].ToString();
                    ngaytratien = DateTime.Parse(ngaytra);
                    diffDay = today.Subtract(ngaytratien);
                    noqh = diffDay.Days;
                    sqlStr = "UPDATE [HOPDONG] SET [NoQH] = Yes WHERE [MaHD] = '" + mahd + "'";
                    runSQLCmd(sqlStr);
                    sqlStr = "UPDATE [TIENLAI] SET [NoQH] = " + noqh.ToString() + "WHERE [MaDT] = " + madt.ToString();
                    runSQLCmd(sqlStr);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Tinhloinhuan_Giadinh()
        {
            string sqlStr = "SELECT MIN(FORMAT([Ngaytra], 'yyyy')) AS minyear, MAX(FORMAT([Ngaytra], 'yyyy')) AS maxyear FROM [TIENLAI]";
            int i;
            int minyear, maxyear;
            OleDbDataReader oleReader;
            oleReader = genDataReader(sqlStr);
            if (oleReader.Read())
            {
                minyear = int.Parse(oleReader["minyear"].ToString());
                maxyear = int.Parse(oleReader["maxyear"].ToString());
                while (minyear <= maxyear)
                {
                    for (i = 1; i <= 12; i++)
                    {
                        Loinhuanthang_Giadinh(i, minyear);
                    }
                    minyear++;
                }
            }            
        }

        private void Loinhuanthang_Giadinh(int thang, int nam)
        {
            string sqlStr;
            Int64 Loinhuan = 0;
            Int64 laithuc, tienlai, tienchiulai;
            Int64 laisuat, ngaychiulai;
            OleDbDataReader oleReader;
            string month;
            TimeSpan diffDays;
            DateTime ngayvay, ngaytra, nextMonth;
            string theFirstOfMonth = "01";
            string accMonth; //using in access
            string maLN;
            if (thang < 10)
                month = "0" + thang.ToString();
            else month = thang.ToString();
            theFirstOfMonth = theFirstOfMonth + "/" + month + "/" + nam.ToString();
            accMonth = month + "/" + "01" + "/" + nam.ToString();
            nextMonth = DateTime.Parse(theFirstOfMonth).AddMonths(1);
            sqlStr = "SELECT [Sotienlai], FORMAT([NgayTra], 'dd/mm/yyyy') AS Ngaytratien, [Tienchiulai], [Laisuat] FROM [TIENLAI]WHERE (([Ngaytra] > #" + accMonth + "#))";
            oleReader = this.genDataReader(sqlStr);
            if (oleReader == null)
            {
                return;
            }
            while (oleReader.Read())
            {
                tienchiulai = Int64.Parse(oleReader["Tienchiulai"].ToString());
                ngaytra = DateTime.Parse(oleReader["Ngaytratien"].ToString());
                tienlai = Int64.Parse(oleReader["Sotienlai"].ToString());
                laisuat = Int64.Parse(oleReader["Laisuat"].ToString());
                ngaychiulai = (Int64)Math.Round((decimal)(tienlai * 360 * 100 * 100) / (tienchiulai * laisuat));
                ngayvay = ngaytra.AddDays(0 - Math.Abs(ngaychiulai));
                if (ngayvay > nextMonth.AddDays(-1))
                    continue;
                diffDays = Utilities.minDate(nextMonth.AddDays(-1), ngaytra) - Utilities.maxDate(ngayvay, nextMonth.AddMonths(-1));
                laithuc = (tienchiulai * laisuat * diffDays.Days) / (360 * 100 * 100);
                if (tienlai >= 0)
                    Loinhuan = Loinhuan + laithuc;
                else
                    Loinhuan = Loinhuan - laithuc;
            }
            sqlStr = "SELECT [MaLN] FROM [LOINHUANGIADINH] WHERE [Thang] = '" + month + "' AND [Nam] = " + nam.ToString();
            oleReader = genDataReader(sqlStr);
            if (oleReader == null)
            {
                return;
            }
            else
            {
                if (oleReader.Read())
                {
                    maLN = oleReader["MaLN"].ToString();
                    sqlStr = "UPDATE [LOINHUANGIADINH] SET [Soluong] = " + Loinhuan.ToString() + " WHERE [MaLN] =" + maLN.ToString();
                }
                else
                {
                    sqlStr = "INSERT INTO [LOINHUANGIADINH] ([Thang], [Nam], [Soluong]) VALUES (";
                    sqlStr = sqlStr + "'" + month + "', " + nam.ToString() + "," + Loinhuan.ToString() + ")";
                }
                runSQLCmd(sqlStr);
            }
        }
    }
}
