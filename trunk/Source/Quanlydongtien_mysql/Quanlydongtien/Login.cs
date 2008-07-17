using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.OleDb;
/*
 * Login menu using to log user into the system
 * Base on Userlogin will have specific role to operate with th system
 */
namespace Quanlydongtien
{
    public partial class Login : Form
    {
        private db hdbhData;
        private string dbName;
        public string user;
        private int count;
        public Boolean logined = false;        
        public Login()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            string sqlString;
            string frmPass, dbPass;
            OleDbDataReader userReader;
            sqlString = "SELECT Password FROM QUANLYUSER ";
            if (txtUserName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Ban phai nhap user name va password");
                return;
            }
            byte[] d = Encoding.Unicode.GetBytes(txtPass.Text);
            frmPass = System.Convert.ToBase64String(d);
            sqlString = sqlString + "WHERE UserName = '" + txtUserName.Text + "'";
            userReader = hdbhData.genDataReader(sqlString);
            if (userReader.Read())
            {
                dbPass = userReader.GetString(0);
                if (dbPass != frmPass)
                {
                    if (count < 3)
                    {
                        count++;
                        MessageBox.Show("Ten dang nhap hoac mat khau khong hop le");
                        return;
                    }
                    else
                    {
                        logined = false;
                        this.Close();
                    }
                }
                else
                {
                    user = txtUserName.Text;
                    this.Close();
                }
            }
            this.Close();
            logined = true;
        }
        public void init(string dbfilename, string dbuser, int dbport)
        {

            dbName = dbfilename;
            hdbhData = new db(dbName, dbuser, dbport);
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            logined = false;
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}