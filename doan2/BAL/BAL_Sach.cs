using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BEL;
namespace BAL
{
    public class BAL_Sach
    {
        //Sách thư viện
        public DataTable DocDSsach()
        {
            try
            {
                DAL_Sach xuly = new DAL_Sach();
                return xuly.DocDSSach();
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Sách Nhập
        public DataTable DocDSSachnhap()
        {
            try
            {
                DAL_Sach xuly = new DAL_Sach();
                return xuly.DocDSSachNhap();
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Lấy sách theo mã sách
        public BEL_Sach TimSachTheoMa(string Ma)
        {
            try
            {
                DAL_Sach xuly = new DAL_Sach();
                BEL_Sach kq = xuly.TimSachTheoMa(Ma);
                return kq;
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Lấy mã thể loại theo thể loại
        public string LayMaTheLoai(string TheLoai)
        {
            try
            {
                DAL_Sach xuly = new DAL_Sach();
                return xuly.TimMaTheLoaiTheoTheLoai(TheLoai);
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Thêm Sách
        public bool ThemSachVaoThuVien(BEL_Sach Sach)
        {
            DAL_Sach xuly = new DAL_Sach();
            return xuly.ThemSachVaoThuVien(Sach);
        }
        //Hiển Thị Thể Loai
        public DataTable Hienthitheloai()
        {
            
            try
            {
                DAL_Sach xuly = new DAL_Sach();
                return xuly.HienThiTheLoai("tbTheLoai");
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Cập Nhật
        public bool CapNhatSach(BEL_Sach Sach)
        {
            DAL_Sach xuly = new DAL_Sach();
            return xuly.CapNhatSach(Sach);
        }
        //Xóa
        public bool XoaSachTheoMa(string ma)
        {
            DAL_Sach xuly = new DAL_Sach();
            return xuly.XoaSachTheoMa(ma);
        }
        //Tìm Sách Theo tên
        public DataTable LaySachtheoten(string Ten)
        {
            try
            {
                DAL_Sach xuly = new DAL_Sach();
                return xuly.TimSachTheoTen(Ten);
            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}
