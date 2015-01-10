using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.DataAccess;

namespace QuanLyCongBoKhoaHoc.Business
{
    public class BQuaTrinhCongTac
    {
        //-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "QuaTrinhCongTac_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "QuaTrinhCongTac_SelectTop", pr);
            return all;
        }
        //-----------------------------------------------------------//
        public static void Insert(EQuaTrinhCongTac OQuaTrinhCongTac)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"MoTaCongTac", OQuaTrinhCongTac.MoTaCongTac);
            pr[1] = new SqlParameter(@"MaGiangVien", OQuaTrinhCongTac.MaGiangVien);
            pr[2] = new SqlParameter(@"NamcongTac", OQuaTrinhCongTac.NamcongTac);
            pr[3] = new SqlParameter(@"ThuTuHienThi", OQuaTrinhCongTac.ThuTuHienThi);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "QuaTrinhCongTac_Insert", pr);
        }
        //-----------------------------------------------------------//
        public static void Update(EQuaTrinhCongTac OQuaTrinhCongTac)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"MaCongTac", OQuaTrinhCongTac.MaCongTac);
            pr[1] = new SqlParameter(@"MoTaCongTac", OQuaTrinhCongTac.MoTaCongTac);
            pr[2] = new SqlParameter(@"MaGiangVien", OQuaTrinhCongTac.MaGiangVien);
            pr[3] = new SqlParameter(@"NamcongTac", OQuaTrinhCongTac.NamcongTac);
            pr[4] = new SqlParameter(@"ThuTuHienThi", OQuaTrinhCongTac.ThuTuHienThi);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "QuaTrinhCongTac_Update", pr);
        }
        //-----------------------------------------------------------//
        public static void Delete(int MaCongTac)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaCongTac", MaCongTac);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "QuaTrinhCongTac_Delete", pr);
        }
        //-----------------------------------------------------------//
        public static EQuaTrinhCongTac SelectByID(int MaCongTac)
        {
            EQuaTrinhCongTac OQuaTrinhCongTac = new EQuaTrinhCongTac();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaCongTac", MaCongTac);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "QuaTrinhCongTac_SelectByID", pr);
            if (idr.Read())
                OQuaTrinhCongTac = GetOneQuaTrinhCongTac(idr);
            idr.Close();
            idr.Dispose();
            return OQuaTrinhCongTac;
        }
        //-----------------------------------------------------------//
        private static EQuaTrinhCongTac GetOneQuaTrinhCongTac(IDataReader idr)
        {
            EQuaTrinhCongTac OQuaTrinhCongTac = new EQuaTrinhCongTac();
            if (idr["MaCongTac"] != DBNull.Value)
                OQuaTrinhCongTac.MaCongTac = (int)idr["MaCongTac"];
            if (idr["MoTaCongTac"] != DBNull.Value)
                OQuaTrinhCongTac.MoTaCongTac = (string)idr["MoTaCongTac"];
            if (idr["MaGiangVien"] != DBNull.Value)
                OQuaTrinhCongTac.MaGiangVien = (int)idr["MaGiangVien"];
            if (idr["NamcongTac"] != DBNull.Value)
                OQuaTrinhCongTac.NamcongTac = (string)idr["NamcongTac"];
            if (idr["ThuTuHienThi"] != DBNull.Value)
                OQuaTrinhCongTac.ThuTuHienThi = (int)idr["ThuTuHienThi"];
            return OQuaTrinhCongTac;
        }
        //-----------------------------------------------------------//
        public static bool TestByID(int MaCongTac)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaCongTac", MaCongTac);
            pr[1] = new SqlParameter(@"TestID", SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "QuaTrinhCongTac_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
        //-----------------------------------------------------------//
        public static List<EQuaTrinhCongTac> ListAll()
        {
            List<EQuaTrinhCongTac> list = new List<EQuaTrinhCongTac>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "QuaTrinhCongTac_SelectAll", null);
            while (idr.Read())
                list.Add(GetOneQuaTrinhCongTac(idr));
            if (idr.IsClosed == false)
            {
                idr.Close();
                idr.Dispose();
            }
            return list;
        }

        public static List<EQuaTrinhCongTac> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<EQuaTrinhCongTac> list = new List<EQuaTrinhCongTac>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "QuaTrinhCongTac_SelectAll", pr);
            while (idr.Read())
                list.Add(GetOneQuaTrinhCongTac(idr));
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
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "QuaTrinhCongTac_SelectByMaGiangVien", pr);
            return all;
        }
    }

}