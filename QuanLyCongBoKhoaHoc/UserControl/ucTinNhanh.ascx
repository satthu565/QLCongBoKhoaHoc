<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTinNhanh.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.ucTinNhanh" %>
<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Slides.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.Slides" %>--%>

<div class="row breaking-news isscrolling">
    <div class="line-horizontal"></div>
    <div class="breaking-title">
        <span class="fa fa-bullhorn">&nbsp</span>
        <b>Tin Trong Ngày</b>
        <div class="the-corner"></div>
    </div>
    <div class="breaking-block">
      <marquee direction=right behavior=alternate  onmouseover="this.stop();" onmouseout="this.start();" scrollamount=5> 
          <asp:label text="" ID="lbTinMoi" runat="server" />
      </marquee>

    </div>
    <div class="breaking-controls">
        <div class="clear-float"></div>
        <div class="the-corner"></div>
    </div>
</div>


   