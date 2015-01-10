<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcQuanLyTinTuc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcQuanLyTinTuc" %>

<h3>Quản lý tin tức</h3>
<div class="">
    <div class="table-responsive">
        <asp:GridView ID="gvTinTuc" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False" DataKeyNames="idTinTuc" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvTinTuc_PageIndexChanging" OnRowCommand="gvTinTuc_RowCommand" OnRowDeleting="gvTinTuc_RowDeleting" >
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbChonTat" runat="server" onclick="cbChonTat(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbChon" runat="server" onclick="cbChon(this);" />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="idTinTuc" HeaderText="Mã tin" ReadOnly="True"
                    SortExpression="idTinTuc" ItemStyle-CssClass="col-lg-1"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center" CssClass="col-lg-1"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TieuDe" HeaderText="Tiêu đề"
                    SortExpression="TieuDe" />
                <asp:BoundField DataField="NgayDang" DataFormatString="{0:dd/MM/yyyy}"
                    HeaderText="Ngày đăng" SortExpression="NgayDang" />
                <asp:TemplateField HeaderText="Thể loại" >
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenMenu") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Sửa" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                            Text="Sửa" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="ChonSua">
                                <img src="../img/edit.jpg" alt="sửa" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                    <ItemTemplate>
                        <%-- Bắt sự kiện nhấn nút xóa --%>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa?');">
                                <img src="../img/delete.jpg" alt="Xóa" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>

<asp:LinkButton ID="lbXoaTat" runat="server" class="btn btn-primary" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa các dòng đã chọn?');" OnClick="lbXoaTat_Click">Xóa chọn</asp:LinkButton>
