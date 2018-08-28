<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="loja.aspx.cs" Inherits="AcroniWeb.loja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/loja.css" rel="stylesheet" type="text/css"/>
		<script type="text/javascript">
            var _gaq = _gaq || [];
            _gaq.push(['_setAccount', 'UA-7243260-2']);
            _gaq.push(['_trackPageview']);
            (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
            })();
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo"></div>
    <ul class="grid">
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
            <ItemTemplate>
                
                <li>  
                    <figure id="click<%# Eval("id") %>" name="<%# Eval("id") %>">
                        <%--<a href="#Produto<%# Eval("id") %>">--%><asp:Image ID="imgFoto" class="img" runat="server"  ImageUrl='<%# Bind("id","~/img/produtos/Img ({0}).jpg") %>' /><%--</a>--%>
                        <figcaption>
                            <asp:Label class="descricao" ID="lblNome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                            <asp:Label class="descricao" ID="lblCidade" runat="server" Text=' <%# Bind("descricao") %>'></asp:Label>
                            <asp:Label class="descricao" ID="Label1" runat="server" Text='<%# Eval("preco") %>'></asp:Label>
                        </figcaption>
                    </figure>
                </li>

                <div id="Produto<%# Eval("id") %>" class="modal-wrap modal-wrap-loja">
                    <div class="modal-body modal-body-loja">
                        <a class="fecha-janela">x</a>
                        <div class="right">
                            <asp:Image ID="Image1" class="img-grande" runat="server"  ImageUrl='<%# Bind("id","~/img/produtos/Img ({0}).png") %>' /></a>
                        </div>
                        <div class="left">
                        </div>
                    <div class="modal-background"><div>
                 </div>

            </ItemTemplate>
        </asp:DataList>
      </ul>
       <!--<a href="Produto<%# Eval("id") %>.aspx"><div class="info">-->
       <!--<a href="Produto<%# Eval("id") %>.aspx">Produto <%# Eval("id") %></a>-->
    <script>
        $('figure').click(function () {
            var id = $(this).attr("name"); 
            $("#Produto"+id).removeClass("animate-out").addClass("is-showing animate-in");
             $("body").niceScroll().remove();
        
        $('.modal-background, .fecha-janela').click(function () {
            $("body").niceScroll({ cursorcolor: "#0093ff", cursorwidth: "10px", cursorborder: "none" });
            $("#Produto"+id).removeClass("is-showing animate-in").addClass("animate-out");
        });
        });
     
    </script>
</asp:Content>

