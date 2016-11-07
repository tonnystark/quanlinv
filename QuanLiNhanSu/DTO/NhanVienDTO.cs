using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu.DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string Hoten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string MaPB { get; set; }
        public string MaCV { get; set; }
        public string MaCM { get; set; }
        public int BacLuong { get; set; }

        public NhanVienDTO() { }
        public NhanVienDTO(string maNV, string hoTen, DateTime nSinh, string dChi, string gTinh, string maPB, string maCV, string maCM, int bacLuong)
        {
            this.MaNV = maNV;
            this.Hoten = hoTen;
            this.NgaySinh = nSinh;
            this.DiaChi = dChi;
            this.GioiTinh = gTinh;
            this.MaPB = maPB;
            this.MaCV = maCV;
            this.MaCM = maCM;
            this.BacLuong = bacLuong;
        }


    }


}
