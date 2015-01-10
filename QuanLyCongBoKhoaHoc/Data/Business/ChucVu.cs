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
    public class BChucVu
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "ChucVu_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "ChucVu_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EChucVu OChucVu)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"TenChucVu", OChucVu.TenChucVu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"ChucVu_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EChucVu OChucVu)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaChucVu", OChucVu.MaChucVu);
            pr[1] = new SqlParameter(@"TenChucVu", OChucVu.TenChucVu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"ChucVu_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaChucVu)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaChucVu",MaChucVu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ChucVu_Delete", pr);
        }
//-----------------------------------------------------------//
        public static EChucVu SelectByID(int MaChucVu)
        {
            EChucVu OChucVu = new EChucVu();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaChucVu",MaChucVu);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"ChucVu_SelectByID", pr);
            if (idr.Read())
              OChucVu = GetOneChucVu(idr);
            idr.Close();
            idr.Dispose();
            return OChucVu;
        }
//-----------------------------------------------------------//
        private static EChucVu GetOneChucVu(IDataReader idr)
       {
            EChucVu OChucVu = new EChucVu();
                if (idr["MaChucVu"] != DBNull.Value)
                    OChucVu.MaChucVu = (int)idr["MaChucVu"];
                if (idr["TenChucVu"] != DBNull.Value)
                    OChucVu.TenChucVu = (string)idr["TenChucVu"];
            return OChucVu;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaChucVu)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaChucVu",MaChucVu);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"ChucVu_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EChucVu> ListAll()
        {
            List<EChucVu> list = new List<EChucVu>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "ChucVu_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneChucVu(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EChucVu> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EChucVu> list = new List<EChucVu>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "ChucVu_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneChucVu(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }
    }
 
}