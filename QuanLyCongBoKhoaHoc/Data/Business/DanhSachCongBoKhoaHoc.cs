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
    public class BDanhSachCongBoKhoaHoc
    {
        //-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_SelectTop", pr);
            return all;
        }
        //-----------------------------------------------------------//
        public static void Insert(EDanhSachCongBoKhoaHoc ODanhSachCongBoKhoaHoc)
        {
            SqlParameter[] pr = new SqlParameter[10];
            pr[0] = new SqlParameter(@"MaCapDeTai", ODanhSachCongBoKhoaHoc.MaCapDeTai);
            pr[1] = new SqlParameter(@"TenCongTrinh", ODanhSachCongBoKhoaHoc.TenCongTrinh);
            pr[2] = new SqlParameter(@"ChuoiMaGiangVienChuNhiem", ODanhSachCongBoKhoaHoc.ChuoiMaGiangVienChuNhiem);
            pr[3] = new SqlParameter(@"ChuoiMaThanhVienThamGia", ODanhSachCongBoKhoaHoc.ChuoiMaThanhVienThamGia);
            pr[4] = new SqlParameter(@"NoiCongBo", ODanhSachCongBoKhoaHoc.NoiCongBo);
            pr[5] = new SqlParameter(@"LinkFileMem", ODanhSachCongBoKhoaHoc.LinkFileMem);
            pr[6] = new SqlParameter(@"TenChuNhiemNgoai", ODanhSachCongBoKhoaHoc.TenChuNhiemNgoai);
            pr[7] = new SqlParameter(@"TenThanhVienNgoai", ODanhSachCongBoKhoaHoc.TenThanhVienNgoai);
            pr[8] = new SqlParameter(@"MaSo", ODanhSachCongBoKhoaHoc.MaSo);
            pr[9] = new SqlParameter(@"NamCongBo", ODanhSachCongBoKhoaHoc.NamCongBo);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_Insert", pr);
        }
        //-----------------------------------------------------------//
        public static void Update(EDanhSachCongBoKhoaHoc ODanhSachCongBoKhoaHoc)
        {
            SqlParameter[] pr = new SqlParameter[11];
            pr[0] = new SqlParameter(@"MaCongTrinhKhoaHoc", ODanhSachCongBoKhoaHoc.MaCongTrinhKhoaHoc);
            pr[1] = new SqlParameter(@"MaCapDeTai", ODanhSachCongBoKhoaHoc.MaCapDeTai);
            pr[2] = new SqlParameter(@"TenCongTrinh", ODanhSachCongBoKhoaHoc.TenCongTrinh);
            pr[3] = new SqlParameter(@"ChuoiMaGiangVienChuNhiem", ODanhSachCongBoKhoaHoc.ChuoiMaGiangVienChuNhiem);
            pr[4] = new SqlParameter(@"ChuoiMaThanhVienThamGia", ODanhSachCongBoKhoaHoc.ChuoiMaThanhVienThamGia);
            pr[5] = new SqlParameter(@"NoiCongBo", ODanhSachCongBoKhoaHoc.NoiCongBo);
            pr[6] = new SqlParameter(@"LinkFileMem", ODanhSachCongBoKhoaHoc.LinkFileMem);
            pr[7] = new SqlParameter(@"TenChuNhiemNgoai", ODanhSachCongBoKhoaHoc.TenChuNhiemNgoai);
            pr[8] = new SqlParameter(@"TenThanhVienNgoai", ODanhSachCongBoKhoaHoc.TenThanhVienNgoai);
            pr[9] = new SqlParameter(@"MaSo", ODanhSachCongBoKhoaHoc.MaSo);
            pr[10] = new SqlParameter(@"NamCongBo", ODanhSachCongBoKhoaHoc.NamCongBo);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_Update", pr);
        }
        //-----------------------------------------------------------//
        public static void Delete(int MaCongTrinhKhoaHoc)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaCongTrinhKhoaHoc", MaCongTrinhKhoaHoc);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_Delete", pr);
        }
        //-----------------------------------------------------------//
        public static EDanhSachCongBoKhoaHoc SelectByID(int MaCongTrinhKhoaHoc)
        {
            EDanhSachCongBoKhoaHoc ODanhSachCongBoKhoaHoc = new EDanhSachCongBoKhoaHoc();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaCongTrinhKhoaHoc", MaCongTrinhKhoaHoc);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_SelectByID", pr);
            if (idr.Read())
                ODanhSachCongBoKhoaHoc = GetOneDanhSachCongBoKhoaHoc(idr);
            idr.Close();
            idr.Dispose();
            return ODanhSachCongBoKhoaHoc;
        }
        //-----------------------------------------------------------//
        private static EDanhSachCongBoKhoaHoc GetOneDanhSachCongBoKhoaHoc(IDataReader idr)
        {
            EDanhSachCongBoKhoaHoc ODanhSachCongBoKhoaHoc = new EDanhSachCongBoKhoaHoc();
            if (idr["MaCongTrinhKhoaHoc"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.MaCongTrinhKhoaHoc = (int)idr["MaCongTrinhKhoaHoc"];
            if (idr["MaCapDeTai"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.MaCapDeTai = (int)idr["MaCapDeTai"];
            if (idr["TenCongTrinh"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.TenCongTrinh = (string)idr["TenCongTrinh"];
            if (idr["ChuoiMaGiangVienChuNhiem"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.ChuoiMaGiangVienChuNhiem = (string)idr["ChuoiMaGiangVienChuNhiem"];
            if (idr["ChuoiMaThanhVienThamGia"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.ChuoiMaThanhVienThamGia = (string)idr["ChuoiMaThanhVienThamGia"];
            if (idr["NoiCongBo"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.NoiCongBo = (string)idr["NoiCongBo"];
            if (idr["LinkFileMem"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.LinkFileMem = (string)idr["LinkFileMem"];
            if (idr["TenChuNhiemNgoai"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.TenChuNhiemNgoai = (string)idr["TenChuNhiemNgoai"];
            if (idr["TenThanhVienNgoai"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.TenThanhVienNgoai = (string)idr["TenThanhVienNgoai"];
            if (idr["MaSo"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.MaSo = (string)idr["MaSo"];
            if (idr["NamCongBo"] != DBNull.Value)
                ODanhSachCongBoKhoaHoc.NamCongBo = (DateTime)idr["NamCongBo"];
            return ODanhSachCongBoKhoaHoc;
        }
        //-----------------------------------------------------------//
        public static bool TestByID(int MaCongTrinhKhoaHoc)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaCongTrinhKhoaHoc", MaCongTrinhKhoaHoc);
            pr[1] = new SqlParameter(@"TestID", SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
        //-----------------------------------------------------------//
        public static List<EDanhSachCongBoKhoaHoc> ListAll()
        {
            List<EDanhSachCongBoKhoaHoc> list = new List<EDanhSachCongBoKhoaHoc>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneDanhSachCongBoKhoaHoc(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        public static List<EDanhSachCongBoKhoaHoc> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EDanhSachCongBoKhoaHoc> list = new List<EDanhSachCongBoKhoaHoc>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_SelectAll", pr);
            while (idr.Read())
                list.Add(GetOneDanhSachCongBoKhoaHoc(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }


        // select theo mã giảng viên dựa theo 2 cột , người chủ nhiệm , thành viên

        public static DataTable SelectMaGiangVien2Cot(string MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_SelectByMaHaiCotGiangVien", pr);
            return all;
        }

        public static DataTable SelectCountByMaGiangVien(string MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_CountByMaGianVien", pr);
            return all;
        }

        public static int CountByMaGianVienVaCapDeTai(string MaGiangVien, int CapDeTai)
        {
            int SoLuong = 0;
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            pr[1] = new SqlParameter(@"CapDeTai", CapDeTai);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_CountByMaGianVienVaCapDeTai", pr);
            if (idr.Read())
                SoLuong = int.Parse(idr["SoLuong"].ToString());
            idr.Close();
            idr.Dispose();
            return SoLuong;
        }

        public static int CountByMaGianVienVaCapDeTaiVaNamCongBo(string MaGiangVien, int CapDeTai, int TuNamCongBo, int DenNamCongBo)
        {
            int SoLuong = 0;
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            pr[1] = new SqlParameter(@"CapDeTai", CapDeTai);
            pr[2] = new SqlParameter(@"TuNamCongBo", TuNamCongBo);
            pr[3] = new SqlParameter(@"DenNamCongBo", DenNamCongBo);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_CountByMaGianVienVaCapDeTaiVaNamCongBo", pr);
            if (idr.Read())
                SoLuong = int.Parse(idr["SoLuong"].ToString());
            idr.Close();
            idr.Dispose();
            return SoLuong;
        }



        public static DataTable SelectByTenCongTrinh(string TenCongTrinh)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenCongTrinh", TenCongTrinh);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_HienThiTimKiemTheoTenCongTrinh", pr);
            return all;
        }

        public static DataTable LietKeByMaCapDeTai(int MaCapDeTai)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaCapDeTai", MaCapDeTai);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_LietKeByMaCapDeTai", pr);
            return all;
        }

        public static DataTable LietKe()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_LietKe", null);
            return all;
        }

        public static DataTable LietKeByMaCapDeTaiVaNamCongBo(int MaCapDeTai, int NamCongBo)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaCapDeTai", MaCapDeTai);
            pr[1] = new SqlParameter(@"NamCongBo", NamCongBo);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_LietKeByMaCapDeTaiVaNamCongBo", pr);
            return all;
        }

        public static DataTable LietKeByNamCongBo(int NamCongBo)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"NamCongBo", NamCongBo);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhSachCongBoKhoaHoc_LietKeByNamCongBo", pr);
            return all;
        }

    }
 
}