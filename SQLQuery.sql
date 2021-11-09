create database veterinaria;
use veterinaria;

create table personal(
	idPersonal int identity(1,1) not null primary key,
	nombre varchar(max) not null,
	identificacion varchar(max) not null,
	fechaIngreso varchar(max) not null,
	fechaNacimiento varchar(max) not null,
	especializacion varchar(max) not null,
	salario float not null,
	telefono varchar(max) not null,
	direccion varchar(max) not null
);

create table mascota(
	idMascota int identity(1,1) not null primary key,
	nombreMascota varchar(max) not null,
	sexo varchar(max) not null,
	raza varchar(max) not null,
	tipoAnimal varchar(max) not null,
	fechaIngreso varchar(max) not null,
	fechaNacimiento varchar(max) not null,
	nombreDueno varchar(max) not null,
	telefonoDueno varchar(max) not null
);

create table consultaMedica(
	idCita int identity(1,1) not null primary key,
	idMascota int foreign key references mascota(idMascota),
	idPersonal int foreign key references personal(idPersonal),
	descripcionConsulta varchar(max) not null,
	fechaConsulta varchar(max) not null,
	costoConsulta float not null
);