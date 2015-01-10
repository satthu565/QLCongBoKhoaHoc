<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="CuoiHoi.Admin.Home1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="vi-vn" lang="vi-vn">
<head id="Head1" runat="server">
    <meta  charset="utf-8"/>
    <title>Trang Chu</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../flaty/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../flaty/assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../flaty/css/flaty-responsive.css" rel="stylesheet" />
    <link href="../flaty/css/flaty.css" rel="stylesheet" />
    <link href="../css/styleAdmin.css" rel="stylesheet" />
    <meta name="description" content="The description of my page" />
    <script src="../js/jquery.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="navbar" class="navbar">
                <button type="button" class="navbar-toggle navbar-btn collapsed" data-toggle="collapse"
                    data-target="#sidebar">
                    <span class="icon-reorder"></span>
                </button>
                <a class="navbar-brand" href="#">
                    <small>
                        <i class="glyphicon glyphicon-globe"></i>
                        <b>TRANG QUẢN TRỊ</b>
                    </small>
                </a>
                <%-- Bên phải phần Header --%>
                <ul class="nav flaty-nav pull-right">
                    <li class="user-profile">
                        <a data-toggle="dropdown" href="#" class="user-menu dropdown-toggle">
                            <img src="../../flaty/img/demo/avatar/avatar1.jpg" class="nav-user-photo" />
                            <span id="user_info"><b runat="server" id="txtTenNguoiDung">Admin</b>
                            </span>
                            <i class="icon-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu dropdown-navbar" id="user_menu">
                            <li class="nav-header">
                                <i class="icon-time"></i>
                                Đăng nhập lúc <%# DateTime.Now %>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="icon-cog"></i>
                                    Cá nhân
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="icon-question"></i>
                                    Thông tin
                                </a>
                            </li>
                            <li>
                                <asp:LinkButton ID="btThoat" runat="server" OnClick="btThoat_Click">                                
                                    <i class="icon-off"></i>
                                    Logout
                            </asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
            <%-- End header--%>

            <div class="container" id="main-container">
                <%-- Phần sidebar bên trái --%>
                <div id="sidebar" class="navbar-collapse collapse">
                    <ul class="nav nav-list">
                   
                        <li id="QLHeThong">
                            <a href="#" class="dropdown-toggle">
                                <i class="icon-user"></i>
                                <span>QL Tin Tức</span>
                                <b class="arrow icon-angle-right"></b>
                            </a>
                            <ul class="submenu">
                                <li>
                                    <a href="#">Quản lý tin tức </a>
                                </li>
                                <li>
                                    <a href="#">Viết bài </a>
                                </li>
                            </ul>
                        </li>

                        <li>
                            <a href="#" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>QL Album Ảnh </span>
                                <b class="arrow icon-angle-right"></b>
                            </a>
                            <ul class="submenu">
                                <li>
                                    <a href="#">Quản lý </a>
                                </li>
                                <li>
                                    <a href="#">Thêm Album </a>
                                </li>
                            </ul>
                        </li>

                   

                        <li>
                            <a href="#" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>QL Thể Loại </span>
                            </a>

                        </li>
                        <li>
                            <a href="#" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>QL Slide </span>
                            </a>

                        </li>
                    </ul>
                    <div id="sidebar-collapse" class="visible-lg">
                        <i class="icon-double-angle-left"></i>
                    </div>
                </div>

                <%-- Phần nội dung chính --%>
                <div id="main-content">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
        <div id="Info">
            <div id="noidung">
                <label></label>
            </div>
        </div>
    </form>
 
    <script src="../flaty/assets/bootstrap/js/bootstrap.min.js"></script>
 
    <script src="../flaty/assets/jquery-cookie/jquery.cookie.js"></script>
    <script src="../flaty/assets/nicescroll/jquery.nicescroll.min.js"></script>
    <script src="../flaty/js/flaty.js"></script>
    <script src="../js/xuly.js"></script>

    <script type="text/javascript">
        var action ='<%= Session["action"] == null ? "" :  Session["action"].ToString() %>' 
        if (action != '')
        {
            $('#Info').css('display','block')

            if (action=='1')
                $('#Info').find('label').html("Thêm thành công")
            else
            if (action=='2')
                $('#Info').find('label').html("Sửa thành công")
            else
            if (action=='3')
                $('#Info').find('label').html("Xóa thành công")

            $( "#Info" ).animate({
                bottom: 50,
                opacity: 0
            }, 4000);
           
        }

        <%  if (Session["action"] != null) Session["action"] = null;%> 
    </script>
</body>
</html>
