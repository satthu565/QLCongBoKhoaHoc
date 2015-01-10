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
    public class BCapDeTai
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "CapDeTai_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "CapDeTai_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(ECapDeTai OCapDeTai)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenCapDeTai", OCapDeTai.TenCapDeTai);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"CapDeTai_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(ECapDeTai OCapDeTai)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaCapDeTai", OCapDeTai.MaCapDeTai);
            pr[1] = new SqlParameter(@"TenCapDeTai", OCapDeTai.TenCapDeTai);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"CapDeTai_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaCapDeTai)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaCapDeTai",MaCapDeTai);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "CapDeTai_Delete", pr);
        }
//-----------------------------------------------------------//
        public static ECapDeTai SelectByID(int MaCapDeTai)
        {
            ECapDeTai OCapDeTai = new ECapDeTai();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaCapDeTai",MaCapDeTai);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"CapDeTai_SelectByID", pr);
            if (idr.Read())
              OCapDeTai = GetOneCapDeTai(idr);
            idr.Close();
            idr.Dispose();
            return OCapDeTai;
        }
//-----------------------------------------------------------//
        private static ECapDeTai GetOneCapDeTai(IDataReader idr)
       {
            ECapDeTai OCapDeTai = new ECapDeTai();
                if (idr["MaCapDeTai"] != DBNull.Value)
                    OCapDeTai.MaCapDeTai = (int)idr["MaCapDeTai"];
                if (idr["TenCapDeTai"] != DBNull.Value)
                    OCapDeTai.TenCapDeTai = (string)idr["TenCapDeTai"];
            return OCapDeTai;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaCapDeTai)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaCapDeTai",MaCapDeTai);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"CapDeTai_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<ECapDeTai> ListAll()
        {
            List<ECapDeTai> list = new List<ECapDeTai>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "CapDeTai_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneCapDeTai(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<ECapDeTai> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<ECapDeTai> list = new List<ECapDeTai>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "CapDeTai_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneCapDeTai(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }
    }
 
}