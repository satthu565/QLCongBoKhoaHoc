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
    public class BSauDaiHoc
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SauDaiHoc_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SauDaiHoc_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(ESauDaiHoc OSauDaiHoc)
        {
            SqlParameter[] pr = new SqlParameter[9];
            pr[0] = new SqlParameter(@"MaHocVien", OSauDaiHoc.MaHocVien);
            pr[1] = new SqlParameter(@"NoiDaoTao", OSauDaiHoc.NoiDaoTao);
            pr[2] = new SqlParameter(@"ThoiGianDaoTao", OSauDaiHoc.ThoiGianDaoTao);
            pr[3] = new SqlParameter(@"ThoiGianBatDau", OSauDaiHoc.ThoiGianBatDau);
            pr[4] = new SqlParameter(@"ThoiGianBaoVe", OSauDaiHoc.ThoiGianBaoVe);
            pr[5] = new SqlParameter(@"TenDeTai", OSauDaiHoc.TenDeTai);
            pr[6] = new SqlParameter(@"LoaiDaoTao", OSauDaiHoc.LoaiDaoTao);
            pr[7] = new SqlParameter(@"MaGiangVien", OSauDaiHoc.MaGiangVien);
            pr[8] = new SqlParameter(@"TrangThai", OSauDaiHoc.TrangThai);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"SauDaiHoc_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(ESauDaiHoc OSauDaiHoc)
        {
            SqlParameter[] pr = new SqlParameter[10];
            pr[0] = new SqlParameter(@"MaSauDaiHoc", OSauDaiHoc.MaSauDaiHoc);
            pr[1] = new SqlParameter(@"MaHocVien", OSauDaiHoc.MaHocVien);
            pr[2] = new SqlParameter(@"NoiDaoTao", OSauDaiHoc.NoiDaoTao);
            pr[3] = new SqlParameter(@"ThoiGianDaoTao", OSauDaiHoc.ThoiGianDaoTao);
            pr[4] = new SqlParameter(@"ThoiGianBatDau", OSauDaiHoc.ThoiGianBatDau);
            pr[5] = new SqlParameter(@"ThoiGianBaoVe", OSauDaiHoc.ThoiGianBaoVe);
            pr[6] = new SqlParameter(@"TenDeTai", OSauDaiHoc.TenDeTai);
            pr[7] = new SqlParameter(@"LoaiDaoTao", OSauDaiHoc.LoaiDaoTao);
            pr[8] = new SqlParameter(@"MaGiangVien", OSauDaiHoc.MaGiangVien);
            pr[9] = new SqlParameter(@"TrangThai", OSauDaiHoc.TrangThai);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"SauDaiHoc_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaSauDaiHoc)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaSauDaiHoc",MaSauDaiHoc);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SauDaiHoc_Delete", pr);
        }
//-----------------------------------------------------------//
        public static ESauDaiHoc SelectByID(int MaSauDaiHoc)
        {
            ESauDaiHoc OSauDaiHoc = new ESauDaiHoc();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaSauDaiHoc",MaSauDaiHoc);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"SauDaiHoc_SelectByID", pr);
            if (idr.Read())
              OSauDaiHoc = GetOneSauDaiHoc(idr);
            idr.Close();
            idr.Dispose();
            return OSauDaiHoc;
        }
//-----------------------------------------------------------//
        private static ESauDaiHoc GetOneSauDaiHoc(IDataReader idr)
       {
            ESauDaiHoc OSauDaiHoc = new ESauDaiHoc();
                if (idr["MaSauDaiHoc"] != DBNull.Value)
                    OSauDaiHoc.MaSauDaiHoc = (int)idr["MaSauDaiHoc"];
                if (idr["MaHocVien"] != DBNull.Value)
                    OSauDaiHoc.MaHocVien = (int)idr["MaHocVien"];
                if (idr["NoiDaoTao"] != DBNull.Value)
                    OSauDaiHoc.NoiDaoTao = (string)idr["NoiDaoTao"];
                if (idr["ThoiGianDaoTao"] != DBNull.Value)
                    OSauDaiHoc.ThoiGianDaoTao = (string)idr["ThoiGianDaoTao"];
                if (idr["ThoiGianBatDau"] != DBNull.Value)
                    OSauDaiHoc.ThoiGianBatDau = (DateTime)idr["ThoiGianBatDau"];
                if (idr["ThoiGianBaoVe"] != DBNull.Value)
                    OSauDaiHoc.ThoiGianBaoVe = (DateTime)idr["ThoiGianBaoVe"];
                if (idr["TenDeTai"] != DBNull.Value)
                    OSauDaiHoc.TenDeTai = (string)idr["TenDeTai"];
                if (idr["LoaiDaoTao"] != DBNull.Value)
                    OSauDaiHoc.LoaiDaoTao = (string)idr["LoaiDaoTao"];
                if (idr["MaGiangVien"] != DBNull.Value)
                    OSauDaiHoc.MaGiangVien = (int)idr["MaGiangVien"];
                if (idr["TrangThai"] != DBNull.Value)
                    OSauDaiHoc.TrangThai = (bool)idr["TrangThai"];
            return OSauDaiHoc;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaSauDaiHoc)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaSauDaiHoc",MaSauDaiHoc);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"SauDaiHoc_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<ESauDaiHoc> ListAll()
        {
            List<ESauDaiHoc> list = new List<ESauDaiHoc>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "SauDaiHoc_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneSauDaiHoc(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<ESauDaiHoc> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<ESauDaiHoc> list = new List<ESauDaiHoc>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "SauDaiHoc_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneSauDaiHoc(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static DataTable SauDaiHoc_HocVien_SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SauDaiHoc_HocVien_SelectAll", null);
            return all;
        }


        public static DataTable SelectByMaGiangVienVaLoaiDaoTao(int MaGiangVien, string LoaiDaoTao)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            pr[1] = new SqlParameter(@"LoaiDaoTao", LoaiDaoTao);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "SauDaiHoc_HocVien_SelectByMaGiangVienVaLoaiDaoTao", pr);
            return all;
        }


    }
}