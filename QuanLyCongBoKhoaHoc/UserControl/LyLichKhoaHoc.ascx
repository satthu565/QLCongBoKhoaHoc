<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LyLichKhoaHoc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.LyLichKhoaHoc" %>
<div class="panel panel-primary">
    <div class="panel-heading">
        <h3 class="panel-title">Lý lịch khoa học
                                     <span class="pull-right glyphicon glyphicon-remove"></span>
            <span class="pull-right glyphicon glyphicon-resize-vertical"></span>
        </h3>
    </div>
    <div class="panel-body" style="padding-bottom:0px">
        <asp:DetailsView ID="DVLyLichGiangVien" runat="server"  AutoGenerateRows="False" BorderStyle="double" BorderWidth="1px" CellPadding="3" GridLines="Vertical" CssClass="table table-responsive table-condensed table-ttc">
            <AlternatingRowStyle  />
            <EditRowStyle  Font-Bold="True"  />
            <Fields>
                <asp:BoundField DataField="TenGiangVien" HeaderText="Họ và tên:" />
                <asp:TemplateField HeaderText="Giới tính">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# GioiTinh(bool.Parse(Eval("GioiTinh").ToString())) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NamSinh" HeaderText="Năm sinh:" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="NoiSinh" HeaderText="Nơi sinh:" />
                <asp:BoundField DataField="QueQuan" HeaderText="Quê quán:" />
                <asp:BoundField DataField="TenKhoa" HeaderText="Đơn vị công tác" />
                <asp:BoundField DataField="TenChucVu" HeaderText="Chức vụ:" />
                <asp:BoundField DataField="DayCN" HeaderText="Dạy CN:" />
                <asp:BoundField DataField="LinhVucNC" HeaderText="Lĩnh vực nghiên cứu:" />
                <asp:BoundField DataField="DiaChiLienHe" HeaderText="Địa chỉ liên hệ" />
                <asp:BoundField DataField="DienThoai" HeaderText="Điện thoại" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField HeaderText="Tốt nghiệp ĐH chuyên ngành:">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ChuyenNganhDaiHoc") +"Trường:"+Eval("TruongDaiHoc") + "Năm:"+ String.Format("{0:dd/MM/yyyy}",Eval("NamTotNghiepDaiHoc")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Học vị">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("TenHocVi")+"Chuyên ngành:"+ Eval("ChuyenNganhHocVi") +"Trường:"+Eval("TruongHocVi") + "Năm:"+ String.Format("{0:dd/MM/yyyy}", Eval("NamTotNghiepHocVi") ) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <FooterStyle />
            <HeaderStyle  />
            <PagerStyle  HorizontalAlign="Center" />
            <RowStyle />
        </asp:DetailsView>
    </div>
</div>      