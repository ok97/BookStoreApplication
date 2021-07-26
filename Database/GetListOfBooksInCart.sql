-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL

CREATE PROCEDURE sp_GetListOfBooksInCart
	
	@UserId int
AS
BEGIN
	
select Carts.CartId,Carts.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Carts LEFT OUTER JOIN Books on Carts.BookId=Books.BookId WHERE UserId=@UserId
END
GO
	select * from Books
	drop proc GetListOfBooksInCart


	select Carts.UserId,Carts.CartId,Carts.BookId,Books.AdminId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Carts LEFT OUTER JOIN Books on Carts.BookId=Books.BookId


	select Carts.UserId,Carts.CartId,Carts.BookId,Books.AdminId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Carts LEFT OUTER JOIN Books on Carts.BookId=Books.BookId WHERE UserId=11

	
	select Carts.CartId,Carts.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Carts LEFT OUTER JOIN Books on Carts.BookId=Books.BookId WHERE UserId=11