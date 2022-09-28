<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="GestionarP.aspx.cs" Inherits="Minimarket.GestionarP" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>home</title>
        <link href="css/style.css" rel="stylesheet" />
        <link href="css/gestionarP.css" rel="stylesheet" />
        <script>
        function campos() {
            swal('Advertencia', 'Debe Completar los campos', 'warning')
        }
        function camposC() {
            swal('Advertencia', 'Siga el ejemplo:cod000', 'warning')
        }
        function camposD() {
            swal('Advertencia', 'Descripcion muy corta', 'warning')
        }
        function camposP() {
            swal('Advertencia', 'Debe ingresar un precio mayor a 100 pesos', 'warning')
        }
        function Agrego() {
            swal('Operación Exitosa', 'Producto agregado', 'success')
        }
        function ErrorA() {
            swal('Error', 'El producto ingresado ya existe', 'Error')
        }
        function AgregoE() {
            swal('Operación Exitosa', 'Producto eliminado', 'success')
        }
        function ErrorE() {
            swal('Error', 'El producto ingresado no se pudo elimianr', 'Error')
        }
        function AgregoAc() {
            swal('Operación Exitosa', 'Producto actualizado', 'success')
        }
        function ErrorAc() {
            swal('Error', 'El producto no se pudo actualizar', 'Error')
        }
        function ErrorL() {
            swal('Error', 'No se pudo listar los productos', 'Error')
        }
        function Conectar(){
            swal('Operación Exitosa', 'Conectado a la BD', 'success');
        }
        function Desconectar() {
            swal('Operación Exitosa', 'Desconectado BD', 'success')
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
            <br /><br />
            <div class="formulario">
                <div class="contenedor">
            <table>
                <tr>
                    <td colspan="4">Codigo</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="TxtCodigo" runat="server" placeholder="Pueden ser letras y numeros cod000" Width="400px" Height="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">Descripcion</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="TxtDescripcion" runat="server" placeholder="Nombre del producto" Width="400px" Height="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">Precio</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="TxtPrecio" runat="server" placeholder="Precio del producto" Width="400px" Height="30px" TextMode="Number" min="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">Cantidad</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="TxtCantidad" runat="server" placeholder="Cantidad de producto" Width="400px" Height="30px" TextMode="Number" min="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">Tipo Producto</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:DropDownList ID="CbxTipoP" runat="server" Width="400px" Height="30px" DataSourceID="minimarket" DataTextField="Descripcion" DataValueField="Descripcion">
                        </asp:DropDownList>           
                        <asp:SqlDataSource ID="minimarket" runat="server" ConnectionString="<%$ ConnectionStrings:ConectionBD %>" SelectCommand="SELECT [Descripcion] FROM [TipoP]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Button ID="BtnGrabar" runat="server" Text="Grabar" OnClick="BtnGrabar_Click" Height="40px" Width="80px"/>
                    </td>
                    <td>
                        <br />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" Height="40px" Width="80px"/>
                    </td>
                    <td>
                        <br />
                        <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" Height="40px" Width="80px"/>
                    </td>
                    <td>
                        <br />
                        <asp:Button ID="BtnListar" runat="server" Text="Listar" OnClick="BtnListar_Click" Height="40px" Width="70px"/>
                    </td>
                </tr>
                </table>    
                </div>
            </div>
            <br />
            <center>
            <asp:GridView ID="GvListar" runat="server" AutoGenerateColumns="False" Width="40%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="GvListar_SelectedIndexChanged" DataKeyNames="Codigo">
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
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                    <asp:BoundField DataField="TipoProducto" HeaderText="Tipo de Producto" SortExpression="TipoProducto" />
             </Columns>
            </asp:GridView>
            </center>
            <br /><br />
        </main>
    </body>
    </html>
</asp:Content>
