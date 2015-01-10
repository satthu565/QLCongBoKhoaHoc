//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
    public class ETinTuc
    {
        public ETinTuc()
        {
        }
        private int _idTinTuc;
        private string _TieuDe;
        private string _MoTa;
        private string _AnhDaiDien;
        private string _NoiDung;
        private DateTime _NgayDang;
        private int _MaGiangVien;
        private int _MaMenu;


        public int idTinTuc
        {
            get { return _idTinTuc; }
            set { _idTinTuc = value; }
        }
        public string TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }
        public string AnhDaiDien
        {
            get { return _AnhDaiDien; }
            set { _AnhDaiDien = value; }
        }
        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }
        public DateTime NgayDang
        {
            get { return _NgayDang; }
            set { _NgayDang = value; }
        }
        public int MaGiangVien
        {
            get { return _MaGiangVien; }
            set { _MaGiangVien = value; }
        }
        public int MaMenu
        {
            get { return _MaMenu; }
            set { _MaMenu = value; }
        }
    }
}