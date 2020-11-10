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