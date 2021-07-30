create PROCEDURE sp_GetListOfReview	
	@UserId int
AS
BEGIN
	select Review.UserId,Books.BookId,Books.Name,Books.Author,Books.Language,Books.Category,Books.Pages,Books.Price, Review.Review,Review.Feedback from Books  inner join Review  on  Books.BookId=Review.BookId AND UserId=@UserId
END
GO


select * from Review