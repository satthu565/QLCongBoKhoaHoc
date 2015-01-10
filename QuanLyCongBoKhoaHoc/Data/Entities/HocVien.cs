//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class EHocVien
   {
	 public EHocVien()
	 {
	 }
	 private int _MaHocVien ;
	 private string _HoTen ;
	 private bool _GioiTinh ;
	 private DateTime _NgaySinh ;
	 private string _SoCMND ;
	

	 public int MaHocVien
	 {
	    get { return _MaHocVien ; }
	    set { _MaHocVien = value ; }
	 }
	 public string HoTen
	 {
	    get { return _HoTen ; }
	    set { _HoTen = value ; }
	 }
	 public bool GioiTinh
	 {
	    get { return _GioiTinh ; }
	    set { _GioiTinh = value ; }
	 }
	 public DateTime NgaySinh
	 {
	    get { return _NgaySinh ; }
	    set { _NgaySinh = value ; }
	 }
	
	 public string SoCMND
	 {
	    get { return _SoCMND ; }
	    set { _SoCMND = value ; }
	 }
	
   }
 }