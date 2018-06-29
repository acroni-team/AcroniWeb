<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="CadastroLogin.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:TextBox ID="txtNome" runat="server" placeholder="Nome"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtEmail" runat="server" placeholder="E-mail"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtCPF" runat="server" placeholder="CPF"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtData" runat="server" placeholder="Data de nascimento"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtRG" runat="server" placeholder="RG"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtEndereco" runat="server" placeholder="Endereço"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtCidade" runat="server" placeholder="Cidade"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtCEP" runat="server" placeholder="CEP"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtUF" runat="server" placeholder="UF"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtTelefone" runat="server" placeholder="Telefone"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtUsu" runat="server" placeholder="Usuário"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtPass" runat="server" placeholder="Senha"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtPass2" runat="server" placeholder="Confirme a senha"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblErro" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" Text="Cadastrar" />
        </div>
    </form>
</body>
</html>
