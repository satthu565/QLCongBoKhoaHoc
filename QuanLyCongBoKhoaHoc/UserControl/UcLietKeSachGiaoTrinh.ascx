<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcLietKeSachGiaoTrinh.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcLietKeSachGiaoTrinh" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
<h2 style="text-align:center"> LIỆT KÊ SÁCH GIÁO TRÌNH</h2>
        <div class="row" style="text-align: center ;font-weight: bold; font-size: 20px;">
            <b>Nhà xuất bản : </b>
            <asp:TextBox ID="txtNhaXuatBan" runat="server" />  

            <b>Năm xuất bản : </b>
                <asp:TextBox ID="txtNamXuatBan" runat="server"></asp:TextBox>

            <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm"  CssClass="btn btn-primary" OnClick="btnTimKiem_Click" />
        </div>
<hr />

  <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
               <div class="row" style="margin-bottom:3px;">
                 <div class="col-md-12">  
                        <p>   
                           <b><%# Eval("TenSach") %> </b> 
                           <i> Tác giả: </i>  <b> <%# TenTacGia(int.Parse(Eval("MaGiangVien").ToString())) %> </b>
                           <i>Nhà xuất bản: </i> <b> <%# Eval("NhaXuatBan") %> </b>
                           <i> Năm xuất bản : </i> <b> <%# String.Format("{0:dd/MM/yyyy}",Eval("NamHoanThanh")) %> </b>
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