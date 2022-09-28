<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="Minimarket.Contactanos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Contactenos</title>
        <link href="css/style.css" rel="stylesheet" />
        <link href="css/contactenos.css" rel="stylesheet" />
    </head>
    <body>
		<section id="banner">
			<div class="slider">
				<ul>					
					<li>   
					   	<center>
				         	<img src="img/carro02.png"/><br />	
                       	</center>
                    </li>
                    <li>   
					   	<center>
				         	<img src="img/carro01.png"/><br />	
                       	</center>                        
                    </li>
                    <li>   
					   	<center>
				         	<img src="img/carro03.png"/><br />	
                       	</center>                        
                    </li>
                    <li>   
					   	<center>
				         	<img src="img/carro04.png"/><br />	
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
		<section id="ofrecemos">
	        <div class="contenedor">
	        	<article>
					<center>
						<h2>  Ayudanos a crecer.... </h2><br />
						<h3 class="h3">Contactanos en caso de reclamos, felicitaciones o consultas.</h3>
					</center>
	        	</article>	
	        </div>
			<div class="contenedor">
				<article>				  
					<div class="form">	
                    <h2>CONTACTO</h2>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label1" runat="server" Text="De:"></asp:Label>
                            <asp:TextBox ID="TextFrom" type="email" placeholder="Ingresa tu email" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                            <asp:TextBox ID="TextPass" type="password" placeholder="Ingrese su contraseña" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label3" runat="server" Text="CC:"></asp:Label>
                            <asp:TextBox ID="TexCopy" type="email" placeholder="Ingrese un correo de copia" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label4" runat="server" Text="Para:"></asp:Label>
                            <asp:TextBox ID="TextTo" type="email" placeholder="Ingrese Correo de destino" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label5" runat="server" Text="Motivo:"></asp:Label>
                            <asp:TextBox ID="TextSubjet"  placeholder="Ingrese el motivo" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label6" runat="server" Text="Mensaje:"></asp:Label>
                            <asp:TextBox ID="TextMessage"  placeholder="Ingrese el mensaje" class="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">                    
                            <asp:Button ID="BtnEnviar" class="btn-secondary" runat="server" Text="Enviar" OnClick="BtnEnviar_Click" />
                        </div>
                    </div>
			        </div>	
				</article>
			</div>
		</section>
	    <br /><br />
	</main>
    </body>
    </html>
</asp:Content>
