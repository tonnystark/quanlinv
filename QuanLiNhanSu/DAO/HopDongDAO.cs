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
    public class HopDongDAO
    {
        // sql Connect
        static SqlConnection con;
        // string connect
        static string strCon = DataProvider.strCon;

        /// <summary>
        /// Trả ra danh sách phòng ban
        /// </summary>
        /// <returns></returns>
        public static DataTable GetHopDong()
        {
            using (con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetHopDong", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = DataProvider.GetDataTable(cmd, con);
                return dt;
            }
        }

        /// <summary>
        /// Thêm 1 hợp đồng, thêm được trả về True
        /// </summary>
        /// <param name="hd"></param>
        /// <returns></returns>
        public static bool AddHopDong(HopDongDTO hd)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spAddHopDong", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] arrParams =  { new SqlParameter("@MaHD", hd.MaHD),
                                                                    new SqlParameter("@MaNV", hd.MaNV),
                                                                    new SqlParameter("@LoaiHD", hd.LoaiHD),
                                                                     new SqlParameter("@NgayBD", hd.NgayBD),
                                                                      new SqlParameter("@NgayKT", hd.NgayKT),
                                                                       new SqlParameter("@MoTa", hd.MoTa)
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
        /// Update hợp đồng
        /// </summary>
        /// <param name="hd"></param>
        /// <returns></returns>
        public static bool UpdateHopDong(HopDongDTO hd)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateHopDong", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] arrParams =  { new SqlParameter("@MaHD", hd.MaHD),
                                                                    new SqlParameter("@MaNV", hd.MaNV),
                                                                    new SqlParameter("@LoaiHD", hd.LoaiHD),
                                                                     new SqlParameter("@NgayBD", hd.NgayBD),
                                                                      new SqlParameter("@NgayKT", hd.NgayKT),
                                                                       new SqlParameter("@MoTa", hd.MoTa)
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
        /// Xóa hợp đồng
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public static bool DeleteHopDong(string ma)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spDeleteHopDong", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@MaHD", ma));

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
