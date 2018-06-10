namespace Quản_lý_bán_hàng_siêu_thị
{
    partial class frmdn
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
            this.lbtk = new System.Windows.Forms.Label();
            this.txttk = new System.Windows.Forms.TextBox();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.lbmk = new System.Windows.Forms.Label();
            this.btndn = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbtk
            // 
            this.lbtk.AutoSize = true;
            this.lbtk.BackColor = System.Drawing.Color.Transparent;
            this.lbtk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbtk.ForeColor = System.Drawing.Color.White;
            this.lbtk.Location = new System.Drawing.Point(89, 48);
            this.lbtk.Name = "lbtk";
            this.lbtk.Size = new System.Drawing.Size(76, 19);
            this.lbtk.TabIndex = 1;
            this.lbtk.Text = "Tài khoản";
            // 
            // txttk
            // 
            this.txttk.Location = new System.Drawing.Point(264, 47);
            this.txttk.Name = "txttk";
            this.txttk.Size = new System.Drawing.Size(151, 20);
            this.txttk.TabIndex = 2;
            // 
            // txtmk
            // 
            this.txtmk.Location = new System.Drawing.Point(264, 107);
            this.txtmk.Name = "txtmk";
            this.txtmk.Size = new System.Drawing.Size(151, 20);
            this.txtmk.TabIndex = 3;
            // 
            // lbmk
            // 
            this.lbmk.AutoSize = true;
            this.lbmk.BackColor = System.Drawing.Color.Transparent;
            this.lbmk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbmk.ForeColor = System.Drawing.Color.White;
            this.lbmk.Location = new System.Drawing.Point(89, 108);
            this.lbmk.Name = "lbmk";
            this.lbmk.Size = new System.Drawing.Size(75, 19);
            this.lbmk.TabIndex = 4;
            this.lbmk.Text = "Mật khẩu";
            // 
            // btndn
            // 
            this.btndn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btndn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btndn.Location = new System.Drawing.Point(103, 168);
            this.btndn.Name = "btndn";
            this.btndn.Size = new System.Drawing.Size(98, 52);
            this.btndn.TabIndex = 5;
            this.btndn.Text = "Đăng nhập";
            this.btndn.UseVisualStyleBackColor = false;
            this.btndn.Click += new System.EventHandler(this.btndn_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnthoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthoat.Location = new System.Drawing.Point(275, 168);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(102, 52);
            this.btnthoat.TabIndex = 6;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // frmdn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quản_lý_bán_hàng_siêu_thị.Properties.Resources._0459a3158144a863bec50fdb4019f34e;
            this.ClientSize = new System.Drawing.Size(497, 261);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btndn);
            this.Controls.Add(this.lbmk);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.txttk);
            this.Controls.Add(this.lbtk);
            this.Name = "frmdn";
            this.Text = "Đăng nhập hệ thống";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbtk;
        private System.Windows.Forms.TextBox txttk;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.Label lbmk;
        private System.Windows.Forms.Button btndn;
        private System.Windows.Forms.Button btnthoat;
    }
}

