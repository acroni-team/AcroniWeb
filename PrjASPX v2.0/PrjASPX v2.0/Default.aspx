<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrjASPX_v2._0.Default" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" type="text/css" href="css/index.css" />
</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <section id="lsection">
		<div>
			<h1> Acroni </h1><br>
			<p> Mais que um teclado. O seu.</p>
			<div id="buttons">
                <asp:Button class="blue" runat="server" Text="Baixar o software" />
                <asp:Button class="blue" runat="server"  Text="Teclados mecânicos" OnClientClick="return false;" />
            </div>
		</div>
	    </section>
	    <section id="rsection">
		    <div>
			    <img src="img/apple.png" id="img" />
		    </div>
	    </section>
	    <section style="height:1000px; width:100%;"></section>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

</asp:Content>