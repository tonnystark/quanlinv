using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QuanLiNhanSu
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }


        // lấy ra form theo tên
        // ngăn không cho mở 1 form trong nhiều tab
        Form GetChildFormByName(Type type)
        {
            return MdiChildren.FirstOrDefault(f => f.GetType() == type);
        }

        private void barBtnSaoLuu_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void barButtonDSNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            // string fName = "frmNhanVien";
            Form f = GetChildFormByName(typeof(frmNhanVien));
            // nếu chưa có Form nào thì tạo
            if (f == null)
            {
                f = new frmNhanVien();
                f.MdiParent = this;
                f.Show();
            }
            // nếu có thì gọi ra
            else
                f.Activate();
        }

        private void barButtonDSPhongBan_ItemClick(object sender, ItemClickEventArgs e)
        {           
            Form f = GetChildFormByName(typeof(frmPhongBan));
            // nếu chưa có Form nào thì tạo
            if (f == null)
            {
                f = new frmPhongBan();           
                f.MdiParent = this;
                f.Show();
            }
            // nếu có thì gọi ra
            else
                f.Activate();
        }

        private void barButtonDSHopDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            // string fName = "frmNhanVien";
            Form f = GetChildFormByName(typeof(frmHopDong));
            // nếu chưa có Form nào thì tạo
            if (f == null)
            {
                f = new frmHopDong();
                f.MdiParent = this;
                f.Show();
            }
            // nếu có thì gọi ra
            else
                f.Activate();
        }
    }
}