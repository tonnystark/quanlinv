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
    public partial class frmHopDong : frmBase
    {
        public frmHopDong()
        {
            InitializeComponent();
        }

        private void frmHopDong_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}