IF OBJECT_ID('dbo.sp_UpdateRestaurant', 'P') IS NOT NULL
	DROP PROCEDURE dbo.sp_UpdateRestaurant
GO
CREATE PROCEDURE [dbo].[sp_UpdateRestaurant]
    -- Add the parameters for the stored procedure here
    @Id int,
    @Name VARCHAR(500),
    @CuisineId int,
	@Chef NVARCHAR(500),
	@Rating tinyint,
	@AddressLine1 VARCHAR(500),
	@AddressLine2 VARCHAR(500),
	@Suburb VARCHAR(500),
	@State VARCHAR(3),
	@PostCode VARCHAR(4),
	@PhoneNumber VARCHAR(10)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    Update [dbo].[Restaurant] 
    SET 
		[Name] = @Name,
		CuisineId = @CuisineId,
		Chef = @Chef,
		Rating = @Rating,
		AddressLine1 = @AddressLine1,
		AddressLine2 = @AddressLine2,
		Suburb = @Suburb,
		[State] = @State,
		PostCode = @PostCode,
		PhoneNumber = @PhoneNumber
    where Id = @Id;

END