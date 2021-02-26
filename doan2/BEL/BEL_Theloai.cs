using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Theloai
    {
        private string _Matheloai;
        private string _Theloai;
        private bool _Daxoa;
        public BEL_Theloai()
        {
            this._Matheloai = "";
            this._Theloai = "";
            this._Daxoa = false;
        }
        public BEL_Theloai(string Matheloai,string Theloai,bool Daxoa)
        {
            this._Matheloai = Matheloai;
            this._Theloai = Theloai;
            this._Daxoa = Daxoa;
        }
        public string Matheloai
        {
            get { return this._Matheloai; }
            set { this._Matheloai = value; }
        }
        public string Theloai
        {
            get { return this._Theloai; }
            set { this._Theloai = value; }
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }

    }
}
