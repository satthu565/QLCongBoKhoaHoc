<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuDoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.MenuDoc" %>

<script src="../../js/bootstrap.js"></script>
<%--<script src="../js/jquery-1.8.3.min.js"></script>--%>
<link href="../../css/font-awesome.min.css" rel="stylesheet" />
<link href="../../css/font-awesome.css" rel="stylesheet" />
<div class="right-content">
    <div class="categories">
        <ul class="list-group2">
            <li class="list-group-item active">
                <a href="#">
                    <div class="category-icon">
                        <i class="fa fa-bars fa-lg"></i>
                    </div>
                    <div class="category-info">
                        <p>DANH MỤC</p>
                    </div>
                </a>
            </li>
            <li class="list-group-item category-item category-item-before ">
                <a href="/Liet-ke/LKCBKH">
                    <div class="category-icon">
                        <i class="fa fa-gamepad fa-2x"></i>
                    </div>
                    <div class="category-info">
                        <p class="titleCT">Công trình khoa học</p>
                        <p class="infoCT">Các công bố khoa học</p>
                    </div>
                </a>
            </li>
            <li class="list-group-item category-item">
                <a href="/Liet-ke/LKBBKH">
                    <div class="category-icon">
                        <i class="fa fa-android fa-2x"></i>
                    </div>
                    <div class="category-info">
                        <p class="titleCT">Bài Báo Khoa Học</p>
                        <p class="infoCT">Các bài báo khoa học</p>
                    </div>
                </a>
            </li>
            <li class="list-group-item category-item">
                <a href="/Liet-ke/LKSGT">
                    <div class="category-icon">
                        <i class="fa fa-female fa-2x"></i>
                    </div>
                    <div class="category-info">
                        <p class="titleCT">Sách Khoa học</p>
                        <p class="infoCT"> Các sách khoa học</p>
                    </div>
                </a>
            </li>
            <li class="list-group-item category-item">
                <a href="/Tim-kiem/TKGV">
                    <div class="category-icon">
                        <i class="fa fa-book fa-2x"></i>
                    </div>
                    <div class="category-info">
                        <p class="titleCT">Tìm kiếm giảng viên</p>
                        <p class="infoCT">Tìm giảng viên</p>
                    </div>
                </a>
            </li>
            <li class="list-group-item category-item">
                <a href="/">
                    <div class="category-icon">
                        <i class="fa fa-music fa-2x"></i>
                    </div>
                    <div class="category-info">
                        <p class="titleCT">Thống Kê</p>
                        <p class="infoCT">Thống kê chi tiết</p>
                    </div>
                </a>
            </li>
            <li class="list-group-item category-item category-item-after">
                <a href="">
                    <div class="category-icon">
                        <i class="fa fa-comments fa-2x"></i>
                    </div>
                    <div class="category-info">
                        <p class="titleCT">Báo Cáo</p>
                        <p class="infoCT">Báo cáo chi tiết</p>
                    </div>
                </a>
            </li>
        </ul>
    </div>
    <div class="row">
        <div class="col-sm-12 best-seller" style="padding-right:0px">
            <ul class="nav nav-tabs title">
                <li class="active">
                    <a href="#tab-star" class="star" data-toggle="tab">
                        <i class="fa fa-star fa-lg"></i>
                    </a>
                </li>
                <li>
                    <a href="#tab-best-seller" class="best" data-toggle="tab">Sách Và Giáo Trình 
                    </a>
                </li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane fade in active" id="tab-star">
                    <asp:Repeater runat="server" ID="rptSach">
                        <ItemTemplate>
                            <div class="row star-item">
                                <div class="img-star">
                                    <img src="../../images/star-1-1.png" alt="star1">
                                </div>
                                <div class="info-star">
                                    <a href="#" class="name"><%# Eval("TenSach") %></a>
                                    <p class="price"><%# Eval("TenGiangVien") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!-- end. star-item-->
                </div>
                <div class="tab-pane fade in" id="tab-best-seller">
                    tab best-seller
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-sm-12 client" style="padding-right:0px">
            <div class="title-client">
                <div class="icon col-md-3 col-xs-3">
                    <i class="fa fa-microphone fa-lg"></i>
                </div>
                <div class="client-name col-md-9 col-xs-9">
                    <p>Giảng Viên</p>
                </div>
            </div>
            <div class="slide" id="client">
                <div class="carousel-button">
                    <a href="#client" data-slide="next" style="float: right; position: absolute; top: 13px; right: 10px;" class="left">
                        <div class="botton-client">
                            <i class="fa fa-angle-right fa-1"></i>
                        </div>
                    </a>
                    <a href="#client" data-slide="prev" class="right" style="float: right; position: absolute; top: 13px; right: 30px;">
                        <div class="botton-client">
                            <i class="fa fa-angle-left fa-1"></i>
                        </div>
                    </a>
                </div>
                <div class="carousel-inner">
                 <%--   <asp:Label ID="lbGiangVien" runat="server" Text="Label"></asp:Label>--%>
                 <%--   <div class="item active">
                        <div class="row">
                            <div class="content-client">
                                <div class="mid-content">
                                    <p>Là một giảng viên xuất sắc của trường đại học điện lực. Luôn tham gia vào các công trình lớn của trường, cũng như của tập đoàn.  </p>
                                </div>
                                <hr>
                                <div class="footer-content">
                                    <div class="client-img">
                                        <img src="../../img/client-img.png" alt="client-img">
                                    </div>
                                    <div class="client-info">
                                        <p class="name">Nguyễn Hữu A</p>
                                        <p class="excerpt">Khoa CNTT</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <% Response.Write(LoadGiangVien().ToString());  %>

                 <%--   <div class="item">
                        <div class="row">
                            <div class="content-client">
                                <div class="mid-content">
                                    <p>Là một giảng viên xuất sắc của trường đại học điện lực. Luôn tham gia vào các công trình lớn của trường, cũng như của tập đoàn. </p>
                                </div>
                                <hr>
                                <div class="footer-content">
                                    <div class="client-img">
                                        <img src="../img/client-img2.png" alt="client-img">
                                    </div>
                                    <div class="client-info">
                                        <p class="name">Nguyễn Thị Thu</p>
                                        <p class="excerpt">Khoa CNTT</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                </div>
            </div>
        </div>
    </div>
</div>
