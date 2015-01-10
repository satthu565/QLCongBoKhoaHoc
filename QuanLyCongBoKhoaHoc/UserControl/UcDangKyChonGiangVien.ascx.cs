using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;
using System.Net.Mail;
using System.Net;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcDangKyChonGiangVien : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCbbHocVi();
        }

       void LoadCbbHocVi()
       {
           cbbHocVi.DataSource = BHocVi.SelectAll();
           cbbHocVi.DataTextField = "TenHocVi" ;
           cbbHocVi.DataValueField = "MaHocVi" ;
           cbbHocVi.DataBind();
       }

       void ThongBao(string Loi)
       {
           ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
       }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            BHocVien.Insert(new EHocVien { 
             
                GioiTinh = bool.Parse(cbbGioiTinh.SelectedValue.ToString()),
                HoTen=txtHoTen.Text,
              
                NgaySinh= DateTime.Parse(txtNgaySinh.Text),
             
                SoCMND= txtCMND.Text,
              
            });

            Session["MaHocVien"] = BHocVien.SelectBySoCMND(txtCMND.Text);
            BLienHe.Insert(new ELienHe {
                DoiTuong = "Theo nghiên cứu",
                EmailNguoiGui=txtEmail.Text,
                HoTenNguoiGui=txtHoTen.Text,
                MaGiangVienNhan = int.Parse(Session["MaGiangVien"].ToString()),
                NoiDung=txtTinNhan.Value,
                ThoiGian= DateTime.Now,
                TieuDe = "Đăng ký theo nghiên cứu",
                TieuDeBai = "Đăng ký theo giảng viên",
                TrangThai=false
            });

            BHocVienVaDeTaiNghienCuu.Insert(new EHocVienVaDeTaiNghienCuu
            {
                MaGiangVien = int.Parse(Session["MaGiangVien"].ToString()),
                MaHocVien = int.Parse(Session["MaGiangVien"].ToString()),
                TrangThai=false
            });


        }

    }
}