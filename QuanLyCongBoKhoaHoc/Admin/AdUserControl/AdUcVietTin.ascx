<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcVietTin.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcVietTin" %>

<h3>Đăng bài mới</h3>
 
<div class="row">
    <div class="col-lg-12">
        <div class="box">
            <div class="box-title">
                <h3>
                    <i class="icon-home"></i>
                </h3>
                <div class="box-tool">
                    <a data-action="collapse" href="#"><i class="icon-chevron-up"></i></a>
                    <a data-action="close" href="#"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <br />
                <br />

                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Tiêu đề bài viết :</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <input class="form-control show-tooltip" placeholder="Tiêu đề" id="txtTieuDe" runat="server"
                            type="text" data-original-title="Tiêu đề bài viết" data-trigger="hover">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTieuDe" ForeColor="Red">Nhập tiêu đề</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Ảnh đại diện :</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <asp:Image ID="AnhDaiDien" runat="server" ImageUrl="~/images/default.png" Height="100px"
                            CssClass="img-responsive" />
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="hide" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Mô tả :</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <textarea class="form-control show-tooltip" placeholder="Mô tả" id="txtMoTa" runat="server"
                            rows="2" data-original-title="Mô tả bài viết" data-trigger="hover"></textarea>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtMoTa" ForeColor="Red">Nhập mô tả</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Nội dung bài viết :</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <asp:TextBox runat="server" CssClass="form-control mceAdvanced" ID="txtNoiDung" />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNoiDung" ForeColor="Red">Nhập nội dung</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Chọn thể loại :</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <asp:DropDownList ID="cbbTheLoai" TabIndex="1" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
               
                <div class="btn-group">  
                        <asp:Button ID="btnThemTinTuc" runat="server" Text="Thêm bài viết" class="btn btn-primary" OnClick="btnThemTinTuc_Click" />
                </div>
            </div>
        </div>
    </div>
</div>


<script src="../../js/tinymce/tinymce.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        tfm_path = '../Admin/TinyFileManager.NET';
        tinymce.init({
            selector: ".mceAdvanced",
            theme: "modern",
            mode: "specific_textareas",
            convert_urls: false,
            encoding: "xml",
            language: 'vi_VN',
            font_formats: "Times New Roman=times new roman ,Arial=arial,helvetica,sans-serif;",
            fontsize_formats: "8pt 9pt 10pt 11pt 12pt 13pt 14pt 16pt 26pt 36pt",
            plugins: [
             "advlist autolink lists link image charmap print preview hr anchor pagebreak",
             "searchreplace wordcount visualblocks visualchars code fullscreen",
             "insertdatetime media nonbreaking save table contextmenu directionality",
             "emoticons template paste textcolor tinyfilemanager.net"
            ],
            height: 400,
            toolbar1: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent",
            toolbar2: "link image media | print preview | forecolor backcolor emoticons | fontselect fontsizeselect",
            // image_advtab: true,           
        });
    });

    function OpenUpload(fileUpload) {
        $(fileUpload).click();
    }

    $('#<%= AnhDaiDien.ClientID %>').click(function () {
        $('#<%= FileUpload1.ClientID%>').click();
    });
    $('#<%= FileUpload1.ClientID%>').change(function () {
        readURL(this, '#<%= AnhDaiDien.ClientID %>');
    });
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


