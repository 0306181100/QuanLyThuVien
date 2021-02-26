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
    public class DAL_NhaCungCap:general
    {
        //Xuất danh sách nhà cung cấp
        public DataTable DocDSNCC()
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select MaNCC 'Mã Nhà Cung Cấp', TenNCC 'Tên Nhà Cung Cấp', DiaChi 'Địa Chỉ',Email from tbNhaCungCap where Daxoa =0"; 
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
        //Lấy Nhà Cung Cấp Theo Mã
        public BEL_Nhacungcap TimNhaCungCapTheoMa(string Ma)
        {
            Getcon();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from tbNhaCungCap where Daxoa = 0 and MaNCC like N'" + Ma + "'", con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                BEL_Nhacungcap KQ = new BEL_Nhacungcap(dt.Rows[0]["MaNCC"].ToString(),
                    dt.Rows[0]["TenNCC"].ToString(),
                    dt.Rows[0]["DiaChi"].ToString(),
                    dt.Rows[0]["Email"].ToString(),
                    bool.Parse(dt.Rows[0]["Daxoa"].ToString())
                );
                return KQ;
            }
            catch (Exception err)
            {
                throw;
            }
        }
        //Thêm 
        public bool ThemNCC(BEL_Nhacungcap NCC)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "insert into tbNhaCungCap values('" + NCC.MaNCC + "',N'" + NCC.TenNCC + "',N'"
                 + NCC.Diachi + "',N'"+NCC.Email+"','" + NCC.Daxoa + "')";
                SqlCommand commmand = new SqlCommand(sql, con);
                ketqua = (commmand.ExecuteNonQuery() > 0);
            }
            catch (Exception err)
            {
                ketqua = TimNhaCungCapTheoMa(NCC.MaNCC).Daxoa && CapNhatNCC(NCC);
            }
            finally
            {
                con.Close();
            }
            return ketqua;
        }
        //Cập Nhật
        public bool CapNhatNCC(BEL_Nhacungcap NCC)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbNhaCungCap Set TenNCC = N'" + NCC.TenNCC + "', DiaChi = N'" + NCC.Diachi
                    + "', Email = '" + NCC.Email +", DaXoa='"+NCC.Daxoa+"' where MaNCC ='" + NCC.MaNCC + "'";
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
        public bool XoatNCC(string NCC)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbNhaCungCap Set Daxoa = 1 where MaNCC ='" + NCC + "'";
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
        public DataTable TimNCCtheoten(string ten)
        {
            Getcon();
            DataTable dt = new DataTable();
            string sql = "Select MaNCC 'Mã Nhà Cung Cấp', TenNCC 'Tên Nhà Cung Cấp', DiaChi 'Địa Chỉ',Email from tbNhaCungCap where Daxoa =0 and TenNCC like N'%"+ten+"%'";
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
