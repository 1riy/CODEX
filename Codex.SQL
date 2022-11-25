use master
go

if(exists(select * from sys.databases where name =  'BDCCODEX'))
	drop database BDCCODEX
go

create database BDCCODEX
go

use BDCCODEX
go

create table Usuario(
	ID int identity primary key,
	Email varchar (200) not null,
	Nome varchar(200) not null,
	Senha varchar(1000) not null,
);
go

create table Post(
	ID int identity primary key,
	Publicante varchar(200) not null,
	Conteudo 
	varchar (MAX) not null,
);
go
/*Set-Executionpolicy -Scope CurrentUser -ExecutionPolicy  Bypass */


