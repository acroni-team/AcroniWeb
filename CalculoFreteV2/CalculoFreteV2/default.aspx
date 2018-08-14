<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CalculoFreteV2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtCep" AutoPostBack="true" runat="server" OnTextChanged="txtCep_TextChanged"></asp:TextBox>
    </div>
        <p>
        <asp:Label ID="lblPreco" runat="server" Text=""></asp:Label>
        </p>
    </form>
</body>
</html>
