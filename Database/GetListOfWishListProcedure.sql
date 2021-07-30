

alter PROCEDURE sp_GetListOfWishList
	
	@UserId int
AS
BEGIN
	select WishList.WishListId,WishList.UserId,WishList.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Books  inner join WishList  on  Books.BookId=WishList.BookId AND UserId=@UserId
END
GO

select * from Books
select WishList.WishListId, WishList.UserId,WishList.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price from Books  inner join WishList  on  Books.BookId=WishList.BookId AND UserId=1