<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrjASPX_v2._0.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/login.css" />
</asp:Content>
		

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div id="left">
	        <img src="img/logo.png" />
        </div>
        <div id="right">
            <input type="text" placeholder="Usuário" name="user" />
            <input type="text" placeholder="Senha" name="senha" />
        </div>
    </section>
</asp:Content>
