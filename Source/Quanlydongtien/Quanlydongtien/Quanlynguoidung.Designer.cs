namespace Quanlydongtien
{
    partial class Quanlynguoidung
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
            this.dtGridUser = new System.Windows.Forms.DataGridView();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridUser
            // 
            this.dtGridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridUser.Location = new System.Drawing.Point(1, 0);
            this.dtGridUser.MultiSelect = false;
            this.dtGridUser.Name = "dtGridUser";
            this.dtGridUser.Size = new System.Drawing.Size(317, 225);
            this.dtGridUser.TabIndex = 1;
            this.dtGridUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridUser_CellContentClick);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(3, 231);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(67, 23);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "Them User";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(137, 231);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(60, 23);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "Dong";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(70, 231);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(65, 23);
            this.cmdDelete.TabIndex = 5;
            this.cmdDelete.Text = "Xoa";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // Quanlynguoidung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 260);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.dtGridUser);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(328, 294);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(328, 294);
            this.Name = "Quanlynguoidung";
            this.Text = "Quanlynguoidung";
            this.Load += new System.EventHandler(this.Quanlynguoidung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridUser;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdDelete;
    }
}