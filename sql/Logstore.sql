SET DATEFORMAT ymd
SET ARITHABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
SET NUMERIC_ROUNDABORT, IMPLICIT_TRANSACTIONS, XACT_ABORT OFF
GO

USE Logstore
GO

IF DB_NAME() <> N'Logstore' SET NOEXEC ON
GO

--
-- Create table [dbo].[Produto]
--
PRINT (N'Create table [dbo].[Produto]')
GO
CREATE TABLE dbo.Produto (
  Id int IDENTITY,
  Descricao varchar(100) NULL,
  VlUnitario decimal(18, 2) NULL,
  CONSTRAINT PK_Produto_Id PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
GO

--
-- Create table [dbo].[Endereco]
--
PRINT (N'Create table [dbo].[Endereco]')
GO
CREATE TABLE dbo.Endereco (
  Id int IDENTITY,
  Logradouro varchar(150) NULL,
  Bairro varchar(50) NULL,
  Numero varchar(5) NULL,
  Complemento varchar(50) NULL,
  Municipio varchar(50) NULL,
  Cep varchar(9) NULL,
  CONSTRAINT PK_Endereco_Id PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
GO

--
-- Create table [dbo].[Cliente]
--
PRINT (N'Create table [dbo].[Cliente]')
GO
CREATE TABLE dbo.Cliente (
  Id int IDENTITY,
  IdEndereco int NULL,
  Nome varchar(100) NULL,
  Telefone varchar(12) NULL,
  CONSTRAINT PK_Cliente_Id PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
GO

--
-- Create table [dbo].[PedidoItem]
--
PRINT (N'Create table [dbo].[PedidoItem]')
GO
CREATE TABLE dbo.PedidoItem (
  Id int IDENTITY,
  IdPedido int NULL,
  IdProduto int NULL,
  VlUnitario decimal(18, 2) NULL,
  QtdItem int NULL,
  Referencia int NULL,
  CONSTRAINT PK_PedidoItem_Id PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
GO

--
-- Create table [dbo].[Pedido]
--
PRINT (N'Create table [dbo].[Pedido]')
GO
CREATE TABLE dbo.Pedido (
  Id int IDENTITY,
  IdCliente int NULL,
  VlTotal decimal(18, 2) NULL,
  QtdItens int NULL,
  DtPedido datetime NULL,
  IdEndereco int NULL,
  CONSTRAINT PK_Pedido_Id PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
GO
-- 
-- Dumping data for table Cliente
--
PRINT (N'Dumping data for table Cliente')
SET IDENTITY_INSERT dbo.Cliente ON
GO
INSERT dbo.Cliente(Id, IdEndereco, Nome, Telefone) VALUES (3, 3, 'Diego', '33332211')
GO
SET IDENTITY_INSERT dbo.Cliente OFF
GO
-- 
-- Dumping data for table Endereco
--
PRINT (N'Dumping data for table Endereco')
SET IDENTITY_INSERT dbo.Endereco ON
GO
INSERT dbo.Endereco(Id, Logradouro, Bairro, Numero, Complemento, Municipio, Cep) VALUES (3, 'Rua 2', 'Bairro 1', '3', 'Casa', 'Vitoria', '2900000')
GO
SET IDENTITY_INSERT dbo.Endereco OFF
GO
-- 
-- Dumping data for table Produto
--
PRINT (N'Dumping data for table Produto')
SET IDENTITY_INSERT dbo.Produto ON
GO
INSERT dbo.Produto(Id, Descricao, VlUnitario) VALUES (1, '3 Queijos', 50.00)
INSERT dbo.Produto(Id, Descricao, VlUnitario) VALUES (2, 'Frango com requeijão', 59.99)
INSERT dbo.Produto(Id, Descricao, VlUnitario) VALUES (3, 'Mussarela', 42.50)
INSERT dbo.Produto(Id, Descricao, VlUnitario) VALUES (4, 'Calabresa', 42.50)
INSERT dbo.Produto(Id, Descricao, VlUnitario) VALUES (5, 'Pepperoni', 55.00)
INSERT dbo.Produto(Id, Descricao, VlUnitario) VALUES (6, 'Portuguesa', 45.00)
INSERT dbo.Produto(Id, Descricao, VlUnitario) VALUES (7, 'Veggie', 59.99)
GO
SET IDENTITY_INSERT dbo.Produto OFF
GO

USE Logstore
GO

IF DB_NAME() <> N'Logstore' SET NOEXEC ON
GO

--
-- Create foreign key [FK_Cliente_Endereco_Id] on table [dbo].[Cliente]
--
PRINT (N'Create foreign key [FK_Cliente_Endereco_Id] on table [dbo].[Cliente]')
GO
ALTER TABLE dbo.Cliente
  ADD CONSTRAINT FK_Cliente_Endereco_Id FOREIGN KEY (IdEndereco) REFERENCES dbo.Endereco (Id)
GO

--
-- Create foreign key [FK_Pedido_Cliente_Id] on table [dbo].[Pedido]
--
PRINT (N'Create foreign key [FK_Pedido_Cliente_Id] on table [dbo].[Pedido]')
GO
ALTER TABLE dbo.Pedido
  ADD CONSTRAINT FK_Pedido_Cliente_Id FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente (Id)
GO

--
-- Create foreign key [FK_Pedido_Endereco_Id] on table [dbo].[Pedido]
--
PRINT (N'Create foreign key [FK_Pedido_Endereco_Id] on table [dbo].[Pedido]')
GO
ALTER TABLE dbo.Pedido
  ADD CONSTRAINT FK_Pedido_Endereco_Id FOREIGN KEY (IdEndereco) REFERENCES dbo.Endereco (Id)
GO

--
-- Create foreign key [FK_PedidoItem_Pedido_Id] on table [dbo].[PedidoItem]
--
PRINT (N'Create foreign key [FK_PedidoItem_Pedido_Id] on table [dbo].[PedidoItem]')
GO
ALTER TABLE dbo.PedidoItem
  ADD CONSTRAINT FK_PedidoItem_Pedido_Id FOREIGN KEY (IdPedido) REFERENCES dbo.Pedido (Id)
GO

--
-- Create foreign key [FK_PedidoItem_Produto_Id] on table [dbo].[PedidoItem]
--
PRINT (N'Create foreign key [FK_PedidoItem_Produto_Id] on table [dbo].[PedidoItem]')
GO
ALTER TABLE dbo.PedidoItem
  ADD CONSTRAINT FK_PedidoItem_Produto_Id FOREIGN KEY (IdProduto) REFERENCES dbo.Produto (Id)
GO
SET NOEXEC OFF
GO