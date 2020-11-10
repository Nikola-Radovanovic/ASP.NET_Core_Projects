CREATE PROCEDURE [dbo].[spAds_GetAds]
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [Title], [DatePosted], [Description], [Price], [ModelName], [Kilometers], [CubicCapacity], [HorsePower],
		   [Kilowatts], [ClientName], [Address], [City], [ZIP], [Country], [Phone], [ClientId], [BrandId], [CarBodyTypeId], 
		   [CarConditionId], [ColorId], [FuelId], [ProductionYearId] 
	FROM [dbo].[Ads];
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO