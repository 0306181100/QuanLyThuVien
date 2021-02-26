using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Thedocgia
    {
        private string _Mathedocgia;
        private string _Hoten;
        private string _Gioitinh;
        private string _Ngaysinh;
        private string _CMND;
        private DateTime _Ngaylap;
        private DateTime _Ngayhethan;
        private string _SDT;
        private string _Diachi;
        private string _Ghichu;
        private bool _Daxoa;
        public BEL_Thedocgia()
        {
            this._Mathedocgia = "";
            this._Hoten = "";
            this._Gioitinh = "";
            this._Ngaysinh= "1/1/2019";
            this._CMND = "";
            this._Ngaylap = DateTime.Now;
            this._Ngayhethan = this._Ngaylap.AddDays(30);
            this._SDT = "";
            this._Diachi = "";
            this._Ghichu = null;
            this._Daxoa = false;
        }
        public BEL_Thedocgia(string Mathedocgia,string Hoten,string Gioitinh,DateTime Ngaysinh,string CMND,DateTime Ngaylap,string SDT,string Diachi,string Ghichu,bool Daxoa)
        {
            this._Mathedocgia = Mathedocgia;
            this._Hoten = Hoten;
            this._Gioitinh = Gioitinh;
            this._Ngaysinh=Ngaysinh.ToString("d");
            this._CMND = CMND;
            this._Ngaylap = Ngaylap;
            this._SDT = SDT;
            this._Diachi = Diachi;
            this._Ngayhethan = this._Ngaylap.AddDays(30);
            this._Ghichu = Ghichu;
            this._Daxoa = Daxoa;
        }
        public string Mathedocgia
        {
            get { return this._Mathedocgia; }
            set { this._Mathedocgia = value; }
        }
        public string Hoten
        {
            get { return this._Hoten; }
            set { this._Hoten = value; }
        }
        public string Gioitinh
        {
            get { return this._Gioitinh; }
            set { this._Gioitinh = value; }
        }
        public string Ngaysinh
        {
            get { return this._Ngaysinh; }
            set { this._Ngaysinh = value; }
        }
        public string CMND
        {
            get { return this._CMND; }
            set { this._CMND = value; }
        }
        public DateTime Ngaylap
        {
            get { return this._Ngaylap; }
            set { this._Ngaylap = value; }
        }
        public DateTime Ngayhethan
        {
            get { return this._Ngayhethan; }
            set { this._Ngayhethan = value; }
        }
        public string SDT
        {
            get { return this._SDT; }
            set { this._SDT = value; }
        }
        public string Diachi
        {
            get { return this._Diachi; }
            set { this._Diachi = value; }
        }
        public string Ghichu
        {
            get { return this._Ghichu; }
            set { this._Ghichu = value; }

        }
        public bool Daxoa
        {
            get { return this._Daxoa; }
            set { this._Daxoa = value; }
        }
    }
}
