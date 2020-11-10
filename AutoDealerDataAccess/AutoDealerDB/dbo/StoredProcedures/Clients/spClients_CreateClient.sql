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