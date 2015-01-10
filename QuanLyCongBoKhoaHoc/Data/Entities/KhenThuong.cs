
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class EKhenThuong
   {
	 public EKhenThuong()
	 {
	 }
	 private int _MaKhenThuong ;
	 private string _TenKhenThuong ;
	 private string _So ;
	 private DateTime _NamNhan ;
	 private int _MaGiangVien ;
 

	 public int MaKhenThuong
	 {
	    get { return _MaKhenThuong ; }
	    set { _MaKhenThuong = value ; }
	 }
	 public string TenKhenThuong
	 {
	    get { return _TenKhenThuong ; }
	    set { _TenKhenThuong = value ; }
	 }
	 public string So
	 {
	    get { return _So ; }
	    set { _So = value ; }
	 }
	 public DateTime NamNhan
	 {
	    get { return _NamNhan ; }
	    set { _NamNhan = value ; }
	 }
	 public int MaGiangVien
	 {
	    get { return _MaGiangVien ; }
	    set { _MaGiangVien = value ; }
	 }
   }
 }