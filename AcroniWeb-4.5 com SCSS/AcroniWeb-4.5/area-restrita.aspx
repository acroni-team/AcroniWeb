<%@ Page Title="" Language="C#" MasterPageFile="~/layout.Master" AutoEventWireup="true" CodeBehind="area-restrita.aspx.cs" Inherits="AcroniWeb.area_restrita" %>
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
            <input style="width:500px;margin-top:30px;" class="textbox" type="text" placeholder="Entre com seu email e seja notificado" name="notifica" />
            <asp:Button class="button" type="button" Text="Entrar" runat="server" />
        </div>
    </section>

</asp:Content>
