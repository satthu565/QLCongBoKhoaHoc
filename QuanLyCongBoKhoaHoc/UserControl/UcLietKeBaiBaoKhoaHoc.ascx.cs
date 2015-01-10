using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcLietKeBaiBaoKhoaHoc : System.Web.UI.UserControl
    {
         string[] MaChuNhiem;
         public static DataTable dt;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["pagecurrent"] = 1;
                DataTable dt = new DataTable();
                dt = BBaiBao.SelectByGioiHan(true);
                LoadData(dt);
            }
        }
        //trong nước = 1 . quốc tế = 0 ;
        public string ChuoiTenTacGia(string chuoi)
        {
              string TenTG = "";
              string TenTacGia = "";   
                string MaChuNhiemChuan = HamXuLyChuoi(chuoi);  // ko con day '-' o dau va cuoi
                MaChuNhiem = MaChuNhiemChuan.Split('-');
                foreach (var item in MaChuNhiem)
                {
                    TenTG = BGiangVien.SelectByID(int.Parse(item)).TenGiangVien;
                    TenTacGia += TenTG + ",";
                }
            return TenTacGia;
        }

        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }


        void LoadData(DataTable dt)
        {    
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
           if (txtNamXuatBan.Text != "")
            {
                int NamXuatBan = int.Parse(txtNamXuatBan.Text);
                int TuNamXuatBan = NamXuatBan;
                int DenNamXuatBan = NamXuatBan+1;

                dt = BBaiBao.TimKiemTheoNamXuatBanVaGioiHan(NamXuatBan,bool.Parse(ccbGioiHan.SelectedValue));
                LoadData(dt);
            }
          
            else
            {
                dt = BBaiBao.SelectByGioiHan(bool.Parse(ccbGioiHan.SelectedValue));
                LoadData(dt);
            }  
        }


        public string GioiHan(string GioiHan)
        {
            if (GioiHan== "True")
            {
                return "Trong nước";
            }
            return "Quốc tế";
        }

    }
}