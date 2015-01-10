using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace QuanLyCongBoKhoaHoc
{
    public class Global : System.Web.HttpApplication
    {

        void ResgisterRoutes(RouteCollection routes)
        {
         
            routes.MapPageRoute("Error", "error", "~/404.aspx");
            routes.MapPageRoute("Home1", "", "~/Home.aspx");
            routes.MapPageRoute("Home", "page-{trang}", "~/Home.aspx");
            routes.MapPageRoute("GiangVien", "Giang-Vien", "~/CVGiangVien.aspx");
            routes.MapPageRoute("CVGiangVien", "CV-Giang-Vien/{UcConTrol}/{MaGiangVien}", "~/CVGiangVien.aspx");
            routes.MapPageRoute("LyLich", "Ly-Lich/{MaGiangVien}", "~/CVGiangVien.aspx");
            routes.MapPageRoute("CVGiangVien1", "CV-Giang-Vien/{UcConTrol}", "~/CVGiangVien.aspx");
            routes.MapPageRoute("YKienTraoDoi", "CV-Giang-Vien/{UcConTrol}/{DoiTuong}/{MaTieuDeYKien}", "~/CVGiangVien.aspx");

            routes.MapPageRoute("AdHome", "Admin/{usercontrol}", "~/Admin/AdHome.aspx");
            routes.MapPageRoute("adminLogin", "Login", "~/Admin/Login.aspx");


            routes.MapPageRoute("ChiTiet", "{KieuHienThi}/{DoiTuong}", "~/ChiTiet.aspx");
            routes.MapPageRoute("TimKiem", "{KieuHienThi}/{DoiTuong}/{tranghientai}", "~/ChiTiet.aspx");
    
        
         
           
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHubs();
             ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
             {
                Path = "~/scripts/jquery-1.7.2.min.js",
                DebugPath = "~/scripts/jquery-1.7.2.min.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
              });
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
            ResgisterRoutes(RouteTable.Routes);
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}