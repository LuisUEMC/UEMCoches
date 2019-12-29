<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AppWeb.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: 13pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1" style="font-size: 24pt">
            <br />
            <br />
            <br />
            UEMCoches<br />
            Login</div>
        <div class="auto-style1" style="height: 194px">
            <span class="auto-style2">Nombre de Usuario:&nbsp; </span>
            <asp:TextBox ID="tbUsuario" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsuario" ErrorMessage="Introduce el nombre de usuario" ForeColor="Red" CssClass="auto-style2"></asp:RequiredFieldValidator>
            <br class="auto-style2" />
            <span class="auto-style2">Contraseña:&nbsp; </span>
            <asp:TextBox ID="tbPass" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPass" ErrorMessage="Introduce la contraseña" ForeColor="Red" CssClass="auto-style2"></asp:RequiredFieldValidator>
            <br class="auto-style2" />
            <br class="auto-style2" />
            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="auto-style2" OnClick="btnEntrar_Click" />
            <span class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span>
            <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" CssClass="auto-style2" CausesValidation="False" OnClick="btnRegistro_Click" />
            <br class="auto-style2" />
            <br class="auto-style2" />
            <asp:Label ID="lblInfo" runat="server" CssClass="auto-style2" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
