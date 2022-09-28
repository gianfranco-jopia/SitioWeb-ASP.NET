<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Minimarket.Registrar" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/registrar.css" rel="stylesheet" />
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/Alert_Swal/sweetalert.min.js"></script>
    <script>
        function rut() {
            swal('Advertencia', 'Rut mal ingresado', 'warning')
        } 
        function campos() {
           swal('Advertencia', 'Debe Completar los campos', 'warning')
        } 
        function camposR() {
            swal('Informacion', 'rut debe ser ingresado de esta manera ej:11.111.111-1', 'info')
        } 
        function camposN() {
            swal('Informacion', 'Nombre muy corto', 'info')
        } 
        function camposA() {
            swal('Informacion', 'Apellido muy corto', 'info')
        } 
        function camposC() {
            swal('Informacion', 'Contraseña muy corta minimo 8 caracteres', 'info')
        } 
        function camposG() {
            swal('Informacion', 'Debe seleccionar el tipo de genero', 'info')
        } 
        function camposConfirmar() {
            swal('Informacion', 'Debe confirmar los terminos', 'info')
        }
        function Agrego() {
            swal('Operación Exitosa', 'Usuario agregado', 'success')
        }
        function Error() {
            swal('Error', 'El usuario ingresado ya existe', 'error')
        }
    </script>
</head>
<body>
    <form class="formulario" runat="server">
        <div class="contenedor">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Registrar"></asp:Label>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2">Rut</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:TextBox ID="TxtRut" runat="server" placeholder="Ejemplo: 11.111.111-1" Width="400px" Height="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">Nombre</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:TextBox ID="TxtNombre" runat="server" placeholder="Ingrese nombre" Width="400px" Height="30px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">Apellido&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:TextBox ID="TxtApellido" runat="server" placeholder="Ingrese apellido" Width="400px" Height="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">Genero</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:RadioButton ID="RbtMasculino" runat="server" GroupName="Genero" Text="Masculino" width="180px"/>
                        <asp:RadioButton ID="RbtFemenino" runat="server" GroupName="Genero" Text="Femenino" width="180px"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">Contraseña</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:TextBox ID="TxtContrasena" runat="server" placeholder="La contraseña puede ser numero o letras" Width="400px" Height="30px" type="password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:CheckBox ID="CheckBoxConfirma" runat="server" Text="Acepta todos los terminos" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <br />
                        <asp:Button ID="btnConectar" runat="server" Text="Conectar" OnClick="btnConectar_Click" Width="198px" Height="40px"/>
                    </td>
                    <td class="auto-style2">
                        <br />
                        <asp:Button ID="btnDesconectar" runat="server" Text="Desconectar" OnClick="btnDesconectar_Click" Width="198px" Height="40px"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" Width="400px" Height="40px"/>
                    </td>
                </tr>
            </table>
        </div>
        </form>
</body>
</html>
