create database vehiculosnortegrandedb;

create table Cliente (
	Rut varchar(60) not null, 
    Nombre varchar(60) not null, 
    Direccion varchar(60) not null, 
    Telefono_domicilio int not null, 
    Telefono_movil int not null, 
    ClienteRut varchar(60) not null, 
    primary key (Rut));
    
create table Reserva (
	Numero_reserva int not null auto_increment, 
    Fecha_inicio date not null, 
    Fecha_final date not null, 
    Precio_final int not null, 
    ClienteRut varchar(60) not null, 
    primary key (Numero_reserva));
    
create table Reserva_vehiculo(
	Numero_reserva int not null,
    Patente varchar(60) not null,
	Litros_gasolina int not null, 
	primary key(Numero_reserva, Patente));
 
create table Vehiculo (
	Patente varchar(60) not null, 
    Modelo varchar(60) not null, 
    Marca varchar(60) not null, 
    Numero_motor int not null, 
    Color varchar(60) not null, 
    Precio_alquiler_diario int not null,
    primary key (Patente));

insert into cliente(Rut, Nombre, Direccion, Telefono_domicilio, Telefono_movil, ClienteRut)
	values
    (123456789, 'Ana Mercedes Montalban Flores','Osorno 3785', 1234,5678, 199678760),
    (199678760, 'Manuel Alejandro Trigo Montalban', 'Palestina 1315', 8888, 9999, 123456789),
    (987654321, 'Naomi Alison Andrea Chavez Osorio', 'Longitudinal 6', 6666, 7777, 199678760),
    (111123333, 'Manuel Jesus Trigo Taborga', 'Psje Davila 580',1111,2222, 987654321),
    (147258369, "Celeste Rojelia Blanco Negrete", "Los Colores 1234", 123456, 976002971, 987654321),
    (111111111, 'Marisol Carolina Torres Arriagada','Ese 11',234561222,123456789,199678760),
	(369258147, 'Karla Pamela Salgado Montalvan', 'Delicias 1', 11223344, 976002971, 199678760),
    (789456123, 'Maria Teresa Salgado Montalvan', 'Osorno 3785', 1234556, 976002971, 369258147);
        
insert into vehiculo(Patente, Modelo, Marca, Numero_motor, Color, Precio_alquiler_diario)
	values
    ("ZX6969", 'Toyota 560','Toyota', 12,"Rojo", 20000),
    ("WE1234", 'Mazda 1','Mazda', 1,"Verde", 30000),
    ("DKJR11", 'Chevere 69','Chevere', 10,"Azul", 25000),
    ("AL2019", 'El faso 420','Toyota', 121,"Morado", 40000),
	('XX1231', 'Honda X', 'Honda', 111, 'Azul', 30000),
	('KKKK99', 'GranT 99', 'GT', 3, 'Celeste', 5000),
    ('KKKK88', 'GranK 88', 'GT', 7, 'Negro', 1000),
    ('KT1998', 'Chevrolet 11', 'Chevrolet', 11, 'Blanco', 5000);

alter table Cliente 
	add foreign key (ClienteRut) references Cliente (Rut) on delete cascade on update cascade;

alter table Reserva 
	add foreign key (ClienteRut) references Cliente (Rut) on delete cascade on update cascade;

alter table Reserva_vehiculo
	add foreign key (Numero_reserva) references Reserva (Numero_reserva) on delete cascade on update cascade;
    
alter table Reserva_vehiculo
	add foreign key (Patente) references Vehiculo (Patente) on delete cascade on update cascade;

select*
from cliente;

select*
from reserva;

select*
from reserva_vehiculo;

select*
from vehiculo;

select * 
from vehiculosnortegrandedb.reserva_vehiculo rv right join vehiculosnortegrandedb.vehiculo v on rv.patente = v.patente 
where rv.numero_reserva= 7;



delete from reserva
