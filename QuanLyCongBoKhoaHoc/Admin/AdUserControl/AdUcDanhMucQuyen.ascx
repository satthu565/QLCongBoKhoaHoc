<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcDanhMucQuyen.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcDanhMucQuyen" %>

<div class="row">
    <div class="col-lg-12">
        <div class="box">
            <div class="box-title">
                <h3>
                    <i class="icon-home"></i>
                  QUẢN LÝ DANH MỤC QUYỀN
                </h3>
                <div class="box-tool">
                    <a data-action="collapse" href="#"><i class="icon-chevron-up"></i></a>
                    <a data-action="close" href="#"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <br />
                <asp:GridView ID="grvDanhMucQuyen" runat="server" EnableViewState="False" CssClass="table table-bordered table-hover"
                    AutoGenerateColumns="False" DataKeyNames="MaDanhMucQuyen">
                    <Columns>
                        <asp:BoundField DataField="MaDanhMucQuyen" HeaderText="Mã Danh mục quyền" InsertVisible="False"
                            ReadOnly="True" SortExpression="MaDanhMucQuyen" ItemStyle-CssClass="col-md-2 col-lg-2"
                            ControlStyle-Font-Bold="true">
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle CssClass="col-md-1 col-lg-1" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Tên danh mục quyền" InsertVisible="False" 
                            SortExpression="TenQuyen">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTenDanhMucQuyen" CssClass="form-control" runat="server" Text='<%# Bind("TenDanhMucQuyen") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TenDanhMucQuyen") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="col-md-2 col-lg-2" />
                        </asp:TemplateField>

                        <asp:CommandField CancelText="Hủy" EditText="Sửa" HeaderText="Sửa"
                            ShowEditButton="True" UpdateText="Sửa"
                            ItemStyle-CssClass="col-md-2 col-lg-2" ControlStyle-Font-Bold="true">
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle CssClass="col-md-2 col-lg-2" />
                        </asp:CommandField>
                        <asp:CommandField DeleteText="Xóa" HeaderText="Xóa" ShowDeleteButton="True" ItemStyle-CssClass="col-md-2 col-lg-2"
                            ControlStyle-Font-Bold="true" Visible="False">
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle CssClass="col-md-2 col-lg-2" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataTemplate>
                        <label class="empty-data">
                            Chưa có dữ liệu! Nhấn vào nút thêm mới để thêm dữ liệu.
                        </label>
                    </EmptyDataTemplate>
                </asp:GridView>
                <div class="btn-group">
                    <a class="btn btn-primary show-tooltip" role="button" title="" data-toggle="modal"
                        href="#modal-docgia" data-original-title="Thêm mới">Thêm mới</a> 
                </div>
            </div>
        </div>
    </div>
</div>

<%-- Modal --%>
<div class="row">
    <div class="col-md-12">
        <%--Bắt đầu box thong tin--%>
        <div id="modal-docgia" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button class="close" type="button" data-dismiss="modal">X</button>
                        <h3 style="text-align: center">THÊM QUYỀN</h3>
                    </div>
                    <div class="modal-body">
                        <div id="validation-form" class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Quyền :</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtTenQuyen" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>        
                        </div>
                    </div>

                    <div class="modal-footer">
                        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Xóa hết" CssClass="btn btn-danger" OnClientClick="return confirm('bạn có muốn reset lại từ đầu?');" OnClick="btnReset_Click" />
                        <button class="btn btn-primary" data-dismiss="modal">Hủy</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
