--IF OBJECT_ID('Chef', 'U') IS NULL
--BEGIN
--    CREATE TABLE Chef
--        (
--            Id INT IDENTITY(1,1) NOT NULL, 
--            FirstName NVARCHAR(100),
--            LastName NVARCHAR(100)
--        )
--    ALTER TABLE Chef 
--        ADD CONSTRAINT Pk_Chef PRIMARY KEY (Id);
--END
--GO

IF OBJECT_ID('Cuisine', 'U') IS NULL
BEGIN
    CREATE TABLE Cuisine
    (
        Id INT IDENTITY(1,1) NOT NULL,
        [Name] NVARCHAR(100) NOT NULL,
        [Description] NVARCHAR(MAX)
    )
    ALTER TABLE Cuisine 
        ADD CONSTRAINT PK_Cuisine PRIMARY KEY (Id);
END
GO
IF OBJECT_ID('RestaurantCuisine', 'U') IS NULL
BEGIN
    CREATE TABLE RestaurantCuisine
    (
        [RestaurantId] INT NOT NULL,
        [CuisineId] INT NOT NULL
    )
    ALTER TABLE RestaurantCuisine 
        ADD CONSTRAINT PK_RestaurantCuisine PRIMARY KEY (RestaurantId, CuisineId);
	ALTER TABLE RestaurantCuisine 
        ADD CONSTRAINT FK_RestaurantCuisine_Restaurant FOREIGN KEY (RestaurantId)
			REFERENCES Restaurant(Id); 
	ALTER TABLE RestaurantCuisine 
        ADD CONSTRAINT FK_RestaurantCuisine_Cusine FOREIGN KEY (CuisineId)
			REFERENCES Cuisine(Id); 
END
GO