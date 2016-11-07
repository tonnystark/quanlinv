using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiNhanSu.DTO;
using QuanLiNhanSu.BUS;

namespace QuanLiNhanSu
{
    public partial class frmPhongBan : frmBase
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }

        string ma = "";
        protected override void OnAdd()
        {
            ReSetText();
            ma = GetMaPB();
            txtMa.Text = ma;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenPhong.Focus();
        }

        void ReSetText()
        {
            txtMa.Clear();
            txtDiaChi.Clear();
            txtTenPhong.Clear();

            txtTenPhong.Focus();
        }

        protected override void OnCancel()
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

            ReSetText();
        }

        protected override void OnLoad()
        {
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            txtMa.Enabled = false;

            LoadPhongBan();
            ChangeHeaderName();
        }

        void ChangeHeaderName()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã phòng";
            dgvDanhSach.Columns[1].HeaderText = "Tên phòng";
            dgvDanhSach.Columns[2].HeaderText = "Địa chỉ";
        }

        protected override void OnSave()
        {
            if (String.IsNullOrWhiteSpace(txtTenPhong.Text) || String.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin");
                return;
            }
            else
            {
                PhongBanDTO pb = new PhongBanDTO { MaPB = ma, TenPB = ChangeNameStyle(txtTenPhong.Text), DiaChi = txtDiaChi.Text };
                if (PhongBan_BUS.AddPhongBan(pb))
                {
                    LoadPhongBan();
                    MessageBox.Show("Thêm thành công");
                    btnLuu.Enabled = false;
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
        }


        int lastIndex = -1;
        protected override void OnUpdate()
        {
            if (String.IsNullOrWhiteSpace(txtTenPhong.Text) || String.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin");
                return;
            }
            else
            {
                PhongBanDTO pb = new PhongBanDTO { MaPB = txtMa.Text, TenPB = ChangeNameStyle(txtTenPhong.Text), DiaChi = txtDiaChi.Text };
                if (PhongBan_BUS.UpdatePhongBan(pb))
                {
                    // tìm lastIndex
                    lastIndex = dgvDanhSach.CurrentRow.Index;
                    LoadPhongBan();                  
                    SetFocusRow(lastIndex);
                    MessageBox.Show("Sửa thành công");                    
                }
                else
                    MessageBox.Show("Sửa thất bại");
            }
        }

        private void LoadPhongBan()
        {
            DataTable dt = PhongBan_BUS.GetPhongBan();
            dgvDanhSach.DataSource = dt;
        }

        protected override void OnDgvClick()
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            DataGridViewRow dr = dgvDanhSach.SelectedRows[0];
            txtMa.Text = dr.Cells[0].Value.ToString();
            txtTenPhong.Text = dr.Cells[1].Value.ToString();
            txtDiaChi.Text = dr.Cells[2].Value.ToString();
        }

        private string GetMaPB()
        {
            string ma = "PB";
            Random rd = new Random();
            int i = rd.Next(1000);

            if (i < 10)
                ma = "PB00";
            else if (i < 100)
                ma = "PB0";

            return (ma + i.ToString());
        }

        protected override void OnDelete()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataGridViewRow dr = dgvDanhSach.SelectedRows[0];
                string ma = dr.Cells[0].Value.ToString();

                if (PhongBan_BUS.DeletePhongBan(ma))
                {
                    LoadPhongBan();
                    MessageBox.Show("Xóa thành công");
                    ReSetText();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        // đổi sang kiểu chữ Hoa đầu cho tên
        private string ChangeNameStyle(string name)
        {
            // loại bỏ khoảng trắng và Chuyển Style
            // thạch mu ni => Thạch Mu Ni
            name = RemoveWhiteSpace(name);

            string[] arrStr = name.Split(' ');

            string result = "";

            for (int i = 0; i < arrStr.Length; i++)
            {
                arrStr[i] = arrStr[i].Substring(0, 1).ToUpper() + arrStr[i].Substring(1).ToLower() + " ";
                result += arrStr[i];
            }

            return result;
        }
        private string RemoveWhiteSpace(string str)
        {
            string[] arrStr = str.Split(new char[] { ' ' }, 10, StringSplitOptions.RemoveEmptyEntries);
            string strResult = "";
            foreach (var item in arrStr)
            {
                strResult += item + " ";
            }
            return strResult.Trim();
        }


        void SetFocusRow(int index)
        {
        
            if (index != -1)
                dgvDanhSach.Rows[index].Selected = true;
        }

    }
}