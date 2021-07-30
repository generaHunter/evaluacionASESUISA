
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movimientos'
CREATE TABLE [dbo].[Movimientos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Moviemientos] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Palabras'
CREATE TABLE [dbo].[Palabras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Palabras] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [PK_Movimientos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Palabras'
ALTER TABLE [dbo].[Palabras]
ADD CONSTRAINT [PK_Palabras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

INSERT INTO [dbo].[Moviemientos] ([Id], [Moviemiento]) VALUES (1, N'Piedra')
INSERT INTO [dbo].[Moviemientos] ([Id], [Moviemiento]) VALUES (2, N'Tijera')
INSERT INTO [dbo].[Moviemientos] ([Id], [Moviemiento]) VALUES (3, N'Papel')
GO

INSERT INTO [dbo].[Palabras] ([Id], [Palabra]) VALUES (1, N'DERECHA')
INSERT INTO [dbo].[Palabras] ([Id], [Palabra]) VALUES (2, N'SI')
INSERT INTO [dbo].[Palabras] ([Id], [Palabra]) VALUES (3, N'RELOJ')
INSERT INTO [dbo].[Palabras] ([Id], [Palabra]) VALUES (4, N'NOCHE')
INSERT INTO [dbo].[Palabras] ([Id], [Palabra]) VALUES (5, N'LAPIZ')
INSERT INTO [dbo].[Palabras] ([Id], [Palabra]) VALUES (6, N'BIBLIOTECA')
GO
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------