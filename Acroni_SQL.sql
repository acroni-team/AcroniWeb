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

UPDATE tblCliente SET usuario = 'Mota',senha = 'oimota' WHERE email = 'oimota@gmail.com'

ALTER TABLE tblCliente add cep varchar(15), cpf varchar(15)
