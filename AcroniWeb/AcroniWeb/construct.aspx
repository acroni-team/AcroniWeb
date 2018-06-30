<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="construct.aspx.cs" Inherits="AcroniWeb.img.construct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="css/area-restrita.css" />
    <link rel="stylesheet" type="text/css" href="css/login.css" />
    <link rel="stylesheet" type="text/css" href="css/default.css" />
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div>
            <h1>Em Breve</h1>
            <p>Estamos trabalhando para construir essa página</p>
            <input style="width:500px;margin-top:30px;" class="caixxinha" type="text" placeholder="Entre com seu email e seja notificado" name="notifica" />
            <asp:Button class="button" type="button" Text="Enviar" runat="server"/>
        </div>
    </section>

</asp:Content>
