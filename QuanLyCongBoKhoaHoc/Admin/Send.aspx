<%@ Page language="c#" Codebehind="Send.aspx.cs" AutoEventWireup="false" Inherits="MailWebService.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
		TD { FONT-SIZE: 10pt; COLOR: #000000; FONT-STYLE: normal; FONT-FAMILY: Arial, Helvetica, sans-serif }
		.width386 { WIDTH: 386px }
		.basic { FONT-SIZE: 10pt; COLOR: #000000; FONT-STYLE: normal; FONT-FAMILY: Arial, Helvetica, sans-serif }
		.titl { FONT-WEIGHT: bold; FONT-SIZE: 13pt; COLOR: #ffffff; FONT-STYLE: normal; FONT-FAMILY: Arial, Helvetica, sans-serif }
		BODY { BORDER-RIGHT: 0px; BORDER-TOP: 0px; BACKGROUND: white; MARGIN: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px; FONT-FAMILY: Arial, Helvetica, sans-serif }
		</style>
	</HEAD>
	<body>
		<table cellSpacing="0" cellPadding="3" width="100%" bgColor="navy" border="0">
			<tr>
				<td align="center"><span class="titl">ASP.NET&nbsp;Email</span></td>
			</tr>
		</table>
		<br>
		<div align="center"><asp:Label id="lblMessage" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="540"
				Visible="False"></asp:Label></div>
		<br>
		<div align="center">
			<form id="Form1" name="form2" method="post" encType="multipart/form-data" runat="server">
				<table cellSpacing="0" cellPadding="4" bgColor="navy" border="0">
					<tr>
						<td>
							<table cellSpacing="3" cellPadding="4" width="540" bgColor="white">
								<tr>
									<td vAlign="middle" align="right" width="80">From:</td>
									<td><asp:textbox id="txtSender" tabIndex="1" runat="server" MaxLength="100" Width="386px" CssClass="width386"
											Font-Size="X-Small" Font-Names="Arial"></asp:textbox></td>
								</tr>
								<tr>
									<td vAlign="middle" align="right" width="80">To:</td>
									<td><asp:textbox id="txtReceiver" tabIndex="1" runat="server" MaxLength="100" Width="386px" CssClass="width386"
											Font-Size="X-Small" Font-Names="Arial"></asp:textbox></td>
								</tr>
								<tr>
									<td vAlign="middle" align="right">Subject:</td>
									<td><asp:textbox id="txtSubject" tabIndex="2" runat="server" MaxLength="200" Width="386px" CssClass="width386"
											Font-Size="X-Small" Font-Names="Arial"></asp:textbox></td>
								</tr>
								<tr>
									<td vAlign="middle" align="right">Format:</td>
									<td><asp:radiobuttonlist id="rblMailFormat" tabIndex="3" runat="server" repeatcolumns="2" repeatdirection="Horizontal">
											<asp:ListItem Value="text" Selected="True">text</asp:ListItem>
											<asp:ListItem Value="html">html</asp:ListItem>
										</asp:radiobuttonlist></td>
								</tr>
								<tr>
									<td vAlign="top" align="right">Message:</td>
									<td height="84">
										<p><asp:textbox id="txtBody" tabIndex="4" runat="server" columns="40" rows="5" textmode="MultiLine"
												width="451px" CssClass="width386" Font-Size="X-Small" Font-Names="Arial"></asp:textbox></p>
									</td>
								</tr>
								<tr>
									<td vAlign="middle" align="right">Attachment:</td>
									<td><input id="ofdAttachment1" tabIndex="5" type="file" size="56" name="filMyFile" runat="server"></td>
								</tr>
								<tr>
									<td vAlign="middle" align="right">Attachment:</td>
									<td><input id="ofdAttachment2" tabIndex="6" type="file" size="56" name="filMyFile" runat="server"></td>
								</tr>
								<tr>
									<td vAlign="middle" align="right">Attachment:</td>
									<td><input id="ofdAttachment3" tabIndex="7" type="file" size="56" name="filMyFile" runat="server"></td>
								</tr>
								<tr>
									<td align="center" colSpan="2"><asp:button id="btnSend" tabIndex="9" runat="server" width="100px" text="Send"></asp:button></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</form>
			<h1></h1>
			<br>
			<br>
			<br>
			<br>
			<br>
		</div>
	</body>
</HTML>
