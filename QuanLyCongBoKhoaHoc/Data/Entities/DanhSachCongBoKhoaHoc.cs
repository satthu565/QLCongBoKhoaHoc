
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
    public class EDanhSachCongBoKhoaHoc
    {
        public EDanhSachCongBoKhoaHoc()
        {
        }
        private int _MaCongTrinhKhoaHoc;
        private int _MaCapDeTai;
        private string _TenCongTrinh;
        private string _ChuoiMaGiangVienChuNhiem;
        private string _ChuoiMaThanhVienThamGia;
        private string _NoiCongBo;
        private string _LinkFileMem;
        private string _TenChuNhiemNgoai;
        private string _TenThanhVienNgoai;
        private string _MaSo;
        private DateTime _NamCongBo;


        public int MaCongTrinhKhoaHoc
        {
            get { return _MaCongTrinhKhoaHoc; }
            set { _MaCongTrinhKhoaHoc = value; }
        }
        public int MaCapDeTai
        {
            get { return _MaCapDeTai; }
            set { _MaCapDeTai = value; }
        }
        public string TenCongTrinh
        {
            get { return _TenCongTrinh; }
            set { _TenCongTrinh = value; }
        }
        public string ChuoiMaGiangVienChuNhiem
        {
            get { return _ChuoiMaGiangVienChuNhiem; }
            set { _ChuoiMaGiangVienChuNhiem = value; }
        }
        public string ChuoiMaThanhVienThamGia
        {
            get { return _ChuoiMaThanhVienThamGia; }
            set { _ChuoiMaThanhVienThamGia = value; }
        }
        public string NoiCongBo
        {
            get { return _NoiCongBo; }
            set { _NoiCongBo = value; }
        }
        public string LinkFileMem
        {
            get { return _LinkFileMem; }
            set { _LinkFileMem = value; }
        }
        public string TenChuNhiemNgoai
        {
            get { return _TenChuNhiemNgoai; }
            set { _TenChuNhiemNgoai = value; }
        }
        public string TenThanhVienNgoai
        {
            get { return _TenThanhVienNgoai; }
            set { _TenThanhVienNgoai = value; }
        }
        public string MaSo
        {
            get { return _MaSo; }
            set { _MaSo = value; }
        }
        public DateTime NamCongBo
        {
            get { return _NamCongBo; }
            set { _NamCongBo = value; }
        }
    }
}