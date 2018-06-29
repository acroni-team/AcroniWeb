CREATE DATABASE DB
GO
USE DB

CREATE TABLE tblCliente (
	id int PRIMARY KEY IDENTITY(1,1),
	usuario VARCHAR(30),
	senha VARCHAR(20),
	nome VARCHAR(50),
	email VARCHAR(30),
	cpf VARCHAR(15),
	data_nascimento date,
	rg VARCHAR(15),
	endereco VARCHAR(50),
	cidade VARCHAR(20),
	cep VARCHAR(15),
	uf VARCHAR(10),
	telefone VARCHAR(15)
)

