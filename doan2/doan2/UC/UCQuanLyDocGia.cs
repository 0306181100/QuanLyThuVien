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
    public partial class UCQuanLyDocGia : UserControl
    {
        public UCQuanLyDocGia()
        {
            InitializeComponent();
        }
        public void HienThi(DataGridView dgv)
        {
            dgv.ForeColor = Color.Black;
            BAL_DocGia xuly = new BAL_DocGia();
            dgv.DataSource = xuly.DocDanhSachTheDocGia();

        }

        private void UCQuanLyDocGia_Load(object sender, EventArgs e)
        {
            HienThi(dgvDanhSachDocGia);
        }

        private void dgvDanhSachDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaDG = dgvDanhSachDocGia.CurrentRow.Cells[0].Value.ToString().Trim();
            BAL_DocGia xuly = new BAL_DocGia();
            BEL_Thedocgia DG = xuly.LayDGTheoMa(MaDG);
            txtMaDG.Text = DG.Mathedocgia.ToString();
            txtHotenDG.Text = DG.Hoten.ToString();
            txtDiaChi.Text = DG.Diachi.ToString();
            txtCMND.Text = DG.CMND.ToString();
            txtSDT.Text = DG.SDT.ToString();
            dtpNgaySinh.Value = DateTime.Parse(DG.Ngaysinh);
            if (DG.Gioitinh.Equals("Nam"))
                radNam.Checked = true;
            else
                radNu.Checked = true;

            
        }
        void Reresh()
        {
            txtMaDG.Text = "";
            txtHotenDG.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
            txtSDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BAL_DocGia xuly = new BAL_DocGia();
            BEL_Thedocgia TheDG = new BEL_Thedocgia();
            dgvDanhSachDocGia.DataSource = null;
            TheDG.Mathedocgia = txtMaDG.Text.ToString();
            TheDG.Hoten = txtHotenDG.Text.ToString();
            if (radNam.Checked == true)
                TheDG.Gioitinh = "Nam";
            else
                TheDG.Gioitinh = "Nữ";
            TheDG.Ngaysinh = dtpNgaySinh.Value.ToString("d");
            TheDG.CMND = txtCMND.Text.ToString();
            TheDG.Diachi = txtDiaChi.Text.ToString();
            TheDG.SDT = txtSDT.Text.ToString();
            if (xuly.Them(TheDG))
            {
                MessageBox.Show("Thêm dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDanhSachDocGia.DataSource = xuly.DocDanhSachTheDocGia();
                Reresh();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDanhSachDocGia.DataSource = xuly.DocDanhSachTheDocGia();
                txtMaDG.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BAL_DocGia xuly = new BAL_DocGia();
            BEL_Thedocgia TheDG = new BEL_Thedocgia();
            dgvDanhSachDocGia.DataSource = null;
            TheDG.Mathedocgia = txtMaDG.Text.ToString();
            TheDG.Hoten = txtHotenDG.Text.ToString();
            if (radNam.Checked == true)
                TheDG.Gioitinh = "Nam";
            else
                TheDG.Gioitinh = "Nữ";
            TheDG.Ngaysinh = dtpNgaySinh.Value.ToString("d");
            TheDG.CMND = txtCMND.Text.ToString();
            TheDG.Diachi = txtDiaChi.Text.ToString();
            TheDG.SDT = txtSDT.Text.ToString();
            if (xuly.Xoa(TheDG.Mathedocgia))
            {
                MessageBox.Show("Xóa dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDanhSachDocGia.DataSource = xuly.DocDanhSachTheDocGia();
                Reresh();
            }
            else
            {
                MessageBox.Show("Xóa dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDanhSachDocGia.DataSource = xuly.DocDanhSachTheDocGia();
                txtMaDG.Focus();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            BAL_DocGia xuly = new BAL_DocGia();
            BEL_Thedocgia TheDG = new BEL_Thedocgia();
            dgvDanhSachDocGia.DataSource = null;
            TheDG.Mathedocgia = txtMaDG.Text.ToString();
            TheDG.Hoten = txtHotenDG.Text.ToString();
            if (radNam.Checked == true)
                TheDG.Gioitinh = "Nam";
            else
                TheDG.Gioitinh = "Nữ";
            TheDG.Ngaysinh = dtpNgaySinh.Value.ToString("d");
            TheDG.CMND = txtCMND.Text.ToString();
            TheDG.Diachi = txtDiaChi.Text.ToString();
            TheDG.SDT = txtSDT.Text.ToString();
            if (xuly.CapNhat(TheDG))
            {
                MessageBox.Show("Cập Nhật dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDanhSachDocGia.DataSource = xuly.DocDanhSachTheDocGia();
                Reresh();
            }
            else
            {
                MessageBox.Show("Cập nhật liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDanhSachDocGia.DataSource = xuly.DocDanhSachTheDocGia();
                txtMaDG.Focus();
            }
        }

        private void btnTimtheoten_Click(object sender, EventArgs e)
        {
            dgvDanhSachDocGia.ForeColor = Color.Black;
            BAL_DocGia xuly = new BAL_DocGia();
            dgvDanhSachDocGia.DataSource = xuly.LayDocGiaTheoTen(txtHotenDG.Text);
        }




    }
}
