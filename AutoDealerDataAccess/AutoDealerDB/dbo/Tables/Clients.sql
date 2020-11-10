﻿CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[DateRegistered] DATETIME2 NOT NULL,
	[ClientName] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	[City] NVARCHAR(30) NOT NULL,
	[ZIP] NVARCHAR(10) NOT NULL,
	[Country] NVARCHAR(30) NOT NULL,
	[Phone]	NVARCHAR(20) NOT NULL
)