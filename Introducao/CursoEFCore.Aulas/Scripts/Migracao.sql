﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(80) NOT NULL,
    [Telefone] CHAR(11) NULL,
    [CEP] CHAR(8) NOT NULL,
    [Estado] CHAR(2) NOT NULL,
    [Cidade] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [produtos] (
    [Id] int NOT NULL IDENTITY,
    [CodigoBarras] VARCHAR(14) NOT NULL,
    [Descricao] VARCHAR(60) NULL,
    [Valor] decimal(18,2) NOT NULL,
    [TipoProduto] nvarchar(max) NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_produtos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [pedidos] (
    [Id] int NOT NULL IDENTITY,
    [ClienteId] int NOT NULL,
    [IniciadoEm] datetime2 NOT NULL DEFAULT (GETDATE()),
    [FinalizadoEm] datetime2 NOT NULL,
    [TipoFrete] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [Observacao] VARCHAR(512) NULL,
    CONSTRAINT [PK_pedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_pedidos_clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [pedidos_itens] (
    [Id] int NOT NULL IDENTITY,
    [PedidoId] int NOT NULL,
    [ProdutoId] int NOT NULL,
    [Quantidade] int NOT NULL DEFAULT 1,
    [Valor] decimal(18,2) NOT NULL,
    [Desconto] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_pedidos_itens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_pedidos_itens_pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [pedidos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_pedidos_itens_produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [produtos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [ix_cliente_telefone] ON [clientes] ([Telefone]);
GO

CREATE INDEX [IX_pedidos_ClienteId] ON [pedidos] ([ClienteId]);
GO

CREATE INDEX [IX_pedidos_itens_PedidoId] ON [pedidos_itens] ([PedidoId]);
GO

CREATE INDEX [IX_pedidos_itens_ProdutoId] ON [pedidos_itens] ([ProdutoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211003193744_PrimeiraMigracao', N'5.0.10');
GO

COMMIT;
GO

