//DevNETCoder
//CopyRight By DevNET Group
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.DataAccess;
 
namespace QuanLyCongBoKhoaHoc .Business
{
    public class BSachXuatBan
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(ESachXuatBan OSachXuatBan)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"TenSach", OSachXuatBan.TenSach);
            pr[1] = new SqlParameter(@"NamHoanThanh", OSachXuatBan.NamHoanThanh);
            pr[2] = new SqlParameter(@"NhaXuatBan", OSachXuatBan.NhaXuatBan);
            pr[3] = new SqlParameter(@"MaGiangVien", OSachXuatBan.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"SachXuatBan_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(ESachXuatBan OSachXuatBan)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"MaSachXuatBan", OSachXuatBan.MaSachXuatBan);
            pr[1] = new SqlParameter(@"TenSach", OSachXuatBan.TenSach);
            pr[2] = new SqlParameter(@"NamHoanThanh", OSachXuatBan.NamHoanThanh);
            pr[3] = new SqlParameter(@"NhaXuatBan", OSachXuatBan.NhaXuatBan);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"SachXuatBan_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaSachXuatBan)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaSachXuatBan",MaSachXuatBan);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SachXuatBan_Delete", pr);
        }
//-----------------------------------------------------------//
        public static ESachXuatBan SelectByID(int MaSachXuatBan)
        {
            ESachXuatBan OSachXuatBan = new ESachXuatBan();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaSachXuatBan",MaSachXuatBan);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"SachXuatBan_SelectByID", pr);
            if (idr.Read())
              OSachXuatBan = GetOneSachXuatBan(idr);
            idr.Close();
            idr.Dispose();
            return OSachXuatBan;
        }
//-----------------------------------------------------------//
        private static ESachXuatBan GetOneSachXuatBan(IDataReader idr)
       {
            ESachXuatBan OSachXuatBan = new ESachXuatBan();
                if (idr["MaSachXuatBan"] != DBNull.Value)
                    OSachXuatBan.MaSachXuatBan = (int)idr["MaSachXuatBan"];
                if (idr["TenSach"] != DBNull.Value)
                    OSachXuatBan.TenSach = (string)idr["TenSach"];
                if (idr["NamHoanThanh"] != DBNull.Value)
                    OSachXuatBan.NamHoanThanh = (DateTime)idr["NamHoanThanh"];
                if (idr["NhaXuatBan"] != DBNull.Value)
                    OSachXuatBan.NhaXuatBan = (string)idr["NhaXuatBan"];
                if (idr["MaGiangVien"] != DBNull.Value)
                    OSachXuatBan.MaGiangVien = (int)idr["MaGiangVien"];
            return OSachXuatBan;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaSachXuatBan)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaSachXuatBan",MaSachXuatBan);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"SachXuatBan_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<ESachXuatBan> ListAll()
        {
            List<ESachXuatBan> list = new List<ESachXuatBan>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "SachXuatBan_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneSachXuatBan(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<ESachXuatBan> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<ESachXuatBan> list = new List<ESachXuatBan>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "SachXuatBan_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneSachXuatBan(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        //

        public static DataTable SelectByMaGiangVien(int MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_SelectByMaGiangVien", pr);
            return all;
        }

        public static DataTable SelectThongKeSachXuatBan_GiangVien()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_GiangVienThongKe", null);
            return all;
        }


        //
        public static DataTable TimKiemByTenSach(string TenSach)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenSach", TenSach);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_TimKiemByTenSach", pr);
            return all;
        }

        public static DataTable SachXuatBan_GiangVien()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_GiangVien_Select", null);
            return all;
        }


        public static DataTable TimKiemByNamXuatBan(int NamXuatBan)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"NamXuatBan", NamXuatBan);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_TimKiemByNamXuatBan", pr);
            return all;
        }

        public static DataTable TimKiemByNhaXuatBan(string NhaXuatBan)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"NhaXuatBan", NhaXuatBan);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_TimKiemByNhaXuatBan", pr);
            return all;
        }

        public static DataTable TimKiemByNhaXuatBanVaNamXuatBan(string NhaXuatBan, int NamXuatBan)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"NhaXuatBan", NhaXuatBan);
            pr[1] = new SqlParameter(@"NamXuatBan", NamXuatBan);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SachXuatBan_TimKiemByNhaXuatBanVaNamXuatBan", pr);
            return all;
        }


        public static int DemSachTheoMaGiangVien(int MaGiangVien)
        {
            int SoLuong = 0;
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "SachXuatBan_DemTheoMaGiangVien", pr);
            if (idr.Read())
                SoLuong = int.Parse(idr["SoLuong"].ToString());
            idr.Close();
            idr.Dispose();
            return SoLuong;
        }

        public static int DemTheoMaGiangVienVaNamHoanThanh(int MaGiangVien, int TuNamHoanThanh, int DenNamHoanThanh)
        {
            int SoLuong = 0;
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            pr[1] = new SqlParameter(@"TuNamHoanThanh", TuNamHoanThanh);
            pr[2] = new SqlParameter(@"DenNamHoanThanh", DenNamHoanThanh);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "SachXuatBan_DemTheoMaGiangVienVaNamHoanThanh", pr);
            if (idr.Read())
                SoLuong = int.Parse(idr["SoLuong"].ToString());
            idr.Close();
            idr.Dispose();
            return SoLuong;
        }

    }
 
}