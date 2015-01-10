<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcCongBoKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUserCongBoKhoaHoc" %>

<%--tiep tuc lam nhá--%>
<h3>quản lý công bố khoa học</h3>
<div class="">
    <div class="table-responsive">
        <asp:GridView ID="gvCongBoKhoaHoc" runat="server" AllowPaging="True" PageSize="15" CssClass="table table-bordered table-hover" AutoGenerateColumns="False"
           DataKeyNames="MaCongTrinhKhoaHoc" ShowHeaderWhenEmpty="True" OnRowCommand="gvCongBoKhoaHoc_RowCommand" OnPageIndexChanging="gvCongBoKhoaHoc_PageIndexChanging" OnRowDeleting="gvCongBoKhoaHoc_RowDeleting"  >
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

              <asp:BoundField DataField="MaSo" HeaderText="Mã số" ReadOnly="True"  SortExpression="MaSo" ItemStyle-CssClass="col-lg-1" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center" CssClass="col-lg-1"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TenCongTrinh" HeaderText="Đề tài"
                    SortExpression="TenCongTrinh" />
                <asp:BoundField DataField="NamCongBo" DataFormatString="{0:dd/MM/yyyy}"
                    HeaderText="Thời gian công bố" SortExpression="NamCongBo" />
               
                 
                <asp:TemplateField HeaderText="Chủ nhiệm">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# ChuoiTacGiaChuNhiem(Eval("ChuoiMaGiangVienChuNhiem").ToString(), Eval("TenChuNhiemNgoai").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thành viên">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# ChuoiTacGiaThanhVien(Eval("ChuoiMaThanhVienThamGia").ToString(),Eval("TenThanhVienNgoai").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                 
                <asp:BoundField DataField="LinkFileMem" HeaderText="Tên file mềm" />
               
                 
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
<asp:Button ID="btThemCongBo" runat="server" Text="Thêm công bố mới" class="btn btn-primary" OnClick="btThemCongBo_Click"  />


<%--<div class="">
    <div class="table-responsive">
        <asp:GridView ID="gvQuanLyCongBoKhoaHoc" runat="server" AllowPaging="True" DataKeyNames="MaCongTrinhKhoaHoc" PageSize="10" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" OnRowCommand="gvQuanLyCongBoKhoaHoc_RowCommand" OnRowDeleting="gvQuanLyCongBoKhoaHoc_RowDeleting">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbChonTat" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbChon" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="10px" HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
               
                <asp:BoundField DataField="MaSo" HeaderText="Mã số" SortExpression="MaSo" />
                <asp:BoundField DataField="NamCongBo" DataFormatString="{0:dd/MM/yyyy}"
                    HeaderText="Thời gian công bố" SortExpression="NamCongBo" />
              <asp:TemplateField HeaderText="Chủ nhiệm">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# ChuoiTacGiaChuNhiem(Eval("ChuoiMaGiangVienChuNhiem").ToString(),Eval("TenChuNhiemNgoai").ToString())%>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Thành viên" >
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# ChuoiTacGiaThanhVien(Eval("ChuoiMaThanhVienThamGia").ToString(),Eval("TenThanhVienNgoai").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                      
                <asp:BoundField DataField="TenCongTrinh" HeaderText="Tên công trình" SortExpression="TenCongTrinh" />

                 <asp:TemplateField HeaderText="File mềm" SortExpression="LinkFileMem">
                    <ItemTemplate>
                      
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
<%--                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa?');">
                                <img src="../img/delete.jpg" alt="Xóa" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>

<asp:LinkButton ID="lbXoaTat" runat="server" class="btn btn-primary" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa các dòng đã chọn?');">Xóa chọn</asp:LinkButton>--%>
