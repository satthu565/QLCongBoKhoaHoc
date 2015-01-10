using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCongBoKhoaHoc
{
    public partial class Home : System.Web.UI.Page
    {    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["Trang"] != null)
            {
                Session["Trang"] = RouteData.Values["Trang"].ToString();
            }
            else
            {
                Session["Trang"] = "1";
            }
            PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcHome.ascx"));
        }
    }
}