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
    public class BGiaiThuongKhoaHoc
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiaiThuongKhoaHoc_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiaiThuongKhoaHoc_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EGiaiThuongKhoaHoc OGiaiThuongKhoaHoc)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter(@"TenGiaiThuong", OGiaiThuongKhoaHoc.TenGiaiThuong);
            pr[1] = new SqlParameter(@"LinhVuc", OGiaiThuongKhoaHoc.LinhVuc);
            pr[2] = new SqlParameter(@"NamNhan", OGiaiThuongKhoaHoc.NamNhan);
            pr[3] = new SqlParameter(@"NoiCap", OGiaiThuongKhoaHoc.NoiCap);
            pr[4] = new SqlParameter(@"So", OGiaiThuongKhoaHoc.So);
            pr[5] = new SqlParameter(@"MaGiangVien", OGiaiThuongKhoaHoc.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"GiaiThuongKhoaHoc_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EGiaiThuongKhoaHoc OGiaiThuongKhoaHoc)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter(@"MaGiaiThuongKhoaHoc", OGiaiThuongKhoaHoc.MaGiaiThuongKhoaHoc);
            pr[1] = new SqlParameter(@"TenGiaiThuong", OGiaiThuongKhoaHoc.TenGiaiThuong);
            pr[2] = new SqlParameter(@"LinhVuc", OGiaiThuongKhoaHoc.LinhVuc);
            pr[3] = new SqlParameter(@"NamNhan", OGiaiThuongKhoaHoc.NamNhan);
            pr[4] = new SqlParameter(@"NoiCap", OGiaiThuongKhoaHoc.NoiCap);
            pr[5] = new SqlParameter(@"So", OGiaiThuongKhoaHoc.So);
            pr[6] = new SqlParameter(@"MaGiangVien", OGiaiThuongKhoaHoc.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"GiaiThuongKhoaHoc_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaGiaiThuongKhoaHoc)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiaiThuongKhoaHoc",MaGiaiThuongKhoaHoc);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "GiaiThuongKhoaHoc_Delete", pr);
        }
//-----------------------------------------------------------//
        public static EGiaiThuongKhoaHoc SelectByID(int MaGiaiThuongKhoaHoc)
        {
            EGiaiThuongKhoaHoc OGiaiThuongKhoaHoc = new EGiaiThuongKhoaHoc();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiaiThuongKhoaHoc",MaGiaiThuongKhoaHoc);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"GiaiThuongKhoaHoc_SelectByID", pr);
            if (idr.Read())
              OGiaiThuongKhoaHoc = GetOneGiaiThuongKhoaHoc(idr);
            idr.Close();
            idr.Dispose();
            return OGiaiThuongKhoaHoc;
        }
//-----------------------------------------------------------//
        private static EGiaiThuongKhoaHoc GetOneGiaiThuongKhoaHoc(IDataReader idr)
       {
            EGiaiThuongKhoaHoc OGiaiThuongKhoaHoc = new EGiaiThuongKhoaHoc();
                if (idr["MaGiaiThuongKhoaHoc"] != DBNull.Value)
                    OGiaiThuongKhoaHoc.MaGiaiThuongKhoaHoc = (int)idr["MaGiaiThuongKhoaHoc"];
                if (idr["TenGiaiThuong"] != DBNull.Value)
                    OGiaiThuongKhoaHoc.TenGiaiThuong = (string)idr["TenGiaiThuong"];
                if (idr["LinhVuc"] != DBNull.Value)
                    OGiaiThuongKhoaHoc.LinhVuc = (string)idr["LinhVuc"];
                if (idr["NamNhan"] != DBNull.Value)
                    OGiaiThuongKhoaHoc.NamNhan = (DateTime)idr["NamNhan"];
                if (idr["NoiCap"] != DBNull.Value)
                    OGiaiThuongKhoaHoc.NoiCap = (string)idr["NoiCap"];
                if (idr["So"] != DBNull.Value)
                    OGiaiThuongKhoaHoc.So = (string)idr["So"];
                if (idr["MaGiangVien"] != DBNull.Value)
                    OGiaiThuongKhoaHoc.MaGiangVien = (int)idr["MaGiangVien"];
            return OGiaiThuongKhoaHoc;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaGiaiThuongKhoaHoc)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaGiaiThuongKhoaHoc",MaGiaiThuongKhoaHoc);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"GiaiThuongKhoaHoc_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EGiaiThuongKhoaHoc> ListAll()
        {
            List<EGiaiThuongKhoaHoc> list = new List<EGiaiThuongKhoaHoc>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiaiThuongKhoaHoc_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneGiaiThuongKhoaHoc(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EGiaiThuongKhoaHoc> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EGiaiThuongKhoaHoc> list = new List<EGiaiThuongKhoaHoc>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "GiaiThuongKhoaHoc_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneGiaiThuongKhoaHoc(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static DataTable SelectByMaGiangVien(int MaGiangVien)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVien", MaGiangVien);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "GiaiThuongKhoaHoc_SelectByMaGiangVien", pr);
            return all;
        }


    }
}