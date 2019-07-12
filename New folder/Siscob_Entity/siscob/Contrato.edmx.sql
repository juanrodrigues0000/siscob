
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/04/2019 10:45:57
-- Generated from EDMX file: C:\Benner\projetos\siscob\siscob\Contrato.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TesteDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DocumentoContrato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentoSet] DROP CONSTRAINT [FK_DocumentoContrato];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaContrato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContratoSet] DROP CONSTRAINT [FK_EmpresaContrato];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionarioContrato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuncionarioSet] DROP CONSTRAINT [FK_FuncionarioContrato];
GO
IF OBJECT_ID(N'[dbo].[FK_ContratoPagamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PagamentoSet] DROP CONSTRAINT [FK_ContratoPagamento];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteContrato_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteContrato] DROP CONSTRAINT [FK_ClienteContrato_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteContrato_Contrato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteContrato] DROP CONSTRAINT [FK_ClienteContrato_Contrato];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientePagamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PagamentoSet] DROP CONSTRAINT [FK_ClientePagamento];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteSet] DROP CONSTRAINT [FK_ClienteCliente];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ContratoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContratoSet];
GO
IF OBJECT_ID(N'[dbo].[EmpresaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpresaSet];
GO
IF OBJECT_ID(N'[dbo].[DocumentoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentoSet];
GO
IF OBJECT_ID(N'[dbo].[FuncionarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuncionarioSet];
GO
IF OBJECT_ID(N'[dbo].[PagamentoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PagamentoSet];
GO
IF OBJECT_ID(N'[dbo].[ClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteSet];
GO
IF OBJECT_ID(N'[dbo].[ClienteContrato]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteContrato];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ContratoSet'
CREATE TABLE [dbo].[ContratoSet] (
    [IdContrato] int IDENTITY(1,1) NOT NULL,
    [NomeTitular] nvarchar(45)  NOT NULL,
    [ValorContrato] float  NOT NULL,
    [Garantia] nvarchar(45)  NOT NULL,
    [EmpresaIdEmpresa] int  NOT NULL,
    [PagamentoIdPagamento] int  NOT NULL,
    [Funcionario1_IdFuncionario] int  NOT NULL
);
GO

-- Creating table 'EmpresaSet'
CREATE TABLE [dbo].[EmpresaSet] (
    [IdEmpresa] int IDENTITY(1,1) NOT NULL,
    [NomeEmpresa] nvarchar(45)  NOT NULL
);
GO

-- Creating table 'DocumentoSet'
CREATE TABLE [dbo].[DocumentoSet] (
    [IdDocumento] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(45)  NOT NULL,
    [IdCliente] int  NOT NULL,
    [Contrato_IdContrato] int  NOT NULL
);
GO

-- Creating table 'FuncionarioSet'
CREATE TABLE [dbo].[FuncionarioSet] (
    [IdFuncionario] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(45)  NOT NULL,
    [login] nvarchar(45)  NOT NULL,
    [Senha] nvarchar(45)  NOT NULL,
    [Funcao] nvarchar(45)  NOT NULL
);
GO

-- Creating table 'PagamentoSet'
CREATE TABLE [dbo].[PagamentoSet] (
    [IdPagamento] int IDENTITY(1,1) NOT NULL,
    [ValorIntegralDaParcela] float  NOT NULL,
    [ValorEmAberto] float  NOT NULL,
    [ContratoIdContrato] int  NOT NULL,
    [ClienteIdCliente] int  NOT NULL
);
GO

-- Creating table 'ClienteSet'
CREATE TABLE [dbo].[ClienteSet] (
    [IdCliente] int IDENTITY(1,1) NOT NULL,
    [NomeCompleto] nvarchar(45)  NOT NULL,
    [CPF] nvarchar(11)  NOT NULL,
    [CNPJ] nvarchar(14)  NOT NULL,
    [Endereco] nvarchar(45)  NOT NULL,
    [SituacaoJuridica] int  NOT NULL,
    [Categoria] int  NOT NULL,
    [Associados] int  NOT NULL,
    [ClienteIdCliente] int  NOT NULL
);
GO

-- Creating table 'ClienteContrato'
CREATE TABLE [dbo].[ClienteContrato] (
    [Cliente_IdCliente] int  NOT NULL,
    [Contrato_IdContrato] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdContrato] in table 'ContratoSet'
ALTER TABLE [dbo].[ContratoSet]
ADD CONSTRAINT [PK_ContratoSet]
    PRIMARY KEY CLUSTERED ([IdContrato] ASC);
GO

-- Creating primary key on [IdEmpresa] in table 'EmpresaSet'
ALTER TABLE [dbo].[EmpresaSet]
ADD CONSTRAINT [PK_EmpresaSet]
    PRIMARY KEY CLUSTERED ([IdEmpresa] ASC);
GO

-- Creating primary key on [IdDocumento] in table 'DocumentoSet'
ALTER TABLE [dbo].[DocumentoSet]
ADD CONSTRAINT [PK_DocumentoSet]
    PRIMARY KEY CLUSTERED ([IdDocumento] ASC);
GO

-- Creating primary key on [IdFuncionario] in table 'FuncionarioSet'
ALTER TABLE [dbo].[FuncionarioSet]
ADD CONSTRAINT [PK_FuncionarioSet]
    PRIMARY KEY CLUSTERED ([IdFuncionario] ASC);
GO

-- Creating primary key on [IdPagamento] in table 'PagamentoSet'
ALTER TABLE [dbo].[PagamentoSet]
ADD CONSTRAINT [PK_PagamentoSet]
    PRIMARY KEY CLUSTERED ([IdPagamento] ASC);
GO

-- Creating primary key on [IdCliente] in table 'ClienteSet'
ALTER TABLE [dbo].[ClienteSet]
ADD CONSTRAINT [PK_ClienteSet]
    PRIMARY KEY CLUSTERED ([IdCliente] ASC);
GO

-- Creating primary key on [Cliente_IdCliente], [Contrato_IdContrato] in table 'ClienteContrato'
ALTER TABLE [dbo].[ClienteContrato]
ADD CONSTRAINT [PK_ClienteContrato]
    PRIMARY KEY CLUSTERED ([Cliente_IdCliente], [Contrato_IdContrato] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Contrato_IdContrato] in table 'DocumentoSet'
ALTER TABLE [dbo].[DocumentoSet]
ADD CONSTRAINT [FK_DocumentoContrato]
    FOREIGN KEY ([Contrato_IdContrato])
    REFERENCES [dbo].[ContratoSet]
        ([IdContrato])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentoContrato'
CREATE INDEX [IX_FK_DocumentoContrato]
ON [dbo].[DocumentoSet]
    ([Contrato_IdContrato]);
GO

-- Creating foreign key on [EmpresaIdEmpresa] in table 'ContratoSet'
ALTER TABLE [dbo].[ContratoSet]
ADD CONSTRAINT [FK_EmpresaContrato]
    FOREIGN KEY ([EmpresaIdEmpresa])
    REFERENCES [dbo].[EmpresaSet]
        ([IdEmpresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaContrato'
CREATE INDEX [IX_FK_EmpresaContrato]
ON [dbo].[ContratoSet]
    ([EmpresaIdEmpresa]);
GO

-- Creating foreign key on [ContratoIdContrato] in table 'PagamentoSet'
ALTER TABLE [dbo].[PagamentoSet]
ADD CONSTRAINT [FK_ContratoPagamento]
    FOREIGN KEY ([ContratoIdContrato])
    REFERENCES [dbo].[ContratoSet]
        ([IdContrato])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratoPagamento'
CREATE INDEX [IX_FK_ContratoPagamento]
ON [dbo].[PagamentoSet]
    ([ContratoIdContrato]);
GO

-- Creating foreign key on [Cliente_IdCliente] in table 'ClienteContrato'
ALTER TABLE [dbo].[ClienteContrato]
ADD CONSTRAINT [FK_ClienteContrato_Cliente]
    FOREIGN KEY ([Cliente_IdCliente])
    REFERENCES [dbo].[ClienteSet]
        ([IdCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Contrato_IdContrato] in table 'ClienteContrato'
ALTER TABLE [dbo].[ClienteContrato]
ADD CONSTRAINT [FK_ClienteContrato_Contrato]
    FOREIGN KEY ([Contrato_IdContrato])
    REFERENCES [dbo].[ContratoSet]
        ([IdContrato])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteContrato_Contrato'
CREATE INDEX [IX_FK_ClienteContrato_Contrato]
ON [dbo].[ClienteContrato]
    ([Contrato_IdContrato]);
GO

-- Creating foreign key on [ClienteIdCliente] in table 'PagamentoSet'
ALTER TABLE [dbo].[PagamentoSet]
ADD CONSTRAINT [FK_ClientePagamento]
    FOREIGN KEY ([ClienteIdCliente])
    REFERENCES [dbo].[ClienteSet]
        ([IdCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientePagamento'
CREATE INDEX [IX_FK_ClientePagamento]
ON [dbo].[PagamentoSet]
    ([ClienteIdCliente]);
GO

-- Creating foreign key on [ClienteIdCliente] in table 'ClienteSet'
ALTER TABLE [dbo].[ClienteSet]
ADD CONSTRAINT [FK_ClienteCliente]
    FOREIGN KEY ([ClienteIdCliente])
    REFERENCES [dbo].[ClienteSet]
        ([IdCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteCliente'
CREATE INDEX [IX_FK_ClienteCliente]
ON [dbo].[ClienteSet]
    ([ClienteIdCliente]);
GO

-- Creating foreign key on [Funcionario1_IdFuncionario] in table 'ContratoSet'
ALTER TABLE [dbo].[ContratoSet]
ADD CONSTRAINT [FK_ContratoFuncionario]
    FOREIGN KEY ([Funcionario1_IdFuncionario])
    REFERENCES [dbo].[FuncionarioSet]
        ([IdFuncionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratoFuncionario'
CREATE INDEX [IX_FK_ContratoFuncionario]
ON [dbo].[ContratoSet]
    ([Funcionario1_IdFuncionario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------