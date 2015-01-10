<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcThongKeHocVi.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcThongKeHocVi" %>

<h2 style="text-align:center">THỐNG KÊ HỌC VỊ </h2>

<div class="row"> <asp:DropDownList ID="cbbHocVi" runat="server" OnSelectedIndexChanged="cbbHocVi_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> </div>
<h2> <asp:Label ID="TenHocVi" runat="server" Text="Label"></asp:Label> </h2>

<div class="table-responsive">
        <asp:GridView ID="gvThongKeHocVi" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" >
            <Columns>
                 <asp:TemplateField HeaderText="STT">  
                     <ItemTemplate>  
                         <%# Container.DataItemIndex + 1 %>  
                     </ItemTemplate>  
                </asp:TemplateField>
                <asp:BoundField DataField="TenGiangVien" HeaderText="Tên tác giả" />
                <asp:BoundField DataField="TenKhoa" HeaderText="Đơn vị Công tác" />
                <asp:BoundField DataField="NamTotNghiepHocVi" HeaderText="Năm" />
            </Columns>
        </asp:GridView>
</div>