--USE cidades
--GO

--CREATE TABLE [dbo].[Cidades](
--    [Codigo] [int] IDENTITY(1,1) NOT NULL,
--    [NomeCidade] [nvarchar](450) NOT NULL,
--    [UF] [nvarchar](2) NOT NULL,
--    CONSTRAINT [PK_Cidades] PRIMARY KEY (Codigo),
--)
--GO

----DBCC CHECKIDENT('Cidades', RESEED, 0)

--INSERT INTO dbo.Cidades
--           (NomeCidade
--           ,UF)
--     VALUES
--           ('Porto Alegre'
--           ,'RS')
 
--INSERT INTO dbo.Cidades
--            (NomeCidade
--           ,UF)
--     VALUES
--           ('Alvorada'
--           ,'RS')
 
--INSERT INTO dbo.Cidades
--           (NomeCidade
--           ,UF)
--     VALUES
--           ('Florianópolis'
--           ,'SC')

--INSERT INTO dbo.Cidades
--           (NomeCidade
--           ,UF)
--     VALUES
--           ('Joinville'
--           ,'SC')

--INSERT INTO dbo.Cidades
--           (NomeCidade
--           ,UF)
--     VALUES
--           ('Blumenau'
--           ,'SC')


