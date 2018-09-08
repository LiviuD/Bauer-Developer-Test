IF OBJECT_ID('Chef', 'U') IS NULL
BEGIN
    CREATE TABLE Chef
        (
            Id INT IDENTITY(1,1) NOT NULL, 
            FirstName NVARCHAR(100),
            LastName NVARCHAR(100)
        )
    ALTER TABLE Chef 
        ADD CONSTRAINT Pk_Chef PRIMARY KEY (Id);
END
GO
IF OBJECT_ID('Restaurant', 'U') IS NULL
BEGIN
    CREATE TABLE Restaurant
    (
        Id INT IDENTITY(1,1) NOT NULL,
        [Name] NVARCHAR(500) NOT NULL,
        ChefId INT,
        Rating SMALLINT,
        AddressLine1 NVARCHAR(500),
        AddressLine2 NVARCHAR(500),
        Suburb NVARCHAR(500),
        [State] NVARCHAR(3),
        PostCode SMALLINT,
        PhoneNumber NVARCHAR(15)
    )
    ALTER TABLE Restaurant 
        ADD CONSTRAINT PK_Restaurant PRIMARY KEY (Id);
    ALTER TABLE Restaurant 
        ADD CONSTRAINT FK_Restaurant_Chef FOREIGN KEY (ChefId) REFERENCES dbo.Chef(Id);
END
GO
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
END
GO