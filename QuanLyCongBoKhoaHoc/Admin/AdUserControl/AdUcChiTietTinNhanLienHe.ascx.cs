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

namespace QuanLyCongBoKhoaHoc.Admin.AdUserControl
{
    public partial class AdUcChiTietTinNhanLienHe : System.Web.UI.UserControl
    {
        public bool isClick = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            int MaTinNhan = int.Parse(Session["MaTinNhan"].ToString());
            ELienHe LienHe = BLienHe.SelectByID(MaTinNhan);
            lbEmailGui.Text = LienHe.EmailNguoiGui;
            lbHoTen.Text = LienHe.HoTenNguoiGui;
            lbTieuDe.Text = LienHe.TieuDe;
            lbTinNhan.Value = LienHe.NoiDung;
            txtEmailNhan.Text = LienHe.EmailNguoiGui;
        }

        protected void btnGuiMail_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(txtEmailGui.Text, "email");
            msg.To.Add(new MailAddress(txtEmailNhan.Text));
            msg.Subject = txtTieuDe.Text;
            msg.Body = txtTinNhan.Text;
            msg.IsBodyHtml = true;
            if (FileUpload1.HasFile)
            {
                msg.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential(txtEmailGui.Text, txtPassWord.Text);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
                Session["action"] = 4;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

     

    }
}