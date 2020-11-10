﻿CREATE PROCEDURE [dbo].[spBrands_GetBrands]
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [BrandName]
	FROM [dbo].[Brands];
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO