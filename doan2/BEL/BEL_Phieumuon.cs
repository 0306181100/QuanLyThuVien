using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Phieumuon
    {
        private string _Maphieumuon;
        private string _Mathedocgia;
        private DateTime _Ngaylap;
        private bool _Daxoa;
        public BEL_Phieumuon()
        {
            this._Maphieumuon = "";
            this._Mathedocgia = "";
            this._Ngaylap = DateTime.Now;
            this._Daxoa = false;
        }
        public BEL_Phieumuon(string Maphieumuon,string Mathedocgia,DateTime Ngaylap,bool Daxoa)
        {
            this._Maphieumuon = Maphieumuon;
            this._Mathedocgia = Mathedocgia;
            this._Ngaylap = Ngaylap;
            this._Daxoa = Daxoa;

        }
        public string Maphieumuon
        {
            get { return this._Maphieumuon; }
            set { this._Maphieumuon = value; }
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
        public string Mathedocgia
        {
            get { return _Mathedocgia; }
            set { _Mathedocgia = value; }
        }
        public DateTime Ngaylap
        {
            get { return _Ngaylap; }
            set { _Ngaylap = value; }
        }
    }
}
