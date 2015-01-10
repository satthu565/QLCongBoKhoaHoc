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
    public partial class UcTimKiemBaiBaoKhoaHoc : System.Web.UI.UserControl
    {
        string[] MaChuNhiem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["pagecurrent"] = 1;
                LoadData("");
            }
        }

        void LoadData(string TenBaiBao)
        {
            DataTable dt = new DataTable();
            dt = BBaiBao.SelectTimKiemByTenBaiBao(TenBaiBao);
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
            LoadData(txtTenBaiBao.Value.Trim());
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

        public string ChuoiTacGia(string Chuoi)
        {
               string TenTG = "";
               string TenTacGia = "";

                DataTable dtLKBaiBaoKhoaHoc = new DataTable();
                string MaChuNhiemChuan = HamXuLyChuoi(Chuoi);  // ko con day '-' o dau va cuoi
                MaChuNhiem = MaChuNhiemChuan.Split('-');
                foreach (var item in MaChuNhiem)
                {
                    TenTG = BGiangVien.SelectByID(int.Parse(item)).TenGiangVien;
                    TenTacGia += TenTG + ",";
                }
                return TenTacGia;
        }

        public string GioiHanBaiBao(bool GioiHan)
        {
            if (GioiHan == true)
            {
                return "Trong nước";
            }
            else
            {
                return "Quốc tế";
            }
        }

        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TenBaiBao = txtTenBaiBao.Value.Trim();
            LoadData(TenBaiBao);
        }


    }
}