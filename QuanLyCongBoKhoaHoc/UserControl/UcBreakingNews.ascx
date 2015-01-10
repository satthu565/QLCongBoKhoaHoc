<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcBreakingNews.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcBreakingNews" %>

<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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