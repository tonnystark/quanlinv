using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu.DAO
{
    public class BacLuongDAO
    {
        // sql Connect
        static SqlConnection con;
        // string connect
        static string strCon = DataProvider.strCon;

        public static DataTable GetBacLuong()
        {
            using (con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetBacLuong", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = DataProvider.GetDataTable(cmd, con);
                return dt;
            }
        }
    }
}
