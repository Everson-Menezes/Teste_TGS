
-- -- Crie a base de dados TGS, se ainda não existir
-- CREATE DATABASE TGS;

-- -- Crie a tabela de logradouros
-- CREATE TABLE TB_Logradouros (
--     Id INT IDENTITY(1,1) PRIMARY KEY,
--     Rua NVARCHAR(200),
--     Cidade NVARCHAR(50),
--     Bairro NVARCHAR(50),
--     Estado NVARCHAR(50),
--     Pais NVARCHAR(50),
--     Cep NVARCHAR(8),
--     ClienteId INT, -- Chave estrangeira para a tabela de Clientes

-- );

-- -- Crie a tabela de clientes
-- CREATE TABLE TB_Clientes (
--     Id INT IDENTITY(1,1) PRIMARY KEY,
--     Nome NVARCHAR(255),
--     Email NVARCHAR(100) UNIQUE, -- Garante e-mails únicos
--     Logotipo NVARCHAR(Max),
-- );

-- -- Defina a restrição de chave estrangeira para o campo ClienteId
-- ALTER TABLE TB_Logradouros
-- ADD CONSTRAINT FK_Clientes_Logradouros FOREIGN KEY (ClienteId)
-- REFERENCES TB_Clientes (Id);

-- --Insert
-- INSERT INTO TB_Logradouros (Rua,Cidade,Bairro,Estado,Pais,Cep,ClienteId)
-- VALUES ('Rua das violetas, 127', 'São Bernardo do Campo', 'Assunção', 'São Paulo', 'Brasil', '09811190', 1);

-- INSERT INTO TB_Clientes (Nome,Email,Logotipo)
-- VALUES ('Everson', 'Everson@Email.com.br', 'vazio');