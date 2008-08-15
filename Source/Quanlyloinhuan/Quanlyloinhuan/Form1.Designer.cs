namespace Quanlyloinhuan
{
    partial class Form1
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
            this.dtGridProfit = new System.Windows.Forms.DataGridView();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoiNhuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tienvon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tysuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkReal = new System.Windows.Forms.CheckBox();
            this.dtGridProMonth = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNam = new System.Windows.Forms.Label();
            this.cmdExpLoiNhuanNam = new System.Windows.Forms.Button();
            this.cmdLoiNhuanThang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridProMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridProfit
            // 
            this.dtGridProfit.AllowUserToAddRows = false;
            this.dtGridProfit.AllowUserToDeleteRows = false;
            this.dtGridProfit.AllowUserToOrderColumns = true;
            this.dtGridProfit.AllowUserToResizeColumns = false;
            this.dtGridProfit.AllowUserToResizeRows = false;
            this.dtGridProfit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridProfit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridProfit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridProfit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nam,
            this.LoiNhuan,
            this.Tienvon,
            this.Tysuat});
            this.dtGridProfit.Location = new System.Drawing.Point(2, 34);
            this.dtGridProfit.Name = "dtGridProfit";
            this.dtGridProfit.ReadOnly = true;
            this.dtGridProfit.Size = new System.Drawing.Size(406, 291);
            this.dtGridProfit.TabIndex = 2;
            this.dtGridProfit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridProfit_CellDoubleClick);
            this.dtGridProfit.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtGridProfit_ColumnHeaderMouseClick);
            this.dtGridProfit.AllowUserToOrderColumnsChanged += new System.EventHandler(this.dtGridProfit_AllowUserToOrderColumnsChanged);
            // 
            // Nam
            // 
            this.Nam.HeaderText = "Nam";
            this.Nam.Name = "Nam";
            this.Nam.ReadOnly = true;
            this.Nam.Width = 54;
            // 
            // LoiNhuan
            // 
            this.LoiNhuan.HeaderText = "Loi nhuan";
            this.LoiNhuan.Name = "LoiNhuan";
            this.LoiNhuan.ReadOnly = true;
            this.LoiNhuan.Width = 73;
            // 
            // Tienvon
            // 
            this.Tienvon.HeaderText = "Tien von";
            this.Tienvon.Name = "Tienvon";
            this.Tienvon.ReadOnly = true;
            this.Tienvon.Width = 69;
            // 
            // Tysuat
            // 
            this.Tysuat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tysuat.HeaderText = "Ty suat loi nhuan tren von";
            this.Tysuat.Name = "Tysuat";
            this.Tysuat.ReadOnly = true;
            this.Tysuat.Width = 106;
            // 
            // chkReal
            // 
            this.chkReal.AutoSize = true;
            this.chkReal.Location = new System.Drawing.Point(2, 11);
            this.chkReal.Name = "chkReal";
            this.chkReal.Size = new System.Drawing.Size(80, 17);
            this.chkReal.TabIndex = 3;
            this.chkReal.Text = "Du lieu that";
            this.chkReal.UseVisualStyleBackColor = true;
            this.chkReal.CheckedChanged += new System.EventHandler(this.chkReal_CheckedChanged);
            // 
            // dtGridProMonth
            // 
            this.dtGridProMonth.AllowUserToAddRows = false;
            this.dtGridProMonth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridProMonth.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridProMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridProMonth.Location = new System.Drawing.Point(414, 34);
            this.dtGridProMonth.Name = "dtGridProMonth";
            this.dtGridProMonth.ReadOnly = true;
            this.dtGridProMonth.Size = new System.Drawing.Size(185, 291);
            this.dtGridProMonth.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nam:";
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(453, 12);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(0, 13);
            this.lblNam.TabIndex = 6;
            // 
            // cmdExpLoiNhuanNam
            // 
            this.cmdExpLoiNhuanNam.Location = new System.Drawing.Point(292, 331);
            this.cmdExpLoiNhuanNam.Name = "cmdExpLoiNhuanNam";
            this.cmdExpLoiNhuanNam.Size = new System.Drawing.Size(116, 23);
            this.cmdExpLoiNhuanNam.TabIndex = 7;
            this.cmdExpLoiNhuanNam.Text = "Export To Excel";
            this.cmdExpLoiNhuanNam.UseVisualStyleBackColor = true;
            this.cmdExpLoiNhuanNam.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdLoiNhuanThang
            // 
            this.cmdLoiNhuanThang.Location = new System.Drawing.Point(483, 331);
            this.cmdLoiNhuanThang.MaximumSize = new System.Drawing.Size(116, 23);
            this.cmdLoiNhuanThang.MinimumSize = new System.Drawing.Size(116, 23);
            this.cmdLoiNhuanThang.Name = "cmdLoiNhuanThang";
            this.cmdLoiNhuanThang.Size = new System.Drawing.Size(116, 23);
            this.cmdLoiNhuanThang.TabIndex = 8;
            this.cmdLoiNhuanThang.Text = "Export To Excel";
            this.cmdLoiNhuanThang.UseVisualStyleBackColor = true;
            this.cmdLoiNhuanThang.Click += new System.EventHandler(this.cmdLoiNhuanThang_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 361);
            this.Controls.Add(this.cmdLoiNhuanThang);
            this.Controls.Add(this.cmdExpLoiNhuanNam);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGridProMonth);
            this.Controls.Add(this.chkReal);
            this.Controls.Add(this.dtGridProfit);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Loi nhuan kinh doanh";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridProMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoiNhuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tienvon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tysuat;
        private System.Windows.Forms.CheckBox chkReal;
        private System.Windows.Forms.DataGridView dtGridProMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Button cmdExpLoiNhuanNam;
        private System.Windows.Forms.Button cmdLoiNhuanThang;
    }
}

