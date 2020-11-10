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