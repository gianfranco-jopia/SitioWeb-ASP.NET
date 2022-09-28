<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="AjustesUsuario.aspx.cs" Inherits="Minimarket.AjustesUsuario" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 41%;
        }
        .auto-style2 {
            height: 20px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>home</title>
        <link href="css/menu.css" rel="stylesheet" />
        <link href="css/style.css" rel="stylesheet" />
        <link href="css/ajustesUsuario.css" rel="stylesheet" />
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
        function Agrego() {
            swal('Operación Exitosa', 'Usuario agregado', 'success')
        }
        function AgregoE() {
            swal('Operación Exitosa', 'Usuario eliminado', 'success')
        }
        function AgregoA() {
            swal('Operación Exitosa', 'Usuario Actualizado', 'success')
        }
        function ErrorA() {
            swal('Error', 'El usuario ingresado ya existe', 'error')
        }
        function ErrorE() {
            swal('Error', 'El usuario ingresado no se pudo eliminar', 'error')
        }
        function ErrorAc() {
            swal('Error', 'El usuario nose pudo modificar', 'error')
        }
        function ErrorL() {
            swal('Error', 'Nose Pudo listar los datos', 'error')
        }
        </script>
    </head>
    <body>
		<section id="banner">
			<div class="slider">
				<ul>					
					<li>   
					   	<center>
				         	<img src="img/carro02.png" /><br />
                       	</center>
                    </li>
					<li>   
					   	<center>
				         	<img src="img/carro01.png" /><br />	
                       	</center>                        
                    </li>
                    <li>   
					   	<center>
				         	<img src="img/carro03.png" /><br />	
                       	</center>                        
                    </li>
                    <li>   
					   	<center>
				         	<img src="img/carro04.png" /><br />	
                       	</center>                        
                    </li>
				</ul>				
			</div>			
		  	<section id="titulolbt">
				<br /><h1 class="icon-globe">MINIMARKET ONLINE DEL PUEBLO</h1><br />
				<h3>EN NUESTRO MINIMARKET, LES OFRECEMOS
				LOS MEJORES PRODUCTOS Y AL MEJOR PRECIO,<br /> TODO A SU SERVICIO, SIN NECESIDAD DE SALIR DE SU HOGAR.</h3>
                <br />			
		  	</section>
		</section>
        <main class="fondo">
        <br />
        <div class="formulario">
            <div class="contenedor">
            <table class="auto-style1">
                <tr>
                    <td colspan="2">Rut</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TxtRut" runat="server" placeholder="Ejemplo: 11.111.111-1" Width="400px" Height="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Nombre</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TxtNombre" runat="server" placeholder="Ingrese nombre" Width="400px" Height="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Apellido</td>
                </tr>
                <tr>
                    <td colspan="2">
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
                    <td colspan="2">Contraseña</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TxtContrasena" runat="server" placeholder="La contraseña puede ser numero o letras" Width="400px" Height="30px" type="password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:DropDownList ID="CbxTipoU" runat="server" Width="400px" Height="30px" DataSourceID="minimarket" DataTextField="Descripcion" DataValueField="Descripcion">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="minimarket" runat="server" ConnectionString="<%$ ConnectionStrings:ConectionBD %>" SelectCommand="SELECT [Descripcion] FROM [TipoU]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" Width="198px" Height="40px"/>
                    </td>
                    <td>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Width="198px" Height="40px"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Text="Agregar" Width="198px" Height="40px"/>
                    </td>
                    <td>
                        <asp:Button ID="BtnListar" runat="server" OnClick="BtnListar_Click" Text="Listar" Width="198px" Height="40px"/>
                    </td>
                </tr>
            </table>
            </div>
        </div>
            <br />
            <center>
            <asp:GridView ID="GvListar" runat="server" AutoGenerateColumns="False" Width="50%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="GvListar_SelectedIndexChanged" DataKeyNames="Rut">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
            <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Rut" HeaderText="Rut" ReadOnly="True" SortExpression="Rut" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                    <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
                    <asp:BoundField DataField="Contrasena" HeaderText="Contraseña" SortExpression="Contrasena" />
                    <asp:BoundField DataField="TipoUser" HeaderText="Tipo Usuario" SortExpression="TipoUser" />
                </Columns>
            </asp:GridView>
            </center>
            <br />
        </main>
    </body>
    </html>
</asp:Content>
