<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcThongKeSachGiaoTrinh.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcThongKeSachGiaoTrinh" %>

<h2 style="text-align:center">THỐNG KÊ SÁCH GIÁO TRÌNH </h2>
  <div class="row" style="text-align: center">

            <b>Đơn vị công tác : </b>
            <asp:DropDownList ID="cbbDonViCongTac" runat="server">
            </asp:DropDownList>

            <b>Tên giảng viên : </b>
            <asp:TextBox runat="server" ID="txtTenGiangVien" />
            
            <b>Từ năm sách hoàn thành: </b>
            <asp:TextBox runat="server" ID="txtTuNamHoanThanh" />

             <b>Đến năm sách hoàn thành: </b>
            <asp:TextBox runat="server" ID="txtDenNamHoanThanh" />

            <asp:Button ID="btnTimKiemThongKeSachGiaoTrinh" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary" Style="height: 26px" OnClick="btnTimKiemThongKeSachGiaoTrinh_Click" />
        </div>

<div class="table-responsive">
        <asp:GridView ID="gvTKSachXuatBan" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" OnPageIndexChanging="gvTKSachXuatBan_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="STT">  
                     <ItemTemplate>  
                         <%# Container.DataItemIndex + 1 %>  
                     </ItemTemplate>  
                </asp:TemplateField>
                <asp:BoundField DataField="TenGiangVien" HeaderText="Tên tác giả" />
                <asp:BoundField DataField="TenKhoa" HeaderText="Khoa" />
                <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            </Columns>
        </asp:GridView>
</div>