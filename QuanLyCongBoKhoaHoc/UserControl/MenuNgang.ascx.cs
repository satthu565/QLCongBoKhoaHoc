using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class MenuNgang : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void MenuDong(int MenuCha)
        {
            DataTable table = new DataTable();
            table = BMenu.SelectByMenuCha(MenuCha);
            int count = table.Rows.Count;

            if (count > 0 && MenuCha != 0)
                Response.Write("<ul class='dropdown-menu'>");

            for (int i = 0; i < count; i++)
            {
                if (MenuCha == 0 && BMenu.SelectByMenuCha(int.Parse(table.Rows[i]["MaMenu"].ToString())).Rows.Count > 0)
                    // Response.Write("<li class='dropdown'><a rel='nofollow' class='dropdown-toggle'  href='/" + Router.NonUnicode(table.Rows[i]["TenMenu"].ToString()) + "-" + table.Rows[i]["KieuHienThi"].ToString() + "'>" + table.Rows[i]["TenMenu"].ToString() + " <b class='caret'></b></a>");
                    Response.Write("<li class='dropdown'><a style=\" font-size:12px;text-transform:uppercase;color:#fff;padding: 13px !important;height:45px;background-color: #4A72B8 \" rel='nofollow' class='dropdown-toggle'  href='#'>" + table.Rows[i]["TenMenu"].ToString() + " <b class='caret'></b></a>");
                else
                    Response.Write("<li><a style=\" font-size:12px;  color:#fff ;background-color: #4A72B8;height:45px;text-transform:uppercase \" rel='nofollow' href='/" + table.Rows[i]["KieuHienThi"] + "/" + table.Rows[i]["DoiTuong"] + "'>" + table.Rows[i]["TenMenu"].ToString() + "</a>");
                MenuDong(int.Parse(table.Rows[i]["MaMenu"].ToString()));
            }

            if (count > 0) Response.Write("</ul></li>");
            else Response.Write("</li>");
        }
    }
}