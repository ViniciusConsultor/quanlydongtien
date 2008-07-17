using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quanlydongtien
{
    public partial class CreateUser : Form
    {
        public Boolean created = false;
        private db hdbhData;
        private string dbName;
        private Boolean admin = false;        
        public CreateUser()
        {
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }
        public void init(string dbfilename, Boolean administrator)
        {

            dbName = dbfilename;
            hdbhData = new db(dbName);
            admin = administrator;
            if (admin)
            {
                txtUser.Text = "admin";
                txtUser.Enabled = false;
            }
        }
        private void cmdHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Create_Admin(string username, string pass)
        {
            string sqlString;
            sqlString = "INSERT INTO QUANLYUSER ([Username], [Password]) VALUES ('" + username + "',";
            sqlString = sqlString + " '" + pass + "')";
            if (hdbhData.runSQLCmd(sqlString))
            {
                sqlString = "INSERT INTO UserRole ([Username], [RoleID], [Value]) VALUES ('" + username + "', ";
                sqlString = sqlString + "8, " + admin + ")";
                hdbhData.runSQLCmd(sqlString);
                created = true;
            }
            else created = false;
            this.Close();
        }
        private void Create_User(string username, string pass)
        {
            string sqlString;
            int i;
            sqlString = "INSERT INTO QUANLYUSER ([Username], [Password]) VALUES ('" + username + "',";
            sqlString = sqlString + " '" + pass + "')";
            if (hdbhData.runSQLCmd(sqlString))
            {
                for (i = 1; i <= 8; i++)
                {
                    sqlString = "INSERT INTO [UserRole] ([Username], [RoleId], [Value]) VALUES ('" + username;
                    sqlString = sqlString + "', " + i.ToString() + ", No)";
                    hdbhData.runSQLCmd(sqlString);
                }
                created = true;
            }
            else created = false;
        }

        private void cmdSubmit_Click_1(object sender, EventArgs e)
        {
            string frmpass;
            if (txtUser.Text == "" || txtPass.Text == "" || txtConfirm.Text == "")
            {
                MessageBox.Show("Ban phai nhap day du thong tin!");
                return;
            }
            if (txtPass.Text != txtConfirm.Text)
            {
                MessageBox.Show("Thong tin ve mat khau va xac nhan mat khau khong giong nhau \n Ban phai nhap lai!");
                return;
            }
            byte[] d = Encoding.Unicode.GetBytes(txtPass.Text);
            frmpass = System.Convert.ToBase64String(d);
            if (admin)
                Create_Admin(txtUser.Text, frmpass);
            else Create_User(txtUser.Text, frmpass);            
            this.Close();
        }

        private void cmdHuy_Click_1(object sender, EventArgs e)
        {
            hdbhData.close();
            this.Close();
        }

    }
}