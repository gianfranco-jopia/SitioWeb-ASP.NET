<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Autores.aspx.cs" Inherits="Minimarket.Autores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--  --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>home</title>
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
				LOS MEJORES PRODUCTOS Y AL MEJOR PRECIO,<br /> TODO A SU SERVICIO, SIN NECESIDAD DE SALIR DE SU HOGAR.</h3>
                <br />			
		  	</section>
		</section>
        <main class="fondo">
        <br />
        <center>
        <table style="width:80%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Image ID="Image3" runat="server" Height="583px" ImageUrl="~/img/gianfranco.png" Width="260px"/></td>
                <td>
                    <center>
                    <b>Alejandro Patricio Neira Morales ~ Gianfranco Jopia Lucero</b><br />
                    <b>Alumnos cursando la carrera Analista y Programador, 5to semestre, Inacap.</b><br /><br />
                    <b>Profesor a cargo: Cesar Arce Jara.</b><br /><br />
                    <b>Fecha:04/07/2020.</b><br /><br />
                    <b><u>Contacto programadores: </u></b><br />
                    <b>alejandro.neira.morales@gmail.com <br />gianfranco.jopia@gmail.com</b>
                    </center>
                </td>
                <td><asp:Image ID="Image1" runat="server" Height="583px" ImageUrl="~/img/neira.png" Width="260px" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
         </table>
         </center>
         <br />
        </main>
    </body>
    </html>
</asp:Content>
                    
