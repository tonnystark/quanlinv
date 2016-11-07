using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class frmConnect : XtraForm
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string strCon = "";
            if (!String.IsNullOrWhiteSpace(cmbServer.Text) && !String.IsNullOrWhiteSpace(cmbDatabase.Text))
                if (!chkAut.Checked)
                {
                    strCon = String.Format("Server={0};Database={1};Trusted_Connection=True;", cmbServer.Text, cmbDatabase.Text);
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(txtUser.Text) && !String.IsNullOrWhiteSpace(txtPass.Text))
                    {
                        strCon = String.Format("Server={0};Database={1};User Id={2};Password = {3}; ", cmbServer.Text, cmbDatabase.Text, txtUser.Text, txtPass.Text);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hay mật khẩu không được để trống");
                        return;
                    }
                }
            else
            {
                MessageBox.Show("Tên Server hay Database không hợp lệ");
                return;
            }

            using (SqlConnection con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    // tiến hành gán chuỗi kết nối cho project
                    QuanLiNhanSu.Properties.Settings.Default.strConnect = strCon;
                    QuanLiNhanSu.Properties.Settings.Default.Save();
                    
                    MessageBox.Show("Kết nối đến Server thành công");
                    Console.Beep();
                    // restart lại
                    Application.Restart();   
                }
                catch
                {
                    MessageBox.Show("Kết nối đến Server thất bại, vui lòng kiểm tra lại");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            txtUser.Enabled = false;
            txtPass.Enabled = false;

            SqlDataSourceEnumerator instance =
    SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            cmbServer.DataSource = table;
            cmbServer.DisplayMember = "ServerName";


            //  cmbServer.SelectedIndexChanged -= cmbServer_SelectedIndexChanged_1;


            //cmbServer.SelectedIndex = 0;

        }

        private void chkAut_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAut.Checked)
            {
                txtUser.Enabled = true;
                txtPass.Enabled = true;

            }
            else
            {
                txtUser.Enabled = false;
                txtPass.Enabled = false;
            }
        }


        //private void cmbServer_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    string myServer = Environment.MachineName;
        //    if (cmbServer.Text == myServer)
        //        LoadDatabase(cmbServer.Text);
        //    else
        //    {
        //        cmbDatabase.DataSource = null;
        //    }
        //}

        //void LoadDatabase(string server = ".")
        //{
        //    var connectionString = string.Format("Data Source={0}; Integrated Security=True;", server);

        //    DataTable databases = null;
        //    using (var sqlConnection = new SqlConnection(connectionString))
        //    {
        //        sqlConnection.Open();
        //        databases = sqlConnection.GetSchema("Databases");
        //        sqlConnection.Close();

        //        cmbDatabase.DataSource = databases;
        //        cmbDatabase.DisplayMember = "database_name";

        //        cmbDatabase.SelectedIndex = 0;
        //    }

        //}

        public static void frmConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
