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
    public class DAL_NhanVien:general
    {
        //Xuất danh sách nhân viên
        public DataTable DocDSNhanVien()
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select MaNV 'Mã Nhân Viên', TaiKhoan 'Tài Khoản',HoTen 'Họ và Tên',NgaySinh 'Ngày Sinh',GioiTinh 'Giới Tính',SDT,DiaChi 'Địa Chỉ' from tbNhanVien  where Daxoa = 0 and Quyen = 0";
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
        //Lấy Nhân viên theo mã
        public BEL_Nhanvien TimNVTheoMa(string Manv)
        {
            Getcon();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from tbNhanVien B where Manv like N'" + Manv + "'", con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                BEL_Nhanvien KQ = new BEL_Nhanvien(dt.Rows[0]["Manv"].ToString(),
                    dt.Rows[0]["Hoten"].ToString(),
                    DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString()),
                    dt.Rows[0]["GioiTinh"].ToString(),
                    dt.Rows[0]["SDT"].ToString(),
                    dt.Rows[0]["DiaChi"].ToString(),
                    bool.Parse(dt.Rows[0]["Quyen"].ToString()),
                    bool.Parse(dt.Rows[0]["Daxoa"].ToString())
                    );
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
            bool ketqua = false;
            try
            {
                Getcon();
                DAL_TaiKhoan xl = new DAL_TaiKhoan();
                //Thêm tài khoản mật khẩu
                BEL_TaiKhoan tk = new BEL_TaiKhoan(
                    NV.Taikhoan, NV.SDT, false
                    );
                string sql = "insert into tbNhanVien values('" + NV.Manv + "','" + NV.Taikhoan + "',N'"
                    + NV.Hoten + "','" + NV.Ngaysinh + "',N'" + NV.Diachi + "',N'" + NV.Gioitinh + "','"
                    + NV.SDT + "','" + NV.Quyen + "','" + NV.Daxoa + "')";
                SqlCommand commmand = new SqlCommand(sql, con);
                ketqua = (commmand.ExecuteNonQuery() > 0) && xl.ThemTKMK(tk);
            }
            catch (Exception err)
            {
                    ketqua =TimNVTheoMa(NV.Manv).Daxoa && CapNhatNV(NV);
            }
            finally
            {
                con.Close();
            }
            return ketqua;
        }
        //Cập Nhật Nhân Viên
        public bool CapNhatNV(BEL_Nhanvien nv)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                if (!nv.Quyen)
                {
                    BEL_TaiKhoan tk = new BEL_TaiKhoan(
                    nv.Taikhoan, nv.SDT, false
                    );
                    DAL_TaiKhoan xl = new DAL_TaiKhoan();
                    string sql = "update tbNhanVien Set Taikhoan ='" + nv.Taikhoan + "',Hoten =N'"
                        + nv.Hoten + "',NgaySinh ='" + nv.Ngaysinh + "',DiaChi = N'" + nv.Diachi + "',GioiTinh = N'" + nv.Gioitinh + "',SDT ='"
                        + nv.SDT + "', DaXoa= 'False', Quyen='false' where Manv ='" + nv.Manv + "'";
                    SqlCommand commmand = new SqlCommand(sql, con);
                    ketqua =xl.CapNhatTK(tk) && (commmand.ExecuteNonQuery() > 0);
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
        public bool XoaNV(string Ma)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbNhanVien Set Daxoa = 1 where Manv ='" + Ma + "'";
                SqlCommand commmand = new SqlCommand(sql, con);
                if (commmand.ExecuteNonQuery() > 0)
                {
                    DAL_TaiKhoan xl = new DAL_TaiKhoan();
                    ketqua = xl.XoaTK(xl.TimTaiKhoanTheoTK(TimNVTheoMa(Ma).Taikhoan));
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
        //Tìm Nhân viên theo tên
        public DataTable TimNVtheoTen(string ten)
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select MaNV 'Mã Nhân Viên', TaiKhoan 'Tài Khoản',HoTen 'Họ và Tên',NgaySinh 'Ngày Sinh',GioiTinh 'Giới Tính',SDT,DiaChi 'Địa Chỉ' from tbNhanVien  where Daxoa = 0 and  Quyen =0 and Hoten like N'%"+ten+"%'";
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
