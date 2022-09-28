<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="NuestrosProveedores.aspx.cs" Inherits="Minimarket.NuestrosProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .auto-style32 {
         width: 100%;
     }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Nuestros Proveedores</title>
        <link href="css/style.css" rel="stylesheet" />
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
				LOS MEJORES PRODUCTOS Y AL MEJOR PRECIO,<br /> TODO A SU SERVICIO, SIN NECESIDAD DE SALIR DE SU HOGAR.</h3><br />			
		  	</section>
		</section>
        <main class="fondo" style="text-align:center">
        <table class="auto-style32">
            <tr>
                <td colspan="3"><h2>Nuestros principales proveedores</h2></td><br /><br />
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="250px" Width="250px" ImageUrl="~/img/provedorcarne.png" />
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="250px" Width="250px" ImageUrl="~/img/provedorharina.png" />
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton3" runat="server" Height="250px" Width="250px" ImageUrl="~/img/provedordespensa.png" />
                </td>
            </tr>
            <tr>
                <td>ProCarne</td>
                <td>Molinera San Cristobal</td>
                <td>Despesa Hualiz</td>
            </tr>
        </table>
            <br />
        </main>
    </body>
    </html>
</asp:Content>
