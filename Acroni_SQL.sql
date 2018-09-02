use master
go

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'ACRONI_SQL')
	DROP DATABASE ACRONI_SQL

CREATE DATABASE ACRONI_SQL
GO
USE ACRONI_SQL
GO
CREATE TABLE tblCliente (
	usuario VARCHAR(30),
	senha VARCHAR(30),
	email VARCHAR(50) PRIMARY KEY,
	cpf VARCHAR(15),
	cep VARCHAR(15),

)
GO

INSERT INTO tblCliente VALUES ('pezinho', 'amaasp','gustavoplm@55gmail.com',2423432,24323)

GO
create table tblProdutos
(
	id int primary key identity(1,1),
	nome varchar(50),
	descricao varchar(80),
	marca varchar (50),
	peso decimal(6,2),
	altura decimal(6,2),
	largura decimal(6,2),
	comprimento decimal(6,2),
	preco decimal(6,2),
)
GO

SELECT * FROM tblCliente
SELECT * FROM tblProdutos


--Tralha

insert into tblProdutos values('Rubens','ele é um RUBANCO bem LOCO','bem loco impolganti leite pao de batata',69.89)
insert into tblProdutos values('FRUIT  DOLLY','Bebida de nectar',' DOLLY',56.30,1.98,3.56,5.97,69.89)
insert into tblProdutos values('TETRAEDRO KRL','VOCE N SABE NEM EU','bem loco impolganti irineu',727)
insert into tblProdutos values('OI MOUTA','Aquele que escreveu Mouta como nome na lista','bem leite eunsei kkj',420)
insert into tblProdutos values('AGORA SIM','Famoso Rodrigao da Massa','fritas francesas JOBS Gabriel TORRES',50)
insert into tblProdutos values('OI, eu sou um tecladinho bunitinho :D','digo, PERFECTUS','PERFEITINHOS PALHACTUOPLANCTUM JOTA É PALHATROLITICO ',999)





