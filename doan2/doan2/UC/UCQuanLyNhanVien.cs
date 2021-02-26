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
    public partial class UCQuanLyNhanVien : UserControl
    {
        public UCQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void UCQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            Hienthi();
            radNam.Checked = true;
        }
        public void Hienthi()
        {
            dgvDanhSachNhanVien.ForeColor = Color.Black;
            BAL_NhanVien xuly = new BAL_NhanVien();
            dgvDanhSachNhanVien.DataSource = xuly.DocDSNhanVien();
        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma = dgvDanhSachNhanVien.CurrentRow.Cells[0].Value.ToString().Trim();
            BAL_NhanVien xuly = new BAL_NhanVien();
            BEL_Nhanvien NV = xuly.TimNVTheoMa(ma);
            txtMa.Text = NV.Manv.ToString();
            txtTen.Text = NV.Hoten.ToString();
            txtDiaChi.Text = NV.Diachi.ToString();
            txtSDT.Text = NV.SDT.ToString();
            dtpNgaySinh.Value = DateTime.Parse(NV.Ngaysinh);
            if (NV.Gioitinh.Equals("Nam"))
                radNam.Checked = true;
            else
                radNu.Checked = true;
        }
        void Reresh()
        {
            BAL_NhanVien xuly = new BAL_NhanVien();
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            radNam.Checked = true;
            dgvDanhSachNhanVien.DataSource = null;
            dgvDanhSachNhanVien.DataSource = xuly.DocDSNhanVien();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            BAL_NhanVien xuly = new BAL_NhanVien();
            BEL_Nhanvien NV = new BEL_Nhanvien(
                   txtMa.Text,
                   txtTen.Text,
                   dtpNgaySinh.Value,
                   (radNam.Checked) ? "Nam" : "Nữ",
                   txtSDT.Text,
                   txtDiaChi.Text, false, false
                   );
            if (xuly.ThemNV(NV))
            {
                MessageBox.Show("Thêm dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reresh();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu thất bại! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reresh();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BAL_NhanVien xuly = new BAL_NhanVien();
            BAL_TaiKhoan xulytk = new BAL_TaiKhoan();
            BEL_TaiKhoan tkmk = new BEL_TaiKhoan(
                   "Nv" + txtMa.Text,
                    txtSDT.Text,
                    false
                );
            if (xulytk.XoaTK(tkmk))
            {
                BEL_Nhanvien NV = new BEL_Nhanvien(
                   txtMa.Text,
                   txtTen.Text,
                   dtpNgaySinh.Value,
                   (radNam.Checked) ? "Nam" : "Nữ",
                   txtSDT.Text,
                   txtDiaChi.Text, false, false
                   );
                if (xuly.XoaNV(NV.Manv))
                {
                    MessageBox.Show("Xóa dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reresh();
                }
            }
            else
            {
                MessageBox.Show("Xóa dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            BAL_NhanVien xuly = new BAL_NhanVien();
            BEL_Nhanvien NV = new BEL_Nhanvien(
                txtMa.Text,
                txtTen.Text,
                dtpNgaySinh.Value,
                (radNam.Checked) ? "Nam" : "Nữ",
                txtSDT.Text,
                txtDiaChi.Text,false,false
                );
            BAL_TaiKhoan xulytk = new BAL_TaiKhoan();
            BEL_TaiKhoan tkmk = new BEL_TaiKhoan(
                "Nv" + NV.Manv,
                txtSDT.Text.ToString(),
                NV.Daxoa
                );
            
            if (xulytk.CapNhatTK(tkmk))
            {
                if (xuly.CapNhatNV(NV))
                {
                    MessageBox.Show("Cập nhật dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDanhSachNhanVien.DataSource = xuly.DocDSNhanVien();
                    Reresh();
                }
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
            }
        }

        private void btnTimtheoten_Click(object sender, EventArgs e)
        {
            dgvDanhSachNhanVien.ForeColor = Color.Black;
            BAL_NhanVien xuly = new BAL_NhanVien();
            dgvDanhSachNhanVien.DataSource = xuly.TimNVtheoTen(txtTen.Text);
        }


    }
}
