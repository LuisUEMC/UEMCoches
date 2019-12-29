<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="AppWeb.Registro" %>

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
            Registro</div>
        <div class="auto-style1" style="height: 351px">
            <span class="auto-style2">Nombre:&nbsp; </span>
            <asp:TextBox ID="tbNombre" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbNombre" ErrorMessage="Introduce el Nombre" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br class="auto-style2" />
            <span class="auto-style2">Apellidos:&nbsp; </span>
            <asp:TextBox ID="tbApellidos" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbApellidos" ErrorMessage="Introduce los Apellidos" ForeColor="Red"></asp:RequiredFieldValidator>
            <br class="auto-style2" />
            <span class="auto-style2">Edad:&nbsp; </span>
            <asp:TextBox ID="tbEdad" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEdad" ErrorMessage="Introduce la edad" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label ID="lblEdad" runat="server" ForeColor="Red" Text="Debes de ser mayor de edad" Visible="False"></asp:Label>
            <br class="auto-style2" />
            <span class="auto-style2">Nombre de Usuario:&nbsp; </span>
            <asp:TextBox ID="tbUsuario" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbUsuario" ErrorMessage="Introduce el Usuario" ForeColor="Red"></asp:RequiredFieldValidator>
            <br class="auto-style2" />
            <span class="auto-style2">Contraseña:&nbsp; </span>
            <asp:TextBox ID="tbPass" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbPass" ErrorMessage="Introduce la Contraseña" ForeColor="Red"></asp:RequiredFieldValidator>
            <br class="auto-style2" />
            <span class="auto-style2">Repite la Contraseña:&nbsp; </span>
            <asp:TextBox ID="tbPass2" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Repite la contraseña" ForeColor="Red" ControlToValidate="tbPass2"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPass" ControlToValidate="tbPass2" ErrorMessage="La contraseña no es la misma" ForeColor="Red"></asp:CompareValidator>
            <br class="auto-style2" />
            <br class="auto-style2" />
            <asp:Button ID="btnRegistro" runat="server" CssClass="auto-style2" OnClick="btnRegistro_Click" Text="Registrarse!" />
            <br class="auto-style2" />
            <br class="auto-style2" />
            <asp:Label ID="lblInfo" runat="server" CssClass="auto-style2"></asp:Label>
        </div>
    </form>
</body>
</html>
