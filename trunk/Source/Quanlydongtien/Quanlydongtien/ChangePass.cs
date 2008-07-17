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
    public partial class ChangePass : Form
    {
        string username, oldpass;
        string dbfile;
        private db pwddb;
        public ChangePass()
        {
            InitializeComponent();
        }

        private void ChangePass_Load(object sender, EventArgs e)
        {

        }
        public void init(string user, string dbfile)
        {
            username = user;
            pwddb = new db(dbfile);
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            string sqlString;
            string dbpass;
            if ((txtConfirm.Text == "") || (txtNewPass.Text == "") || (txtOldPass.Text == ""))
            {
                MessageBox.Show("Ban phai nhap day du thong tin!");
                return;
            }
            if (txtNewPass.Text != txtConfirm.Text)
            {
                MessageBox.Show("Thong tin ve mat khau va xac nhan mat khau khong giong nhau \n Ban phai nhap lai");
                return;
            }
            byte[] d = Encoding.Unicode.GetBytes(txtConfirm.Text);
            dbpass = System.Convert.ToBase64String(d);
            if (!checkoldpass(txtOldPass.Text))
            {
                MessageBox.Show("Ban nhap mat khau khong dung");
                return;
            }
            sqlString = "UPDATE QUANLYUSER SET [password] = '" + dbpass + "' WHERE [UserName] = '" + username + "'";
            pwddb.runSQLCmd(sqlString);
            pwddb.close();
            this.Close();
        }
        private Boolean checkoldpass(string oldpass)
        {
            string sqlString;
            string datapass;
            OleDbDataReader OleReader;
            byte[] d = Encoding.Unicode.GetBytes(oldpass);
            datapass = System.Convert.ToBase64String(d);
            sqlString = "SELECT * FROM QUANLYUSER WHERE [Username] = '" + username + "' AND";
            sqlString = sqlString + " [password] = '" + datapass + "'";
            OleReader = pwddb.genDataReader(sqlString);
            if ((OleReader != null) && (OleReader.Read()))
                return true;
            else return false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            pwddb.close();
            this.Close();
        }
    }
}