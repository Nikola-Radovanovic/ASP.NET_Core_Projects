﻿CREATE PROCEDURE [dbo].[spCarBodyTypes_GetBodyTypes]
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [BodyType]
	FROM [dbo].[CarBodyTypes];
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO