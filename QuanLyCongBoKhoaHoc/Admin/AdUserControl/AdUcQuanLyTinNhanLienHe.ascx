<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcQuanLyTinNhanLienHe.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcQuanLyTinNhanLienHe" %>
<div class="row">
    <div class="col-lg-12">
        <div class="box">
            <div class="box-title">
                <h3>
                   <i class="icon-home"></i>
                   QUẢN LÝ TIN NHẮN LIÊN HỆ
                </h3>
                <div class="box-tool">
                    <a data-action="collapse" href="#"><i class="icon-chevron-up"></i></a>
                    <a data-action="close" href="#"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">             
                <br />
                    <form class="form-horizontal" role="form">
                         <div class="form-group">
                                 <label for="inputEmail3" class="col-lg-5 control-label"> <b> Họ tên, email cần tìm: </b> </label>
                            <div class="col-lg-5">
                                 <input id="txtTimHoTenLienHe" runat="server" type="text" class="form-control col-lg-4" placeholder="Nhập họ tên email liên hệ cần tìm kiếm">   
                            </div>
                            <div class="col-lg-2">
                                 <asp:Button ID="btnTimKiemNguoiLienHe" CssClass="btn btn-primary" runat="server" Text="Tìm kiếm" OnClick="btnTimKiemNguoiLienHe_Click" />
                            </div>
                        </div>
                    </form>
                 <br />
                <hr />

                <asp:GridView ID="grvLienHe" runat="server" EnableViewState="False" CssClass="table table-bordered table-hover" AutoGenerateColumns="False"  AllowPaging="True" PageSize="15"
                  DataKeyNames="MaLienHe"  OnRowCommand="grvLienHe_RowCommand" OnRowDeleting="grvLienHe_RowDeleting" OnPageIndexChanging="grvLienHe_PageIndexChanging"  >
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

                          <asp:BoundField DataField="EmailNguoiGui" HeaderText="Email gửi" ReadOnly="true" />
                          <asp:BoundField DataField="HoTenNguoiGui" HeaderText="Họ tên"  ReadOnly="true" />
                       
                          <asp:BoundField DataField="TieuDe" HeaderText="tiêu đề" ReadOnly="true" />
                          <asp:BoundField DataField="DoiTuong" HeaderText="Đối tượng" ReadOnly="true" />
                          <asp:BoundField DataField="TieuDeBai" HeaderText="tiêu đề bài" ReadOnly="true" />
                          <asp:BoundField DataField="ThoiGian" HeaderText="ThoiGian" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="true" />
                          <asp:BoundField DataField="TrangThai" HeaderText="Trạng thái" ReadOnly="true" />

                  
                <asp:TemplateField HeaderText="Xem" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Font-Bold="true"
                            Text="Xem" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="ChonXem">
                          <img src="../img/detail.jpg" alt="Xem" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

                        <asp:CommandField DeleteText="Xóa" HeaderText="Xóa" ShowDeleteButton="True" ItemStyle-CssClass="col-md-2 col-lg-2"
                            ControlStyle-Font-Bold="true">
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle CssClass="col-md-1 col-lg-1" />
                        </asp:CommandField>

                    </Columns>
                    <EmptyDataTemplate>
                        <label class="empty-data">
                            Chưa có dữ liệu! Nhấn vào nút thêm mới để thêm dữ liệu.
                        </label>
                    </EmptyDataTemplate>
                </asp:GridView>   
            </div>
        </div>
    </div>
</div>

<asp:LinkButton ID="lbXoaTat" runat="server" class="btn btn-primary" OnClientClick="return ConfirmDelete('Có chắc bạn muốn xóa các dòng đã chọn?');" OnClick="lbXoaTat_Click"> Xóa chọn </asp:LinkButton>
