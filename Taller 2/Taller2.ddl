create table Cliente (Rut varchar(60) not null, Nombre varchar(20) not null, Direccion varchar(60) not null, Telefono_domicilio int(20) not null, Telefono_movil int(20) not null, ClienteRut varchar(60) not null, primary key (Rut));
create table Reserva (Numero_reserva int(20) not null auto_increment, Fecha_inicio date not null, Fecha_final date not null, Precio_final int(20) not null, ClienteRut varchar(60) not null, primary key (Numero_reserva));
create table Vehiculo (Patente varchar(60) not null, Modelo varchar(60) not null, Marca varchar(60) not null, Numero_motor int(20) not null, Color varchar(60) not null, `Precio alquiler diario` int(20) not null, Litros_gasolina int(20) not null, ReservaNumero_reserva int(20) not null, primary key (Patente));
alter table Cliente add constraint FKCliente983742 foreign key (ClienteRut) references Cliente (Rut);
alter table Reserva add constraint FKReserva495124 foreign key (ClienteRut) references Cliente (Rut);
alter table Vehiculo add constraint FKVehiculo454397 foreign key (ReservaNumero_reserva) references Reserva (Numero_reserva);
