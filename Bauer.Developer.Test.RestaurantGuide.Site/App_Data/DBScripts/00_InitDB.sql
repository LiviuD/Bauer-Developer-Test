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
