create procedure sp_AddBookIntoCart
	@UserId int,
	@BookId int
	
	
	as 
	begin
	Insert into Carts (UserId ,BookId) values (@UserId,@BookId)
	End

	drop proc sp_AddBookIntoCart

	select * from Carts