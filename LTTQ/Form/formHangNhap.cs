using LTTQ;
using System;
using System.Data;
using System.Windows.Forms;

namespace formHangNhap
{
    public partial class formHangNhap : Form
    {
        SQL dtBase = new SQL();
        public formHangNhap()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgvHangNhap.DataSource = dtBase.loaddulieu("select SoHDN, MaNCC, MaNV, MaDoChoi, SoLuongNhap, KhuyenMai, NgayNhap from Nhap");
        }
        private void dgvHangNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHDN.Text = dgvHangNhap.CurrentRow.Cells[0].Value.ToString();
            txtMaNCC.Text = dgvHangNhap.CurrentRow.Cells[1].Value.ToString();
            cboMaNV.Text = dgvHangNhap.CurrentRow.Cells[2].Value.ToString();
            cboDoChoi.Text = dgvHangNhap.CurrentRow.Cells[3].Value.ToString();
            txtSL.Text = dgvHangNhap.CurrentRow.Cells[4].Value.ToString();
            txtKM.Text = dgvHangNhap.CurrentRow.Cells[5].Value.ToString();
            
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }

        private void formHangNhap_Load(object sender, EventArgs e)
        {
            DataTable HangNhap = dtBase.loaddulieu("select * from Nhap");
            cboDoChoi.DataSource = dtBase.loaddulieu("Select MaDoChoi from Nhap");
            cboDoChoi.DisplayMember = "MaDoChoi";
            cboDoChoi.ValueMember = "MaDoChoi";
            cboDoChoi.Text = "";
            
            LoadData();
            dgvHangNhap.Columns[0].HeaderText = "Số hóa đơn nhập";
            dgvHangNhap.Columns[1].HeaderText = "Mã nhà cung cấp";
            dgvHangNhap.Columns[2].HeaderText = "Mã nhân viên";
            dgvHangNhap.Columns[3].HeaderText = "Mã đồ chơi";
            dgvHangNhap.Columns[4].HeaderText = "Số lượng nhập";
            dgvHangNhap.Columns[5].HeaderText = "Khuyến mại";
            dgvHangNhap.Columns[6].HeaderText = "Ngày nhập";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable DoChoi;
            string maDoChoi, sqlInsert;
            if(txtHDN.Text =="" || txtMaNCC.Text=="" || cboMaNV.Text=="" || cboDoChoi.Text=="" || txtSL.Text=="" || txtKM.Text =="")
            {
                MessageBox.Show("Bạn phải nhập đủ dữ liệu");
                return;
            }
            maDoChoi = cboDoChoi.Text;
            DoChoi = dtBase.loaddulieu("select * from Nhap where MaDoChoi ='" + maDoChoi + "'");
            if(DoChoi.Rows.Count > 0)
            {
                MessageBox.Show("Mã đồ chơi này đã có, mời nhập mã khác.");
                cboDoChoi.Focus();
                return;
            }    
            sqlInsert = "insert into Nhap values ('"+txtHDN.Text+"','" +txtMaNCC.Text+ "', '" + cboMaNV.Text+ "','"+ cboDoChoi.Text+"', '"+int.Parse(txtSL.Text)+"','"+float.Parse(txtKM.Text)+"','"+DateTime.Parse(dtpNgayNhap.Text)+"')";
            dtBase.CapNhatDuLieu(sqlInsert);
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dtBase.CapNhatDuLieu("update Nhap set MaHDN='" + txtHDN.Text + "' where MaHDN='" + txtHDN.Text + "'");
            dtBase.CapNhatDuLieu("update Nhap set MaNCC='" + txtMaNCC.Text + "' where MaNCC='" + txtMaNCC.Text + "'");
            dtBase.CapNhatDuLieu("update Nhap set MaNV='" + cboMaNV.Text + "' where MaNV='" + cboMaNV.Text + "'");
            dtBase.CapNhatDuLieu("update Nhap set MaDoChoi='" + cboDoChoi.Text + "' where MaDoChoi='" + cboDoChoi.Text + "'");
            dtBase.CapNhatDuLieu("update Nhap set SoLuongNhap='" + txtSL.Text + "' where SoLuongNhap='" + txtSL.Text + "'");
            dtBase.CapNhatDuLieu("update Nhap set KhuyenMai='" + txtKM.Text + "' where KhuyenMai='" + txtKM.Text + "'");
            dtBase.CapNhatDuLieu("update Nhap set NgayNhap='" + dtpNgayNhap.Text + "' where NgayNhap='" + dtpNgayNhap.Text + "'");
            dgvHangNhap.DataSource = dtBase.loaddulieu("select * from Nhap");
            txtHDN.Text = "";
            txtMaNCC.Text = "";
            cboMaNV.Text = "";
            cboDoChoi.Text = "";
            txtSL.Text = "";
            txtKM.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sqlSelect = "select SoHDN, MaNCC, MaNV, MaDoChoi, SoLuongNhap, KhuyenMai, NgayNhap";
            if(txtTim.Text.Trim() != "")
            {
                sqlSelect = sqlSelect + "and (MaDoChoi like '%" + txtTim.Text + "%')";
            }
            dgvHangNhap.DataSource = dtBase.loaddulieu(sqlSelect);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cboDoChoi.Text == "")
            {
                MessageBox.Show("Chọn mã đồ chơi để xóa");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa", "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.CapNhatDuLieu("delete Nhap where MaDoChoi = '" + cboDoChoi.Text + "'");
                LoadData();
            }
            txtHDN.Text = "";
            txtMaNCC.Text = "";
            cboMaNV.Text = "";
            cboDoChoi.Text = "";
            txtSL.Text = "";
            txtKM.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }    
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
