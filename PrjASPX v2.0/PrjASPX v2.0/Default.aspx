<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrjASPX_v2._0.Default" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" type="text/css" href="css/index.css" />
        <script type="text/javascript" src="js/tema.js"></script>
</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <section id="lsection">
		<div>
			<h1> Acroni </h1><br/>
			<p> Mais que um teclado. O seu.</p>
			<div id="buttons">
                <asp:Button class="blue" runat="server" Text="Fale conosco" OnClick="Unnamed1_Click" />
               <asp:Button id="muda2" class="blue" runat="server"  Text="Faça o login" OnClick="Unnamed2_Click"/> <!-- OnClientClick="return false;">   ClientIDMode="Static" OnClientClick="return false;--> 
            </div>
		</div>
	    </section>
	    <section id="rsection">
		    <div>
			    <img src="img/apple.png" id="img" />
		    </div>
	    </section>
        <script>
            document.getElementById("home").classList.add("active");
        </script>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

</asp:Content>