﻿/*
Deployment script for AutoDealerDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "AutoDealerDB"
:setvar DefaultFilePrefix "AutoDealerDB"
:setvar DefaultDataPath "C:\Users\Johny\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Johny\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Ads]...';


GO
CREATE TABLE [dbo].[Ads] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Title]          NVARCHAR (50)   NULL,
    [DatePosted]     DATETIME2 (7)   NOT NULL,
    [Description]    NVARCHAR (1000) NULL,
    [ClientId]       INT             NOT NULL,
    [BrandId]        INT             NOT NULL,
    [CarBodyTypeId]  INT             NOT NULL,
    [CarConditionId] INT             NOT NULL,
    [ColorId]        INT             NOT NULL,
    [FuelId]         INT             NOT NULL,
    [YearMakeId]     INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Brands]...';


GO
CREATE TABLE [dbo].[Brands] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[CarBodyTypes]...';


GO
CREATE TABLE [dbo].[CarBodyTypes] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [BodyType] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[CarConditions]...';


GO
CREATE TABLE [dbo].[CarConditions] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [FirstOwner]            BIT NULL,
    [Warranty]              BIT NULL,
    [Garaged]               BIT NULL,
    [ServiceBook]           BIT NULL,
    [SpareKey]              BIT NULL,
    [Restaurated]           BIT NULL,
    [Oldtimer]              BIT NULL,
    [AdaptedForTheDisabled] BIT NULL,
    [TaxiCar]               BIT NULL,
    [TestCar]               BIT NULL,
    [Tuning]                BIT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Clients]...';


GO
CREATE TABLE [dbo].[Clients] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [DateRegistered] DATETIME2 (7)  NOT NULL,
    [ClientName]     NVARCHAR (50)  NOT NULL,
    [Address]        NVARCHAR (200) NOT NULL,
    [City]           NVARCHAR (30)  NOT NULL,
    [ZIP]            NVARCHAR (10)  NOT NULL,
    [Country]        NVARCHAR (30)  NOT NULL,
    [Phone]          NVARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Colors]...';


GO
CREATE TABLE [dbo].[Colors] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Fuels]...';


GO
CREATE TABLE [dbo].[Fuels] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [FuelType] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[ProductionYears]...';


GO
CREATE TABLE [dbo].[ProductionYears] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [YearName] NVARCHAR (4) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[spAds_CreateAd]...';


GO
CREATE PROCEDURE [dbo].[spAds_CreateAd]
	@Title NVARCHAR(50),
	@DatePosted DATETIME2,
	@Description NVARCHAR(1000),
	@ClientId INT,
	@BrandId INT,
	@CarBodyTypeId INT,
	@CarConditionId INT,
	@ColorId INT,
	@FuelId INT,
	@YearMakeId INT,
	@Id INT OUTPUT
AS
	SET NOCOUNT ON;
BEGIN TRY
	INSERT INTO [dbo].[Ads]
	([Title], [DatePosted], [Description], [ClientId], [BrandId], 
	 [CarBodyTypeId], [CarConditionId], [ColorId], [FuelId], [YearMakeId])
	VALUES
	(@Title, @DatePosted, @Description, @ClientId, @BrandId, 
	 @CarBodyTypeId, @CarConditionId, @ColorId, @FuelId, @YearMakeId);

	SET @Id = SCOPE_IDENTITY();

	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spAds_DeleteAd]...';


GO
CREATE PROCEDURE [dbo].[spAds_DeleteAd]
	@Id INT
AS
	SET NOCOUNT ON;
BEGIN TRY
	DELETE FROM [dbo].[Ads]
	WHERE [Id] = @Id;
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spAds_GetAdById]...';


GO
CREATE PROCEDURE [dbo].[spAds_GetAdById]
	@Id INT
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [Title], [DatePosted], [Description], [ClientId], [BrandId], 
		   [CarBodyTypeId], [CarConditionId], [ColorId], [FuelId], [YearMakeId]
	FROM [dbo].[Ads]
	WHERE [Id] = @Id;
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spAds_GetAds]...';


GO
CREATE PROCEDURE [dbo].[spAds_GetAds]
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [Title], [DatePosted], [Description], [ClientId], [BrandId], 
		   [CarBodyTypeId], [CarConditionId], [ColorId], [FuelId], [YearMakeId] 
	FROM [dbo].[Ads];
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spAds_UpdateAd]...';


GO
CREATE PROCEDURE [dbo].[spAds_UpdateAd]
	@Id INT,
	@Title NVARCHAR(50),
	@Description NVARCHAR(1000),
	@ClientId INT,
	@BrandId INT,
	@CarBodyTypeId INT,
	@CarConditionId INT,
	@ColorId INT,
	@FuelId INT,
	@YearMakeId INT
AS
	SET NOCOUNT ON;
BEGIN TRY
	UPDATE [dbo].[Ads]
	SET [Title] = @Title, 
		[Description] = @Description, 
		[ClientId] = @ClientId, 
		[BrandId] = @BrandId, 
		[CarBodyTypeId] = @CarBodyTypeId, 
		[CarConditionId] = @CarConditionId, 
		[ColorId] = @ColorId, 
		[FuelId] = @FuelId, 
		[YearMakeId] = @YearMakeId
	WHERE [Id] = @Id;
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spClients_CreateClient]...';


GO
CREATE PROCEDURE [dbo].[spClients_CreateClient]
	@DateRegistered DATETIME2,
	@ClientName NVARCHAR(50), 
	@Address NVARCHAR(200), 
	@City NVARCHAR(30), 
	@ZIP NVARCHAR(10), 
	@Country NVARCHAR(30), 
	@Phone NVARCHAR(20),
	@Id INT OUTPUT
AS
	SET NOCOUNT ON;
BEGIN TRY
	INSERT INTO [dbo].[Clients]
	([DateRegistered], [ClientName], [Address], [City], [ZIP], [Country], [Phone])
	VALUES
	(@DateRegistered, @ClientName, @Address, @City, @ZIP, @Country, @Phone);

	SET @Id = SCOPE_IDENTITY();

	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spClients_DeleteClient]...';


GO
CREATE PROCEDURE [dbo].[spClients_DeleteClient]
	@Id INT
AS
	SET NOCOUNT ON;
BEGIN TRY
	DELETE FROM [dbo].[Clients]
	WHERE [Id] = @Id;
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spClients_GetClientById]...';


GO
CREATE PROCEDURE [dbo].[spClients_GetClientById]
	@Id INT
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [DateRegistered], [ClientName], [Address], [City], [ZIP], [Country], [Phone] 
	FROM [dbo].[Clients]
	WHERE [Id] = @Id;
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spClients_GetClients]...';


GO
CREATE PROCEDURE [dbo].[spClients_GetClients]
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [DateRegistered], [ClientName], [Address], [City], [ZIP], [Country], [Phone] 
	FROM [dbo].[Clients];
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
PRINT N'Creating [dbo].[spClients_UpdateClient]...';


GO
CREATE PROCEDURE [dbo].[spClients_UpdateClient]
	@Id INT,
	@ClientName NVARCHAR(50), 
	@Address NVARCHAR(200), 
	@City NVARCHAR(30), 
	@ZIP NVARCHAR(10), 
	@Country NVARCHAR(30), 
	@Phone NVARCHAR(20)
AS
	SET NOCOUNT ON;
BEGIN TRY
	UPDATE [dbo].[Clients]
	SET [ClientName] = @ClientName, 
		[Address] = @Address, 
		[City] = @City, 
		[ZIP] = @ZIP, 
		[Country] = @Country,
		[Phone] = @Phone
	WHERE [Id] = @Id;
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$TableName]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT [Id], [BrandName] FROM [dbo].[Brands])
BEGIN
    INSERT INTO [dbo].[Brands]
    ([BrandName])
    VALUES
    ('Alfa Romeo'),
    ('Aston Martin'),
    ('Audi'),
    ('Bentley'),
    ('BMW'),
    ('Cadillac'),
    ('Chery'),
    ('Chevrolet'),
    ('Chrysler'),
    ('Citroen'),
    ('Dacia'),
    ('Daewoo'),
    ('Daihatsu'),
    ('Dodge'),
    ('Ferrari'),
    ('Fiat'),
    ('Ford'),
    ('GMC'),
    ('Honda'),
    ('Hummer'),
    ('Hyndai'),
    ('Infinity'),
    ('Isuzu'),
    ('Jaguar'),
    ('Jeep'),
    ('Kia'),
    ('Lada'),
    ('Lamborghini'),
    ('Lancia'),
    ('Land Rover'),
    ('Lexus'),
    ('Mahindra'),
    ('Maserati'),
    ('Maybach'),
    ('Mazda'),
    ('Mercedes Benz'),
    ('Mini'),
    ('Mitsubishi'),
    ('Nissan'),
    ('Opel'),
    ('Peugeot'),
    ('Pontiac'),
    ('Porsche'),
    ('Renault'),
    ('Rolls Royce'),
    ('Rover'),
    ('Saab'),
    ('Seat'),
    ('Smart'),
    ('Subaru'),
    ('Suzuki'),
    ('Tesla'),
    ('Toyota'),
    ('Volkswagen'),
    ('Volvo'),
    ('Zastava'),
    ('Škoda'),
    ('Ostalo');
END

IF NOT EXISTS (SELECT [Id], [BodyType] FROM [dbo].[CarBodyTypes])
BEGIN
    INSERT INTO [dbo].[CarBodyTypes]
    ([BodyType])
    VALUES 
    ('Limousine'),
    ('Hatchback'),
    ('Caravan'),
    ('Coupe'),
    ('Convertible/Roadster'),
    ('MiniVan'),
    ('Jeep/SUV'),
    ('PickUp');
END

IF NOT EXISTS (SELECT [Id], [ColorName] FROM [dbo].[Colors])
BEGIN
    INSERT INTO [dbo].[Colors] 
    ([ColorName]) 
    VALUES 
    ('Blue'),
    ('Red'),
    ('Yellow'),
    ('Green'),
    ('Black'),
    ('White'),
    ('Gray'),
    ('Brown'),
    ('Pink'),
    ('Violet'),
    ('Orange'),
    ('Gold'),
    ('Silver'),
    ('Beige');
END

IF NOT EXISTS (SELECT [Id], [FuelType] FROM [dbo].[Fuels])
BEGIN
    INSERT INTO [dbo].[Fuels] 
    ([FuelType]) 
    VALUES 
    ('Gasoline'),
    ('Diesel'),
    ('TNG'),
    ('Metan(CNG)'),
    ('E-Car'),
    ('Hybrid');
END

IF NOT EXISTS (SELECT [Id], [YearName] FROM [dbo].[ProductionYears])
BEGIN
    INSERT INTO [dbo].[ProductionYears] 
    ([YearName]) 
    VALUES 
    ('1970'),
    ('1971'),
    ('1972'),
    ('1973'),
    ('1974'),
    ('1975'),
    ('1976'),
    ('1977'),
    ('1978'),
    ('1979'),
    ('1980'),
    ('1981'),
    ('1982'),
    ('1983'),
    ('1984'),
    ('1985'),
    ('1986'),
    ('1987'),
    ('1988'),
    ('1989'),
    ('1990'),
    ('1991'),
    ('1992'),
    ('1993'),
    ('1994'),
    ('1995'),
    ('1996'),
    ('1997'),
    ('1998'),
    ('1999'),
    ('2000'),
    ('2001'),
    ('2002'),
    ('2003'),
    ('2004'),
    ('2005'),
    ('2006'),
    ('2007'),
    ('2008'),
    ('2009'),
    ('2010'),
    ('2011'),
    ('2012'),
    ('2013'),
    ('2014'),
    ('2015'),
    ('2016'),
    ('2017'),
    ('2018'),
    ('2019'),
    ('2020');
END
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
