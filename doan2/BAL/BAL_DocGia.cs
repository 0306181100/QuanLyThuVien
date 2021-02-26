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
    public class BAL_DocGia
    {
        //Xuất danh sách thẻ độc giả
        public DataTable DocDanhSachTheDocGia()
        {
            try
            {
                DAL_DocGia xuly = new DAL_DocGia();
                return xuly.DocDSDocGia();
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Lấy Độc Giả Theo MãDG
        public BEL_Thedocgia LayDGTheoMa(string Ma)
        {
            try
            {
                DAL_DocGia xuly = new DAL_DocGia();
                BEL_Thedocgia kq = xuly.TimDocGiaTheoMa(Ma);
                return kq;
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Thêm Độc Giả
        public bool Them(BEL_Thedocgia DG)
        {
            DAL_DocGia xuly = new DAL_DocGia();
            return xuly.ThemDG(DG);
        }
        //Cập nhật
        public bool CapNhat(BEL_Thedocgia DG)
        {
            DAL_DocGia xuly = new DAL_DocGia();
            return xuly.CapNhatDG(DG);
        }
        //Xóa
        public bool Xoa(string DG)
        {
            DAL_DocGia xuly = new DAL_DocGia();
            return xuly.XoaDG(DG);
        }
        //Tìm theo tên
        public DataTable LayDocGiaTheoTen(string ten)
        {
            try
            {
                DAL_DocGia xuly = new DAL_DocGia();
                return xuly.TimDGtheoten(ten);
            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}
