<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcMenu.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcMenu" %>
<div class="">
    <h3> Quản lý menu ngang </h3>
    <div class="table-responsive">
        <asp:GridView ID="gvMenu" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False"    HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Middle"
            DataKeyNames="MaMenu,MaMenuCha" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvMenu_PageIndexChanging" OnRowCommand="gvMenu_RowCommand" OnRowDeleting="gvMenu_RowDeleting" >
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

                 <asp:BoundField DataField="MaMenu" HeaderText="Mã menu" ItemStyle-CssClass="col-lg-1"
                    SortExpression="MaMenu" />
                <asp:BoundField DataField="TenMenu" HeaderText="Tên menu" ItemStyle-CssClass="col-lg-1"
                    SortExpression="TenMenu" />
                <asp:BoundField DataField="KieuHienThi" SortExpression="KieuHienThi" HeaderText="Kiểu hiển thị"
                    ItemStyle-CssClass="col-lg-1" />
                    <asp:BoundField DataField="DoiTuong" SortExpression="DoiTuong" HeaderText="Đối tượng"
                    ItemStyle-CssClass="col-lg-1" />                
                <asp:BoundField DataField="MaMenuCha" SortExpression="TheLoaiCha" HeaderText="Thể loại cha" />
                <asp:BoundField DataField="ThuTu" SortExpression="ThuTu" HeaderText="Thứ tự" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
             <%--   <asp:BoundField DataField="TrangThai" SortExpression="TrangThai" HeaderText="Trạng thái" />--%>

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
<asp:LinkButton ID="lbXoaTat" runat="server" class="btn btn-primary" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa các dòng đã chọn?');" OnClick="lbXoaTat_Click">Xóa chọn</asp:LinkButton>

<div id="thongTin" class="modal fade in" aria-hidden="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 id="myModalLabel">Thêm thể loại</h4>
            </div>
            <div class="modal-body">
              <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Tên thể loại :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:TextBox ID="txtTheLoai" runat="server" class="form-control" data-rule-required="true"
                            data-rule-minlength="3"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Kiểu hiển thị :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:DropDownList ID="ddKieuHienThi" class="form-control" runat="server">
                            <asp:ListItem Text="Tin tức, sự kiện" Value="cat"></asp:ListItem>
                            <asp:ListItem Text="Chi tiết tin tức, sự kiện" Value="info"></asp:ListItem>
                            <asp:ListItem Text="Ảnh, video" Value="media"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Tiêu đề :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:TextBox ID="txtTieuDe" runat="server" placeholder="Độ dài tối đa 80 ký tự để tốt cho SEO"
                            class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Mô tả :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:TextBox ID="txtMoTa" runat="server" placeholder="Độ dài tối đa 155 ký tự để tốt cho SEO" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Từ khóa :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:TextBox ID="txtTuKhoa" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Thể loại cha :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:DropDownList ID="ddTheLoaiCha" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group" id="thutu" runat="server" visible="false">
                    <label class="col-sm-4 col-lg-3 control-label">Thứ tự :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:DropDownList ID="ddThuTu" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group" >
                    <label class="col-sm-4 col-lg-3 control-label">Hiển thị :</label>
                    <div class="col-sm-8 col-lg-9 controls">
                        <asp:DropDownList ID="ddTrangThai" class="form-control" runat="server">
                            <asp:ListItem Text="Hiển thị" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Không hiển thị" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
          </div>
            <div class="modal-footer">
                <asp:Button ID="btThemMoi" runat="server" Text="Thêm mới" class="btn btn-primary"
                    OnClick="Button1_Click" />
                <asp:Button ID="btSua" runat="server" CssClass="btn btn-primary" Text="Lưu"
                    OnClick="btSua_Click" />
   
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
            $('#<%=thutu.ClientID%>').css('display', 'none');
            $('#<%=btThemMoi.ClientID%>').css('display', 'inline-block');
            $('#<%=btSua.ClientID%>').css('display', 'none');
        });
    });
</script>
