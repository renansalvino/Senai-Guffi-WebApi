--DQL--
--Listar todos os usuarios cadastrados --
SELECT Nome,Email,IdTipousuario,DataCadastro,Genero FROM Usuario

--Listar todas as instituições cadastradas --
SELECT CNPJ,NomeFantasia,Endereco FROM Instituicao

--Listar todos os eventos --
SELECT NomeEvento,TipoEvento.TituloTipoEvento,DataEvento,AcessoLivre,Descricao,CNPJ,NomeFantasia,Endereco
FROM Evento 
INNER JOIN Instituicao
ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN TipoEvento
ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento

--Listar Todos os eventos que um determinado usuário participa --
SELECT Evento.NomeEvento AS 'Nome Do Evento'
      ,Evento.DataEvento AS 'Data do Evento'
	  ,Evento.AcessoLivre AS 'Controle de acesso'
	  ,Evento.Descricao	AS	'Descrição do Evento'
	  ,Instituicao.CNPJ
	  ,Instituicao.NomeFantasia
	  ,Instituicao.Endereco
	  ,Usuario.Nome
	  ,Usuario.Email
	  ,Usuario.Senha
	  ,Usuario.DataCadastro
	  ,Usuario.Genero
FROM Evento
INNER JOIN Instituicao
ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN Presenca
ON Presenca.IdEvento = Evento.IdEvento
INNER JOIN TipoEvento
ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Usuario
ON Presenca.IdUsuario = Usuario.IdUsuario
WHERE Usuario.IdUsuario = 2;

-- Ao listar os eventos em que os usuarios participa, mostrar apenas os eventos com a situação 'Confirmada'

--EXTRAS --
--1--

 SELECT NomeEvento,AcessoLivre as 'Acessos',
			IIF(AcessoLivre = 0,
				'Privado',
				'Publico') as 'Tipo de acesso'

	FROM Evento

SELECT NomeEvento,
	CASE AcessoLivre
		WHEN 0 THEN 'Publico'
		WHEN 1 THEN 'Privado'
		WHEN 2 THeN 'Cagado'
		END as Status
	FROM Evento

SELECT NomeEvento,
	CASE WHEN AcessoLivre = 0 THEN
	 'Publico'
	 ELSE
	 'Privado'
	 END AS status
	From Evento

--2--

--- AO LISTAR OS EVENTOS QUE UM USUÁRIO PARTICIPA, MOSTRAR APENAS OS EVENTOS COM A SITUAÇÃO'CONFIRMADA'

SELECT Evento.NomeEvento AS 'Nome Do Evento'
      ,Evento.DataEvento AS 'Data do Evento'
	  ,Evento.AcessoLivre AS 'Controle de acesso'
	  ,Evento.Descricao	AS	'Descrição do Evento'
	  ,Usuario.Nome
	  ,Usuario.Email
	  ,Usuario.Senha
	  ,Usuario.DataCadastro
	  ,Usuario.Genero
	  ,Presenca.Situacao
	  FROM Usuario,Evento, Presenca
	  Where Situacao = 'Confirmada' AND Usuario.IdUsuario = 3;


SELECT Usuario.Nome
      ,Usuario.Email
	  ,Usuario.Genero
	  ,TipoUsuario.TituloTipoUsuario 
	  ,DATEDIFF(YY, Usuario.DataCadastro, GETDATE()) -
		CASE
			WHEN DATEADD(YY, DATEDIFF(YY,Usuario.DataCadastro,GETDATE()),Usuario.DataCadastro) 
			> GETDATE() THEN 1
			ELSE 0
		END AS Idade
FROM
Usuario
INNER JOIN
TipoUsuario
ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario





