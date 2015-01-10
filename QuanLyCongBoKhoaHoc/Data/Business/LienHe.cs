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
    public class BLienHe
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "LienHe_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "LienHe_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(ELienHe OLienHe)
        {
            SqlParameter[] pr = new SqlParameter[9];
            pr[0] = new SqlParameter(@"EmailNguoiGui", OLienHe.EmailNguoiGui);
            pr[1] = new SqlParameter(@"HoTenNguoiGui", OLienHe.HoTenNguoiGui);
            pr[2] = new SqlParameter(@"MaGiangVienNhan", OLienHe.MaGiangVienNhan);
            pr[3] = new SqlParameter(@"TieuDe", OLienHe.TieuDe);
            pr[4] = new SqlParameter(@"NoiDung", OLienHe.NoiDung);
            pr[5] = new SqlParameter(@"TrangThai", OLienHe.TrangThai);
            pr[6] = new SqlParameter(@"DoiTuong", OLienHe.DoiTuong);
            pr[7] = new SqlParameter(@"TieuDeBai", OLienHe.TieuDeBai);
            pr[8] = new SqlParameter(@"ThoiGian", OLienHe.ThoiGian);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "LienHe_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(ELienHe OLienHe)
        {
            SqlParameter[] pr = new SqlParameter[10];
            pr[0] = new SqlParameter(@"MaLienHe", OLienHe.MaLienHe);
            pr[1] = new SqlParameter(@"EmailNguoiGui", OLienHe.EmailNguoiGui);
            pr[2] = new SqlParameter(@"HoTenNguoiGui", OLienHe.HoTenNguoiGui);
            pr[3] = new SqlParameter(@"MaGiangVienNhan", OLienHe.MaGiangVienNhan);
            pr[4] = new SqlParameter(@"TieuDe", OLienHe.TieuDe);
            pr[5] = new SqlParameter(@"NoiDung", OLienHe.NoiDung);
            pr[6] = new SqlParameter(@"TrangThai", OLienHe.TrangThai);
            pr[7] = new SqlParameter(@"DoiTuong", OLienHe.DoiTuong);
            pr[8] = new SqlParameter(@"TieuDeBai", OLienHe.TieuDeBai);
            pr[9] = new SqlParameter(@"ThoiGian", OLienHe.ThoiGian);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "LienHe_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaLienHe)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaLienHe",MaLienHe);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "LienHe_Delete", pr);
        }
//-----------------------------------------------------------//
        public static ELienHe SelectByID(int MaLienHe)
        {
            ELienHe OLienHe = new ELienHe();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaLienHe",MaLienHe);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"LienHe_SelectByID", pr);
            if (idr.Read())
              OLienHe = GetOneLienHe(idr);
            idr.Close();
            idr.Dispose();
            return OLienHe;
        }
//-----------------------------------------------------------//
        private static ELienHe GetOneLienHe(IDataReader idr)
        {
            ELienHe OLienHe = new ELienHe();
            if (idr["MaLienHe"] != DBNull.Value)
                OLienHe.MaLienHe = (int)idr["MaLienHe"];
            if (idr["EmailNguoiGui"] != DBNull.Value)
                OLienHe.EmailNguoiGui = (string)idr["EmailNguoiGui"];
            if (idr["HoTenNguoiGui"] != DBNull.Value)
                OLienHe.HoTenNguoiGui = (string)idr["HoTenNguoiGui"];
            if (idr["MaGiangVienNhan"] != DBNull.Value)
                OLienHe.MaGiangVienNhan = (int)idr["MaGiangVienNhan"];
            if (idr["TieuDe"] != DBNull.Value)
                OLienHe.TieuDe = (string)idr["TieuDe"];
            if (idr["NoiDung"] != DBNull.Value)
                OLienHe.NoiDung = (string)idr["NoiDung"];
            if (idr["TrangThai"] != DBNull.Value)
                OLienHe.TrangThai = (bool)idr["TrangThai"];
            if (idr["DoiTuong"] != DBNull.Value)
                OLienHe.DoiTuong = (string)idr["DoiTuong"];
            if (idr["TieuDeBai"] != DBNull.Value)
                OLienHe.TieuDeBai = (string)idr["TieuDeBai"];
            if (idr["ThoiGian"] != DBNull.Value)
                OLienHe.ThoiGian = (DateTime)idr["ThoiGian"];
            return OLienHe;
        }
//-----------------------------------------------------------//
        public static bool TestByID(int MaLienHe)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaLienHe",MaLienHe);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"LienHe_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<ELienHe> ListAll()
        {
            List<ELienHe> list = new List<ELienHe>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "LienHe_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneLienHe(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<ELienHe> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<ELienHe> list = new List<ELienHe>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "LienHe_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneLienHe(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static DataTable SelectByMaGiangVienNhan(int MaGiangVienNhan)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaGiangVienNhan", MaGiangVienNhan);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "LienHe_SelectByMaGiangVienNhan", pr);
            return all;
        }
       
        public static DataTable TimKiemNguoiGui(string NguoiGui)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"NguoiGui", NguoiGui);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "LienHe_TimKiemNguoiGui", pr);
            return all;
        }
    }
}