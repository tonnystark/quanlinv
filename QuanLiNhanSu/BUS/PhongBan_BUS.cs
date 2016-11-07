using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiNhanSu.DTO;
using QuanLiNhanSu.DAO;

namespace QuanLiNhanSu.BUS
{
    public class PhongBan_BUS
    {
        public static DataTable GetPhongBan()
        {
            return PhongBanDAO.GetPhongBan();
        }

        public static bool AddPhongBan(PhongBanDTO pb)
        {
            return PhongBanDAO.AddPhongBan(pb);
        }

        public static bool DeletePhongBan(string ma)
        {
            return PhongBanDAO.DeletePhongBan(ma);
        }

        public  static bool UpdatePhongBan(PhongBanDTO pb)
        {
            return PhongBanDAO.UpdatePhongBan(pb);
        }

        public static string GetTenPhongBanByMaPB(string ma)
        {
            return PhongBanDAO.GetTenPhongBanByMaPB(ma);
        }
    }
}
