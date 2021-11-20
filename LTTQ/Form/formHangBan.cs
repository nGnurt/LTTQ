using LTTQ;
using System;
using System.Data;

using System.Windows.Forms;

namespace formHangBan
{
    public partial class formHangBan : Form
    {
        SQL dtBase = new SQL();
        public formHangBan()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgvHangBan.DataSource = dtBase.loaddulieu("select SoHDB, MaNV, MaKH, MaDoChoi, SoLuong, KhuyenMai, Ngayban from Nhap");
        }
        private void dgvHangBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHDB.Text = dgvHangBan.CurrentRow.Cells[0].Value.ToString();
            cboMaNV.Text = dgvHangBan.CurrentRow.Cells[1].Value.ToString();
            txtMaKH.Text = dgvHangBan.CurrentRow.Cells[2].Value.ToString();
            cboDoChoi.Text = dgvHangBan.CurrentRow.Cells[3].Value.ToString();
            txtSL.Text = dgvHangBan.CurrentRow.Cells[4].Value.ToString();
            txtKM.Text = dgvHangBan.CurrentRow.Cells[5].Value.ToString();
            
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }

        private void formHangBan_Load(object sender, EventArgs e)
        {
            DataTable HangBan = dtBase.loaddulieu("select * from HoaDon");
            cboDoChoi.DataSource = dtBase.loaddulieu("select MaDoChoi from HoaDon");
            cboDoChoi.DisplayMember = "MaDoChoi";
            cboDoChoi.ValueMember = "MaDoChoi";
            cboDoChoi.Text = "";
            LoadData();
            dgvHangBan.Columns[0].HeaderText = "Số hóa đơn bán";
            dgvHangBan.Columns[1].HeaderText = "Mã nhân viên";
            dgvHangBan.Columns[2].HeaderText = "Mã khách hàng";
            dgvHangBan.Columns[3].HeaderText = "Mã đồ chơi";
            dgvHangBan.Columns[4].HeaderText = "Số lượng";
            dgvHangBan.Columns[5].HeaderText = "Khuyến mại";
            dgvHangBan.Columns[6].HeaderText = "Ngày bán";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable DoChoi;
            string maDoChoi, sqlInsert;
            if(txtHDB.Text =="" || cboMaNV.Text=="" || txtMaKH.Text=="" || cboDoChoi.Text=="" || txtSL.Text=="" || txtKM.Text =="")
            {
                MessageBox.Show("Bạn phải nhập đủ dữ liệu");
                return;
            }
            maDoChoi = cboDoChoi.Text;
            DoChoi = dtBase.loaddulieu("select * from HoaDon where MaDoChoi ='" + maDoChoi + "'");
            if(DoChoi.Rows.Count > 0)
            {
                MessageBox.Show("Mã đồ chơi này đã có, mời nhập mã khác.");
                cboDoChoi.Focus();
                return;
            }    
            sqlInsert = "insert into HoaDon values ('"+txtHDB.Text+"','" + cboMaNV.Text+ "', '" +txtMaKH.Text+ "','"+ cboDoChoi.Text+"', '"+int.Parse(txtSL.Text)+"','"+float.Parse(txtKM.Text)+"','"+DateTime.Parse(dtpNgayBan.Text)+"')";
            dtBase.CapNhatDuLieu(sqlInsert);
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dtBase.CapNhatDuLieu("update HoaDon set MaHDB='" + txtHDB.Text + "' where MaHDB='" + txtHDB.Text + "'");
            dtBase.CapNhatDuLieu("update HoaDon set MaNV='" + cboMaNV.Text + "' where MaNV='" + cboMaNV.Text + "'");
            dtBase.CapNhatDuLieu("update HoaDon set MaKH='" + txtMaKH.Text + "' where MaKH='" + txtMaKH.Text + "'");
            dtBase.CapNhatDuLieu("update HoaDon set MaDoChoi='" + cboDoChoi.Text + "' where MaDoChoi='" + cboDoChoi.Text + "'");
            dtBase.CapNhatDuLieu("update HoaDon set SoLuong='" + txtSL.Text + "' where SoLuong='" + txtSL.Text + "'");
            dtBase.CapNhatDuLieu("update HoaDon set KhuyenMai='" + txtKM.Text + "' where KhuyenMai='" + txtKM.Text + "'");
            dtBase.CapNhatDuLieu("update HoaDon set NgayBan='" + dtpNgayBan.Text + "' where NgayBan='" + dtpNgayBan.Text + "'");
            dgvHangBan.DataSource = dtBase.loaddulieu("select * from HoaDon");
            txtHDB.Text = "";
            cboMaNV.Text = "";
            txtMaKH.Text = "";
            cboDoChoi.Text = "";
            txtSL.Text = "";
            txtKM.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sqlSelect = "select SoHDB, MaNV, MaKH, MaDoChoi, SoLuong, KhuyenMai, NgayBan";
            if(txtTim.Text.Trim() != "")
            {
                sqlSelect = sqlSelect + "and (MaDoChoi like '%" + txtTim.Text + "%')";
            }
            dgvHangBan.DataSource = dtBase.loaddulieu(sqlSelect);
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
                dtBase.CapNhatDuLieu("delete HoaDon where MaDoChoi = '" + cboDoChoi.Text + "'");
                LoadData();
            }
            txtHDB.Text = "";
            cboMaNV.Text = "";
            txtMaKH.Text = "";
            cboDoChoi.Text = "";
            txtSL.Text = "";
            txtKM.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
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
