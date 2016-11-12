using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiNhanSu.DTO;
using QuanLiNhanSu.DAO;
using System.Data;

namespace QuanLiNhanSu.BUS
{
    public class NhanVien_BUS
    {
        public  static bool AddNhanVien(NhanVienDTO nv)
        {
            return NhanVienDAO.AddNhanVien(nv);
        }

        public static DataTable GetNhanVien()
        {
            return NhanVienDAO.GetNhanVien();
        }

        public static DataTable GetNVByMa(string ma)
        {
            return NhanVienDAO.GetNVByMa(ma);
        }

        public static bool DeleteNhanVien(string ma)
        {
            return NhanVienDAO.DeleteNhanVien(ma);
        }

        public static bool UpdateNhanVien(NhanVienDTO nv)
        {
            return NhanVienDAO.UpdateNhanVien(nv);
        }

        public static DataTable GetAllMaNV()
        {
            return NhanVienDAO.GetAllMaNV();
        }

    }
}
