using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Sach
    {
       private string _Masach;
       private string _Tensach;
       private string _Matheloai;
       private int _Giathue;
       private int _Soluong;
       private bool _Trangthai;
       private bool _Daxoa;
        public BEL_Sach()
        {
            this._Masach = "";
            this._Tensach = "";
            this._Matheloai = "";
            this._Giathue = 0;
            this._Soluong = 0;
            this._Trangthai = true;
            this._Daxoa = false;
        }
        public BEL_Sach(string Masach,string Tensach,string Matheloai,int Giathue,int Soluong,bool Trangthai, bool Daxoa)
        {
            this._Masach = Masach;
            this._Tensach = Tensach;
            this._Matheloai = Matheloai;
            this._Giathue = Giathue;
            this._Soluong = Soluong;
            this._Trangthai = Trangthai;
            this._Daxoa = Daxoa;
        }
        public string Masach
        {
            get { return this._Masach; }
            set { this._Masach = value; }
        }
        public string Tensach
        {
            get { return this._Tensach; }
            set { this._Tensach = value; }
        }
        public string Matheloai
        {
            get { return this._Matheloai; }
            set { this._Matheloai = value; }
        }
        
        public int Giathue
        {
            get { return this._Giathue; }
            set { this._Giathue = value; }
        }
        public int Soluong
        {
            get { return this._Soluong; }
            set { this._Soluong = value; }
        }
        public bool Trangthai
        {
            get { return this._Trangthai; }
            set { this._Trangthai= value; }
        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
    }
}
