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
    public class BAL_TaiKhoan
    {
        public bool ThemTKMK(BEL_TaiKhoan tkmk)
        {
            DAL_TaiKhoan xuly = new DAL_TaiKhoan();
            return xuly.ThemTKMK(tkmk);
        }
        public bool CapNhatTK(BEL_TaiKhoan tkmk)
        {
            DAL_TaiKhoan xuly = new DAL_TaiKhoan();
            return xuly.CapNhatTK(tkmk);
        }
        public bool XoaTK(BEL_TaiKhoan tkmk)
        {
            DAL_TaiKhoan xuly = new DAL_TaiKhoan();
            return xuly.XoaTK(tkmk);
        }
        
    }
}
