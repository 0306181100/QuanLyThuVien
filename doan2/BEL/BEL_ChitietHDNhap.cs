using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_ChitietHDNhap
    {
        private string _MaHD;
        private string _Masach;
        private string _TenSach;

        public string TenSach
        {
            get { return _TenSach; }
            set { _TenSach = value; }
        }
        private int _Soluong;
        private int _Dongia;
        private bool _Dathem;
        private bool _Daxoa;
        public BEL_ChitietHDNhap()
        {
            this._MaHD = "";
            this._Masach = "";
            this._Soluong = 0;
            this._Dongia = 0;
            this._Dathem = true;
            this._Daxoa = false;
        }
        public BEL_ChitietHDNhap(string MaHD,string Masach,string TenSach,int Soluong,int Dongia,bool Dathem,bool Daxoa)
        {
            this._MaHD = MaHD;
            this._Masach = Masach;
            this._TenSach = TenSach;
            this._Soluong = Soluong;
            this._Dongia = Dongia;
            this._Dathem = Dathem;
            this._Daxoa = Daxoa;
        }
        public string MaHD
        {
            get { return this._MaHD; }
            set { this._MaHD = value; }
        }
        public string Masach
        {
            get { return this._Masach; }
            set { this._Masach = value; }
        }
        public int Soluong
        {
            get { return this._Soluong; }
            set { this._Soluong = value; }
        }
        public int Dongia
        {
            get { return this._Dongia; }
            set { this._Dongia = value; }
        }
        public bool Dathem
        {
            get { return this._Dathem; }
            set { this._Dathem = value; }
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
    }
}
