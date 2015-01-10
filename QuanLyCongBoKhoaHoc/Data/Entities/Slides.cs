//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class ESlides
   {
	 public ESlides()
	 {
	 }
	 private int _MaSlide ;
	 private string _TieuDe ;
	 private string _MoTa ;
	 private string _Anh ;
	 private byte _ThuTu ;
 

	 public int MaSlide
	 {
	    get { return _MaSlide ; }
	    set { _MaSlide = value ; }
	 }
	 public string TieuDe
	 {
	    get { return _TieuDe ; }
	    set { _TieuDe = value ; }
	 }
	 public string MoTa
	 {
	    get { return _MoTa ; }
	    set { _MoTa = value ; }
	 }
	 public string Anh
	 {
	    get { return _Anh ; }
	    set { _Anh = value ; }
	 }
	 public byte ThuTu
	 {
	    get { return _ThuTu ; }
	    set { _ThuTu = value ; }
	 }
   }
 }