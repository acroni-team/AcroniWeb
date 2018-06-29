<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CadastroLogin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Usuário"></asp:Label>
        <br />
        <div>
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblErro" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnEntrar" runat="server" OnClick="btnEntrar_Click" Text="Entrar" />
            <asp:Button ID="btnRedirect" runat="server" OnClick="btnRedirect_Click" Text="Cadastrar" />
        </p>
    </form>
</body>
</html>
