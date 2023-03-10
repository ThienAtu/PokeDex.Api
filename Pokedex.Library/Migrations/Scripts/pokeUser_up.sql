USE [Pokedex.DB]

--============================================================
----------------------------CREATE----------------------------
--============================================================

-- 1. Create Table: Poke User
CREATE TABLE [dbo].[PokeUser] (
  [Id] int IDENTITY(1,1) NOT NULL,
  [UserName] nvarchar(255) NOT NULL DEFAULT(N''),
  [Password] nvarchar(max) NOT NULL,
  [RoleId] int NOT NULL DEFAULT('1'),
  [Status] tinyint NOT NULL DEFAULT('1'),
  CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id])
)
GO

-- 2. Create Procedure: Insert Poke User

CREATE PROCEDURE [dbo].[sp_PokeUser_Insert]
  @userName nvarchar(255),
  @password nvarchar(max),
  @roleId int,
  @status tinyint
AS
  INSERT  [dbo].[PokeUser]
  (
    [UserName],
    [Password],
    [RoleId],
    [Status]
  )
  VALUES
  (
    @userName,
    @password,
    @roleId,
    @status
  )
GO

-- 3. Create Store Procedure: Get
CREATE PROCEDURE [dbo].[sp_PokeUser_Get]
AS
  SET NOCOUNT ON;

  SELECT  [Id],
          [UserName],
          [Password],
          [RoleId],
          [Status]
    FROM  [dbo].[PokeUser]
GO

-- 4. Create Store Procedure: Get By Id
CREATE PROCEDURE [dbo].[sp_PokeUser_GetById]
  @id int
AS
  SET NOCOUNT ON;

  SELECT  [Id],
          [UserName],
          [Password],
          [RoleId],
          [Status]
    FROM  [dbo].[PokeUser]
   WHERE  [PokeUser].[Id] = @id
GO

-- 5. Create Store Procedure: Get By User Name
CREATE PROCEDURE [dbo].[sp_PokeUser_GetByUserName]
  @userName nvarchar(255)
AS
  SET NOCOUNT ON;

  SELECT  [Id],
          [UserName],
          [Password],
          [RoleId],
          [Status]
    FROM  [dbo].[PokeUser]
   WHERE  [PokeUser].[UserName] = @userName
GO

-- 6. Create Store Procedure: Check Log In
CREATE PROCEDURE [dbo].[sp_PokeUser_CheckLogIn]
  @userName nvarchar(255),
  @password nvarchar(max)
AS
  SET NOCOUNT ON;

  SELECT  [Id],
          [UserName],
          [Password],
          [RoleId],
          [Status]
    FROM  [dbo].[PokeUser]
   WHERE  [PokeUser].[UserName] = @userName
     AND  [PokeUser].[Password] = @password
GO

-- 7. Create Store Procedure: Get Password Salt
CREATE PROCEDURE [dbo].[sp_PokeUser_GetPasswordSalt]
  @userName nvarchar(255)
AS
  SET NOCOUNT ON;

  SELECT  SUBSTRING([Password], 1, 172)
    FROM  [dbo].[PokeUser]
   WHERE  [PokeUser].[UserName] = @userName
GO
--============================================================
----------------------------INSERT----------------------------
--============================================================

-- 1. Insert
EXEC [dbo].[sp_PokeUser_Insert]
  @userName = 'minhminh',
  @password = '{{ password }}',
  @roleId = '10',
  @status = '1'

--============================================================
----------------------------UPDATE----------------------------
--============================================================

--============================================================
----------------------------CREATE----------------------------
--============================================================
