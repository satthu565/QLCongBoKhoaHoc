using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class LyLichKhoaHoc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDVGiangVien();  
        }

        void LoadDVGiangVien()
        {
            if (Session["MaGiangVien"] != null)
            {
                int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
                DVLyLichGiangVien.AutoGenerateRows = false;
                DVLyLichGiangVien.DataSource = BGiangVien.SelectLyLichByMaGiangVien(MaGiangVien);
                DVLyLichGiangVien.DataBind();
            }
        }

      public string GioiTinh(bool kt)
        {
            if (kt == true)
            {
                return "Nam";
            }
            else
            {
                return "Nữ";
            }
        }

    }
}