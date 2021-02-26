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
    public partial class UCQuanLyNhaCungCap : UserControl
    {
        public UCQuanLyNhaCungCap()
        {
            InitializeComponent();
            HienThi(dgvNhaCungCap);
        }
        public void HienThi(DataGridView dgv)
        {
            dgv.ForeColor = Color.Black;
            BAL_NhaCungCap xuly = new BAL_NhaCungCap();
            dgv.DataSource = xuly.DocDSNhaCungCap(); 
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaNCC = dgvNhaCungCap.CurrentRow.Cells[0].Value.ToString().Trim();
            BAL_NhaCungCap xuly = new BAL_NhaCungCap();
            BEL_Nhacungcap NCC = xuly.LayNhaCungCapTheoMa(MaNCC);
            txtMa.Text = NCC.MaNCC.ToString();
            txtTen.Text = NCC.TenNCC.ToString();
            txtDiaChi.Text = NCC.Diachi.ToString();
            txtEmail.Text = NCC.Email.ToString();
        }
        void Reresh()
        {
            HienThi(dgvNhaCungCap);
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            BAL_NhaCungCap xuly = new BAL_NhaCungCap();
            BEL_Nhacungcap NCC = new BEL_Nhacungcap();
            dgvNhaCungCap.DataSource = null;
            NCC.MaNCC = txtMa.Text.ToString();
            NCC.TenNCC = txtTen.Text.ToString();
            NCC.Diachi = txtDiaChi.Text.ToString();
            NCC.Email = txtEmail.Text.ToString();
            if (xuly.Them(NCC))
            {
                MessageBox.Show("Thêm dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reresh();            
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThi(dgvNhaCungCap);
                txtMa.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BAL_NhaCungCap xuly = new BAL_NhaCungCap();
            BEL_Nhacungcap NCC = new BEL_Nhacungcap();
            dgvNhaCungCap.DataSource = null;
            NCC.MaNCC = txtMa.Text.ToString();
            NCC.TenNCC = txtTen.Text.ToString();
            NCC.Diachi = txtDiaChi.Text.ToString();
            NCC.Email = txtEmail.Text.ToString();
            if (xuly.Xoa(NCC.MaNCC))
            {
                MessageBox.Show("Xóa dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reresh();

            }
            else
            {
                MessageBox.Show("Xóa dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThi(dgvNhaCungCap);
                txtMa.Focus();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            BAL_NhaCungCap xuly = new BAL_NhaCungCap();
            BEL_Nhacungcap NCC = new BEL_Nhacungcap();
            dgvNhaCungCap.DataSource = null;
            NCC.MaNCC = txtMa.Text.ToString();
            NCC.TenNCC = txtTen.Text.ToString();
            NCC.Diachi = txtDiaChi.Text.ToString();
            NCC.Email = txtEmail.Text.ToString();
            if (xuly.CapNhat(NCC))
            {
                MessageBox.Show("Cập Nhật dữ liệu thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reresh();
            }
            else
            {
                MessageBox.Show("Cập Nhật dữ liệu thất bại vui lòng xem lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThi(dgvNhaCungCap);
                txtMa.Focus();
            }
        }

        private void btnTimtheoten_Click(object sender, EventArgs e)
        {
            dgvNhaCungCap.ForeColor = Color.Black;
            BAL_NhaCungCap xuly = new BAL_NhaCungCap();
            dgvNhaCungCap.DataSource = xuly.LayNCCtheoTen(txtTen.Text); 
        }

      


    }
}
