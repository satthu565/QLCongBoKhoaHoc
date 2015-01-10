<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcChiTietTinNhanLienHe.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcChiTietTinNhanLienHe" %>
 
 <h3 style="text-align:center"> Chi tiết tin nhắn liên hệ </h3>
  <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label"> Email gửi:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                        <asp:Label Text="" runat="server" id="lbEmailGui" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label"> Họ tên người gửi:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                         <asp:Label Text="" runat="server" id="lbHoTen" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label">Tiêu đề:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                         <asp:Label Text="" runat="server" id="lbTieuDe" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label">Tin nhắn:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                       <textarea class="form-control" rows="3"  id="lbTinNhan" runat="server"  name="txtNoiDungBinhLuan" placeholder="Nội dung chi tiết" readonly="readonly"></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label"></label>
                    <div class="col-sm-9 col-lg-9 controls">
                       <a id="btThem" href="#thongTin" role="button" class="btn btn-primary" data-toggle="modal">Trả lời lại</a>
                     </div>
                 </div>
  </div>

<div id="thongTin" class="modal fade in" aria-hidden="false" >
    <div class="modal-dialog">
        <div class="modal-content">

         <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" >×</button>
              <h4 id="myModalLabel">GỬI EMAIL LIÊN HỆ LẠI </h4>
         </div>
            <div class="modal-body">
              <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Email gửi:</label>
                    <div class="col-sm-8 col-lg-8 controls">
                        <asp:TextBox ID="txtEmailGui" runat="server" class="form-control" data-rule-required="true" ></asp:TextBox>
                    </div>
                </div>   
                 <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Password:</label>
                    <div class="col-sm-8 col-lg-8 controls">
                        <asp:TextBox ID="txtPassWord" runat="server" class="form-control" data-rule-required="true" ></asp:TextBox>
                    </div>
                </div>  
                 <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Email nhận:</label>
                    <div class="col-sm-8 col-lg-8 controls">
                        <asp:TextBox ID="txtEmailNhan" runat="server" class="form-control" data-rule-required="true" ></asp:TextBox>
                    </div>
                </div>   
                 <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Tiêu đề:</label>
                    <div class="col-sm-8 col-lg-8 controls">
                        <asp:TextBox ID="txtTieuDe" runat="server" class="form-control" data-rule-required="true" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Tin nhắn:</label>
                    <div class="col-sm-8 col-lg-8 controls">
                        <asp:TextBox ID="txtTinNhan" runat="server" class="form-control" data-rule-required="true" ></asp:TextBox>
                </div>
                </div>            
                 <div class="form-group">
                    <label class="col-sm-4 col-lg-3 control-label">Đính kèm:</label>
                    <div class="col-sm-8 col-lg-8 controls">
                        <asp:FileUpload ID="FileUpload1" runat="server" /> 
                    </div>
                </div>    
                  
                     <div class="form-group">
                       <label class="col-sm-4 col-lg-3 control-label"></label>
                        <div class="col-sm-8 col-lg-8 controls">
                             <asp:Button ID="btnGuiMail" runat="server" Text="Gửi mail" class="btn btn-primary" OnClick="btnGuiMail_Click" />   
                          <asp:Button ID="btnHuy" runat="server" CssClass="btn btn-primary" Text="Hủy" />
                        </div>  
                    </div>
            </div>  
        </div>
    </div>
</div>


<script>

    $(document).ready(function () {
        if ('<%Response.Write(isClick.ToString());%>' == 'True') {
            $('#btThem').click();
        }

        $('#btThem').click(function () {
            $('#thongTin').find('input:not([type=submit])').val('');
            $('#thongTin').find('textarea').val('');    
        });
    });
</script>
