<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcQuanLyGiangVien.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcQuanLyGiangVien" %>



<div class="row">
    <div class="col-lg-12">
        <div class="box">
            <div class="box-title">
                <h3>
                    <i class="icon-home"></i>
                    Quản lý nhân viên
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
                                 <label for="inputEmail3" class="col-lg-2 control-label col-md-offset-2"> <b> Nhập tên giảng viên : </b> </label>
                            <div class="col-lg-5">
                                 <input id="txtTimTenGiangVien" runat="server" type="text" class="form-control col-lg-4" placeholder="Nhập họ tên giảng viên cần tìm kiếm">   
                            </div>
                            <div class="col-lg-2">
                                 <asp:Button ID="btnTimKiemGiangVien" CssClass="btn btn-primary" runat="server" Text="Tìm kiếm" OnClick="btnTimKiemGiangVien_Click" />
                            </div>
                        </div>
                    </form>
                 <br />
                <hr />

                <asp:GridView ID="grvGiangVien" runat="server" EnableViewState="False" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" AllowPaging="True" PageSize="15"
                  DataKeyNames="MaGiangVien" OnPageIndexChanging="grvGiangVien_PageIndexChanging" OnRowCancelingEdit="grvGiangVien_RowCancelingEdit"
                  OnRowDeleting="grvGiangVien_RowDeleting" OnRowEditing="grvGiangVien_RowEditing" OnRowUpdating="grvGiangVien_RowUpdating" OnRowDataBound="grvGiangVien_RowDataBound" OnRowCommand="grvGiangVien_RowCommand" >
                    <Columns>
                        <asp:BoundField DataField="TenGiangVien" HeaderText="Tên giảng viên" ReadOnly="true" />
                        <asp:BoundField DataField="NamSinh" HeaderText="NamSinh" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="true" />
                       
                        <asp:TemplateField HeaderText="Giới tính" >
                            <ItemTemplate>
                               <asp:Label ID="Label3" ReadOnly="true" runat="server" Text='<%# GioiTinh(bool.Parse(Eval("GioiTinh").ToString())) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="TenKhoa" HeaderText="Khoa" ReadOnly="true" />
                        <asp:BoundField DataField="TenHocVi" HeaderText="Học vị" ReadOnly="true" />
                        <asp:BoundField DataField="TenChucVu" HeaderText="Chức vụ" ReadOnly="true" />

                          <asp:TemplateField HeaderText="Quyền" InsertVisible="False">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cbbQuyen" runat="server"></asp:DropDownList>     
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("TenQuyen") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>    
                          
                       <asp:TemplateField HeaderText="Ảnh đại diện" InsertVisible="False" >
                            <ItemTemplate>
                                <asp:Image ID="Image1" ReadOnly="true" runat="server" ImageUrl= '<%# "~/images/AnhGiangVien/"+ Eval("AnhDaiDien") %>' Width="120px" Height="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>

                <asp:TemplateField HeaderText="Chi tiết" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Font-Bold="true"
                            Text="Xem" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="ChonXem">
                        </asp:LinkButton>
                      
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>

                        <asp:CommandField CancelText="Hủy" EditText="Sửa" HeaderText="Sửa"
                            ShowEditButton="True" UpdateText="Sửa"
                            ItemStyle-CssClass="col-md-2 col-lg-2" ControlStyle-Font-Bold="true">
                            <ControlStyle Font-Bold="True" />
                            <ItemStyle CssClass="col-md-1 col-lg-1" />
                        </asp:CommandField>
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
                        <h3 style="text-align: center">THÊM GIẢNG VIÊN</h3>
                    </div>
                    <div class="modal-body">
                        <div id="validation-form" class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Tên giảng viên:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtTenNhanVien" CssClass="form-control" runat="server" placeholder="Nhập tên giảng viên"></asp:TextBox>
                                </div>
                            </div>

                           <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Giới tính:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:DropDownList ID="cbbGioiTinh" runat="server">
                                        <asp:ListItem Value="True">Nam</asp:ListItem>
                                        <asp:ListItem Value="False">Nữ</asp:ListItem>
                                    </asp:DropDownList> 
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Tài khoản:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtTaiKhoan" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Mật khẩu:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtMatKhau" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Quyền:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:DropDownList ID="cbbQuyen" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username">Chọn Ảnh đại diện: </label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <img src="../images/default.png" style="height:80px" alt="" id="imgPreview" />
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="hide form-control" AllowMultiple="true" />
                                    <label><b style="color: red"><<</b>Nhấn vào đây để chọn ảnh.</label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-4 control-label" for="username"> Ảnh đại diện: </label>
                                <div id="out"></div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" />
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
