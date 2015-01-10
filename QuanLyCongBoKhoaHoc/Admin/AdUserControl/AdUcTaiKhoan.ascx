<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcTaiKhoan.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUserTaiKhoan" %>

<div class="row">
    <div class="col-md-12">
        <div class="box">
            <div class="box-title">
                <h3><i class="icon-reorder"></i> THAY ĐỔI MẬT KHẨU </h3>
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
                <div class="form-horizontal">
                    <div class="form-group">
                             <label class="col-sm-3 col-lg-3 control-label"> <b>Mật khẩu cũ:</b></label>
                        <div class="col-sm-6 col-lg-4 controls">            
                             <input id="txtMatKhauCu" runat="server" class="form-control" type="password" placeholder="Mật khẩu cũ của bạn" name="txtMatKhauCu">
                             <asp:Label ID="lbThongBao" runat="server" Text="" BackColor="Red"></asp:Label>
                        </div>
                    </div>

                      <div class="form-group">
                             <label class="col-sm-3 col-lg-3 control-label" for="password"><b> Mật khẩu mới:</b></label>
                        <div class="col-sm-6 col-lg-4 controls">            
                             <input id="txtMatKhauMoi"  runat="server" class="form-control" type="password" placeholder="Mật khẩu mới của bạn" name="txtMatKhauMoi">
                        </div>
                    </div>

                     <div class="form-group">
                             <label class="col-sm-3 col-lg-3 control-label" for="password"><b> Nhập Lại mật khẩu mới:</b></label>
                        <div class="col-sm-6 col-lg-4 controls">            
                             <input id="txtMatKhauMoi1"  runat="server" class="form-control" type="password" placeholder="Nhâp lại mật khẩu mới của bạn" name="txtMatKhauMoi1">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Chưa trùng khớp mật khẩu mới" ControlToCompare="txtMatKhauMoi" ControlToValidate="txtMatKhauMoi1" ForeColor="Red"></asp:CompareValidator>
                       </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-9 col-sm-offset-4 col-lg-10 col-lg-offset-2">
                            <asp:Button ID="BtnXacNhan" runat="server" Text="Xác nhận" CssClass="btn btn-primary" OnClick="BtnXacNhan_Click" />
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-pink" />
                        </div>
                    </div>

              </div>  
            </div>
        </div>
    </div>
</div>