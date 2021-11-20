using LTTQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoiMatKhau
{
    public partial class txtXacNhan : Form
    {
        SQL dtBase = new SQL();
        public txtXacNhan()
        {
            InitializeComponent();
        }
        public void LoadUser()
        {
            DataTable user = dtBase.loaddulieu("select TaiKhoan, MatKhau from QuanLiNhanVien");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        SqlConnection cn = new SqlConnection(@"Data Source=NGNURT\TRUNGND232;Integrated Security=SSPI;Initial Catalog=LTTQ");
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select count (*) from QuanLiNhanVien where TaiKhoan = '" + txtTK + "' and MatKhau = '" + txtMKC + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (txtMKM.Text == txtXN.Text)
                {
                    if (txtMKM.Text.Length >= 8)
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter("update QuanLiNhanVien set MatKhau = '" + txtMKM.Text + "' where TaiKhoan = '" + txtTK.Text + "'", cn);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else errorProvider1.SetError(txtMKM, "Mật khẩu phải có ít nhất 8 kí tự");
                }
                else
                {
                    errorProvider1.SetError(txtMKM, "Bạn chưa điền mật khẩu");
                    errorProvider1.SetError(txtXN, "Mật khẩu xác nhận chưa đúng");
                }
            }
            else
            {
                errorProvider1.SetError(txtTK, "Tên tài khoản không đúng");
                errorProvider1.SetError(txtMKC, "Mật khẩu hiện tại không đúng");
            }
        }
    }      
}
