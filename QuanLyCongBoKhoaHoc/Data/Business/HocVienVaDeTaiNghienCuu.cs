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
    public class BHocVienVaDeTaiNghienCuu
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "HocVienVaDeTaiNghienCuu_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "HocVienVaDeTaiNghienCuu_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EHocVienVaDeTaiNghienCuu OHocVienVaDeTaiNghienCuu)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"MaHocVien", OHocVienVaDeTaiNghienCuu.MaHocVien);
            pr[1] = new SqlParameter(@"TrangThai", OHocVienVaDeTaiNghienCuu.TrangThai);
            pr[2] = new SqlParameter(@"MaGiangVien", OHocVienVaDeTaiNghienCuu.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVienVaDeTaiNghienCuu_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EHocVienVaDeTaiNghienCuu OHocVienVaDeTaiNghienCuu)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"MaDangKy", OHocVienVaDeTaiNghienCuu.MaDangKy);
            pr[1] = new SqlParameter(@"MaHocVien", OHocVienVaDeTaiNghienCuu.MaHocVien);
            pr[2] = new SqlParameter(@"MaDeTaiHuongNghienCuu", OHocVienVaDeTaiNghienCuu.MaDeTaiHuongNghienCuu);
            pr[3] = new SqlParameter(@"TrangThai", OHocVienVaDeTaiNghienCuu.TrangThai);
            pr[4] = new SqlParameter(@"MaGiangVien", OHocVienVaDeTaiNghienCuu.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVienVaDeTaiNghienCuu_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaDangKy)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaDangKy",MaDangKy);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "HocVienVaDeTaiNghienCuu_Delete", pr);
        }
//-----------------------------------------------------------//
        public static EHocVienVaDeTaiNghienCuu SelectByID(int MaDangKy)
        {
            EHocVienVaDeTaiNghienCuu OHocVienVaDeTaiNghienCuu = new EHocVienVaDeTaiNghienCuu();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaDangKy",MaDangKy);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"HocVienVaDeTaiNghienCuu_SelectByID", pr);
            if (idr.Read())
              OHocVienVaDeTaiNghienCuu = GetOneHocVienVaDeTaiNghienCuu(idr);
            idr.Close();
            idr.Dispose();
            return OHocVienVaDeTaiNghienCuu;
        }
//-----------------------------------------------------------//
        private static EHocVienVaDeTaiNghienCuu GetOneHocVienVaDeTaiNghienCuu(IDataReader idr)
       {
            EHocVienVaDeTaiNghienCuu OHocVienVaDeTaiNghienCuu = new EHocVienVaDeTaiNghienCuu();
                if (idr["MaDangKy"] != DBNull.Value)
                    OHocVienVaDeTaiNghienCuu.MaDangKy = (int)idr["MaDangKy"];
                if (idr["MaHocVien"] != DBNull.Value)
                    OHocVienVaDeTaiNghienCuu.MaHocVien = (int)idr["MaHocVien"];
                if (idr["MaDeTaiHuongNghienCuu"] != DBNull.Value)
                    OHocVienVaDeTaiNghienCuu.MaDeTaiHuongNghienCuu = (int)idr["MaDeTaiHuongNghienCuu"];
                if (idr["TrangThai"] != DBNull.Value)
                    OHocVienVaDeTaiNghienCuu.TrangThai = (bool)idr["TrangThai"];
                if (idr["MaGiangVien"] != DBNull.Value)
                    OHocVienVaDeTaiNghienCuu.MaGiangVien = (int)idr["MaGiangVien"];
            return OHocVienVaDeTaiNghienCuu;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaDangKy)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaDangKy",MaDangKy);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVienVaDeTaiNghienCuu_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EHocVienVaDeTaiNghienCuu> ListAll()
        {
            List<EHocVienVaDeTaiNghienCuu> list = new List<EHocVienVaDeTaiNghienCuu>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "HocVienVaDeTaiNghienCuu_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneHocVienVaDeTaiNghienCuu(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EHocVienVaDeTaiNghienCuu> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EHocVienVaDeTaiNghienCuu> list = new List<EHocVienVaDeTaiNghienCuu>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "HocVienVaDeTaiNghienCuu_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneHocVienVaDeTaiNghienCuu(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }
    }
 
}