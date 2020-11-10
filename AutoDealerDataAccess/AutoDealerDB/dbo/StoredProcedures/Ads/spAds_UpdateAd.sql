CREATE PROCEDURE [dbo].[spAds_UpdateAd]
	@Id INT,
	@Title NVARCHAR(50),	
	@Description NVARCHAR(1000),
	@Price MONEY,
	@ModelName NVARCHAR(30), 
	@Kilometers NVARCHAR(7), 
	@CubicCapacity NVARCHAR(5), 
	@HorsePower NVARCHAR(5), 
	@Kilowatts NVARCHAR(5),
	@ClientName NVARCHAR(50), 
	@Address NVARCHAR(100), 
	@City NVARCHAR(30), 
	@ZIP NVARCHAR(10), 
	@Country NVARCHAR(30), 
	@Phone NVARCHAR(20),
	@ClientId INT,
	@BrandId INT,
	@CarBodyTypeId INT,
	@CarConditionId INT,
	@ColorId INT,
	@FuelId INT,
	@ProductionYearId INT
AS
	SET NOCOUNT ON;
BEGIN TRY
	UPDATE [dbo].[Ads]
	SET [Title] = @Title,
		[Description] = @Description,
		[Price] = @Price,
		[ModelName] = @ModelName, 
		[Kilometers] = @Kilometers, 
		[CubicCapacity] = @CubicCapacity, 
		[HorsePower] = @HorsePower, 
		[Kilowatts] = @Kilowatts,
		[ClientName] = @ClientName, 
	    [Address] = @Address, 
	    [City] = @City, 
	    [ZIP] = @ZIP, 
	    [Country] = @Country, 
	    [Phone] = @Phone,
		[ClientId] = @ClientId,
		[BrandId] = @BrandId, 
		[CarBodyTypeId] = @CarBodyTypeId, 
		[CarConditionId] = @CarConditionId, 
		[ColorId] = @ColorId, 
		[FuelId] = @FuelId, 
		[ProductionYearId] = @ProductionYearId
	WHERE [Id] = @Id;
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO