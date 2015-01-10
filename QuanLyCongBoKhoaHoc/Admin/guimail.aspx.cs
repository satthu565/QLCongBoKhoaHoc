using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCongBoKhoaHoc.Admin
{
    public partial class guimail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from.Text, "email");
            msg.To.Add(new MailAddress(to.Text));
            msg.Subject = chude.Text;
            msg.Body = tinnhan.Text;
            msg.IsBodyHtml=true;
            if (FileUpload1.HasFile)
	{
		 msg.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream,FileUpload1.FileName));
	}
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential(from.Text,pass.Text);
            thongbao.Visible=true;
            smtp.EnableSsl=true;
            try 
	{	        
		smtp.Send(msg);
                thongbao.Text = "thanh cong";
	}
	catch (Exception ex)
	{
		thongbao.Text = ex.Message;
	}
        }

}
}

