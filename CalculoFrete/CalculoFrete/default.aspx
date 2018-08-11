<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CalculoFrete._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Digite o CEP"></asp:Label>
        </div>
        <p>
            <asp:TextBox ID="txtCep" runat="server" AutoPostBack="true" OnTextChanged="txtCep_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblPreco" runat="server"></asp:Label>
        </p>
        
    </form>
</body>
</html>
