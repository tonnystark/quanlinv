using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiNhanSu.DTO;

namespace QuanLiNhanSu.DAO
{
    public class PhongBanDAO
    {
        // sql Connect
        static SqlConnection con;
        // string connect
        static string strCon = DataProvider.strCon;

        /// <summary>
        /// Trả ra danh sách phòng ban
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPhongBan()
        {
            using (con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetPhongBan", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = DataProvider.GetDataTable(cmd, con);
                return dt;
            }
        }

        /// <summary>
        /// Lấy ra tên phòng ban
        /// </summary>
        /// <param name="maPB"></param>
        /// <returns></returns>
        public static string GetTenPhongBanByMaPB(string maPB = "null")
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetTenPhongByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MaPB", maPB));
                    return DataProvider.ExecuteScalar(cmd);
                }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Thêm 1 phòng ban, thêm được trả về True
        /// </summary>
        /// <param name="pb"></param>
        /// <returns></returns>
        public static bool AddPhongBan(PhongBanDTO pb)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spAddPhongBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] arrParams =  { new SqlParameter("@MaPB ", pb.MaPB),
                                                                    new SqlParameter("@TenPB ", pb.TenPB),
                                                                    new SqlParameter("@DiaChi ", pb.DiaChi)
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
        /// Update phòng ban
        /// </summary>
        /// <param name="pb"></param>
        /// <returns></returns>
        public static bool UpdatePhongBan(PhongBanDTO pb)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdatePhongBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] arrParams =  { new SqlParameter("@MaPB ", pb.MaPB),
                                                                    new SqlParameter("@TenPB ", pb.TenPB),
                                                                    new SqlParameter("@DiaChi ", pb.DiaChi)
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
        /// Xóa 1 phòng ban
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public static bool DeletePhongBan(string ma)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spDeletePhongBan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@MaPB", ma));

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
