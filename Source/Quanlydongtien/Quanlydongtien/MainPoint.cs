using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.OleDb;
using System.Diagnostics;

namespace Quanlydongtien
{    
    public partial class MainPoint : Form
    {
        string dbFileName; //Path to datafile
        db userdb;
        string username;
        string workingDir;
        public MainPoint()
        {
            InitializeComponent();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.init(dbFileName);
            frmLogin.ShowDialog();
            if (frmLogin.logined == false)
                this.Close();
            username = frmLogin.user;
            check_role(username);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void nhapHopDongMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapthongtinHD frmNhapHD = new NhapthongtinHD();
            if (frmNhapHD.init(dbFileName, workingDir))
                frmNhapHD.ShowDialog();
        }

        private void nhapDongTienToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quanLyHopDongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlyhopdong frmQLHD = new Quanlyhopdong();
            frmQLHD.init(dbFileName, workingDir, true);
            frmQLHD.ShowDialog();
        }

        private void quanLyKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlykhachhang frmQLKH = new Quanlykhachhang();
            frmQLKH.init(dbFileName);
            frmQLKH.ShowDialog();
        }

        private void quanLyDongTienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dongtiennam frmDTN = new Dongtiennam();
            frmDTN.init(dbFileName, workingDir);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainPoint_Load(object sender, EventArgs e)
        {
            string sqlString;
            OleDbDataReader oleReader;
            config();
            userdb = new db(dbFileName);
            sqlString = "SELECT * FROM QUANLYUSER WHERE [Username] = 'admin'";
            oleReader = userdb.genDataReader(sqlString);
            if (oleReader == null)
            {
                this.Close();
                Application.Exit();
                return;
            }
            if (!oleReader.Read())
            {
                CreateUser frmCreateUser = new CreateUser();
                frmCreateUser.Text = "Khoi tao user admin cho he thong";
                frmCreateUser.init(dbFileName, true);
                frmCreateUser.ShowDialog();
                if (frmCreateUser.created == false)
                    this.Close();
                return;
            }
            Login frmLogin = new Login();
            frmLogin.init(dbFileName);
            frmLogin.ShowDialog();
            if (frmLogin.logined == false)
                this.Close();
            username = frmLogin.user;
            check_role(username);
//            userdb.Batch_Process();
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
            workingDir = xNode.OuterXml.Trim();
        }
        private void check_role(string username)
        {
            string sqlString;
            OleDbDataReader oleReader;
            Boolean value;
            int i;
            sqlString = "SELECT VALUE FROM UserRole WHERE [Username] = '" + username + "' AND";
            sqlString = sqlString + "[RoleID] = 8";
            oleReader = userdb.genDataReader(sqlString);
            if ((oleReader != null) && (oleReader.Read()))
            {
                value = oleReader.GetBoolean(0);
                if (value == true)
                {
                    this.nhapDuLieuToolStripMenuItem.Enabled = true;
                    this.quanLyDongTienToolStripMenuItem.Enabled = true;
                    this.quanLyHopDongToolStripMenuItem.Enabled = true;
                    this.quanLyKhachHangToolStripMenuItem.Enabled = true;
                    this.quanLyVonToolStripMenuItem.Enabled = true;
                    this.capthuHoiQuyenToolStripMenuItem.Enabled = true;
                    this.quanLyNguoiDungToolStripMenuItem.Enabled = true;
                }
                else
                {
                    sqlString = "SELECT RoleID, Value FROM UserRole WHERE Username = '" + username + "' ORDER BY RoleID";
                    oleReader = userdb.genDataReader(sqlString);
                    this.capthuHoiQuyenToolStripMenuItem.Enabled = false;
                    if (oleReader == null)
                    {
                        this.Close();
                        Application.Exit();
                    }
                    while (oleReader.Read())
                    {
                        i = oleReader.GetInt16(0);
                        value = oleReader.GetBoolean(1);
                        if (value == false)
                        {
                            if (i == 1)
                                //Khong duoc nhap thong tin hop dong va dong tien
                                this.nhapDuLieuToolStripMenuItem.Enabled = false;
                            else if (i == 3)
                                //Khong duoc them bot thong tin ve nguoi su dung he thong
                                this.quanLyNguoiDungToolStripMenuItem.Enabled = false;
                            else if (i == 4)
                                // Khong duoc xem thong tin khach hang va khong duoc sua doi thong tin khach hang
                                this.quanLyKhachHangToolStripMenuItem.Enabled = false;
                            else if (i == 5)
                                // Quan ly hop dong
                                this.quanLyHopDongToolStripMenuItem.Enabled = false;
                            else if (i == 6)
                                // Quan ly lai suat
                                this.quanLyVonToolStripMenuItem.Enabled = false;
                            else if (i == 7)
                                // Quan ly dong tien
                                this.quanLyDongTienToolStripMenuItem.Enabled = false;
                        }
                        else
                        {
                            if (i == 1)
                                //Duoc nhap thong tin hop dong va dong tien
                                this.nhapDuLieuToolStripMenuItem.Enabled = true;
                            else if (i == 3)
                                //Duoc them bot thong tin ve nguoi su dung he thong
                                this.quanLyNguoiDungToolStripMenuItem.Enabled = true;
                            else if (i == 4)
                                // Duoc xem thong tin khach hang va khong duoc sua doi thong tin khach hang
                                this.quanLyKhachHangToolStripMenuItem.Enabled = true;
                            else if (i == 5)
                                // Quan ly hop dong
                                this.quanLyHopDongToolStripMenuItem.Enabled = true;
                            else if (i == 6)
                                // Quan ly lai suat
                                this.quanLyVonToolStripMenuItem.Enabled = true;
                            else if (i == 7)
                                // Quan ly dong tien
                                this.quanLyDongTienToolStripMenuItem.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                this.Close();
                Application.Exit();
            }
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser frmCreateUser = new CreateUser();
            frmCreateUser.Text = "Them nguoi dung";
            frmCreateUser.init(dbFileName, false);
            frmCreateUser.ShowDialog();
            if (frmCreateUser.created == false)
                MessageBox.Show("Khong tao duoc nguoi dung!");
            return;

        }

        private void changePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePass frmChPass = new ChangePass();
            frmChPass.init(username, dbFileName);
            frmChPass.ShowDialog();
        }

        private void capthuHoiQuyenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRole frmChRole = new ChangeRole();
            frmChRole.init(dbFileName);
            frmChRole.ShowDialog();
        }

        private void quanLyNguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlynguoidung frmQLND = new Quanlynguoidung();
            frmQLND.init(dbFileName, username);
            frmQLND.ShowDialog();
        }

        private void quanLyVonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlyvon frmQLV;
            frmQLV = new Quanlyvon();
            frmQLV.init(dbFileName);
            frmQLV.ShowDialog();
        }

        private void nhapThongTinKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapthongtinKH frmCreateNewCus = new NhapthongtinKH();
            frmCreateNewCus.init(dbFileName);
            frmCreateNewCus.ShowDialog();
        }

        private void nhapThongTinNguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser frmNewuser = new CreateUser();
            frmNewuser.init(dbFileName, false);
            frmNewuser.ShowDialog();
        }

        private void chayBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userdb.Batch_Process();
        }

        private void quanLyLoiNhuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process Proc = new Process();
            Proc.StartInfo.FileName = @workingDir + "\\Quanlyloinhuan\\Quanlyloinhuan.exe";
            Proc.Start();
        }

        private void suaFileCauHinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process Proc = new Process();
            Proc.StartInfo.FileName = @"wordpad.exe";
            Proc.StartInfo.Arguments = "..\\config\\conf.xml";
            Proc.Start();
        }
    }
}