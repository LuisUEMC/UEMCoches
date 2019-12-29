<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="AppWeb.home" %>

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
            <font size="6">Home<br />
            <br />
            <br />
            </font>
        </div>
        <div style="height: 269px">
            <asp:Panel ID="Panel1" runat="server" Height="357px" ScrollBars="Auto" Width="547px">
            </asp:Panel>
        </div>
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            Buscador:<br />
            Modelo:
            <asp:TextBox ID="tbModelo" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Combustible:
            <asp:TextBox ID="tbcombustible" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Precio:
            <asp:TextBox ID="tbPrecio" runat="server">0</asp:TextBox>
            <br />
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnMisCoches" runat="server" OnClick="Button1_Click" Text="Mis coches Alquilados" />
        &nbsp;</div>
    </form>
</body>
</html>
