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
