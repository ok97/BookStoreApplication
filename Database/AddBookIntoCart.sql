create procedure sp_AddBookIntoCart
	@UserId int,
	@BookId int,
	@IsUsed varchar(20)
	
	as 
	begin
	Insert into [dbo].[Carts] values ( @UserId,@BookId ,@IsUsed)
	End

	drop proc sp_AddBookIntoCart