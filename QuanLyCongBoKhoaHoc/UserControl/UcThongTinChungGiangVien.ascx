<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcThongTinChungGiangVien.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcThongTinChungGiangVien" %>

<%@ Register Src="~/UserControl/LyLichKhoaHoc.ascx" TagPrefix="uc1" TagName="LyLichKhoaHoc" %>
<%@ Register Src="~/UserControl/UcQuaTrinhGiangDayVaCongTac.ascx" TagPrefix="uc1" TagName="UcQuaTrinhGiangDayVaCongTac" %>
<%@ Register Src="~/UserControl/UcDeTaiCongTrinhKhoaHoc.ascx" TagPrefix="uc1" TagName="UcDeTaiCongTrinhKhoaHoc" %>
<%@ Register Src="~/UserControl/UcBaiBaoKhoaHoc.ascx" TagPrefix="uc1" TagName="UcBaiBaoKhoaHoc" %>
<%@ Register Src="~/UserControl/UcSachVaGiaoTrinh.ascx" TagPrefix="uc1" TagName="UcSachVaGiaoTrinh" %>
<%@ Register Src="~/UserControl/UcGiaiThuongKhoaHoc.ascx" TagPrefix="uc1" TagName="UcGiaiThuongKhoaHoc" %>
<%@ Register Src="~/UserControl/UcKhenThuong.ascx" TagPrefix="uc1" TagName="UcKhenThuong" %>







<uc1:LyLichKhoaHoc runat="server" ID="LyLichKhoaHoc" /> <br />
<uc1:UcQuaTrinhGiangDayVaCongTac runat="server" ID="UcQuaTrinhGiangDayVaCongTac" />
<uc1:UcDeTaiCongTrinhKhoaHoc runat="server" ID="UcDeTaiCongTrinhKhoaHoc" />
<uc1:UcBaiBaoKhoaHoc runat="server" ID="UcBaiBaoKhoaHoc" />
<uc1:UcSachVaGiaoTrinh runat="server" ID="UcSachVaGiaoTrinh" />
<uc1:UcGiaiThuongKhoaHoc runat="server" ID="UcGiaiThuongKhoaHoc" />
<uc1:UcKhenThuong runat="server" ID="UcKhenThuong" />
