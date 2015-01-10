<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcYKienTraoDoi.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcYKienTraoDoi" %>

    <div class="HeadGopY" <% if (kt==1) Response.Write("style=display:none"); %> >
        <div class="TieuDe" style="text-align:center">
            <h3> <asp:Label Text="" ID="lbTenTieuDe" runat="server" /> </h3>
        </div>
        <div class="TacGia" >
           <b>Tác giả hoặc nhóm tác giả : </b>  <asp:Label Text="" ID="lbTenTacGia" runat="server" />
        </div>
        <div class="NoiCongBo" >
           <b> Nơi đăng : </b> <asp:Label Text="" ID="lbNoiDang" runat="server" />
           <b>  Mã số : </b> <asp:Label Text="" ID="lbMaSo" runat="server" />
           <b> Năm: </b> <asp:Label Text="" ID="lbNam" runat="server" />
        </div>
        <div class="TomTat">
             <b> <asp:Label Text="Tóm tắt :" ID="TomTat" runat="server" /> </b>  
             <asp:Label Text="" ID="lbTomTat" runat="server" />
        </div>
        <hr /> 
    </div>

    <h4 style="text-align:center"> Ý kiến trao đổi </h4>
  <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label"> Họ Tên:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                        <input id="txtHoTen" class="form-control" type="text" placeholder="Họ tên" runat="server" name="txtHoTen">   
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label"> Email:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                         <input id="txtEmail" class="form-control" type="text" placeholder="Email" runat="server" name="txtEmail">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label">Tiêu đề:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                         <input id="txtTieuDeBinhLuan" class="form-control" type="text" placeholder="Tiêu đề cho bình luận" runat="server" name="txtTieuDeBinhLuan">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label">Nội dung chi tiết:</label>
                    <div class="col-sm-9 col-lg-9 controls">
                       <textarea class="form-control" rows="3"  id="txtNoiDungBinhLuan" runat="server"  name="txtNoiDungBinhLuan" placeholder="Nội dung chi tiết" ></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-3 control-label"></label>
                    <div class="col-sm-9 col-lg-9 controls">
                        <asp:Button Text="Gửi ý kiến" ID="btnGuiYKien" runat="server" class="btn btn-primary" OnClick="btnGuiYKien_Click" OnClientClick=" return confirm('Bạn có muốn gửi ý kiến của mình đi không?.')" />
                        <asp:Label ID="ThongBao" runat="server" Text=""></asp:Label>
                     </div>
              </div>
  </div>
