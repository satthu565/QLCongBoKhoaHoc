
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.DataAccess;

namespace QuanLyCongBoKhoaHoc.Business
{
    
 public class BMenu
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Menu_SelectAll", null);
            return all;
        }

        public static DataTable SelectByMenuCha(int MaMenuCha)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaMenuCha", MaMenuCha);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Menu_SelectByMenuCha", pr);
            return all;
        }

        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Menu_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EMenu OMenu)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"TenMenu", OMenu.TenMenu);
            pr[1] = new SqlParameter(@"KieuHienThi", OMenu.KieuHienThi);
            pr[2] = new SqlParameter(@"DoiTuong", OMenu.DoiTuong);
            pr[3] = new SqlParameter(@"MaMenuCha", OMenu.MaMenuCha);
            pr[4] = new SqlParameter(@"ThuTu", OMenu.ThuTu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Menu_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EMenu OMenu)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter(@"MaMenu", OMenu.MaMenu);
            pr[1] = new SqlParameter(@"TenMenu", OMenu.TenMenu);
            pr[2] = new SqlParameter(@"KieuHienThi", OMenu.KieuHienThi);
            pr[3] = new SqlParameter(@"DoiTuong", OMenu.DoiTuong);
            pr[4] = new SqlParameter(@"MaMenuCha", OMenu.MaMenuCha);
            pr[5] = new SqlParameter(@"ThuTu", OMenu.ThuTu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Menu_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaMenu)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaMenu",MaMenu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Menu_Delete", pr);
        }
//-----------------------------------------------------------//
        public static EMenu SelectByID(int MaMenu)
        {
            EMenu OMenu = new EMenu();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaMenu",MaMenu);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"Menu_SelectByID", pr);
            if (idr.Read())
              OMenu = GetOneMenu(idr);
            idr.Close();
            idr.Dispose();
            return OMenu;
        }
//-----------------------------------------------------------//
        private static EMenu GetOneMenu(IDataReader idr)
       {
            EMenu OMenu = new EMenu();
                if (idr["MaMenu"] != DBNull.Value)
                    OMenu.MaMenu = (int)idr["MaMenu"];
                if (idr["TenMenu"] != DBNull.Value)
                    OMenu.TenMenu = (string)idr["TenMenu"];
                if (idr["KieuHienThi"] != DBNull.Value)
                    OMenu.KieuHienThi = (string)idr["KieuHienThi"];
                if (idr["DoiTuong"] != DBNull.Value)
                    OMenu.DoiTuong = (string)idr["DoiTuong"];
                if (idr["MaMenuCha"] != DBNull.Value)
                    OMenu.MaMenuCha = (int)idr["MaMenuCha"];
                if (idr["ThuTu"] != DBNull.Value)
                    OMenu.ThuTu = (byte)idr["ThuTu"];
            return OMenu;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaMenu)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaMenu",MaMenu);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Menu_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EMenu> ListAll()
        {
            List<EMenu> list = new List<EMenu>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Menu_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneMenu(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EMenu> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EMenu> list = new List<EMenu>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Menu_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneMenu(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

     // 

        public static EMenu SelectByTenDoiTuong(string DoiTuong)
        {
            EMenu OMenu = new EMenu();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"DoiTuong", DoiTuong);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Menu_SelectMaMenuByDoiTuong", pr);
            if (idr.Read())
                OMenu = GetOneMenu(idr);
            idr.Close();
            idr.Dispose();
            return OMenu;
        }


        public static DataTable SelectTenMenuTinTuc()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Menu_SelectKieuHienThi_TinTuc", null);
            return all;
        }
    }
}