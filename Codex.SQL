use master
go

if(exists(select * from sys.databases where name =  'TCC_CODEX'))
	drop database TCC_CODEX
go

create database TCC_CODEX
go

use TCC_CODEX
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
	Conteudo varchar (MAX) not null,clear
);
go
/*Set-Executionpolicy -Scope CurrentUser -ExecutionPolicy  Bypass */


