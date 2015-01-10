<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTimKiemGiangVien.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcTimKiemGiangVien" %>

<h4 style="text-align:center">TÌM KIẾM GIẢNG VIÊN</h4>

<asp:UpdatePanel runat="server">
    <ContentTemplate>

<form class="form-horizontal" role="form">
     <div class="form-group">
             <label for="inputEmail3" class="col-sm-4 control-label"> Nhập tên giảng viên cần tìm kiếm : </label>
        <div class="col-sm-6">
             <input id="txtTimTenGiangVien" runat="server" type="text" class="form-control col-lg-4" placeholder="Nhập họ tên giảng viên cần tìm kiếm">   
        </div>
        <div class="col-sm-2">
             <asp:Button ID="btnTimKiemGiangVien" CssClass="btn btn-primany" runat="server" Text="Tìm kiếm" OnClick="btnTimKiemGiangVien_Click" />
        </div>
    </div>
</form>

<br />
<hr />

<h4 style="text-align:center">KẾT QUẢ TÌM KIẾM GIẢNG VIÊN</h4>

<div class="wrap-khung row">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="khung col-md-4" style="min-height: 388px;">
                <div style="padding-top: 20px; border: 1px solid #A9A7A7; border-style: dotted; box-shadow: 10px 10px 5px #e9e9e9; border-radius: 5px">
                    <div class="row" style="text-align: center"><a href="/CV-Giang-Vien/TTC/<%#Eval("MaGiangVien") %>">
                        <img src="/images/AnhGiangVien/<%#Eval("AnhDaiDien") %>" alt="Ảnh đại diện" width="195px" height="185px" style="border-radius: 5px" />
                    </a></div>
                    <div class="row button-detail">
                        <a class="box-left pull-left ">
                            <i class="fa fa-heart fa-lg "></i>
                        </a>
                        <a class="box-right pull-right animate ">
                            <i class="fa fa-refresh fa-lg"></i>
                        </a>
                        <a href="/CV-Giang-Vien/TTC/<%#Eval("MaGiangVien") %>" class="btn btn-default btn-add btn-add-cart btn-icon icon-cart glyphicon glyphicon-search" style="padding-top: 4px; padding-left: 0px; width: auto; font-size: 11px;">
                            <span style="position: relative; left: 6px; top: 6px; font-size: 12px; font-weight: bold; font-family: normal">Lý lịch chi tiết</span>
                        </a>
                    </div>
                    <div class="wrap-content-view">
                        <div class="row"><b><%# Eval("TenHocVi") %>.<%# Eval("TenGiangVien") %></b></div>
                        <div class="row"><b>Khoa : </b><%# Eval("TenKhoa") %>  </div>
                        <div class="row"><b>Số điện thoại : </b><%# Eval("DienThoai") %> </div>
                        <div class="row"><b>Email : </b><%# Eval("Email") %> </div>
                    </div>
              
                    <div class="Line"></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
       <div style="overflow: hidden; text-align: center; margin: 5px auto; clear: both" class="phantrang">
            <asp:Repeater ID="rptPages" runat="server"
                OnItemCommand="rptPages_ItemCommand1" OnItemDataBound="rptPages_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton ID="btnPage" Text="<%# Convert.ToInt32(Container.DataItem) %>"
                        Style="padding: 1px 3px; margin: 1px; background: #ccc; border: solid 1px #666; font: 8pt tahoma;"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                        runat="server"><%# Container.DataItem %></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        </ContentTemplate>
</asp:UpdatePanel>
  