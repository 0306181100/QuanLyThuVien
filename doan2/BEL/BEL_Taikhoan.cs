using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_TaiKhoan
    {
        private string _Taikhoan;
        private string _Matkhau;
        private bool _Daxoa;
        public BEL_TaiKhoan()
        {
            this._Taikhoan = "";
            this._Matkhau = "";
            this._Daxoa = false;
        }
        public BEL_TaiKhoan(string Taikhoan,string MatKhau,bool Daxoa)
        {
            this._Taikhoan = Taikhoan;
            this._Matkhau = MatKhau;
            this._Daxoa = _Daxoa;
        }
        public string Taikhoan
        {
            get { return this._Taikhoan; }
            set { this._Taikhoan = value; }
        }
        public string Matkhau
        {
            get { return this._Matkhau; }
            set { this._Matkhau = value; }
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
    }
}
