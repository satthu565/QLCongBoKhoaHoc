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
    public class BKhenThuong
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "KhenThuong_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "KhenThuong_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EKhenThuong OKhenThuong)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"TenKhenThuong", OKhenThuong.TenKhenThuong);
            pr[1] = new SqlParameter(@"So", OKhenThuong.So);
            pr[2] = new SqlParameter(@"NamNhan", OKhenThuong.NamNhan);
            pr[3] = new SqlParameter(@"MaGiangVien", OKhenThuong.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"KhenThuong_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EKhenThuong OKhenThuong)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"MaKhenThuong", OKhenThuong.MaKhenThuong);
            pr[1] = new SqlParameter(@"TenKhenThuong", OKhenThuong.TenKhenThuong);
            pr[2] = new SqlParameter(@"So", OKhenThuong.So);
            pr[3] = new SqlParameter(@"NamNhan", OKhenThuong.NamNhan);
            pr[4] = new SqlParameter(@"MaGiangVien", OKhenThuong.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"KhenThuong_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaKhenThuong)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaKhenThuong",MaKhenThuong);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "KhenThuong_Delete", pr);
        }
//-----------------------------------------------------------//
        public static EKhenThuong SelectByID(int MaKhenThuong)
        {
            EKhenThuong OKhenThuong = new EKhenThuong();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaKhenThuong",MaKhenThuong);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"KhenThuong_SelectByID", pr);
            if (idr.Read())
              OKhenThuong = GetOneKhenThuong(idr);
            idr.Close();
            idr.Dispose();
            return OKhenThuong;
        }
//-----------------------------------------------------------//
        private static EKhenThuong GetOneKhenThuong(IDataReader idr)
       {
            EKhenThuong OKhenThuong = new EKhenThuong();
                if (idr["MaKhenThuong"] != DBNull.Value)
                    OKhenThuong.MaKhenThuong = (int)idr["MaKhenThuong"];
                if (idr["TenKhenThuong"] != DBNull.Value)
                    OKhenThuong.TenKhenThuong = (string)idr["TenKhenThuong"];
                if (idr["So"] != DBNull.Value)
                    OKhenThuong.So = (string)idr["So"];
                if (idr["NamNhan"] != DBNull.Value)
                    OKhenThuong.NamNhan = (DateTime)idr["NamNhan"];
                if (idr["MaGiangVien"] != DBNull.Value)
                    OKhenThuong.MaGiangVien = (int)idr["MaGiangVien"];
            return OKhenThuong;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaKhenThuong)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaKhenThuong",MaKhenThuong);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"KhenThuong_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EKhenThuong> ListAll()
        {
            List<EKhenThuong> list = new List<EKhenThuong>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "KhenThuong_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneKhenThuong(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EKhenThuong> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EKhenThuong> list = new List<EKhenThuong>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "KhenThuong_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneKhenThuong(idr));
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
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "KhenThuong_SelectByMaGiangVien", pr);
            return all;
        }
    }
 
}