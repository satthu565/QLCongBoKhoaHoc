using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;

namespace QuanLyCongBoKhoaHoc.Admin.AdUserControl
{
    public partial class AdUserTaiKhoan : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BtnXacNhan_Click(object sender, EventArgs e)
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            string TenDangNhap = BGiangVien.SelectByID(MaGiangVien).TenDangNhap;
            string MatKhau = BGiangVien.SelectByID(MaGiangVien).MatKhau;

            if (XacNhan(MatKhau, Router.MaHoaMD5(txtMatKhauCu.Value.Trim())))
            {
                BGiangVien.UpdateMatKhau(new EGiangVien { 
                    MaGiangVien = MaGiangVien,
                    MatKhau = Router.MaHoaMD5(txtMatKhauMoi.Value.Trim())
                });
                Session["action"] = 2;
            }
            else
            {
                lbThongBao.Text = "Nhập sai mật khẩu cũ";
            }
        }

        bool XacNhan(string MatKhau,string MatKhauNhap)
        {
            if (MatKhau == MatKhauNhap)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}