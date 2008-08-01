namespace Quanlydongtien
{
    partial class Quanlyvon
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTienvon = new System.Windows.Forms.TextBox();
            this.txtTienmat = new System.Windows.Forms.TextBox();
            this.txtLai = new System.Windows.Forms.TextBox();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Von tu co:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tien mat:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tien lai:";
            // 
            // txtTienvon
            // 
            this.txtTienvon.Location = new System.Drawing.Point(74, 18);
            this.txtTienvon.Name = "txtTienvon";
            this.txtTienvon.Size = new System.Drawing.Size(123, 20);
            this.txtTienvon.TabIndex = 3;
            // 
            // txtTienmat
            // 
            this.txtTienmat.Location = new System.Drawing.Point(74, 50);
            this.txtTienmat.Name = "txtTienmat";
            this.txtTienmat.ReadOnly = true;
            this.txtTienmat.Size = new System.Drawing.Size(123, 20);
            this.txtTienmat.TabIndex = 4;
            // 
            // txtLai
            // 
            this.txtLai.Location = new System.Drawing.Point(74, 85);
            this.txtLai.Name = "txtLai";
            this.txtLai.ReadOnly = true;
            this.txtLai.Size = new System.Drawing.Size(123, 20);
            this.txtLai.TabIndex = 5;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(214, 15);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdate.TabIndex = 6;
            this.cmdUpdate.Text = "Cap nhat";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(214, 52);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 52);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "Dong";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Quanlyvon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 118);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.txtLai);
            this.Controls.Add(this.txtTienmat);
            this.Controls.Add(this.txtTienvon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Quanlyvon";
            this.Text = "Quanlyvon";
            this.Load += new System.EventHandler(this.Quanlyvon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTienvon;
        private System.Windows.Forms.TextBox txtTienmat;
        private System.Windows.Forms.TextBox txtLai;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdClose;
    }
}