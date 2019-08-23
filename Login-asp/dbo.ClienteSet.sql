CREATE TABLE [dbo].[ClienteSet] (
    [IdCliente]        INT           IDENTITY (1, 1) NOT NULL,
    [NomeCompleto]     NVARCHAR (45) NOT NULL,
    [CPF]              NVARCHAR (11) NULL,
    [CNPJ]             NVARCHAR (14) NULL,
    [Endereco]         NVARCHAR (45) NOT NULL,
    [SituacaoJuridica] INT           NULL,
    [Categoria]        INT           NOT NULL,
    [Associados]       INT           NULL,
    [ClienteIdCliente] INT           NOT NULL,
	[Telefone] INT NOT NULL,
    CONSTRAINT [PK_ClienteSet] PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    CONSTRAINT [FK_ClienteCliente] FOREIGN KEY ([ClienteIdCliente]) REFERENCES [dbo].[ClienteSet] ([IdCliente])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_ClienteCliente]
    ON [dbo].[ClienteSet]([ClienteIdCliente] ASC);

