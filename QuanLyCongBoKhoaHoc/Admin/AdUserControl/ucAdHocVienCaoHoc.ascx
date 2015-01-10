<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdHocVienCaoHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.ucAdHocVienCaoHoc" %>

<div class="">
    <h3 style="text-align:center">Học viên cao học</h3>

    <div class="form-horizontal row">
        <div class="form-group">
            <label for="inputEmail3" class="col-lg-2 control-label col-md-offset-2"><b> Chọn loại đào tạo : </b></label>
            <div class="col-lg-5">
                <asp:DropDownList ID="cbbTimLoaiDaoTao" runat="server">
                    <asp:ListItem Text="Cao Học" Value="CaoHoc" />
                    <asp:ListItem Text="Nghiên cứu sinh" Value ="NghienCuuSinh" />
                </asp:DropDownList>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="TimKiemTheoLoaiDaoTao" CssClass="btn btn-primary" runat="server" Text="Tìm kiếm" OnClick="TimKiemTheoLoaiDaoTao_Click"  />
            </div>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gvHocVienCaoHoc" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False"    HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Middle"
            DataKeyNames="MaSauDaiHoc" ShowHeaderWhenEmpty="True" OnRowCommand="gvHocVienCaoHoc_RowCommand" OnRowDeleting="gvHocVienCaoHoc_RowDeleting" OnPageIndexChanging="gvHocVienCaoHoc_PageIndexChanging"  >
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

                <asp:BoundField DataField="MaHocVien" HeaderText="MaHocVien" >
                    <ItemStyle CssClass="col-lg-1"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="HoTen" HeaderText="Học viên" ItemStyle-CssClass="col-lg-2" SortExpression="HoTen" >
                    <ItemStyle CssClass="col-lg-2"></ItemStyle>
                </asp:BoundField>

              <asp:BoundField DataField="NgaySinh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày sinh" SortExpression="NgaySinh" />


                <asp:BoundField DataField="TenDeTai" HeaderText="Đề tài" ItemStyle-CssClass="col-lg-2" SortExpression="TenDeTai" >
                    <ItemStyle CssClass="col-lg-2"></ItemStyle>
                </asp:BoundField>

                  <asp:BoundField DataField="NoiDaoTao" HeaderText="Học viên" ItemStyle-CssClass="col-lg-2" SortExpression="NoiDaoTao" >
                    <ItemStyle CssClass="col-lg-2"></ItemStyle>
                </asp:BoundField>

                 <asp:BoundField DataField="ThoiGianDaoTao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Thời gian đào tạo" SortExpression="ThoiGianDaoTao" />
                 <asp:BoundField DataField="ThoiGianBatDau" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Bắt đầu" SortExpression="ThoiGianBatDau" />
                 <asp:BoundField DataField="ThoiGianBaoVe" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Bảo về" SortExpression="ThoiGianBaoVe" />

                <asp:BoundField DataField="LoaiDaoTao" HeaderText="Đào tạo" ItemStyle-CssClass="col-lg-2" SortExpression="LoaiDaoTao" >
                    <ItemStyle CssClass="col-lg-2"></ItemStyle>
                </asp:BoundField>

                 <asp:BoundField DataField="TrangThai" HeaderText="Trạng thái" ItemStyle-CssClass="col-lg-2" SortExpression="TrangThai" >
                    <ItemStyle CssClass="col-lg-2"></ItemStyle>
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

<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
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
                    <h4 id="myModalLabel">Học viên sau đại học</h4>
            </div>

            <div class="modal-body">
              <div class="form-horizontal" >
                    <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label">Họ tên :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                <input id="txtHoTen" runat="server" class="form-control" type="text" placeholder="Nhập họ tên" name="txtHoTen">
                            </div>
                    </div>

                    <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label">GioiTinh :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                <asp:DropDownList ID="cbbGioiTinh" runat="server">
                                    <asp:ListItem Value="True">Nam</asp:ListItem>
                                    <asp:ListItem Value="False"> Nữ</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                    </div>

                      <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label">ngày sinh :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                  <input id="txtNgaySinh" runat="server" class="form-control" type="text" placeholder="dd/mm/yyyy" name="txtNgaySinh">
                            </div>
                    </div>
                      <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label"> Số CMND :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                  <input id="txtCMND" runat="server" class="form-control" type="text" placeholder="Nhập số CMND" name="txtCMND">
                            </div>
                     </div>

                   <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label"> Nơi đào tạo :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                  <input id="txtNoiDaoTao" runat="server" class="form-control" type="text" placeholder="Nhập nơi đào tạo" name="txtNoiDaoTao">
                            </div>
                     </div>

                   <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label"> thời gian đào tạo:</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                  <input id="txtThoiGianDaoTao" runat="server" class="form-control" type="text" placeholder="Bao nhiêu tháng" name="txtThoiGianDaoTao">
                            </div>
                     </div>
                   <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label"> Thời gian bắt đầu:</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                  <input id="txtThoiGianBatDau" runat="server" class="form-control" type="text" placeholder="dd/mm/yyyy" name="txtThoiGianBatDau">
                            </div>
                     </div>
                   <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label"> Thời gian bảo vệ :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                  <input id="txtThoiGianBaoVe" runat="server" class="form-control" type="text" placeholder="dd/mm/yyyy" name="txtThoiGianBaoVe">
                            </div>
                     </div>
                   <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label"> Tên đề tài :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                  <input id="txtTenDeTai" runat="server" class="form-control" type="text" placeholder="Nhập tên đề tài" name="txtTenDeTai">
                            </div>
                     </div>
                   <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label"> Loại đào tạo :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                <asp:DropDownList ID="cbbLoaiDaoTao" runat="server">
                                    <asp:ListItem Value="CaoHoc">Cao Học</asp:ListItem>
                                    <asp:ListItem Value="NghienCuuSinh">Nghiên cứu sinh</asp:ListItem>
                                </asp:DropDownList>  
                            </div>
                     </div>

                   <div class="form-group">
                            <label class="col-sm-4 col-lg-3 control-label">Trạng thái :</label>
                            <div class="col-sm-8 col-lg-9 controls">
                                <asp:DropDownList ID="cbbTrangThai" runat="server">
                                    <asp:ListItem Value="True">Hoàn thành</asp:ListItem>
                                    <asp:ListItem Value="False">Chưa hoàn thành</asp:ListItem>
                                </asp:DropDownList>  
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