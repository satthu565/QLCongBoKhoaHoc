//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class EHocVi
   {
	 public EHocVi()
	 {
	 }
	 private int _MaHocVi ;
	 private string _TenHocVi ;
 

	 public int MaHocVi
	 {
	    get { return _MaHocVi ; }
	    set { _MaHocVi = value ; }
	 }
	 public string TenHocVi
	 {
	    get { return _TenHocVi ; }
	    set { _TenHocVi = value ; }
	 }
   }
 }