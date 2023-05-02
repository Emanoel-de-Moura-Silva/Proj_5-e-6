<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="proj5.CadastroUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Cadastre-se" ForeColor="#660066" 
            Font-Bold="True" Font-Size="X-Large"></asp:Label><br />
        <p><asp:Label ID="Label2" runat="server" Text="Use o formulário abaixo para criar nova conta." Font-Bold="True"></asp:Label></p>
        <asp:Label ID="Label3" runat="server" Text="Nome:" Font-Bold="True"></asp:Label><br />
        <asp:TextBox ID="txtNomeUsuario" runat="server" Width="247px"></asp:TextBox><br /><br />
        <asp:Label ID="Label4" runat="server" Text="E-Mail:" Font-Bold="True"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server" Width="237px"></asp:TextBox><br /><br />
        <asp:Label ID="Label5" runat="server" Text="Senha:" Font-Bold="True"></asp:Label><br />
        <asp:TextBox ID="txtSenha" type="password" runat="server" Width="95px"></asp:TextBox><br /><br />
        <asp:Label ID="Label6" runat="server" Text="Confirmação Senha:" Font-Bold="True"></asp:Label><br />
        <asp:TextBox ID="txtConfSenha" type="password" runat="server" Width="90px"></asp:TextBox><br /><br />
        <asp:Label ID="msgGeral" runat="server" Font-Bold="True" Font-Size="Medium" 
            ForeColor="#CC0000"></asp:Label>
        <p>
            <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Cadastro" 
                Font-Bold="True" onclick="btnFinalizar_Click" />
            <asp:Button ID="btnConexao" runat="server" Text="Conexao" 
                onclick="btnConexao_Click" style="position: relative; top: 0px; left: 40px" />
        </p>
         <asp:LinkButton ID="linkLogin" runat="server" PostBackUrl="~/Login.aspx">Login</asp:LinkButton>
    </div>
    </form>
</body>
</html>
