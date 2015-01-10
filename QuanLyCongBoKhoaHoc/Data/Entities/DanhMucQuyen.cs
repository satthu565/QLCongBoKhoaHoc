//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
    public class EDanhMucQuyen
    {
        public EDanhMucQuyen()
        {
        }
        private int _MaDanhMucQuyen;
        private string _TenDanhMucQuyen;


        public int MaDanhMucQuyen
        {
            get { return _MaDanhMucQuyen; }
            set { _MaDanhMucQuyen = value; }
        }
        public string TenDanhMucQuyen
        {
            get { return _TenDanhMucQuyen; }
            set { _TenDanhMucQuyen = value; }
        }
    }
}