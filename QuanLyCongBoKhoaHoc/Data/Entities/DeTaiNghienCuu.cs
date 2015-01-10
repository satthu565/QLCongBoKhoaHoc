//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class EDeTaiNghienCuu
   {
	 public EDeTaiNghienCuu()
	 {
	 }
	 private int _MaDeTaiHuongNghienCuu ;
	 private string _TenDeTaiHuongNghienCuu ;
	 private string _GioiThieuDeTai ;
	 private DateTime _ThoiGianThucHien ;
	 private DateTime _ThoiGianKetThuc ;
	 private int _MaGiangVien ;
 

	 public int MaDeTaiHuongNghienCuu
	 {
	    get { return _MaDeTaiHuongNghienCuu ; }
	    set { _MaDeTaiHuongNghienCuu = value ; }
	 }
	 public string TenDeTaiHuongNghienCuu
	 {
	    get { return _TenDeTaiHuongNghienCuu ; }
	    set { _TenDeTaiHuongNghienCuu = value ; }
	 }
	 public string GioiThieuDeTai
	 {
	    get { return _GioiThieuDeTai ; }
	    set { _GioiThieuDeTai = value ; }
	 }
	 public DateTime ThoiGianThucHien
	 {
	    get { return _ThoiGianThucHien ; }
	    set { _ThoiGianThucHien = value ; }
	 }
	 public DateTime ThoiGianKetThuc
	 {
	    get { return _ThoiGianKetThuc ; }
	    set { _ThoiGianKetThuc = value ; }
	 }
	 public int MaGiangVien
	 {
	    get { return _MaGiangVien ; }
	    set { _MaGiangVien = value ; }
	 }
   }
 }