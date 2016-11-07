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
    public class NhanVienDAO
    {
        // sql Connect
        static SqlConnection con;
        // string connect
        static string strCon = DataProvider.strCon;

        //Lấy ra thông tin tất cả Nhân Viên
        public static DataTable GetNhanVien()
        {
            using (con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetNhanVien", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = DataProvider.GetDataTable(cmd, con);
                return dt;
            }
        }

        /// <summary>
        /// Thêm Nhân Viên
        /// </summary>
        /// <param name="nv"></param>
        /// <returns></returns>
        public static bool AddNhanVien(NhanVienDTO nv)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spAddNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] NVparams =  { new SqlParameter { ParameterName = "@MaNV", Value = nv.MaNV},
                                                  new SqlParameter { ParameterName = "@HoTen ", Value = nv.Hoten},
                                                   new SqlParameter { ParameterName = "@NgaySinh", Value = nv.NgaySinh},
                                                    new SqlParameter { ParameterName = "@GioiTinh", Value = nv.GioiTinh},
                                                     new SqlParameter { ParameterName = "@MaPB", Value = nv.MaPB},
                                                      new SqlParameter { ParameterName = "@MaCV", Value = nv.MaCV},
                                                      new SqlParameter { ParameterName = "@MaCM", Value = nv.MaCM},
                                                      new SqlParameter { ParameterName = "@BacLuong", Value = nv.BacLuong},
                                                       new SqlParameter { ParameterName = "@DiaChi", Value = nv.DiaChi }

                    };
                    cmd.Parameters.AddRange(NVparams);
                    return DataProvider.ExecuteNonQuery(cmd) > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Lấy ra thông tin Nhân Viên theo mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public static DataTable GetNVByMa(string ma = "null")
        {
            using (con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetNhanVienByMa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Ma", ma));
                return DataProvider.GetDataTable(cmd, con);
            }
        }
        /// <summary>
        /// Xóa Nhân Viên
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public static bool DeleteNhanVien(string ma)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spDeleteNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.Add(new SqlParameter("@MaNV", ma));

                    return DataProvider.ExecuteNonQuery(cmd) > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool UpdateNhanVien(NhanVienDTO nv)
        {
            using (con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] NVparams =  { new SqlParameter { ParameterName = "@MaNV", Value = nv.MaNV},
                                                  new SqlParameter { ParameterName = "@HoTen ", Value = nv.Hoten},
                                                   new SqlParameter { ParameterName = "@NgaySinh", Value = nv.NgaySinh},
                                                    new SqlParameter { ParameterName = "@GioiTinh", Value = nv.GioiTinh},
                                                     new SqlParameter { ParameterName = "@MaPB", Value = nv.MaPB},
                                                      new SqlParameter { ParameterName = "@MaCV", Value = nv.MaCV},
                                                      new SqlParameter { ParameterName = "@MaCM", Value = nv.MaCM},
                                                      new SqlParameter { ParameterName = "@BacLuong", Value = nv.BacLuong},
                                                       new SqlParameter { ParameterName = "@DiaChi", Value = nv.DiaChi }

                    };
                    cmd.Parameters.AddRange(NVparams);
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

