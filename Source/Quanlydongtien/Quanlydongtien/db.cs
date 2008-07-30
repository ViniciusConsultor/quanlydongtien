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
        public static Boolean Batch_Process()
        {
            return true;
        }

    }
}
