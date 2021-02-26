using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BEL;
namespace DAL
{
    public class DAL_DocGia:general
    {
        //Xuất danh sách độc giả
        public DataTable DocDSDocGia()
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select MaTheDocGia 'Mã Thẻ Đọc Giả', HoTen 'Họ Tên',GioiTinh 'Giới Tính',NgaySinh 'Ngày Sinh',CMND,NgayLap 'Ngày Lập', NgayHetHan 'Ngày Hết Hạn',SDT,DiaChi 'Địa Chỉ',GhiChu 'Ghi Chú' from tbTheDocGia  where Daxoa = 0";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Lấy Độc giả theo mã
        public BEL_Thedocgia TimDocGiaTheoMa(string MaDocGia)
        {
            Getcon();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from tbTheDocGia where Daxoa = 0 and MaTheDocGia like N'" + MaDocGia + "'", con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                BEL_Thedocgia KQ = new BEL_Thedocgia(dt.Rows[0]["MaTheDocGia"].ToString(),
                    dt.Rows[0]["HoTen"].ToString(),
                    dt.Rows[0]["GioiTinh"].ToString(),
                    DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString()),
                    dt.Rows[0]["CMND"].ToString(),
                    DateTime.Parse(dt.Rows[0]["NgayLap"].ToString()),
                    dt.Rows[0]["SDT"].ToString(),
                    dt.Rows[0]["DiaChi"].ToString(),
                    dt.Rows[0]["GhiChu"].ToString(),
                    bool.Parse(dt.Rows[0]["DaXoa"].ToString()));
                return KQ;
            }
            catch (Exception err)
            {
                throw;
            }

        }
        //Thêm Thẻ Độc Giả
        public bool ThemDG(BEL_Thedocgia DG)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "insert into tbTheDocGia values('"+DG.Mathedocgia +"',N'" + DG.Hoten + "',N'" + DG.Gioitinh +"','"+DG.Ngaysinh+"','"+ DG.CMND +"','" + DG.Ngaylap+"','" + DG.Ngayhethan +"','"+ DG.SDT+"',N'"+DG.Diachi +"','"+DG.Ghichu+"','"+DG.Daxoa+"')";
                SqlCommand commmand = new SqlCommand(sql, con);
                ketqua = (commmand.ExecuteNonQuery() > 0);
            }
            catch (Exception err)
            {
                ketqua = TimDocGiaTheoMa(DG.Mathedocgia).Daxoa && CapNhatDG(DG);
            }
            finally
            {
                con.Close();
            }
            return ketqua;
        }
        //Cập nhật
        public bool CapNhatDG(BEL_Thedocgia DG)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbTheDocGia Set MaTheDocGia ='" + DG.Mathedocgia + "', HoTen = N'" + DG.Hoten + "', GioiTinh = N'" + DG.Gioitinh
                    + "', NgaySinh = '" + DG.Ngaysinh + "', CMND = '" + DG.CMND + "',NgayLap = '" + DG.Ngaylap +"',NgayHetHan ='"+DG.Ngayhethan+"',SDT ='"+DG.SDT+"',DiaChi =N'"+DG.Diachi +"',GhiChu = N'"+DG.Ghichu  + "' where MaTheDocGia ='" + DG.Mathedocgia + "'";
                SqlCommand commmand = new SqlCommand(sql, con);
                ketqua = (commmand.ExecuteNonQuery() > 0);
            }
            catch (Exception err)
            {

            }
            finally
            {
                con.Close();
            }
            return ketqua;
        }
        //Xóa 
        public bool XoaDG(string MaDG)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbTheDocGia Set Daxoa = 1 where MaTheDocGia ='" + MaDG + "'";
                SqlCommand commmand = new SqlCommand(sql, con);
                ketqua = (commmand.ExecuteNonQuery() > 0);
            }
            catch (Exception err)
            {

            }
            finally
            {
                con.Close();
            }
            return ketqua;
        }
        //Tìm Dộc Giả theo tên
        public DataTable TimDGtheoten(string ten)
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select MaTheDocGia 'Mã Thẻ Đọc Giả', HoTen 'Họ Tên',GioiTinh 'Giới Tính',NgaySinh 'Ngày Sinh',CMND,NgayLap 'Ngày Lập', NgayHetHan 'Ngày Hết Hạn',SDT,DiaChi 'Địa Chỉ',GhiChu 'Ghi Chú' from tbTheDocGia  where Daxoa = 0 and Hoten like N'%"+ ten +"%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}
