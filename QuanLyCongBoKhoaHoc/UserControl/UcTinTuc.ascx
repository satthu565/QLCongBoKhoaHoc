<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcTinTuc.ascx.cs" Inherits="QuanLyCongBoKhoaHoc.UserControl.UcTinTuc" %>

 <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="media">
                    <a rel="nofollow" class="pull-left" href='<%# "/Tin-tuc/"+ ChuanHoaTieuDe(Eval("TieuDe").ToString())+"/"+ Eval("idTinTuc") %>'>       
                        <%# Eval("AnhDaiDien") != DBNull.Value ? "<img src=\"../images/TinTuc/"+Eval("AnhDaiDien")+"\" width=\"128px\" height=\"128px\" alt=\"Alternate Text\" />" : string.Empty %>                
                    </a>
                    <div class="media-body">
                        <a rel="nofollow" href='<%# "/Tin-tuc/"+ ChuanHoaTieuDe(Eval("TieuDe").ToString())+"/"+ Eval("idTinTuc") %>'>
                            <h3 class="media-heading"><%# Eval("TieuDe") %> </h3>
                        </a>
                        <%# Eval("MoTa") %>
                        <ul class="pager">
                            <li class="next"><a rel="nofollow" href='<%# "/Tin-tuc/"+ ChuanHoaTieuDe(Eval("TieuDe").ToString()) +"/"+ Eval("idTinTuc") %>' >Chi tiết &rarr;</a></li>
                        </ul>
                    </div>
                </div>
            </ItemTemplate>
  </asp:Repeater>

        <div style="overflow: hidden; text-align:center ; margin:5px auto ; clear:both" class="phantrang">
            <asp:Repeater ID="rptPages" runat="server"
                OnItemCommand="rptPages_ItemCommand1">
                <ItemTemplate>
                    <asp:LinkButton ID="btnPage" class="pagdingpage"
                        Style="padding: 1px 3px; margin: 1px; background: #ccc; border: solid 1px #666;
                        font: 8pt tahoma;"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                        runat="server"><%# Container.DataItem %></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>