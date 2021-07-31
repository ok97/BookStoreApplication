-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL

alter PROCEDURE sp_GetListOfBooksInCart
	
	@UserId int
AS
BEGIN
	select Carts.UserId,Carts.CartId,Books.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price,Carts.OrderQuantity,(Carts.OrderQuantity*Books.Price) as TotalPrice  from Books  inner join Carts  on  Books.BookId=Carts.BookId AND UserId=@UserId
	UPDATE [dbo].[Carts] SET TotalPrice = TotalPrice WHERE BookId = Carts.BookId
	End
GO
	select * from Books
	drop proc GetListOfBooksInCart

	-----------------
----	main ---- code

select Carts.CartId,Carts.BookId,Carts.OrderQuantity,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Carts LEFT OUTER JOIN Books on Carts.BookId=Books.BookId WHERE UserId=2




	---------------
	select Carts.UserId,Carts.CartId,Carts.BookId,Books.AdminId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Carts LEFT OUTER JOIN Books on Carts.BookId=Books.BookId


	select Carts.UserId,Carts.CartId,Carts.BookId,Books.AdminId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Carts LEFT OUTER JOIN Books on Carts.BookId=Books.BookId WHERE UserId=11

	select * from Carts
	select Carts.CartId,Carts.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Carts LEFT OUTER JOIN Books on Carts.BookId=Books.BookId WHERE UserId=2





select Carts.UserId,Carts.CartId,Books.BookId,Carts.OrderQuantity,Books.Price,(Carts.OrderQuantity*Books.Price) as TotalPrice  from Books  inner join Carts  on Books.BookId=Carts.BookId


	select * from Carts
select Carts.UserId,Carts.CartId,Books.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price,Carts.OrderQuantity,(Carts.OrderQuantity*Books.Price) as TotalPrice  from Books  inner join Carts  on Books.BookId=Carts.BookId