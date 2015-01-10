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
    public class BKhoa
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Khoa_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Khoa_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EKhoa OKhoa)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenKhoa", OKhoa.TenKhoa);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Khoa_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EKhoa OKhoa)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaKhoa", OKhoa.MaKhoa);
            pr[1] = new SqlParameter(@"TenKhoa", OKhoa.TenKhoa);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Khoa_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaKhoa)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaKhoa",MaKhoa);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Khoa_Delete", pr);
        }
//-----------------------------------------------------------//
        public static EKhoa SelectByID(int MaKhoa)
        {
            EKhoa OKhoa = new EKhoa();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaKhoa",MaKhoa);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"Khoa_SelectByID", pr);
            if (idr.Read())
              OKhoa = GetOneKhoa(idr);
            idr.Close();
            idr.Dispose();
            return OKhoa;
        }
//-----------------------------------------------------------//
        private static EKhoa GetOneKhoa(IDataReader idr)
       {
            EKhoa OKhoa = new EKhoa();
                if (idr["MaKhoa"] != DBNull.Value)
                    OKhoa.MaKhoa = (int)idr["MaKhoa"];
                if (idr["TenKhoa"] != DBNull.Value)
                    OKhoa.TenKhoa = (string)idr["TenKhoa"];
            return OKhoa;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaKhoa)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaKhoa",MaKhoa);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Khoa_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EKhoa> ListAll()
        {
            List<EKhoa> list = new List<EKhoa>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Khoa_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneKhoa(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EKhoa> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EKhoa> list = new List<EKhoa>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Khoa_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneKhoa(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        // 

        public static EKhoa SelectTenKhoaByMaGiangVien(int MaGiangVien)
        {
            EKhoa OKhoa = new EKhoa();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Khoa_SelectTenKhoaByMaGiangVien", pr);
            if (idr.Read())
                OKhoa = GetOneKhoa(idr);
            idr.Close();
            idr.Dispose();
            return OKhoa;
        }

       


    }
}