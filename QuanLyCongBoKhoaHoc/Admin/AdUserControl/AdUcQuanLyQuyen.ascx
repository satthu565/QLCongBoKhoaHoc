<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcQuanLyQuyen.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcQuanLyQuyen" %>

<div class="row">
    <div class="col-lg-12">
        <div class="box">
            <div class="box-title">
                <h3>
                    <i class="icon-home"></i>
                   Quản lý chức vụ
                </h3>
                <div class="box-tool">
                    <a data-action="collapse" href="#"><i class="icon-chevron-up"></i></a>
                    <a data-action="close" href="#"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <br />
                <asp:GridView ID="grvQuanLyQuyen" runat="server" EnableViewState="False" CssClass="table table-bordered table-hover"
                    AutoGenerateColumns="False" DataKeyNames="MaQuyen" OnRowCommand="grvQuanLyQuyen_RowCommand" OnRowDataBound="grvQuanLyQuyen_RowDataBound" OnRowDeleting="grvQuanLyQuyen_RowDeleting" >
                    <Columns>
                        <asp:BoundField DataField="MaQuyen" HeaderText="Mã quyền" InsertVisible="False"
                            ReadOnly="True" SortExpression="MaQuyen" ItemStyle-CssClass="col-md-2 col-lg-2"
                            ControlStyle-Font-Bold="true">
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle CssClass="col-md-1 col-lg-1" />
                        </asp:BoundField>

                        <asp:BoundField DataField="TenQuyen" HeaderText="Tên quyền" />
                        <asp:BoundField DataField="ChuoiDanhMucQuyen" HeaderText="Chuỗi Danh sách quyền" /> 

               <asp:TemplateField HeaderText="Sửa" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                            Text="Sửa" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="ChonSua">
                                <img src="../img/edit.jpg" alt="sửa" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

                        <asp:CommandField DeleteText="Xóa" HeaderText="Xóa" ShowDeleteButton="True" ItemStyle-CssClass="col-md-2 col-lg-2"
                            ControlStyle-Font-Bold="true">
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
                    <a id="btThem" href="#thongTin" role="button" class="btn btn-primary" data-toggle="modal">Thêm mới </a>
                </div>
            </div>
        </div>
    </div>
</div>

<%-- Modal --%>

<div id="thongTin" class="modal fade in" aria-hidden="false" style="display: none;">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h2 id="myModalLabel" style="text-align:center">Quản lý Quyền</h2>
            </div>
            <div class="modal-body">
             <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label">Tên quyền:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                        <asp:TextBox ID="txtTenQuyen" runat="server" class="form-control" data-rule-required="true"
                            data-rule-minlength="3"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label">Quyền:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                        <asp:CheckBoxList ID="CheckBoxQuyen" runat="server" CellPadding="5" CellSpacing="3" RepeatColumns="2"></asp:CheckBoxList>
                    </div>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="btThemMoi" runat="server" Text="Thêm mới" class="btn btn-primary"  OnClick="btnThemMoi_Click"  />
                    <asp:Button ID="btSua" runat="server" CssClass="btn btn-primary" Text="Lưu" OnClick="btnSua_Click" />
                    <button class="btn" data-dismiss="modal">Hủy</button>
                </div>
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
            $('#<%=btThemMoi.ClientID%>').css('display', 'inline-block');
            $('#<%=btSua.ClientID%>').css('display', 'none');
        });
    });
</script>


