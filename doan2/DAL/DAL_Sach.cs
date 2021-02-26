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
    public class DAL_Sach:general
    {
        //Sách thư viện
        public DataTable DocDSSach()
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select MaSach Mã ,TenSach 'Tên Sách',Theloai 'Thể loại' ,GiaThue 'Giá sách',SoLuong 'Số lượng', TrangThai 'Trạng thái' "+
            "from tbSach A,tbTheloai B where A.MaTheLoai = B.MaTheLoai and A.Daxoa = 0";
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
        //Sách nhập
        public DataTable DocDSSachNhap()
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select TenSach 'Tên Sách' ,SoLuong 'Số lượng' from tbChiTietHoaDonNhap where Daxoa = 0";
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
        //Lấy sách theo mã
        public BEL_Sach TimSachTheoMa(string Masach)
        {
            Getcon();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from tbSach where Daxoa = 0 and MaSach like N'"+ Masach +"'", con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                BEL_Sach KQ= new BEL_Sach(dt.Rows[0]["MaSach"].ToString(),
                    dt.Rows[0]["TenSach"].ToString(),
                    dt.Rows[0]["MaTheLoai"].ToString(),
                    int.Parse(dt.Rows[0]["GiaThue"].ToString()),
                    int.Parse(dt.Rows[0]["SoLuong"].ToString()),
                    bool.Parse(dt.Rows[0]["TrangThai"].ToString()),
                    bool.Parse(dt.Rows[0]["DaXoa"].ToString()));
                return KQ;
            }
            catch (Exception err)
            {
                throw;
            }

        }
        //Tìm mã thể loại theo thể loại
        public String TimMaTheLoaiTheoTheLoai(string Theloai)
        {
            string matheloai = null;
            Getcon();
            DataTable dt = new DataTable();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select MaTheLoai from tbTheLoai where TheLoai like N'" + Theloai + "' and Daxoa = 0", con);
            try
            {
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    matheloai = dt.Rows[0]["matheloai"].ToString();
                }
                return matheloai;
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Thêm sách
        public bool ThemSachVaoThuVien(BEL_Sach Sach)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "insert into tbSach values('" + Sach.Masach + "',N'" + Sach.Tensach + "',N'"
                 + Sach.Matheloai + "'," + Sach.Giathue + "," + Sach.Soluong + ",'" + Sach.Trangthai + "','" + Sach.Daxoa + "')";
                SqlCommand commmand = new SqlCommand(sql, con);
                if (commmand.ExecuteNonQuery() > 0)
                    ketqua = true;
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
        //Hiển thị thể loại
        public DataTable HienThiTheLoai(string table)
        {
            Getcon();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select TheLoai from " + table, con);

            try
            {
                SqlDataReader rd = cmd.ExecuteReader();

                dt.Load(rd);

                return dt;
            }

            catch
            {
                throw;
            }
        }
        //Cập nhật
        public bool CapNhatSach(BEL_Sach Sach)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbSach Set TenSach = N'" + Sach.Tensach + "', MaTheLoai = '" + Sach.Matheloai
                    + "', GiaThue = " + Sach.Giathue + ", SoLuong = "+ Sach.Soluong + " where MaSach ='" +Sach.Masach + "'";
                SqlCommand commmand = new SqlCommand(sql, con);
                if (commmand.ExecuteNonQuery() > 0)
                {
                    ketqua = true;
                }
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
        //Xóa sách
        public bool XoaSachTheoMa(string ma)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbSach Set Daxoa = 1 where MaSach ='" + ma + "'";
                SqlCommand commmand = new SqlCommand(sql, con);
                if (commmand.ExecuteNonQuery() > 0)
                    ketqua = true;
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
        //Tìm sách theo tên
        public DataTable TimSachTheoTen (string Ten)
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select MaSach Mã ,TenSach 'Tên Sách',Theloai 'Thể loại' ,GiaThue 'Giá sách',SoLuong 'Số lượng', TrangThai 'Trạng thái' " +
            "from tbSach A,tbTheloai B where A.MaTheLoai = B.MaTheLoai and A.Daxoa = 0 and TenSach like N'%"+Ten+"%'";
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
