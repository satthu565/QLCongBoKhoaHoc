//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
    public class EQuyen
    {
        public EQuyen()
        {
        }
        private int _MaQuyen;
        private string _ChuoiDanhMucQuyen;
        private string _TenQuyen;


        public int MaQuyen
        {
            get { return _MaQuyen; }
            set { _MaQuyen = value; }
        }
        public string ChuoiDanhMucQuyen
        {
            get { return _ChuoiDanhMucQuyen; }
            set { _ChuoiDanhMucQuyen = value; }
        }
        public string TenQuyen
        {
            get { return _TenQuyen; }
            set { _TenQuyen = value; }
        }
    }
}