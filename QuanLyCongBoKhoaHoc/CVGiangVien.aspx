<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CVGiangVien.aspx.cs" Inherits="QuanLyCongBoKhoaHoc.CVGiangVien" %>

<%@ Register Src="~/UserControl/Banner.ascx" TagPrefix="uc1" TagName="Banner" %>
<%@ Register Src="~/UserControl/MenuNgang.ascx" TagPrefix="uc1" TagName="MenuNgang" %>
<%@ Register Src="~/UserControl/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/mst-style.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style type="text/css">
        .CV-AnhDaiDien {
            text-align:center;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <uc1:Banner runat="server" ID="Banner" />
            <uc1:MenuNgang runat="server" ID="MenuNgang" />
       </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3" style="border-right:2px solid #0094ff">
                <div class="row">
                    <div class="CV-AnhDaiDien">
                        <asp:Image ImageUrl="" runat="server" id="AnhDaiDien"  alt="Ảnh đại diện" width="150px" height="170px" />
                     </div>
                </div>
                 <div class="row" style="text-align:center">
                   <a class="CV-TenGiangVien"> <asp:Label Text="" ID="TenGiangVien" runat="server" /> </a>
                </div>
                    <hr />
              

              <div class="row">
                    <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/TTC"> Thông tin chung</a> </span> 
                    <hr />
                </div>

            <div class="row">
                 <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/CTKH"> Công trình Khoa học</a> </span> 
             </div>

            <div class="row">
                  <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/BBBCKH"> Bài báo ,Báo cáo khoa học </a> </span> 
             </div>

              <div class="row">
                   <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/HDSDH"> Hướng dẫn sau đại học</a> </span> 
              </div>

              <div class="row">
                     <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/SGT">Sách và giáo trình</a> </span> 
              </div>

              <div class="row">
                      <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/GTKH">Giải thưởng khoa học</a> </span> 
              </div>

              <div class="row"> 
                    <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/KT"> Khen thưởng </a></span> 
               </div>

              <div class="row">
                    <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/YKienTraoDoi/TinNhanRieng/1"> Gửi tin nhắn </a> </span> 
                    <hr />
              </div>

               <div class="row">
                     <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/DKCGV">Đăng ký chọn giảng viên</a> </span>
               </div>

               <div class="row">
                     <span class="glyphicon glyphicon-hand-right"> <a href="/CV-Giang-Vien/HC"> Hiệu chỉnh</a> </span>
               </div>

            </div>
            
            <div class="col-md-9">
                <div class="row">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">          
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
      <div class="row">
          <uc1:Footer runat="server" ID="Footer" />
      </div>
    </div>
</form>


    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/style.css" rel="stylesheet" />

<%--     css menu ngang--%>
    <link href="css/style1.css" rel="stylesheet" />

   <%-- js tin moi slide doc--%>
    <script src="/js/jquery-latest.js"></script>
    <script src="/js/jcarousellite_1.js"></script>

     <%--chay tin moi --%>
     <script type="text/javascript">
         $(function () {
             $(".newsticker-jcarousellite").jCarouselLite({
                 vertical: true,
                 hoverPause: true,
                 visible: 3,
                 auto: 500,
                 speed: 4000
             });
         });
    </script>
     <script type="text/javascript">
         var num = 150; //vị trí mà khi scroll chuột đến sẽ bắt đầu sự kiện
         $(window).bind('scroll', function () {
             if ($(window).scrollTop() > num) {
                 $('#Menu').addClass('fixed-menu');
             }
             else {
                 $('#Menu').removeClass('fixed-menu');
             }
         });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".glyphicon-remove").click(function () {
                $(this).parents(".panel").remove();

            });

            $(".glyphicon-resize-vertical").click(function () {
                $(this).parents('.panel').find('.panel-body').slideToggle("slow");
            });

        });
     </script>
    
</body>
</html>


