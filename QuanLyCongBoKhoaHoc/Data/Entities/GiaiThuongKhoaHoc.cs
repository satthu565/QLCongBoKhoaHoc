 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class EGiaiThuongKhoaHoc
   {
	 public EGiaiThuongKhoaHoc()
	 {
	 }
	 private int _MaGiaiThuongKhoaHoc ;
	 private string _TenGiaiThuong ;
	 private string _LinhVuc ;
	 private DateTime _NamNhan ;
	 private string _NoiCap ;
	 private string _So ;
	 private int _MaGiangVien ;
 

	 public int MaGiaiThuongKhoaHoc
	 {
	    get { return _MaGiaiThuongKhoaHoc ; }
	    set { _MaGiaiThuongKhoaHoc = value ; }
	 }
	 public string TenGiaiThuong
	 {
	    get { return _TenGiaiThuong ; }
	    set { _TenGiaiThuong = value ; }
	 }
	 public string LinhVuc
	 {
	    get { return _LinhVuc ; }
	    set { _LinhVuc = value ; }
	 }
	 public DateTime NamNhan
	 {
	    get { return _NamNhan ; }
	    set { _NamNhan = value ; }
	 }
	 public string NoiCap
	 {
	    get { return _NoiCap ; }
	    set { _NoiCap = value ; }
	 }
	 public string So
	 {
	    get { return _So ; }
	    set { _So = value ; }
	 }
	 public int MaGiangVien
	 {
	    get { return _MaGiangVien ; }
	    set { _MaGiangVien = value ; }
	 }
   }
 }