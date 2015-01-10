 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
    public class ELienHe
    {
        public ELienHe()
        {
        }
        private int _MaLienHe;
        private string _EmailNguoiGui;
        private string _HoTenNguoiGui;
        private int _MaGiangVienNhan;
        private string _TieuDe;
        private string _NoiDung;
        private bool _TrangThai;
        private string _DoiTuong;
        private string _TieuDeBai;
        private DateTime  _ThoiGian;

        public int MaLienHe
        {
            get { return _MaLienHe; }
            set { _MaLienHe = value; }
        }
        public string EmailNguoiGui
        {
            get { return _EmailNguoiGui; }
            set { _EmailNguoiGui = value; }
        }
        public string HoTenNguoiGui
        {
            get { return _HoTenNguoiGui; }
            set { _HoTenNguoiGui = value; }
        }
        public int MaGiangVienNhan
        {
            get { return _MaGiangVienNhan; }
            set { _MaGiangVienNhan = value; }
        }
        public string TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }
        public bool TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
        public string DoiTuong
        {
            get { return _DoiTuong; }
            set { _DoiTuong = value; }
        }
        public string TieuDeBai
        {
            get { return _TieuDeBai; }
            set { _TieuDeBai = value; }
        }
        public DateTime ThoiGian
        {
            get { return _ThoiGian; }
            set { _ThoiGian = value; }
        }
        
    }
}