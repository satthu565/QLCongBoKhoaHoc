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
    public class BDeTaiNghienCuu
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DeTaiNghienCuu_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "DeTaiNghienCuu_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(EDeTaiNghienCuu ODeTaiNghienCuu)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"TenDeTaiHuongNghienCuu", ODeTaiNghienCuu.TenDeTaiHuongNghienCuu);
            pr[1] = new SqlParameter(@"GioiThieuDeTai", ODeTaiNghienCuu.GioiThieuDeTai);
            pr[2] = new SqlParameter(@"ThoiGianThucHien", ODeTaiNghienCuu.ThoiGianThucHien);
            pr[3] = new SqlParameter(@"ThoiGianKetThuc", ODeTaiNghienCuu.ThoiGianKetThuc);
            pr[4] = new SqlParameter(@"MaGiangVien", ODeTaiNghienCuu.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"DeTaiNghienCuu_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(EDeTaiNghienCuu ODeTaiNghienCuu)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter(@"MaDeTaiHuongNghienCuu", ODeTaiNghienCuu.MaDeTaiHuongNghienCuu);
            pr[1] = new SqlParameter(@"TenDeTaiHuongNghienCuu", ODeTaiNghienCuu.TenDeTaiHuongNghienCuu);
            pr[2] = new SqlParameter(@"GioiThieuDeTai", ODeTaiNghienCuu.GioiThieuDeTai);
            pr[3] = new SqlParameter(@"ThoiGianThucHien", ODeTaiNghienCuu.ThoiGianThucHien);
            pr[4] = new SqlParameter(@"ThoiGianKetThuc", ODeTaiNghienCuu.ThoiGianKetThuc);
            pr[5] = new SqlParameter(@"MaGiangVien", ODeTaiNghienCuu.MaGiangVien);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"DeTaiNghienCuu_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaDeTaiHuongNghienCuu)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaDeTaiHuongNghienCuu",MaDeTaiHuongNghienCuu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DeTaiNghienCuu_Delete", pr);
        }
//-----------------------------------------------------------//
        public static EDeTaiNghienCuu SelectByID(int MaDeTaiHuongNghienCuu)
        {
            EDeTaiNghienCuu ODeTaiNghienCuu = new EDeTaiNghienCuu();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaDeTaiHuongNghienCuu",MaDeTaiHuongNghienCuu);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"DeTaiNghienCuu_SelectByID", pr);
            if (idr.Read())
              ODeTaiNghienCuu = GetOneDeTaiNghienCuu(idr);
            idr.Close();
            idr.Dispose();
            return ODeTaiNghienCuu;
        }
//-----------------------------------------------------------//
        private static EDeTaiNghienCuu GetOneDeTaiNghienCuu(IDataReader idr)
       {
            EDeTaiNghienCuu ODeTaiNghienCuu = new EDeTaiNghienCuu();
                if (idr["MaDeTaiHuongNghienCuu"] != DBNull.Value)
                    ODeTaiNghienCuu.MaDeTaiHuongNghienCuu = (int)idr["MaDeTaiHuongNghienCuu"];
                if (idr["TenDeTaiHuongNghienCuu"] != DBNull.Value)
                    ODeTaiNghienCuu.TenDeTaiHuongNghienCuu = (string)idr["TenDeTaiHuongNghienCuu"];
                if (idr["GioiThieuDeTai"] != DBNull.Value)
                    ODeTaiNghienCuu.GioiThieuDeTai = (string)idr["GioiThieuDeTai"];
                if (idr["ThoiGianThucHien"] != DBNull.Value)
                    ODeTaiNghienCuu.ThoiGianThucHien = (DateTime)idr["ThoiGianThucHien"];
                if (idr["ThoiGianKetThuc"] != DBNull.Value)
                    ODeTaiNghienCuu.ThoiGianKetThuc = (DateTime)idr["ThoiGianKetThuc"];
                if (idr["MaGiangVien"] != DBNull.Value)
                    ODeTaiNghienCuu.MaGiangVien = (int)idr["MaGiangVien"];
            return ODeTaiNghienCuu;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaDeTaiHuongNghienCuu)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaDeTaiHuongNghienCuu",MaDeTaiHuongNghienCuu);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"DeTaiNghienCuu_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<EDeTaiNghienCuu> ListAll()
        {
            List<EDeTaiNghienCuu> list = new List<EDeTaiNghienCuu>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DeTaiNghienCuu_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneDeTaiNghienCuu(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<EDeTaiNghienCuu> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EDeTaiNghienCuu> list = new List<EDeTaiNghienCuu>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "DeTaiNghienCuu_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneDeTaiNghienCuu(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }
    }
 
}