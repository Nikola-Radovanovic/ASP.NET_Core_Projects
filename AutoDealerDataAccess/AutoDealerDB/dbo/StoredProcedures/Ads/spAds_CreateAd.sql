CREATE PROCEDURE [dbo].[spAds_CreateAd]
	@Title NVARCHAR(50),
	@DatePosted DATETIME2,
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
	@ProductionYearId INT,
	@Id INT OUTPUT
AS
	SET NOCOUNT ON;
BEGIN TRY
	INSERT INTO [dbo].[Ads]
	([Title], [DatePosted], [Description], [Price], [ModelName], [Kilometers], [CubicCapacity], [HorsePower],
	 [Kilowatts], [ClientName], [Address], [City], [ZIP], [Country], [Phone], [ClientId], [BrandId], [CarBodyTypeId], 
	 [CarConditionId], [ColorId], [FuelId], [ProductionYearId])
	VALUES
	(@Title, @DatePosted, @Description, @Price, @ModelName, @Kilometers, @CubicCapacity, @HorsePower, 
	 @Kilowatts, @ClientName, @Address, @City, @ZIP, @Country, @Phone, @ClientId, @BrandId, @CarBodyTypeId, 
	 @CarConditionId, @ColorId, @FuelId, @ProductionYearId);

	SET @Id = SCOPE_IDENTITY();

	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO