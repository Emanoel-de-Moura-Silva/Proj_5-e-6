<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="proj5.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" ForeColor="#660066" Text="Identificação do Usuario"></asp:Label>
            <br />
        </div>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Entre com e-mail e senha"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Caso ainda não  tenha conta, "></asp:Label>
        <asp:LinkButton ID="linkCadastro" runat="server" PostBackUrl="~/CadastroUsuario.aspx">Cadastre-se</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="E-mail:"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Senha"></asp:Label>
        <br />
        <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="MsgGeral" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
    </form>
</body>
</html>
