
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class EKhoa
   {
	 public EKhoa()
	 {
	 }
	 private int _MaKhoa ;
	 private string _TenKhoa ;
 

	 public int MaKhoa
	 {
	    get { return _MaKhoa ; }
	    set { _MaKhoa = value ; }
	 }
	 public string TenKhoa
	 {
	    get { return _TenKhoa ; }
	    set { _TenKhoa = value ; }
	 }
   }
 }