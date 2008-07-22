namespace Quanlydongtien
{
    partial class Quanlykhachhang
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
            this.dtGridKH = new System.Windows.Forms.DataGridView();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxLoaiKH = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridKH)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridKH
            // 
            this.dtGridKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridKH.Location = new System.Drawing.Point(0, 52);
            this.dtGridKH.MultiSelect = false;
            this.dtGridKH.Name = "dtGridKH";
            this.dtGridKH.Size = new System.Drawing.Size(559, 269);
            this.dtGridKH.TabIndex = 0;
            this.dtGridKH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridKH_CellContentClick);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(222, 327);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Them moi";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(303, 327);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Dong";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Phan loai khach hang";
            // 
            // cbxLoaiKH
            // 
            this.cbxLoaiKH.FormattingEnabled = true;
            this.cbxLoaiKH.Location = new System.Drawing.Point(147, 17);
            this.cbxLoaiKH.Name = "cbxLoaiKH";
            this.cbxLoaiKH.Size = new System.Drawing.Size(121, 21);
            this.cbxLoaiKH.TabIndex = 8;
            this.cbxLoaiKH.SelectedIndexChanged += new System.EventHandler(this.cbxLoaiKH_SelectedIndexChanged);
            // 
            // Quanlykhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 356);
            this.Controls.Add(this.cbxLoaiKH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.dtGridKH);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Quanlykhachhang";
            this.Text = "Quanlykhachhang";
            this.Load += new System.EventHandler(this.Quanlykhachhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridKH;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxLoaiKH;
    }
}