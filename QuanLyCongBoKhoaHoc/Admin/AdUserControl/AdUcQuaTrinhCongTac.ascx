<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcQuaTrinhCongTac.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUserQuaTrinhCongTac" %>
 
<div class="">
    <h3 style="text-align:center">QUÁ TRÌNH CÔNG TÁC</h3>
    <div class="table-responsive">
        <asp:GridView ID="gvQuaTrinhCongTac" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False"    HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Middle" 
            DataKeyNames="MaCongTac" ShowHeaderWhenEmpty="True" OnRowCommand="gvQuaTrinhCongTac_RowCommand" OnRowDeleting="gvQuaTrinhCongTac_RowDeleting" >
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

                <asp:BoundField DataField="NamCongTac" HeaderText="Năm công tác" ItemStyle-CssClass="col-lg-2" SortExpression="NamCongTac" >
                    <ItemStyle CssClass="col-lg-2"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="MoTaCongTac" SortExpression="MoTaCongTac" HeaderText="Mô tả công tác" ItemStyle-CssClass="col-lg-8" >
                    <ItemStyle CssClass="col-lg-8"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="ThuTuHienThi" SortExpression="ThuTuHienThi" HeaderText="Thứ tự" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" >          
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="col-lg-1"></ItemStyle>
                </asp:BoundField>

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

<div id="thongTin" class="modal fade in" aria-hidden="false" >
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 id="myModalLabel">Quá trình công tác</h4>
            </div>

            <div class="modal-body">
              <div class="form-horizontal" >
                    <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label">Năm công tác :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                <asp:TextBox ID="txtNamCongTac" runat="server" class="form-control" data-rule-required="true"></asp:TextBox>
                            </div>
                    </div>
                      <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label">Mô tả công tác:</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                <asp:TextBox ID="txtMoTaCongTac" runat="server" class="form-control" data-rule-required="true"></asp:TextBox>
                            </div>
                    </div>
                      <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label">Thứ tự hiển thị :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                <asp:TextBox ID="txtThuTuHienThi" runat="server" class="form-control" data-rule-required="true"></asp:TextBox>
                            </div>
                     </div>
               </div>
            </div>

            <div class="modal-footer">
                <asp:Button ID="btThemMoi" runat="server" Text="Thêm mới" class="btn btn-primary" OnClick="btThemMoi_Click" />
                <asp:Button ID="btSua" runat="server" CssClass="btn btn-primary" Text="Lưu" OnClick="btSua_Click" />
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