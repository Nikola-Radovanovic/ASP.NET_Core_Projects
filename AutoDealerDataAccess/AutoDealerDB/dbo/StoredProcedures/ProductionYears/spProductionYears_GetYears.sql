﻿CREATE PROCEDURE [dbo].[spProductionYears_GetYears]
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [YearName]
	FROM [dbo].[ProductionYears];
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO