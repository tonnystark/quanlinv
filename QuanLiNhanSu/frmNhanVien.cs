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
using QuanLiNhanSu.DAO;
using QuanLiNhanSu.BUS;

namespace QuanLiNhanSu
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }



        private void LoadNhanVien()
        {
            DataTable dt = NhanVienDAO.GetNhanVien();
            dgvNhanVien.DataSource = dt;

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadPhongBan();
            LoadChuyenMon();
            LoadBacLuong();
            LoadChucVu();
            LoadGioiTinh();

            cmbBacLuong.SelectedIndex = 0;
            cmbChucVu.SelectedIndex = 0;
            cmbGioiTinh.SelectedIndex = 0;
            cmbChuyenMon.SelectedIndex = 0;
            cmbPhongBan.SelectedIndex = 0;

            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            txtMa.Enabled = false;

            ChangeHeaderName();
        }

        /// <summary>
        /// Đổi lại tên các cột
        /// </summary>
        void ChangeHeaderName()
        {
            dgvNhanVien.Columns[0].HeaderText = "Mã số";
            dgvNhanVien.Columns[1].HeaderText = "Họ và Tên";
            dgvNhanVien.Columns[2].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[3].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[4].HeaderText = "Giới tính";
            dgvNhanVien.Columns[5].HeaderText = "Mã PB";
            dgvNhanVien.Columns[6].HeaderText = "Mã CV";
            dgvNhanVien.Columns[7].HeaderText = "Mã CM";
            dgvNhanVien.Columns[8].HeaderText = "Bậc lương";
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtHoTen.Text) || String.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin");
                return;
            }
            else
            {
                NhanVienDTO nv = new NhanVienDTO(txtMa.Text, ChangeNameStyle(txtHoTen.Text), DateTime.Parse(dtpNgaySinh.Value.ToShortDateString()), txtDiaChi.Text, cmbGioiTinh.Text, cmbPhongBan.SelectedValue.ToString(), cmbChucVu.SelectedValue.ToString(), cmbChuyenMon.SelectedValue.ToString(), (int)cmbBacLuong.SelectedValue);

                if (NhanVien_BUS.UpdateNhanVien(nv))
                {
                    LoadNhanVien();
                    MessageBox.Show("Sửa thành công");                                        
                }
                else
                    MessageBox.Show("Sửa thất bại");
            }

        }

        string maNV = "";
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetText();
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            maNV = GetMaNV();
            txtMa.Text = maNV;
            txtHoTen.Focus();
        }

        void ResetText()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();

            cmbBacLuong.SelectedIndex = 0;
            cmbChucVu.SelectedIndex = 0;
            cmbGioiTinh.SelectedIndex = 0;
            cmbChuyenMon.SelectedIndex = 0;
            cmbPhongBan.SelectedIndex = 0;

            txtHoTen.Focus();

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtHoTen.Text) || String.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin");
                return;
            }
            else
            {
                NhanVienDTO nv = new NhanVienDTO(maNV, ChangeNameStyle(txtHoTen.Text), DateTime.Parse(dtpNgaySinh.Value.ToShortDateString()), txtDiaChi.Text, cmbGioiTinh.Text, cmbPhongBan.SelectedValue.ToString(), cmbChucVu.SelectedValue.ToString(), cmbChuyenMon.SelectedValue.ToString(), (int)cmbBacLuong.SelectedValue);

                if (NhanVien_BUS.AddNhanVien(nv))
                {
                    LoadNhanVien();
                    MessageBox.Show("Thêm thành công");
                    btnLuu.Enabled = false;
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }

            
            barStaticItemInfo.Caption = "Lần thêm dữ liệu gần nhất: " + DateTime.Now.ToString();
        }

        /// <summary>
        /// Sinh ra mã NV
        /// Theo dạng: NV001
        /// </summary>
        /// <returns></returns>
        private string GetMaNV()
        {
            string ma = "NV";
            Random rd = new Random();
            int i = rd.Next(1000);

            if (i < 10)
                ma = "NV00";
            else if (i < 100)
                ma = "NV0";

            return (ma + i.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataGridViewRow dr = dgvNhanVien.SelectedRows[0];
                string maNV = dr.Cells[0].Value.ToString();

                if (NhanVien_BUS.DeleteNhanVien(maNV))
                {
                    LoadNhanVien();
                    MessageBox.Show("Xóa thành công");
                    ResetText();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            ResetText();
        }

        void LoadPhongBan()
        {
            DataTable dt = PhongBanDAO.GetPhongBan();
            cmbPhongBan.DataSource = dt;
            cmbPhongBan.DisplayMember = "TenPB";
            cmbPhongBan.ValueMember = "MaPB";
        }

        void LoadGioiTinh()
        {
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
        }
        void LoadChuyenMon()
        {
            DataTable dt = ChuyenMonDAO.GetChuyenMon();
            cmbChuyenMon.DataSource = dt;
            cmbChuyenMon.DisplayMember = "TenCM";
            cmbChuyenMon.ValueMember = "MaCM";
        }

        void LoadChucVu()
        {
            DataTable dt = ChucVuDAO.GetChucVu();
            cmbChucVu.DataSource = dt;
            cmbChucVu.DisplayMember = "TenCV";
            cmbChucVu.ValueMember = "MaCV";
        }

        void LoadBacLuong()
        {
            DataTable dt = BacLuongDAO.GetBacLuong();
            cmbBacLuong.DataSource = dt;
            cmbBacLuong.DisplayMember = "BacLuong";
            cmbBacLuong.ValueMember = "BacLuong";
        }



        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            DataGridViewRow dr = dgvNhanVien.SelectedRows[0];
            txtMa.Text = dr.Cells[0].Value.ToString();
            txtHoTen.Text = dr.Cells[1].Value.ToString();
            dtpNgaySinh.Text = dr.Cells[2].Value.ToString();
            txtDiaChi.Text = dr.Cells[3].Value.ToString();
            if (dr.Cells[4].Value.ToString().ToLower() == "nam")
                cmbGioiTinh.SelectedIndex = 0;
            else
                cmbGioiTinh.SelectedIndex = 1;
            // sẽ lấy ra tên phòng ban theo mã
            cmbPhongBan.Text = PhongBan_BUS.GetTenPhongBanByMaPB(dr.Cells[5].Value.ToString());
            cmbBacLuong.Text = dr.Cells[8].Value.ToString();
            cmbChucVu.Text = ChucVuDAO.GetTenChucVuByMa(dr.Cells[6].Value.ToString());
            cmbChuyenMon.Text = ChuyenMonDAO.GetTenChuyenMonByMa(dr.Cells[7].Value.ToString());
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

            return result.Trim();
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

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

    }
}


