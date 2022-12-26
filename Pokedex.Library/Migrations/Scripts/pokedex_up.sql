USE [Pokedex.DB]

-- 1. Create table
CREATE TABLE [dbo].[Pokedex](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [Number] [nvarchar](3) NOT NULL,
  [Name] [nvarchar](200) NOT NULL,
  [NameJapanese] [nvarchar](200) NOT NULL,
  [NameRomanji] [nvarchar](200) NOT NULL,
  [Type1] [nvarchar](200) NOT NULL,
  [Type2] [nvarchar](200) NOT NULL,
  [Height] [decimal](18, 1) NOT NULL,
  [Weight] [decimal](18, 1) NOT NULL,
  CONSTRAINT [PK_Pokedex] PRIMARY KEY CLUSTERED ([Id])
)
GO

-- 2. Create Store Procedure: Insert
CREATE PROCEDURE [dbo].[sp_Pokedex_Insert]
  @number [nvarchar](3),
  @name [nvarchar](200),
  @namejapanese [nvarchar](200),
  @nameromanji [nvarchar](200),
  @type1 [nvarchar](200),
  @type2 [nvarchar](200),
  @height [decimal](18, 1),
  @weight [decimal](18, 1)
AS

  INSERT  [dbo].[Pokedex]
  (
    [Number],
    [Name],
    [NameJapanese],
    [NameRomanji],
    [Type1],
    [Type2],
    [Height],
    [Weight]
  )
  VALUES
  (
    @number,
    @name,
    @namejapanese,
    @nameromanji,
    @type1,
    @type2,
    @height,
    @weight
  )
GO

-- 2. Create default data
--SET IDENTITY_INSERT [dbo].[Pokedex] ON 
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (1, N'001', N'Bulbasaur', N'フシギダネ', N'Fushigidane', N'Grass', N'Poison', CAST(0.7 AS Decimal(18, 1)), CAST(6.9 AS Decimal(18, 1)))
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (2, N'002', N'Ivysaur', N'フシギソウ', N'Fushigisou', N'Grass', N'Poison', CAST(1.0 AS Decimal(18, 1)), CAST(13.0 AS Decimal(18, 1)))
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (3, N'003', N'Venusaur', N'フシギバナ', N'Fushigibana', N'Grass', N'Poison', CAST(2.0 AS Decimal(18, 1)), CAST(100.0 AS Decimal(18, 1)))
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (4, N'004', N'Charmander', N'ヒトカゲ', N'Hitokage', N'Fire', N'', CAST(0.6 AS Decimal(18, 1)), CAST(8.5 AS Decimal(18, 1)))
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (5, N'005', N'Charmeleon', N'リザード', N'Lizardo', N'Fire', N'', CAST(1.1 AS Decimal(18, 1)), CAST(19.0 AS Decimal(18, 1)))
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (6, N'006', N'Charizard', N'リザードン', N'Lizardon', N'Fire', N'Flying', CAST(1.7 AS Decimal(18, 1)), CAST(90.5 AS Decimal(18, 1)))
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (7, N'007', N'Squirtle', N'ゼニガメ', N'Zenigame', N'Water', N'', CAST(0.5 AS Decimal(18, 1)), CAST(9.0 AS Decimal(18, 1)))
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (8, N'008', N'Wartortle', N'カメール', N'Kameil', N'Water', N'', CAST(1.0 AS Decimal(18, 1)), CAST(22.5 AS Decimal(18, 1)))
--INSERT [dbo].[Pokedex] ([Id], [Number], [Name], [NameJapanese], [NameRomanji], [Type1], [Type2], [Height], [Weight]) VALUES (9, N'009', N'Blastoise', N'カメックス', N'Kamex', N'Water', N'', CAST(1.6 AS Decimal(18, 1)), CAST(85.5 AS Decimal(18, 1)))
--SET IDENTITY_INSERT [dbo].[Pokedex] OFF
--GO

-- 3. Create Store Procedure: Get all
--CREATE PROCEDURE [dbo].[sp_Pokedex_GetAll]
--AS
--  SET NOCOUNT ON;

--  SELECT  [Pokedex].[Id],
--          [Pokedex].[Number],
--          [Pokedex].[Name],
--          [Pokedex].[NameJapanese],
--          [Pokedex].[NameRomanji],
--          [Pokedex].[Type1],
--          [Pokedex].[Type12,
--          [Pokedex].[Height],
--          [Pokedex].[Weight]
--    FROM  [dbo].[Pokedex]
--GO

-- 3. Create Store Procedure: Get by Id
--CREATE PROCEDURE [dbo].[sp_Pokedex_GetById]
--  @id [nvarchar] (254)
--AS
--  SET NOCOUNT ON;

--  SELECT  [Pokedex].[Id],
--          [Pokedex].[Number],
--          [Pokedex].[Name],
--          [Pokedex].[NameJapanese],
--          [Pokedex].[NameRomanji],
--          [Pokedex].[Type1],
--          [Pokedex].[Type12,
--          [Pokedex].[Height],
--          [Pokedex].[Weight]
--    FROM  [dbo].[Pokedex]
--   WHERE  [Pokedex].[Id] = @id
--GO

--============================================================
--------------------------------------------------------------
--============================================================

-- 1. Insert
EXEC  [dbo].[sp_Pokedex_Insert]
      @number = N'001',
      @name = N'Bulbasaur',
      @namejapanese = N'フシギダネ',
      @nameromanji = N'Fushigidane',
      @type1 = N'Grass',
      @type2 = N'Poison',
      @height = 0.7,
      @weight = 6.9

EXEC  [dbo].[sp_Pokedex_Insert]
      @number = N'001',
      @name = N'Bulbasaur',
      @namejapanese = N'フシギダネ',
      @nameromanji = N'Fushigidane',
      @type1 = N'Grass',
      @type2 = N'Poison',
      @height = 0.7,
      @weight = 6.9