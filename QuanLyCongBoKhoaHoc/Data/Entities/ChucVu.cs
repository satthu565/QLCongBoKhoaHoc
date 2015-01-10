//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class EChucVu
   {
	 public EChucVu()
	 {
	 }
	 private int _MaChucVu ;
	 private string _TenChucVu ;
 

	 public int MaChucVu
	 {
	    get { return _MaChucVu ; }
	    set { _MaChucVu = value ; }
	 }
	 public string TenChucVu
	 {
	    get { return _TenChucVu ; }
	    set { _TenChucVu = value ; }
	 }
   }
 }