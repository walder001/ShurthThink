Create database Shurth
Go
use Shurth
Go

Create table Usuarios(
UsuarioId Int Primary key ,
Nombres varchar(50),
Email varchar(50),
Usuario varchar(50),
clave varchar(50),
FechaIngreso varchar(50)
); 
Go


Create Table Cargos(
IdCargo Int Primary Key,
Descripcion varchar(50)
);

Select * from Usuarios;
Select * from Cargo;