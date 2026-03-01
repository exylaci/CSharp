-- Unit teszteléshez DROP-ok:
-- IF OBJECT_ID('Kolcsonzok', 'U') IS NOT NULL DROP TABLE Kolcsonzok;
-- IF OBJECT_ID('Jarmuvek', 'U') IS NOT NULL DROP TABLE Jarmuvek;
-- IF OBJECT_ID('Autok', 'U') IS NOT NULL DROP TABLE Autok;
-- IF OBJECT_ID('Motorok', 'U') IS NOT NULL DROP TABLE Motorok;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Kolcsonzok' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE Kolcsonzok(
        Nev              NVARCHAR(30)    NOT NULL,
        Cim              NVARCHAR(60)    NOT NULL,
	MaxJarmu         TINYINT         NOT NULL,
        CONSTRAINT       PK_Kolcsonzok
            PRIMARY KEY  (Nev, Cim)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Jarmuvek' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE Jarmuvek(
        Rendszam         NVARCHAR(7)     NOT NULL,
        Marka            NVARCHAR(20)    NOT NULL,
        Foglalt          BIT             NOT NULL,
        KolcsonzoNev     NVARCHAR(30)    NOT NULL,
        KolcsonzoCim     NVARCHAR(60)    NOT NULL,
        CONSTRAINT       PK_Jarmuvek
            PRIMARY KEY  (Rendszam),
        CONSTRAINT       FK_Jarmuvek_Kolcsonzok
            FOREIGN KEY  (KolcsonzoNev, KolcsonzoCim)
            REFERENCES   dbo.Kolcsonzok(Nev, Cim)
            ON UPDATE CASCADE
            ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Autok' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE Autok(
        Rendszam         NVARCHAR(7)     NOT NULL,
	Kialakitas	 NVARCHAR(20)    NOT NULL,
        CONSTRAINT       PK_Autok
            PRIMARY KEY  (Rendszam),
        CONSTRAINT       FK_Autok_Jarmuvek
            FOREIGN KEY  (Rendszam)
            REFERENCES   dbo.Jarmuvek(Rendszam)
            ON UPDATE CASCADE
            ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Motorok' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE Motorok(
        Rendszam         NVARCHAR(7)     NOT NULL,
        Kobcenti         SMALLINT        NOT NULL,
        CONSTRAINT       PK_Motorok
            PRIMARY KEY  (Rendszam),
        CONSTRAINT       FK_Motorok_Jarmuvek
            FOREIGN KEY  (Rendszam)
            REFERENCES   dbo.Jarmuvek(Rendszam)
            ON UPDATE CASCADE
            ON DELETE NO ACTION
    );
END;