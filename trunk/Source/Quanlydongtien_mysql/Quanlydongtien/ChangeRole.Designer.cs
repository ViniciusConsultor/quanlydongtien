namespace Quanlydongtien
{
    partial class ChangeRole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cbxUserName = new System.Windows.Forms.ComboBox();
            this.gpQuyen = new System.Windows.Forms.GroupBox();
            this.chkQLDT = new System.Windows.Forms.CheckBox();
            this.chkQLLS = new System.Windows.Forms.CheckBox();
            this.chkQLHD = new System.Windows.Forms.CheckBox();
            this.chkQLKH = new System.Windows.Forms.CheckBox();
            this.chkFrmQLND = new System.Windows.Forms.CheckBox();
            this.chkNhapThongtin = new System.Windows.Forms.CheckBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpQuyen.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(146, 170);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 33);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Huy bo";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Location = new System.Drawing.Point(29, 170);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 33);
            this.cmdSubmit.TabIndex = 8;
            this.cmdSubmit.Text = "Chap nhan";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click_1);
            // 
            // cbxUserName
            // 
            this.cbxUserName.FormattingEnabled = true;
            this.cbxUserName.Location = new System.Drawing.Point(107, 5);
            this.cbxUserName.Name = "cbxUserName";
            this.cbxUserName.Size = new System.Drawing.Size(121, 21);
            this.cbxUserName.TabIndex = 7;
            // 
            // gpQuyen
            // 
            this.gpQuyen.Controls.Add(this.chkQLDT);
            this.gpQuyen.Controls.Add(this.chkQLLS);
            this.gpQuyen.Controls.Add(this.chkQLHD);
            this.gpQuyen.Controls.Add(this.chkQLKH);
            this.gpQuyen.Controls.Add(this.chkFrmQLND);
            this.gpQuyen.Controls.Add(this.chkNhapThongtin);
            this.gpQuyen.Controls.Add(this.chkAdmin);
            this.gpQuyen.Location = new System.Drawing.Point(9, 37);
            this.gpQuyen.Name = "gpQuyen";
            this.gpQuyen.Size = new System.Drawing.Size(275, 123);
            this.gpQuyen.TabIndex = 6;
            this.gpQuyen.TabStop = false;
            this.gpQuyen.Text = "Danh sach quyen";
            // 
            // chkQLDT
            // 
            this.chkQLDT.AutoSize = true;
            this.chkQLDT.Location = new System.Drawing.Point(6, 97);
            this.chkQLDT.Name = "chkQLDT";
            this.chkQLDT.Size = new System.Drawing.Size(109, 17);
            this.chkQLDT.TabIndex = 7;
            this.chkQLDT.Tag = "7";
            this.chkQLDT.Text = "Quan ly dong tien";
            this.chkQLDT.UseVisualStyleBackColor = true;
            // 
            // chkQLLS
            // 
            this.chkQLLS.AutoSize = true;
            this.chkQLLS.Location = new System.Drawing.Point(7, 74);
            this.chkQLLS.Name = "chkQLLS";
            this.chkQLLS.Size = new System.Drawing.Size(98, 17);
            this.chkQLLS.TabIndex = 6;
            this.chkQLLS.Tag = "6";
            this.chkQLLS.Text = "Quan ly lai suat";
            this.chkQLLS.UseVisualStyleBackColor = true;
            // 
            // chkQLHD
            // 
            this.chkQLHD.AutoSize = true;
            this.chkQLHD.Location = new System.Drawing.Point(140, 75);
            this.chkQLHD.Name = "chkQLHD";
            this.chkQLHD.Size = new System.Drawing.Size(114, 17);
            this.chkQLHD.TabIndex = 5;
            this.chkQLHD.Tag = "5";
            this.chkQLHD.Text = "Quan ly Hop Dong";
            this.chkQLHD.UseVisualStyleBackColor = true;
            // 
            // chkQLKH
            // 
            this.chkQLKH.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chkQLKH.AutoSize = true;
            this.chkQLKH.Location = new System.Drawing.Point(140, 52);
            this.chkQLKH.Name = "chkQLKH";
            this.chkQLKH.Size = new System.Drawing.Size(122, 17);
            this.chkQLKH.TabIndex = 4;
            this.chkQLKH.Tag = "4";
            this.chkQLKH.Text = "Quan ly khach hang";
            this.chkQLKH.UseVisualStyleBackColor = true;
            // 
            // chkFrmQLND
            // 
            this.chkFrmQLND.AutoSize = true;
            this.chkFrmQLND.Location = new System.Drawing.Point(140, 29);
            this.chkFrmQLND.Name = "chkFrmQLND";
            this.chkFrmQLND.Size = new System.Drawing.Size(118, 17);
            this.chkFrmQLND.TabIndex = 3;
            this.chkFrmQLND.Tag = "3";
            this.chkFrmQLND.Text = "Quan ly nguoi dung";
            this.chkFrmQLND.UseVisualStyleBackColor = true;
            // 
            // chkNhapThongtin
            // 
            this.chkNhapThongtin.AutoSize = true;
            this.chkNhapThongtin.Location = new System.Drawing.Point(7, 52);
            this.chkNhapThongtin.Name = "chkNhapThongtin";
            this.chkNhapThongtin.Size = new System.Drawing.Size(86, 17);
            this.chkNhapThongtin.TabIndex = 1;
            this.chkNhapThongtin.Tag = "1";
            this.chkNhapThongtin.Text = "Nhap du lieu";
            this.chkNhapThongtin.UseVisualStyleBackColor = true;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(6, 29);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(55, 17);
            this.chkAdmin.TabIndex = 0;
            this.chkAdmin.Tag = "8";
            this.chkAdmin.Text = "Admin";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ten nguoi dung";
            // 
            // ChangeRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 209);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.cbxUserName);
            this.Controls.Add(this.gpQuyen);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(311, 243);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(311, 243);
            this.Name = "ChangeRole";
            this.Text = "ChangeRole";
            this.Load += new System.EventHandler(this.ChangeRole_Load);
            this.gpQuyen.ResumeLayout(false);
            this.gpQuyen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.ComboBox cbxUserName;
        private System.Windows.Forms.GroupBox gpQuyen;
        private System.Windows.Forms.CheckBox chkQLDT;
        private System.Windows.Forms.CheckBox chkQLLS;
        private System.Windows.Forms.CheckBox chkQLHD;
        private System.Windows.Forms.CheckBox chkQLKH;
        private System.Windows.Forms.CheckBox chkFrmQLND;
        private System.Windows.Forms.CheckBox chkNhapThongtin;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.Label label1;

    }
}