using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.DataAccess;

namespace QuanLyCongBoKhoaHoc.Business
{
    public class BBaiBao
    {
        //-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_SelectTop", pr);
            return all;
        }
        //-----------------------------------------------------------//
        public static void Insert(EBaiBao OBaiBao)
        {
            SqlParameter[] pr = new SqlParameter[10];
            pr[0] = new SqlParameter(@"TenBaiBao", OBaiBao.TenBaiBao);
            pr[1] = new SqlParameter(@"ThoiGianXuatBan", OBaiBao.ThoiGianXuatBan);
            pr[2] = new SqlParameter(@"NoiCongBo", OBaiBao.NoiCongBo);
            pr[3] = new SqlParameter(@"GioiHan", OBaiBao.GioiHan);
            pr[4] = new SqlParameter(@"ChuoiMaGiangVienTacGia", OBaiBao.ChuoiMaGiangVienTacGia);
            pr[5] = new SqlParameter(@"TenTacGiaNgoai", OBaiBao.TenTacGiaNgoai);
            pr[6] = new SqlParameter(@"MaSo", OBaiBao.MaSo);
            pr[7] = new SqlParameter(@"NoiDungTomTat", OBaiBao.NoiDungTomTat);
            pr[8] = new SqlParameter(@"FileMem", OBaiBao.FileMem);
            pr[9] = new SqlParameter(@"NoiXuatBan", OBaiBao.NoiXuatBan);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "BaiBao_Insert", pr);
        }
        //-----------------------------------------------------------//
        public static void Update(EBaiBao OBaiBao)
        {
            SqlParameter[] pr = new SqlParameter[11];
            pr[0] = new SqlParameter(@"MaBaiBao", OBaiBao.MaBaiBao);
            pr[1] = new SqlParameter(@"TenBaiBao", OBaiBao.TenBaiBao);
            pr[2] = new SqlParameter(@"ThoiGianXuatBan", OBaiBao.ThoiGianXuatBan);
            pr[3] = new SqlParameter(@"NoiCongBo", OBaiBao.NoiCongBo);
            pr[4] = new SqlParameter(@"GioiHan", OBaiBao.GioiHan);
            pr[5] = new SqlParameter(@"ChuoiMaGiangVienTacGia", OBaiBao.ChuoiMaGiangVienTacGia);
            pr[6] = new SqlParameter(@"TenTacGiaNgoai", OBaiBao.TenTacGiaNgoai);
            pr[7] = new SqlParameter(@"MaSo", OBaiBao.MaSo);
            pr[8] = new SqlParameter(@"NoiDungTomTat", OBaiBao.NoiDungTomTat);
            pr[9] = new SqlParameter(@"FileMem", OBaiBao.FileMem);
            pr[10] = new SqlParameter(@"NoiXuatBan", OBaiBao.NoiXuatBan);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "BaiBao_Update", pr);
        }
        //-----------------------------------------------------------//
        public static void Delete(int MaBaiBao)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaBaiBao", MaBaiBao);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "BaiBao_Delete", pr);
        }
        //-----------------------------------------------------------//
        public static EBaiBao SelectByID(int MaBaiBao)
        {
            EBaiBao OBaiBao = new EBaiBao();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaBaiBao", MaBaiBao);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "BaiBao_SelectByID", pr);
            if (idr.Read())
                OBaiBao = GetOneBaiBao(idr);
            idr.Close();
            idr.Dispose();
            return OBaiBao;
        }
        //-----------------------------------------------------------//
        private static EBaiBao GetOneBaiBao(IDataReader idr)
        {
            EBaiBao OBaiBao = new EBaiBao();
            if (idr["MaBaiBao"] != DBNull.Value)
                OBaiBao.MaBaiBao = (int)idr["MaBaiBao"];
            if (idr["TenBaiBao"] != DBNull.Value)
                OBaiBao.TenBaiBao = (string)idr["TenBaiBao"];
            if (idr["ThoiGianXuatBan"] != DBNull.Value)
                OBaiBao.ThoiGianXuatBan = (DateTime)idr["ThoiGianXuatBan"];
            if (idr["NoiCongBo"] != DBNull.Value)
                OBaiBao.NoiCongBo = (string)idr["NoiCongBo"];
            if (idr["GioiHan"] != DBNull.Value)
                OBaiBao.GioiHan = (bool)idr["GioiHan"];
            if (idr["ChuoiMaGiangVienTacGia"] != DBNull.Value)
                OBaiBao.ChuoiMaGiangVienTacGia = (string)idr["ChuoiMaGiangVienTacGia"];
            if (idr["TenTacGiaNgoai"] != DBNull.Value)
                OBaiBao.TenTacGiaNgoai = (string)idr["TenTacGiaNgoai"];
            if (idr["MaSo"] != DBNull.Value)
                OBaiBao.MaSo = (string)idr["MaSo"];
            if (idr["NoiDungTomTat"] != DBNull.Value)
                OBaiBao.NoiDungTomTat = (string)idr["NoiDungTomTat"];
            if (idr["FileMem"] != DBNull.Value)
                OBaiBao.FileMem = (string)idr["FileMem"];
            if (idr["NoiXuatBan"] != DBNull.Value)
                OBaiBao.NoiXuatBan = (string)idr["NoiXuatBan"];
            return OBaiBao;
        }
        //-----------------------------------------------------------//
        public static bool TestByID(int MaBaiBao)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaBaiBao", MaBaiBao);
            pr[1] = new SqlParameter(@"TestID", SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "BaiBao_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
        //-----------------------------------------------------------//
        public static List<EBaiBao> ListAll()
        {
            List<EBaiBao> list = new List<EBaiBao>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "BaiBao_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneBaiBao(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        public static List<EBaiBao> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EBaiBao> list = new List<EBaiBao>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "BaiBao_SelectAll", pr);
            while (idr.Read())
                list.Add(GetOneBaiBao(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }


        // Hàm lấy toàn bộ like Mã chuỗi Tác giả

        public static DataTable SelectByChuoiMaTacGia(string MaGiangVienTrongChuoi)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVienTrongChuoi", MaGiangVienTrongChuoi);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_SelectByChuoiMaGiangVien", pr);
            return all;
        }


      

        
        public static DataTable SelectByGioiHan(bool GioiHan)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"GioiHan", GioiHan);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_SelectByGioiHan", pr);
            return all;
        }

        public static DataTable SelectTimKiemByTenBaiBao(string TenBaiBao)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenBaiBao", TenBaiBao);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_HienThiTimKiemTheoTenBao", pr);
            return all;
        }

      


        public static DataTable SelectCountByMaGiangVien(string MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_CountByMaGianVien", pr);
            return all;
        }


        public static int CountByMaGianVienVaGioiHan(string MaGiangVien, int GioiHan)
        {
            int SoLuong = 0;
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            pr[1] = new SqlParameter(@"GioiHan", GioiHan);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "BaiBao_CountByMaGianVienVaGioiHan", pr);
            if (idr.Read())
                SoLuong = int.Parse(idr["SoLuong"].ToString());
            idr.Close();
            idr.Dispose();
            return SoLuong;
        }


        public static int CountByMaGianVienVaGioiHanVaNamXuatBan(string MaGiangVien, int GioiHan, int TuNamXuatBan, int DenNamXuatBan)
        {
            int SoLuong = 0;
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            pr[1] = new SqlParameter(@"GioiHan", GioiHan);
            pr[2] = new SqlParameter(@"TuNamXuatBan", TuNamXuatBan);
            pr[3] = new SqlParameter(@"DenNamXuatBan", DenNamXuatBan);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "BaiBao_CountByMaGianVienVaGioiHanVaNamXuatBan", pr);
            if (idr.Read())
                SoLuong = int.Parse(idr["SoLuong"].ToString());
            idr.Close();
            idr.Dispose();
            return SoLuong;
        }



      

        public static DataTable TimKiemTheoTenBaoVaGioiHan(string TenBaiBao, bool GioiHan)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"TenBaiBao", TenBaiBao);
            pr[1] = new SqlParameter(@"GioiHan", GioiHan);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_TimKiemTheoTenBaVaGioiHan", pr);
            return all;
        }


        public static DataTable TimKiemTheoNamXuatBanVaGioiHan(int NamXuatBan, bool GioiHan)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"NamXuatBan", NamXuatBan);
            pr[1] = new SqlParameter(@"GioiHan", GioiHan);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_TimKiemTheoNamXuatBanVaGioiHan", pr);
            return all;
        }

        public static DataTable TimKiemTheoNamXuatBanVaGioiHanVaTenBaiBao(int NamXuatBan, bool GioiHan, string TenBaiBao)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"NamXuatBan", NamXuatBan);
            pr[1] = new SqlParameter(@"GioiHan", GioiHan);
            pr[2] = new SqlParameter(@"TenBaiBao", TenBaiBao);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "BaiBao_TimKiemTheoNamXuatBanVaGioiHanVaTenBaiBao", pr);
            return all;
        }


    }
}