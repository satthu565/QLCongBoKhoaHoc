<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="QuanLyCongBoKhoaHoc.Admin.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asp.net Bind Data to Datatable using JQuery or JSON</title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
         
            
        });

        function Search() {
            var a = "";
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebForm2.aspx/BindDatatable",
                data: "{TenGiangVien:'"+$("#txtTimKiem").val().trim()+"'}",
                dataType: "json",
                success: function (data) {
                    for (var i = 0; i < data.d.length; i++) {
                        a = +data.d[i].TenGiangVien + ".";
                    //    $("#ThongTin").append("<b>" + data.d[i].TenGiangVien + "</b> <img src=" + "/images/" + data.d[i].AnhDaiDien + " alt=" + data.d[i].AnhDaiDien + " height='50px' ; width='50px' />   <input type='button' name="+ data.d[i].MaGiangVien+ "  value='Chọn' class=\"Chon\"/> " + "</br>")
                    }
                    $("#TextBox1").html(a);
                },
                error: function (result) {
                  //  alert("Error");
                }
            });
           }    
       
       
    </script>
    <style type="text/css">
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <input type="text" name="txtTimKiem" id="txtTimKiem"  onkeyup="Search()" />
       <div id="ThongTin"></div>
        <div>Tên :</div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <input type="button" name="11" value="Chọn" class="Chon" />
    </form>
</body>
</html>

<script type="text/javascript">

    $('#ThongTin > .Chon').click(function () {
         //  var magiangvien = $(this).attr("name").val();
         alert("an nut chon");
     });

     $('img').click(function () {
         alert("img click");
     });
 </script>