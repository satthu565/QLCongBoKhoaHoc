<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcLietKeCongTrinhKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcLietKeCongTrinhKhoaHoc" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
<h2 style="text-align:center ; font-weight:bold ; font-size:20px;"> LIỆT KÊ CÔNG TRÌNH KHOA HỌC </h2>

    <div class="row" style="text-align:center"> 
       <b>  Đề tài cấp : </b>
        <asp:DropDownList ID="ccbCapDeTai" runat="server"  AutoPostBack="true">
        </asp:DropDownList> 

          <b>  Năm công bố : </b>
        <asp:TextBox ID="txtNamCongBo" runat="server"></asp:TextBox>

        <asp:Button ID="btnTimKiemCongTrinh" runat="server" Text="Tìm kiếm" OnClick="btnTimKiemCongTrinh_Click" CssClass ="btn btn-primary" />
    </div>
<hr />
 <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
               <div class="row" style="margin-bottom:3px;">
                 <div class="col-md-12">  
                        <p>   
                          <i> - Mã số: </i> <b> <%#Eval("MaSo") %> </b>
                          <i> Đề tài <%#Eval("TenCapDeTai") %> : </i> <b><%# Eval("TenCongTrinh") %></b>
                          <i> Chủ nhiêm đề tài :</i> <b> <%# ChuoiTacGiaChuNhiem(Eval("ChuoiMaGiangVienChuNhiem").ToString() )%>,<%#Eval("TenChuNhiemNgoai") %> </b>
                          <i>Thành viên :</i> <b> <%# ChuoiTacGiaThanhVien(Eval("ChuoiMaThanhVienThamGia").ToString() )%>,<%#Eval("TenThanhVienNgoai") %> </b> 
                          <i>Nơi công bố :</i> <b> <%# Eval("NoiCongBo") %> </b><i> Năm :</i> <b> <%# String.Format("{0:dd/MM/yyyy}",Eval("NamCongBo")) %>  </b>
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