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
    public class BSlides
    {
//-----------------------------------------------------------//
        public static DataTable SelectAll()
        {
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Slides_SelectAll", null);
            return all;
        }
        public static DataTable SelectTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, "Slides_SelectTop", pr);
            return all;
        }
//-----------------------------------------------------------//
        public static void Insert(ESlides OSlides)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter(@"TieuDe", OSlides.TieuDe);
            pr[1] = new SqlParameter(@"MoTa", OSlides.MoTa);
            pr[2] = new SqlParameter(@"Anh", OSlides.Anh);
            pr[3] = new SqlParameter(@"ThuTu", OSlides.ThuTu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Slides_Insert", pr);
        }
//-----------------------------------------------------------//
        public static void Update(ESlides OSlides)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter(@"MaSlide", OSlides.MaSlide);
            pr[1] = new SqlParameter(@"TieuDe", OSlides.TieuDe);
            pr[2] = new SqlParameter(@"MoTa", OSlides.MoTa);
            pr[3] = new SqlParameter(@"Anh", OSlides.Anh);
            pr[4] = new SqlParameter(@"ThuTu", OSlides.ThuTu);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Slides_Update", pr);
        }
//-----------------------------------------------------------//
        public static void Delete(int MaSlide)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaSlide",MaSlide);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Slides_Delete", pr);
        }
//-----------------------------------------------------------//
        public static ESlides SelectByID(int MaSlide)
        {
            ESlides OSlides = new ESlides();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"MaSlide",MaSlide);
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,"Slides_SelectByID", pr);
            if (idr.Read())
              OSlides = GetOneSlides(idr);
            idr.Close();
            idr.Dispose();
            return OSlides;
        }
//-----------------------------------------------------------//
        private static ESlides GetOneSlides(IDataReader idr)
       {
            ESlides OSlides = new ESlides();
                if (idr["MaSlide"] != DBNull.Value)
                    OSlides.MaSlide = (int)idr["MaSlide"];
                if (idr["TieuDe"] != DBNull.Value)
                    OSlides.TieuDe = (string)idr["TieuDe"];
                if (idr["MoTa"] != DBNull.Value)
                    OSlides.MoTa = (string)idr["MoTa"];
                if (idr["Anh"] != DBNull.Value)
                    OSlides.Anh = (string)idr["Anh"];
                if (idr["ThuTu"] != DBNull.Value)
                    OSlides.ThuTu = (byte)idr["ThuTu"];
            return OSlides;
       }
//-----------------------------------------------------------//
        public static bool TestByID(int MaSlide)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter(@"MaSlide",MaSlide);
            pr[1] = new SqlParameter(@"TestID",SqlDbType.Bit);
            pr[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"Slides_TestByID", pr);
            return Convert.ToBoolean(pr[1].Value);
        }
//-----------------------------------------------------------//
        public static List<ESlides> ListAll()
        {
            List<ESlides> list = new List<ESlides>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Slides_SelectAll", null);
            while (idr.Read())
              list.Add(GetOneSlides(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }

        public static List<ESlides> ListTop(int Top)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter(@"Top", Top);
            List<ESlides> list = new List<ESlides>();
            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "Slides_SelectAll", pr);
            while (idr.Read())
              list.Add(GetOneSlides(idr));
            if (idr.IsClosed == false)
            {
               idr.Close();
               idr.Dispose();
            }
            return list;
        }
    }
 
}