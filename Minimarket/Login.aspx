<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Minimarket.Login" %>

<!DOCTYPE html>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/login.css" rel="stylesheet" />
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/Alert_Swal/sweetalert.min.js"></script>
    <script>
        function error() {
           swal('Error', 'Usuario o contraseña incorrectos', 'error')
        } 
        function campos() {
            swal('Informacion', 'Debe completar todos los campos', 'info')
        }
    </script>
</head>
<body>
    <form class="formulario" runat="server" method="post">
        <div class="contenedor">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label> 
            <br />
            <table class="auto-style3">
                <tr class="input-contenedor">
                    <td>Usuario</td>
                </tr>
                <tr class="input-contenedor">
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server" Width="400px" Height="30px" placeholder="Ejemplo: 11.111.111-1"></asp:TextBox>
                    </td>
                </tr>
                <tr  class="input-contenedor">
                    <td>Contraseña</td>
                </tr>
                <tr  class="input-contenedor">
                    <td>
                        <asp:TextBox ID="txtContrasena" runat="server" Width="400px" Height="30px" TextMode="Password" placeholder="Ingrese contraseña"></asp:TextBox>
                    </td>
                </tr>
                <tr  class="input-contenedor">
                    <td>
                        Tipo de usuario</td>
                </tr>
                <tr  class="input-contenedor">
                    <td>
                        <asp:DropDownList ID="CbxTipoU" runat="server" Width="400px" Height="30px" DataSourceID="minimarket" DataTextField="Descripcion" DataValueField="Descripcion">
                        </asp:DropDownList >               
                        <asp:SqlDataSource ID="minimarket" runat="server" ConnectionString="<%$ ConnectionStrings:ConectionBD %>" SelectCommand="SELECT [Descripcion] FROM [TipoU]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <br />
                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="400px" Height="40px" />
                    </td>
                </tr>
                <tr>
                    <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="Registrar.aspx">Registrarse</a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
