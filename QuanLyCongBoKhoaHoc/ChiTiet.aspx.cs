using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;

namespace QuanLyCongBoKhoaHoc
{
    public partial class ChiTiet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["tranghientai"] != null)
            {
                Session["TrangHienTai"] = RouteData.Values["tranghientai"].ToString();
            }
                LoadUcControlThongKe();         
        }


        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        } 

        void LoadUcControlThongKe()
        {
            string DoiTuong = "";
            if (RouteData.Values["DoiTuong"] != null)
            {
                DoiTuong = RouteData.Values["DoiTuong"].ToString();
            }

            string KieuHienThi = "";

            if (RouteData.Values["KieuHienThi"] != null)
            {
                KieuHienThi = RouteData.Values["KieuHienThi"].ToString();
            }
            if (KieuHienThi == "Thong-ke")
            {
                switch (DoiTuong)
                {
                    case "CBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcThongKeCongTrinhKhoaHoc.ascx"));
                        break;
                    case "BBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcThongKeBaiBaoKhoaHoc.ascx"));
                        break;
                    case "SGT":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcThongKeSachGiaoTrinh.ascx"));
                        break;
                    case "HV":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcThongKeHocVi.ascx"));
                        break;
                    default:
                        break;
                }
            }

            if (KieuHienThi == "Liet-ke")
            {
                switch (DoiTuong)
                {
                    case "LKCBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcLietKeCongTrinhKhoaHoc.ascx"));
                        break;
                    case "LKBBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcLietKeBaiBaoKhoaHoc.ascx"));
                        break;
                    case "LKSGT":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcLietKeSachGiaoTrinh.ascx"));
                        break;
                    default:
                        break;
                }
            }

            if (KieuHienThi == "Tim-kiem")
            {
                switch (DoiTuong)
                {
                    case "TKGV":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcTimKiemGiangVien.ascx"));
                        break;
                    case "TKCBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcTimKiemCongBoKhoaHoc.ascx"));
                        break;
                    case "TKBB":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcTimKiemBaiBaoKhoaHoc.ascx"));
                        break;
                    case "TKSXB":
                        PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcTimKiemSachXuatBan.ascx"));
                        break;
                    default:
                        break;
                }
            }

            if (DoiTuong == "Gop-y")
            {
                Session["DoiTuong"] = "Gop-y";
                PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcYKienTraoDoi.ascx"));
            }

            if (KieuHienThi == "Tin-tuc")
            {
                EMenu Menu = BMenu.SelectByTenDoiTuong(DoiTuong);
                Session["MaMenu"] = Menu.MaMenu;
               
               if ( RouteData.Values["tranghientai"] == null)
	          {
		            PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcTinTuc.ascx"));  
	          }
               else
               {
                   Session["MaTinTuc"] = RouteData.Values["tranghientai"].ToString();
                   PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcChiTietTinTuc.ascx"));
               }
             
            }

        }
    }
}