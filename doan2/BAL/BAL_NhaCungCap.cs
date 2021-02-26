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
    public class BAL_NhaCungCap
    {
        public DataTable DocDSNhaCungCap()
        {
            try
            {
                DAL_NhaCungCap xuly = new DAL_NhaCungCap();
                return xuly.DocDSNCC();
            }
            catch (Exception err)
            {
                throw;
            }
        }
        public BEL_Nhacungcap LayNhaCungCapTheoMa(string Ma)
        {
            try
            {
                DAL_NhaCungCap xuly = new DAL_NhaCungCap();
                BEL_Nhacungcap KQ = xuly.TimNhaCungCapTheoMa(Ma);
                return KQ;
            }
            catch (Exception err)
            {
                throw;
            }
        }
        public bool Them(BEL_Nhacungcap NCC)
        {
            DAL_NhaCungCap xuly = new DAL_NhaCungCap();
            return xuly.ThemNCC(NCC);
        }
        public bool CapNhat(BEL_Nhacungcap NCC)
        {
            DAL_NhaCungCap xuly = new DAL_NhaCungCap();
            return xuly.CapNhatNCC(NCC);
        }
        public bool Xoa(string Ma)
        {
            DAL_NhaCungCap xuly = new DAL_NhaCungCap();
            return xuly.XoatNCC(Ma);
        }
        //Lấy nhà cung cấp theo tên
        public DataTable LayNCCtheoTen(string ten)
        {
            try
            {
                DAL_NhaCungCap xuly = new DAL_NhaCungCap();
                return xuly.TimNCCtheoten(ten);
            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}
