using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;
using System.Data;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcHome : System.Web.UI.UserControl
    {    
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Session["pagecurrent"] = 1;
                LoadcbbKhoa();
                LoadData("", 0);
            }
        }

        void LoadData(string TenGiangVien,int MaKhoa)
        {
            DataTable dt = new DataTable();
            dt = BGiangVien.SelectTimKiemByMaKhoaVaTenGiangVien(TenGiangVien,MaKhoa);
            PagedDataSource pgitems = new PagedDataSource();
            System.Data.DataView dv = new System.Data.DataView(dt);
            pgitems.DataSource = dv;
            pgitems.AllowPaging = true;

            pgitems.PageSize = 6;
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
            string TenGiangVienTim = txtTenGiangVien.Text.Trim();
            int Makhoa = int.Parse(cbbKhoa.SelectedValue.ToString());
            LoadData(TenGiangVienTim, Makhoa);
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

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        void LoadcbbKhoa()
        {
            cbbKhoa.DataSource = BKhoa.SelectAll();
            cbbKhoa.DataTextField = "TenKhoa";
            cbbKhoa.DataValueField = "MaKhoa";
            cbbKhoa.DataBind();
            cbbKhoa.Items.Insert(0, new ListItem("--- Chọn khoa ---","0"));
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            PageNumber = 0;
            string TenGiangVienTim = txtTenGiangVien.Text.Trim();
            string Makhoa = cbbKhoa.SelectedValue;
            int makhoa = int.Parse(Makhoa);
            LoadData(TenGiangVienTim, makhoa);
        }

    }
}