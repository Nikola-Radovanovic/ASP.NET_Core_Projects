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