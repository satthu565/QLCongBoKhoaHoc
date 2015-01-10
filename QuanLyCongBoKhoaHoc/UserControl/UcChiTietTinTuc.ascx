<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcChiTietTinTuc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcChiTietTinTuc" %>

<h1><% Response.Write(TinTuc.TieuDe); %></h1>
<div class="media">
    <a class="pull-left" href="#" rel="nofollow">
        <% if (TinTuc.AnhDaiDien != "") Response.Write("<img style=\"width:90px ; height:90x;\" src=\"/../../images/TinTuc/" + TinTuc.AnhDaiDien + "\">");%> 
    </a>
    <div class="media-body">
        <% Response.Write(TinTuc.MoTa); %>
    </div>
</div>

<div class="noi-dung">
    <% Response.Write(HttpUtility.HtmlDecode(TinTuc.NoiDung)); %>
</div>
