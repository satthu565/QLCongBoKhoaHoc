<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdUcCongBoKhoaHoc_Sua.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.AdUserControl.AdUcCongBoKhoaHoc_Sua" %>

<div style="text-align:center ; font-weight:bold ; font-size:18px;">
    <asp:Label ID="lbTieuDeThemSua" runat="server" Text="" ></asp:Label>
</div>
<br />
<div class="form-horizontal">
<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"> <b>Cấp đề tài : </b></label>
    <div class="col-sm-9 col-lg-9 controls">
        <asp:DropDownList ID="cbbCapDeTai" runat="server"></asp:DropDownList>     
    </div>
</div>

<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"><b> Tên công bố khoa học : </b> </label>
    <div class="col-sm-9 col-lg-9 controls">
           <input class="form-control" type="text" runat="server" id="txtTenCongBo" value="" placeholder="Nhập tên công bố khoa học">
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTenCongBo" ForeColor="Red">Nhập tên công bố</asp:RequiredFieldValidator>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"> <b> Nơi công bố : </b> </label>
    <div class="col-sm-9 col-lg-9 controls">
         <input class="form-control" type="text" runat="server" id="txtNoiCongBo" value="" placeholder="Nhập nơi công bố khoa học">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNoiCongBo" ForeColor="Red">Nhập nơi công bố</asp:RequiredFieldValidator>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"><b> Thời gian công bố : </b> </label>
    <div class="col-sm-9 col-lg-9 controls">
        <input class="form-control" type="text" runat="server" id="txtNamCongBo" value="" placeholder="ngày/tháng/năm">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNamCongBo" ForeColor="Red">Nhập năm công bố</asp:RequiredFieldValidator>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"><b> Mã số : </b> </label>
    <div class="col-sm-9 col-lg-9 controls">
       <input class="form-control" type="text" runat="server" id="txtMaSo" value="" placeholder="Nhập mã số công bố khoa học">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtMaSo" ForeColor="Red">Nhập mã số công bố</asp:RequiredFieldValidator>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"> <b> file mềm : </b> </label>
    <div class="col-sm-3 col-lg-3 controls">
        <asp:FileUpload ID="FileUpload1" runat="server" />  
    </div>
      <div class="col-sm-6 col-lg-6 controls">
      <b>  Tên file mềm hiện tại: </b> <asp:Label ID="lbFileMemHienTai" runat="server" Text=""></asp:Label>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"> <b> Chọn thành phần: </b> </label>
    <div class="col-sm-9 col-lg-9 controls">
        <asp:RadioButton ID="RBChuNhiemCongBo" runat="server" Text="Chủ nhiệm" GroupName ="ChonThanhPhan"/>
        &nbsp;
        <asp:RadioButton ID="RBThanhVienCongBo" runat="server" Text="Thành viên" GroupName ="ChonThanhPhan" />
        <asp:Label ID="lbThongBaoChon" runat="server" Text="" BackColor="Red" ></asp:Label>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"><b> Tác giả chủ nhiệm : </b> </label>
    <div class="col-sm-4 col-lg-4  controls">
        <input class="form-control" type="text" runat="server" id="txtTimKiemTenGiangVien" value="" placeholder="Nhập tên giảng viên tìm kiếm">
    </div>
    <div class="col-sm-1 col-lg-1 control-label">
        <asp:Button Text="Tìm kiếm" runat="server" ID="btnTimKiemTacGiaCongBo" OnClick="btnTimKiemTacGiaCongBo_Click" /></div>
    <div class="col-sm-1 col-lg-2 control-label">
        <asp:Button Text="Thêm vào danh sách" runat="server" ID="btnThemDanhSach" OnClick="btnThemDanhSach_Click" /></div>
    <div class="col-sm-2 col-lg-2 control-label">
        <asp:Button Text="Hủy hết danh sách chọn" runat="server" ID="btnHuyDanhSach" OnClick="btnHuyDanhSach_Click" /></div>
</div>


<div class="form-group">
    <div class="col-sm- 12 col-lg-12 controls">
        <div class="table-responsive">
            <asp:GridView ID="gvGiangVien" runat="server" AllowPaging="True" PageIndex="5" CssClass="table table-bordered table-hover"
                AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" DataKeyNames="MaGiangVien"
                ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvGiangVien_PageIndexChanging" >
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
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/images/AnhGiangVien/"+ Eval("AnhDaiDien") %>' Height="50px" Width="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="TenGiangVien" HeaderText="Tên giảng viên" ItemStyle-CssClass="col-lg-1" SortExpression="TenGiangVien">
                        <ItemStyle CssClass="col-lg-1"></ItemStyle>
                    </asp:BoundField>


                    <asp:BoundField DataField="TenKhoa" SortExpression="TenKhoa" HeaderText="Khoa" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
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
                    <label class="col-sm-2 col-lg-2 control-label"> <b> Danh sách chủ nhiệm: </b> </label>
                    <div class="col-sm-10 col-lg-10 controls">
                        <asp:Label ID="lbDanhSachChuNhiem" runat="server" Text=""></asp:Label> 
                    </div>
               </div>

            <div class="form-group">
                <label class="col-sm-2 col-lg-2 control-label"> <b> Danh sách thành viên: </b> </label>
                <div class="col-sm-10 col-lg-10 controls">
                    <asp:Label ID="lbDanhSachThanhVien" runat="server" Text=""></asp:Label>
                </div>
            </div>
<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"><b> Tên chủ nhiệm ngoài : </b> </label>
    <div class="col-sm-9 col-lg-9 controls">
       <input class="form-control" type="text" runat="server" id="txtTenChuNhiemNgoai" value="" placeholder="Nhập Tên chủ nhiệm ngoài">
    </div>
</div>

<div class="form-group">
    <label class="col-sm-2 col-lg-2 control-label"> <b> Tên thành viên ngoài : </b> </label>
    <div class="col-sm-9 col-lg-9 controls">
       <input class="form-control" type="text" runat="server" id="txtTenThanhVienNgoai" value="" placeholder="Nhập tên thành viên ngoài">
    </div>
</div>

<div class="form-group">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2">
        <asp:Button ID="btnThemCongBoKhoaHoc" runat="server" Text="Thêm công bố " class="btn btn-primary" OnClick="btnThemCongBoKhoaHoc_Click" />
        <asp:Button ID="BtnSuaCongBoKhoaHoc" runat="server" Text="Sửa công bố " class="btn btn-primary" OnClick="BtnSuaCongBoKhoaHoc_Click" />
        <asp:Button ID="btnHuy" runat="server" Text="Hủy" class="btn btn-primary" />
    </div>
</div>
    </div>