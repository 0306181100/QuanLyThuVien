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
    public class BAL_NhanVien
    {
        //Danh Sách Nhân Viên
        public DataTable DocDSNhanVien()
        {
            try
            {
                DAL_NhanVien xuly = new DAL_NhanVien();
                return xuly.DocDSNhanVien();
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Lấy NV theo mã
        public BEL_Nhanvien TimNVTheoMa(string Ma)
        {
            try
            {
                DAL_NhanVien xuly = new DAL_NhanVien();
                BEL_Nhanvien KQ = xuly.TimNVTheoMa(Ma);
                return KQ;
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Thêm Nhân Viên
        public bool ThemNV(BEL_Nhanvien NV)
        {
            DAL_NhanVien xuly = new DAL_NhanVien();
            return xuly.ThemNV(NV);
        }
        //Cập nhật nhân viên
        public bool CapNhatNV(BEL_Nhanvien NV)
        {
            DAL_NhanVien xuly = new DAL_NhanVien();
            return xuly.CapNhatNV(NV);
        }
        //Xóa Nhân Viên
        public bool XoaNV(string Ma)
        {
            DAL_NhanVien xuly = new DAL_NhanVien();
            return xuly.XoaNV(Ma);
        }
        //Tìm Nhân viên theo tên
        public DataTable TimNVtheoTen(string ten)
        {
            try
            {
                DAL_NhanVien xuly = new DAL_NhanVien();
                return xuly.TimNVtheoTen(ten);
            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}
