using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace Quanlydongtien
{
    public partial class ChangeRole : Form
    {
        string dbFileName;
        db roledb;
        ArrayList useridlist;
        public ChangeRole()
        {
            InitializeComponent();
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox admin = (CheckBox)sender;
            foreach (Control ctl in this.gpQuyen.Controls)
            {
                if (ctl.ToString().Contains("CheckBox"))
                {
                    if ((admin.Checked == true) && (ctl.Name != "chkAdmin"))
                    {
                        ctl.Enabled = false;
                    }
                    else
                        ctl.Enabled = true;
                }

            }
        }

        private void ChangeRole_Load(object sender, EventArgs e)
        {

        }
        public void init(string dbfile)
        {
            string sqlString, user;
            OleDbDataReader oleReader;
            useridlist = new ArrayList();
            dbFileName = dbfile;
            roledb = new db(dbFileName);
            sqlString = "SELECT DISTINCT UserName FROM [UserRole] WHERE RoleID <> 8";
            oleReader = roledb.genDataReader(sqlString);
            while (oleReader.Read())
            {
                user = oleReader.GetString(0);
                cbxUserName.Items.Add(user);               
            }
            oleReader.Close();
            cbxUserName.Text = cbxUserName.Items[0].ToString();
        }

        private void cmdSubmit_Click_1(object sender, EventArgs e)
        {
            string sqlString;
            string user = cbxUserName.Text;           
            foreach (Control ctl in this.gpQuyen.Controls)
            {
                if (ctl.ToString().Contains("CheckBox"))
                {
                    CheckBox crrCtl = (CheckBox)ctl;
                    sqlString = "UPDATE [UserRole] SET [VALUE] = " + crrCtl.Checked;
                    sqlString = sqlString + " WHERE Username = '" + user + "' AND";
                    sqlString = sqlString + " RoleID = " + crrCtl.Tag.ToString();
                    roledb.runSQLCmd(sqlString);
                }
            }
            this.Close();
        }
    }
}