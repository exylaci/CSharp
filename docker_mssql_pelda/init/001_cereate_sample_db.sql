IF DB_ID('CarRental') IS NULL
BEGIN
    CREATE DATABASE CarRental;
END;
GO

USE CarRental;
GO

IF OBJECT_ID('dbo.Cars') IS NULL
BEGIN
    CREATE TABLE dbo.Cars (
        Id INT IDENTITY PRIMARY KEY,
        PlateNumber NVARCHAR(10) NOT NULL UNIQUE,
        Brand NVARCHAR(50) NOT NULL,
        Model NVARCHAR(50) NOT NULL,
        IsAvailable BIT NOT NULL DEFAULT 1
    );
    INSERT INTO db.Cars (PlateNumber, Brand, Model, IsAvailable)
    VALUES (N'ABC-123', N'Opel', N'Astra', 1),
       (N'DEF-456', N'Toyota', N'Corolla', 1);
END;
