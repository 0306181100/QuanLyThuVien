using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BEL;


namespace doan2
{
    public partial class UCQLSachThuVien : UserControl
    {
        public UCQLSachThuVien()
        {
            InitializeComponent();
        }
        //Hiển thị thể loai
        public void HienThicboTheLoai(ComboBox cbo)//Tạo Bel_theloai r làm mốt ổng kêu quảng lý thể loại dễ sữa 
        {                                           // Tạo lâu r mày
            BAL_Sach Sach = new BAL_Sach();
            cbo.DataSource = Sach.Hienthitheloai();
            cbo.DisplayMember = "MaTheLoai";
            cbo.ValueMember = "TheLoai";
        }
        public void HienthiSachNhap()
        {
            BAL_Sach xuly = new BAL_Sach();
            dgvSachNhap.ForeColor = Color.Black;
            dgvSachNhap.DataSource = xuly.DocDSSachnhap();
        }
        //Sách thư viện
        public void HienthiSachTV()
        {
            dgvSachThuVien.ForeColor = Color.Black;
            BAL_Sach xuly = new BAL_Sach();
            dgvSachThuVien.DataSource = xuly.DocDSsach();
        }
        private void UCtab4_Load(object sender, EventArgs e)
        {

            HienthiSachTV();
            HienthiSachNhap();
            nbrGiaThue.Maximum = 999999;
            nbrGiaThue.Minimum = 0;
            HienThicboTheLoai(cboTheLoai);
            
        }    
        void Reresh()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtSoLuong.Text = "";
            cbTrangThai.Checked = false;
            nbrGiaThue.Value = 0;
            dgvSachThuVien.DataSource = null;
            HienthiSachTV();
            HienthiSachNhap();
        }
        private void dgvSachThuVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;

            string masach = dgvSachThuVien.CurrentRow.Cells[0].Value.ToString().Trim();
            BAL_Sach xuly = new BAL_Sach();
            BEL_Theloai TheLoai = new BEL_Theloai();
            BEL_Sach dt = xuly.TimSachTheoMa(masach);
            txtMaSach.Text = dt.Masach;
            txtSoLuong.Text = dt.Soluong.ToString();
            txtTenSach.Text = dt.Tensach;
            nbrGiaThue.Value = dt.Giathue;
            cbTrangThai.Checked = dt.Trangthai;
            cboTheLoai.SelectedValue = dgvSachThuVien.CurrentRow.Cells[2].Value;
        }

        private void dgvSachNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BAL_Sach xuly = new BAL_Sach();
            BEL_Sach Sach = new BEL_Sach();
            Sach.Masach = txtMaSach.Text.ToString();
            Sach.Tensach = txtTenSach.Text.ToString();
            Sach.Matheloai = xuly.LayMaTheLoai(cboTheLoai.Text.ToString());
            Sach.Soluong = int.Parse(txtSoLuong.Text.ToString());
            Sach.Giathue = int.Parse(nbrGiaThue.Value.ToString());

            if (xuly.ThemSachVaoThuVien(Sach))
            {
                MessageBox.Show("Thêm dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reresh();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            BAL_Sach xuly = new BAL_Sach();
            BEL_Sach Sach = new BEL_Sach();
            Sach.Masach = txtMaSach.Text.ToString();
            Sach.Tensach = txtTenSach.Text.ToString();
            Sach.Matheloai = xuly.LayMaTheLoai(cboTheLoai.Text.ToString());
            Sach.Soluong = int.Parse(txtSoLuong.Text.ToString());
            Sach.Giathue = int.Parse(nbrGiaThue.Value.ToString());
            if (xuly.CapNhatSach(Sach))
            {
                MessageBox.Show("Cập nhật dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reresh();
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BAL_Sach xuly = new BAL_Sach();
            BEL_Sach Sach = new BEL_Sach();
            Sach.Masach = txtMaSach.Text.ToString();
            if (xuly.XoaSachTheoMa(Sach.Masach))
            {
                MessageBox.Show("Xóa dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reresh();
             }
            else
            {
                MessageBox.Show("Xóa dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
            }
        }

        private void btnTimtheoten_Click(object sender, EventArgs e)
        {
            dgvSachThuVien.ForeColor = Color.Black;
            BAL_Sach xuly = new BAL_Sach();
            dgvSachThuVien.DataSource = xuly.LaySachtheoten(txtTenSach.Text);
        }
        private void dgvSachNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

            txtSoLuong.Text = dgvSachNhap.CurrentRow.Cells[1].Value.ToString();
            txtTenSach.Text = dgvSachNhap.CurrentRow.Cells[0].Value.ToString();
            nbrGiaThue.Value = 0;
            cbTrangThai.Checked = false;
        }

    }
}
