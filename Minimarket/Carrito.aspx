<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Minimarket.Carrito" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Carrito</title>
        <link href="css/style.css" rel="stylesheet" />
        <script>
            function campos() {
                swal('Advertencia', 'Cantidad ingresada supera el stock', 'warning')
            }
            function carro() {
                swal('Advertencia', 'Debe tener productos agregados para realizar una compra', 'warning')
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
				LOS MEJORES PRODUCTOS Y AL MEJOR PRECIO,<br /> TODO A SU SERVICIO, SIN NECESIDAD DE SALIR DE SU HOGAR.</h3><br />			
		  	</section>
		</section>
        <main class="fondo" >
        <asp:TextBox ID="TxtFecha" runat="server" TextMode="DateTime"></asp:TextBox>
        <br /><br />
        <center>      
             <asp:GridView ID="GvListar" runat="server" AutoGenerateColumns="False" Width="46%" DataKeyNames="Codigo"
                 OnRowCancelingEdit="GvListar_RowCancelingEdit" OnRowDeleting="GvListar_RowDeleting" OnRowEditing="GvListar_RowEditing" OnRowUpdating="GvListar_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="Codigo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Codigo") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtCodigo" Text='<%# Eval("Codigo") %>' runat="server" Enabled="false" Width="100%"/>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Descripcion") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtDescripcion" Text='<%# Eval("Descripcion") %>' runat="server" Enabled="false" Width="100%"/>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="TipoProducto">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("TipoProducto") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtTipoProducto" Text='<%# Eval("TipoProducto") %>' runat="server" Enabled="false" Width="100%"/>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Precio") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtPrecio" Text='<%# Eval("Precio") %>' runat="server" Enabled="false" Width="100%"/>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Cantidad") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtCantidad" Text='<%# Eval("Cantidad") %>' runat="server" Width="100%" TextMode="Number" min="1"/>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Subtotal">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PrecioTotal") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtPrecioTotal" Text='<%# Eval("PrecioTotal")%>' runat="server" Enabled="false" Width="100%"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ControlStyle-ForeColor="Black"/>
                </Columns>
            </asp:GridView>
            <table style="width: 624px;" border="1">
                <tr>
                    <td style="width: 700px;">Total a pagar</td>
                    <td style="width: 340px;">$<asp:Label ID="TotalP" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="BtnComprar" runat="server" Text="Comprar" OnClick="BtnComprar_Click" />
            </center>
            <br />
        </main>
    </body>
    </html>
</asp:Content>
                