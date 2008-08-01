namespace Quanlydongtien
{
    partial class Dongtienngay
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
            this.dtGridCash = new System.Windows.Forms.DataGridView();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tienvao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tienra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ducuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblthang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDuno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCash)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridCash
            // 
            this.dtGridCash.AllowUserToAddRows = false;
            this.dtGridCash.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridCash.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridCash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCash.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ngay,
            this.Tienvao,
            this.Tienra,
            this.Ducuoi});
            this.dtGridCash.Location = new System.Drawing.Point(2, 37);
            this.dtGridCash.Name = "dtGridCash";
            this.dtGridCash.Size = new System.Drawing.Size(345, 442);
            this.dtGridCash.TabIndex = 2;
            this.dtGridCash.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtGridCash_CellMouseDoubleClick);
            this.dtGridCash.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCash_CellContentClick);
            // 
            // Ngay
            // 
            this.Ngay.HeaderText = "Nam";
            this.Ngay.Name = "Ngay";
            this.Ngay.Width = 54;
            // 
            // Tienvao
            // 
            this.Tienvao.HeaderText = "Tien vao";
            this.Tienvao.Name = "Tienvao";
            this.Tienvao.Width = 74;
            // 
            // Tienra
            // 
            this.Tienra.HeaderText = "Tien ra";
            this.Tienra.Name = "Tienra";
            this.Tienra.Width = 65;
            // 
            // Ducuoi
            // 
            this.Ducuoi.HeaderText = "So du cuoi";
            this.Ducuoi.Name = "Ducuoi";
            this.Ducuoi.Width = 83;
            // 
            // lblthang
            // 
            this.lblthang.AutoSize = true;
            this.lblthang.Location = new System.Drawing.Point(121, 9);
            this.lblthang.Name = "lblthang";
            this.lblthang.Size = new System.Drawing.Size(29, 13);
            this.lblthang.TabIndex = 6;
            this.lblthang.Text = "Nam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bao cao dong tien ngay:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Nam";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tien vao";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 74;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tien ra";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 65;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "So du cuoi";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Du no cu:";
            // 
            // lblDuno
            // 
            this.lblDuno.AutoSize = true;
            this.lblDuno.Location = new System.Drawing.Point(227, 9);
            this.lblDuno.Name = "lblDuno";
            this.lblDuno.Size = new System.Drawing.Size(29, 13);
            this.lblDuno.TabIndex = 8;
            this.lblDuno.Text = "Nam";
            // 
            // Dongtienngay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 477);
            this.Controls.Add(this.lblDuno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblthang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGridCash);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(356, 511);
            this.MinimumSize = new System.Drawing.Size(356, 511);
            this.Name = "Dongtienngay";
            this.Text = "Dongtienngay";
            this.Load += new System.EventHandler(this.Dongtienngay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridCash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tienvao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tienra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ducuoi;
        private System.Windows.Forms.Label lblthang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDuno;
    }
}