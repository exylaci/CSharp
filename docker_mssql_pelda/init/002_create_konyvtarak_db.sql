USE master;
GO

IF DB_ID(N'Konyvtarak') IS NULL
BEGIN
    CREATE DATABASE [Konyvtarak];
END;
GO

USE [Konyvtarak];
GO

IF OBJECT_ID(N'dbo.Konyvmoly') IS NULL
BEGIN
    CREATE TABLE [dbo].[Konyvmoly](
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Nev] NVARCHAR(60) NOT NULL,
        CONSTRAINT [Konyvmoly_PK] PRIMARY KEY([Id])
    );
END;
GO

IF OBJECT_ID(N'dbo.KonyvKategoria') IS NULL
BEGIN
    CREATE TABLE [dbo].[KonyvKategoria](
        [Id] INT NOT NULL IDENTITY(1, 1),
        [KategoriaNev] NVARCHAR(30) NOT NULL,
        CONSTRAINT [KonyvKategoria_PK] PRIMARY KEY([Id])
    );
END;
GO

IF OBJECT_ID(N'dbo.Varosok') IS NULL
BEGIN
    CREATE TABLE [dbo].[Varosok](
        [Irsz] SMALINT NOT NULL,
        [VarosNev] NVARCHAR(30) NOT NULL,
        CONSTRAINT [Varosok_PK] PRIMARY KEY([Irsz])
    );
END;
GO

IF OBJECT_ID(N'dbo.Konyv') IS NULL
BEGIN
    CREATE TABLE [dbo].[Varosok](
        [ISBN] NVARCHAR(20) NOT NULL,
        [Szerzo] NVARCHAR(60) NOT NULL,
        [Cim] NVARCHAR(60) NOT NULL,
        [KonyvKategoria] INT NOT NULL,
        CONSTRAINT [Konyv_PK] PRIMARY KEY([ISBN])
        CONSTRAINT [Konyv_KonyvKategoria_FK] FOREIGN KEY([KategoriaId]) REFERENCES [dbo].[KonyvKategoria]([Id])
    );
END;
GO

IF OBJECT_ID(N'dbo.Konyvtar') IS NULL
BEGIN
    CREATE TABLE [dbo].[Konyvtar](
        [Id] INT NOT NULL IDENTITY(1,1),
        [Tulajdonos] NVARCHAR(60) NOT NULL,
        [Irsz] SMALINT NOT NULL,
        [Utca] NVARCHAR(60) NOT NULL,
        [HSZ] SMALINT NOT NULL,
        CONSTRAINT [Konyvtar_PK] PRIMARY KEY([Id])
        CONSTRAINT [Konyvtar_Varosok_FK] FOREIGN KEY([Irsz]) REFERENCES [dbo].[Varosok]([Irsz])
    );
END;
GO

IF OBJECT_ID(N'dbo.KonyvtarKonyvei') IS NULL
BEGIN
CREATE TABLE [dbo].[KonyvtarKonyvei](
    [ISBN] NVARCHAR(20) NOT NULL,
    [KonyvtarId] INT NOT NULL,
    [Db] INT NULL,
    CONSTRAINT [KonyvtarKonyvei_PK] PRIMARY KEY([ISBN], [KonyvtarId),
    CONSTRAINT [KonyvtarKonyvei_Konyv_FK] FOREIGN KEY([ISBN]) REFERENCES [dbo].[Konyv]([ISBN]),
    CONSTRAINT [KonyvtarKonyvei_Konyvtar_FK] FOREIGN KEY([KonyvtarId]) REFERENCES [dbo].[Konyvtar]([Id])
);
END;
