using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Chitietphieumuon
    {
        private string _Maphieumuon;
        private string _Mathedocgia;
        private string _Masach;
        private DateTime _Ngaymuon;
        private int _Hanmuon;
        private string _Ngaytra;
        private bool _Daxoa;
        public BEL_Chitietphieumuon()
        {
            this._Maphieumuon = "";
            this._Mathedocgia = "";
            this._Masach = "";
            this._Ngaymuon = DateTime.Now;
            this._Hanmuon = 0;
            this._Ngaytra = "";
            this._Daxoa = false;
        }
        public BEL_Chitietphieumuon(string Madocgia,string Manv,string Masach,
            DateTime Ngaymuon,int Hanmuom,bool Daxoa)
        {
            this._Mathedocgia = Madocgia;
            this._Masach = Masach;
            this._Ngaymuon = Ngaymuon;
            this._Hanmuon = Hanmuon;
            this._Ngaytra = "";
            this._Daxoa = Daxoa;
        }
        public string Maphieumuon
        {
            get { return this._Maphieumuon; }
            set { this._Maphieumuon = value; }
        }
        public string Mathedocgia
        {
            get { return this._Mathedocgia; }
            set { this._Mathedocgia = value; }
        }
        public string Masach
        {
            get { return this._Masach; }
            set { this._Masach = value; }
        }
        public DateTime Ngaymuon
        {
            get { return this._Ngaymuon; }
            set { this._Ngaymuon = value; }
        }
        public int Hanmuon
        {
            get { return this._Hanmuon; }
            set { this._Hanmuon = value; }
        }
        public string Ngaytra
        {
            get { return this._Ngaytra; }
            set { this._Ngaytra = value; }
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
    }
}
