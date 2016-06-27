<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearCuenta.aspx.cs" Inherits="ClienteEntidadBanco.CrearCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Crear Cuenta<br />
        <br />
        Primer Nombre:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrimerNombre" runat="server" Width="252px"></asp:TextBox>
        <br />
        Segundo Nombre:
        <asp:TextBox ID="txtSegundoNombre" runat="server" Height="20px" Width="252px"></asp:TextBox>
        <br />
        Primer Apellido:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrimerApellido" runat="server" Width="251px"></asp:TextBox>
        <br />
        Segundo Apellido:
        <asp:TextBox ID="txtSegundoApellido" runat="server" Width="257px"></asp:TextBox>
        <br />
        Fecha de Nacimiento:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFechaNac" runat="server" Width="213px"></asp:TextBox>
        <br />
        Telefono:&nbsp;
        <asp:TextBox ID="txtTelefono" runat="server" Width="220px"></asp:TextBox>
        <br />
        Direccion:
        <asp:TextBox ID="txtDireccion" runat="server" Width="216px"></asp:TextBox>
        <br />
        Saldo:&nbsp;
        <asp:TextBox ID="txtSaldo" runat="server" Width="314px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btnCuenta" runat="server" OnClick="btnCuenta_Click" Text="Crear Cuenta" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRespuesta" runat="server" BackColor="White" Font-Overline="False" Font-Size="Medium" ForeColor="Red" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
