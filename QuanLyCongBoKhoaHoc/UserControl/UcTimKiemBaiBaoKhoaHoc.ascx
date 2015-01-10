<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTimKiemBaiBaoKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcTimKiemBaiBaoKhoaHoc" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>

<h3 style="text-align:center" >TÌM KIẾM BÀI BÁO KHOA HỌC</h3>

<form class="form-horizontal" role="form">
     <div class="form-group">
             <label for="inputEmail3" class="col-sm-4 control-label"> Nhập tên bài báo cần tìm : </label>
        <div class="col-sm-6">
             <input id="txtTenBaiBao" runat="server" type="text" class="form-control col-lg-4" placeholder="Nhập tên bài báo tìm kiếm">   
        </div>
        <div class="col-sm-2">
             <asp:Button ID="btnTimKiem" CssClass="btn btn-primany" runat="server" Text="Tìm kiếm" OnClick="btnTimKiem_Click" />
        </div>
    </div>
</form>
<br />
<hr />
    <h3 style="text-align:center">KẾT QUẢ TÌM KIẾM</h3>
  <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
               <div class="row" style="margin-bottom:3px;">
                 <div class="col-md-11 col-md-offset-1 ">
                      <b>  Bài báo  <%# GioiHanBaiBao(bool.Parse( Eval("GioiHan").ToString() )) %> - <%# Eval("TenBaiBao") %> </b> <br /> 
                      <b>  Chủ nhiệm : </b> <%# ChuoiTacGia(Eval("ChuoiMaGiangVienTacGia").ToString() ) %> 
                      <b>  Mã số : </b> <%# Eval("MaSo") %>
                      <b>  Nơi công bố :</b> <%# Eval("NoiCongBo") %>
                      <b>  Thời gian xuất bản :</b> <%# String.Format("{0:dd/MM/yyyy}",Eval("ThoiGianXuatBan").ToString()) %>
                 </div>
               </div>
            </ItemTemplate>
  </asp:Repeater>

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