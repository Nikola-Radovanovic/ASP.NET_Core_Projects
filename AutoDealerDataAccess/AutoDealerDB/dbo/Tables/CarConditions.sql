CREATE TABLE [dbo].[CarConditions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstOwner] BIT NULL,
	[Warranty] BIT NULL,
	[Garaged] BIT NULL,
	[ServiceBook] BIT NULL,
	[SpareKey] BIT NULL,
	[Restaurated] BIT NULL,
	[Oldtimer] BIT NULL,
	[AdaptedForTheDisabled] BIT NULL,
	[TaxiCar] BIT NULL,
	[TestCar] BIT NULL,
	[Tuning] BIT NULL
)