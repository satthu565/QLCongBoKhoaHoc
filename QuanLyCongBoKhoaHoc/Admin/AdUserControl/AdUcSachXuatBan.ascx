<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcSachXuatBan.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcSachXuatBan" %>
<div class="">
    <h3 style="text-align:center">QUẢN LÝ SÁCH XUẤT BẢN</h3>
    <div class="table-responsive">
        <asp:GridView ID="gvSachXuatBan" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False"    HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Middle"
            DataKeyNames="MaSachXuatBan" ShowHeaderWhenEmpty="True" OnRowCommand="gvSachXuatBan_RowCommand" OnRowDeleting="gvSachXuatBan_RowDeleting" >
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbChonTat" runat="server" onclick="cbChonTat(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbChon" runat="server" onclick="cbChon(this);" />
                    </ItemTemplate>
                    <ItemStyle Width="9px" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:BoundField DataField="MaSachXuatBan" HeaderText="Mã sách" ItemStyle-CssClass="col-lg-2"
                    SortExpression="gvSachXuatBan" />
                <asp:BoundField DataField="TenSach" SortExpression="TenSach" HeaderText="Tên sách"
                    ItemStyle-CssClass="col-lg-4" />
                    <asp:BoundField DataField="NhaXuatBan" SortExpression="TenSach" HeaderText="Nhà xuất bản"
                    ItemStyle-CssClass="col-lg-4" />
                    <asp:BoundField DataField="NamHoanThanh" SortExpression="NamHoanThanh" HeaderText="Năm hoàn thành" DataFormatString="{0:dd/MM/yyyy}"
                    ItemStyle-CssClass="col-lg-4" />
               
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
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Delete" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa?');">
                                <img src="../img/delete.jpg" alt="Xóa" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>



<a id="btThem" href="#thongTin" role="button" class="btn btn-primary" data-toggle="modal">Thêm mới
</a>
<asp:LinkButton ID="lbXoaTat" runat="server" class="btn btn-primary" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa các dòng đã chọn?');" OnClick="lbXoaTat_Click"> Xóa chọn </asp:LinkButton>

<div id="thongTin" class="modal fade in" aria-hidden="false" style="display: none;">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 id="myModalLabel">Thêm Sách</h4>
            </div>
            <div class="modal-body">
              <div class="form-horizontal" >
                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Tên sách :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:TextBox ID="txtTenSach" runat="server" class="form-control" data-rule-required="true"></asp:TextBox>
                    </div>
                </div>
                  <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Nhà xuất bản :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:TextBox ID="txtNhaXuatBan" runat="server" class="form-control" data-rule-required="true"></asp:TextBox>
                    </div>
                </div>
                  <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Năm xuất bản :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:TextBox ID="txtNamXuatBan" runat="server" class="form-control" data-rule-required="true"></asp:TextBox>
                    </div>
                </div>
                  <//div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btThemMoi" runat="server" Text="Thêm mới" class="btn btn-primary" OnClick="btThemMoi_Click"/>
                <asp:Button ID="btSua" runat="server" CssClass="btn btn-primary" Text="Lưu" OnClick="btSua_Click"/>
                <button class="btn" data-dismiss="modal">Hủy</button>
            </div>
        </div>
    </div>
</div>


<script>

    $(document).ready(function () {
        if ('<%Response.Write(isClick.ToString());%>' == 'True') {
            $('#btThem').click();
            $('#<%=btThemMoi.ClientID%>').css('display', 'none');
            $('#<%=btSua.ClientID%>').css('display', 'inline-block');
        }

        $('#btThem').click(function () {
            $('#thongTin').find('input:not([type=submit])').val('');
            $('#thongTin').find('textarea').val('');
            $('#<%=btThemMoi.ClientID%>').css('display', 'inline-block');
            $('#<%=btSua.ClientID%>').css('display', 'none');
        });
    });
</script>