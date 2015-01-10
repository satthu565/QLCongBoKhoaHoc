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
    public class BDanhMucQuyen
    {
        //-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhMucQuyen_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DanhMucQuyen_SelectTop", pr);
            return all;
        }
        //-----------------------------------------------------------//
        public static void Insert(EDanhMucQuyen ODanhMucQuyen)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenDanhMucQuyen", ODanhMucQuyen.TenDanhMucQuyen);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhMucQuyen_Insert", pr);
        }
        //-----------------------------------------------------------//
        public static void Update(EDanhMucQuyen ODanhMucQuyen)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaDanhMucQuyen", ODanhMucQuyen.MaDanhMucQuyen);
            pr[1] = new SqlParameter(@"TenDanhMucQuyen", ODanhMucQuyen.TenDanhMucQuyen);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhMucQuyen_Update", pr);
        }
        //-----------------------------------------------------------//
        public static void Delete(int MaDanhMucQuyen)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaDanhMucQuyen", MaDanhMucQuyen);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhMucQuyen_Delete", pr);
        }
        //-----------------------------------------------------------//
        public static EDanhMucQuyen SelectByID(int MaDanhMucQuyen)
        {
            EDanhMucQuyen ODanhMucQuyen = new EDanhMucQuyen();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaDanhMucQuyen", MaDanhMucQuyen);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DanhMucQuyen_SelectByID", pr);
            if (idr.Read())
                ODanhMucQuyen = GetOneDanhMucQuyen(idr);
            idr.Close();
            idr.Dispose();
            return ODanhMucQuyen;
        }
        //-----------------------------------------------------------//
        private static EDanhMucQuyen GetOneDanhMucQuyen(IDataReader idr)
        {
            EDanhMucQuyen ODanhMucQuyen = new EDanhMucQuyen();
            if (idr["MaDanhMucQuyen"] != DBNull.Value)
                ODanhMucQuyen.MaDanhMucQuyen = (int)idr["MaDanhMucQuyen"];
            if (idr["TenDanhMucQuyen"] != DBNull.Value)
                ODanhMucQuyen.TenDanhMucQuyen = (string)idr["TenDanhMucQuyen"];
            return ODanhMucQuyen;
        }
        //-----------------------------------------------------------//
        public static bool TestByID(int MaDanhMucQuyen)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaDanhMucQuyen", MaDanhMucQuyen);
            pr[1] = new SqlParameter(@"TestID", SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhMucQuyen_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
        //-----------------------------------------------------------//
        public static List<EDanhMucQuyen> ListAll()
        {
            List<EDanhMucQuyen> list = new List<EDanhMucQuyen>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DanhMucQuyen_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneDanhMucQuyen(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        public static List<EDanhMucQuyen> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EDanhMucQuyen> list = new List<EDanhMucQuyen>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DanhMucQuyen_SelectAll", pr);
            while (idr.Read())
                list.Add(GetOneDanhMucQuyen(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        public static void Reset()
        {
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DanhMucQuyen_Reset", null);
        }

    }
}