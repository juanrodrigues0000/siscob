CREATE TABLE [dbo].[FuncionarioSet] (
    [IdFuncionario]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]                NVARCHAR (45) NOT NULL,
    [login]               NVARCHAR (45) NOT NULL,
    [Senha]               NVARCHAR (45) NOT NULL,
    [Funcao]              NVARCHAR (45) NOT NULL,
    [Contrato_IdContrato] INT           NULL,
    CONSTRAINT [PK_FuncionarioSet] PRIMARY KEY CLUSTERED ([IdFuncionario] ASC),
    CONSTRAINT [FK_FuncionarioContrato] FOREIGN KEY ([Contrato_IdContrato]) REFERENCES [dbo].[ContratoSet] ([IdContrato])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_FuncionarioContrato]
    ON [dbo].[FuncionarioSet]([Contrato_IdContrato] ASC);

