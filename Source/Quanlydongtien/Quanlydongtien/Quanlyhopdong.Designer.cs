namespace Quanlydongtien
{
    partial class Quanlyhopdong
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
            this.cmdAdd = new System.Windows.Forms.Button();
            this.dtGridContracts = new System.Windows.Forms.DataGridView();
            this.cbxCusName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMoney = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(461, 392);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(150, 35);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "Dong";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(305, 392);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(150, 35);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "Them moi";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // dtGridContracts
            // 
            this.dtGridContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridContracts.Location = new System.Drawing.Point(1, 54);
            this.dtGridContracts.MultiSelect = false;
            this.dtGridContracts.Name = "dtGridContracts";
            this.dtGridContracts.ReadOnly = true;
            this.dtGridContracts.Size = new System.Drawing.Size(609, 332);
            this.dtGridContracts.TabIndex = 4;
            this.dtGridContracts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridContracts_CellContentDoubleClick);
            this.dtGridContracts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridContracts_CellContentClick);
            // 
            // cbxCusName
            // 
            this.cbxCusName.FormattingEnabled = true;
            this.cbxCusName.Location = new System.Drawing.Point(118, 12);
            this.cbxCusName.Name = "cbxCusName";
            this.cbxCusName.Size = new System.Drawing.Size(121, 21);
            this.cbxCusName.TabIndex = 10;
            this.cbxCusName.SelectedIndexChanged += new System.EventHandler(this.cbxCusName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ten Khach Hang";
            // 
            // cbxMoney
            // 
            this.cbxMoney.FormattingEnabled = true;
            this.cbxMoney.Items.AddRange(new object[] {
            "50000000",
            "100000000",
            "200000000",
            "500000000",
            "1000000000",
            "10000000000",
            "100000000000",
            "1000000000000",
            "All"});
            this.cbxMoney.Location = new System.Drawing.Point(382, 12);
            this.cbxMoney.Name = "cbxMoney";
            this.cbxMoney.Size = new System.Drawing.Size(121, 21);
            this.cbxMoney.TabIndex = 12;
            this.cbxMoney.Text = "All";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Gia tri hop dong tren";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Tim kiem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(151, 392);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(150, 35);
            this.cmdEdit.TabIndex = 14;
            this.cmdEdit.Text = "Chinh sua";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // Quanlyhopdong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 429);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCusName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.dtGridContracts);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(623, 463);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(623, 463);
            this.Name = "Quanlyhopdong";
            this.Text = "Quanlyhopdong";
            this.Load += new System.EventHandler(this.Quanlyhopdong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContracts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.DataGridView dtGridContracts;
        private System.Windows.Forms.ComboBox cbxCusName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdEdit;
    }
}