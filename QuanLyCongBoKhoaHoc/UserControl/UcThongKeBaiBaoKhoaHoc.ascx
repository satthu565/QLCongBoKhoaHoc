<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcThongKeBaiBaoKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcThongKeBaiBaoKhoaHoc" %>

<h2 style="text-align:center">THỐNG KÊ BÀI BÁO KHOA HỌC </h2>

<asp:UpdatePanel runat="server">
    <ContentTemplate>

        <div class="row" style="text-align: center">
            <asp:DropDownList ID="cbbDonViCongTac" runat="server">
            </asp:DropDownList>
             &nbsp;
            <asp:TextBox runat="server" ID="txtTenTacGia" placeholder="Họ tên giảng viên"/>
              &nbsp;
             <b> Năm xuất bản : </b>
            <asp:TextBox runat="server" ID="txtNamXuatBan" placeholder="Năm" Width="50px" /> -> <asp:TextBox runat="server" ID="txtDenNamXuatBan" placeholder="Năm" Width="50px" />
            <asp:Button ID="btnTimKiemThongKeCongBo" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary"  OnClick="btnTimKiemThongKeCongBo_Click" />
        </div>
        <hr />
        <div class="table-responsive">
            <asp:GridView ID="gvTTBaiBaoKhoaHoc" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover" AutoGenerateColumns="False"
                OnPageIndexChanging="gvTTBaiBaoKhoaHoc_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TenGiangVien" HeaderText="Tên tác giả" />
                    <asp:BoundField DataField="Khoa" HeaderText="Đơn vị Công tác" />
                    <asp:BoundField DataField="SoLuongTrongNuoc" HeaderText="Số Bài báo trong nước" />
                    <asp:BoundField DataField="SoLuongQuocTe" HeaderText="Số Bài báo quốc tế" />
                </Columns>
            </asp:GridView>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>