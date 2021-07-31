

create procedure sp_GetListOfBooksId
	@BookId int
	as begin
	select * from  [dbo].[Books] where BookId=@BookId
	End

	select Carts.UserId,Carts.CartId,Books.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price,Carts.OrderQuantity,(Carts.OrderQuantity*Books.Price) as TotalPrice  from Books  inner join Carts  on  Books.BookId=Carts.BookId AND UserId=@UserId