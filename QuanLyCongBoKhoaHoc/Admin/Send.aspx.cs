using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace MailWebService
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButtonList rblMailFormat;
		protected System.Web.UI.WebControls.Button btnSend;
		protected System.Web.UI.HtmlControls.HtmlInputFile ofdAttachment1;
		protected System.Web.UI.HtmlControls.HtmlInputFile ofdAttachment2;
		protected System.Web.UI.HtmlControls.HtmlInputFile ofdAttachment3;
		protected System.Web.UI.WebControls.TextBox txtSender;
		protected System.Web.UI.WebControls.TextBox txtReceiver;
		protected System.Web.UI.WebControls.TextBox txtSubject;
		protected System.Web.UI.WebControls.TextBox txtBody;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected string strFileName;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Create a new blank MailMessage
				MailMessage email = new MailMessage ();


				// Set the properties of the MailMessage to the
				// values on the form
				if (rblMailFormat.SelectedItem.Text == "text")
					email.BodyFormat = MailFormat.Text;
				else
					email.BodyFormat = MailFormat.Html;
				email.From = txtSender.Text;
				email.To = txtReceiver.Text;
				email.Subject = txtSubject.Text;
				email.Body = txtBody.Text;
            

				// We use the 3 following variables to keep track of
				// attachments so we can delete them and strFileName is
				// used to for the name of the file attachment being 
				// processed.
				string attach1 = null;
				string attach2 = null;
				string attach3 = null;
				string strFileName = null;

				// Beginning of attachments processing
				// Check the first open file dialog for a value
				if (ofdAttachment1.PostedFile != null)
				{
					// Get a reference to PostedFile object
					HttpPostedFile ulFile = ofdAttachment1.PostedFile;
					// Get size of the file
					int nFileLen = ulFile.ContentLength; 
					// Make sure the size of the file is > 0
					if( nFileLen > 0 )
					{
						// Get the file name
						strFileName = Path.GetFileName(ofdAttachment1.PostedFile.FileName);
						// Preced the file name with "attachments/" so 
						// the file is saved to our attachments directory
						strFileName = "attachments/" + strFileName;
						// Save the file on the server
						ofdAttachment1.PostedFile.SaveAs(Server.MapPath(strFileName));
						// Create the email attachment with the uploaded file
						MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
						// Attach the newly created email attachment
						email.Attachments.Add(attach);
						// Store filename so we can delete it later
						attach1 = strFileName;
					}
				}
				// Repeat previous step if there is an attachment #2
				if (ofdAttachment2.PostedFile != null)
				{
					HttpPostedFile ulFile = ofdAttachment2.PostedFile;
					int nFileLen = ulFile.ContentLength; 
					if( nFileLen > 0 )
					{
						strFileName = Path.GetFileName(ofdAttachment2.PostedFile.FileName);
						strFileName = "attachments/" + strFileName;
						ofdAttachment2.PostedFile.SaveAs(Server.MapPath(strFileName));
						MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
						email.Attachments.Add(attach);
						attach2 = strFileName;
					}
				}
				// Repeat previous step if there is an attachment #3
				if (ofdAttachment3.PostedFile != null)
				{
					HttpPostedFile ulFile = ofdAttachment3.PostedFile;
					int nFileLen = ulFile.ContentLength; 
					if( nFileLen > 0 )
					{
						strFileName = Path.GetFileName(ofdAttachment3.PostedFile.FileName);
						strFileName = "attachments/" + strFileName;
						ofdAttachment3.PostedFile.SaveAs(Server.MapPath(strFileName));
						MailAttachment attach = new MailAttachment(Server.MapPath(strFileName));
						email.Attachments.Add(attach);
						attach3 = strFileName;
					}
				}
				// End of attachments processing
            
				// Set the SMTP server and send the email
				SmtpMail.SmtpServer = "localhost";
				SmtpMail.Send (email);

				// Delete the attachements if any
				if (attach1 != null)
					File.Delete(Server.MapPath(attach1));
				if (attach2 != null)
					File.Delete(Server.MapPath(attach2));
				if (attach3 != null)
					File.Delete(Server.MapPath(attach3));	

				// Reset the form
				txtSender.Text = "";
				txtReceiver.Text = "";
				txtSubject.Text = "";
				txtBody.Text = "";

                // Dispaly a friendly message telling the user
				// his email has been sent
				lblMessage.Visible = true;
				lblMessage.ForeColor = Color.Black;
				lblMessage.Text = "Your email has been sent";
			}
			catch(Exception ex)
			{
				// Print a much less friendly message informing the 
				// user about the exception that was risen
				lblMessage.Visible = true;
				lblMessage.ForeColor = Color.Red;
				lblMessage.Text = ex.ToString();
			}
			
		}

	}
}
