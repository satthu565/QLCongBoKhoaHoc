<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuNgang.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.MenuNgang" %>

<nav class="navbar navbar-default" style="background-color:#4A72B8 !important;min-height: 44px !important;height: 45px !important;"  role="navigation" id="Menu">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" style="background-color:#4A72B8;text-transform: uppercase;font-size: 12px;margin-left:3px!important" rel="nofollow" href="/">Trang chủ</a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1" style="font-size:13px">
            <ul class="nav navbar-nav cf">      
                <% MenuDong(0); %>
               
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>


