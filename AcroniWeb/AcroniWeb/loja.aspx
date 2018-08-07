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
                    <figure>
                        <a href="#Produto<%# Eval("id") %>"><asp:Image ID="imgFoto" class="img" runat="server"  ImageUrl='<%# Bind("id","~/img/Img ({0}).jpg") %>' /></a>
                        <figcaption>
                            <asp:Label class="descricao" ID="lblNome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                            <asp:Label class="descricao" ID="lblCidade" runat="server" Text=' <%# Bind("descricao") %>'></asp:Label>
                            <asp:Label class="descricao" ID="Label1" runat="server" Text='<%# Eval("preco") %>'></asp:Label>
                        </figcaption>
                    </figure>
                </li>

                <div id="Produto<%# Eval("id") %>" class="fundo">
                    <div class="janela">
                        <a href="#fecha" class="fecha-janela">x</a>
                        <div class="right">
                            <asp:Image ID="Image1" class="img-grande" runat="server"  ImageUrl='<%# Bind("id","~/img/produtos/Img ({0}).jpg") %>' /></a>
                        </div>
                        <div class="left">
                            
                         </div>
                    <div>
                 </div>

            </ItemTemplate>
        </asp:DataList>
      </ul>
       <!--<a href="Produto<%# Eval("id") %>.aspx"><div class="info">-->
       <!--<a href="Produto<%# Eval("id") %>.aspx">Produto <%# Eval("id") %></a>-->
       <script>
            if (window.location.hash.substr(1) == 'janela') { document.getElementById('Produto<%# Eval("id") %>').checked = true }
        </script> 
</asp:Content>

