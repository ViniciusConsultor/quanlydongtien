namespace Quanlydongtien
{
    partial class Quanlydongtien
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
            this.dtGridCFG = new System.Windows.Forms.DataGridView();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdUpadate = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.dtGridCFL = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCFG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCFL)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridCFG
            // 
            this.dtGridCFG.AllowUserToAddRows = false;
            this.dtGridCFG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCFG.Location = new System.Drawing.Point(3, 71);
            this.dtGridCFG.Name = "dtGridCFG";
            this.dtGridCFG.Size = new System.Drawing.Size(452, 255);
            this.dtGridCFG.TabIndex = 0;
            this.dtGridCFG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCFG_CellEndEdit);
            this.dtGridCFG.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCFG_CellValueChanged);
            this.dtGridCFG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCFG_CellContentClick);
            // 
            // txtMaHD
            // 
            this.txtMaHD.Enabled = false;
            this.txtMaHD.Location = new System.Drawing.Point(81, 25);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(100, 20);
            this.txtMaHD.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ma hop dong";
            // 
            // cmdUpadate
            // 
            this.cmdUpadate.Location = new System.Drawing.Point(299, 13);
            this.cmdUpadate.Name = "cmdUpadate";
            this.cmdUpadate.Size = new System.Drawing.Size(75, 43);
            this.cmdUpadate.TabIndex = 4;
            this.cmdUpadate.Text = "Cap nhat";
            this.cmdUpadate.UseVisualStyleBackColor = true;
            this.cmdUpadate.Click += new System.EventHandler(this.cmdUpadate_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(380, 13);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 43);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Dong";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dtGridCFL
            // 
            this.dtGridCFL.AllowUserToAddRows = false;
            this.dtGridCFL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCFL.Location = new System.Drawing.Point(3, 351);
            this.dtGridCFL.Name = "dtGridCFL";
            this.dtGridCFL.Size = new System.Drawing.Size(452, 255);
            this.dtGridCFL.TabIndex = 6;
            this.dtGridCFL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCFL_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tien goc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tien lai";
            // 
            // Quanlydongtien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 610);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtGridCFL);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdUpadate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.dtGridCFG);
            this.Name = "Quanlydongtien";
            this.Text = "Quanlydongtien";
            this.Load += new System.EventHandler(this.Quanlydongtien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCFG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCFL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridCFG;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdUpadate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridView dtGridCFL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}