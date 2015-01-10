//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
    public class EMenu
    {
        public EMenu()
        {
        }
        private int _MaMenu;
        private string _TenMenu;
        private string _KieuHienThi;
        private string _DoiTuong;
        private int _MaMenuCha;
        private byte _ThuTu;


        public int MaMenu
        {
            get { return _MaMenu; }
            set { _MaMenu = value; }
        }
        public string TenMenu
        {
            get { return _TenMenu; }
            set { _TenMenu = value; }
        }
        public string KieuHienThi
        {
            get { return _KieuHienThi; }
            set { _KieuHienThi = value; }
        }
        public string DoiTuong
        {
            get { return _DoiTuong; }
            set { _DoiTuong = value; }
        }

        public int MaMenuCha
        {
            get { return _MaMenuCha; }
            set { _MaMenuCha = value; }
        }
        public byte ThuTu
        {
            get { return _ThuTu; }
            set { _ThuTu = value; }
        }
    }
}