using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Nhacungcap
    {
       private string _MaNCC;
       private string _TenNCC;
       private string _Diachi;
       private string _Email;
       private bool _Daxoa;
        public BEL_Nhacungcap()
       {
           this._MaNCC = "";
           this._TenNCC = "";
           this._Diachi = "";
           this._Email = "";
           this._Daxoa = false;
       }
        public BEL_Nhacungcap(string MaNCC,string TenNCC,string Diachi,string Email,bool Daxoa)
        {
            this._MaNCC = MaNCC;
            this._TenNCC = TenNCC;
            this._Diachi = Diachi;
            this._Email = Email;
            this._Daxoa = Daxoa;
        }
        public string MaNCC
        {
            get { return this._MaNCC; }
            set { this._MaNCC = value; }
        }
        public string TenNCC
        {
            get { return this._TenNCC; }
            set { this._TenNCC = value; }
        }
        public string Diachi
        {
            get { return this._Diachi; }
            set { this._Diachi = value; }
        }
        public string Email
        {
            get { return this._Email; }
            set { this._Email = value; }
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
    }
}
