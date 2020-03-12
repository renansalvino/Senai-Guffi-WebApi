-- Cria o banco de dados com o nome Gufi
CREATE DATABASE Guffi_Tarde;


-- Define o banco de dados que será utilizado
USE Guffi_Tarde;


-- Criação das tabelas
CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,TituloTipoUsuario VARCHAR (255) NOT NULL UNIQUE
);


CREATE TABLE TipoEvento (
	IdTipoEvento INT PRIMARY KEY IDENTITY
	,TituloTipoEvento VARCHAR (255) NOT NULL UNIQUE
);


CREATE TABLE Instituicao (
	IdInstituicao INT PRIMARY KEY IDENTITY
	,CNPJ CHAR(14) NOT NULL UNIQUE
	,NomeFantasia VARCHAR (255) NOT NULL UNIQUE
	,Endereco VARCHAR (255) NOT NULL UNIQUE
);


CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY
	,Nome VARCHAR (255) NOT NULL
	,Email VARCHAR (255) NOT NULL UNIQUE
	,Senha VARCHAR (255) NOT NULL
	,DataCadastro DATETIME2 
	,Genero VARCHAR (255)
	,IdTipousuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);


CREATE TABLE Evento (
	IdEvento INT PRIMARY KEY IDENTITY
	,NomeEvento VARCHAR (255) NOT NULL
	,DataEvento DATETIME2 NOT NULL
	,Descricao VARCHAR (255) NOT NULL
	,AcessoLivre BIT DEFAULT (1) NOT NULL
	,IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (IdInstituicao)
	,IdTipoEvento INT FOREIGN KEY REFERENCES TipoEvento (IdTipoEvento)
);

CREATE TABLE Presenca (
	IdPresenca INT PRIMARY KEY IDENTITY
	,IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
	,IdEvento INT FOREIGN KEY REFERENCES Evento (IdEvento)
	,Situacao VARCHAR (255) NOT NULL
);


SELECT * FROM TipoUsuario
SELECT * FROM TipoEvento
SELECT * FROM Instituicao
SELECT * FROM Usuario
SELECT * FROM Evento
SELECT * FROM Presenca




