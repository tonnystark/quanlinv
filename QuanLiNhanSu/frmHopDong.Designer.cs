namespace QuanLiNhanSu
{
    partial class frmHopDong
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.cmbNV = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.grpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(10)))), ((int)(((byte)(62)))));
            this.groupControl1.Location = new System.Drawing.Point(101, 12);
            this.groupControl1.Size = new System.Drawing.Size(1020, 400);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.Text = "Mã HĐ";
            // 
            // txtMa
            // 
            this.txtMa.Size = new System.Drawing.Size(192, 27);
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.cmbNV);
            this.grpControl.Controls.Add(this.cmbLoai);
            this.grpControl.Controls.Add(this.dtpNgayKT);
            this.grpControl.Controls.Add(this.dtpNgayBD);
            this.grpControl.Controls.Add(this.label6);
            this.grpControl.Controls.Add(this.label5);
            this.grpControl.Controls.Add(this.label4);
            this.grpControl.Controls.Add(this.label3);
            this.grpControl.Controls.Add(this.label2);
            this.grpControl.Controls.Add(this.txtMoTa);
            this.grpControl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpControl.Text = "Thông tin hợp đồng";
            this.grpControl.Controls.SetChildIndex(this.txtMa, 0);
            this.grpControl.Controls.SetChildIndex(this.btnThem, 0);
            this.grpControl.Controls.SetChildIndex(this.btnSua, 0);
            this.grpControl.Controls.SetChildIndex(this.label1, 0);
            this.grpControl.Controls.SetChildIndex(this.btnHuy, 0);
            this.grpControl.Controls.SetChildIndex(this.btnThoat, 0);
            this.grpControl.Controls.SetChildIndex(this.btnXoa, 0);
            this.grpControl.Controls.SetChildIndex(this.btnLuu, 0);
            this.grpControl.Controls.SetChildIndex(this.txtMoTa, 0);
            this.grpControl.Controls.SetChildIndex(this.label2, 0);
            this.grpControl.Controls.SetChildIndex(this.label3, 0);
            this.grpControl.Controls.SetChildIndex(this.label4, 0);
            this.grpControl.Controls.SetChildIndex(this.label5, 0);
            this.grpControl.Controls.SetChildIndex(this.label6, 0);
            this.grpControl.Controls.SetChildIndex(this.dtpNgayBD, 0);
            this.grpControl.Controls.SetChildIndex(this.dtpNgayKT, 0);
            this.grpControl.Controls.SetChildIndex(this.cmbLoai, 0);
            this.grpControl.Controls.SetChildIndex(this.cmbNV, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(34, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Mã NV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(34, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Loại hợp đồng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(34, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(34, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Ngày kết thúc";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMoTa.Location = new System.Drawing.Point(148, 199);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(192, 27);
            this.txtMoTa.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(34, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Mô tả";
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayBD.Location = new System.Drawing.Point(148, 133);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(192, 27);
            this.dtpNgayBD.TabIndex = 2;
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayKT.Location = new System.Drawing.Point(148, 166);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(192, 27);
            this.dtpNgayKT.TabIndex = 3;
            this.dtpNgayKT.ValueChanged += new System.EventHandler(this.dtpNgayKT_ValueChanged);
            // 
            // cmbLoai
            // 
            this.cmbLoai.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Location = new System.Drawing.Point(148, 100);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(192, 28);
            this.cmbLoai.TabIndex = 1;
            // 
            // cmbNV
            // 
            this.cmbNV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbNV.FormattingEnabled = true;
            this.cmbNV.Location = new System.Drawing.Point(148, 66);
            this.cmbNV.Name = "cmbNV";
            this.cmbNV.Size = new System.Drawing.Size(192, 28);
            this.cmbNV.TabIndex = 1;
            // 
            // frmHopDong
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(10)))), ((int)(((byte)(62)))));
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(10)))), ((int)(((byte)(92)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 571);
            this.Name = "frmHopDong";
            this.Text = "frmHopDong";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.ComboBox cmbNV;
    }
}