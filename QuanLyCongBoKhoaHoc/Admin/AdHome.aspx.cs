using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Entities;
using System.Data.SqlClient;
using QuanLyCongBoKhoaHoc.Business;
using System.Data;

namespace QuanLyCongBoKhoaHoc.Admin
{
    public partial class AdHome : System.Web.UI.Page
    {
        public string[] MangQuyen;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TenGiangVien"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx");
                
             }
            else
            {
                string ten = Session["TenGiangVien"].ToString();
                lbTenNguoiDung.Text = ten;
                int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
                string AnhDaiDien = "~/images/AnhGiangVien/"+BGiangVien.SelectByID(MaGiangVien).AnhDaiDien;
                AnhDaiDienNho.ImageUrl = AnhDaiDien;
                int MaQuyen = BGiangVien.SelectByID(MaGiangVien).MaQuyen;
                string ChuoiDanhSachQuyen = BQuyen.SelectByID(MaQuyen).ChuoiDanhMucQuyen;
                MangQuyen = ChuoiDanhSachQuyen.Split(' ');
                LoadUcControl();
            }
        }

        public bool PhanQuyen(int DanhSachQuyen)
        {
            foreach (var item in MangQuyen)
            {
                if (item.ToString() == DanhSachQuyen.ToString())
                {
                    return true;  
                }
            }
            return false;
        }

        void LoadUcControl()
        {
            if (Request.QueryString["url"] != null)
            {
                string URL = Request.QueryString["url"].ToString();
                switch (URL)
                {
                    // Sửa công bố khoa học
                    case "SCBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcCongBoKhoaHoc_Sua.ascx"));
                        break;
                    // Sửa bài báo khoa học 
                    case "SBBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcBaiBaoKhoaHoc_Sua.ascx"));
                        break;
                    // Sửa tin tức 
                    case "STT":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcQuanLySuaTinTuc.ascx"));
                        break;
                   // xem chi tiết tin nhắn liên hệ
                    case "XTNLH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcChiTietTinNhanLienHe.ascx"));
                        break;
           
                    default:
                        break;
                }
            }
            else
            {
                string UC = "";
                if (RouteData.Values["usercontrol"] != null)
                {
                    UC = RouteData.Values["usercontrol"].ToString();
                }
                switch (UC)
                {
                    //quản lý thông tin  
                    case "TTCN":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcThongTinCaNhan.ascx"));
                        break;
                    // Quản lý tài khoản
                    case "QLTK":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcTaiKhoan.ascx"));
                        break;
                    // Quản lý quá trình công tác
                    case "QLQTCT":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcQuaTrinhCongTac.ascx"));
                        break;

                    // Quản lý công bố khoa học
                    case "QLCBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcCongBoKhoaHoc.ascx"));
                        break;

                    // Thêm bài báo khoa học
                    case "TBBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcBaiBaoKhoaHoc_Them.ascx"));
                        break;
                    // Sửa bài báo khoa học
                    case "SBBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcBaiBaoKhoaHoc_Sua.ascx"));
                        break;
                    // Quản lý bài báo khoa học
                    case "QLBBKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcBaiBaoKhoaHoc.ascx"));
                        break;

                    // thêm sách xuất bản  
                    case "TSXB":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcSachXuatBan_Them.ascx"));
                        break;
                    // Quản lý sách xuất bản
                    case "QLSXB":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcSachXuatBan.ascx"));
                        break;

                    // đào tạo học viên cao học 
                    case "DTHVCH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/ucAdHocVienCaoHoc.ascx"));
                        break;
                    // đào tạo nghiên cứu sinh
                    case "DTNCS":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUcHocVienSauDaiHoc/AdUcNghienCuuSinh.ascx"));
                        break;
                   
                 

                    //Giải thưởng khoa học
                    case "GTKH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcGiaiThuongKhoaHoc.ascx"));
                        break;
                    // Khen thưởng
                    case "KT":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcKhenThuong.ascx"));
                        break;

                    // Quản lý slide
                    case "QLS":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcQuanLySlide.ascx"));
                        break;
                    // Quản lý menu
                    case "QLM":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcMenu.ascx"));
                        break;
                    // Quản lý tin nhắn liên hệ
                    case "TNLH":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcQuanLyTinNhanLienHe.ascx"));
                        break;
                    // Quản lý giảng viên
                    case "QLGV":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcQuanLyGiangVien.ascx"));
                        break;
                    // Quản lý chức vụ
                    case "QLCV":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcQuanLyChucVu.ascx"));
                        break;
                    // Quản lý quyền
                    case "QLQ":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcQuanLyQuyen.ascx"));
                        break;
                     //Danh mục quyền
                    case "DMQ":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcDanhMucQuyen.ascx"));
                        break;
                    //Danh quản lý tin tức
                    case "QLTinTuc":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcQuanLyTinTuc.ascx"));
                        break;
                    //Danh mục viết tin tức
                    case "VietBai":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcVietTin.ascx"));
                        break;


                     // các thông tin khác
                    case "Khoa":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcKhoa.ascx"));
                        break;
                    case "ChucVu":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcChucVu.ascx"));
                        break;
                    case "HocVi":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcHocVi.ascx"));
                        break;
                    case "CapDeTai":
                        PlaceHolder1.Controls.Add(LoadControl("~/Admin/AdUserControl/AdUcCapDeTai.ascx"));
                        break;

                    default:
                        break;
                }
            }
        }

        protected void btThoat_Click(object sender, EventArgs e)
        {
            Session["TenGiangVien"] = null;
            Response.Cookies["pass"].Expires = DateTime.Now;
            Response.Cookies["userName"].Expires = DateTime.Now;
            Response.Redirect("~/Admin/login.aspx");
        }
     

    }
}