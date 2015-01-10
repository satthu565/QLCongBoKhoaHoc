<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcQuanLySlide.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcQuanLySlide" %>

<div class="row">
    <div class="col-lg-12">
        <div class="box">
            <div class="box-title">
                <h3>
                    <i class="icon-home"></i>
                    Quản lý Slide
                </h3>
                <div class="box-tool">
                    <a data-action="collapse" href="#"><i class="icon-chevron-up"></i></a>
                    <a data-action="close" href="#"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <br />
                <br />
                <asp:GridView ID="grvSlide" runat="server" EnableViewState="False" CssClass="table table-bordered table-hover"
                    AutoGenerateColumns="False" DataKeyNames="MaSlide"
                    OnRowDeleting="grvSlide_RowDeleting"
                    OnRowCancelingEdit="grvSlide_RowCancelingEdit"
                    OnRowEditing="grvSlide_RowEditing" OnRowUpdating="grvSlide_RowUpdating"
                    OnRowDataBound="grvSlide_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="MaSlide" HeaderText="Mã Slide" InsertVisible="False"
                            ReadOnly="True" SortExpression="MaSlide" ItemStyle-CssClass="col-md-2 col-lg-2"
                            ControlStyle-Font-Bold="true">
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle CssClass="col-md-1 col-lg-1" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Tiêu đề" InsertVisible="False" 
                            SortExpression="TieuDe">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTieuDe" CssClass="form-control" runat="server" Text='<%# Bind("TieuDe") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TieuDe") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="col-md-2 col-lg-2l" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mô tả" InsertVisible="False" 
                            SortExpression="MoTa">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMoTa" CssClass="form-control" runat="server" Text='<%# Bind("MoTa") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("MoTa") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="col-md-2 col-lg-2" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hình ảnh" SortExpression="TenAnh" ItemStyle-CssClass="col-md-2 col-lg-1">
                            <EditItemTemplate>
                                <asp:Image ID="imgAnhSlide" CssClass="img-responsive" runat="server" Style="height: 100px"
                                    ImageUrl='<%# "~/images/Slides/"+Eval("Anh") %>' />
                                <asp:Label ID="imgAnhDaiDienCu" runat="server" Text='<%# Bind("Anh") %>'></asp:Label>
                                <asp:FileUpload ID="uploadAnhSlide" runat="server" CssClass="hide" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" CssClass="img-responsive" style="height:100px" runat="server" ImageUrl='<%# "~/images/Slides/"+Eval("Anh") %>' />
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Anh") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="col-md-2 col-lg-1" />
                        </asp:TemplateField>

                        <asp:CommandField CancelText="Hủy" EditText="Sửa" HeaderText="Sửa"
                            ShowEditButton="True" UpdateText="Sửa"
                            ItemStyle-CssClass="col-md-2 col-lg-2" ControlStyle-Font-Bold="true">
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle CssClass="col-md-2 col-lg-2" />
                        </asp:CommandField>
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
                        <h3 style="text-align: center">THÊM SLIDE</h3>
                    </div>
                    <div class="modal-body">
                        <div id="validation-form" class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Tiêu đề:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtTieuDe" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Mô tả:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtMoTa" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Chọn ảnh:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <img src="../images/default.png" style="height:80px" alt="" id="imgPreview" />
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="hide form-control" AllowMultiple="true" />
                                    <label><b style="color: red"><<</b>Nhấn vào đây để chọn ảnh.</label>
                                </div>
                            </div>
                            <div class="form-group">
                                 <label class="col-sm-4 col-lg-4 control-label" for="username">Ảnh đại diện:</label>
                                <div id="out"></div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" OnClick="btnThemMoi_Click"
                            CssClass="btn btn-primary" />
                        <button class="btn btn-primary" data-dismiss="modal">Hủy</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<script>
    function handleFileSelect(evt) {
        var files = evt.target.files; // FileList object

        // Loop through the FileList and render image files as thumbnails.
        for (var i = 0, f; f = files[i]; i++) {

            // Only process image files.
            if (!f.type.match('image.*')) {
                continue;
            }

            var reader = new FileReader();

            // Closure to capture the file information.
            reader.onload = (function (theFile) {
                return function (e) {
                    // Render thumbnail.
                    var span = document.createElement('span');
                    span.className = 'col-lg-6';
                    span.innerHTML = ['<img class="img-responsive imgPreview"  src="', e.target.result,
                                      '" title="', escape(theFile.name), '"/>'].join('');
                    document.getElementById('out').insertBefore(span, null);
                };
            })(f);

            // Read in the image file as a data URL.
            reader.readAsDataURL(f);

        }
    }

    $('#<%= FileUpload1.ClientID%>').change(function (e) {
        handleFileSelect(e);
    });

    $('#imgPreview').click(function () {
        $('#<%= FileUpload1.ClientID%>').click();
        $('#out').html('');
    });

    function OpenUpload(fileUpload) {
        $(fileUpload).click();
    }


    function readURL(input, imgAnhDaiDien) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $(imgAnhDaiDien).attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
</script>
