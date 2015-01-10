//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
    public class EQuaTrinhCongTac
    {
        public EQuaTrinhCongTac()
        {
        }
        private int _MaCongTac;
        private string _MoTaCongTac;
        private int _MaGiangVien;
        private string _NamcongTac;
        private int _ThuTuHienThi;


        public int MaCongTac
        {
            get { return _MaCongTac; }
            set { _MaCongTac = value; }
        }
        public string MoTaCongTac
        {
            get { return _MoTaCongTac; }
            set { _MoTaCongTac = value; }
        }
        public int MaGiangVien
        {
            get { return _MaGiangVien; }
            set { _MaGiangVien = value; }
        }
        public string NamcongTac
        {
            get { return _NamcongTac; }
            set { _NamcongTac = value; }
        }
        public int ThuTuHienThi
        {
            get { return _ThuTuHienThi; }
            set { _ThuTuHienThi = value; }
        }
    }
}