USE [Pokedex.DB]

--============================================================
----------------------------CREATE----------------------------
--============================================================

-- 1. Create Table: Pokedex
CREATE TABLE [dbo].[Pokedex] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [Number] nvarchar(3) NOT NULL,
  [Name] nvarchar(255) NOT NULL DEFAULT(N''),
  [NameJapanese] nvarchar(255) NOT NULL DEFAULT(N''),
  [NameRomanji] nvarchar(255) NOT NULL DEFAULT(N''),
  [Type1] nvarchar(255) NOT NULL DEFAULT(N''),
  [Type2] nvarchar(255) NOT NULL DEFAULT(N''),
  [Height] decimal(18, 1) NOT NULL,
  [Weight] decimal(18, 1) NOT NULL,
  [ImageUrl] nvarchar(255) NOT NULL DEFAULT(N''),
  CONSTRAINT [PK_Pokedex] PRIMARY KEY CLUSTERED ([Id])
)
GO

-- 2. Create Store Procedure: Insert
CREATE PROCEDURE [dbo].[sp_Pokedex_Insert]
  @number nvarchar(3),
  @name nvarchar(255),
  @namejapanese nvarchar(255),
  @nameromanji nvarchar(255),
  @type1 nvarchar(255),
  @type2 nvarchar(255),
  @height decimal(18, 1),
  @weight decimal(18, 1),
  @imageurl nvarchar(255)
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
    [Weight],
    [ImageUrl]
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
    @weight,
    @imageurl
  )
GO

-- 3. Create Store Procedure: Get
CREATE PROCEDURE [dbo].[sp_Pokedex_Get]
AS
  SET NOCOUNT ON;

  SELECT  [Pokedex].[Id],
          [Pokedex].[Number],
          [Pokedex].[Name],
          [Pokedex].[NameJapanese],
          [Pokedex].[NameRomanji],
          [Pokedex].[Type1],
          [Pokedex].[Type2],
          [Pokedex].[Height],
          [Pokedex].[Weight],
          [Pokedex].[ImageUrl]
    FROM  [dbo].[Pokedex]
GO

-- 4. Create Store Procedure: Get By Id
CREATE PROCEDURE [dbo].[sp_Pokedex_GetById]
  @id int
AS
  SET NOCOUNT ON;

  SELECT  [Pokedex].[Id],
          [Pokedex].[Number],
          [Pokedex].[Name],
          [Pokedex].[NameJapanese],
          [Pokedex].[NameRomanji],
          [Pokedex].[Type1],
          [Pokedex].[Type2],
          [Pokedex].[Height],
          [Pokedex].[Weight],
          [Pokedex].[ImageUrl]
    FROM  [dbo].[Pokedex]
   WHERE  [Pokedex].[Id] = @id
GO

-- 5. Create Store Procedure: Update By Id
CREATE PROCEDURE [dbo].[sp_Pokedex_Update]
  @id int,
  @number nvarchar(3),
  @name nvarchar(255),
  @namejapanese nvarchar(255),
  @nameromanji nvarchar(255),
  @type1 nvarchar(255),
  @type2 nvarchar(255),
  @height decimal(18,1),
  @weight decimal(18,1),
  @imageurl nvarchar(255)
AS

  UPDATE  [dbo].[Pokedex]
     SET  [Pokedex].[Number] = @number,
          [Pokedex].[Name] = @name,
          [Pokedex].[NameJapanese] = @namejapanese,
          [Pokedex].[NameRomanji] = @nameromanji,
          [Pokedex].[Type1] = @type1,
          [Pokedex].[Type2] = @type2,
          [Pokedex].[Height] = @height,
          [Pokedex].[Weight] = @weight,
          [Pokedex].[ImageUrl] = @imageurl
   WHERE  [Pokedex].[Id] = @id
GO

-- 6. Create Store Procedure: Delete
CREATE PROCEDURE [dbo].[sp_Pokedex_Delete]
AS
  DELETE  [dbo].[Pokedex]
GO

-- 7. Create Store Procedure: Delete By Id
CREATE PROCEDURE [dbo].[sp_Pokedex_DeleteById]
  @id int
AS

  DELETE  [dbo].[Pokedex]
   WHERE  [Pokedex].[Id] = @id
GO

-- 8. Create Store Procedure: Update Image Url
CREATE PROCEDURE [dbo].[sp_Pokedex_Update_ImageUrl]
  @number nvarchar(3)
AS

  UPDATE  [dbo].[Pokedex]
     SET  [Pokedex].[ImageUrl] = '/Images/' + @number + '.png'
   WHERE  [Pokedex].[Number] = @number
GO

--============================================================
----------------------------INSERT----------------------------
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
  @weight = 6.9,
  @imageurl = ''

EXEC  [dbo].[sp_Pokedex_Insert]
  @number = N'002',
  @name = N'Ivysaur',
  @namejapanese = N'フシギソウ',
  @nameromanji = N'Fushigisou',
  @type1 = N'Grass',
  @type2 = N'Poison',
  @height = 1,
  @weight = 13,
  @imageurl = ''

EXEC  [dbo].[sp_Pokedex_Insert]
  @number = N'003',
  @name = N'Venusaur',
  @namejapanese = N'フシギバナ',
  @nameromanji = N'Fushigibana',
  @type1 = N'Grass',
  @type2 = N'Poison',
  @height = 2,
  @weight = 100,
  @imageurl = ''

EXEC  [dbo].[sp_Pokedex_Insert]
  @number = N'004',
  @name = N'Charmander',
  @namejapanese = N'ヒトカゲ',
  @nameromanji = N'Hitokage',
  @type1 = N'Fire',
  @type2 = N'',
  @height = 0.6,
  @weight = 8.5,
  @imageurl = ''

EXEC  [dbo].[sp_Pokedex_Insert]
  @number = N'005',
  @name = N'Charmeleon',
  @namejapanese = N'リザード',
  @nameromanji = N'Lizardo',
  @type1 = N'Fire',
  @type2 = N'',
  @height = 1.1,
  @weight = 19,
  @imageurl = ''

EXEC  [dbo].[sp_Pokedex_Insert]
  @number = N'006',
  @name = N'Charizard',
  @namejapanese = N'リザードン',
  @nameromanji = N'Lizardon',
  @type1 = N'Fire',
  @type2 = N'Flying',
  @height = 1.7,
  @weight = 90.5,
  @imageurl = ''

EXEC  [dbo].[sp_Pokedex_Insert]
  @number = N'007',
  @name = N'Squirtle',
  @namejapanese = N'ゼニガメ',
  @nameromanji = N'Zenigame',
  @type1 = N'Water',
  @type2 = N'',
  @height = 0.5,
  @weight = 9,
  @imageurl = ''

EXEC  [dbo].[sp_Pokedex_Insert]
  @number = N'008',
  @name = N'Wartortle',
  @namejapanese = N'カメール',
  @nameromanji = N'Kameil',
  @type1 = N'Water',
  @type2 = N'',
  @height = 1,
  @weight = 22.5,
  @imageurl = ''

EXEC  [dbo].[sp_Pokedex_Insert]
  @number = N'009',
  @name = N'Blastoise',
  @namejapanese = N'カメックス',
  @nameromanji = N'Kamex',
  @type1 = N'Water',
  @type2 = N'',
  @height = 1.6,
  @weight = 85.5,
  @imageurl = ''

--============================================================
----------------------------UPDATE----------------------------
--============================================================

-- 1. Update Image URL
EXEC  [sp_Pokedex_Update_ImageUrl] '001'
EXEC  [sp_Pokedex_Update_ImageUrl] '002'
EXEC  [sp_Pokedex_Update_ImageUrl] '003'
EXEC  [sp_Pokedex_Update_ImageUrl] '004'
EXEC  [sp_Pokedex_Update_ImageUrl] '005'
EXEC  [sp_Pokedex_Update_ImageUrl] '006'
EXEC  [sp_Pokedex_Update_ImageUrl] '007'
EXEC  [sp_Pokedex_Update_ImageUrl] '008'
EXEC  [sp_Pokedex_Update_ImageUrl] '009'
