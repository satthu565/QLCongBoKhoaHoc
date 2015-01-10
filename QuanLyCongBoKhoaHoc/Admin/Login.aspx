<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Đăng nhập hệ thống</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/maruti-login.css" />
    <script src="../js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div id="loginbox">
            <div class="control-group normal_text">
                <h4>Đăng nhập hệ thống</h4>
            </div>
            <div class="control-group">
                <div class="controls">
                    <div class="main_input_box">
                        <span class="add-on"><i class="glyphicon glyphicon-user"></i></span>
                        <asp:TextBox ID="txtTenDangNhap" runat="server" placeholder="Username" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="dn" runat="server"
                            ControlToValidate="txtTenDangNhap" ErrorMessage="*" ForeColor="Red" Font-Bold="true"
                            ToolTip="Bạn chưa nhập tên đăng nhập"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="control-group password">
                <div class="controls">
                    <div class="main_input_box">
                        <span class="add-on"><i class="glyphicon glyphicon-lock"></i></span>
                        <asp:TextBox ID="txtMatKhau" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="dn" runat="server"
                            ControlToValidate="txtMatKhau" ErrorMessage="*" ForeColor="Red" Font-Bold="true"
                            ToolTip="Bạn chưa nhập mật khẩu"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="remember">
                <asp:CheckBox ID="cbNhoMatKhau" runat="server" Text="Nhớ mật khẩu" />
            </div>

            <div class="control-group">
                <div class="controls">
                    <asp:Button ID="btDangNhap" runat="server" CssClass="btn btn-info" ValidationGroup="dn"
                        Text="Đăng nhập" OnClick="btDangNhap_Click" />
                    <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
  Quên mật khẩu
</button>

                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="H1">Lấy lại mật khẩu </h4>
                                </div>
                                <div class="modal-body">
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" Display="Dynamic" Font-Size="8pt">
	                <br  />* Bạn chưa nhập email</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator2"
                                        runat="server"
                                        ControlToValidate="txtEmail"
                                        Display="Dynamic"
                                        Font-Size="8pt"
                                        SetFocusOnError="True"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> <br>*Email chưa hợp lệ
                                    </asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textForm" Width="282px" />
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    <asp:Button Text="Gửi" ID="btnGuiLayMatKhau" runat="server" class="btn btn-primary" OnClick="btnGuiLayMatKhau_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
          

        </div>
    </form>


</body>
</html>

<script src="../js/bootstrap.min.js"></script>


