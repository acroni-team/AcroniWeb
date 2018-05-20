<%@ Page Language="vb" MasterPageFile="~/Layout.Master" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="PrjASPv1._0._Default" %> 

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <section id="lsection">
		    <div>
			    <h1> Acroni </h1><br>
			    <p> Mais que um teclado, O seu. Apoio ETAPA </p>
                <div id="buttons">
                    <a href="#">Baixe o software</a>
                    <a href="#">Teclados mecânicos</a>
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
