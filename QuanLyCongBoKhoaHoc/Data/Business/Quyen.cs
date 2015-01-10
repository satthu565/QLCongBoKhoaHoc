using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.DataAccess;

namespace QuanLyCongBoKhoaHoc.Business
{
    public class BQuyen
    {
        //-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Quyen_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Quyen_SelectTop", pr);
            return all;
        }
        //-----------------------------------------------------------//
        public static void Insert(EQuyen OQuyen)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"ChuoiDanhMucQuyen", OQuyen.ChuoiDanhMucQuyen);
            pr[1] = new SqlParameter(@"TenQuyen", OQuyen.TenQuyen);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Quyen_Insert", pr);
        }
        //-----------------------------------------------------------//
        public static void Update(EQuyen OQuyen)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter(@"MaQuyen", OQuyen.MaQuyen);
            pr[1] = new SqlParameter(@"ChuoiDanhMucQuyen", OQuyen.ChuoiDanhMucQuyen);
            pr[2] = new SqlParameter(@"TenQuyen", OQuyen.TenQuyen);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Quyen_Update", pr);
        }
        //-----------------------------------------------------------//
        public static void Delete(int MaQuyen)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaQuyen", MaQuyen);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Quyen_Delete", pr);
        }
        //-----------------------------------------------------------//
        public static EQuyen SelectByID(int MaQuyen)
        {
            EQuyen OQuyen = new EQuyen();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaQuyen", MaQuyen);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Quyen_SelectByID", pr);
            if (idr.Read())
                OQuyen = GetOneQuyen(idr);
            idr.Close();
            idr.Dispose();
            return OQuyen;
        }
        //-----------------------------------------------------------//
        private static EQuyen GetOneQuyen(IDataReader idr)
        {
            EQuyen OQuyen = new EQuyen();
            if (idr["MaQuyen"] != DBNull.Value)
                OQuyen.MaQuyen = (int)idr["MaQuyen"];
            if (idr["ChuoiDanhMucQuyen"] != DBNull.Value)
                OQuyen.ChuoiDanhMucQuyen = (string)idr["ChuoiDanhMucQuyen"];
            if (idr["TenQuyen"] != DBNull.Value)
                OQuyen.TenQuyen = (string)idr["TenQuyen"];
            return OQuyen;
        }
        //-----------------------------------------------------------//
        public static bool TestByID(int MaQuyen)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaQuyen", MaQuyen);
            pr[1] = new SqlParameter(@"TestID", SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Quyen_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
        //-----------------------------------------------------------//
        public static List<EQuyen> ListAll()
        {
            List<EQuyen> list = new List<EQuyen>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Quyen_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneQuyen(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        public static List<EQuyen> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EQuyen> list = new List<EQuyen>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Quyen_SelectAll", pr);
            while (idr.Read())
                list.Add(GetOneQuyen(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }
    }

}