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
    public class BHocVi
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "HocVi_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "HocVi_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EHocVi OHocVi)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaHocVi", OHocVi.MaHocVi);
            pr[1] = new SqlParameter(@"TenHocVi", OHocVi.TenHocVi);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVi_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EHocVi OHocVi)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaHocVi", OHocVi.MaHocVi);
            pr[1] = new SqlParameter(@"TenHocVi", OHocVi.TenHocVi);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVi_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaHocVi)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaHocVi",MaHocVi);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "HocVi_Delete", pr);
        }
//-----------------------------------------------------------//
        public static EHocVi SelectByID(int MaHocVi)
        {
            EHocVi OHocVi = new EHocVi();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaHocVi",MaHocVi);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"HocVi_SelectByID", pr);
            if (idr.Read())
              OHocVi = GetOneHocVi(idr);
            idr.Close();
            idr.Dispose();
            return OHocVi;
        }
//-----------------------------------------------------------//
        private static EHocVi GetOneHocVi(IDataReader idr)
       {
            EHocVi OHocVi = new EHocVi();
                if (idr["MaHocVi"] != DBNull.Value)
                    OHocVi.MaHocVi = (int)idr["MaHocVi"];
                if (idr["TenHocVi"] != DBNull.Value)
                    OHocVi.TenHocVi = (string)idr["TenHocVi"];
            return OHocVi;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaHocVi)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaHocVi",MaHocVi);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVi_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EHocVi> ListAll()
        {
            List<EHocVi> list = new List<EHocVi>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "HocVi_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneHocVi(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EHocVi> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EHocVi> list = new List<EHocVi>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "HocVi_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneHocVi(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        // 

        public static DataTable SelectByMaHocVi(int MaHocVi)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaHocVi", MaHocVi);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiangVien_SelectByMaHocVi", pr);
            return all;
        }

    }
}