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
    public class DAL_TaiKhoan:general
    {
        //Tạo tài khoản mật khẩu
        public BEL_TaiKhoan TimTaiKhoanTheoTK(string Tk)
        {
            BEL_TaiKhoan KQ =null;
            try {
                Getcon();  
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from tbTaiKhoan  where TaiKhoan = '" + Tk + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                KQ = new BEL_TaiKhoan(
                    dt.Rows[0]["Taikhoan"].ToString(),dt.Rows[0]["MatKhau"].ToString(),bool.Parse(dt.Rows[0]["Daxoa"].ToString())
                    );
            }
            catch(Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return KQ;
        }
        public bool ThemTKMK(BEL_TaiKhoan tkmk)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "insert into tbTaikhoan values('" + tkmk.Taikhoan + "','" + tkmk.Matkhau + "','" + tkmk.Daxoa + "')";
                SqlCommand commmand = new SqlCommand(sql, con);
                if (commmand.ExecuteNonQuery() > 0)
                    ketqua = true;
            }
            catch (Exception err)
            {
                ketqua = TimTaiKhoanTheoTK(tkmk.Taikhoan).Daxoa && CapNhatTK(tkmk);
            }
            finally
            {
                con.Close();
            }
            return ketqua;
        }

        private object TimTaiKhoanTheoTK(BEL_TaiKhoan tkmk)
        {
            throw new NotImplementedException();
        }
        public bool CapNhatTK(BEL_TaiKhoan tk)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbTaiKhoan Set MatKhau ='"+tk.Matkhau+"',DaXoa='"+tk.Daxoa+"' where Taikhoan like '"+tk.Taikhoan+"'";
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
        public bool XoaTK(BEL_TaiKhoan tkmk)
        {
            bool ketqua = false;
            try
            {
                Getcon();
                string sql = "update tbTaiKhoan Set Daxoa = 1 where Taikhoan ='" + tkmk.Taikhoan + "'";
                SqlCommand commmand = new SqlCommand(sql, con);
                ketqua= (commmand.ExecuteNonQuery() > 0);
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

    }
}
