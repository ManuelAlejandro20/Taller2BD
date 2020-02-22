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
    
create table Vehiculo (
	Patente varchar(60) not null, 
    Modelo varchar(60) not null, 
    Marca varchar(60) not null, 
    Numero_motor int not null, 
    Color varchar(60) not null, 
    Precio_alquiler_diario int not null, 
    Litros_gasolina int not null, 
    ReservaNumero_reserva int, 
    primary key (Patente));

insert into cliente(Rut, Nombre, Direccion, Telefono_domicilio, Telefono_movil, ClienteRut)
	values
    (123456789, 'Ana Mercedes Montalban Flores','Osorno 3785', 1234,5678, 199678760),
    (199678760, 'Manuel Alejandro Trigo Montalban', 'Palestina 1315', 8888, 9999, 123456789),
    (987654321, 'Naomi Alison Andrea Chavez Osorio', 'Longitudinal 6', 6666, 7777, 199678760),
    (111123333, 'Manuel Jesus Trigo Taborga', 'Psje Davila 580',1111,2222, 987654321);

insert into vehiculo(Patente, Modelo, Marca, Numero_motor, Color, Precio_alquiler_diario, Litros_gasolina, ReservaNumero_reserva)
	values
    ("ZX6969", 'Toyota 560','Toyota', 12,"Rojo", 20000, 23, 3),
    ("WE1234", 'Mazda 1','Mazda', 1,"Verde", 30000, 23, null),
    ("DKJR11", 'Chevere 69','Chevere', 10,"Azul", 25000, 27, null),
    ("AL2019", 'El faso 420','Toyota', 121,"Morado", 40000, 28, 12),
	('XX1231', 'Honda X', 'Honda', 111, 'Azul', 30000, 10, 3),
	('KKKK99', 'GranT 99', 'GT', 3, 'Celeste', 5000, 1, null),
    ('KKKK88', 'GranK 88', 'GT', 7, 'Negro', 1000, 17, null),
    ('KT1998', 'Chevrolet 11', 'Chevrolet', 11, 'Blanco', 5000, 1, 12);

insert into reserva(ClienteRut, Precio_final, Fecha_final, Fecha_inicio)
	values
    (199678760, 62400, '2020-02-28', '2020-02-22');

alter table Cliente 
	add constraint FKCliente983742 foreign key (ClienteRut) references Cliente (Rut) on delete cascade on update cascade;

alter table Reserva 
	add constraint FKReserva495124 foreign key (ClienteRut) references Cliente (Rut) on delete cascade on update cascade;

alter table Vehiculo 
	add constraint FKVehiculo454397 foreign key (ReservaNumero_reserva) references Reserva (Numero_reserva) on delete set null;
    
update vehiculo
	set ReservaNumero_reserva = 1
	where Patente = "WE1234";
    
update vehiculo
	set ReservaNumero_reserva = 1
	where Patente = "DKJR11";
    
SELECT * 
FROM vehiculosnortegrandedb.reserva
WHERE vehiculosnortegrandedb.reserva.clienterut = 199678760;

insert into vehiculo(Patente, Modelo, Marca, Numero_motor, Color, Precio_alquiler_diario, Litros_gasolina, ReservaNumero_reserva)
	values
		('XX1231', 'Honda X', 'Honda', 111, 'Azul', 30000, 10, null),
        ('KKKK99', 'GranT 99', 'GT', 3, 'Celeste', 5000, 1, null);
        
insert into reserva(ClienteRut, Precio_final, Fecha_final, Fecha_inicio)
	values
    (199678760, 10000, '2020-03-30', '2020-04-22');
    
update vehiculo
	set ReservaNumero_reserva = 2
	where Patente = "KKKK99";
    
select *
from reserva;

select *
from cliente;

select*
from vehiculo;

select r.Numero_reserva, r.Precio_final , r.Fecha_inicio, r.Fecha_final 
from reserva r join cliente c on r.ClienteRut = c.Rut 
where c.Rut = 199678760;

select v.Patente, v.Modelo, v.Modelo, v.Color, v.Precio_alquiler_diario, v.Litros_gasolina
from vehiculo v join (select r.Numero_reserva from reserva r join cliente c on r.ClienteRut = c.Rut where c.Rut = 123456789) cr
on v.ReservaNumero_reserva = cr.Numero_reserva;

select r.ClienteRut
from vehiculo v join reserva r on v.ReservaNumero_reserva = r.Numero_reserva
where v.Patente = "ZX6969";

select c.*
from (select r.ClienteRut from vehiculo v join reserva r on v.ReservaNumero_reserva = r.Numero_reserva where v.Patente = "KKKK99") vr join cliente c
on vr.ClienteRut = c.Rut;

select c2.*
from cliente c1 join cliente c2 on c1.ClienteRut = c2.Rut
where c1.Rut = 11111111;
