DECLARE @Id INT, @Name NVARCHAR(MAX);
-- Asian = 1,
SET @Id = 1; SET @Name = 'Asian';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Chinese = 2,
SET @Id = 2; SET @Name = 'Chinese';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         English = 3,
SET @Id = 3; SET @Name = 'English';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         European = 4,
SET @Id = 4; SET @Name = 'European';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         French = 5,
SET @Id = 5; SET @Name = 'French';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Greek = 6,
SET @Id = 6; SET @Name = 'Greek';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Indian = 7,
SET @Id = 7; SET @Name = 'Indian';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Indonesian = 8,
SET @Id = 8; SET @Name = 'Indonesian';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Italian = 9,
SET @Id = 9; SET @Name = 'Italian';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Japanese = 10,
SET @Id = 10; SET @Name = 'Japanese';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Korean = 11,
SET @Id = 11; SET @Name = 'Korean';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         LatinAmerican = 12,
SET @Id = 12; SET @Name = 'Latin American';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Lebanese = 13,
SET @Id = 13; SET @Name = 'Lebanese';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Malaysian = 14,
SET @Id = 14; SET @Name = 'Malaysian';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Mediterranean = 15,
SET @Id = 15; SET @Name = 'Mediterranean';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Mexican = 16,
SET @Id = 16; SET @Name = 'Mexican';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         MiddleEastern = 17,
SET @Id = 17; SET @Name = 'Middle Eastern';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         ModernAustralian = 18,
SET @Id = 18; SET @Name = 'Modern Australian';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         ModernEuropean = 19,
SET @Id = 19; SET @Name = 'Modern European';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Seafood = 20,
SET @Id = 20; SET @Name = 'Seafood';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Spanish = 21,
SET @Id = 21; SET @Name = 'Spanish';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Steak = 22,
SET @Id = 22; SET @Name = 'Steak';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Thai = 23,
SET @Id = 23; SET @Name = 'Thai';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Turkish = 24,
SET @Id = 24; SET @Name = 'Turkish';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Vietnamese = 25,
SET @Id = 25; SET @Name = 'Vietnamese';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Argentine = 26,
SET @Id = 26; SET @Name = 'Argentine';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         ModernAsian = 27,
SET @Id = 27; SET @Name = 'Modern Asian';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         NorthAfrican = 28,
SET @Id = 28; SET @Name = 'North African';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         Pizza = 29,
SET @Id = 29; SET @Name = 'Pizza';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END
--         American = 30
SET @Id = 30; SET @Name = 'American';
IF NOT EXISTS(SELECT NULL FROM Cuisine WHERE Id = @Id)
BEGIN
    INSERT INTO Cuisine
    SELECT @Id, @Name;
END

