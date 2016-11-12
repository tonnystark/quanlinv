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
            ma = GetMa("PB");
            txtMa.Text = ma;

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
            ReSetText();
        }

        protected override void OnLoad()
        {


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
            if (!IsEmptyTextbox())
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
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
        }



        int lastIndex = -1;
        protected override void OnUpdate()
        {
            if (!IsEmptyTextbox())
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

            DataGridViewRow dr = dgvDanhSach.SelectedRows[0];
            txtMa.Text = dr.Cells[0].Value.ToString();
            txtTenPhong.Text = dr.Cells[1].Value.ToString();
            txtDiaChi.Text = dr.Cells[2].Value.ToString();
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

        void SetFocusRow(int index)
        {
            if (index != -1)
                dgvDanhSach.Rows[index].Selected = true;
        }

    }
}