<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Slides.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.Slides" %>

<div id="carousel-example-captions" class="carousel slide" data-ride="carousel">
    <ol class="carousel-indicators">
        <% for (int i = 0; i < TbSlide.Rows.Count; i++)
           {%>
        <li data-target="#carousel-example-captions" data-slide-to="<%Response.Write(i.ToString());%>"
            class='<% if (i == 0) Response.Write("active"); %>'></li>
        <% } %>
    </ol>
    <div class="carousel-inner">
        <% for (int i = 0; i < TbSlide.Rows.Count; i++)
           {%>
        <div class="item <% if (i == 0) Response.Write("active"); %>">
            <img alt="<% Response.Write("../images/Slides/" + TbSlide.Rows[i]["TieuDe"].ToString()); %>"
                src='<% Response.Write("/images/Slides/" + TbSlide.Rows[i]["Anh"].ToString()); %>'
                style="height: 300px; margin: auto" />
           <%-- <div class="carousel-caption">
                <h3><% Response.Write(TbSlide.Rows[i]["TieuDe"].ToString()); %></h3>
                <p><% Response.Write(TbSlide.Rows[i]["MoTa"].ToString()); %></p>
            </div>--%>
        </div>
        <% } %>
    </div>

    <a  rel="nofollow" class="left carousel-control" href="#carousel-example-captions" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left"></span>
    </a>
    <a rel="nofollow" class="right carousel-control" href="#carousel-example-captions"
        data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
    </a>
</div>