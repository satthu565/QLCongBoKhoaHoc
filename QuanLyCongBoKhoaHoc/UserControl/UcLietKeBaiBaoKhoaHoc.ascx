 <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcLietKeBaiBaoKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcLietKeBaiBaoKhoaHoc" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>

<h2 style="text-align:center ; font-weight:bold ; font-size:20px; "> LIỆT KÊ BÀI BÁO KHOA HỌC</h2>

<div class="row" style="text-align:center">
    <b> Tìm kiếm Bài báo </b>
    <asp:DropDownList ID="ccbGioiHan" runat="server" >
    <asp:ListItem Value="True">Trong nước</asp:ListItem>
    <asp:ListItem Value="False">Quốc tế</asp:ListItem>
    </asp:DropDownList>

     <b>  Năm xuất bản : </b>
     <asp:TextBox ID="txtNamXuatBan" runat="server"></asp:TextBox>

     <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary" OnClick="btnTimKiem_Click" />
</div>
<hr />

  <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
               <div class="row" style="margin-bottom:3px;">
                 <div class="col-md-12 ">  
                        <p>   
                           <i> Bài báo  <%# GioiHan(Eval("GioiHan").ToString())%> : <b><%# Eval("TenBaiBao") %> </b> 
                           <i> Tác giả: </i> <b>  <%# ChuoiTenTacGia(Eval("ChuoiMaGiangVienTacGia").ToString() )%>,<%#Eval("TenTacGiaNgoai") %> </b>
                           <i> Nơi công bố :</i>  <b>  <%# Eval("NoiCongBo") %> </b>
                           <i> Mã số: </i> <b> <%#Eval("MaSo") %>  </b>
                           <i> Năm: </i>  <b> <%# String.Format("{0:dd/MM/yyyy}",Eval("ThoiGianXuatBan")) %>  </b>
                        </p>
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