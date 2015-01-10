//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class EHocVienVaDeTaiNghienCuu
   {
	 public EHocVienVaDeTaiNghienCuu()
	 {
	 }
	 private int _MaDangKy ;
	 private int _MaHocVien ;
	 private int _MaDeTaiHuongNghienCuu ;
	 private bool _TrangThai ;
	 private int _MaGiangVien ;
 

	 public int MaDangKy
	 {
	    get { return _MaDangKy ; }
	    set { _MaDangKy = value ; }
	 }
	 public int MaHocVien
	 {
	    get { return _MaHocVien ; }
	    set { _MaHocVien = value ; }
	 }
	 public int MaDeTaiHuongNghienCuu
	 {
	    get { return _MaDeTaiHuongNghienCuu ; }
	    set { _MaDeTaiHuongNghienCuu = value ; }
	 }
	 public bool TrangThai
	 {
	    get { return _TrangThai ; }
	    set { _TrangThai = value ; }
	 }
	 public int MaGiangVien
	 {
	    get { return _MaGiangVien ; }
	    set { _MaGiangVien = value ; }
	 }
   }
 }