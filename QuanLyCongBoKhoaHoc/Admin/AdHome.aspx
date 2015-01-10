<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdHome.aspx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdHome" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta  charset="utf-8"/>
    <title>Trang Chu</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../flaty/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../flaty/assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../flaty/css/flaty-responsive.css" rel="stylesheet" />
    <link href="../flaty/css/flaty.css" rel="stylesheet" />
    <link href="../css/styleAdmin.css" rel="stylesheet" />
    <link href="../flaty/assets/bootstrap-datepicker/css/datepicker.css" rel="stylesheet" />
    <script src="../flaty/assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
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
                            <asp:Image ImageUrl="../../flaty/img/demo/avatar/avatar1.jpg" runat="server" ID="AnhDaiDienNho" class="nav-user-photo"  />
                           
                              <%--<img src="../../flaty/img/demo/avatar/avatar1.jpg" class="nav-user-photo" />--%>
                            <span id="user_info"><b runat="server" >
                                <asp:Label  ID="lbTenNguoiDung" runat="server" /></b>
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
                                <asp:LinkButton ID="btThoat" runat="server" OnClick="btThoat_Click" >                                
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
                                <span>Quản lý thông tin</span>
                                <b class="arrow icon-angle-right"></b>
                            </a>
                            <ul class="submenu">
                                <li>
                                    <a href="/Admin/TTCN">Thông tin cá nhân</a>
                                </li>
                              
                                <li>
                                    <a href="/Admin/QLTK">Quản lý Tài khoản</a>
                                </li>
                            </ul>
                        </li>

                         <li <% if (PhanQuyen(2)==false) Response.Write("style=display:none"); %>>
                            <a href="/Admin/QLQTCT" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                 <span>Quá trình công tác </span>    
                            </a>               
                        </li>

                        <li <% if (PhanQuyen(3)==false) Response.Write("style=display:none"); %>>
                            <a href="/Admin/QLCBKH" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                 <span>Công bố khoa học </span>     
                            </a>            
                        </li>

                         <li <% if (PhanQuyen(4)==false) Response.Write("style=display:none"); %>>
                            <a href="/Admin/QLBBKH" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>Bài báo khoa học </span>  
                            </a>           
                        </li>

                        <li <% if (PhanQuyen(5)==false) Response.Write("style='display:none'"); %>>
                            <a href="/Admin/QLSXB">
                                <i class="icon-book"></i>
                                <span>Sách xuất bản</span>
                            </a>       
                        </li>

                        <li <% if (PhanQuyen(6)==false) Response.Write("style='display:none'"); %>>
                            <a href="/Admin/DTHVCH" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>Sau đại học</span>
                            </a>
                        </li>
                   
                        <li <% if (PhanQuyen(7)==false) Response.Write("style='display:none'"); %>>
                            <a href="#" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span> Khen thưởng </span>
                                 <b class="arrow icon-angle-right"></b>
                            </a>
                             <ul class="submenu">
                                <li>
                                    <a href="/Admin/GTKH">Giải thưởng khoa học</a>
                                </li>
                                <li>
                                    <a href="/Admin/KT">Khen thưởng</a>
                                </li>
                            </ul>
                        </li>

                        <li <% if (PhanQuyen(8)==false) Response.Write("style='display:none'"); %>>
                            <a href="/Admin/QLS" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>Quản lý Slide </span>
                            </a>
                        </li>

                        <li <% if (PhanQuyen(9)==false) Response.Write("style='display:none'"); %>>
                            <a href="/Admin/QLM" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>Quản lý Menu</span>
                            </a>
                        </li>

                        <li <% if (PhanQuyen(10)==false) Response.Write("style='display:none'"); %>>
                            <a href="/Admin/TNLH" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>Tin nhắn liên hệ</span>
                            </a>
                        </li>

                         <li <% if (PhanQuyen(11)==false) Response.Write("style='display:none'"); %>>
                            <a href="#" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>Quản lý Quyền</span>
                                 <b class="arrow icon-angle-right"></b>
                            </a>
                             <ul class="submenu">
                                <li>
                                    <a href="/Admin/QLQ">Quản lý Quyền</a>
                                </li>
                                <li>
                                    <a href="/Admin/DMQ">Danh mục quyền</a>
                                </li>
                            </ul>
                        </li>

                        <li <% if (PhanQuyen(12)==false) Response.Write("style='display:none'"); %>>
                            <a href="/Admin/QLGV" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>Quản lý giảng viên</span>
                            </a>
                        </li>

                         <li <% if (PhanQuyen(13)==false) Response.Write("style='display:none'"); %>>
                            <a href="#" class="dropdown-toggle">
                                <i class="icon-book"></i>
                                <span>Các thông tin khác</span>
                                 <b class="arrow icon-angle-right"></b>
                            </a>
                             <ul class="submenu">
                                <li>
                                    <a href="/Admin/Khoa">Khoa</a>
                                </li>
                                <li>
                                    <a href="/Admin/CapDeTai">Cấp đề tài</a>
                                </li>
                                <li>
                                    <a href="/Admin/ChucVu">Chức vụ</a>
                                </li>
                                 <li>
                                    <a href="/Admin/HocVi">Học vị</a>
                                </li>
                            </ul>
                        </li>

                           <li <% if (PhanQuyen(14)==false) Response.Write("style='display:none'"); %>>
                            <a href="#" class="dropdown-toggle">
                                <i class="icon-user"></i>
                                <span>QL Tin Tức</span>
                                <b class="arrow icon-angle-right"></b>
                            </a>
                            <ul class="submenu">
                                <li>
                                    <a href="/Admin/QLTinTuc">Quản lý tin tức </a>
                                </li>
                                <li>
                                    <a href="/Admin/VietBai">Viết bài </a>
                                </li>
                            </ul>
                        </li>




                       </ul>
                    <div id="sidebar-collapse" class="visible-lg">
                        <i class="icon-double-angle-left"></i>
                    </div>
                </div>

                <%-- Phần nội dung chính --%>
                <div id="main-content">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <h1 style="text-align:center">Chào Mừng Bạn Đến Với Trang Quản Trị</h1>
                    </asp:PlaceHolder>
                </div>
            </div>
         <div id="Info">
            <div id="noidung">
                <label></label>
            </div>
        </div>
   </div>
</form>
 
    <script src="../../ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../flaty/assets/jquery/jquery-2.0.3.min.js"><\/script>')</script>
    <script src="../flaty/assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="../flaty/assets/nicescroll/jquery.nicescroll.min.js"></script>
    <script src="../flaty/assets/jquery-cookie/jquery.cookie.js"></script>
    <script type="text/javascript" src="../flaty/assets/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../flaty/assets/jquery-validation/dist/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../flaty/assets/jquery-validation/dist/additional-methods.min.js"></script>
    <script src="../flaty/js/flaty.js"></script>
    <script src="../flaty/js/flaty-demo-codes.js"></script>
    <script src="../js/xuly.js"></script>


    <script type="text/javascript">
        var action = '<%= Session["action"] == null ? "" :  Session["action"].ToString() %>'
        if (action != '') {
            $('#Info').css('display', 'block')

            if (action == '1')
                $('#Info').find('label').html("Thêm thành công")
            else
                if (action == '2')
                    $('#Info').find('label').html("Sửa thành công")
                else
                    if (action == '3')
                        $('#Info').find('label').html("Xóa thành công")
                    else
                        if (action == '4')
                            $('#Info').find('label').html("Gửi mail thành công")

            $("#Info").animate({
                bottom: 50,
                opacity: 0
            }, 4000);
        }

        <%  if (Session["action"] != null) Session["action"] = null;%> 

     
    </script>
</body>
</html>
