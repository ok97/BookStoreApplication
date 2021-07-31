create procedure sp_AddBookIntoCartQauntity
@UserId int,
	@BookId int,
	@OrderQuantity int
	
	as 
	begin
	UPDATE [dbo].[Carts] SET OrderQuantity = @OrderQuantity WHERE BookId = @BookId
	End

	select * from Carts