namespace Quanlydongtien
{
    partial class Tinhlai
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
            this.cmdSave = new System.Windows.Forms.Button();
            this.dtGridCF = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.txtLaisuat = new System.Windows.Forms.TextBox();
            this.MaDongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaytra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tienlai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCF)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(260, 334);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 30);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.Text = "Dong";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(179, 334);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 30);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "Luu lai";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // dtGridCF
            // 
            this.dtGridCF.AllowUserToAddRows = false;
            this.dtGridCF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDongTien,
            this.Ngaytra,
            this.Duno,
            this.Tienlai});
            this.dtGridCF.Location = new System.Drawing.Point(2, 73);
            this.dtGridCF.MultiSelect = false;
            this.dtGridCF.Name = "dtGridCF";
            this.dtGridCF.Size = new System.Drawing.Size(333, 258);
            this.dtGridCF.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ma hop dong";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lai suat";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Enabled = false;
            this.txtMaHD.Location = new System.Drawing.Point(100, 6);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(122, 20);
            this.txtMaHD.TabIndex = 11;
            // 
            // txtLaisuat
            // 
            this.txtLaisuat.Enabled = false;
            this.txtLaisuat.Location = new System.Drawing.Point(100, 39);
            this.txtLaisuat.Name = "txtLaisuat";
            this.txtLaisuat.Size = new System.Drawing.Size(122, 20);
            this.txtLaisuat.TabIndex = 12;
            // 
            // MaDongTien
            // 
            this.MaDongTien.HeaderText = "Ma Dong Tien";
            this.MaDongTien.Name = "MaDongTien";
            // 
            // Ngaytra
            // 
            this.Ngaytra.HeaderText = "Ngay tra";
            this.Ngaytra.Name = "Ngaytra";
            // 
            // Duno
            // 
            this.Duno.HeaderText = "Du no goc";
            this.Duno.Name = "Duno";
            // 
            // Tienlai
            // 
            this.Tienlai.HeaderText = "Tien lai";
            this.Tienlai.Name = "Tienlai";
            // 
            // Tinhlai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 370);
            this.Controls.Add(this.txtLaisuat);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dtGridCF);
            this.Name = "Tinhlai";
            this.Text = "Tinhlai";
            this.Load += new System.EventHandler(this.Tinhlai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView dtGridCF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.TextBox txtLaisuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaytra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tienlai;
    }
}