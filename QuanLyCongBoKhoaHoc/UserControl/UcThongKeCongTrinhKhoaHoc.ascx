<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcThongKeCongTrinhKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcThongKeCongTrinhKhoaHoc" %>

<h2 style="text-align:center"> THỐNG KÊ CÔNG TRÌNH KHOA HỌC</h2>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="row" style="text-align: center">
            <asp:DropDownList ID="cbbDonViCongTac" runat="server">
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox runat="server" ID="txtTenTacGia" placeholder="Họ tên giảng viên" />
            &nbsp;
            <b> Năm công bố:  </b>
            <asp:TextBox runat="server" ID="txtTuNamCongBo" placeholder="Năm" Width="50px"/> -> <asp:TextBox runat="server" ID="txtDenNamCongBo" placeholder="Năm" Width="50px" />

            <asp:Button ID="btnTimKiemThongKeCongBo" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary" OnClick="btnTimKiemThongKeCongBo_Click" />
            </div>
    <hr />
        <div class="table-responsive">
            <asp:GridView ID="gvTTCongTrinhKhoaHoc" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" OnPageIndexChanging="gvTTCongTrinhKhoaHoc_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TenGiangVien" HeaderText="Tên tác giả" />
                    <asp:BoundField DataField="Khoa" HeaderText="Đơn vị Công tác" />
                    <asp:BoundField DataField="CapTruong" HeaderText="Cấp trường" />
                    <asp:BoundField DataField="CapBo" HeaderText="Cấp bộ" />
                    <asp:BoundField DataField="CapCoSo" HeaderText="Cấp cơ sở" />
                    <asp:BoundField DataField="CapThanhPho" HeaderText="Cấp thành phố" />
                    <asp:BoundField DataField="CapNhaNuoc" HeaderText="Cấp nhà nước" />
                    <asp:BoundField DataField="CapQuocGia" HeaderText="Cấp quốc gia" />
                </Columns>
            </asp:GridView>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>