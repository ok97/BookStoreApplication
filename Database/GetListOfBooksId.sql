

create procedure sp_GetListOfBooksId
	@BookId int
	as begin
	select * from  [dbo].[Books] where BookId=@BookId
	End