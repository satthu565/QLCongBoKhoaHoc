using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.Business;
using System.Data;


using System.Net.Mail;
using System.Net;

namespace QuanLyCongBoKhoaHoc.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        public bool isClick = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userName"] != null && Request.Cookies["pass"] != null)
            {
                cbNhoMatKhau.Checked = true;
                try
                {
                    DangNhap(Request.Cookies["userName"].Value, Request.Cookies["pass"].Value);
                }
                catch
                { }
            }
        }
        
        void ThongBao(string Loi)
         {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
         }

        protected void btDangNhap_Click(object sender, EventArgs e)
        {
            // Ma hoa MD5 mat khau
              DangNhap(txtTenDangNhap.Text, Router.MaHoaMD5(txtMatKhau.Text));
        }

        void DangNhap(string TenDN,string Matkhau)
        {
            EGiangVien GiangVien = BGiangVien.DangNhap(TenDN, Matkhau);

            if (GiangVien.TenGiangVien == null)
            {

                ThongBao("Tài khoản hoặc mật khẩu sai....!");
            }
            else
            {
                if (cbNhoMatKhau.Checked == true)
                {
                    Response.Cookies["userName"].Value = TenDN;
                    Response.Cookies["pass"].Value = GiangVien.MatKhau;

                    Response.Cookies["userName"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["pass"].Expires = DateTime.Now.AddDays(15);

                }
                else if (cbNhoMatKhau.Checked == false)
                {
                    Response.Cookies["pass"].Expires = DateTime.Now;
                    Response.Cookies["userName"].Expires = DateTime.Now;
                }

           //   Session["QuyenDN"] = GiangVien.idChucVu;
                Session["TenGiangVIen"] = GiangVien.TenGiangVien;
                Session["AnhDaiDien"] = GiangVien.AnhDaiDien;
                Session["MaGiangVien"] = GiangVien.MaGiangVien;
                Response.Redirect("~/Admin/AdHome.aspx");
            }            
        }

        protected void btnGuiLayMatKhau_Click(object sender, EventArgs e)
        {
            //MailMessage objEmail = new MailMessage();
            DataTable dtb = LayTenDangNhap(txtEmail.Text + "");
            if (dtb.Rows.Count > 0)
            {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("hungtd_d5cntt@epu.edu.vn", "email");
            msg.To.Add(new MailAddress("buithian1994@gmail.com"));
            msg.Subject = "Lấy lại mật khẩu";
            msg.Body = NoiDungMail();
            msg.IsBodyHtml=true;
        
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("hungtd_d5cntt@epu.edu.vn","0978870779");
            smtp.EnableSsl=true;
            try 
	        {	        
		        smtp.Send(msg);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert('Thanh cong!');", true);
	        }
	        catch (Exception ex)
	        {
		         ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert('chưa gửi được email!');", true);
	        }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectMe", "alert('Email của bạn chưa đăng ký!');", true);
            }
        }


        public string CreateLostPassword(int PasswordLength)
        {
            string _allowedChars = "abcdefghijk0123456789mnopqrstuvwxyz";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;


            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        private void DoiMatKhau(string TenDangNhap, string MatKhau)
        {
            BGiangVien.UpdateMatKhauByTenDangNhap(new EGiangVien {
                TenDangNhap = TenDangNhap,
                MatKhau = MatKhau
            });
        }


        private DataTable LayTenDangNhap(string Email)
        {
           return BGiangVien.LayTenDangNhapbyEmail(Email);
        }

        private string NoiDungMail()
        {
            string NoiDung = "";
            DataTable dtb = LayTenDangNhap(txtEmail.Text + "");
            string MatKhauMoi = "", TenDangNhap = "";
            if (dtb.Rows.Count > 0)
            {
                NoiDung = "Đây là Mail gửi đến từ website của duyhung..<br>";
                MatKhauMoi = CreateLostPassword(7);
                NoiDung += "Mật khẩu mới của bạn là: " + MatKhauMoi;
                TenDangNhap = dtb.Rows[0]["TenDangNhap"].ToString();
                DoiMatKhau(TenDangNhap, Router.MaHoaMD5(MatKhauMoi));
                NoiDung += "<br>Sau khi đăng nhập bạn đổi lại mật khẩu để tiện cho việc đăng nhập lần tiếp theo";
                NoiDung += "<br>Làm ơn không gửi lại email";
            }
          return NoiDung;
       }

    }
}