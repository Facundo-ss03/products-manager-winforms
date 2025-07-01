
-- crea la base de datos --

if DB_ID('CATALOGO_DB') is null
begin
	create database CATALOGO_DB
	ON
	primary
		(name = catalogoPrimary,
		filename = 'C:\Users\Public\Downloads\catalogoPrimary.mdf',		-- se puede cambiar por una carpeta a elección
		size = 50MB,
		maxsize = 200MB,
		filegrowth = 20),
	filegroup catalogoIFG
		(name = catalogoData,
		filename = 'C:\Users\Public\Downloads\catalogoData.ndf',
		size = 200MB,
		maxsize = 800,
		filegrowth = 100)
	log on
		(name = catalogoLog,
		filename = 'C:\Users\Public\Downloads\catalogoLog.ldf',
		size = 300MB,
		maxsize = 800,
		filegrowth = 100);
end
go

-- genera las tablas necesarias --

use CATALOGO_DB
go

if OBJECT_ID('ARTICULOS', 'U') is not null drop table ARTICULOS;
if OBJECT_ID('MARCAS', 'U') is not null drop table MARCAS;
if OBJECT_ID('CATEGORIAS', 'U') is not null drop table CATEGORIAS;


create table ARTICULOS
(
Id int identity(1,1),
Codigo varchar(30) not null,
Nombre varchar(30) not null,
Descripcion varchar(30) not null,
IdMarca int not null,
IdCategoria int not null,
ImagenUrl varchar(100) not null,
Precio money not null
)

create table MARCAS
(
Id int identity(1,1),
Descripcion varchar(30) not null,
)

create table CATEGORIAS
(
Id int identity(1,1),
Descripcion varchar(30) not null,
);
go

-- genera un articulo para probar la app --

INSERT INTO CATEGORIAS(Descripcion)
VALUES('Carnes congeladas')

INSERT INTO MARCAS(Descripcion)
VALUES('Granja Del Sol')

INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)
VALUES('1234', 'Pollo', 'Pollo congelado', 1, 1, '@ImagenUrl', 1.000)
go