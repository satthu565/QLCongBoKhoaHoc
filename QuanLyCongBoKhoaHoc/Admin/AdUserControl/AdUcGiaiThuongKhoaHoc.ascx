<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcGiaiThuongKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcGiaiThuongKhoaHoc" %>

<div class="">
    <h3>Quản lý giải thưởng khoa học</h3>
    <div class="table-responsive">
        <asp:GridView ID="gvGiaiThuongKhoaHoc" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False"    HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Middle"
            DataKeyNames="MaGiaiThuongKhoaHoc" ShowHeaderWhenEmpty="True" OnRowCommand="gvGiaiThuongKhoaHoc_RowCommand" OnRowDeleting="gvGiaiThuongKhoaHoc_RowDeleting" >
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

                 <asp:BoundField DataField="TenGiaiThuong" SortExpression="TenGiaiThuong" HeaderText="Tên giải thưởng" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="LinhVuc" SortExpression="LinhVuc" HeaderText="Lĩnh vực" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="NoiCap" SortExpression="NoiCap" HeaderText="Nơi cấp" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                 <asp:BoundField DataField="So" SortExpression="so" HeaderText="Mã Số" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="NamNhan" SortExpression="NamNhan" HeaderText="Năm nhận"  DataFormatString="{0:dd/MM/yyyy}" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"  />
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
<asp:LinkButton ID="lbXoaTat" runat="server" class="btn btn-primary" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa các dòng đã chọn?');" OnClick="lbXoaTat_Click" > Xóa chọn </asp:LinkButton>

<div id="thongTin" class="modal fade in" aria-hidden="false" >
    <div class="modal-dialog">
        <div class="modal-content">

            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 id="myModalLabel">Thêm sửa khoa</h4>
            </div>

            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-4 col-lg-3 control-label">Tên giải thưởng :</label>
                        <div class="col-sm-8 col-lg-9 controls">
                            <asp:TextBox ID="txtTenGiaiThuong" runat="server" class="form-control" data-rule-required="true" Height="23px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 col-lg-3 control-label">Lĩnh vực :</label>
                        <div class="col-sm-8 col-lg-9 controls">
                            <asp:TextBox ID="txtLinhVuc" runat="server" class="form-control" data-rule-required="true" Height="23px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 col-lg-3 control-label">Thời gian nhận :</label>
                        <div class="col-sm-8 col-lg-9 controls">
                            <asp:TextBox ID="txtThoiGianNhan" runat="server" class="form-control" data-rule-required="true" Height="23px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 col-lg-3 control-label">Nơi nhận :</label>
                        <div class="col-sm-8 col-lg-9 controls">
                            <asp:TextBox ID="txtNoiNhan" runat="server" class="form-control" data-rule-required="true" Height="23px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 col-lg-3 control-label">Mã số giải thưởng :</label>
                        <div class="col-sm-8 col-lg-9 controls">
                            <asp:TextBox ID="txtMaSoGiaiThuong" runat="server" class="form-control" data-rule-required="true" Height="23px"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal-footer">
                <asp:Button ID="btThemMoi" runat="server" Text="Thêm mới" class="btn btn-primary" OnClick="btThemMoi_Click"/>
                <asp:Button ID="btSua" runat="server" CssClass="btn btn-primary" Text="Lưu" OnClick="btSua_Click" />
                <asp:Button ID="btnHuy" runat="server" CssClass="btn btn-primary" Text="Hủy" OnClick="btnHuy_Click" />
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