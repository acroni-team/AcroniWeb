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
INSERT INTO tblCliente VALUES ('Mota','oi','jota@jot.com',28128192,219219201)
SELECT * FROM tblCliente Where usuario = 'tm22' and senha = '123'
delete from tblCliente

GO
create table tblProdutos
(
	id int primary key identity(1,1),
	nome varchar(50),
	descricao varchar(80),
	espec varchar (80),
	preco decimal(6,2),
)
GO
insert into tblProdutos values('Rubens','ele é um RUBANCO bem LOCO','bem loco impolganti leite pao de batata',69,89)
insert into tblProdutos values('TETRAEDRO KRL','VOCE N SABE NEM EU','bem loco impolganti irineu',727)
insert into tblProdutos values('OI MOUTA','Aquele que escreveu Mouta como nome na lista','bem leite eunsei kkj',420)
insert into tblProdutos values('AGORA SIM','Famoso Rodrigao da Massa','fritas francesas JOBS Gabriel TORRES',50)
insert into tblProdutos values('OI, eu sou um tecladinho bunitinho :D','digo, PERFECTUS','PERFEITINHOS PALHACTUOPLANCTUM JOTA É PALHATROLITICO ',999)

--OMEGALUL

UPDATE tblCliente SET usuario = 'Mota',senha = 'oimota' WHERE email = 'oimota@gmail.com'

ALTER TABLE tblCliente add cep varchar(15), cpf varchar(15)
