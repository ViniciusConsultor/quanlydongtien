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
    public partial class Quanlynguoidung : Form
    {
        db dbUser;
        string datafile;
        public Quanlynguoidung()
        {
            InitializeComponent();
        }

        private void Quanlynguoidung_Load(object sender, EventArgs e)
        {

        }
        public void init(string database)
        {
            DataSet ds;
            DataGridViewButtonColumn dtGridBt = new DataGridViewButtonColumn();
            datafile = database;
            dtGridUser.AllowUserToAddRows = true;
            int i, cullCount;
            string sqlString = "SELECT [Username] AS [Ten nguoi dung], [Locked] AS [Khoa] FROM [QUANLYUSER]";            
            dbUser = new db(database);
            ds = dbUser.genDataset(sqlString);
            dtGridUser.DataSource = ds.Tables[0];
            dtGridBt.Width = 60;
            dtGridBt.Text = "Cap nhat";
            dtGridBt.Name = "capnhat";
            dtGridBt.UseColumnTextForButtonValue = true;
            for (i = 0; i < dtGridUser.Columns.Count; i++)
            {
                dtGridUser.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtGridUser.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }            
            dtGridUser.Columns.Add(dtGridBt);
            cullCount = dtGridUser.Columns.Count;
            for (i = 0; i < dtGridUser.Rows.Count; i++)
            {
                dtGridUser.Rows[i].Cells[cullCount - 1].Value = "Cap nhat";
            }
            dtGridUser.AllowUserToAddRows = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            dbUser.close();
            this.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dtGridRow;
            string sqlStr;
            if (dtGridUser.SelectedRows.Count == 0)
                return;
            dtGridRow = dtGridUser.SelectedRows[0];
            if (dtGridRow.Cells["Ten nguoi dung"].Value.ToString() == "admin")
            {
                MessageBox.Show("Ban khong the xoa nguoi dung admin");
                return;
            }
            sqlStr = "DELETE FROM [Quanlyuser] WHERE [Username] = '" + dtGridRow.Cells["Ten nguoi dung"].Value.ToString() + "'";
            dbUser.runSQLCmd(sqlStr);
            sqlStr = "DELETE FROM [UserRole] WHERE [Username] = '" + dtGridRow.Cells["Ten nguoi dung"].Value.ToString() + "'";
            dbUser.runSQLCmd(sqlStr);
            dtGridUser.Rows.Remove(dtGridRow);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            CreateUser frmNewuser = new CreateUser();
            frmNewuser.init(datafile, false);
            frmNewuser.ShowDialog();
            refreshdata();
        }
        private void refreshdata()
        {
            string sqlString;
            DataSet ds;
            DataGridViewButtonColumn dtGridBt = new DataGridViewButtonColumn();
            int i, cullCount;
        //    dtGridUser.AllowUserToAddRows = true;           
            while (dtGridUser.Rows.Count > 0)
                dtGridUser.Rows.RemoveAt(dtGridUser.Rows.Count - 1);
            while (dtGridUser.Columns.Count > 0)
                dtGridUser.Columns.RemoveAt(dtGridUser.Columns.Count - 1);
            dtGridUser.AllowUserToAddRows = true;           
            sqlString = "SELECT [Username] AS [Ten nguoi dung], [Locked] AS [Khoa] FROM [QUANLYUSER]";
            ds = dbUser.genDataset(sqlString);
            dtGridUser.DataSource = ds.Tables[0];
            for (i = 0; i < dtGridUser.Columns.Count; i++)
            {
                dtGridUser.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtGridUser.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtGridUser.Columns[i].Tag = i;
            }
            dtGridBt.Width = 60;
            dtGridBt.Text = "Cap nhat";
            dtGridBt.Name = "capnhat";
            dtGridBt.UseColumnTextForButtonValue = true;
            dtGridUser.Columns.Add(dtGridBt);
            cullCount = dtGridUser.Columns.Count;
            for (i = 0; i < dtGridUser.Rows.Count; i++)
            {
                dtGridUser.Rows[i].Cells["capnhat"].Value = "Cap nhat";
            }
            dtGridUser.AllowUserToAddRows = false;
        }

        private void dtGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sqlStr;
            DataGridViewRow dtGridRow;
            DataGridViewCell dtGridCel;
            dtGridCel = dtGridUser.SelectedCells[0];
            if (dtGridCel.Value.ToString() != "Cap nhat")
                return;            
            dtGridRow = dtGridUser.Rows[e.RowIndex];
            if (dtGridRow.Cells["Ten nguoi dung"].Value.ToString() == "admin")
            {
                dtGridRow.Cells["Khoa"].Value = false;
                return;
            }
            sqlStr = "UPDATE [QUANLYUSER] SET [locked] = " + dtGridRow.Cells["Khoa"].Value.ToString();
            sqlStr = sqlStr + " WHERE [Username] = '" + dtGridRow.Cells["Ten nguoi dung"].Value.ToString() + "'";
            dbUser.runSQLCmd(sqlStr);
        }
    }
}