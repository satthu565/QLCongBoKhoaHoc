<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcBaiBaoKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUserBaiBaoKhoaHoc" %>
<h3>Quản lý bài báo khoa học</h3>
<div class="">
    <div class="table-responsive">
        <asp:GridView ID="gvBaiBaoKhoaHoc" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover" AutoGenerateColumns="False"
           DataKeyNames="MaBaiBao" ShowHeaderWhenEmpty="True" OnRowCommand="gvBaiBaoKhoaHoc_RowCommand" OnRowDeleting="gvBaiBaoKhoaHoc_RowDeleting" OnPageIndexChanging="gvBaiBaoKhoaHoc_PageIndexChanging" >
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
               <asp:BoundField DataField="MaBaiBao" HeaderText="Mã tin" ReadOnly="True"  SortExpression="MaBaiBao" ItemStyle-CssClass="col-lg-1" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center" CssClass="col-lg-1"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TenBaiBao" HeaderText="Tên bài báo"
                    SortExpression="TenBaiBao" />
                <asp:BoundField DataField="ThoiGianXuatBan" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Thời gian xuất bản" SortExpression="ThoiGianXuatBan" />
                <asp:BoundField DataField="NoiXuatBan" HeaderText="Nơi xuất bản"
                    SortExpression="NoiXuatBan" />
                <asp:TemplateField HeaderText="Tác giả">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# ChuoiTacGia(Eval("ChuoiMaGiangVienTacGia").ToString(), Eval("TenTacGiaNgoai").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="File Mềm">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                            Text="File mềm" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="ChonTai">
                                <img src="../img/dowload.png" alt="Dowload" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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

<asp:LinkButton ID="lbXoaTat" runat="server" class="btn btn-primary" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa các dòng đã chọn?');">Xóa chọn </asp:LinkButton>
<asp:Button ID="btnThemBaiBao" runat="server" CssClass="btn btn-primary" Text="Thêm bài báo mới" OnClick="btnThemBaiBao_Click" />