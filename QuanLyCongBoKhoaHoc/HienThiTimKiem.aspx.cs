using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.UserControl;

namespace QuanLyCongBoKhoaHoc
{
    public partial class HienThiTimKiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlaceHolder1.Controls.Add(LoadControl("~/UserControl/UcHienThiTimKiemGiangVien.ascx"));
        }
    }
}