USE Gufi_Renan

INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES ('Administrador'),('Comum');

INSERT INTO TipoEvento (TituloTipoEvento)
VALUES ('C#'),('React'),('SQL');

INSERT INTO Instituicao (CNPJ, NomeFantasia,Endereco)
VALUES (11111111111111,'Escola Senai de informática', 'Alameda Barão de Limeira 538')

INSERT INTO Usuario (Nome, Email,Senha,Genero,DataCadastro,IdTipousuario)
VALUES ('Administrador','adm@adm.com','adm123','Não Informado','06/02/2020',1),
		('Carol','carol@email.com','carol123','Feminino', '06/02/2020',2),
		('Saulo','saulo@email.com','saulo123','Masculino','06/02/2020',2)

INSERT INTO Evento (NomeEvento,DataEvento,Descricao,AcessoLivre,IdInstituicao,IdTipoEvento)
VALUES 
		('Optimização de banco dados','07/02/2020','Aplicação de itens calusterizados e não clausterizados',2,1,3)

INSERT INTO Presenca (IdUsuario,IdEvento,Situacao)
VALUES  (2,2,'Agendada'),(2,3,'Confirmada'),(3,1,'Não Compareceu')
