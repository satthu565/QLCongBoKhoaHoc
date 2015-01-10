<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         Từ khóa : <input id="txtTimTenGiangVien"  type="text" onkeyup="Search()"/>   


           <h4 style="text-align:center">KẾT QUẢ TÌM KIẾM</h4>
  <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
               <div class="row" style="margin-bottom:3px;">
                 <div class="col-md-7 col-md-offset-1 ">
                  <b>   Họ tên : </b> <%# Eval("TenHocVi") %>.<%# Eval("TenGiangVien") %> <br />
                  <b>   Khoa : </b> <%# Eval("TenKhoa") %> <br />
                  <b>   Số điện thoại : </b> <%# Eval("DienThoai") %> <br />
                  <b>   Email : </b> <%# Eval("Email") %> <br />
                  <a href="/CV-Giang-Vien/TTC/<%#Eval("MaGiangVien") %>">Lý lịch Khoa Học</a>
                 </div>
                 <div class="col-md-4"> 
                     <img src="/images/<%#Eval("AnhDaiDien") %>" alt="Ảnh đại diện" width="120px" height="140px" />
                 </div>
               </div>
            </ItemTemplate>
  </asp:Repeater>

        <div style="overflow: hidden; text-align:center ; margin:5px auto" class="phantrang">
            <asp:Repeater ID="rptPages" runat="server"
                OnItemCommand="rptPages_ItemCommand1">
                <ItemTemplate>
                    <asp:LinkButton ID="btnPage"
                        Style="padding: 1px 3px; margin: 1px; background: #ccc; border: solid 1px #666;
                        font: 8pt tahoma;"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                        runat="server"><%# Container.DataItem %></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>

 <script type="text/javascript">

     $(document).ready(function () {
         alert("chay ham");
     });

     function Search() {
       //  alert($("#txtTimTenGiangVien").val().toString());    
         $.ajax({
             type: "POST",
             contentType: "application/json; charset=utf-8",
             url: "WebForm3.aspx/LoadData",
             data: "{}",
             dataType: "json",
             success: Thanhcong,
             error: function (result) {
                  alert("Error");
             }
         });
     }

     function Thanhcong()
     {
         alert("thanh cong roi");
     }


    </script>

