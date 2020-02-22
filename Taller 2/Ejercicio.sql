use dbexample;
create table empleado(
	nombre_principal tinytext not null,
    inicial char(1) not null,
    apellido tinytext not null,
	nss varchar(9) not null,
    fecha_ncto date not null,
    direccion varchar(60) not null,
    sexo char(1) not null,
    salario int not null,
	nss_superv varchar(9),
    nd int not null,
    PRIMARY KEY (nss),
    foreign key(nss_superv) references empleado(nss) on delete cascade on update cascade
);
    
create table departamento(
	num_departamento int not null,
	nombre_departamento varchar(60) not null,
    fecha_inicio date not null,
    nss_jefe varchar(9) not null,
    PRIMARY KEY (num_departamento, nombre_departamento),
    foreign key(nss_jefe) references empleado(nss) on delete cascade on update cascade
);

alter table empleado
	add foreign key(nd) references departamento(num_departamento) on delete cascade on update cascade;

create table localizacion_departamento(
	num_dep int not null,
    direccion varchar(60) not null,
    primary key(num_dep, direccion),
	foreign key(num_dep) references departamento(num_departamento) on delete cascade on update cascade
);

create table proyecto(
	nombre_proyecto varchar(60) not null,
	numero_proyecto int not null,
    num_dep int not null,
    localizacion varchar(60) not null,
    PRIMARY KEY (numero_proyecto),
    foreign key(num_dep) references departamento(num_departamento) on delete cascade on update cascade
);

create table trabaja_en(
	nss_trabajador varchar(9) not null,
	num_proyecto int not null,
    horas int not null,
    PRIMARY KEY (nss_trabajador, num_proyecto),
	foreign key(nss_trabajador) references empleado(nss) on delete cascade on update cascade,
    foreign key(num_proyecto) references proyecto(numero_proyecto) on delete cascade on update cascade
);

create table familiar(
	nsse varchar(9) not null,
	nombre_familiar varchar(60) not null,
	sexo_familiar char(1) not null,
    fecha_nac date not null,
    parentesco tinytext not null,
    PRIMARY KEY (nsse, nombre_familiar),
	foreign key(nsse) references empleado(nss) on delete cascade on update cascade
);

insert into departamento(num_departamento, nombre_departamento, fecha_inicio, nss_jefe)
	values 
    (5, 'Investigacion', '1965-05-22' , 333445555),
    (4, 'Administracion', '1995-01-01' , 987654321),
    (1, 'Direccion', '1981-06-19' , 888665555);

insert into empleado(nombre_principal, inicial, apellido, nss, fecha_ncto, direccion, sexo, salario, nss_superv, nd)
	values
    ('John', 'B', 'Smith', 123456789, '1965-01-09', '731 Fondren, Houston, TX', 'H', 30000, 333445555, 5),
    ('Franklin', 'T', 'Wong', 333445555, '1955-12-08', '633 Voss, Houston, TX', 'H', 40000, 888665555, 5),
    ('Alicia', 'J', 'Zelaya', 999887777, '1968-07-19', '3321 Castle, Spring, TX', 'M', 25000, 987654321, 4),
    ('Jeniffer', 'S', 'Wallace', 987654321, '1941-06-20', '291 Berry, Bellaire, TX', 'M', 43000, 888665555, 4),
    ('Rarnesh', 'K', 'Narayan', 666884444, '1962-09-15', '975 Fire Oak, Humble, TX', 'H', 38000, 333445555, 5),
    ('Joyce', 'A', 'English', 453453453, '1972-07-31', '5631 Rice, Houston, TX', 'M', 25000, 333445555, 5),
    ('Ahmad', 'V', 'Jabbar', 987987987, '1969-03-29', '980 Dallas, Houston, TX', 'H', 25000, 987654321, 4),
    ('James', 'E', 'Borg', 888665555, '1937-11-10', '450 Stones, Houston, TX', 'H', 55000, null , 1);