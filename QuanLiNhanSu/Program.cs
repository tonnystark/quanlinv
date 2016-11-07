using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //try
            //{
            //    // kết nối thành công thì đóng luôn
            //    SqlConnection con = new SqlConnection(DAO.DataProvider.strCon);
            //    con.Open();
            //    con.Close();
              
            //    // chạy Form2
            //    Application.Run(new frmMain());
            //}
            //catch
            //{
            //    // nếu lỗi thì chạy lại frmConnect
            //    Application.Run(new frmConnect());
            //}

            Application.Run(new frmMain());
        }
    }
}
