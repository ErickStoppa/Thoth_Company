# AgendaApp

# Descrição
- Mini documentação da aplicação AgendaApp, um sistema de gerenciamento de compromissos com controle de acesso por usuário, desenvolvido em C# Windows Forms (.NET Framework 4.7.2) e SQL Server.

# Funcionalidades:
- Cadastro e autenticação de usuários
- CRUD de compromissos (Criar, Ler, Atualizar, Excluir)
- Acesso restrito: cada usuário vê apenas seus compromissos
- Logout e retorno à tela de login

# Estrutura do Projeto:

![image](https://github.com/user-attachments/assets/4310b607-ce6f-41c9-9000-12adf120959d)

# Banco de Dados:
- Nome: AgendaDB

# Criação e tabelas:
-- 1) Cria o banco (se ainda não existir):

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AgendaDB')
    CREATE DATABASE AgendaDB;
GO
USE AgendaDB;
GO

-- 2) Tabela de Usuários:

CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    SenhaHash VARBINARY(32) NOT NULL,
    Salt VARBINARY(16) NOT NULL
);
GO

-- 3) Tabela de Compromissos:

CREATE TABLE Compromissos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT NOT NULL
        CONSTRAINT FK_Compromissos_Usuarios
        REFERENCES Usuarios(Id)
        ON DELETE CASCADE,
    Titulo VARCHAR(100) NOT NULL,
    Descricao VARCHAR(500) NULL,
    DataHora DATETIME NOT NULL
);
GO

# Como Rodar?:
- Abra o SQL Server Management Studio e execute o script acima para criar o banco e tabelas.
- No Visual Studio 2022 (ou 2019), abra a solução AgendaApp.sln.
- Ajuste a connection string em Data/Database.cs se necessário (instância LocalDB ou nome do servidor).
- IMPORTANTE!!! Restaure pacotes NuGet: Dapper e System.Data.SqlClient.
- Compile e execute o projeto. A tela de login aparecerá.
- Use Cadastrar-se para criar seu usuário e, em seguida, faça login.
- No MainForm, gerencie seus compromissos com os botões Novo, Editar, Excluir e faça Logout para voltar ao login.

# Observações:
- Senhas são armazenadas com salt e hash via PBKDF2 para maior segurança.
- Cada usuário só vê seus próprios compromissos graças ao filtro por UsuarioId.
