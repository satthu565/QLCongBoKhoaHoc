 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
    public class EBaiBao
    {
        public EBaiBao()
        {
        }
        private int _MaBaiBao;
        private string _TenBaiBao;
        private DateTime _ThoiGianXuatBan;
        private string _NoiCongBo;
        private bool _GioiHan;
        private string _ChuoiMaGiangVienTacGia;
        private string _TenTacGiaNgoai;
        private string _MaSo;
        private string _NoiDungTomTat;
        private string _FileMem;
        private string _NoiXuatBan;

        public int MaBaiBao
        {
            get { return _MaBaiBao; }
            set { _MaBaiBao = value; }
        }
        public string TenBaiBao
        {
            get { return _TenBaiBao; }
            set { _TenBaiBao = value; }
        }
        public DateTime ThoiGianXuatBan
        {
            get { return _ThoiGianXuatBan; }
            set { _ThoiGianXuatBan = value; }
        }
        public string NoiCongBo
        {
            get { return _NoiCongBo; }
            set { _NoiCongBo = value; }
        }
        public bool GioiHan
        {
            get { return _GioiHan; }
            set { _GioiHan = value; }
        }
        public string ChuoiMaGiangVienTacGia
        {
            get { return _ChuoiMaGiangVienTacGia; }
            set { _ChuoiMaGiangVienTacGia = value; }
        }
        public string TenTacGiaNgoai
        {
            get { return _TenTacGiaNgoai; }
            set { _TenTacGiaNgoai = value; }
        }
        public string MaSo
        {
            get { return _MaSo; }
            set { _MaSo = value; }
        }  
        public string NoiDungTomTat
        {
            get { return _NoiDungTomTat; }
            set { _NoiDungTomTat = value; }
        }

        public string FileMem
        {
            get { return _FileMem; }
            set { _FileMem = value; }
        }

        public string NoiXuatBan
        {
            get { return _NoiXuatBan; }
            set { _NoiXuatBan = value; }
        }

    }
}