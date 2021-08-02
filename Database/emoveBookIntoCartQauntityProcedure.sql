alter procedure sp_removeBookIntoCartQauntity
@UserId int,
	@BookId int,
	@OrderQuantity int
	
	as 
	begin
	UPDATE [dbo].[Carts] SET OrderQuantity = @OrderQuantity WHERE BookId = @BookId
	UPDATE [dbo].[Books] SET Quantity = Quantity+1 WHERE BookId = @BookId
	End

	select * from Carts
		select * from Books