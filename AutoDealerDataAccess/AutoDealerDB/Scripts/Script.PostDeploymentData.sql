/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$TableName]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT [Id], [BrandName] FROM [dbo].[Brands])
BEGIN
    INSERT INTO [dbo].[Brands]
    ([BrandName])
    VALUES
    ('Alfa Romeo'),
    ('Aston Martin'),
    ('Audi'),
    ('Bentley'),
    ('BMW'),
    ('Cadillac'),
    ('Chery'),
    ('Chevrolet'),
    ('Chrysler'),
    ('Citroen'),
    ('Dacia'),
    ('Daewoo'),
    ('Daihatsu'),
    ('Dodge'),
    ('Ferrari'),
    ('Fiat'),
    ('Ford'),
    ('GMC'),
    ('Honda'),
    ('Hummer'),
    ('Hyndai'),
    ('Infinity'),
    ('Isuzu'),
    ('Jaguar'),
    ('Jeep'),
    ('Kia'),
    ('Lada'),
    ('Lamborghini'),
    ('Lancia'),
    ('Land Rover'),
    ('Lexus'),
    ('Mahindra'),
    ('Maserati'),
    ('Maybach'),
    ('Mazda'),
    ('Mercedes Benz'),
    ('Mini'),
    ('Mitsubishi'),
    ('Nissan'),
    ('Opel'),
    ('Peugeot'),
    ('Pontiac'),
    ('Porsche'),
    ('Renault'),
    ('Rolls Royce'),
    ('Rover'),
    ('Saab'),
    ('Seat'),
    ('Smart'),
    ('Subaru'),
    ('Suzuki'),
    ('Tesla'),
    ('Toyota'),
    ('Volkswagen'),
    ('Volvo'),
    ('Zastava'),
    ('Škoda'),
    ('Ostalo');
END

IF NOT EXISTS (SELECT [Id], [BodyType] FROM [dbo].[CarBodyTypes])
BEGIN
    INSERT INTO [dbo].[CarBodyTypes]
    ([BodyType])
    VALUES 
    ('Limousine'),
    ('Hatchback'),
    ('Caravan'),
    ('Coupe'),
    ('Convertible/Roadster'),
    ('MiniVan'),
    ('Jeep/SUV'),
    ('PickUp');
END

IF NOT EXISTS (SELECT [Id], [ColorName] FROM [dbo].[Colors])
BEGIN
    INSERT INTO [dbo].[Colors] 
    ([ColorName]) 
    VALUES 
    ('Blue'),
    ('Red'),
    ('Yellow'),
    ('Green'),
    ('Black'),
    ('White'),
    ('Gray'),
    ('Brown'),
    ('Pink'),
    ('Violet'),
    ('Orange'),
    ('Gold'),
    ('Silver'),
    ('Beige');
END

IF NOT EXISTS (SELECT [Id], [FuelType] FROM [dbo].[Fuels])
BEGIN
    INSERT INTO [dbo].[Fuels] 
    ([FuelType]) 
    VALUES 
    ('Gasoline'),
    ('Diesel'),
    ('TNG'),
    ('Metan(CNG)'),
    ('E-Car'),
    ('Hybrid');
END

IF NOT EXISTS (SELECT [Id], [YearName] FROM [dbo].[ProductionYears])
BEGIN
    INSERT INTO [dbo].[ProductionYears] 
    ([YearName]) 
    VALUES 
    ('1970'),
    ('1971'),
    ('1972'),
    ('1973'),
    ('1974'),
    ('1975'),
    ('1976'),
    ('1977'),
    ('1978'),
    ('1979'),
    ('1980'),
    ('1981'),
    ('1982'),
    ('1983'),
    ('1984'),
    ('1985'),
    ('1986'),
    ('1987'),
    ('1988'),
    ('1989'),
    ('1990'),
    ('1991'),
    ('1992'),
    ('1993'),
    ('1994'),
    ('1995'),
    ('1996'),
    ('1997'),
    ('1998'),
    ('1999'),
    ('2000'),
    ('2001'),
    ('2002'),
    ('2003'),
    ('2004'),
    ('2005'),
    ('2006'),
    ('2007'),
    ('2008'),
    ('2009'),
    ('2010'),
    ('2011'),
    ('2012'),
    ('2013'),
    ('2014'),
    ('2015'),
    ('2016'),
    ('2017'),
    ('2018'),
    ('2019'),
    ('2020');
END
GO