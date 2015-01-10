<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcDangKyChonGiangVien.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcDangKyChonGiangVien" %>

<div class="row">
      <div class="panel panel-primary">
          <div class="panel-heading">
                <h3 class="panel-title">Đăng Ký Giáo Viên Hướng Dẫn
                    <span class="pull-right glyphicon glyphicon-remove"></span> 
                    <span class="pull-right glyphicon glyphicon-resize-vertical"></span>       
                </h3>
          </div>
          <div class="panel-body">
                <div id="validation-form" class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Họ tên học viên:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtHoTen" CssClass="form-control" runat="server" placeholder="Nhập tên của bạn"></asp:TextBox>
                                </div>
                            </div>

                           <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label">Giới tính:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:DropDownList ID="cbbGioiTinh" runat="server">
                                        <asp:ListItem Value="True">Nam</asp:ListItem>
                                        <asp:ListItem Value="False">Nữ</asp:ListItem>
                                    </asp:DropDownList> 
                                </div>
                            </div>

                           <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Ngày sinh:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtNgaySinh" CssClass="form-control" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                                </div>
                            </div>

                          <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Số điện thoại:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtSoDienThoai" CssClass="form-control" runat="server" placeholder="Nhập số điện thoại"></asp:TextBox>
                                </div>
                            </div>

                           <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Chuyên ngành:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtChuyenNganh" CssClass="form-control" runat="server" placeholder="Nhập chuyên ngành"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Trường:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtTruong" CssClass="form-control" runat="server" placeholder="Nhập trường học và làm việc"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Học vị:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:DropDownList ID="cbbHocVi" runat="server">    
                                    </asp:DropDownList> 
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-lg-3  control-label" for="username">Số CMND:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtCMND" CssClass="form-control" runat="server" placeholder="Nhập số chứng minh nhân dân"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Email:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Nhập email đúng để đăng ký,nhận thông báo"></asp:TextBox>
                                </div>
                            </div>

                             <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Quê quán:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtQueQuan" CssClass="form-control" runat="server" placeholder="Nhập quê quán bạn"></asp:TextBox>
                                </div>
                            </div>

                           <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Tin nhắn:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                     <textarea class="form-control" rows="3"  id="txtTinNhan" runat="server"  name="txtTinNhan" placeholder="Nội dung tin nhắn"> </textarea>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" ></label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:Button ID="btnDangKy" runat="server" Text="Đăng ký" OnClick="btnDangKy_Click" />
                                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" />
                                </div>
                            </div>
                   </div>
 
          </div>
    </div>
</div>

<div class="row">
      <div class="panel panel-primary">
          <div class="panel-heading">
                <h3 class="panel-title"> Xác Nhận Đăng Ký
                    <span class="pull-right glyphicon glyphicon-remove"></span> 
                    <span class="pull-right glyphicon glyphicon-resize-vertical"></span>       
                </h3>
          </div>
          <div class="panel-body">
                   <div id="Div1" class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label" >Mã học viên xác nhận:</label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:TextBox ID="txtMaHocVien" CssClass="form-control" runat="server" placeholder="Nhập mã học viên xác nhận"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-4 col-lg-3 control-label"></label>
                                <div class="col-sm-8 col-lg-8 controls">
                                    <asp:Button ID="Button1" runat="server" Text="Xác nhận" OnClick="btnXacNhan" />
                                </div>
                           </div>
                   </div>
          </div>

    </div>
</div>