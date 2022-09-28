create database minimarket;

use minimarket;
drop database minimarket;

create table TipoU(
Codigo numeric(3) constraint PkCodigoTipoU primary key(Codigo),
Descripcion varchar(40));

insert into TipoU values(1,'Seleccione tipo de Usuario:');
insert into TipoU values(2,'Administrador');
insert into TipoU values(3,'Usuario');

create table TipoP(
Codigo numeric(3) constraint PkCodigoTipoP primary key(Codigo),
Descripcion varchar(40));

insert into TipoP values(1,'Seleccione tipo de producto:');
insert into TipoP values(2,'Carniceria');
insert into TipoP values(3,'Despensa');
insert into TipoP values(4,'Panaderia');
insert into TipoP values(5,'Botilleria');

create table Registrar(
Rut char(12) constraint PkRutRegistrar primary key(Rut),
Nombre varchar(25),
Apellido varchar(25),
Genero varchar(10),
Contrasena varchar(20),
TipoUser numeric(3) constraint FkTipoUserRegistrar foreign key(TipoUser) references TipoU(Codigo));

create table Producto(
Codigo char(6) constraint PkCodigoProducto primary key(Codigo),
Descripcion varchar(25),
Precio numeric(6),
Cantidad numeric(3),
TipoProducto numeric(3) constraint FkTipoProductoProducto foreign key(TipoProducto) references TipoP(Codigo));

create table Carrito(
Codigo INT IDENTITY(1,1)constraint PkCodigoCarrito primary key(Codigo),
Descripcion varchar(25),
Precio numeric(6),
Cantidad numeric(3),
PrecioTotal numeric(6),
TipoProducto numeric(3) constraint FkTipoProductoCarrito foreign key(TipoProducto) references TipoP(Codigo));

create table Historial(
Codigo numeric(2) constraint PkCodigoHistorial primary key(Codigo),
Descripcion varchar(25),
Precio numeric(6),
Cantidad numeric(3),
TipoProducto numeric(3) constraint FkTipoProductoHistorial foreign key(TipoProducto) references TipoP(Codigo),
Rut char(12) constraint FkRutHistorial foreign key(Rut) references Registrar(Rut));

insert into Registrar values('11.111.111-1','Alejandro','Neira','Masculino','12345678',2);
insert into Registrar values('11.111.111-2','Gianfranco','Jopia','Masculino','87654321',3);

insert into Producto values('cod000','baguette',1000,40,4);
insert into Producto values('cod001','fideos',1700,18,3);
insert into Producto values('cod002','fanta',2300,15,5);
insert into Producto values('cod003','costillar',1800,20,2);

/*-------------------------------Consultas-------------------------------*/
select * from Producto;
select * from Registrar;
select * from TipoU;
select * from TipoP;
select * from carrito;
select * from Historial;

drop table TipoU;
drop table TipoP;
drop table Registrar;
drop table Producto;
drop table carrito;
drop table Historial;

insert into Historial(Codigo,Descripcion,Precio,Cantidad,TipoProducto) select Codigo,Descripcion,Precio,Cantidad,TipoProducto from Carrito;
Update Historial set Rut='11.111.111-1' where Cantidad>=0;

select Producto.Descripcion, Carrito.Descripcion from Producto,Carrito where Producto.Descripcion=Carrito.Descripcion;

Update Producto set Producto.Cantidad=(Producto.Cantidad - Carrito.Cantidad) from Producto,Carrito where Producto.Descripcion=Carrito.Descripcion;


Select Producto.Codigo,Producto.Descripcion,Producto.Precio,Producto.Cantidad,TipoP.Descripcion from Producto,TipoP where Producto.TipoProducto = TipoP.Codigo;
Select Carrito.Codigo,Carrito.Descripcion,Carrito.Precio,Carrito.Cantidad,TipoP.Descripcion from Carrito,TipoP where Carrito.TipoProducto = TipoP.Codigo;

Select SUM(PrecioTotal) as TotalP from Carrito;
select * from Carrito;
Select Producto.Cantidad from Producto,Carrito where Carrito.Descripcion='baguette' and Producto.Descripcion='baguette' and Producto.Cantidad >= 37;
Update Producto set Cantidad=(Cantidad-3) where Descripcion='baguette';


