//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class ESauDaiHoc
   {
	 public ESauDaiHoc()
	 {
	 }
	 private int _MaSauDaiHoc ;
	 private int _MaHocVien ;
	 private string _NoiDaoTao ;
	 private string _ThoiGianDaoTao ;
	 private DateTime _ThoiGianBatDau ;
	 private DateTime _ThoiGianBaoVe ;
	 private string _TenDeTai ;
	 private string _LoaiDaoTao ;
	 private int _MaGiangVien ;
	 private bool _TrangThai ;
 

	 public int MaSauDaiHoc
	 {
	    get { return _MaSauDaiHoc ; }
	    set { _MaSauDaiHoc = value ; }
	 }
	 public int MaHocVien
	 {
	    get { return _MaHocVien ; }
	    set { _MaHocVien = value ; }
	 }
	 public string NoiDaoTao
	 {
	    get { return _NoiDaoTao ; }
	    set { _NoiDaoTao = value ; }
	 }
	 public string ThoiGianDaoTao
	 {
	    get { return _ThoiGianDaoTao ; }
	    set { _ThoiGianDaoTao = value ; }
	 }
	 public DateTime ThoiGianBatDau
	 {
	    get { return _ThoiGianBatDau ; }
	    set { _ThoiGianBatDau = value ; }
	 }
	 public DateTime ThoiGianBaoVe
	 {
	    get { return _ThoiGianBaoVe ; }
	    set { _ThoiGianBaoVe = value ; }
	 }
	 public string TenDeTai
	 {
	    get { return _TenDeTai ; }
	    set { _TenDeTai = value ; }
	 }
	 public string LoaiDaoTao
	 {
	    get { return _LoaiDaoTao ; }
	    set { _LoaiDaoTao = value ; }
	 }
	 public int MaGiangVien
	 {
	    get { return _MaGiangVien ; }
	    set { _MaGiangVien = value ; }
	 }
	 public bool TrangThai
	 {
	    get { return _TrangThai ; }
	    set { _TrangThai = value ; }
	 }
   }
 }