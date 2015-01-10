//DevNETCoder
//CopyRight By DevNET Group
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.DataAccess;

namespace QuanLyCongBoKhoaHoc.Business
{
    public class BGiangVien
    {
        //-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_SelectTop", pr);
            return all;
        }
        //-----------------------------------------------------------//
        public static void Insert(EGiangVien OGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[23];
            pr[0] = new SqlParameter(@"TenGiangVien", OGiangVien.TenGiangVien);
            pr[1] = new SqlParameter(@"GioiTinh", OGiangVien.GioiTinh);
            pr[2] = new SqlParameter(@"DanToc", OGiangVien.DanToc);
            pr[3] = new SqlParameter(@"NamSinh", OGiangVien.NamSinh);
            pr[4] = new SqlParameter(@"NoiSinh", OGiangVien.NoiSinh);
            pr[5] = new SqlParameter(@"QueQuan", OGiangVien.QueQuan);
            pr[6] = new SqlParameter(@"MaChucVu", OGiangVien.MaChucVu);
            pr[7] = new SqlParameter(@"MaHocVi", OGiangVien.MaHocVi);
            pr[8] = new SqlParameter(@"DayCN", OGiangVien.DayCN);
            pr[9] = new SqlParameter(@"LinhVucNC", OGiangVien.LinhVucNC);
            pr[10] = new SqlParameter(@"DienThoai", OGiangVien.DienThoai);
            pr[11] = new SqlParameter(@"Email", OGiangVien.Email);
            pr[12] = new SqlParameter(@"AnhDaiDien", OGiangVien.AnhDaiDien);
            pr[13] = new SqlParameter(@"MaKhoa", OGiangVien.MaKhoa);
            pr[14] = new SqlParameter(@"TenDangNhap", OGiangVien.TenDangNhap);
            pr[15] = new SqlParameter(@"MatKhau", OGiangVien.MatKhau);
            pr[16] = new SqlParameter(@"NamTotNghiepDaiHoc", OGiangVien.NamTotNghiepDaiHoc);
            pr[17] = new SqlParameter(@"TruongDaiHoc", OGiangVien.TruongDaiHoc);
            pr[18] = new SqlParameter(@"ChuyenNganhDaiHoc", OGiangVien.ChuyenNganhDaiHoc);
            pr[19] = new SqlParameter(@"NamTotNghiepHocVi", OGiangVien.NamTotNghiepHocVi);
            pr[20] = new SqlParameter(@"TruongHocVi", OGiangVien.TruongHocVi);
            pr[21] = new SqlParameter(@"ChuyenNganhHocVi", OGiangVien.ChuyenNganhHocVi);
            pr[22] = new SqlParameter(@"MaQuyen", OGiangVien.MaQuyen);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_Insert", pr);
        }
        //---------------------Sửa rồi--------------------------------------//
        public static void Update(EGiangVien OGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[15];
            pr[0] = new SqlParameter(@"MaGiangVien", OGiangVien.MaGiangVien);
            pr[1] = new SqlParameter(@"TenGiangVien", OGiangVien.TenGiangVien);
            pr[2] = new SqlParameter(@"GioiTinh", OGiangVien.GioiTinh);
            pr[3] = new SqlParameter(@"DanToc", OGiangVien.DanToc);
            pr[4] = new SqlParameter(@"NamSinh", OGiangVien.NamSinh);
            pr[5] = new SqlParameter(@"NoiSinh", OGiangVien.NoiSinh);
            pr[6] = new SqlParameter(@"QueQuan", OGiangVien.QueQuan);
            pr[7] = new SqlParameter(@"MaChucVu", OGiangVien.MaChucVu);
            pr[8] = new SqlParameter(@"MaHocVi", OGiangVien.MaHocVi);
            pr[9] = new SqlParameter(@"DayCN", OGiangVien.DayCN);
            pr[10] = new SqlParameter(@"LinhVucNC", OGiangVien.LinhVucNC);
            pr[11] = new SqlParameter(@"DienThoai", OGiangVien.DienThoai);
            pr[12] = new SqlParameter(@"Email", OGiangVien.Email);
            pr[13] = new SqlParameter(@"AnhDaiDien", OGiangVien.AnhDaiDien);
            pr[14] = new SqlParameter(@"MaKhoa", OGiangVien.MaKhoa);  
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_Update", pr);
        }
        //-----------------------------------------------------------//
        public static void Delete(int MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_Delete", pr);
        }
        //-----------------------------------------------------------//
        public static EGiangVien SelectByID(int MaGiangVien)
        {
            EGiangVien OGiangVien = new EGiangVien();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiangVien_SelectByID", pr);
            if (idr.Read())
                OGiangVien = GetOneGiangVien(idr);
            idr.Close();
            idr.Dispose();
            return OGiangVien;
        }
        //-----------------------------------------------------------//
        private static EGiangVien GetOneGiangVien(IDataReader idr)
        {
            EGiangVien OGiangVien = new EGiangVien();
            if (idr["MaGiangVien"] != DBNull.Value)
                OGiangVien.MaGiangVien = (int)idr["MaGiangVien"];
            if (idr["TenGiangVien"] != DBNull.Value)
                OGiangVien.TenGiangVien = (string)idr["TenGiangVien"];
            if (idr["GioiTinh"] != DBNull.Value)
                OGiangVien.GioiTinh = (bool)idr["GioiTinh"];
            if (idr["DanToc"] != DBNull.Value)
                OGiangVien.DanToc = (string)idr["DanToc"];
            if (idr["NamSinh"] != DBNull.Value)
                OGiangVien.NamSinh = (DateTime)idr["NamSinh"];
            if (idr["NoiSinh"] != DBNull.Value)
                OGiangVien.NoiSinh = (string)idr["NoiSinh"];
            if (idr["QueQuan"] != DBNull.Value)
                OGiangVien.QueQuan = (string)idr["QueQuan"];
            if (idr["MaChucVu"] != DBNull.Value)
                OGiangVien.MaChucVu = (int)idr["MaChucVu"];
            if (idr["MaHocVi"] != DBNull.Value)
                OGiangVien.MaHocVi = (int)idr["MaHocVi"];
            if (idr["DayCN"] != DBNull.Value)
                OGiangVien.DayCN = (string)idr["DayCN"];
            if (idr["LinhVucNC"] != DBNull.Value)
                OGiangVien.LinhVucNC = (string)idr["LinhVucNC"];
            if (idr["DienThoai"] != DBNull.Value)
                OGiangVien.DienThoai = (string)idr["DienThoai"];
            if (idr["Email"] != DBNull.Value)
                OGiangVien.Email = (string)idr["Email"];
            if (idr["AnhDaiDien"] != DBNull.Value)
                OGiangVien.AnhDaiDien = (string)idr["AnhDaiDien"];
            if (idr["MaKhoa"] != DBNull.Value)
                OGiangVien.MaKhoa = (int)idr["MaKhoa"];
            if (idr["TenDangNhap"] != DBNull.Value)
                OGiangVien.TenDangNhap = (string)idr["TenDangNhap"];
            if (idr["MatKhau"] != DBNull.Value)
                OGiangVien.MatKhau = (string)idr["MatKhau"];
            if (idr["NamTotNghiepDaiHoc"] != DBNull.Value)
                OGiangVien.NamTotNghiepDaiHoc = (DateTime)idr["NamTotNghiepDaiHoc"];
            if (idr["TruongDaiHoc"] != DBNull.Value)
                OGiangVien.TruongDaiHoc = (string)idr["TruongDaiHoc"];
            if (idr["ChuyenNganhDaiHoc"] != DBNull.Value)
                OGiangVien.ChuyenNganhDaiHoc = (string)idr["ChuyenNganhDaiHoc"];
            if (idr["NamTotNghiepHocVi"] != DBNull.Value)
                OGiangVien.NamTotNghiepHocVi = (DateTime)idr["NamTotNghiepHocVi"];
            if (idr["TruongHocVi"] != DBNull.Value)
                OGiangVien.TruongHocVi = (string)idr["TruongHocVi"];
            if (idr["ChuyenNganhHocVi"] != DBNull.Value)
                OGiangVien.ChuyenNganhHocVi = (string)idr["ChuyenNganhHocVi"];
            if (idr["MaQuyen"] != DBNull.Value)
                OGiangVien.MaQuyen = (int)idr["MaQuyen"];
            return OGiangVien;
        }
        //-----------------------------------------------------------//
        public static bool TestByID(int MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            pr[1] = new SqlParameter(@"TestID", SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
        //-----------------------------------------------------------//
        public static List<EGiangVien> ListAll()
        {
            List<EGiangVien> list = new List<EGiangVien>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiangVien_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneGiangVien(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        public static List<EGiangVien> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EGiangVien> list = new List<EGiangVien>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiangVien_SelectAll", pr);
            while (idr.Read())
                list.Add(GetOneGiangVien(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        // tự viết
        public static List<EGiangVien> GetByTop(string Top, string Where, string Order)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"Top", Top);
            pr[1] = new SqlParameter(@"Where", Where);
            pr[2] = new SqlParameter(@"Order", Order);
            List<EGiangVien> list = new List<EGiangVien>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiangVien_GetByTop", pr);
            while (idr.Read())
                list.Add(GetOneGiangVien(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }


        public static List<EGiangVien> Paging(int CurentPage, int PageSize, string Where, string Order)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"CurentPage", CurentPage);
            pr[1] = new SqlParameter(@"PageSize", PageSize);
            pr[2] = new SqlParameter(@"Where", Where);
            pr[3] = new SqlParameter(@"Order", Order);
            List<EGiangVien> list = new List<EGiangVien>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiangVien_Paging", pr);
            while (idr.Read())
                list.Add(GetOneGiangVien(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
       

        public static DataTable SelectLyLichByMaGiangVien(int MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_SelectLyLichByID", pr);
            return all;
        }



        public static DataTable SelectByMaHocVi(int MaHocVi)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaHocVi", MaHocVi);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_SelectByMaHocVi", pr);
            return all;
        }
        //

        public static DataTable SelectTimKiemByTenGiangVien(string TenGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenGiangVien", TenGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_HienThiTimKiemTheoTen", pr);
            return all;
        }

        public static DataTable SelectTimKiemByTenGiangVienLoaiMaGiangVien(string TenGiangVien,int MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"TenGiangVien", TenGiangVien);
            pr[1] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_HienThiTimKiemTheoTenVaLoaiTruMaGiangVien", pr);
            return all;
        }

        

        //
        public static DataTable SelectTimKiemByMaKhoaVaTenGiangVien(string TenGiangVien,int MaKhoa)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"TenGiangVien", TenGiangVien);
            pr[1] = new SqlParameter(@"MaKhoa", MaKhoa);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_TimKiemByMaKhoaVaTenGiangVien", pr);
            return all;
        }

        public static List<EGiangVien> ListTimKiemByTenGiangVien(string TenGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenGiangVien", TenGiangVien);
            List<EGiangVien> list = new List<EGiangVien>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiangVien_HienThiTimKiemTheoTen", pr);
            while (idr.Read())
                list.Add(GetOneGiangVien(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }


        public static EGiangVien DangNhap(string TenDangNhap , string MatKhau)
        {
            EGiangVien OGiangVien = new EGiangVien();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"TenDangNhap", TenDangNhap);
            pr[1] = new SqlParameter(@"MatKhau", MatKhau);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiangVien_DangNhap", pr);
            if (idr.Read())
                OGiangVien = GetOneGiangVien(idr);
            idr.Close();
            idr.Dispose();
            return OGiangVien;
        }

        public static void UpdateHoc(EGiangVien OGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter(@"NamTotNghiepDaiHoc", OGiangVien.NamTotNghiepDaiHoc);
            pr[1] = new SqlParameter(@"TruongDaiHoc", OGiangVien.TruongDaiHoc);
            pr[2] = new SqlParameter(@"ChuyenNganhDaiHoc", OGiangVien.ChuyenNganhDaiHoc);
            pr[3] = new SqlParameter(@"NamTotNghiepHocVi", OGiangVien.NamTotNghiepHocVi);
            pr[4] = new SqlParameter(@"TruongHocVi", OGiangVien.TruongHocVi);
            pr[5] = new SqlParameter(@"ChuyenNganhHocVi", OGiangVien.ChuyenNganhHocVi);
            pr[6] = new SqlParameter(@"MaGiangVien", OGiangVien.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_UpdateHoc", pr);
        }
        
         public static DataTable SelectToanBoThongTin()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_SelectThongTin_All", null);
            return all;
        }



         public static void ADUpdateQuyen(EGiangVien OGiangVien)
         {
             SqlParameter[] pr = new SqlParameter[2];
             pr[0] = new SqlParameter(@"MaGiangVien", OGiangVien.MaGiangVien);
             pr[1] = new SqlParameter(@"MaQuyen", OGiangVien.MaQuyen);
             SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_UpdateQuyen", pr);
         }


         public static DataTable AdTimKiemGiangVienTheoTen(string TenGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenGiangVien", TenGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_TimKiemThongTin_All_ByTenGiangVien", pr);
            return all;
        }

         public static void UpdateMatKhau(EGiangVien OGiangVien)
         {
             SqlParameter[] pr = new SqlParameter[2];
             pr[0] = new SqlParameter(@"MaGiangVien", OGiangVien.MaGiangVien);
             pr[1] = new SqlParameter(@"MatKhau", OGiangVien.MatKhau);
             SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_UpdateMatKhau", pr);
         }

         public static void UpdateMatKhauByTenDangNhap(EGiangVien OGiangVien)
         {
             SqlParameter[] pr = new SqlParameter[2];
             pr[0] = new SqlParameter(@"TenDangNhap", OGiangVien.TenDangNhap);
             pr[1] = new SqlParameter(@"MatKhau", OGiangVien.MatKhau);
             SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_UpdateMatKhauByTenDangNhap", pr);
         }

        

         public static void DangKyGiangVien(EGiangVien OGiangVien)
         {
             SqlParameter[] pr = new SqlParameter[6];
             pr[0] = new SqlParameter(@"TenGiangVien", OGiangVien.TenGiangVien);
             pr[1] = new SqlParameter(@"GioiTinh", OGiangVien.GioiTinh);
             pr[2] = new SqlParameter(@"AnhDaiDien", OGiangVien.AnhDaiDien);
             pr[3] = new SqlParameter(@"TenDangNhap", OGiangVien.TenDangNhap);
             pr[4] = new SqlParameter(@"MatKhau", OGiangVien.MatKhau);
             pr[5] = new SqlParameter(@"MaQuyen", OGiangVien.MaQuyen);
             SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiangVien_DangKy", pr);
         }

         public static DataTable LayTenDangNhapbyEmail(string Email)
         {
             SqlParameter[] pr = new SqlParameter[1];
             pr[0] = new SqlParameter(@"Email", Email);
             DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_LayTenDangNhapbyEmail", pr);
             return all;
         }

    }
}