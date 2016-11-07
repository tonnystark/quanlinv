using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu.DAO
{
    public class ChuyenMonDAO
    {
        // sql Connect
        static SqlConnection con;
        // string connect
        static string strCon = DataProvider.strCon;

        public static DataTable GetChuyenMon()
        {
            using (con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetChuyenMon", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = DataProvider.GetDataTable(cmd, con);
                return dt;
            }
        }

        public static string GetTenChuyenMonByMa(string ma = "null")
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetTenChuyenMonByMa", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Ma", ma));
                    return DataProvider.ExecuteScalar(cmd);
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
