using QuanLiNhanSu.DTO;
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

        public static bool AddChuyenMon(ChuyenMonDTO cm)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spAddChuyenMon", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] arrParams =  { new SqlParameter("@MaCM", cm.MaCM),
                                                                    new SqlParameter("@TenCM ", cm.TenCM),
                                                                    new SqlParameter("@TrinhDo", cm.TrinhDo)
                                                };
                    cmd.Parameters.AddRange(arrParams);
                    return DataProvider.ExecuteNonQuery(cmd) > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Update chuyên môn
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public static bool UpdateChuyenMon(ChuyenMonDTO cm)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateChuyenMon", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] arrParams =  { new SqlParameter("@MaCM", cm.MaCM),
                                                                    new SqlParameter("@TenCM", cm.TenCM),
                                                                    new SqlParameter("@TrinhDo", cm.TrinhDo)
                                                };
                    cmd.Parameters.AddRange(arrParams);

                    return DataProvider.ExecuteNonQuery(cmd) > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Xóa 1 chuyên môn
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public static bool DeleteChuyenMon(string ma)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spDeleteChuyenMon", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@MaCM", ma));

                    return DataProvider.ExecuteNonQuery(cmd) > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
