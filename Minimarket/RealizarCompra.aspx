<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="RealizarCompra.aspx.cs" Inherits="Minimarket.RealizarCompra" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form {
            width: 443px;
            margin: auto;
            background: rgba(0,0,0,0.3);
            padding: 10px 20px;
            box-sizing: border-box;
            margin-top: 20px;
            border-radius: 10px;
        }
        .ImgMetodoP{
            position: absolute;
            width: 30%;
            padding:30px;
            margin-top:-15px;
        }
        .ImgMetodoC{
            position: absolute;
            width: 30%;
            padding:30px;
            margin-top:60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>home</title>
        <link href="css/style.css" rel="stylesheet" />
        <script>
            function campos() {
                swal('Advertencia', 'Debe Seleccionar forma de pago', 'warning')
            }
            function camposS() {
                swal('Advertencia', 'Debe Completar todos los campos', 'warning')
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
        <asp:TextBox ID="TxtFecha" runat="server" TextMode="DateTime"></asp:TextBox>
        <main class="fondo">
        <br />
        <asp:ImageButton ID="ImageButton1" class="ImgMetodoP" runat="server" ImageUrl="~/img/MetodoP.png" OnClick="ImageButton1_Click"/>
        <asp:ImageButton ID="ImageButton2" class="ImgMetodoC" runat="server" ImageUrl="~/img/MetodoC.png" OnClick="ImageButton2_Click"/>
        <div class="form">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <table class="auto-style3">
                <tr class="input-contenedor">
                    <td>Forma de Pago</td>
                </tr>
                <tr class="input-contenedor">
                    <td>
                        <asp:DropDownList ID="CbxTipoP" runat="server"  Width="400px" Height="30px" AutoPostBack="True">
                            <asp:ListItem>Seleccione Metodo de Pago</asp:ListItem>
                            <asp:ListItem>Debito</asp:ListItem>
                            <asp:ListItem>Credito</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <%
                    if (CbxTipoP.SelectedIndex==1)
                    {
                    %>
                    <tr  class="input-contenedor">
                        <td>Seleccione Banco</td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>
                            <asp:DropDownList ID="CbxTipoB" runat="server" Width="400px" Height="30px">
                                <asp:ListItem>Seleccione tipo de Banco</asp:ListItem>
                                <asp:ListItem>Banco de Chile</asp:ListItem>
                                <asp:ListItem>Banco Estado</asp:ListItem>
                                <asp:ListItem>Banco Bice</asp:ListItem>
                                <asp:ListItem>Banco BCI</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>Rut</td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>
                            <asp:TextBox ID="TxtRut" runat="server" Width="400px" Height="30px" placeholder="11.111.111-1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>Contraseña</td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" type="password" Width="400px" Height="30px"></asp:TextBox>
                        </td>
                    </tr>
                    <%
                    }else if (CbxTipoP.SelectedIndex==2)
                    {
                    %>
                    <tr  class="input-contenedor">
                        <td>Rut</td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>
                            <asp:TextBox ID="TxtRut1" runat="server" Width="400px" Height="30px" placeholder="11.111.111-1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>Numero de Tarjeta</td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>
                            <asp:TextBox ID="TxtNumT" runat="server" Width="400px" Height="30px" placeholder="1111 2222 3333 4444"></asp:TextBox>
                        </td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>Fecha de Vencimiento</td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>
                            <asp:TextBox ID="TxtFechaV" runat="server" Width="400px" Height="30px" placeholder="MM/AA"></asp:TextBox>
                        </td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>Codigo de Seguridad</td>
                    </tr>
                    <tr  class="input-contenedor">
                        <td>
                            <asp:TextBox ID="TxtCodigoS" runat="server" Width="400px" Height="30px" type="password" placeholder="****"></asp:TextBox>
                        </td>
                    </tr>
                    <%
                    }
                %>
                <tr>
                    <td class="auto-style2">
                        <br />
                        <asp:Button ID="btnComprar" runat="server" Text="Realizar Compra" Width="400px" Height="40px" OnClick="btnComprar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br /><br />
        </main>
    </body>
    </html>
</asp:Content>
