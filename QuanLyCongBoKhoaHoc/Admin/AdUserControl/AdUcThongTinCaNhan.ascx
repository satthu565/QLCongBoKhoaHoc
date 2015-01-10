<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcThongTinCaNhan.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUserThongTinCaNhan" %>

<div class="row">
    <div class="col-md-12">
        <div class="box">
            <div class="box-title">
                 <h3><i class="icon-file"></i>Thông tin cá nhân</h3>
                 <div class="box-tool">
                        <a href="#" data-action="collapse"> <i class="icon-chevron-up"></i>  </a>
                        <a href="#" data-action="close"><i class="icon-remove"></i></a>
                </div>
           </div>
                
                <div class="box-content">
                    <div class="row">       
                              <div class="col-md-3">  
                                  <div class="form-group"> 
                                        <div class="col-sm-12 col-lg-12 controls">
                                            <asp:Image ID="AnhDaiDien" runat="server" ImageUrl="~/images/default.png" CssClass="img-responsive" Height="295px" Width="225px" />
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="hide" />
                                        </div>
                                    </div>
                                    <br>
                                    <br>
                                </div>
                         <asp:Repeater id="rpThongTinCaNhan" runat="server">
                            <ItemTemplate>
                        <div class="col-md-9 user-profile-info">
                                <p>
                                    <span>Họ tên:</span>
                                   <%#Eval("TenGiangVien") %>
                                </p>
                                <p>
                                    <span>Giới Tính:</span>
                                   <%# GioiTinh(bool.Parse(Eval("GioiTinh").ToString())) %>
                                </p>
                                <p>
                                    <span>Năm sinh:</span>
                                 <%# String.Format("{0:dd/MM/yyyy}",Eval("NamSinh")) %> 
                                </p>
                                <p>
                                    <span>Quê quán:</span>
                                    <%# Eval("QueQuan") %>
                                </p>
                                <p>
                                    <span>Địa chỉ:</span>
                                     <%# Eval("DiaChiLienHe") %>
                                </p>
                                <p>
                                    <span>Số điện thoại:</span>
                                    <%# Eval("DienThoai") %>
                                </p>
                                <p>
                                    <span>Học vị:</span>
                                     <%# Eval("TenHocVi") %>
                                </p>
                                <p>
                                    <span>Chức vụ:</span>
                                     <%# Eval("TenChucVu") %>
                                </p>
                                <p>
                                    <span>Khoa:</span>
                                     <%# Eval("TenKhoa") %>
                                </p>
                          
                                <p>
                                    <span>Email:</span>
                                     <%# Eval("Email") %>
                                </p>       
                            </div>
                         </ItemTemplate>
                     </asp:Repeater>
                          
                    </div>
                </div>
        </div>
     </div>
    <div class="row hidden-xs">
    <div class="col-md-12">
        <div class="box box-green">
            <div class="box-title">
                <h3>
                    <i class="icon-reorder">Sửa chữa thông tin cá nhân</i>
                
                </h3>
                <div class="box-tool">
                    <a href="#" data-action="collapse">
                        <i class="icon-chevron-up"></i>
                    </a>
                    <a href="#" data-action="close">
                        <i class="icon-remove"></i>
                    </a>
                </div>
            </div>
            <div class="box-content">     
                <div class="form-horizontal" >
                    <div class="row">
                        <div class="col-md-6 ">
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label" for="textfield1">Họ tên:</label>
                                <div class="col-sm-9 col-lg-9 controls">
                                    <input id="txtHoTen" class="form-control" type="text" placeholder="Nhập họ tên" runat="server" name="txtHoTen">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label" for="password1">Ngày sinh:</label>
                                <div class="col-sm-9 col-lg-9 controls">
                                      <input id="txtNgaySinh" class="form-control" type="text" placeholder="Nhập ngày sinh" runat="server" name="txtNgaySinh">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 col-lg-3 control-label">Giới tính</label>
                                <div class="col-sm-9 col-lg-9 controls">
                                <asp:RadioButton ID="RbNam" runat="server" Text="Nam" GroupName ="ChonGioiTinh"/> &nbsp;
                                <asp:RadioButton ID="RbNu" runat="server" Text="Nữ" GroupName ="ChonGioiTinh" />
                                <asp:Label ID="lbThongBaoChon" runat="server" Text="" BackColor="Red" ></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label">Dân tộc: </label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <input id="txtDanToc" class="form-control" type="text" placeholder="Nhập dân tộc" runat="server" name="txtDanToc">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label">Nơi sinh: </label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <input id="txtNoiSinh" class="form-control" type="text" data-rule-email="true" data-rule-required="true" runat="server" name="txtNoiSinh">    
                                </div>
                            </div>
                           <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label">Quê quán: </label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <input id="txtQueQuan" class="form-control" type="text" placeholder="Nhập quê quán:" runat="server" name="txtDanToc">
                                </div>
                            </div> 
                             <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label">Lĩnh vực nghiên cứu: </label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <input id="txtLinhVucNghienCuu" class="form-control" type="text" placeholder="Nhập lĩnh vực nghiên cứu:" runat="server" name="txtLinhVucNghienCuu">
                                </div>
                            </div> 
                        </div>


                        <div class="col-md-6 ">
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label">Số điện thoại: </label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <input id="txtSoDienThoai" class="form-control" type="text" placeholder="Nhập số điện thoại:" runat="server" name="txtDanToc">
                                </div>
                            </div>
                           <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label">Email: </label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <input id="txtEmail" class="form-control" type="email" data-rule-email="true" data-rule-required="true" runat="server" name="txtEmail">    
                                </div>
                            </div>
                           
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label" for="textfield2">Chức vụ:</label>
                                <div class="col-sm-9 col-lg-9 controls">
                                    <asp:DropDownList ID="cbbChucVu" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label" for="password2">Học vị:</label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <asp:DropDownList ID="cbbHocVi" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label" for="password2">Khoa:</label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <asp:DropDownList ID="cbbKhoa" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-xs-3 col-lg-3 control-label" for="password2">Môn giảng dạy:</label>
                                <div class="col-sm-9 col-lg-9 controls">
                                   <input id="txtDayChuyenNganh" class="form-control" type="text" placeholder="Nhập các môn giảng dạy:" runat="server" name="txtDayChuyenNganh">
                                </div>
                            </div>
                      
                            <div class="form-group">
                                <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2">
                                    <asp:Button Text="Sửa thông tin" ID="btnSua" runat="server" class="btn btn-primary" OnClick="btnSua_Click"  />
                                    <asp:Button Text="Hủy" ID="btnHuy" runat="server" class="btn btn-primary" OnClick="btnHuy_Click"   />
                                </div>
                           </div>
                        </div>     
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</div>

  <div class="row hidden-xs">
    <div class="col-md-12">
        <div class="box box-green">
            <div class="box-title">
                <h3>
                    <i class="icon-reorder">Thông tin Công tác</i>
                </h3>
                <div class="box-tool">
                    <a href="#" data-action="collapse">
                        <i class="icon-chevron-up"></i>
                    </a>
                    <a href="#" data-action="close">
                        <i class="icon-remove"></i>
                    </a>
                </div>
            </div>
            <div class="box-content">     
                <div class="form-horizontal" >
                    <div class="row">
                        <div class="col-md-6 ">
                            <div class="form-group">
                                <label class="col-xs-4 col-lg-4 control-label" for="textfield1">Trường Học Đại học:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <input id="txtTruongDaiHoc" class="form-control" type="text" placeholder="Nhập trường đại học" runat="server" name="txtTruongDaiHoc">
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-xs-4 col-lg-4 control-label" for="password1">Chuyên ngành đại học:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                      <input id="txtChuyenNganhDaiHoc" class="form-control" type="text" placeholder="Nhập chuyên ngành đại học" runat="server" name="txtChuyenNganhDaiHoc">
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label class="col-xs-4 col-lg-4 control-label">Năm tốt nghiệp đại học: </label>
                                <div class="col-sm-8 col-lg-8 controls">
                                   <input id="txtNamTotNghiepDaiHoc" class="form-control" type="text" placeholder="Nhập năm tốt nghiệp" runat="server" name="txtNamTotNghiepDaiHoc">
                                </div>
                            </div>
                         </div>
                        <div class="col-md-6 ">
                            <div class="form-group">
                                <label class="col-xs-4 col-lg-4 control-label">Trường Học học vị: </label>
                                <div class="col-sm-8 col-lg-8 controls">
                                   <input id="txtTruongHocVi" class="form-control" type="text" placeholder="Nhập tên trường học vị" runat="server" name="txtTruongHocVi">
                                </div>
                            </div>
                           <div class="form-group">
                                <label class="col-xs-4 col-lg-4 control-label">Chuyên ngành học vị: </label>
                                <div class="col-sm-8 col-lg-8 controls">
                                   <input id="txtChuyenNganhHocVi" class="form-control" type="text" data-rule-required="true" runat="server" name="txtChuyenNganhHocVi">    
                                </div>
                            </div>
                         
                            <div class="form-group">
                                <label class="col-xs-4 col-lg-4 control-label" for="password2">Năm tốt nghiệp học vị:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                   <input id="txtNamTotNghiepHocVi" class="form-control" type="text" placeholder="Nhập năm tốt nghiệp học vị:" runat="server" name="txtNamTotNghiepHocVi">
                                </div>
                            </div>
                      
                            <div class="form-group">
                                <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2">
                                    <asp:Button Text="Sửa" ID="btnSuaThongTinCongTac" runat="server" class="btn btn-primary" OnClick="btnSuaThongTinCongTac_Click"   />
                                    <asp:Button Text="Hủy" ID="btnHuyThongTinCongTac" runat="server" class="btn btn-primary" OnClick="btnHuyThongTinCongTac_Click"  />
                                </div>
                           </div>
                        </div>                
                </div>
            </div>
        </div>
    </div>
</div>
</div>



<script type="text/javascript">
    $(document).ready(function () {
  
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
