USE Guffi_Tarde

INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES ('Administrador'),('Comum');

INSERT INTO TipoEvento (TituloTipoEvento)
VALUES ('C#'),('React'),('SQL');

INSERT INTO Instituicao (CNPJ, NomeFantasia,Endereco)
VALUES (11111111111111,'Escola Senai de inform�tica', 'Alameda Bar�o de Limeira 538')

INSERT INTO Usuario (Nome, Email,Senha,Genero,DataCadastro,IdTipousuario)
VALUES ('Administrador','adm@adm.com','adm123','N�o Informado','06/02/2020',1),
		('Carol','carol@email.com','carol123','Feminino', '06/02/2020',2),
		('Saulo','saulo@email.com','saulo123','Masculino','06/02/2020',2)

INSERT INTO Evento (NomeEvento,DataEvento,Descricao,AcessoLivre,IdInstituicao,IdTipoEvento)
VALUES 
		('Optimiza��o de banco dados','07/02/2020','Aplica��o de itens calusterizados e n�o clausterizados',2,1,3)
		,('Ciclo de Vida','07/02/2020','Como utilizar o ciclo de vida com ReactJs',0,1,2)
		,('Introdu��o ao C#','07/02/2020','Conceitos sobre os pilares da programa��o orientada a objetos',1,1,1)

INSERT INTO Presenca (IdUsuario,IdEvento,Situacao)
VALUES  (2,2,'Agendada'),(2,1,'Confirmada'),(3,3,'N�o Compareceu')

SELECT*FROM Presenca
SELECT*FROM Evento