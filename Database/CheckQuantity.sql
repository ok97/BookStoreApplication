
alter procedure sp_SelectQuantity
	@BookId int,
	@Quantity int out
	
	
	AS
BEGIN
	select @Quantity=Quantity from Books
 WHERE BookId=@BookId 
	End


	
	declare @Quantity int
	exec sp_SelectQuantity 1,@Quantity out 
	print @Quantity



	select * from Books
	select * from Carts