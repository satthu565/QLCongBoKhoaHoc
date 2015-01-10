using QuanLyCongBoKhoaHoc.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcLietKeSachGiaoTrinh : System.Web.UI.UserControl
    {

        public static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["pagecurrent"] = 1;
                dt = BSachXuatBan.SelectAll();
                LoadData(dt);
            }
        }

        public string TenTacGia(int MaGiangVien)
        {
            string TenGiangVien = BGiangVien.SelectByID(MaGiangVien).TenGiangVien;
            return TenGiangVien;
        }

        void LoadData(DataTable dt)
        {
            PagedDataSource pgitems = new PagedDataSource();
            System.Data.DataView dv = new System.Data.DataView(dt);
            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;

            pgitems.PageSize = 10;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount > 1)
            {
                rptPages.Visible = true;
                System.Collections.ArrayList pages = new System.Collections.ArrayList();
                for (int i = 0; i < pgitems.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPages.DataSource = pages;
                rptPages.DataBind();
            }
            else
                rptPages.Visible = false;
            Repeater1.DataSource = pgitems;
            Repeater1.DataBind();
        }

        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                else
                    return 0;
            }
            set
            {
                ViewState["PageNumber"] = value;
            }
        }

        protected void rptPages_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            Session["pagecurrent"] = PageNumber + 1;
            LoadData(dt);
        }

        protected void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton pagelink = e.Item.FindControl("btnPage") as LinkButton;
            string displaypage = pagelink.Text;
            if (Session["pagecurrent"].ToString() == displaypage)
            {
                pagelink.CssClass = "active1";
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtNamXuatBan.Text =="" && txtNhaXuatBan.Text !="")
            {
                dt = BSachXuatBan.TimKiemByNhaXuatBan(txtNhaXuatBan.Text);
                LoadData(dt);
            }
            else if (txtNamXuatBan.Text !="" && txtNhaXuatBan.Text =="")
            {
                dt = BSachXuatBan.TimKiemByNamXuatBan(int.Parse(txtNamXuatBan.Text));
                LoadData(dt);
            }
            else if (txtNamXuatBan.Text != "" && txtNhaXuatBan.Text != "")
            {
                dt = BSachXuatBan.TimKiemByNhaXuatBanVaNamXuatBan(txtNhaXuatBan.Text,int.Parse(txtNamXuatBan.Text));
                LoadData(dt);
            }
            else
	        {
                dt = BSachXuatBan.SelectAll();
                LoadData(dt);
	        }
        }


    }
}