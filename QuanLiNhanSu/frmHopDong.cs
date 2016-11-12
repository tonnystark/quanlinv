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
using QuanLiNhanSu.BUS;
using QuanLiNhanSu.DTO;

namespace QuanLiNhanSu
{
    public partial class frmHopDong : frmBase
    {
        public frmHopDong()
        {
            InitializeComponent();
            cmbNV.KeyPress += CmbNV_KeyPress;
        }

        private void frmHopDong_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
        protected override void OnLoad()
        {
            LoadHopDong();
            LoadLoaiHD();
            LoadMaNV();



            ChangeHeaderName();
        }

        private void LoadHopDong()
        {
            DataTable dt = HopDong_BUS.GetHopDong();
            dgvDanhSach.DataSource = dt;
        }

        string maHD = "";
        protected override void OnAdd()
        {
            ReSetText();
            maHD = GetMa("HD");
            txtMa.Text = maHD;
        }

        void ReSetText()
        {
            txtMa.Clear();
            txtMoTa.Clear();

            cmbLoai.SelectedIndex = 0;
            cmbNV.SelectedIndex = 0;
            dtpNgayBD.ResetText();
            dtpNgayKT.ResetText();
        }

        protected override void OnUpdate()
        {
            if (!IsEmptyTextbox() || !IsValidDate())
            {
                MessageBox.Show("Mời bạn kiểm tra lại thông tin");
                return;
            }
            else
            {
                HopDongDTO hd = new HopDongDTO { MaHD = txtMa.Text, MaNV = cmbNV.Text, LoaiHD = cmbLoai.Text, MoTa = txtMoTa.Text, NgayBD = DateTime.Parse(dtpNgayBD.Value.ToShortDateString()), NgayKT = DateTime.Parse(dtpNgayKT.Value.ToShortDateString()) };
                if (HopDong_BUS.UpdateHopDong(hd))
                {
                    LoadHopDong();
                    MessageBox.Show("Sửa thành công");
                }
                else
                    MessageBox.Show("Sửa thất bại");
            }
        }

        protected override void OnSave()
        {
            if (!IsEmptyTextbox() || !IsValidDate())
            {
                MessageBox.Show("Mời bạn kiểm tra lại thông tin");
                return;
            }
            else
            {
                HopDongDTO hd = new HopDongDTO { MaHD = maHD, MaNV = cmbNV.Text, LoaiHD = cmbLoai.Text, MoTa = txtMoTa.Text, NgayBD = DateTime.Parse(dtpNgayBD.Value.ToShortDateString()), NgayKT = DateTime.Parse(dtpNgayKT.Value.ToShortDateString()) };
                if (HopDong_BUS.AddHopDong(hd))
                {
                    LoadHopDong();
                    MessageBox.Show("Thêm thành công");
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }

        }

        protected override void OnDelete()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataGridViewRow dr = dgvDanhSach.SelectedRows[0];
                string ma = dr.Cells[0].Value.ToString();

                if (HopDong_BUS.DeleteHopDong(ma))
                {
                    LoadHopDong();
                    MessageBox.Show("Xóa thành công");
                    ReSetText();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        protected override void OnDgvClick()
        {
            DataGridViewRow dr = dgvDanhSach.SelectedRows[0];

            txtMa.Text = dr.Cells[0].Value.ToString();
            cmbNV.Text = dr.Cells[1].Value.ToString();
            cmbLoai.Text = dr.Cells[2].Value.ToString();
            dtpNgayBD.Text = dr.Cells[3].Value.ToString();
            dtpNgayKT.Text = dr.Cells[4].Value.ToString();
            txtMoTa.Text = dr.Cells[5].Value.ToString();
        }

        protected override void OnCancel()
        {
            ReSetText();
        }

        void ChangeHeaderName()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã HĐ";
            dgvDanhSach.Columns[1].HeaderText = "Mã NV";
            dgvDanhSach.Columns[2].HeaderText = "Loại hợp đồng";
            dgvDanhSach.Columns[3].HeaderText = "Ngày bắt đầu";
            dgvDanhSach.Columns[4].HeaderText = "Ngày kết thúc";
            dgvDanhSach.Columns[5].HeaderText = "Mô tả";
        }

        void LoadLoaiHD()
        {
            cmbLoai.Items.Add("Ngắn hạn");
            cmbLoai.Items.Add("Dài hạn");
            cmbLoai.Items.Add("Tạm thời");

            cmbLoai.SelectedIndex = 0;
        }

        void LoadMaNV()
        {
            cmbNV.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbNV.AutoCompleteSource = AutoCompleteSource.ListItems;

            DataTable dt = NhanVien_BUS.GetAllMaNV();
            if (dt != null)
            {
                cmbNV.DataSource = dt;
            }
            cmbNV.DisplayMember = "MaNV";
            cmbNV.ValueMember = "MaNV";
            cmbNV.SelectedIndex = 0;

        }

        private void CmbNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbNV.DroppedDown = false;
        }

        private void dtpNgayKT_ValueChanged(object sender, EventArgs e)
        {
            if (!IsValidDate())
            {
                MessageBox.Show("Ngày kết thúc hợp đồng phải sau ngày bắt đầu hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayKT.ResetText();
            }
        }

        private bool IsValidDate()
        {
            return DateTime.Compare(dtpNgayBD.Value, dtpNgayKT.Value) <= 0;
        }
    }
}