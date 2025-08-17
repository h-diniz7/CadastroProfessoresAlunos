# CadastroProfessoresAlunos
Cadastro de Professores e Alunos em MVC ASP.NET CORE

1. Criar o banco de dados no SQL Server:
   CREATE DATABASE Instituicao_Ensino;

2. Crias as tabelas abaixo:

CREATE TABLE Professores (
	ProfessorId INT IDENTITY(1,1) PRIMARY KEY
,	Nome NVARCHAR(100) NOT NULL	
)

CREATE TABLE Alunos (
	AlunoId INT IDENTITY(1,1) PRIMARY KEY
,	Nome NVARCHAR(100) NOT NULL	
,	Mensalidade DECIMAL(18,2) NOT NULL
,	DataVencimento DATE NOT NULL
,	ProfessorId INT 

FOREIGN KEY(ProfessorId) REFERENCES Professores(ProfessorId)

)   

3. Alterar string de conexão no appsettings.json

