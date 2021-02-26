using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Nhanvien
    {
        private string _Manv;
        private string _Taikhoan;
        private string _Hoten;
        private string _Ngaysinh;
        private string _Diachi;
        private string _Gioitinh;
        private string _SDT;
        private bool _Quyen;
        private bool _Daxoa;
        public BEL_Nhanvien()
        {
            this._Manv = "";
            this._Taikhoan = "";
            this._Hoten = "";
            this._Ngaysinh ="1/1/2019";
            this._Gioitinh = "";
            this._Diachi = "";
            this._SDT = "";
            this._Quyen = false;
            this._Daxoa = false;
        }
        public BEL_Nhanvien(string Manv, string Hoten, DateTime Ngaysinh, string Gioitinh, string SDT, string Diachi, bool Quyen, bool Daxoa)
        {
            this._Manv = Manv;
            this._Taikhoan = "Nv"+Manv;
            this._Hoten = Hoten;
            this._Diachi = Diachi;
            this._Ngaysinh = Ngaysinh.ToString("d");
            this._Gioitinh = Gioitinh;
            this._SDT = SDT;
            this._Quyen =Quyen;
            this._Daxoa=Daxoa;
        }
        public string Manv
        {
            get{return this._Manv;}
            set{this._Manv =value;}
        }
        public string Diachi
        {
            get { return this._Diachi; }
            set { this._Diachi = value; }
        }
        public string Taikhoan
        {
            get{return this._Taikhoan;}
            set{this._Taikhoan=value;}
        }
        public string Hoten
        {
            get{return this._Hoten;}
            set{this._Hoten=value;}
        }
        public string Ngaysinh
        {
            get{return this._Ngaysinh;}
            set{this._Ngaysinh=value;}
        }
        public string Gioitinh
        {
            get{return this._Gioitinh;}
            set{this._Gioitinh=value;}
        }
        public string SDT
        {
            get{return this._SDT;}
            set{this._SDT=value;}
        }
        public bool Quyen
        {
            get{return this._Quyen;}
            set{this._Quyen=value;}
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
    }
}
