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
   public  class ChuyenMon_BUS
    {
        public static bool AddChuyenMon(ChuyenMonDTO cm)
        {
            return ChuyenMonDAO.AddChuyenMon(cm);
        }

        public static DataTable GetChuyenMon()
        {
            return ChuyenMonDAO.GetChuyenMon();
        }
             

        public static bool DeleteChuyenMon(string ma)
        {
            return ChuyenMonDAO.DeleteChuyenMon(ma);
        }

        public static bool UpdateChuyenMon(ChuyenMonDTO cm)
        {
            return ChuyenMonDAO.UpdateChuyenMon(cm);
        }
    }
}
