namespace Quanlydongtien
{
    partial class Dongtiennam
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
            this.chkReal = new System.Windows.Forms.CheckBox();
            this.dtGridCash = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tienvao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tienra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ducuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCash)).BeginInit();
            this.SuspendLayout();
            // 
            // chkReal
            // 
            this.chkReal.AutoSize = true;
            this.chkReal.Location = new System.Drawing.Point(7, 10);
            this.chkReal.Name = "chkReal";
            this.chkReal.Size = new System.Drawing.Size(80, 17);
            this.chkReal.TabIndex = 0;
            this.chkReal.Text = "Du lieu that";
            this.chkReal.UseVisualStyleBackColor = true;
            this.chkReal.CheckedChanged += new System.EventHandler(this.chkReal_CheckedChanged);
            // 
            // dtGridCash
            // 
            this.dtGridCash.AllowUserToAddRows = false;
            this.dtGridCash.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridCash.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridCash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCash.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nam,
            this.Tienvao,
            this.Tienra,
            this.Ducuoi});
            this.dtGridCash.Location = new System.Drawing.Point(-2, 33);
            this.dtGridCash.Name = "dtGridCash";
            this.dtGridCash.Size = new System.Drawing.Size(396, 442);
            this.dtGridCash.TabIndex = 1;
            this.dtGridCash.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCash_CellContentDoubleClick);
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
            // Nam
            // 
            this.Nam.HeaderText = "Nam";
            this.Nam.Name = "Nam";
            this.Nam.Width = 54;
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
            // Dongtiennam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 477);
            this.Controls.Add(this.dtGridCash);
            this.Controls.Add(this.chkReal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(402, 511);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(402, 511);
            this.Name = "Dongtiennam";
            this.Text = "Dongtiennam";
            this.Load += new System.EventHandler(this.Dongtiennam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkReal;
        private System.Windows.Forms.DataGridView dtGridCash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tienvao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tienra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ducuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}