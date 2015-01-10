//DevNETCoder  
//CopyRight By DevNET Group
 using System;
 using System.Text;

namespace QuanLyCongBoKhoaHoc.Entities 
{
   public class ESachXuatBan
   {
	 public ESachXuatBan()
	 {
	 }
	 private int _MaSachXuatBan ;
	 private string _TenSach ;
	 private DateTime _NamHoanThanh ;
	 private string _NhaXuatBan ;
	 private int _MaGiangVien ;
 

	 public int MaSachXuatBan
	 {
	    get { return _MaSachXuatBan ; }
	    set { _MaSachXuatBan = value ; }
	 }
	 public string TenSach
	 {
	    get { return _TenSach ; }
	    set { _TenSach = value ; }
	 }
	 public DateTime NamHoanThanh
	 {
	    get { return _NamHoanThanh ; }
	    set { _NamHoanThanh = value ; }
	 }
	 public string NhaXuatBan
	 {
	    get { return _NhaXuatBan ; }
	    set { _NhaXuatBan = value ; }
	 }
	 public int MaGiangVien
	 {
	    get { return _MaGiangVien ; }
	    set { _MaGiangVien = value ; }
	 }
   }
 }