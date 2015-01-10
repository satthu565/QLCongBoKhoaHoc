using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc
{
    public partial class CVGiangVien : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["DoiTuong"] = "";

          if (RouteData.Values["MaGiangVien"] != null)
          {
               Session["MaGiangVien"] = int.Parse(RouteData.Values["MaGiangVien"].ToString());
          }
         if (RouteData.Values["MaTieuDeYKien"] != null)
         {
             Session["MaTieuDeYKien"] = int.Parse(RouteData.Values["MaTieuDeYKien"].ToString());
         }
         if (RouteData.Values["DoiTuong"] != null)
         {
             Session["DoiTuong"] = RouteData.Values["DoiTuong"].ToString();
         }  
            LoadUcControls();
            LoadThongTin();
        }

        void LoadThongTin()
        { 
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            AnhDaiDien.ImageUrl = "/images/AnhGiangVien/" + BGiangVien.SelectByID(MaGiangVien).AnhDaiDien;
            TenGiangVien.Text = BGiangVien.SelectByID(MaGiangVien).TenGiangVien;
        }


        void LoadUcControls()
        {          
             string ChonUc = "TTC";
            if (RouteData.Values["UcControl"] != null)
            {
                 ChonUc = RouteData.Values["UcControl"].ToString();
            }    
            switch (ChonUc)
            {
                case "TTC":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcThongTinChungGiangVien.ascx"));
                    break;
                case "CTKH":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcDeTaiCongTrinhKhoaHoc.ascx"));
                    break;
                case "BBBCKH":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcBaiBaoKhoaHoc.ascx"));
                    break;
                case "HDSDH":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcThongTinChungGiangVien.ascx"));
                    break;
                case "MGD":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcMonGiangDay.ascx"));
                    break;
                case "SGT":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcSachVaGiaoTrinh.ascx"));
                    break;
                case "GTKH":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcGiaiThuongKhoaHoc.ascx"));
                    break;
                case "KT":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcKhenThuong.ascx"));
                    break;
                case "YKienTraoDoi":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcYKienTraoDoi.ascx"));
                    break;
                case "DKCGV":
                    PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcDangKyChonGiangVien.ascx"));
                    break;
                case "HC":
                    Response.Redirect("~/Admin/Login.aspx");
                    break;              
                default : 
                    break;
            }
        }
    }
}