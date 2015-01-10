<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcHome.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcHome" %>
<link href="../css/mst-style.css" rel="stylesheet" />
<link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">
<link href="../css/font-awesome.css" rel="stylesheet" />
<script src="../js/jquery-1.8.3.min.js"></script>
<script src="../js/MST-js.js"></script>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
<div class="cssTimKiem">
    <div class="container-fluid">
        <div class="row ">
            <div class="col-lg-12" style="text-align: center;">
                <h3 style="font-weight:bold;color: #4A72B8;">Tìm Kiếm Cán Bộ Giảng Viên </h3>
            </div>
        </div>
        <hr style="width:100%;border-top: 1px solid #CFCFCF;margin-top: 0px;"/>
        <div class="row">
            <div class="col-lg-3 col-md-6 col-md-push-1 col-md-offset-2">    <%--col-md-push-1 col-md-offset-1--%>
                <label class="control-label" for="inputEmail" style="">Tên giảng viên </label>
            </div>
            <div class="col-lg-4 col-md-6"> 
                <asp:TextBox id="txtTenGiangVien" runat="server" placeholder="Tên giáo viên" CssClass="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-push-1 col-md-offset-2">
                <label class="control-label" for="inputEmail" style="">Khoa : </label>
            </div>
            <div class="col-lg-4" >
                <asp:DropDownList ID="cbbKhoa" runat="server" CssClass="btn btn-default dropdown-toggle mst-width100" >

                </asp:DropDownList>
            </div>
        </div>

        <div class="row" style="padding-bottom:10px">
            <div class="col-lg-3 col-md-push-1 col-md-offset-2 ">
            </div>
            <div class="col-lg-7">
                <asp:Button ID="btnTimKiem" class=" btn btn-primary btn-timkiem" runat ="server" Text="Tìm kiếm" OnClick="btnTimKiem_Click" />
            </div>
        </div>
    </div>
</div>

<h3 style="text-align:center;padding-top:10px">DANH SÁCH GIẢNG VIÊN</h3>
<hr style="width: 36%;margin-top: 10px;margin-bottom: 10px;border-top: 1px solid #B8B8B8;"/>
<div class="wrap-khung row">
   <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                    <div class="khung col-md-4" style="min-height:400px;">
                        <div style="padding-top:20px;border: 1px solid #A9A7A7;border-style: dotted;box-shadow: 10px 10px 5px #e9e9e9;border-radius:5px">
                            <div class="row" style="text-align:center"> <a href="/CV-Giang-Vien/TTC/<%#Eval("MaGiangVien") %>"> <img src="/images/AnhGiangVien/<%#Eval("AnhDaiDien") %>"  alt="Ảnh đại diện" width="195px" height="185px" style="border-radius:5px"/> </a> </div>
                            <div class="row button-detail">  
                                <a class="box-left pull-left ">
                                    <i class="fa fa-heart fa-lg "></i>
                                </a>
                                <a class="box-right pull-right animate ">
                                    <i class="fa fa-refresh fa-lg"></i>
                                </a>
                                <a href="/CV-Giang-Vien/TTC/<%#Eval("MaGiangVien") %>" class="btn btn-default btn-add btn-add-cart btn-icon icon-cart glyphicon glyphicon-search" style="padding-top:4px;padding-left: 0px;width: auto;font-size: 11px;">
                                    <span style="position: relative;left: 6px;top: 6px;font-size: 12px;font-weight:bold;font-family: normal">Lý lịch chi tiết</span>
                                </a> 
                            </div>
                            <div class="wrap-content-view">
                                <div class="row">  <b> <%# Eval("TenHocVi") %>.<%# Eval("TenGiangVien") %></b></div>
                                <div class="row">  <b>   Khoa : </b> <%# Eval("TenKhoa") %>  </div>
                                <div class="row">  <b>   Số điện thoại : </b> <%# Eval("DienThoai") %> </div>
                                <div class="row">  <b>   </b> <%# Eval("Email") %> </div>
                            </div>
                            <div class="Quick-view">
                                <a href="#" class="btn quickview">
                                    <span style="font-size:12px" data-toggle="modal" data-target="#myModal">XEM NHANH</span>
                               
                                </a>
                                <!-- Modal -->
                                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                  <div class="modal-dialog">
                                    <div class="modal-content">
                                      <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" id="myModalLabel">Thông Tin Giảng Viên</h4>
                                      </div>
                                      <div class="modal-body">
                                          <table class="table table-responsive table-condensed">
                                              <tr>
                                                  <td class="table-left">Họ và tên:</td>
                                                  <td class="table-right">Giang vien 1</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Giới tính:</td>
                                                  <td class="table-right">nam</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Năm sinh:</td>
                                                  <td class="table-right">12/12/1983</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Quê quán:</td>
                                                  <td class="table-right">sơn la</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Đơn vị công tác:</td>
                                                  <td class="table-right">Công nghệ thông tin</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Chức vụ:</td>
                                                  <td class="table-right">Phó phòng</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Dạy CN:</td>
                                                  <td class="table-right">Tin học</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Lĩnh vực nghiên cứu:</td>
                                                  <td class="table-right">Toán tin</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Điện thoại</td>
                                                  <td class="table-right">121242342</td>
                                              </tr>
                                              <tr>
                                                  <td class="table-left">Email</td>
                                                  <td class="table-right">gv1.@gmail.com</td>
                                              </tr>
                                          </table>
                                      </div>
                                      <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                                <%--them modal--%>
                            </div>
                            <div class="Line"></div>
                        </div>
                    </div>
            </ItemTemplate>
    </asp:Repeater>
</div>
   <%--     <div style="overflow: hidden; text-align:center ; margin:5px auto ; clear:both" class="phantrang ">
            <asp:Repeater ID="rptPages" runat="server"
                OnItemCommand="rptPages_ItemCommand1">
                <ItemTemplate>
                    <asp:LinkButton ID="btnPage" class="pagination"
                        Style="position: relative;padding: 6px 12px;margin-left: -1px;line-height: 1.42857143;color: #337ab7;text-decoration: none;background-color: #fff;border: 1px solid #ddd;"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                        runat="server"><%# Container.DataItem %></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>
 <div style="overflow: hidden; text-align: center; margin: 5px auto; clear: both" class="phantrang">
            <asp:Repeater ID="rptPages" runat="server"
                OnItemCommand="rptPages_ItemCommand1" OnItemDataBound="rptPages_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton ID="btnPage" class="pagination" Text="<%# Convert.ToInt32(Container.DataItem) %>"
                        Style="position: relative;padding: 6px 12px;margin-left: -1px;line-height: 1.42857143;color: #337ab7;text-decoration: none;background-color: #fff;border: 1px solid #ddd;"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                        runat="server"><%# Container.DataItem %></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
<script src="../js/MST-js.js"></script>
</ContentTemplate>
</asp:UpdatePanel>