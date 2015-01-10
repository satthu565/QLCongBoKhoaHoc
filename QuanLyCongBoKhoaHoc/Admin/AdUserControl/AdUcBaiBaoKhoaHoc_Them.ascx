<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcBaiBaoKhoaHoc_Them.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcBaiBaoKhoaHoc_Them" %>
<div class="col-md-12">
    <div class="box box-pink">
        <div class="box-title">
            <h3>
                <i class="icon-file"></i>
             THÊM BÀI BÁO KHOA HỌC
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
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Tên bài báo:</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <input class="form-control" type="text" runat="server" id="txtTenBaiBao" value="">       
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Thời gian xuất bản:</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <input class="form-control" type="text" runat="server" id="txtThoiGianXuatBan"  value="">     
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Nơi công bố:</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <input class="form-control" type="text" runat="server" id="txtNoiCongBo"  value="">     
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Giới hạn:</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <asp:DropDownList ID="cbbGioiHan" runat="server">
                            <asp:ListItem Value="1">Quốc tế</asp:ListItem>
                            <asp:ListItem Value="0">Trong nước</asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Mã số:</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <input class="form-control" type="text" runat="server" id="txtMaSo" value="" placeholder="Mã số bài báo">     
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 col-lg-2 control-label">Tác giả bài báo :</label>
                    <div class="col-sm-5 col-lg-5  controls">
                        <input class="form-control" type="text" runat="server" id="txtTimKiem" value="" placeholder="Nhập tên giảng viên tìm kiếm">     
                    </div>
                    <div class="col-sm-1 col-lg-1 control-label"> <asp:Button Text="Tìm kiếm" runat="server" ID="btnTimKiemBB" OnClick="btnTimKiemBB_Click" /></div>
                    <div class="col-sm-2 col-lg-2 control-label"> <asp:Button Text="Thêm vào danh sách" runat="server" ID="btnThemDanhSach" OnClick="btnThemDanhSach_Click" /></div>
                    <div class="col-sm-2 col-lg-2 control-label"> <asp:Button Text="Hủy hết danh sách chọn" runat="server" ID="btnHuyDanhSach" OnClick="btnHuyDanhSach_Click" /></div>
                </div>

               

                 <div class="form-group">
                    <div class="col-sm- 12 col-lg-12 controls">
                        <div class="table-responsive">
                            <asp:GridView ID="gvGiangVien" runat="server" AllowPaging="True" PageIndex="5" CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" DataKeyNames="MaGiangVien" 
                            ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvGiangVien_PageIndexChanging">
                            <Columns>
                                 <asp:TemplateField>
                                     <HeaderTemplate>
                                            <asp:CheckBox ID="cbChonTat" runat="server" onclick="cbChonTat(this);" />
                                     </HeaderTemplate>
                                    <ItemTemplate>
                                         <asp:CheckBox ID="cbChon" runat="server" onclick="cbChon(this);" />
                                    </ItemTemplate>
                                         <ItemStyle Width="9px" HorizontalAlign="Center"></ItemStyle>
                                 </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ảnh đại diện">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/images/"+ Eval("AnhDaiDien") %>' Height="50px" Width="50px" />
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:BoundField DataField="TenGiangVien" HeaderText="Tên giảng viên" ItemStyle-CssClass="col-lg-1" SortExpression="TenGiangVien" >
                                   <ItemStyle CssClass="col-lg-1"></ItemStyle>
                              </asp:BoundField>
                                    
                              
                              <asp:BoundField DataField="TenKhoa" SortExpression="TenKhoa" HeaderText="Khoa" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" >
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                              </asp:BoundField>
                                    <asp:BoundField DataField="NamSinh" SortExpression="NamSinh" HeaderText="ngày sinh" />
                                    <asp:BoundField DataField="NoiSinh" SortExpression="NoiSinh" HeaderText="Địa chỉ" />
                            </Columns>

                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Danh sách chọn:</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <asp:Label ID="lbDanhSachChon" runat="server" Text=""></asp:Label> 
                    </div>
               </div>
       

                <div class="form-group">
                    <label class="col-sm-3 col-lg-2 control-label">Tên Giảng viên ngoài:</label>
                    <div class="col-sm-9 col-lg-10 controls">
                        <input class="form-control" type="text" runat="server" id="txtTenGiangVienNgoai" value="">     
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 col-lg-2 control-label"><b>file mềm : </b></label>
                    <div class="col-sm-3 col-lg-3 controls">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                    <div class="col-sm-6 col-lg-6 controls">
                        <b>Tên file mềm hiện tại: </b>
                        <asp:Label ID="lbFileMemHienTai" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                 <div class="form-group">                            
                     <asp:Button ID="btnThemBaiBao" runat="server" CssClass="btn btn-primary" Text="THÊM" OnClick="btnThemBaiBao_Click" />
                     <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-primary" />
                </div>               
            </div>
        </div>
    </div>
</div>