CREATE PROCEDURE [dbo].[spCarConditions_GetCarConditions]
AS
	SET NOCOUNT ON;
BEGIN TRY
	SELECT [Id], [FirstOwner], [Warranty], [Garaged], [ServiceBook], [SpareKey], [Restaurated], 
		   [Oldtimer], [AdaptedForTheDisabled], [TaxiCar], [TestCar], [Tuning]
	FROM [dbo].[CarConditions];
	RETURN 0;
END TRY
BEGIN CATCH
	RETURN ERROR_NUMBER();
END CATCH
GO