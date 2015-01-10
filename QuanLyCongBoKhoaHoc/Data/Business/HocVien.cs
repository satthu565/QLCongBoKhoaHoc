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
    public class BHocVien
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "HocVien_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "HocVien_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EHocVien OHocVien)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"HoTen", OHocVien.HoTen);
            pr[1] = new SqlParameter(@"GioiTinh", OHocVien.GioiTinh);
            pr[2] = new SqlParameter(@"NgaySinh", OHocVien.NgaySinh);
            pr[3] = new SqlParameter(@"SoCMND", OHocVien.SoCMND);
          
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVien_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EHocVien OHocVien)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"MaHocVien", OHocVien.MaHocVien);
            pr[1] = new SqlParameter(@"HoTen", OHocVien.HoTen);
            pr[2] = new SqlParameter(@"GioiTinh", OHocVien.GioiTinh);
            pr[3] = new SqlParameter(@"NgaySinh", OHocVien.NgaySinh);  
            pr[4] = new SqlParameter(@"SoCMND", OHocVien.SoCMND);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVien_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaHocVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaHocVien",MaHocVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "HocVien_Delete", pr);
        }
        //-----------------------------------------------------------//
        public static EHocVien SelectByID(int MaHocVien)
        {
            EHocVien OHocVien = new EHocVien();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaHocVien",MaHocVien);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"HocVien_SelectByID", pr);
            if (idr.Read())
              OHocVien = GetOneHocVien(idr);
            idr.Close();
            idr.Dispose();
            return OHocVien;
        }
//-----------------------------------------------------------//
        private static EHocVien GetOneHocVien(IDataReader idr)
       {
            EHocVien OHocVien = new EHocVien();
                if (idr["MaHocVien"] != DBNull.Value)
                    OHocVien.MaHocVien = (int)idr["MaHocVien"];
                if (idr["HoTen"] != DBNull.Value)
                    OHocVien.HoTen = (string)idr["HoTen"];
                if (idr["GioiTinh"] != DBNull.Value)
                    OHocVien.GioiTinh = (bool)idr["GioiTinh"];
                if (idr["NgaySinh"] != DBNull.Value)
                    OHocVien.NgaySinh = (DateTime)idr["NgaySinh"];
                if (idr["SoCMND"] != DBNull.Value)
                    OHocVien.SoCMND = (string)idr["SoCMND"];
               
            return OHocVien;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaHocVien)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaHocVien",MaHocVien);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"HocVien_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EHocVien> ListAll()
        {
            List<EHocVien> list = new List<EHocVien>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "HocVien_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneHocVien(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EHocVien> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EHocVien> list = new List<EHocVien>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "HocVien_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneHocVien(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static EHocVien SelectBySoCMND(string SoCMND)
        {
            EHocVien OHocVien = new EHocVien();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"SoCMND", SoCMND);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "HocVien_SelectBySoCMND", pr);
            if (idr.Read())
                OHocVien = GetOneHocVien(idr);
            idr.Close();
            idr.Dispose();
            return OHocVien;
        }


        public static EHocVien SelectTop1(int Top)
        {
            EHocVien OHocVien = new EHocVien();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "HocVien_SelectTop1", pr);
            if (idr.Read())
                OHocVien = GetOneHocVien(idr);
            idr.Close();
            idr.Dispose();
            return OHocVien;
        }
    }
 
}