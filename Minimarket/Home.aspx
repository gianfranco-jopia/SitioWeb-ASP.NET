<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Minimarket.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 69%;
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
        <link href="css/style.css" rel="stylesheet" />
        <link href="css/otroMenu.css" rel="stylesheet" />
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
            <div class="text">
				<h2>
				   <p>OFRECEMOS LO MEJOR EN:</p>
                   <p>
                   <span class="word wisteria">PAN.</span>
                   <span class="word belize">ABARROTES.</span>
                   <span class="word pomegranate">CARNES.</span>
                   <span class="word green">DESPENSA.</span>
                   <span class="word midnight">BEBESTIBLES.</span>
                   </p>					
				</h2>              
           	</div>
        <br /><br /><br />
        <center>
        <table class="auto-style1" style="text-align:center;">
            <tr>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="210px" Width="210px" OnClick="ImageButton1_Click" ImageUrl="~/img/pan.jpg" />
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="210px" Width="210px" OnClick="ImageButton2_Click" ImageUrl="~/img/carnes.jpg" />
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton3" runat="server" Height="210px" Width="210px" OnClick="ImageButton3_Click" ImageUrl="~/img/despensa.png" />
                </td>
            </tr>
            <tr>
                <td>Panaderia</td>
                <td>Carniceria</td>
                <td>Productos de despensa</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:ImageButton ID="ImageButton4" runat="server" Height="210px" Width="210px" OnClick="ImageButton4_Click" ImageUrl="~/img/botilleria.png" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">Botilleria</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
        </center>
            <br />
        </main>
    </body>
    </html>
</asp:Content>
