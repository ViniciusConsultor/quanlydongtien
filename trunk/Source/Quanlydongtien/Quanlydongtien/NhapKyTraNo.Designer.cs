namespace Quanlydongtien
{
    partial class NhapKyTraNo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSolan = new System.Windows.Forms.TextBox();
            this.cmdSolan = new System.Windows.Forms.Button();
            this.dtGridCF = new System.Windows.Forms.DataGridView();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCF)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "So lan tra";
            // 
            // txtSolan
            // 
            this.txtSolan.Location = new System.Drawing.Point(99, 14);
            this.txtSolan.Name = "txtSolan";
            this.txtSolan.Size = new System.Drawing.Size(73, 20);
            this.txtSolan.TabIndex = 1;
            this.txtSolan.TextChanged += new System.EventHandler(this.txtSolan_TextChanged);
            // 
            // cmdSolan
            // 
            this.cmdSolan.Location = new System.Drawing.Point(183, 12);
            this.cmdSolan.Name = "cmdSolan";
            this.cmdSolan.Size = new System.Drawing.Size(75, 23);
            this.cmdSolan.TabIndex = 2;
            this.cmdSolan.Text = "Chap nhan";
            this.cmdSolan.UseVisualStyleBackColor = true;
            this.cmdSolan.Click += new System.EventHandler(this.cmdSolan_Click);
            // 
            // dtGridCF
            // 
            this.dtGridCF.AllowUserToAddRows = false;
            this.dtGridCF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCF.Location = new System.Drawing.Point(4, 74);
            this.dtGridCF.MultiSelect = false;
            this.dtGridCF.Name = "dtGridCF";
            this.dtGridCF.Size = new System.Drawing.Size(254, 225);
            this.dtGridCF.TabIndex = 3;
            this.dtGridCF.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCF_CellContentClick_1);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(36, 305);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 30);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Luu lai";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click_1);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(129, 305);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 30);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Dong";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tong so tien";
            // 
            // txtTong
            // 
            this.txtTong.Enabled = false;
            this.txtTong.Location = new System.Drawing.Point(99, 46);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(159, 20);
            this.txtTong.TabIndex = 7;
            // 
            // NhapKyTraNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 337);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dtGridCF);
            this.Controls.Add(this.cmdSolan);
            this.Controls.Add(this.txtSolan);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(271, 371);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(271, 371);
            this.Name = "NhapKyTraNo";
            this.Text = "NhapKyTraNo";
            this.Load += new System.EventHandler(this.NhapKyTraNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSolan;
        private System.Windows.Forms.Button cmdSolan;
        private System.Windows.Forms.DataGridView dtGridCF;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTong;
    }
}