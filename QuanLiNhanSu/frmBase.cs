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
            AddButtonEnable();
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            OnLoad();
            LoadButtonEnable();
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
            CancelButtonEnable();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            OnSave();
            barStaticItemInfo.Caption = "Lần lưu dữ liệu gần nhất: " + DateTime.Now.ToString();
            SaveButtonEnable();
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
            DgvClickButtonEnable();
        }

        /// <summary>
        /// Kiểm tra textBox có trống không
        /// </summary>
        /// <returns>false: trống</returns>
        protected bool IsEmptyTextbox()
        {
            foreach (var item in grpControl.Controls.OfType<TextBox>())
            {
                if (String.IsNullOrWhiteSpace(item.Text))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Bật/ tắt button khi Add
        /// </summary>
        private void AddButtonEnable()
        {
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void CancelButtonEnable()
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void LoadButtonEnable()
        {
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            txtMa.Enabled = false;
        }

        private void SaveButtonEnable()
        {
            btnLuu.Enabled = false;
        }

        private void DgvClickButtonEnable()
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        // đổi sang kiểu chữ Hoa đầu cho tên
        protected string ChangeNameStyle(string name)
        {
            // loại bỏ khoảng trắng và Chuyển Style
            // thạch mu ni => Thạch Mu Ni
            name = RemoveWhiteSpace(name);

            string[] arrStr = name.Split(' ');

            string result = "";

            for (int i = 0; i < arrStr.Length; i++)
            {
                arrStr[i] = arrStr[i].Substring(0, 1).ToUpper() + arrStr[i].Substring(1).ToLower() + " ";
                result += arrStr[i];
            }

            return result;
        }

        /// <summary>
        /// Xóa các khoảng trắng thừa
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        protected string RemoveWhiteSpace(string str)
        {
            string[] arrStr = str.Split(new char[] { ' ' }, 10, StringSplitOptions.RemoveEmptyEntries);
            string strResult = "";
            foreach (var item in arrStr)
            {
                strResult += item + " ";
            }
            return strResult.Trim();
        }
        protected string GetMa(string tenMa = "NV")
        {
            Random rd = new Random();
            int i = rd.Next(1000);

            if (i < 10)
                tenMa += "00";
            else if (i < 100)
                tenMa += "0";

            return (tenMa + i.ToString());
        }

    }
}