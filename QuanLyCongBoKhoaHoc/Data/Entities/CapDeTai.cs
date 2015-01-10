//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class ECapDeTai
   {
	 public ECapDeTai()
	 {
	 }
	 private int _MaCapDeTai ;
	 private string _TenCapDeTai ;
 

	 public int MaCapDeTai
	 {
	    get { return _MaCapDeTai ; }
	    set { _MaCapDeTai = value ; }
	 }
	 public string TenCapDeTai
	 {
	    get { return _TenCapDeTai ; }
	    set { _TenCapDeTai = value ; }
	 }
   }
 }