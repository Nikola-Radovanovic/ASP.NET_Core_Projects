CREATE PROCEDURE [dbo].[spAds_GetAdById]
	@Id INT
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Title], [DatePosted], [Description], [Price], [ModelName], [Kilometers], [CubicCapacity], [HorsePower],
		   [Kilowatts], [ClientName], [Address], [City], [ZIP], [Country], [Phone], [ClientId], [BrandId], [CarBodyTypeId],
		   [CarConditionId], [ColorId], [FuelId], [ProductionYearId]
	FROM [dbo].[Ads]
	WHERE [Id] = @Id;
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO