<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrjASP.Default" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <section id="lsection">
		    <div>
			    <h1> Acroni </h1><br>
			    <p> Mais que um teclado, O seu. </p>
                <div id="buttons">
                    <asp:Button ID="Button1" runat="server" Text="Baixar o software" CssClass="blueButton" />
                    <asp:Button ID="Button2" runat="server"  Text="Teclados mecânicos" CssClass="blueButton" />
                </div>
   
		    </div>
	    </section>
	    <section id="rsection">
		    <div>
			    <img src="img/apple.png">
		    </div>
	    </section>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

</asp:Content>

