
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
-- );

-- -- Crie a tabela de clientes
-- CREATE TABLE TB_Clientes (
--     Id INT IDENTITY(1,1) PRIMARY KEY,
--     Nome NVARCHAR(255),
--     Email NVARCHAR(100) UNIQUE, -- Garante e-mails únicos
--     Logotipo NVARCHAR(Max),
--     LogradouroId INT, -- Chave estrangeira para a tabela de logradouros
-- );

-- -- Defina a restrição de chave estrangeira para o campo LogradouroId
-- ALTER TABLE TB_Clientes
-- ADD CONSTRAINT FK_Clientes_Logradouros FOREIGN KEY (LogradouroId)
-- REFERENCES TB_Logradouros (Id);
