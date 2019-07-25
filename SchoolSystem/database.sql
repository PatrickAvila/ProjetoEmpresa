----    CRIA BANCO DE DADOS
--  IF(EXISTS(SELECT * FROM sys.databases WHERE UPPER(name) = UPPER('schoolSystem')))
--   BEGIN
 --   	DROP DATABASE schoolSystem;
 --    CREATE DATABASE schoolSystem;
--    	USE schoolSystem
--   END
--GO

 --CRIA TABELA MATERIA
CREATE TABLE Materia(
   idMateria INT NOT NULL IDENTITY(1,1),
   Nome      VARCHAR(255),
   Descricao VARCHAR(255),
   dataCadastro DATETIME DEFAULT GETDATE(),
   dataAtualizacao DATETIME
);
--CRIA CHAVE PRIMAIRA IDMATEIRA
ALTER TABLE Materia ADD CONSTRAINT PK_MATERIA
 			PRIMARY KEY (idMateria) 
GO
--CRIA TABELA ALUNO 
CREATE TABLE Aluno(
  idAluno INT NOT NULL IDENTITY(1,1),
  Nome   VARCHAR(255),
  Endereco VARCHAR(255),
  Cep VARCHAR(17),
  Telefone VARCHAR(17),
  Celular VARCHAR(17),
  dataNascimento DATE,
  dataCadastro DATETIME DEFAULT GETDATE(),
  dataAtualizacao DATETIME
 );
--CRIA CHAVE PRIMARIA IDALUNO 
 ALTER TABLE Aluno ADD CONSTRAINT PK_ALUNO
 			 PRIMARY KEY (idAluno)  
GO
--CRIA TABELA CURSO
CREATE TABLE Curso(
  idCurso INT NOT NULL IDENTITY(1,1),
  idAluno INT NOT NULL,
  idMateria INT NOT NULL,
  Nome VARCHAR(255),
  Descricao VARCHAR(255),
  dataCadastro DATETIME DEFAULT GETDATE(),
  dataAtualizacao DATETIME
);
--CRIA CHAVE PRIMARIA IDCURSO
ALTER TABLE Curso ADD CONSTRAINT PK_CURSO
			PRIMARY KEY (idCurso)
GO 
--CRIA CHAVE ESTRANGEIRA IDMATEIRA
ALTER TABLE Curso ADD CONSTRAINT FK_MATERIA
			FOREIGN KEY (idAluno) REFERENCES Aluno (idAluno)
GO
--CRIA CHAVE ESTRANGEIRA IDALUNO
ALTER TABLE Curso ADD CONSTRAINT FK_ALUNO
		    FOREIGN KEY (idMateria) REFERENCES Materia (idMateria)