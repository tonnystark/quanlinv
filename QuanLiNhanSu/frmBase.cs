using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLiNhanSu
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        public frmBase()
        {
            InitializeComponent();
        }

        protected virtual void OnAdd()
        {
        }
        protected virtual void OnDelete()
        {

        }
        protected virtual void OnUpdate()
        {

        }
        protected virtual void OnSave()
        {

        }
        protected virtual void OnCancel()
        {

        }

        protected virtual void OnDgvClick()
        {

        }
        protected virtual void OnLoad()
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            OnAdd();
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void frmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            OnUpdate();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            OnCancel();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            OnSave();
            barStaticItemInfo.Caption = "Lần lưu dữ liệu gần nhất: " + DateTime.Now.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            OnDgvClick();
        }
    }
}