<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alquilerCoche.aspx.cs" Inherits="AppWeb.alquilerCoche" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: 24pt;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            
            <font size="6">UEMCoches</font><br class="auto-style1" />
            <font size="6">Alquilar </font>
            <asp:Label ID="lblTitulo" runat="server" CssClass="auto-style1"></asp:Label>
            
        </div>
        <div style="height: 497px">
            <asp:Image ID="imgCoche" runat="server" Height="136px" ImageUrl="~/coche.jpg" Width="148px" />
            <br />
            <br />
            Disponible:
            <asp:Label ID="lblDisponible" runat="server"></asp:Label>
            <br />
            Modelo: <asp:Label ID="lblModelo" runat="server"></asp:Label>
            <br />
            Año:
            <asp:Label ID="lblAno" runat="server"></asp:Label>
            <br />
            Color:
            <asp:Label ID="lblColor" runat="server"></asp:Label>
            <br />
            Puertas:
            <asp:Label ID="lblPuertas" runat="server"></asp:Label>
            <br />
            Combustible:
            <asp:Label ID="lblCombustible" runat="server"></asp:Label>
            <br />
            Prestaciones:<br />
            <asp:Label ID="lblPrestaciones" runat="server"></asp:Label>
            <br />
            <br />
            Valoracion:
            <asp:Label ID="lblValoracion" runat="server"></asp:Label>
            <br />
            Precio:&nbsp;
            <asp:Label ID="lblPrecio" runat="server"></asp:Label>
            <br />
            <br />
            Fecha de Alquiler (YYYY-MM-DD):
            <asp:TextBox ID="tbFAlquiler" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbFAlquiler" ErrorMessage="Introduce la Fecha de alquiler" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Fecha de Fin de Alquiler (YYYY-MM-DD): <asp:TextBox ID="tbFFin" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbFFin" ErrorMessage="Introduce la fecha de fin" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnAlquilar" runat="server" OnClick="btnAlquilar_Click" style="font-size: large" Text="Alquilame" />
&nbsp;
            <asp:Label ID="lblInfo" runat="server" style="font-size: large"></asp:Label>
        </div>
    </form>
</body>
</html>
