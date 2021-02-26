using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BEL;

namespace doan2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            do
                DN.ShowDialog();
            while(!DN.Flag);
        }

        DangNhap DN = new DangNhap();
        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoQuanly(tabControl1);
        }

        private void KhoiTaoQuanly(TabControl tct)
        {

            ImageList iconlist = new ImageList();
            string[] Text = { "Thông báo", "Độc giả", "Sách", "Nhân viên" };
            tct.Controls.Clear();
            UCThongBao MyUC1=new UCThongBao();
            MyUC1.AutoScroll = true;
            UCQuanLyDocGia MyUC2 = new UCQuanLyDocGia();
            MyUC2.AutoScroll = true;
            UCQLSachThuVien MyUC3 = new UCQLSachThuVien();
            MyUC3.AutoScroll = true;

            MyUC1.Dock = DockStyle.Fill;
            MyUC2.Dock = DockStyle.Fill;
            MyUC3.Dock = DockStyle.Fill;
            
            TabPage MyTabPages1 = new TabPage();
            TabPage MyTabPages2 = new TabPage();
            TabPage MyTabPages3 = new TabPage();

            MyTabPages1.Controls.Add(MyUC1);
            MyTabPages2.Controls.Add(MyUC2);
            MyTabPages3.Controls.Add(MyUC3);

            MyTabPages1.Name = "tab1";
            MyTabPages2.Name = "tab2";
            MyTabPages3.Name = "tab3";

            MyTabPages1.Text = Text[0];
            MyTabPages2.Text = Text[1];
            MyTabPages3.Text = Text[2];

            tct.Controls.Add(MyTabPages1);
            tct.Controls.Add(MyTabPages2);
            tct.Controls.Add(MyTabPages3);

            if (true)//kiểm tra quyền
            {
                UCQuanLyNhanVien MyUC4 = new UCQuanLyNhanVien();
                MyUC4.AutoScroll = true;
                MyUC4.Dock = DockStyle.Fill;
                TabPage MyTabPages4 = new TabPage();
                MyTabPages4.Controls.Add(MyUC4);
                MyTabPages4.Name = "tab4";
                MyTabPages4.Text = Text[3];
                tct.Controls.Add(MyTabPages4);
            }
        }

        private void KhoiTaoLapHoaDon(TabControl tct)
        {
            tct.Controls.Clear();
            UCQuanLyNhaCungCap MyUC1 = new UCQuanLyNhaCungCap();
            MyUC1.AutoScroll = true;
            UCNhapHoaDonNhap MyUC2 = new UCNhapHoaDonNhap();
            MyUC2.AutoScroll = true;
            UCQuanLyHoaDonNhap MyUC3 = new UCQuanLyHoaDonNhap();
            MyUC3.AutoScroll = true;

            MyUC1.Dock = DockStyle.Fill;
            MyUC2.Dock = DockStyle.Fill;
            MyUC3.Dock = DockStyle.Fill;

            TabPage MyTabPages1 = new TabPage();
            TabPage MyTabPages2 = new TabPage();
            TabPage MyTabPages3 = new TabPage();

            MyTabPages1.Controls.Add(MyUC1);
            MyTabPages2.Controls.Add(MyUC2);
            MyTabPages3.Controls.Add(MyUC3);

            MyTabPages1.Name = "tab1";
            MyTabPages2.Name = "tab2";
            MyTabPages3.Name = "tab3";

            MyTabPages1.Text = "Nhà cung cấp";
            MyTabPages2.Text = "Sách nhập";
            MyTabPages3.Text = "Hóa đơn nhập";

            tct.Controls.Add(MyTabPages1);
            tct.Controls.Add(MyTabPages2);
            tct.Controls.Add(MyTabPages3);
        }

        private void KhoiTaoMuonTra(TabControl tct)
        {
            tct.Controls.Clear();
            UCMuonSach MyUC1 = new UCMuonSach();
            MyUC1.AutoScroll = true;
            UCTraSach MyUC2 = new UCTraSach();
            MyUC2.AutoScroll = true;

            MyUC1.Dock = DockStyle.Fill;
            MyUC2.Dock = DockStyle.Fill;

            TabPage MyTabPages1 = new TabPage();
            TabPage MyTabPages2 = new TabPage();

            MyTabPages1.Controls.Add(MyUC1);
            MyTabPages2.Controls.Add(MyUC2);

            MyTabPages1.Name = "tab1";
            MyTabPages2.Name = "tab2";

            MyTabPages1.Text = "Mượn sách";
            MyTabPages2.Text = "Trả sách";

            tct.Controls.Add(MyTabPages1);
            tct.Controls.Add(MyTabPages2);

        }
        private void button4_Click_1(object sender, EventArgs e)
        {

            KhoiTaoQuanly(tabControl1);
        }

        private void btnDoiTK_Click(object sender, EventArgs e)
        {
            DangNhap DN = new DangNhap();
            DN.ShowDialog();
        }

        private void btnNhapSach_Click(object sender, EventArgs e)
        {

            KhoiTaoLapHoaDon(tabControl1);
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
            KhoiTaoMuonTra(tabControl1);
        }

 
    }
}
