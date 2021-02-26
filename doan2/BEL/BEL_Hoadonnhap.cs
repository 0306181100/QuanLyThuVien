using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BEL
{
    public class BEL_Hoadonnhap
    {
        private string _MaHD;
        private string _MaNCC;
        private DateTime _Ngaylap;
        private bool _Daxoa;
        public BEL_Hoadonnhap()
        {
            this._MaHD = "";
            this._MaNCC = "";
            this._Ngaylap = DateTime.Now;
            this._Daxoa = false;
        }
        public BEL_Hoadonnhap(string MaHD,string MaNCC,DateTime Ngaylap,bool Daxoa)
        {
            this._MaHD = MaHD;
            this._MaNCC = MaNCC;
            this._Ngaylap = Ngaylap;
            this._Daxoa = Daxoa;
        }
        public string MaHD
        {
            get { return this._MaHD; }
            set { this._MaHD = value; }
        }
        public string MaNCC
        {
            get { return this._MaNCC; }
            set {this._MaNCC = value;}
        }
        public DateTime Ngaylap
        {
            get { return this._Ngaylap; }
            set { this._Ngaylap = value; }
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
    }
}
