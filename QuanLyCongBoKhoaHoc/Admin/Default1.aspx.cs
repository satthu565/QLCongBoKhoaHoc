
using System;
using System.Web.Services;
 
using System.Web.UI;
namespace QuanLyCongBoKhoaHoc.Admin
{
    public partial class Home1 : System.Web.UI.Page
    {
      //  public string idpage = "";
        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["TenNV"] == null)
            //    Response.Redirect("~/Admin/login.aspx");
            //else
            //{
            //    txtTenNguoiDung.InnerText = Session["TenNV"].ToString();

            //    if (Request.QueryString["idpage"] != null)
            //    {
            //        idpage = Request.QueryString["idpage"].ToString();

            //        if (idpage == "vb")
            //            PlaceHolder1.Controls.Add(LoadControl("ucVietBai.ascx"));
            //        else
            //            if (idpage == "qlha")
            //                PlaceHolder1.Controls.Add(LoadControl("ucQuanLyAlbumAnh.ascx"));
            //            else
            //                if (idpage == "qltt")
            //                    PlaceHolder1.Controls.Add(LoadControl("ucQuanLyTinTuc.ascx"));
            //                else
            //                    if (idpage == "qlstt")
            //                        PlaceHolder1.Controls.Add(LoadControl("ucQuanLySuaTinTuc.ascx"));
            //                    else
            //                        if (idpage == "tab")
            //                            PlaceHolder1.Controls.Add(LoadControl("ucThemAlbum.ascx")); //
            //                        else
            //                            if (idpage == "qltl")
            //                                PlaceHolder1.Controls.Add(LoadControl("ucQLTheLoai.ascx"));
            //                            else
            //                                if (idpage == "qlsl")
            //                                    PlaceHolder1.Controls.Add(LoadControl("ucSlider.ascx"));
            //    }
            //}
        }

        [WebMethod]
        public static void XoaHinhAnh(int idHinhAnh)
        {
          //  BHinhAnh.Delete(idHinhAnh);
        }

        protected void btThoat_Click(object sender, EventArgs e)
        {
            Session["TenNV"] = null;
            Response.Cookies["pass"].Expires = DateTime.Now;
            Response.Cookies["userName"].Expires = DateTime.Now;
            Response.Redirect("~/Admin/login.aspx");
        }
    }
}
