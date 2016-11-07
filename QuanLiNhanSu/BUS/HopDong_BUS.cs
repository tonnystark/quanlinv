using QuanLiNhanSu.DAO;
using QuanLiNhanSu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu.BUS
{
    public class HopDong_BUS
    {
        public static bool AddHopDong(HopDongDTO hd)
        {
            return HopDongDAO.AddHopDong(hd);
        }

        public static DataTable GetHopDong()
        {
            return HopDongDAO.GetHopDong();
        }


        public static bool DeleteHopDong(string ma)
        {
            return HopDongDAO.DeleteHopDong(ma);
        }

        public static bool UpdateHopDong(HopDongDTO hd)
        {
            return HopDongDAO.UpdateHopDong(hd);
        }
    }
}
