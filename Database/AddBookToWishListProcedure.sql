
create procedure sp_AddBookToWishList
	@UserId int,
	@BookId int
	
	
	as 
	begin
	Insert into WishList (UserId ,BookId) values (@UserId,@BookId)
	End