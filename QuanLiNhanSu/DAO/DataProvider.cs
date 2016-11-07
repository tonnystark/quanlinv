using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu.DAO
{
    public class DataProvider
    {
        // string Connection
        public static string strCon = QuanLiNhanSu.Properties.Settings.Default.strConnect;

        // Lấy data table
        public static DataTable GetDataTable(SqlCommand cmd, SqlConnection con)
        {
            var dt = new DataTable();
            var da = new SqlDataAdapter(cmd.CommandText, con);
            da.Fill(dt);
            return dt;
        }

        // Thực thi NonQuery, trả về số dòng thực hiện
        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        // Thực thi scalar
        public static string ExecuteScalar(SqlCommand cmd)
        {
            return cmd.ExecuteScalar().ToString();
        }



    }
}
