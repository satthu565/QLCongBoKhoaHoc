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
    public class BTinTuc
    {
        //-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "TinTuc_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "TinTuc_SelectTop", pr);
            return all;
        }
        //-----------------------------------------------------------//
        public static void Insert(ETinTuc OTinTuc)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter(@"TieuDe", OTinTuc.TieuDe);
            pr[1] = new SqlParameter(@"MoTa", OTinTuc.MoTa);
            pr[2] = new SqlParameter(@"AnhDaiDien", OTinTuc.AnhDaiDien);
            pr[3] = new SqlParameter(@"NoiDung", OTinTuc.NoiDung);
            pr[4] = new SqlParameter(@"NgayDang", OTinTuc.NgayDang);
            pr[5] = new SqlParameter(@"MaGiangVien", OTinTuc.MaGiangVien);
            pr[6] = new SqlParameter(@"MaMenu", OTinTuc.MaMenu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "TinTuc_Insert", pr);
        }
        //-----------------------------------------------------------//
        public static void Update(ETinTuc OTinTuc)
        {
            SqlParameter[] pr = new SqlParameter[8];
            pr[0] = new SqlParameter(@"idTinTuc", OTinTuc.idTinTuc);
            pr[1] = new SqlParameter(@"TieuDe", OTinTuc.TieuDe);
            pr[2] = new SqlParameter(@"MoTa", OTinTuc.MoTa);
            pr[3] = new SqlParameter(@"AnhDaiDien", OTinTuc.AnhDaiDien);
            pr[4] = new SqlParameter(@"NoiDung", OTinTuc.NoiDung);
            pr[5] = new SqlParameter(@"NgayDang", OTinTuc.NgayDang);
            pr[6] = new SqlParameter(@"MaGiangVien", OTinTuc.MaGiangVien);
            pr[7] = new SqlParameter(@"MaMenu", OTinTuc.MaMenu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "TinTuc_Update", pr);
        }
        //-----------------------------------------------------------//
        public static void Delete(int idTinTuc)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"idTinTuc", idTinTuc);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "TinTuc_Delete", pr);
        }
        //-----------------------------------------------------------//
        public static ETinTuc SelectByID(int idTinTuc)
        {
            ETinTuc OTinTuc = new ETinTuc();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"idTinTuc", idTinTuc);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "TinTuc_SelectByID", pr);
            if (idr.Read())
                OTinTuc = GetOneTinTuc(idr);
            idr.Close();
            idr.Dispose();
            return OTinTuc;
        }
        //-----------------------------------------------------------//
        private static ETinTuc GetOneTinTuc(IDataReader idr)
        {
            ETinTuc OTinTuc = new ETinTuc();
            if (idr["idTinTuc"] != DBNull.Value)
                OTinTuc.idTinTuc = (int)idr["idTinTuc"];
            if (idr["TieuDe"] != DBNull.Value)
                OTinTuc.TieuDe = (string)idr["TieuDe"];
            if (idr["MoTa"] != DBNull.Value)
                OTinTuc.MoTa = (string)idr["MoTa"];
            if (idr["AnhDaiDien"] != DBNull.Value)
                OTinTuc.AnhDaiDien = (string)idr["AnhDaiDien"];
            if (idr["NoiDung"] != DBNull.Value)
                OTinTuc.NoiDung = (string)idr["NoiDung"];
            if (idr["NgayDang"] != DBNull.Value)
                OTinTuc.NgayDang = (DateTime)idr["NgayDang"];
            if (idr["MaGiangVien"] != DBNull.Value)
                OTinTuc.MaGiangVien = (int)idr["MaGiangVien"];
            if (idr["MaMenu"] != DBNull.Value)
                OTinTuc.MaMenu = (int)idr["MaMenu"];
            return OTinTuc;
        }
        //-----------------------------------------------------------//
        public static bool TestByID(int idTinTuc)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"idTinTuc", idTinTuc);
            pr[1] = new SqlParameter(@"TestID", SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "TinTuc_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
        //-----------------------------------------------------------//
        public static List<ETinTuc> ListAll()
        {
            List<ETinTuc> list = new List<ETinTuc>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "TinTuc_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneTinTuc(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        public static List<ETinTuc> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<ETinTuc> list = new List<ETinTuc>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "TinTuc_SelectAll", pr);
            while (idr.Read())
                list.Add(GetOneTinTuc(idr));
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
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "TinTuc_SelectByMaGiangVien", pr);
            return all;
        }

        public static DataTable SelectTinTucByMaMenu(int MaMenu)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaMenu", MaMenu);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "TinTuc_SelectByMaMenu", pr);
            return all;
        }
    
    

     
    }
 
}