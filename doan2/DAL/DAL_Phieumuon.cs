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
    public class DAL_Phieumuon:general
    {
        public DataTable DocDSPhieuMuon()
        {
            Getcon();
            DataTable dt = new DataTable();
            
            string sql = "select MaPhieuMuon 'Mã Phiếu Mượn',MaNv 'Tên Độc Giả',NgayLap 'Ngày Lập' from tbPhieuMuon  where Daxoa = 0";
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
